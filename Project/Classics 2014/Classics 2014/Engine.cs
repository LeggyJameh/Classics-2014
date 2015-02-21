using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using CMS.MySQL;
using WindGrapher;
namespace CMS
{
    class Engine
    {
        #region variables and shit
        public IO_Controller IO_Controller;
        public SQL_Controller SQL_Controller;
        private Thread ListenThread;
        private WindGrapher.WindGraphController windGraphController;
        public Main mainForm;
        UserControl SideController;
        TWind[] wind = new TWind[60];
        List<TWind> windList = new List<TWind>();
        public Accuracy.AccuracyEventController accuracyEventController;
        private StreamWriter writer;
        private TabPage pageForGraph;
        public FileStream fileStream;
        bool LostSerialConnection;
        List<UpdateCompetitorDelegate> competitorUpdateDelegates = new List<UpdateCompetitorDelegate>(); // Delegates that are called when competitors are updated via competitor editor.
        EventLoader eventLoader; // The class used for load execution
        #endregion 

        public Engine(Main mainForm, TabPage pageForGraph)
        {
            this.pageForGraph = pageForGraph;
            this.mainForm = mainForm;
            AquireMasterFile();
            IO_Controller = new IO_Controller(new Action(CloseSerialInputs));
            SQL_Controller = new SQL_Controller(UserSettings.Default.mySqlDataBaseServerIP, UserSettings.Default.mySqlDataBaseName, UserSettings.Default.mySqlDataBaseUser, UserSettings.Default.mySqlDataBasePassword);
            accuracyEventController = new Accuracy.AccuracyEventController(SQL_Controller, IO_Controller, this);
            ListenThread = new Thread(new ThreadStart(ListenProcedure));  
            while ((!ListenThread.IsAlive)) 
            {
                 ListenThread.Start();  
            } 
        }

        public void AddLoader()
        {
            eventLoader = new EventLoader(this);
        }

        public void RemoveLoader()
        {
            eventLoader = null;
        }

        /// <summary>
        /// Finds the apprropriate controller and loads the event. Called from EventLoader.
        /// </summary>
        public void LoadEvent(Event Event)
        {
            switch (Event.EventType)
            {
                case EventType.INTL_ACCURACY:
                    accuracyEventController.LoadEvent((Accuracy.Accuracy_Event)Event);
                    break;
            }
        }
        
        public void StartNewEvent(EventType type)
        {
            switch (type)
            {
                case EventType.INTL_ACCURACY:
                    accuracyEventController.AddEvent();
                    break;
            }
        }

        /// <summary>
        /// Ends an event. Thrown from event itself, for removing event from appropriate controllers.
        /// </summary>
        public void EndEvent(Event Event)
        {
            switch (Event.EventType)
            {
                case EventType.INTL_ACCURACY:
                    accuracyEventController.EndEvent((Accuracy.Accuracy_Event)Event);
                    break;
            }
        }

        /// <summary>
        /// Used whenever the competitor editor has a save. Forces all events to reload from database the current competitor data.
        /// </summary>
        public void RefreshAllCompetitorUsers()
        {
            foreach (UpdateCompetitorDelegate d in competitorUpdateDelegates)
            {
                d();
            }
        }

        public void AddCompetitorUpdateDelegate(UpdateCompetitorDelegate _delegate)
        {
            competitorUpdateDelegates.Add(_delegate);
        }

        public void RemoveCompetitorUpdateDelegate(UpdateCompetitorDelegate _delegate)
        {
            competitorUpdateDelegates.Remove(_delegate);
        }

        private void ListenProcedure()
        {
            Thread.Sleep(100);
            do
            {
                if (mainForm.IsHandleCreated)
                {
                    if (windGraphController == null) { windGraphController = new WindGraphController(pageForGraph, fileStream); }
                    IO_Controller._signal.WaitOne();
                    while ((IO_Controller.CheckIO()[0]) && (mainForm.IsHandleCreated))//If Serial is active
                    {
                        Data data;
                        while (IO_Controller.Data_queue.TryDequeue(out data))
                        {
                            switch (data.dataType)
                            {
                                case EventType.INTL_ACCURACY:
                                    Data_Accuracy DatA = (Data_Accuracy)data;
                                    WriteToMasterFile(DatA);
                                    UpdateWindMetrics(DatA);
                                    break;
                            }

                            accuracyEventController.Data_queueEvent.Enqueue(data);
                        }
                    }
                }
                Thread.Sleep(500);

            } while (true);

        }

        public void AddSideController(UserControl Controller)
        {
            SideController = Controller;

            mainForm.MainGrid.Controls.Add(Controller, 2, 0);
        }

        public void RemoveCurrentSideController()
        {
            mainForm.MainGrid.Controls.Remove(SideController);
            SideController = null;
        }

        public void CloseThreads()
        {
            ListenThread.Abort();
            IO_Controller.EndThreads();
            accuracyEventController.EndThread();
            SQL_Controller.StopDatabase();
        }

        private void UpdateWindMetrics(Data DatA)
        {
            TWind wind = new TWind() { direction = DatA.Direction, speed = DatA.Speed, time = DatA.Time };

            mainForm.Invoke((MethodInvoker)(() => mainForm.SetColoursForText(wind, wind.direction, wind.speed)));

            mainForm.Invoke((MethodInvoker)(() => mainForm.UpdateWind(wind)));
            windGraphController.AddData(wind.time, wind.speed, wind.direction);
            ReOrderWindArray(wind);
        }

        private void WriteToMasterFile(Data_Accuracy data)
        {
            writer.WriteLine(data.ToString()); 
            //ToDo Might need some upcasting
            //ToDo Fix Master
        }
        private void AquireMasterFile()
        {
            try
            {
                DateTime lastCreationTime = File.GetCreationTime(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentMasterFile.txt");
                if (lastCreationTime.Date.DayOfYear != DateTime.Now.DayOfYear)
                {
                    if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\OldMasterFiles\\")) { Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\OldMasterFiles"); }
                    File.Move(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentMasterFile.txt", Directory.GetCurrentDirectory() +"\\OldMasterFiles\\" + (lastCreationTime.ToShortDateString().Replace(':','-'))+".txt");
                }
            }
            catch (Exception ex)
            {
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\RecentMasterFile");
                }
            }
            fileStream = new FileStream(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentMasterFile.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);//ToDo Move this file
            writer = new StreamWriter(fileStream);
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
        
        private void CloseSerialInputs()
        {
            LostSerialConnection = true; //ToDo Make work For Multiple Events;
        }

        
    }
}
