using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using Classics_2014.MySQL;

namespace Classics_2014.Accuracy
{
    // Working 29/10/14.
    class AccuracyEventController
    {
        #region variables and the such like
        Engine engine;
        TWind[] IncomingData;
        int NumberOfLandings = 0;
        public List<Accuracy.AccuracyLanding> Landings = new List<Accuracy.AccuracyLanding>();
        public List<Accuracy_Event> Events = new List<Accuracy_Event>();
        Boolean lostSerial = false;
        SQL_Controller SQL_Controller;
        IO_Controller IO_Controller;
        Thread ListenThread;
        public accuracyEventLandingColumn column;
        public readonly ConcurrentQueue<Data> Data_queueEvent = new ConcurrentQueue<Data>();
        #endregion

        public AccuracyEventController(SQL_Controller SQL_Controller, IO_Controller IO_Controller, Engine engine)
        {
            this.SQL_Controller = SQL_Controller;
            column = new accuracyEventLandingColumn(this);
            this.IO_Controller = IO_Controller;
            this.engine = engine;
            ListenThread = new Thread(new ThreadStart(ListenProcedure));
        }

        private void ListenProcedure()
        {
            IncomingData = new TWind[60];
            do
            {
                Data Data;
                Data_Accuracy DataA = new Data_Accuracy();
                IO_Controller._signal.WaitOne();
                while (Data_queueEvent.TryDequeue(out Data))
                {
                    DataA = (Data as Data_Accuracy);
                    if (DataA != null)
                    {
                        if (lostSerial)
                        {
                            lostSerial = false;
                            LostSerial(new TWind { time = DataA.Time, speed = Data.Speed, direction = DataA.Direction });
                        }
                        for (int i = IncomingData.Length; i > 0; i--)
                        {
                            if (i != IncomingData.Length && i >= 1)
                            {
                                IncomingData[i] = IncomingData[i - 1];
                            }
                        }
                        IncomingData[0] = new TWind { time = Data.Time, speed = DataA.Speed, direction = DataA.Direction };
                        if (DataA.IsLanding)
                        {
                            NumberOfLandings++;
                            AccuracyLanding newLanding = new AccuracyLanding { index = NumberOfLandings, ID = 0, score = DataA.LandingScore, windDataPrior = (TWind[])IncomingData.Clone(), time = DataA.Time,  windDataAfter = new TWind[60] };
                            Landings.Add(newLanding);
                            column.AddLanding(newLanding);
                            column.UpdateScore(DataA.LandingScore.ToString());
                        }
                        for (int i = 0; i < Landings.Count; i++)
                        {
                            AccuracyLanding currentLanding = Landings[i];
                            if (currentLanding.windEnum == 60)
                            {
                                currentLanding.completed = true;
                                currentLanding.ID = SQL_Controller.CreateLanding(currentLanding);
                            }
                            else
                            {
                                currentLanding.windDataAfter[currentLanding.windEnum] = new TWind { time = Data.Time, speed = DataA.Speed, direction = DataA.Direction };
                                currentLanding.windEnum++;
                                Landings[i] = currentLanding;
                            }
                        }
                    }
                }
            } while (true);

        }

        private void LostSerial(TWind incomingData)
        {
            if (Landings.Count != 0)
            {
                foreach (AccuracyLanding aL in Landings)
                {
                    for (int i = aL.windEnum; i < 60; i++)
                    {
                        aL.windDataAfter[i] = new TWind { speed = 0, direction = 0, time = "0" };
                        aL.windEnum++;
                    }
                    aL.lostInput = true;
                    aL.completed = true;
                    SQL_Controller.CreateLanding(aL);
                }

            }
        }

        private byte[] ConvertLandingToByteArray(Accuracy.AccuracyLanding Landing)
        {
            //ToDo Override To String
            BinaryFormatter f = new BinaryFormatter();
            MemoryStream m = new MemoryStream();
            f.Serialize(m, Landing);
            return m.ToArray();
        }

        public AccuracyLanding ConvertByteArrayToLanding(byte[] Landing)
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter f = new BinaryFormatter();
            m.Write(Landing, 0, Landing.Length);
            m.Seek(0, SeekOrigin.Begin);
            AccuracyLanding deSerializedLanding = (AccuracyLanding)f.Deserialize(m);
            return deSerializedLanding;
        }

        public AccuracyLanding getLandingFromCell(DataGridViewCell cell)
        {
            for (int i = 0; i < Landings.Count; i++)
            {
                if (Landings[i].dataGridCell == cell)
                {
                    return Landings[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Adds the landing to the landing list. Has already been assigned and therefore doesn't need to be added to the column.
        /// </summary>
        /// <param name="L"></param>
        public void loadLanding(AccuracyLanding landing)
        {
            Landings.Add(landing);
        }

        /// <summary>
        /// Adds the landing to both the column and the landing list, for unassigned loaded landings.
        /// </summary>
        /// <param name="Landing"></param>
        public void addExistingLanding(AccuracyLanding landing)
        {
            Landings.Add(landing);
            column.AddLanding(landing);
        }

        /// <summary>
        /// Adds an existing landing to the column.
        /// </summary>
        /// <param name="landing"></param>
        public void unAssignLanding(AccuracyLanding landing)
        {
            landing.dataGridCell = null;
            landing.UID = -1;
            SQL_Controller.ModifyLanding(landing);
            column.AddLanding(landing);
        }

        /// <summary>
        /// Get's the currently highlighted landing in the column.
        /// </summary>
        public AccuracyLanding getColumnLanding()
        {
            int ID = column.GetIDOfCurrentLanding();
            if (ID != -1)
            {
                for (int i = 0; i < Landings.Count; i++)
                {
                    if (Landings[i].ID == ID)
                    {
                        return Landings[i];
                    }
                }
            }
            return null;
        }

        public void assignLanding(AccuracyLanding landing)
        {
            column.RemoveLanding(landing);
            SQL_Controller.ModifyLanding(landing);
        }

        public void removeLanding(int landingID)
        {
            for (int i = 0; i < Landings.Count; i++)
            {
                if (Landings[i].ID == landingID)
                {
                    SQL_Controller.RemoveLanding(landingID);
                    Landings.Remove(Landings[i]);
                    i = Landings.Count;
                }
            }
        }

        public Accuracy_Event AddEvent()
        {
            Accuracy_Event newEvent =new Accuracy_Event(SQL_Controller, IO_Controller, engine, this);
            Events.Add(newEvent);
            return newEvent;
        }

        public void EndThread()
        {
            ListenThread.Abort();
        }

        public bool EndEvent(Accuracy_Event endingEvent)
        {
            foreach (AccuracyLanding L in Landings)
            {
                if (!(L.completed)||!(L.lostInput))
                {
                    return false;
                }
            }
            Events.Remove(endingEvent);
            for (int i = 0; i < Landings.Count; i++)
            {
                if (Landings[i].eventID == endingEvent.EventID)
                {
                    Landings.Remove(Landings[i]);
                }
            }
            return false;

        }
    }
}
