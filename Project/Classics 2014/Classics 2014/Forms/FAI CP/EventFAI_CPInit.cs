using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS.FAI_CP
{
    partial class EventFAI_CPInit : UserControl
    {
        #region variables and the such like
        FAI_CP_Event Connected_Event;
        Ruleset.FAI_CPRules rules = new Ruleset.FAI_CPRules();
        CompetitorSelector competitorSelector;
        string eventName = "";
        bool scoresUsedShowUnusualOptions = false;
        const float windspeedDiff = 0.5f; /// The minimum difference between safe and rejump windspeeds.
        #endregion

        public EventFAI_CPInit(FAI_CP_Event Connected_Event, bool loaded)
        {
            this.Connected_Event = Connected_Event;
            InitializeComponent();
            competitorSelector = new CompetitorSelector(Connected_Event);
            if (!loaded)
            {
                setupInputs();
            }
            else
            {
                loadInputsFromRules();
                competitorSelector.LoadCompetitorsFromEvent();
            }
            
            this.tableLayoutPanel1.Controls.Add(competitorSelector, 2, 0);
            competitorSelector.Dock = DockStyle.Fill;
            tableLayoutPanel1.SetRowSpan(competitorSelector, 13);
            tableLayoutPanel1.SetColumnSpan(competitorSelector, 2);
        }

        /// <summary>
        /// Checks to see if all the fields have valid results in them.
        /// </summary>
        private bool inputCorrect()
        {
            if ( // Sorry about this godawful bit of code. Best way to do it :/
                eventName != "" &&
                eventName.Length < 255 &&
                rules.preset != null &&
                rules.windspeedSafe >= 1 &&
                rules.windspeedSafe <= 100 &&
                rules.windspeedRejump >= 1 &&
                rules.windspeedRejump <= 100 &&
                rules.windSecondsPriorLand >= 1 &&
                rules.windSecondsPriorLand <= 300 &&
                rules.windSecondsAfterLand >= 1 &&
                rules.windSecondsAfterLand <= 300
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the input values to be that of the rules, used in loading.
        /// </summary>
        private void loadInputsFromRules()
        {
            rules = (Ruleset.FAI_CPRules)Connected_Event.Rules;

            inputName.Text = Connected_Event.Name;
            inputDate.Value = Connected_Event.Date;
            inputMaxWind.Value = Convert.ToDecimal(rules.windspeedSafe);
            inputDirectionChange.SelectedItem = (object)angleToString(rules.directionChange);
            inputRuleSet.SelectedItem = (object)rules.preset;
            inputLegalWindspeed.Value = Convert.ToDecimal(rules.windspeedRejump);
            inputWindDataAfter.Value = Convert.ToDecimal(rules.windSecondsAfterLand);
            inputWindDataPrior.Value = Convert.ToDecimal(rules.windSecondsPriorLand);
        }

        /// <summary>
        /// Takes the input from direction change and removes the ° char.
        /// </summary>
        private int getAngle(string degrees)
        {
            char[] charsToRemove = new char[1];
            charsToRemove[0] = '°';
            return Convert.ToInt16(degrees.TrimEnd(charsToRemove));
        }

        private string angleToString(int angle)
        {
            return angle.ToString() + '°';
        }

        /// <summary>
        /// Compiles the rules, checks validity and saves the event correctly.
        /// </summary>
        /// <returns>If the rules were valid.</returns>
        private bool compileDataAndSave()
        {
            bool allowed = true;
            DateTime date = inputDate.Value;
            eventName = inputName.Text.Trim();
            List<Competitor> competitors = getSelectedCompetitors();

            rules.windspeedSafe = Convert.ToSingle(inputMaxWind.Value);
            rules.preset = inputRuleSet.SelectedItem.ToString();
            rules.stage = EventStage.SetupRules;
            rules.windspeedRejump = Convert.ToSingle(inputLegalWindspeed.Value);
            rules.windSecondsAfterLand = Convert.ToInt16(inputWindDataAfter.Value);
            rules.windSecondsPriorLand = Convert.ToInt16(inputWindDataPrior.Value);

            if ((competitors.Count % rules.competitorsPerTeam) > 0)
            {
                if (MessageBox.Show("The number of competitors is not a multiple of competitors per team. Continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
                {
                    allowed = false;
                }
            }

            if (inputCorrect() && allowed == true)
            {
                Connected_Event.Rules = rules;
                Connected_Event.Date = date;
                Connected_Event.Name = eventName;
                Connected_Event.UnassignedCompetitors = competitors;
                Connected_Event.SaveCurrentStage();
                return true;
            }
            else
            {
                MessageBox.Show("Settings are invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Changes the settings of the input forms to be correct.
        /// </summary>
        private void setupInputs()
        {
            inputDate.Value = DateTime.Today;
            inputName.Text = "Canopy Piloting Event " + (Connected_Event.SQL_Controller.GetNoOfEventsByTypeOnDay(DateTime.Today, EventType.FAI_CP) + 1).ToString() + " " + DateTime.Today.ToShortDateString();
            inputRuleSet.SelectedIndex = 0;
            inputDirectionChange.SelectedItem = inputDirectionChange.Items[8];
            inputRuleSet.SelectedItem = inputRuleSet.Items[0];
            labelWarning.Text = "";
            windspeedSafe = 5.0f;
            windspeedRejump = 4.0f;
        }

        /// <summary>
        /// Pulls the list of selected competitors from the CompetitorSelector Control.
        /// </summary>
        private List<Competitor> getSelectedCompetitors()
        {
            return competitorSelector.GetSelectedCompetitors();
        }

        /// <summary>
        /// Forces the competitor selector to reload groups and competitors due to the competitor editor being used.
        /// </summary>
        public void RefreshGrids()
        {
            competitorSelector.ReloadData();
        }

        #region Control Events

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (compileDataAndSave())
            {
                Connected_Event.NextStage();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            compileDataAndSave();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to save your changes before exiting?", "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            switch (result)
            {
                case DialogResult.Yes:
                    Connected_Event.Exit();
                    break;
                case DialogResult.No:
                    compileDataAndSave();
                    Connected_Event.Exit();
                    break;
            }
        }

        private void inputMaxWind_ValueChanged(object sender, EventArgs e)
        {
            windspeedSafe = Convert.ToSingle(inputMaxWind.Value);
        }

        private void inputLegalWindspeed_ValueChanged(object sender, EventArgs e)
        {
            windspeedRejump = Convert.ToSingle(inputLegalWindspeed.Value);
        }

        #endregion

        #region Rules variables get set operators

        private float windspeedSafe
        {
            get
            {
                return rules.windspeedSafe;
            }
            set
            {
                if (windspeedRejump > (value - windspeedDiff))
                {
                    windspeedRejump = Convert.ToSingle(value - windspeedDiff);
                }
                inputMaxWind.Value = (decimal)value;
                rules.windspeedSafe = value;
            }
        }

        private float windspeedRejump
        {
            get
            {
                return rules.windspeedRejump;
            }
            set
            {
                if (windspeedSafe < (value + windspeedDiff))
                {
                    windspeedSafe = Convert.ToSingle(value + windspeedDiff);
                }
                inputLegalWindspeed.Value = (decimal)value;
                rules.windspeedRejump = value;
            }
        }

        #endregion
    }
}
