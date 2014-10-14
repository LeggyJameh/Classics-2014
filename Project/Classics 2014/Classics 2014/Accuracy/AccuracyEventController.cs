using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

namespace Classics_2014.Accuracy
{
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
                            AccuracyLanding newLanding = new AccuracyLanding { Index = NumberOfLandings, ID = 0, score = DataA.LandingScore, windDataPrior = (TWind[])IncomingData.Clone(), WindInputs = 0, TimeOfLanding = DataA.Time, LandingWind = new TWind { time = Data.Time, speed = DataA.Speed, direction = DataA.Direction }, WindDataAfter = new TWind[60] };
                            newLanding.ID = SQL_Controller.CreateAccuracyLanding(EventID, newLanding.score);
                            Landings.Add(newLanding);
                            column.AddLanding(newLanding);
                            column.UpdateScore(DataA.LandingScore.ToString());
                        }
                        for (int i = 0; i < Landings.Count; i++)
                        {
                            AccuracyLanding currentLanding = Landings[i];
                            if (currentLanding.WindInputs == 60)
                            {
                                SQL_Controller.AssignWindDataToAccuracyLanding(ConvertLandingToByteArray(currentLanding), currentLanding.isRejumpable, currentLanding.ID);
                            }
                            else
                            {
                                currentLanding.WindDataAfter[currentLanding.WindInputs] = new TWind { time = Data.Time, speed = DataA.Speed, direction = DataA.Direction };
                                currentLanding.WindInputs++;
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
                    for (int i = aL.WindInputs; i < 60; i++)
                    {
                        aL.WindDataAfter[i] = new TWind { speed = 0, direction = 0, time = "0" };
                        aL.WindInputs++;
                    }
                    aL.LostInput = true;
                    aL.isComplete = true;
                    SQL_Controller.AssignWindDataToAccuracyLanding(ConvertLandingToByteArray(aL), aL.isRejumpable, aL.ID);
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
        public int GetLandingIDFromCell(DataGridViewCell Cell)
        {
            for (int i = 0; i < Landings.Count; i++)
            {
                if (Landings[i].dataGridCell == Cell)
                {
                    return Landings[i].ID;
                }
            }
            return -1;
        }
        public void loadLanding(AccuracyLanding L)
        {
            Landings.Add(L);
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
                if (!(L.isComplete)||!(L.LostInput))
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
