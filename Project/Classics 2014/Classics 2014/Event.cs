using System;
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
        public bool TeamsSetup;
        public List<List<TCompetitor>> Teams;
        public List<string> TeamNames;
        public int EventID;
        public TabControl TabControl;
        public bool IsActive;
        public readonly ConcurrentQueue<Data> Data_queueEvent = new ConcurrentQueue<Data>();

        public virtual void SaveEventTeams(int CompetitorsPerTeam, List<List<TCompetitor>> TeamInput, List<string> TeamNamesInput)
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
            ListenThread.Abort();
        }
    }
}
