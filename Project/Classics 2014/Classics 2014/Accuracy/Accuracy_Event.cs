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
        TWind[] IncomingData;
        int NumberOfLandings = 0;
        public List<Accuracy.AccuracyLanding> LandingInProgress = new List<Accuracy.AccuracyLanding>();
        public List<Accuracy.AccuracyLanding> CompletedLandings = new List<Accuracy.AccuracyLanding>();
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
                        NumberOfLandings++;
                        AccuracyLanding newLanding = new AccuracyLanding { Index = NumberOfLandings, ID = 0, score = DataA.LandingScore, windDataPrior =(TWind[])IncomingData.Clone(), WindInputs = 0, TimeOfLanding = DataA.Time, LandingWind = new TWind { time = Data.Time, speed = DataA.Speed, direction = DataA.Direction }, WindDataAfter = new TWind[ruleSet.windSecondsAfter] };
                        newLanding.ID = SQL_Controller.CreateAccuracyLanding(EventID, newLanding.score);
                        LandingInProgress.Add(newLanding);
                        EventTab.MethodAddLanding(newLanding);
                        EventTab.ScoreEdit(DataA.LandingScore.ToString());
                    }
                    for (int i = 0; i < LandingInProgress.Count; i++)
                    {
                        AccuracyLanding currentLanding = LandingInProgress[i];
                        if (currentLanding.WindInputs == currentLanding.WindDataAfter.Length) //ToDo Made an edit that was messing with us
                        {
                            EventTab.MakeLandingComplete(currentLanding.ID);
                            LandingsToRemove.Add(currentLanding);
                            CompletedLandings.Add(currentLanding);
                            SQL_Controller.AssignWindDataToAccuracyLanding(ConvertLandingToByteArray(currentLanding),currentLanding.isRejumpable ,currentLanding.ID);
                        }
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

        private byte[] ConvertLandingToByteArray(Accuracy.AccuracyLanding Landing)
        {
            //ToDo Override To String
            BinaryFormatter f = new BinaryFormatter();
            MemoryStream m = new MemoryStream();
            f.Serialize(m,Landing);
            return m.ToArray();
        }
        public AccuracyLanding ConvertByteArrayToLanding(byte[] Landing)
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter f = new BinaryFormatter();
            m.Write(Landing, 0, Landing.Length);
            m.Seek(0, SeekOrigin.Begin);
            AccuracyLanding deSerializedLanding = (AccuracyLanding)f.Deserialize(m);
            return deSerializedLanding;
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

        public int GetLandingIDFromCell(DataGridViewCell Cell)
        {
            for (int i = 0; i < CompletedLandings.Count; i++)
			{
                if (CompletedLandings[i].dataGridCell == Cell)
                {
                    return CompletedLandings[i].ID;
                }
			}
            for (int i = 0; i < LandingInProgress.Count; i++)
            {
                if (LandingInProgress[i].dataGridCell == Cell)
                {
                    return LandingInProgress[i].ID;
                }
            }
            return -1;
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


        public bool makeActive()
        {
            if (IO_Controller.Serial_Input)
            {
                IsActive = true;
                engine.MakeActive(this, new Action(makeInactive));
                ListenThread.Start();
                return true;
            }
            return false;
        }

        public void makeInactive()
        {
            engine.activeEvent = null;
            IsActive = false;
            ListenThread.Abort();
            ListenThread = new Thread(new ThreadStart(ListenProcedure));
            //TODO: Gracefully end event thread.
        }

        public override TWind ReturnWindLimits()
        {
            TWind CurrentWind = new TWind();
            CurrentWind.direction = Convert.ToUInt16(ruleSet.directionOut);
            CurrentWind.speed = ruleSet.windout;
            return CurrentWind;
        }
        private bool Rejumpable(AccuracyLanding L)
        {
            #region SpeedChecks
            for (int i = 0; i < L.windDataPrior.Length; i++)
            {
                if (L.windDataPrior[i].speed > ruleSet.windout) { return true; } //If wind out
            }
            for (int ii = 0; ii < L.WindDataAfter.Length; ii++)
            {
                 if (L.windDataPrior[ii].speed > ruleSet.windout) { return true; } //If wind out  
            }
            #endregion
            #region DirectionChecks
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
            #endregion
            return false;
        }
        private bool IsDirectionOut(TWind wind, int prevData)
        {
            int minimum, maximum, minOverFlow, maxOverFlow;
            if (prevData < ruleSet.directionOut )
            {
                minimum = 0;
                minOverFlow = (360 - (ruleSet.directionOut - prevData));
                if ((wind.direction <= prevData) || (wind.direction > minOverFlow)) { return false; }
            }
            else
            {
                minimum = prevData - ruleSet.directionOut;
                if (wind.direction < minimum) { return true; }
                else if (prevData > wind.direction) { return false; }
            }
            //Max checks
            if ((prevData + ruleSet.directionOut) > 360)
            {
                maximum = 360;
                maxOverFlow = 0 + ((prevData + ruleSet.directionOut) - 360);
                if ((wind.direction >= prevData) || (wind.direction < maxOverFlow)) { return false; }
            }
            else
            {
                maximum = prevData + ruleSet.directionOut;
                if (wind.direction > maximum) { return true; }
            }

            return false;
        }
    }
}
