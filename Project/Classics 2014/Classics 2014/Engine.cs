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
        #endregion 
        private StreamWriter writer;
        public Engine(Main mainForm, TabControl tabControl)
        {
            this.mainForm = mainForm;
            this.tabControl = tabControl;
            AquireMasterFile();
            IO_Controller = new IO_Controller();
            SQL_Controller = new SQL_Controller("127.0.0.1", "Main", "root");
            ListenThread = new Thread(new ThreadStart(ListenProcedure));
           //ToDo Delete this line to start receiving data ListenThread.Start();
        }
        private void ListenProcedure()
        {
            IO_Controller._signal.WaitOne();
            if ((activeEvent != null) && (activeEvent.RequiresSerial )) { Active_Signal.WaitOne(); }
            Data data;

            while (IO_Controller.Data_queue.TryDequeue(out data))
            {
                //ToDo Make sure we cast to the correct fucking type in the future, the serial will know
                Data_Accuracy Data = (data as Data_Accuracy);
                WriteToMasterFile(Data);
                mainForm.UpdateWind(new TWind() { direction = Data.Direction, speed = Data.Speed, time = Data.Time });
            }

        }

        public Classics_2014.Accuracy.EventAccuracyOptions StartNewAccuracyEvent()
        {
            Classics_2014.Accuracy.Accuracy_Event NewEvent = new Accuracy.Accuracy_Event(SQL_Controller, IO_Controller, Active_Signal, this);
            NewEvent.EventOptionsTab = new Accuracy.EventAccuracyOptions(tabControl, NewEvent);
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
            writer.WriteLine(data.Time + " : " + data.Speed.ToString() + " " + data.Direction.ToString());
            if (data.IsLanding)
            {
                writer.Write(Convert.ToInt16(data.LandingScore).ToString());
            }
        }
        private void AquireMasterFile()
        {
            try
            {
                DateTime lastCreationTime = File.GetCreationTime(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentMasterFile.txt");
                if (lastCreationTime.Date != DateTime.Now)
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
                writer = new StreamWriter(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentMasterFile.txt");
                return;
            }

            //Confirm 
        }
    }
}
