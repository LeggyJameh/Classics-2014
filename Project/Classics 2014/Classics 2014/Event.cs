using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Concurrent;
using CMS.MySQL;

namespace CMS
{
    abstract class Event
    {
        public string Name;
        public SQL_Controller SQL_Controller;
        public IO_Controller IO_Controller;
        public bool RequiresSerial { get; protected set; } // This is checked to see if Engine can Read the data without waiting (Psuedo Const)
        public EventType EventType { get; protected set; }
        public List<Team> Teams;
        public int EventID;
        public DateTime Date;
        public TabControl TabControl;
        public Ruleset.Ruleset Rules;
        public Engine engine;

        public void ProceedToTeamSetup()
        {
            Rules.stage = EventStage.SetupTeams;
            engine.mainForm.removeCurrentTab();
            engine.mainForm.addNewTab("Team setup", new Forms.TeamPicker(this));
        }

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
        protected virtual byte[] ConvertRulesToByteArray()
        {
            throw new NotImplementedException();
        }
        protected virtual void ConvertByteArrayToRules()
        {
            throw new NotImplementedException();
        }
        public void EndThread()
        {
            //ListenThread.Abort();
        }
        public virtual TWind ReturnWindLimits()
        {
            throw new NotImplementedException();
        }
    }
}
