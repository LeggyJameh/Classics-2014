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
        EventAccuracyTeams activeEventTab;
        public EventAccuracyOptions EventOptionsTab;
        public EventAccuracyTeams EventTeamsTab;
        public TabControl TabControl;
        Engine engine;
        TAccuracyRuleSet ruleSet;
        int EventID;
        List<TCompetitor> Competitors;
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
            Data Data;
            Data_Accuracy DataA = new Data_Accuracy();
            IO_Controller._signal.WaitOne();
            while (IO_Controller.Data_queue.TryPeek(out Data))
            {
                Active_Signal.Set();
                DataA = (Data as Data_Accuracy);
                if (DataA != null)
                {
                    //ToDo Data is received here DataA is the data and is ready to be used;
                }
                else
                {
                    //Downcast Failed, what the fuck!
                }
            }
        }

        public void ProceedToEventTeams()
        {
            EventTeamsTab = new EventAccuracyTeams(Competitors, EventID, ruleSet.noOfCompetitorsPerTeam);
            TabPage NewPage = new TabPage();
            NewPage.Controls.Add(EventTeamsTab);
            EventTeamsTab.Dock = DockStyle.Fill;
            NewPage.Text = Name + " Team Config";
            TabControl.TabPages.Add(NewPage);
            TabControl.SelectedTab = NewPage;
        }

        protected override byte[] ConvertRuleSetToString()
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            string stringToConvert = "";
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

        public void SaveEvent(TAccuracyRuleSet Rules, string Name, DateTime Date, List<TCompetitor> SelectedCompetitors)
        {
            Competitors = SelectedCompetitors;
            ruleSet = Rules;
            byte[] ByteRules = ConvertRuleSetToString();
            SQL_Controller.CreateEvent(Name, Classics_2014.EventType.Accuracy, ByteRules, Date);
            EventID = SQL_Controller.GetLastInsertKey();
            EventOptionsTab = null;
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
