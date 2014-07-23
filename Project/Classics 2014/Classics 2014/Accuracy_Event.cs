using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Classics_2014
{
    class Accuracy_Event
    {
        #region variables and the such like
        private Thread ListenThread;
        SQL_Controller SQL_Controller;
        IO_Controller IO_Controller;
        readonly AutoResetEvent Active_Signal;
        #endregion
        public Accuracy_Event(SQL_Controller SQL_Controller, IO_Controller IO_Controller, AutoResetEvent Active_Signal)
        {
            this.SQL_Controller = SQL_Controller;
            this.IO_Controller = IO_Controller;
            this.Active_Signal = Active_Signal;
        }
        private void EventStart() //TODO Rule struct goes here
        {
        }
        private void ListenProcedure()
        {
            Data Data;
            Data_Accuracy DataA = new Data_Accuracy();
            IO_Controller._signal.WaitOne();
            while (IO_Controller.Data_queue.TryPeek(out Data))
            {
                DataA = (Data as Data_Accuracy);
                if (DataA != null)
                {
                    Active_Signal.Set();
                    //ToDo Data is received here DataA is the data and is ready to be used;
                }
                else
                {
                    //Downcast Failed, what the fuck!
                }
            }
        }
    }
}
