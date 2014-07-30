using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace Classics_2014.Accuracy
{
    class Accuracy_Event :Event 
    {
        #region variables and the such like
        readonly AutoResetEvent Active_Signal;
        EventTeams activeEventTab;
        public EventAccuracyOptions EventOptionsTab;
        public EventTeams EventTeamsTab;
        public EventAccuracy EventTab; 
        Engine engine;
        TAccuracyRuleSet ruleSet;
        List<TCompetitor> Competitors;
        List<string> ActiveTeams;
        Data_Accuracy[] IncomingData;
        
        #endregion
        public Accuracy_Event(SQL_Controller SQL_Controller, IO_Controller IO_Controller, AutoResetEvent Active_Signal, Engine engine)
        {
            this.SQL_Controller = SQL_Controller;
            this.IO_Controller = IO_Controller;
            this.Active_Signal = Active_Signal;
            this.engine = engine;
            RequiresSerial = true;
            EventType = EventType.Accuracy;
             ListenThread = new Thread(new ThreadStart(ListenProcedure));
        }
        private void EventStart() //TODO Rule struct goes here
        {
        }
        private void ListenProcedure()
        {
            IncomingData = new Data_Accuracy[ruleSet.windSecondsPrior + ruleSet.windSecondsAfter + 1];
            Data Data;
            Data_Accuracy DataA = new Data_Accuracy();
            IO_Controller._signal.WaitOne();
            while (IO_Controller.Data_queue.TryPeek(out Data))
            {
                Active_Signal.Set();
                DataA = (Data as Data_Accuracy);
                if (DataA != null)
                {
                    for (int i = IncomingData.Length; i > 0 ; i--)
                    {
                        if (i != IncomingData.Length && i >= 1)
                        {
                            IncomingData[i] = IncomingData[i - 1];
                        }
                    }
                    IncomingData[0] = DataA;

                    if (IncomingData[ruleSet.windSecondsPrior + 1].IsLanding == true)
                    {

                    }
                }
                else
                {
                    //Downcast Failed, what the fuck!
                }
            }
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

        public void LoadEventOptions()
        {

        }

        public void ProceedToEvent()
        {
            EventTab = new EventAccuracy(this, TabControl);
            TabPage NewPage = new TabPage();
            NewPage.Controls.Add(EventTab);
            EventTab.Dock = DockStyle.Fill;
            NewPage.Text = Name;
            TabControl.TabPages.Add(NewPage);
            TabControl.SelectedTab = NewPage;
        }

        protected override byte[] ConvertRuleSetToString()
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            string stringToConvert = "";
            stringToConvert += TeamsSetup + "*";
            stringToConvert += ruleSet.allScoresUsed + "*";
            stringToConvert += ruleSet.compHalt+ "*";
            stringToConvert += ruleSet.directionOut + "*";
            stringToConvert += ruleSet.finalApproachTime + "*";
            stringToConvert += ruleSet.maxScored + "*";
            stringToConvert += ruleSet.noOfCompetitorsPerTeam + "*";
            stringToConvert += ruleSet.preset + "*";
            stringToConvert += ruleSet.windout + "*";
            stringToConvert += ruleSet.windSecondsAfter + "*";
            stringToConvert += ruleSet.windSecondsPrior + "*";
            return ascii.GetBytes(stringToConvert);

        }

        //protected override TAccuracyRuleSet ConvertStringToRuleset(string Input)
        //{
        //}

        public void SaveEvent(TAccuracyRuleSet Rules, string EventName, DateTime Date, List<TCompetitor> SelectedCompetitors, List<string> SelectedTeams)
        {
            Competitors = SelectedCompetitors;
            ruleSet = Rules;
            Name = EventName;
            ActiveTeams = SelectedTeams;
            byte[] ByteRules = ConvertRuleSetToString();
            SQL_Controller.CreateEvent(Name, Classics_2014.EventType.Accuracy, ByteRules, Date);
            EventID = SQL_Controller.GetLastInsertKey();
            EventOptionsTab = null;
        }

        public override void SaveEventTeams(int CompetitorsPerTeam, List<List<TCompetitor>> TeamInput, List<string> TeamNamesInput)
        {
            ruleSet.noOfCompetitorsPerTeam = CompetitorsPerTeam;
            Teams = TeamInput;
            TeamNames = TeamNamesInput;
            //TODO: Create Teams table in DB
            EventTeamsTab = null;
            ProceedToEvent();
        }
        

        private void makeActive()
        {
            if (IO_Controller.Serial_Input)
            {
                ListenThread.Start();
            }
        }
    }
}
