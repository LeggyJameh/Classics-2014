using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Classics_2014
{
    class Engine
    {
        IO_Controller IO_Controller;
        SQL_Controller SQL_Controller;
        readonly AutoResetEvent Active_Signal = new AutoResetEvent(false);//ANYTIME AN EVENT BECOMES ACTIVE IT REQUIRES A "ref Active_Signal" TO BE PASSED IN!
        private Thread ListenThread;
        Event activeEvent;
        public Engine()
        {
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
                //ToDo data must now be cast into appropriate form but is ready to be used ( I chose not to do that here because I feel we should discuss this
            }

        }

        public Classics_2014.Accuracy.Accuracy_Event StartNewAccuracyEvent()
        {
            Classics_2014.Accuracy.Accuracy_Event NewEvent = new Classics_2014.Accuracy.Accuracy_Event(SQL_Controller, IO_Controller, Active_Signal);
            return NewEvent;
        }
    }
}
