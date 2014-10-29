using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Concurrent;
using Classics_2014.MySQL;

namespace Classics_2014.Accuracy
{
    // Working 28/10/14.
    class Accuracy_Event :Event 
    {
        #region variables and the such like
        public EventAccuracyInit EventOptionsTab;
        public EventTeams EventTeamsTab;
        public EventAccuracy EventTab;
        Engine engine;
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
        }

        /// <summary>
        /// Used for loading procedures. Not viable when initialising a new instance of an Event.
        /// </summary>
        public Accuracy_Event()
        {
        }

        public bool CloseEvent()
        {
            return controller.EndEvent(this);
        }

        public void ProceedToEventTeams()
        {
            EventTeamsTab = new EventTeams(this, Competitors, EventID, Rules.noOfCompetitorsPerTeam, ActiveTeams);
            TabPage NewPage = new TabPage();
            NewPage.Controls.Add(EventTeamsTab);
            EventTeamsTab.Dock = DockStyle.Fill;
            NewPage.Text = Name + " Team Config";
            TabControl.TabPages.Add(NewPage);
            TabControl.SelectedTab = NewPage;
        }

        public override void ProceedToEvent()
        {
            Rules.Stage = 2;
            SQL_Controller.ModifyEvent(this);
            EventTab = new EventAccuracy(this, TabControl);
            TabPage NewPage = new TabPage();
            NewPage.Controls.Add(EventTab);
            EventTab.Dock = DockStyle.Fill;
            NewPage.Text = Name;
            TabControl.TabPages.Add(NewPage);
            TabControl.SelectedTab = NewPage;
        }

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
            Rules.noOfCompetitorsPerTeam = CompetitorsPerTeam;
            SQL_Controller.SaveTeams(EventID, Teams);
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
            CurrentWind.direction = Convert.ToUInt16(Rules.directionOut);
            CurrentWind.speed = Rules.windout;
            return CurrentWind;
        }

        public bool Rejumpable(AccuracyLanding L)
        {
            if (L.windDataPrior != null && L.windDataAfter != null)
            {
                #region SpeedChecks
                for (int i = 0; i < Rules.windSecondsPrior; i++)
                {
                    if (L.windDataPrior[i].speed > Rules.windout) { return true; } //If wind out
                }
                for (int ii = 0; ii < Rules.windSecondsAfter; ii++)
                {
                    if (L.windDataAfter[ii].speed > Rules.windout) { return true; } //If wind out  
                }
                #endregion
                #region DirectionChecks
                bool WindSpeedOverInTimePeriod = false;
                for (int i = 0; i < Rules.timeCheckAngleChangePrior; i++)
                {
                    if (L.windDataPrior[i].speed > Rules.windSpeedNeededForDirectionChangeRujumps) { WindSpeedOverInTimePeriod = true; }
                }
                for (int i = 0; i < Rules.timeCheckAngleChangeAfter; i++)
                {
                    if (L.windDataAfter[i].speed > Rules.windSpeedNeededForDirectionChangeRujumps) { WindSpeedOverInTimePeriod = true; }
                }
                if (WindSpeedOverInTimePeriod == true)
                {
                    List<int> AnglesBefore = new List<int>();
                    List<int> AnglesAfter = new List<int>();
                    for (int i = 0; i < Rules.timeCheckAngleChangePrior; i++)
                    {
                        TWind currentWind = L.windDataPrior[i];
                        for (int i2 = 0; i2 < AnglesBefore.Count; i2++)
                        {
                            if (IsDirectionOut(currentWind, AnglesBefore[i2])) { return true; }
                            else
                            { AnglesBefore.Add(currentWind.direction); }
                        }
                    }
                    for (int i = 0; i < Rules.timeCheckAngleChangeAfter; i++)
                    {
                        TWind currentWind = L.windDataAfter[i];
                        for (int i2 = 0; i2 < Rules.timeCheckAngleChangeAfter; i2++)
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
            if (prevData < Rules.directionOut)
            {
                minimum = 0;
                minOverFlow = (360 - (Rules.directionOut - prevData));
                if ((wind.direction <= prevData) || (wind.direction > minOverFlow)) { return false; }
            }
            else
            {
                minimum = prevData - Rules.directionOut;
                if (wind.direction < minimum) { return true; }
                else if (prevData > wind.direction) { return false; }
            }
            //Max checks
            if ((prevData + Rules.directionOut) > 360)
            {
                maximum = 360;
                maxOverFlow = 0 + ((prevData + Rules.directionOut) - 360);
                if ((wind.direction >= prevData) || (wind.direction < maxOverFlow)) { return false; }
            }
            else
            {
                maximum = prevData + Rules.directionOut;
                if (wind.direction > maximum) { return true; }
            }

            return false;
        }
    }
}
