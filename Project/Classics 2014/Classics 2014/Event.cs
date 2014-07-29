using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;
namespace Classics_2014
{
    abstract class Event
    {
        public string Name;
        protected  Thread ListenThread;
        public SQL_Controller SQL_Controller;
        public IO_Controller IO_Controller;
        public bool RequiresSerial { get; protected set; } // This is checked to see if Engine can Read the data without waiting (Psuedo Const)
        public EventType EventType { get; protected set; }
        protected virtual void  CreateEvent ()
        {
            throw new NotImplementedException();
        }
        protected virtual byte[] ConvertRuleSetToString()
        {
            throw new NotImplementedException();
        }
        public void EndThread()
        {
            ListenThread.Abort();
        }
    }
}
