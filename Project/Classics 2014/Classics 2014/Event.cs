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
        public EventType EventType;
        public List<Competitor> Competitors;
        public List<Competitor> UnassignedCompetitors; // Used to take competitors from Init to Team picker only.
        public List<Team> Teams;
        public int EventID;
        public DateTime Date;
        public Ruleset.Ruleset Rules;
        public Engine engine;
        protected UserControl currentWindow; // The current tabpage that is controlling the event.
        protected UpdateCompetitorDelegate _updateCompetitorDelegate;

        public void Exit()
        {
            if (Rules != null) // Event specific handlers to end / remove references.
            {
                switch (Rules.stage)
                {
                    case EventStage.SetupRules:
                        break;
                    case EventStage.SetupTeams:
                        break;
                    case EventStage.SetupEID:
                        break;
                    case EventStage.Ready:
                        break;
                }
            }

            // General stuff that happens when ending event.
            if (currentWindow != null)
            {
                if (currentWindow.Parent != null)
                {
                    engine.mainForm.removeTab((TabPage)currentWindow.Parent);
                }
                currentWindow = null;
            }
            engine.RemoveCompetitorUpdateDelegate(_updateCompetitorDelegate);
            engine.EndEvent(this);
        }

        public void NextStage()
        {
            if (Rules != null)
            {
                switch (Rules.stage)
                {
                    case EventStage.SetupRules: // Same for most events, once past Setup rules, init setup teams.
                        switch (EventType) // Check for event type. Some don't use teams.
                        {
                            case CMS.EventType.INTL_ACCURACY:
                                SQL_Controller.RemoveAllTeamsForEvent(EventID);
                                Teams = new List<Team>();
                                Rules.stage = EventStage.SetupTeams;
                                engine.mainForm.removeTab((TabPage)currentWindow.Parent);
                                if (Rules.competitorsPerTeam > 1) // If teamed
                                {
                                currentWindow = new TeamPicker(this, Rules.competitorsPerTeam);
                                    engine.mainForm.addNewTab("Team setup", currentWindow);
                                }
                                else // If singles...
                                {
                                    foreach (Competitor c in UnassignedCompetitors)
                                    {
                                        Team newTeam = SQL_Controller.CreateTeam(EventID, c.name);
                                        newTeam.Competitors.Add(new EventCompetitor(c));
                                        SQL_Controller.ModifyTeam(newTeam);
                                        Teams.Add(newTeam);
                                    }
                                    NextStage();
                                }
                                break;
                            case CMS.EventType.FAI_CP:
                                Rules.stage = EventStage.SetupTeams;
                                NextStage();
                                break;
                        }
                        break;
                    case EventStage.SetupTeams: // SetupEID global for all events, so continue.
                        // Currently skipping EID stage.
                        Rules.stage = EventStage.SetupEID;
                        NextStage();
                        break;
                    case EventStage.SetupEID: // Actual event is different for each event type, so switch required.
                        switch (EventType)
                        {
                            case CMS.EventType.INTL_ACCURACY:
                                Rules.stage = EventStage.Ready;
                                engine.mainForm.removeTab((TabPage)currentWindow.Parent);
                                currentWindow = new Accuracy.EventAccuracy((Accuracy.Accuracy_Event)this, new List<Accuracy.AccuracyLanding>());
                                engine.mainForm.addNewTab(Name, currentWindow);
                                break;
                            case CMS.EventType.FAI_CP:
                                Rules.stage = EventStage.Ready;
                                engine.mainForm.removeCurrentTab();
                                currentWindow = new FAI_CP.EventFAI_CP((FAI_CP.FAI_CP_Event)this, new List<FAI_CP.FAI_CPLanding>());
                                engine.mainForm.addNewTab(Name, currentWindow);
                                break;
                        }
                        break; 
                }
                SQL_Controller.ModifyEvent(this);
            }
        }

        public void PreviousStage()
        {
            if (Rules != null)
            {
                switch (Rules.stage)
                {
                    case EventStage.SetupTeams: // Event init is seperate for each event.
                        switch (EventType)
                        {
                            case CMS.EventType.INTL_ACCURACY:
                                currentWindow = new Accuracy.EventAccuracyInit((Accuracy.Accuracy_Event)this, true);
                                engine.mainForm.addNewTab(Name, currentWindow);
                                break;
                            case CMS.EventType.FAI_CP:
                                // TODO: Go back to event init.
                                break;
                        }
                        break;
                    case EventStage.SetupEID:
                        break;
                    case EventStage.Ready:
                        break;
                }
            }
        }

        public void SaveCurrentStage()
        {
            if (Rules != null)
            {
                switch (Rules.stage)
                {
                    case EventStage.SetupRules:
                        if (EventID != -1)
                        {
                            if (SQL_Controller.GetDoesEventExist(EventID))
                            {
                                SQL_Controller.ModifyEvent(this);
                            }
                            else
                            {
                                SQL_Controller.CreateEvent(this);
                                EventID = SQL_Controller.GetLastInsertKey();
                            }
                        }
                        else
                        {
                            SQL_Controller.CreateEvent(this);
                            EventID = SQL_Controller.GetLastInsertKey();
                        }
                        break;
                    case EventStage.SetupTeams:
                        SQL_Controller.ModifyEvent(this);
                        break;
                    case EventStage.SetupEID:
                        break;
                    case EventStage.Ready:
                        break;
                }
            }
        }

        

        public void LoadCurrentStage()
        {
            switch (this.Rules.stage)
            {
                case EventStage.SetupRules:
                    switch (EventType)
                    {
                        case CMS.EventType.INTL_ACCURACY:
                            currentWindow = new Accuracy.EventAccuracyInit((Accuracy.Accuracy_Event)this, true);
                            engine.mainForm.addNewTab(Name, currentWindow);
                            break;
                        case CMS.EventType.INTL_CP:
                            // TODO: CP Stuff
                            break;
                    }
                    break;
                case EventStage.SetupTeams:
                    this.Teams = SQL_Controller.GetTeamsForEvent(EventID);
                    this.UnassignedCompetitors = new List<Competitor>();
                    currentWindow = new TeamPicker(this, Rules.competitorsPerTeam);
                    engine.mainForm.addNewTab("Team setup", currentWindow);
                    break;
                case EventStage.SetupEID:
                    break;
                case EventStage.Ready:
                    switch (EventType)
                    {
                        case CMS.EventType.INTL_ACCURACY:
                                this.Teams = SQL_Controller.GetTeamsForEvent(EventID);
                                Rules.stage = EventStage.Ready;
                                currentWindow = new Accuracy.EventAccuracy((Accuracy.Accuracy_Event)this, SQL_Controller.GetLandingsForEvent(this.EventID, CMS.EventType.INTL_ACCURACY));
                                engine.mainForm.addNewTab(Name, currentWindow);
                            break;
                        case CMS.EventType.INTL_CP:
                            // TODO: CP Stuff
                            break;
                    }
                    break;
            }
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
