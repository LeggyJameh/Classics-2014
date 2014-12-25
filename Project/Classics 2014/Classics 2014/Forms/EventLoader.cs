using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMS.MySQL;

namespace CMS
{
    partial class EventLoader : UserControl
    {
        Engine Engine;
        List<Event> Events = new List<Event>();
        List<Competitor> CurrentCompetitors;

        public EventLoader(Engine Engine)
        {
            InitializeComponent();
            this.Engine = Engine;
            reloadAllEvents();
        }

        private void reloadAllEvents()
        {
            //Events.Clear();
            //Events = Engine.SQL_Controller.GetEvents();

            //for (int i = 0; i < Events.Count; i++)
            //{
            //    EventType CurrentEventType = Events[i].EventType;

            //    switch (CurrentEventType)
            //    {
            //        case EventType.Accuracy:
            //            string EventReady = "Yes";
            //            string EventStage = "Complete";

            //            switch (Events[i].Rules.stage)
            //            {
            //                case 0:
            //                    EventReady = "No";
            //                    EventStage = "Configure Options";
            //                    break;
            //                case 1:
            //                    EventReady = "No";
            //                    EventStage = "Configure Teams";
            //                    break;
            //                case 2:
            //                    EventReady = "Yes";
            //                    EventStage = "Ready";
            //                    break;
            //            }
                        
            //            dataGridViewEvents.Rows.Add(Events[i].EventID, Events[i].Name, Events[i].Date.ToShortDateString(), Events[i].EventType.ToString(), EventReady, EventStage);
            //        break;
            //    }
            //}
        }


        private void dataGridViewEvents_SelectionChanged(object sender, EventArgs e)
        {
            int EventIndex = dataGridViewEvents.SelectedRows[0].Cells[0].RowIndex;
            int EventID = Convert.ToInt16(dataGridViewEvents.SelectedRows[0].Cells[0].Value);
            EventType EventType = (EventType)Enum.Parse(typeof(EventType), dataGridViewEvents.SelectedRows[0].Cells[3].Value.ToString());
            dataGridViewEventProperties.Rows.Clear();
            dataGridViewEventCompetitors.Rows.Clear();

            switch (EventType)
            {
                case EventType.Accuracy:
                    Ruleset.AccuracyRules CurrentRules = (Ruleset.AccuracyRules)Events[EventIndex].Rules;
                    dataGridViewEventProperties.Rows.Add("Rule Preset", CurrentRules.preset);
                    dataGridViewEventProperties.Rows.Add("Competitors Per Team", CurrentRules.competitorsPerTeam);
                    dataGridViewEventProperties.Rows.Add("Scores Used", CurrentRules.scoresUsed);
                    dataGridViewEventProperties.Rows.Add("Max Safe Windspeed", CurrentRules.windspeedSafe);
                    dataGridViewEventProperties.Rows.Add("Max Score", CurrentRules.maxScore);
                    dataGridViewEventProperties.Rows.Add("Rejump Direction Change", CurrentRules.directionChangeFA);
                    dataGridViewEventProperties.Rows.Add("Rejump Speed Over", CurrentRules.windspeedRejump);
                    dataGridViewEventProperties.Rows.Add("Wind data before", CurrentRules.windSecondsPriorLand);
                    dataGridViewEventProperties.Rows.Add("Wind data After", CurrentRules.windSecondsAfterLand);
                    dataGridViewEventProperties.Rows.Add("Wind Speed for Direction Rejumps", CurrentRules.windspeedFA);
                    break;
            }

            CurrentCompetitors = Engine.SQL_Controller.GetCompetitorsForEvent(EventID);

            for (int i = 0; i < CurrentCompetitors.Count; i++)
            {
                dataGridViewEventCompetitors.Rows.Add(CurrentCompetitors[i].ID, CurrentCompetitors[i].name, CurrentCompetitors[i].team);
            }
            
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvents.SelectedRows.Count > 0)
            {
                if (dataGridViewEvents.SelectedRows[0].Cells[0].Value != null)
                {
                    int EventIndex = dataGridViewEvents.SelectedRows[0].Index;
                    EventType SelectedEventType = (EventType)Enum.Parse(typeof(EventType), dataGridViewEvents.SelectedRows[0].Cells[3].Value.ToString());

                    switch (SelectedEventType)
                    {

                        #region Accuracy
                        case EventType.Accuracy:

                            int Stage = (int)Events[EventIndex].Rules.stage;
                            CMS.Accuracy.Accuracy_Event CurrentEvent;

                            switch (Stage)
                            {
                                case 0: // Options Menu
                                    
                                    //Classics_2014.Accuracy.EventAccuracyInit EventTab = Engine.LoadExistingAccuracyEvent((Ruleset.AccuracyRules)Events[EventIndex].Rules,
                                    //Events[EventIndex].Name, Events[EventIndex].Date, CurrentCompetitors);
                                  //  EventTab.Dock = DockStyle.Fill;
                                  //  NewPage.Text = Events[EventIndex].Name + " Setup";
                                   // NewPage.Controls.Add(EventTab);
                                   // CurrentEvent = null;
                                    //TabControl.TabPages.Add(NewPage);
                                    //TabControl.SelectedTab = NewPage;
                                    break;

                                case 1: // Team Selection

                                    CurrentEvent = Engine.LoadExistingAccuracyEvent();
                                    CurrentEvent.Competitors = CurrentCompetitors;
                                    CurrentEvent.Rules = (Ruleset.AccuracyRules)Events[EventIndex].Rules;
                                    CurrentEvent.Name = Events[EventIndex].Name;
                                    CurrentEvent.EventID = Events[EventIndex].EventID;

                                    List<string> SelectedTeams = new List<string>();

                                    for (int i = 0; i < CurrentCompetitors.Count; i++)
                                    {
                                        string CurrentTeam = CurrentCompetitors[i].team;
                                        bool IsUnique = true;

                                        for (int i2 = 0; i2 < SelectedTeams.Count; i2++)
                                        {
                                            if (CurrentTeam == SelectedTeams[i2]) { IsUnique = false; }
                                        }

                                        if (IsUnique == true) { SelectedTeams.Add(CurrentTeam); }
                                    }

                                    CurrentEvent.ActiveTeams = SelectedTeams;
                                    //CurrentEvent.ProceedToEventTeams();
                                    break;

                                case 2: // Ready Event
                                    CurrentEvent = Engine.LoadExistingAccuracyEvent();
                                    List<Team> Teams = Engine.SQL_Controller.GetSTeamsForEvent(Events[EventIndex].EventID);
                                    CurrentEvent.Teams = Teams;
                                    CurrentEvent.Name = Events[EventIndex].Name;
                                    CurrentEvent.EventID = Events[EventIndex].EventID;
                                    CurrentEvent.Rules = (Ruleset.AccuracyRules)Events[EventIndex].Rules;
                                    CurrentEvent.ProceedToEvent();
                                    CurrentEvent.EventTab.LoadExistingEventLandings();
                                    break;
                            }

                            break;
                        #endregion

                    }

                    
                }
            }
            else
            {
                MessageBox.Show("Please select an event to load.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            Engine.mainForm.removeTab((TabPage)this.Parent);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Engine.mainForm.removeTab((TabPage)this.Parent);
            Engine.mainForm.selectTab(0);
        }
    }
}
