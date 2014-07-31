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
        EventTeams activeEventTab;
        public EventAccuracyOptions EventOptionsTab;
        public EventTeams EventTeamsTab;
        public EventAccuracy EventTab; 
        Engine engine;
        TAccuracyRuleSet ruleSet;
        List<TCompetitor> Competitors;
        List<string> ActiveTeams;
        TWind[] IncomingData;
        public int NumberOfLandings = -1;
        List<Accuracy.AccuracyLanding> LandingInProgress = new List<Accuracy.AccuracyLanding>();
        List<Accuracy.AccuracyLanding> CompletedLandings = new List<Accuracy.AccuracyLanding>();
        List<Accuracy.AccuracyLanding> LandingsToRemove = new List<Accuracy.AccuracyLanding>();
        #endregion
        public Accuracy_Event(SQL_Controller SQL_Controller, IO_Controller IO_Controller, Engine engine)
        {
            this.SQL_Controller = SQL_Controller;
            this.IO_Controller = IO_Controller;
            this.engine = engine;
            RequiresSerial = true;
            EventType = EventType.Accuracy;
            ListenThread = new Thread(new ThreadStart(ListenProcedure));
        }
        public void EventStart() //TODO Rule struct goes here
        {
           
        }
        private void ListenProcedure()
        {
            IncomingData = new TWind[ruleSet.windSecondsPrior];
            do
            {
            Data Data;
            Data_Accuracy DataA = new Data_Accuracy();
            IO_Controller._signal.WaitOne();
            while (Data_queueEvent.TryDequeue(out Data))
            {
                DataA = (Data as Data_Accuracy);
                if (DataA != null)
                {
                    for (int i = IncomingData.Length; i > 0; i--)
                    {
                        if (i != IncomingData.Length && i >= 1)
                        {
                            IncomingData[i] = IncomingData[i - 1];
                        }
                    }
                    IncomingData[0] = new TWind { time = Data.Time, speed = DataA.Speed, direction = DataA.Direction }; ;
                    if (DataA.IsLanding)
                    {
                        AccuracyLanding newLanding = new AccuracyLanding { score = DataA.LandingScore, windDataPrior = IncomingData, WindInputs = 0, TimeOfLanding = DataA.Time, LandingWind = new TWind { time = Data.Time, speed = DataA.Speed, direction = DataA.Direction }, WindDataAfter = new TWind[ruleSet.windSecondsAfter] };
                        LandingInProgress.Add(newLanding);
                        newLanding.Index = EventTab.MethodAddLanding(newLanding);
                        EventTab.ScoreEdit(DataA.LandingScore.ToString());
                    }
                    for (int i = 0; i < LandingInProgress.Count; i++)
                    {
                        AccuracyLanding currentLanding = LandingInProgress[i];
                        if (currentLanding.WindInputs == currentLanding.WindDataAfter.Length - 1) { LandingsToRemove.Add(currentLanding); currentLanding.ID = SQL_Controller.CreateAccuracyLanding(EventID, currentLanding.score, ConvertLandingToByteArray(currentLanding)); CompletedLandings.Add(currentLanding); }
                        else
                        {
                            //ToDo Classify Landing, so we can do pro leet tricks
                            currentLanding.WindDataAfter[currentLanding.WindInputs] = new TWind { time = Data.Time, speed = DataA.Speed, direction = DataA.Direction };
                            currentLanding.WindInputs++;
                            LandingInProgress[i] = currentLanding;
                            
                            //ToDo Check that wind hasnt gone over here
                        }
                    }
                    foreach (AccuracyLanding l in LandingsToRemove)
                    {
                         LandingInProgress.Remove(l);
                    }
                    LandingsToRemove.Clear();
                }
            }
            }while(true);

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

        protected override byte[] ConvertRuleSetToByteArray()
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

        private byte[] ConvertLandingToByteArray(Accuracy.AccuracyLanding Landing)
        {
            //ToDo Override To String
            ASCIIEncoding ascii = new ASCIIEncoding();
            string stringToConvert = "";
            stringToConvert += Landing.LandingWind + "*";
            stringToConvert += Landing.TimeOfLanding + "*";
            stringToConvert += Landing.WindDataAfter + "*";
            stringToConvert += Landing.windDataPrior + "*";
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
            byte[] ByteRules = ConvertRuleSetToByteArray();
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

        public Accuracy.AccuracyLanding AssignLanding(int Index, DataGridViewCell Cell)
        {
            AccuracyLanding CurrentLanding = new AccuracyLanding();
            CurrentLanding.ID = -1;
            if (CompletedLandings.Count -1 >= Index)
            {
                CurrentLanding = CompletedLandings[Index];
                CurrentLanding.dataGridCell = Cell;
                CompletedLandings[Index] = CurrentLanding;
            }
            return CurrentLanding;
        }

        public void RemoveCompletedLanding(AccuracyLanding Landing)
        {
            CompletedLandings.Remove(Landing);
        }

        public void makeActive()
        {
            if (IO_Controller.Serial_Input)
            {
                engine.MakeActive(this);
                ListenThread.Start();
            }
        }
    }
}
