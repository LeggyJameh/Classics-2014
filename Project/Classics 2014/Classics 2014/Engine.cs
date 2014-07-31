using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
namespace Classics_2014
{
    class Engine
    {
        #region variables and shit
        IO_Controller IO_Controller;
        SQL_Controller SQL_Controller;
        readonly AutoResetEvent Active_Signal = new AutoResetEvent(false);//ANYTIME AN EVENT BECOMES ACTIVE IT REQUIRES A "ref Active_Signal" TO BE PASSED IN!
        private Thread ListenThread;
        Event activeEvent;
        Main mainForm;
        TabControl tabControl;
        TWind[] wind = new TWind[60];
        List<TWind> windList = new List<TWind>();
        List<Event> eventList = new List<Event>();
        private StreamWriter writer;
        #endregion 

        public Engine(Main mainForm, TabControl tabControl)
        {
            this.mainForm = mainForm;
            this.tabControl = tabControl;
            AquireMasterFile();
            IO_Controller = new IO_Controller();
            SQL_Controller = new SQL_Controller("127.0.0.1", "Main", "root");
            ListenThread = new Thread(new ThreadStart(ListenProcedure));  
            while ((IO_Controller.Serial_Input)&&(!ListenThread.IsAlive)) 
            {
                 ListenThread.Start();  
            } 
        }
        private void ListenProcedure()
        {
            do
            {
                if (mainForm.IsHandleCreated)
                {
                    while (IO_Controller.CheckIO()[0])//If Serial is active
                    {
                        Data data;
                        if ((activeEvent != null) && (activeEvent.RequiresSerial))
                        {
                            Active_Signal.WaitOne();
                        }
                        while (IO_Controller.Data_queue.TryDequeue(out data))
                        {
                            switch (data.dataType)
                            {
                                case EventType.Accuracy:
                                    Data_Accuracy DatA = (Data_Accuracy)data;
                                    WriteToMasterFile(DatA);
                                    UpdateWindMetrics(DatA);
                                    break;
                            }
                        }
                        if ((activeEvent != null) && (activeEvent.RequiresSerial))
                        {
                            Active_Signal.WaitOne();
                        }
                        IO_Controller._signal.WaitOne();
                    }
                }
                Thread.Sleep(500);
            } while (true);

        }

        private void UpdateWindMetrics(Data DatA)
        {
            TWind wind = new TWind() { direction = DatA.Direction, speed = DatA.Speed, time = DatA.Time };
            mainForm.UpdateWind(wind);
            mainForm.UpdateWindGraph(wind);
            ReOrderWindArray(wind);
        }
        public Classics_2014.Accuracy.EventAccuracyOptions StartNewAccuracyEvent()
        {
            Classics_2014.Accuracy.Accuracy_Event NewEvent = new Accuracy.Accuracy_Event(SQL_Controller, IO_Controller, Active_Signal, this);
            NewEvent.EventOptionsTab = new Accuracy.EventAccuracyOptions(tabControl, NewEvent);
           NewEvent.TabControl = tabControl;
           eventList.Add(NewEvent);
            return NewEvent.EventOptionsTab;
        }
        public bool MakeActive(Event eventToBeActive)
        {
            //ToDo Add switch to check serial here MOFO's!
            activeEvent = eventToBeActive;
            return true;
        }
        private void WriteToMasterFile(Data_Accuracy data)
        {
            writer.WriteLine(data.ToString()); //ToDo Might need some upcasting

        }
        private void AquireMasterFile()
        {
            try
            {
                DateTime lastCreationTime = File.GetCreationTime(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentMasterFile.txt");
                if (lastCreationTime.Date.DayOfYear != DateTime.Now.DayOfYear)
                {
                    if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\OldMasterFiles\\")) { Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\OldMasterFiles"); }
                    File.Move(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentMasterFile.txt", Directory.GetCurrentDirectory() + "\\OldMasterFiles\\" + File.GetCreationTime(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentMasterFile.txt"));
                }
            }
            catch
            {
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\RecentMasterFile");
                }
            }
            writer = new StreamWriter(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentMasterFile.txt", true);
            //Confirm 
        }
        private void ReOrderWindArray(TWind newWind)
        {
            for (int i = 60 - 1; i >= 1; i--)
            {

                wind[i] = wind[i - 1];

            }
            wind[0] = newWind;
            mainForm.UpdatelistBoxWindLog(wind);
        }
        public void CloseThreads()
        {
            ListenThread.Abort();
            IO_Controller.EndThreads();
            foreach (Event e in eventList)
            {
                e.EndThread();
            }
            SQL_Controller.StopDatabase();
            writer.Close();
        }
    }
}
