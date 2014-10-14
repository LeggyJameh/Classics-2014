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
        public IO_Controller IO_Controller;
        public SQL_Controller SQL_Controller;
        private Thread ListenThread;
        Main mainForm;
        TabControl tabControl;
        TWind[] wind = new TWind[60];
        List<TWind> windList = new List<TWind>();
        Accuracy.AccuracyEventController accuracyEventController;
        private StreamWriter writer;
        public FileStream fileStream;
        private StreamReader reader;
        public windGraphingControllercs windGraph;
        TabPage createNewEventTab;
        bool LostSerialConnection;
        #endregion 

        public Engine(Main mainForm, TabControl tabControl, windGraphingControllercs windGraph)
        {
            this.mainForm = mainForm;
            this.tabControl = tabControl;
            this.windGraph = windGraph;
            windGraph.MainEngine = this;
            AquireMasterFile();
            IO_Controller = new IO_Controller(new Action(CloseSerialInputs));
            SQL_Controller = new SQL_Controller("127.0.0.1", "Main", "root");
            accuracyEventController = new Accuracy.AccuracyEventController(SQL_Controller, IO_Controller, this);
            ListenThread = new Thread(new ThreadStart(ListenProcedure));  
            while ((!ListenThread.IsAlive)) 
            {
                 ListenThread.Start();  
            } 
        }
        
        private void ListenProcedure()
        {
            Thread.Sleep(100);
            do
            {
                if (mainForm.IsHandleCreated)
                {
                    IO_Controller._signal.WaitOne();
                    while ((IO_Controller.CheckIO()[0]) && (mainForm.IsHandleCreated))//If Serial is active
                    {
                        Data data;
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

                            accuracyEventController.Data_queueEvent.Enqueue(data);
                        }
                    }
                }
                Thread.Sleep(500);

            } while (true);

        }
        private void UpdateWindMetrics(Data DatA)
        {
            TWind wind = new TWind() { direction = DatA.Direction, speed = DatA.Speed, time = DatA.Time };

                mainForm.Invoke((MethodInvoker)(() => mainForm.SetColoursForText(wind, wind.direction, wind.speed)));

             mainForm.Invoke((MethodInvoker)(()=>mainForm.UpdateWind(wind)));
            windGraph.UpdateWindGraph(wind);
            ReOrderWindArray(wind);
        }

        public Classics_2014.Accuracy.EventAccuracyOptions StartNewAccuracyEvent()
        {
            Accuracy.Accuracy_Event NewEvent = accuracyEventController.AddEvent();
            NewEvent.EventOptionsTab = new Accuracy.EventAccuracyOptions(tabControl, NewEvent);
            NewEvent.TabControl = tabControl;
            return NewEvent.EventOptionsTab;
        }

        public Classics_2014.Accuracy.EventAccuracyOptions LoadExistingAccuracyEvent(Rulesets.AccuracyRuleset Rules, string EventName, DateTime Date, List<Competitor> SelectedCompetitors)
        {
            Accuracy.Accuracy_Event NewEvent = accuracyEventController.AddEvent();
            NewEvent.EventOptionsTab = new Accuracy.EventAccuracyOptions(tabControl, NewEvent, Rules, EventName, Date, SelectedCompetitors);
            NewEvent.TabControl = tabControl;
            return NewEvent.EventOptionsTab;
        }

        public Classics_2014.Accuracy.Accuracy_Event LoadExistingAccuracyEvent()
        {
            Accuracy.Accuracy_Event NewEvent = accuracyEventController.AddEvent();
            return NewEvent;
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
            reader = new StreamReader(fileStream);
            DeSerializeGraph(reader);
            //Confirm 
        }
        public void DeSerializeGraph(StreamReader newReader)
        {
            this.reader = newReader;
            Thread th = new Thread(new ThreadStart(DesiralizeGraphThreadProcedure));
            th.Start();
        }
        private void DesiralizeGraphThreadProcedure()
        {
            do
            {
                Thread.Sleep(100);
            } while (!mainForm.IsHandleCreated);
            string input;
            string[] args;
            DateTime previousData = new DateTime();
            bool loopTwo = false;
            reader.BaseStream.Position = 0;
            while (!reader.EndOfStream)
            {
                input = reader.ReadLine();
                args = input.Split(':');
                if (args.Length >= 5)
                {
                    DateTime pointTime = Convert.ToDateTime(args[0] + ":" + args[1] + ":" + (args[2].Substring(0, 2)));
                    if ((loopTwo) && (previousData.AddSeconds(1).ToShortTimeString() != pointTime.ToShortTimeString())&&(previousData.AddSeconds(1)< pointTime))
                    {
                        do
                        {
                            previousData.AddSeconds(1);
                            windGraph.UpdateWindGraph(new TWind {time = (previousData.Hour +":"+previousData.Minute+":" + previousData.Second), speed = 0, direction = 0 });
                            previousData.AddSeconds(1);
                            previousData = previousData.AddSeconds(1);
                        } while (previousData.AddSeconds(1).ToShortTimeString() != pointTime.ToShortTimeString());
                    }
                    previousData = pointTime;
                    loopTwo = true;
                    windGraph.UpdateWindGraph(new TWind { time = (args[0] + ":" + args[1] + ":" + (args[2].Substring(0, 2))), speed = Convert.ToSingle(args[3]), direction = Convert.ToUInt16(args[4]) });
                }
            }
            Thread.CurrentThread.Abort();
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
            accuracyEventController.EndThread();
            SQL_Controller.StopDatabase();
        }
        private void CloseSerialInputs()
        {
            LostSerialConnection = true; //ToDo Make work For Multiple Events;
        }
    }
}
