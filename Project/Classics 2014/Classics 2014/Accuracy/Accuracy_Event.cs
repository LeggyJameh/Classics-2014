using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Concurrent;
using CMS.MySQL;

namespace CMS.Accuracy
{
    // Working 28/10/14.
    class Accuracy_Event :Event 
    {
        #region variables and the such like
        public EventAccuracyInit EventOptionsTab;
        public EventTeams EventTeamsTab;
        public EventAccuracy EventTab;
        public Ruleset.AccuracyRules Rules;

        public List<Competitor> Competitors;
        public List<string> ActiveTeams;
        Boolean lostSerial = false;
        public AccuracyEventController controller;
        #endregion

        /// <summary>
        /// Used when creating event or loading it properly
        /// </summary>
        /// <param name="SQL_Controller">Pass the SQL_Controller from the Engine.</param>
        /// <param name="IO_Controller">Pass the IO_Controller from the Engine.</param>
        /// <param name="engine">Pass the Engine.</param>
        /// <param name="controller">Pass the Accuracy Event Controller from the Engine.</param>
        public Accuracy_Event(SQL_Controller SQL_Controller, IO_Controller IO_Controller, Engine engine, AccuracyEventController controller)
        {
            this.SQL_Controller = SQL_Controller;
            this.IO_Controller = IO_Controller;
            this.engine = engine;
            this.controller = controller;
            RequiresSerial = true;
            EventType = EventType.Accuracy;
            EventID = -1;
        }

        /// <summary>
        /// Used for loading procedures. Not viable when initialising a new instance of an Event.
        /// </summary>
        public Accuracy_Event()
        {
        }

        public bool CloseEvent()
        {
            if (Rules != null)
            {
                switch (Rules.stage)
                {
                    case EventStage.SetupRules:
                        if (EventOptionsTab != null)
                        {
                            if (EventOptionsTab.Parent != null)
                            {
                                engine.mainForm.removeTab((TabPage)EventOptionsTab.Parent);
                                EventOptionsTab = null;
                            }
                        }
                        break;
                    case EventStage.SetupTeams:
                        if (EventTeamsTab != null)
                        {
                            if (EventTeamsTab.Parent != null)
                            {
                                engine.mainForm.removeTab((TabPage)EventTeamsTab.Parent);
                                EventTeamsTab = null;
                            }
                        }
                        break;
                    case EventStage.Ready:
                        if (EventTab != null)
                        {
                            if (EventTab.Parent != null)
                            {
                                engine.mainForm.removeTab((TabPage)EventTab.Parent);
                                EventTab = null;
                            }
                        }
                        break;
                }
            }
            else
            {
                if (EventOptionsTab != null)
                {
                    if (EventOptionsTab.Parent != null)
                    {
                        engine.mainForm.removeTab((TabPage)EventOptionsTab.Parent);
                        EventOptionsTab = null;
                    }
                }
            }
            return controller.EndEvent(this);
        }

        public void proceedToSetupTeams()
        {
            Rules.stage = EventStage.SetupTeams;
            EventTeamsTab = new EventTeams(this, Competitors, EventID, Rules.competitorsPerTeam, ActiveTeams);
            TabPage NewPage = new TabPage();
            NewPage.Controls.Add(EventTeamsTab);
            EventTeamsTab.Dock = DockStyle.Fill;
            NewPage.Text = Name + " Team Config";
            TabControl.TabPages.Add(NewPage);
            TabControl.SelectedTab = NewPage;
        }

        public void proceedToEvent()
        {
            Rules.stage = EventStage.Ready;
            SQL_Controller.ModifyEvent(this);
            EventTab = new EventAccuracy(this, TabControl);
            TabPage NewPage = new TabPage();
            NewPage.Controls.Add(EventTab);
            EventTab.Dock = DockStyle.Fill;
            NewPage.Text = Name;
            TabControl.TabPages.Add(NewPage);
            TabControl.SelectedTab = NewPage;
        }

        public void RefreshCurrent()
        {
            if (Rules != null)
            {
                switch (this.Rules.stage)
                {
                    case EventStage.SetupRules:
                        EventOptionsTab.RefreshGrids();
                        break;
                    case EventStage.SetupTeams:
                        //EventTeamsTab.RefreshGrids();
                        break;
                    case EventStage.Ready:
                        //EventTab.RefreshGrids();
                        break;
                }
            }
            else
            {
                EventOptionsTab.RefreshGrids();
            }
        }

        #region Event Saving

        /// <summary>
        /// Save the event during the Rules stage.
        /// </summary>
        public void saveEventRulesStage(List<Competitor> SelectedCompetitors, Ruleset.AccuracyRules Rules, DateTime Date, string EventName)
        {
            this.Rules = Rules;
            this.Date = Date;
            this.Name = EventName;

            // Stuff to merge over selected competitors so they are carried over.
            this.Teams = new List<Team>();
            Team currentTeam = new Team();
            for (int c = 0; c < SelectedCompetitors.Count; c++)
            {
                currentTeam.Competitors.Add(new EventCompetitor(SelectedCompetitors[c]));
            }
            this.Teams.Add(currentTeam);
            // End merger.

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
        }

        /// <summary>
        /// Save the event during the Team selection stage.
        /// </summary>
        public void saveEventTeamsStage()
        {
        }

        /// <summary>
        /// Save the event, ready to be started.
        /// </summary>
        public void saveEventReadyStage()
        {
        }

        #endregion

        #region Event Loading

        #endregion

        public void SaveEvent(Ruleset.AccuracyRules Rules, string EventName, DateTime Date, List<Competitor> SelectedCompetitors, List<string> SelectedTeams)
        {
            Competitors = SelectedCompetitors;
            this.Rules = Rules;
            Name = EventName;
            ActiveTeams = SelectedTeams;
            SQL_Controller.CreateEvent(this);
            EventID = SQL_Controller.GetLastInsertKey();
            EventOptionsTab = null;
        }

        public override void SaveEventTeams(int CompetitorsPerTeam, List<Team> Teams)
        {
            this.Teams = Teams;
            Rules.competitorsPerTeam = CompetitorsPerTeam;
            SQL_Controller.CreateSTeams(EventID, Teams);
            SQL_Controller.ModifyEvent(this);
            EventTeamsTab = null;
        }


        public override void ReturnToOptions()
        {
            TabControl.TabPages.Remove(TabControl.SelectedTab);
            EventTeamsTab = null;
            //EventOptionsTab = new EventAccuracyInit(TabControl, this, Rules, Name, DateTime.Today, Competitors);
            TabPage NewPage = new TabPage();
            NewPage.Controls.Add(EventOptionsTab);
            EventOptionsTab.Dock = DockStyle.Fill;
            NewPage.Text = "New Event";
            TabControl.TabPages.Add(NewPage);
            TabControl.SelectedTab = NewPage;
        }



        public override TWind ReturnWindLimits()
        {
            TWind CurrentWind = new TWind();
            CurrentWind.direction = Convert.ToUInt16(Rules.directionChangeFA);
            CurrentWind.speed = Rules.windspeedRejump;
            return CurrentWind;
        }

        public bool Rejumpable(AccuracyLanding L)
        {
            if (L.windDataPrior != null && L.windDataAfter != null)
            {
                #region SpeedChecks
                for (int i = 0; i < Rules.windSecondsPriorLand; i++)
                {
                    if (L.windDataPrior[i].speed > Rules.windspeedRejump) { return true; } //If wind out
                }
                for (int ii = 0; ii < Rules.windSecondsAfterLand; ii++)
                {
                    if (L.windDataAfter[ii].speed > Rules.windspeedRejump) { return true; } //If wind out  
                }
                #endregion
                #region DirectionChecks
                bool WindSpeedOverInTimePeriod = false;
                for (int i = 0; i < Rules.timePriorFA; i++)
                {
                    if (L.windDataPrior[i].speed > Rules.windspeedFA) { WindSpeedOverInTimePeriod = true; }
                }
                for (int i = 0; i < Rules.timeAfterFA; i++)
                {
                    if (L.windDataAfter[i].speed > Rules.windspeedFA) { WindSpeedOverInTimePeriod = true; }
                }
                if (WindSpeedOverInTimePeriod == true)
                {
                    List<int> AnglesBefore = new List<int>();
                    List<int> AnglesAfter = new List<int>();
                    for (int i = 0; i < Rules.timePriorFA; i++)
                    {
                        TWind currentWind = L.windDataPrior[i];
                        for (int i2 = 0; i2 < AnglesBefore.Count; i2++)
                        {
                            if (IsDirectionOut(currentWind, AnglesBefore[i2])) { return true; }
                            else
                            { AnglesBefore.Add(currentWind.direction); }
                        }
                    }
                    for (int i = 0; i < Rules.timeAfterFA; i++)
                    {
                        TWind currentWind = L.windDataAfter[i];
                        for (int i2 = 0; i2 < Rules.timeAfterFA; i2++)
                        {
                            if (IsDirectionOut(currentWind, AnglesAfter[i2])) { return true; }
                            else
                            { AnglesAfter.Add(currentWind.direction); }
                        }
                    }
                }
                #endregion
            }
            return false;
        }

        private bool IsDirectionOut(TWind wind, int prevData)
        {
            int minimum, maximum, minOverFlow, maxOverFlow;
            if (prevData < Rules.directionChangeFA)
            {
                minimum = 0;
                minOverFlow = (360 - (Rules.directionChangeFA - prevData));
                if ((wind.direction <= prevData) || (wind.direction > minOverFlow)) { return false; }
            }
            else
            {
                minimum = prevData - Rules.directionChangeFA;
                if (wind.direction < minimum) { return true; }
                else if (prevData > wind.direction) { return false; }
            }
            //Max checks
            if ((prevData + Rules.directionChangeFA) > 360)
            {
                maximum = 360;
                maxOverFlow = 0 + ((prevData + Rules.directionChangeFA) - 360);
                if ((wind.direction >= prevData) || (wind.direction < maxOverFlow)) { return false; }
            }
            else
            {
                maximum = prevData + Rules.directionChangeFA;
                if (wind.direction > maximum) { return true; }
            }

            return false;
        }
    }
}
