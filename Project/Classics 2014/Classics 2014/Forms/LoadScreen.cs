using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS
{
    partial class LoadScreen : UserControl
    {
        EventLoader EventLoader;

        public LoadScreen(EventLoader EventLoader)
        {
            this.EventLoader = EventLoader;
            InitializeComponent();
            refreshEventGrid();
        }

        private void refreshEventGrid()
        {
            EventLoader.loadEventsFromDatabase();
            dataGridEvents.SuspendLayout();
            dataGridEvents.Rows.Clear();
            foreach (Event e in EventLoader.events)
            {
                if (e != null)
                {
                    dataGridEvents.Rows.Add(e.EventID, e.Name, e.Date.ToShortDateString(), e.EventType.ToString());
                }
            }
            dataGridEvents.ResumeLayout();
        }

        private void displayEventProperties(Event Event)
        {
            dataGridProperties.Rows.Clear();
            List<string> properties = getEventProperties(Event);
            bool left = true; // Used to put each string on either cell of each row. Weird, I know.

            foreach (string s in properties)
            {
                if (left)
                {
                    left = false;
                    dataGridProperties.Rows.Add(s);
                }
                else
                {
                    left = true;
                    dataGridProperties.Rows[dataGridProperties.Rows.Count - 1].Cells[1].Value = s;
                }
            }
        }

        /// <summary>
        /// Function used to gather all of the properties of the selected event, by type. Will return list of property names and values.
        /// </summary>
        private List<string> getEventProperties(Event Event)
        {
            List<string> properties = new List<string>();
            properties.Add("Stage");
            switch (Event.Rules.stage)
            {
                case EventStage.SetupRules:
                    properties.Add("Setup Rules");
                    break;
                case EventStage.SetupTeams:
                    properties.Add("Setup Teams");
                    break;
                case EventStage.SetupEID:
                    properties.Add("Setup Event IDs");
                    break;
                case EventStage.Ready:
                    properties.Add("Ready");
                    break;
            }
            properties.Add("Competitors per team");
            properties.Add(Event.Rules.competitorsPerTeam.ToString());
            

            switch (Event.EventType)
            {
                case EventType.INTL_ACCURACY:
                    Ruleset.AccuracyRules rules = (Ruleset.AccuracyRules)Event.Rules;
                    properties.Add("Scores used");
                    properties.Add(rules.scoresUsed);
                    properties.Add("Preset");
                    properties.Add(rules.preset);
                    properties.Add("Max score");
                    properties.Add(rules.maxScore.ToString());
                    properties.Add("");
                    properties.Add("");
                    properties.Add("Maximum safe windspeed");
                    properties.Add(rules.windspeedSafe.ToString());
                    properties.Add("Pre-landing wind time");
                    properties.Add(rules.windSecondsPriorLand.ToString());
                    properties.Add("Post-landing wind time");
                    properties.Add(rules.windSecondsAfterLand.ToString());
                    properties.Add("");
                    properties.Add("");
                    properties.Add("Legal Windspeed");
                    properties.Add(rules.windspeedRejump.ToString());
                    properties.Add("FA legal windspeed");
                    properties.Add(rules.windspeedFA.ToString());
                    properties.Add("FA direction change");
                    properties.Add(rules.directionChangeFA.ToString() + "°");
                    properties.Add("FA time before land");
                    properties.Add(rules.timePriorFA.ToString());
                    properties.Add("FA time after land");
                    properties.Add(rules.timeAfterFA.ToString());
                    break;
            }

            return properties;
        }

        /// <summary>
        /// Function to get the currently selected event from the datagrid. Returns the event or null.
        /// </summary>
        public Event getSelectedEvent()
        {
            if (dataGridEvents.SelectedRows != null)
            {
                if (dataGridEvents.SelectedRows.Count > 0)
                {
                    int eventID = Convert.ToInt16(dataGridEvents.SelectedRows[0].Cells[0].Value);

                    foreach (Event e in EventLoader.events)
                    {
                        if (e != null)
                        {
                            if (e.EventID == eventID)
                            {
                                return e;
                            }
                        }
                    }
                }
            }
            return null;
        }

        #region Control Events

        private void dataGridEvents_SelectionChanged(object sender, EventArgs e)
        {
            Event _event = getSelectedEvent();
            if (_event != null)
            {
                displayEventProperties(_event);
            }
        }

        private void inputLoad_Click(object sender, EventArgs e)
        {
            Event _event = getSelectedEvent();
            if (_event != null)
            {
                EventLoader.LoadEvent(_event);
            }
            EventLoader.Close();
            this.EventLoader = null;
        }

        private void inputCancel_Click(object sender, EventArgs e)
        {
            EventLoader.Close();
            this.EventLoader = null;
        }

        private void inputDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to delete the selected event?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Event _event = getSelectedEvent();
                if (_event != null)
                {
                    EventLoader.RemoveEvent(_event);
                    refreshEventGrid();
                }
                else
                {
                    MessageBox.Show("No event selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void inputRefresh_Click(object sender, EventArgs e)
        {
            refreshEventGrid();
        }
    }
        #endregion
}
