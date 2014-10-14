using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Concurrent;
namespace Classics_2014.Accuracy
{
    class Accuracy_Event :Event 
    {
        #region variables and the such like
        public EventAccuracyOptions EventOptionsTab;
        public EventTeams EventTeamsTab;
        public EventAccuracy EventTab;
        Engine engine;
        public Rulesets.AccuracyRuleset ruleSet;
        public List<Competitor> Competitors;
        public List<string> ActiveTeams;
        Boolean lostSerial = false;
        public AccuracyEventController controller;
        #endregion
        public Accuracy_Event(SQL_Controller SQL_Controller, IO_Controller IO_Controller, Engine engine, AccuracyEventController controller)
        {
            this.SQL_Controller = SQL_Controller;
            this.IO_Controller = IO_Controller;
            this.engine = engine;
            this.controller = controller;
            RequiresSerial = true;
            EventType = EventType.Accuracy;
        }

        public bool CloseEvent()
        {
            return controller.EndEvent(EventID);
        }

        public void ProceedToEventTeams()
        {
            EventTeamsTab = new EventTeams(this, Competitors, EventID, ruleSet.noOfCompetitorsPerTeam, ActiveTeams);
            TabPage NewPage = new TabPage();
            NewPage.Controls.Add(EventTeamsTab);
            EventTeamsTab.Dock = DockStyle.Fill;
            NewPage.Text = Name + " Team Config";
            TabControl.TabPages.Add(NewPage);
            TabControl.SelectedTab = NewPage;
        }

        public override void ProceedToEvent()
        {
            ruleSet.Stage = 2;
            SQL_Controller.ModifyAccuracyRules(ConvertRuleSetToByteArray(), EventID);
            EventTab = new EventAccuracy(this, TabControl);
            TabPage NewPage = new TabPage();
            NewPage.Controls.Add(EventTab);
            EventTab.Dock = DockStyle.Fill;
            NewPage.Text = Name;
            TabControl.TabPages.Add(NewPage);
            TabControl.SelectedTab = NewPage;
        }

        protected override byte[] ConvertRuleSetToByteArray()
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            string stringToConvert = "";
            stringToConvert += ruleSet.Stage + "*";
            stringToConvert += ruleSet.ScoresUsed + "*";
            stringToConvert += ruleSet.compHalt+ "*";
            stringToConvert += ruleSet.directionOut + "*";
            stringToConvert += ruleSet.windSpeedNeededForDirectionChangeRujumps + "*";
            stringToConvert += ruleSet.maxScored + "*";
            stringToConvert += ruleSet.noOfCompetitorsPerTeam + "*";
            stringToConvert += ruleSet.preset + "*";
            stringToConvert += ruleSet.windout + "*";
            stringToConvert += ruleSet.windSecondsAfter + "*";
            stringToConvert += ruleSet.windSecondsPrior + "*";
            stringToConvert += ruleSet.timeCheckAngleChangePrior + "*";
            stringToConvert += ruleSet.timeCheckAngleChangeAfter + "*";
            return ascii.GetBytes(stringToConvert);
        }
 

        public void SaveEvent(Rulesets.AccuracyRuleset Rules, string EventName, DateTime Date, List<Competitor> SelectedCompetitors, List<string> SelectedTeams)
        {
            Competitors = SelectedCompetitors;
            ruleSet = Rules;
            Name = EventName;
            ActiveTeams = SelectedTeams;
            byte[] ByteRules = ConvertRuleSetToByteArray();
            SQL_Controller.CreateEvent(Name, Classics_2014.EventType.Accuracy, ByteRules, Date);
            EventID = SQL_Controller.GetLastInsertKey();
            EventOptionsTab = null;
        }

        public override void SaveEventTeams(int CompetitorsPerTeam, List<Team> Teams)
        {
            this.Teams = Teams;
            ruleSet.noOfCompetitorsPerTeam = CompetitorsPerTeam;
            SQL_Controller.SaveTeams(EventID, Teams);
            SQL_Controller.ModifyAccuracyRules(ConvertRuleSetToByteArray(), EventID);
            EventTeamsTab = null;
        }


        public override void ReturnToOptions()
        {
            TabControl.TabPages.Remove(TabControl.SelectedTab);
            EventTeamsTab = null;
            EventOptionsTab = new EventAccuracyOptions(TabControl, this, ruleSet, Name, DateTime.Today, Competitors);
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
            CurrentWind.direction = Convert.ToUInt16(ruleSet.directionOut);
            CurrentWind.speed = ruleSet.windout;
            return CurrentWind;
        }

        public bool Rejumpable(AccuracyLanding L)
        {
            if (L.windDataPrior != null && L.WindDataAfter != null)
            {
                #region SpeedChecks
                for (int i = 0; i < ruleSet.windSecondsPrior; i++)
                {
                    if (L.windDataPrior[i].speed > ruleSet.windout) { return true; } //If wind out
                }
                for (int ii = 0; ii < ruleSet.windSecondsAfter; ii++)
                {
                    if (L.WindDataAfter[ii].speed > ruleSet.windout) { return true; } //If wind out  
                }
                #endregion
                #region DirectionChecks
                bool WindSpeedOverInTimePeriod = false;
                for (int i = 0; i < ruleSet.timeCheckAngleChangePrior; i++)
                {
                    if (L.windDataPrior[i].speed > ruleSet.windSpeedNeededForDirectionChangeRujumps) { WindSpeedOverInTimePeriod = true; }
                }
                for (int i = 0; i < ruleSet.timeCheckAngleChangeAfter; i++)
                {
                    if (L.WindDataAfter[i].speed > ruleSet.windSpeedNeededForDirectionChangeRujumps) { WindSpeedOverInTimePeriod = true; }
                }
                if (WindSpeedOverInTimePeriod == true)
                {
                    List<int> AnglesBefore = new List<int>();
                    List<int> AnglesAfter = new List<int>();
                    for (int i = 0; i < ruleSet.timeCheckAngleChangePrior; i++)
                    {
                        TWind currentWind = L.windDataPrior[i];
                        for (int i2 = 0; i2 < AnglesBefore.Count; i2++)
                        {
                            if (IsDirectionOut(currentWind, AnglesBefore[i2])) { return true; }
                            else
                            { AnglesBefore.Add(currentWind.direction); }
                        }
                    }
                    for (int i = 0; i < ruleSet.timeCheckAngleChangeAfter; i++)
                    {
                        TWind currentWind = L.WindDataAfter[i];
                        for (int i2 = 0; i2 < ruleSet.timeCheckAngleChangeAfter; i2++)
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

    }
}
