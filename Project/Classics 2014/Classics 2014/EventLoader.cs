using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classics_2014
{
    partial class EventLoader : UserControl
    {
        Engine Engine;
        List<TMySQLEventReturn> Events = new List<TMySQLEventReturn>();
        List<Rulesets.Ruleset> EventRules = new List<Rulesets.Ruleset>();
        TabControl TabControl;
        List<TCompetitor> CurrentCompetitors;

        public EventLoader(Engine Engine, TabControl TabControl)
        {
            InitializeComponent();
            this.Engine = Engine;
            this.TabControl = TabControl;
            reloadAllEvents();
        }

        private void reloadAllEvents()
        {
            Events.Clear();
            EventRules.Clear();
            Events = Engine.SQL_Controller.GetEvents();

            for (int i = 0; i < Events.Count; i++)
            {
                EventType CurrentEventType = Events[i].Type;

                switch (CurrentEventType)
                {
                    case EventType.Accuracy:
                        Rulesets.AccuracyRuleset Rules = GlobalFunctions.ConvertByteArrayToAccuracyRuleSet(Events[i].Options);
                        EventRules.Add(Rules);
                        string EventReady = "Yes";
                        string EventStage = "Complete";

                        switch (Rules.Stage)
                        {
                            case 0:
                                EventReady = "No";
                                EventStage = "Configure Options";
                                break;
                            case 1:
                                EventReady = "No";
                                EventStage = "Configure Teams";
                                break;
                            case 2:
                                EventReady = "Yes";
                                EventStage = "Ready";
                                break;
                        }
                        
                        dataGridViewEvents.Rows.Add(Events[i].ID, Events[i].Name, Events[i].Date.ToShortDateString(), Events[i].Type.ToString(), EventReady, EventStage);
                    break;
                }
            }
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
                    Rulesets.AccuracyRuleset CurrentRules = (Rulesets.AccuracyRuleset)EventRules[EventIndex];
                    dataGridViewEventProperties.Rows.Add("Rule Preset", CurrentRules.preset);
                    dataGridViewEventProperties.Rows.Add("Competitors Per Team", CurrentRules.noOfCompetitorsPerTeam);
                    dataGridViewEventProperties.Rows.Add("Scores Used", CurrentRules.ScoresUsed);
                    dataGridViewEventProperties.Rows.Add("Max Safe Windspeed", CurrentRules.compHalt);
                    dataGridViewEventProperties.Rows.Add("Max Score", CurrentRules.maxScored);
                    dataGridViewEventProperties.Rows.Add("Rejump Direction Change", CurrentRules.directionOut);
                    dataGridViewEventProperties.Rows.Add("Rejump Speed Over", CurrentRules.windout);
                    dataGridViewEventProperties.Rows.Add("Wind data before", CurrentRules.windSecondsPrior);
                    dataGridViewEventProperties.Rows.Add("Wind data After", CurrentRules.windSecondsAfter);
                    dataGridViewEventProperties.Rows.Add("Final approach period", CurrentRules.finalApproachTime);
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

                    TabPage NewPage = new TabPage();

                    switch (SelectedEventType)
                    {

                        #region Accuracy
                        case EventType.Accuracy:

                            int Stage = EventRules[EventIndex].Stage;
                            Classics_2014.Accuracy.Accuracy_Event CurrentEvent;

                            switch (Stage)
                            {
                                case 0: // Options Menu
                                    
                                    Classics_2014.Accuracy.EventAccuracyOptions EventTab = Engine.LoadExistingAccuracyEvent((Rulesets.AccuracyRuleset)EventRules[EventIndex],
                                    Events[EventIndex].Name, Events[EventIndex].Date, CurrentCompetitors);
                                    EventTab.Dock = DockStyle.Fill;
                                    NewPage.Text = Events[EventIndex].Name + " Setup";
                                    NewPage.Controls.Add(EventTab);
                                    CurrentEvent = null;
                                    TabControl.TabPages.Add(NewPage);
                                    TabControl.SelectedTab = NewPage;
                                    break;

                                case 1: // Team Selection

                                    CurrentEvent = Engine.LoadExistingAccuracyEvent();
                                    CurrentEvent.Competitors = CurrentCompetitors;
                                    CurrentEvent.ruleSet = (Rulesets.AccuracyRuleset)EventRules[EventIndex];
                                    CurrentEvent.Name = Events[EventIndex].Name;
                                    CurrentEvent.EventID = Events[EventIndex].ID;

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
                                    CurrentEvent.ProceedToEventTeams();
                                    NewPage.Text = Events[EventIndex].Name + " Team Config";
                                    TabControl.TabPages.Add(NewPage);
                                    TabControl.SelectedTab = NewPage;
                                    break;

                                case 2: // Ready Event
                                    CurrentEvent = Engine.LoadExistingAccuracyEvent();
                                    MySqlTeamsReturn Teams = Engine.SQL_Controller.GetTeamsForEvent(Events[EventIndex].ID);
                                    CurrentEvent.TeamNames = Teams.TeamNames;
                                    CurrentEvent.Teams = Teams.Teams;
                                    CurrentEvent.Name = Events[EventIndex].Name;
                                    CurrentEvent.EventID = Events[EventIndex].ID;
                                    CurrentEvent.ruleSet = (Rulesets.AccuracyRuleset)EventRules[EventIndex];
                                    NewPage = null;
                                    CurrentEvent.TabControl = TabControl;
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
            TabControl.TabPages.Remove((TabPage)this.Parent);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            TabControl.TabPages.Remove(TabControl.SelectedTab);
            TabControl.SelectedTab = TabControl.TabPages[0];
        }
    }
}
