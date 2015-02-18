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
    class Accuracy_Event : Event 
    {
        #region variables and the such like
        public List<Competitor> Competitors;
        public List<string> ActiveTeams;
        Boolean lostSerial = false;
        public AccuracyEventController controller;
        Ruleset.AccuracyRules rules;
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
            EventType = EventType.INTL_ACCURACY;
            EventID = -1;
            rules = new Ruleset.AccuracyRules();
            base._updateCompetitorDelegate = new UpdateCompetitorDelegate(UpdateCompetitors);
            controller.AddCompetitorUpdateDelegate(base._updateCompetitorDelegate);
            currentWindow = new EventAccuracyInit(this, false);
            controller.AddTab(currentWindow);
        }

        /// <summary>
        /// Used for loading procedures. Not viable when initialising a new instance of an Event.
        /// </summary>
        public Accuracy_Event()
        {
        }

        //public void proceedToEvent()
        //{
        //    rules.stage = EventStage.Ready;
        //    SQL_Controller.ModifyEvent(this);
        //    EventTab = new EventAccuracy(this, TabControl);
        //    TabPage NewPage = new TabPage();
        //    NewPage.Controls.Add(EventTab);
        //    EventTab.Dock = DockStyle.Fill;
        //    NewPage.Text = Name;
        //    TabControl.TabPages.Add(NewPage);
        //    TabControl.SelectedTab = NewPage;
        //}

        /// <summary>
        /// Function used in loading to transfer over references that are usually passed on creation.
        /// </summary>
        public void AddParents(SQL_Controller sql_controller, IO_Controller io_controller, Engine engine, Accuracy.AccuracyEventController eventController)
        {
            this.SQL_Controller = sql_controller;
            this.IO_Controller = io_controller;
            this.engine = engine;
            this.controller = eventController;
            RequiresSerial = true;
            if (UnassignedCompetitors == null)
            {
                UnassignedCompetitors = new List<Competitor>();
            }
            if (Teams == null)
            {
                Teams = new List<Team>();
            }
        }

        #region Event Saving

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

        //public void SaveEvent(Ruleset.AccuracyRules Rules, string EventName, DateTime Date, List<Competitor> SelectedCompetitors, List<string> SelectedTeams)
        //{
        //    Competitors = SelectedCompetitors;
        //    this.Rules = Rules;
        //    Name = EventName;
        //    ActiveTeams = SelectedTeams;
        //    SQL_Controller.CreateEvent(this);
        //    EventID = SQL_Controller.GetLastInsertKey();
        //    EventOptionsTab = null;
        //}

        //public override void SaveEventTeams(int CompetitorsPerTeam, List<Team> Teams)
        //{
        //    this.Teams = Teams;
        //    rules.competitorsPerTeam = CompetitorsPerTeam;
        //    throw new NotImplementedException();
        //    //SQL_Controller.CreateTeams(EventID, Teams);
        //    SQL_Controller.ModifyEvent(this);
        //    EventTeamsTab = null;
        //}

        /// <summary>
        /// Called when competitor editor makes a save from engine.
        /// </summary>
        public void UpdateCompetitors()
        {
            if (Rules != null)
            {
                switch (this.Rules.stage)
                {
                    case EventStage.SetupRules:
                        EventAccuracyInit t = (EventAccuracyInit)base.currentWindow;
                        t.RefreshGrids();
                        break;
                    case EventStage.SetupTeams:
                        TeamPicker l = (TeamPicker)base.currentWindow;
                        l.refreshCompetitors();
                        break;
                    case EventStage.Ready:
                        //EventTab.RefreshGrids();
                        break;
                }
            }
        }

        public override TWind ReturnWindLimits()
        {
            TWind CurrentWind = new TWind();
            CurrentWind.direction = Convert.ToUInt16(rules.directionChangeFA);
            CurrentWind.speed = rules.windspeedRejump;
            return CurrentWind;
        }

        public bool Rejumpable(AccuracyLanding L)
        {
            if (L.windDataPrior != null && L.windDataAfter != null)
            {
                #region SpeedChecks
                for (int i = 0; i < rules.windSecondsPriorLand; i++)
                {
                    if (L.windDataPrior[i].speed > rules.windspeedRejump) { return true; } //If wind out
                }
                for (int ii = 0; ii < rules.windSecondsAfterLand; ii++)
                {
                    if (L.windDataAfter[ii].speed > rules.windspeedRejump) { return true; } //If wind out  
                }
                #endregion
                #region DirectionChecks
                bool WindSpeedOverInTimePeriod = false;
                for (int i = 0; i < rules.timePriorFA; i++)
                {
                    if (L.windDataPrior[i].speed > rules.windspeedFA) { WindSpeedOverInTimePeriod = true; }
                }
                for (int i = 0; i < rules.timeAfterFA; i++)
                {
                    if (L.windDataAfter[i].speed > rules.windspeedFA) { WindSpeedOverInTimePeriod = true; }
                }
                if (WindSpeedOverInTimePeriod == true)
                {
                    List<int> AnglesBefore = new List<int>();
                    List<int> AnglesAfter = new List<int>();
                    for (int i = 0; i < rules.timePriorFA; i++)
                    {
                        TWind currentWind = L.windDataPrior[i];
                        for (int i2 = 0; i2 < AnglesBefore.Count; i2++)
                        {
                            if (IsDirectionOut(currentWind, AnglesBefore[i2])) { return true; }
                            else
                            { AnglesBefore.Add(currentWind.direction); }
                        }
                    }
                    for (int i = 0; i < rules.timeAfterFA; i++)
                    {
                        TWind currentWind = L.windDataAfter[i];
                        for (int i2 = 0; i2 < rules.timeAfterFA; i2++)
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
            if (prevData < rules.directionChangeFA)
            {
                minimum = 0;
                minOverFlow = (360 - (rules.directionChangeFA - prevData));
                if ((wind.direction <= prevData) || (wind.direction > minOverFlow)) { return false; }
            }
            else
            {
                minimum = prevData - rules.directionChangeFA;
                if (wind.direction < minimum) { return true; }
                else if (prevData > wind.direction) { return false; }
            }
            //Max checks
            if ((prevData + rules.directionChangeFA) > 360)
            {
                maximum = 360;
                maxOverFlow = 0 + ((prevData + rules.directionChangeFA) - 360);
                if ((wind.direction >= prevData) || (wind.direction < maxOverFlow)) { return false; }
            }
            else
            {
                maximum = prevData + rules.directionChangeFA;
                if (wind.direction > maximum) { return true; }
            }

            return false;
        }
    }
}
