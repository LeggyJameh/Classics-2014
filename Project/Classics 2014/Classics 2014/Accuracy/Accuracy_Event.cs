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
        EventAccuracy activeEventTab;
        public EventAccuracyOptions EventOptionsTab;
        Engine engine;
        TAccuracyRuleSet ruleSet;
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
                DataA = (Data as Data_Accuracy);
                if (DataA != null)
                {
                    Active_Signal.Set();
                    //ToDo Data is received here DataA is the data and is ready to be used;
                }
                else
                {
                    //Downcast Failed, what the fuck!
                }
            }
        }
        protected override void CreateEvent()
        {
            SQL_Controller.CreateEvent(Name, EventType, ConvertRuleSetToString(), EventOptionsTab.ReturnDateTimePickerValue()); 
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
    }
}
