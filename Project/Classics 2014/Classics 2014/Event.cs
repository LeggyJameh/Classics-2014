﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Concurrent;
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
        public List<Team> Teams;
        public int EventID;
        public TabControl TabControl;
        public bool IsActive;
        public readonly ConcurrentQueue<Data> Data_queueEvent = new ConcurrentQueue<Data>();

        public virtual void SaveEventTeams(int CompetitorsPerTeam, List<Team> Teams)
        {
            throw new NotImplementedException();
        }

        public virtual void ProceedToEvent()
        {
            throw new NotImplementedException();
        }

        public virtual void ReturnToOptions()
        {
            throw new NotImplementedException();
        }

        protected virtual void  CreateEvent ()
        {
            throw new NotImplementedException();
        }
        protected virtual byte[] ConvertRuleSetToByteArray()
        {
            throw new NotImplementedException();
        }
        protected virtual void ConvertByteArrayToRuleset()
        {
            throw new NotImplementedException();
        }
        public void EndThread()
        {
            if (ListenThread != null)
            {
                ListenThread.Abort();
            }
        }
        public virtual TWind ReturnWindLimits()
        {
            throw new NotImplementedException();
        }
    }
}
