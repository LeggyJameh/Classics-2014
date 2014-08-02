﻿using System;
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
        SQL_Controller SQL_Controller;
        private Thread ListenThread;
        public Event activeEvent;
        Main mainForm;
        TabControl tabControl;
        TWind[] wind = new TWind[60];
        List<TWind> windList = new List<TWind>();
        List<Event> eventList = new List<Event>();
        private StreamWriter writer;
        public FileStream fileStream;
        private StreamReader reader;
        private windGraphingControllercs windGraph;
        #endregion 

        public Engine(Main mainForm, TabControl tabControl, windGraphingControllercs windGraph)
        {
            this.mainForm = mainForm;
            this.tabControl = tabControl;
            this.windGraph = windGraph;
            windGraph.MainEngine = this;
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

                            if ((activeEvent != null) && (activeEvent.RequiresSerial))
                            {
                                activeEvent.Data_queueEvent.Enqueue(data);
                            }
                        }
                    }
                }
                Thread.Sleep(500);

            } while (true);

        }
        private void UpdateWindMetrics(Data DatA)
        {
            TWind wind = new TWind() { direction = DatA.Direction, speed = DatA.Speed, time = DatA.Time };
            if (activeEvent != null)
            {
               // mainForm.Invoke((MethodInvoker)(() => mainForm.SetColoursForText(wind, activeEvent., 2.0F)));
            }
            mainForm.UpdateWind(wind);
            windGraph.UpdateWindGraph(wind);
            ReOrderWindArray(wind);
        }
        public Classics_2014.Accuracy.EventAccuracyOptions StartNewAccuracyEvent()
        {
            Classics_2014.Accuracy.Accuracy_Event NewEvent = new Accuracy.Accuracy_Event(SQL_Controller, IO_Controller, this);
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
            catch
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
        public void DeSerializeGraph(StreamReader reader)
        {

            string input;
            string[] args;
            reader.BaseStream.Position = 0;
            while (!reader.EndOfStream)
            {
                input = reader.ReadLine();
                args = input.Split(':');
                if (args.Length >= 5)
                {
                    windGraph.UpdateWindGraphNonInvokable(new TWind { time = (args[0] + args[1] + (args[2].Substring(0, 2))), speed = Convert.ToSingle(args[3]), direction = Convert.ToUInt16(args[4]) });
                }
            }
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
            writer.Flush();
            IO_Controller.EndThreads();
            foreach (Event e in eventList)
            {
                e.EndThread();
            }
            SQL_Controller.StopDatabase();
        }
    }
}
