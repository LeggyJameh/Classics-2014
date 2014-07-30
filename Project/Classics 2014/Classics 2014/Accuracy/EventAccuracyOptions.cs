using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classics_2014.Accuracy
{
     partial class EventAccuracyOptions : UserControl
    {
        Accuracy_Event Connected_Event;
        TabControl tabControl;
        List<TCompetitor> SelectedCompetitors = new List<TCompetitor>();
        List<TCompetitor> ExistingCompetitors = new List<TCompetitor>();
        List<string> SelectedTeams = new List<string>();
        List<string> ExistingTeams = new List<string>();
        TAccuracyRuleSet Rules = new TAccuracyRuleSet();
        string EventName = "";

        public EventAccuracyOptions(TabControl Main, Accuracy_Event aEvent)
        {
            InitializeComponent();
            tabControl = Main;
            Connected_Event = aEvent;
            PopulateExistingTeams();
            comboBoxRulePreset.SelectedItem = comboBoxRulePreset.Items[0];
            comboBoxScoresUsed.SelectedItem = comboBoxScoresUsed.Items[0];
            comboBoxRejumpAngleChange.SelectedItem = comboBoxRejumpAngleChange.Items[8];
            dateTimePicker.Value = DateTime.Now;
            this.textBoxTeamCreate.KeyDown += new KeyEventHandler(textBoxTeamCreate_KeyDown);
            this.listBoxExistingTeams.KeyDown += new KeyEventHandler(listBoxExistingTeams_KeyDown);
            this.textBoxCompetitorName.KeyDown += new KeyEventHandler(textBoxCompetitorEntry_KeyDown);
            this.textBoxCompetitorNationality.KeyDown += new KeyEventHandler(textBoxCompetitorEntry_KeyDown);
            this.listBoxExistingTeams.KeyDown += new KeyEventHandler(listBoxExistingTeams_KeyDown);
            this.listBoxSelectedTeams.KeyDown += new KeyEventHandler(listBoxSelectedTeams_KeyDown);
            this.dataGridExistingCompetitors.KeyDown += new KeyEventHandler(dataGridExistingCompetitors_KeyDown);
            this.dataGridSelectedCompetitors.KeyDown +=new KeyEventHandler(dataGridSelectedCompetitors_KeyDown);
        }

        public EventAccuracyOptions(TabControl Main, Accuracy_Event aEvent, TAccuracyRuleSet LoadRules, string LoadEventName, DateTime LoadDate, List<TCompetitor> LoadSelectedCompetitors)
        {
            InitializeComponent();
            tabControl = Main;
            Connected_Event = aEvent;
            PopulateExistingTeams();

            Rules = LoadRules;
            EventName = LoadEventName;
            SelectedCompetitors = LoadSelectedCompetitors;
            LoadEvent(LoadDate, LoadRules);

            this.textBoxTeamCreate.KeyDown += new KeyEventHandler(textBoxTeamCreate_KeyDown);
            this.listBoxExistingTeams.KeyDown += new KeyEventHandler(listBoxExistingTeams_KeyDown);
            this.textBoxCompetitorName.KeyDown += new KeyEventHandler(textBoxCompetitorEntry_KeyDown);
            this.textBoxCompetitorNationality.KeyDown += new KeyEventHandler(textBoxCompetitorEntry_KeyDown);
            this.listBoxExistingTeams.KeyDown += new KeyEventHandler(listBoxExistingTeams_KeyDown);
            this.listBoxSelectedTeams.KeyDown += new KeyEventHandler(listBoxSelectedTeams_KeyDown);
            this.dataGridExistingCompetitors.KeyDown += new KeyEventHandler(dataGridExistingCompetitors_KeyDown);
            this.dataGridSelectedCompetitors.KeyDown += new KeyEventHandler(dataGridSelectedCompetitors_KeyDown);
        }

        #region KeyDown functions

        private void textBoxTeamCreate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonTeamCreate.PerformClick();
            }
        }

        private void textBoxCompetitorEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonCompetitorCreate.PerformClick();
            }
        }

        private void listBoxExistingTeams_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                buttonRemoveSelectedTeam.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
                buttonTeamExistingToSelected.PerformClick();
            }
        }

        private void listBoxSelectedTeams_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonTeamSelectedToExisting.PerformClick();
            }
        }

        private void dataGridExistingCompetitors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonCompetitorExistingToSelected.PerformClick();
            }
        }

        private void dataGridSelectedCompetitors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonCompetitorSelectedToExisting.PerformClick();
            }
        }

        #endregion

        #region Checks

        private bool CheckTeamIsValid(string TeamName)
        {
            bool IsValid = true;
            for (int i = 0; i < listBoxExistingTeams.Items.Count; i++)
            {
                if (listBoxExistingTeams.Items[i].ToString() == TeamName) { IsValid = false; }
            }

            for (int i = 0; i < listBoxSelectedTeams.Items.Count; i++)
            {
                if (listBoxSelectedTeams.Items[i].ToString() == TeamName) { IsValid = false; }
            }
            return IsValid;
        }

        private bool CheckCompetitorIsValid(string CompetitorFullName)
        {
            bool IsValid = true;
            for (int i = 0; i < ExistingCompetitors.Count; i++)
            {
                if (ExistingCompetitors[i].ToString() == CompetitorFullName) { IsValid = false; }
            }

            for (int i = 0; i < SelectedCompetitors.Count; i++)
            {
                if (SelectedCompetitors[i].ToString() == CompetitorFullName) { IsValid = false; }
            }
            return IsValid;
        }

        #endregion


        private void LoadEvent(DateTime LoadedDate, TAccuracyRuleSet LoadedRules)
        {
            dateTimePicker.Value = LoadedDate;
            textBoxEventName.Text = EventName;
            comboBoxRulePreset.SelectedValue = LoadedRules.preset;
            numericUpDownCompetitorsPerTeam.Value = LoadedRules.noOfCompetitorsPerTeam;
            numericUpDownCompMaxWind.Value = Convert.ToDecimal(LoadedRules.compHalt);
            numericUpDownMaxScore.Value = LoadedRules.maxScored;
            numericUpDownRejumpWindspeed.Value = Convert.ToDecimal(LoadedRules.windout);
            numericUpDownTimeBeforeLanding.Value = LoadedRules.windSecondsPrior;
            numericUpDownTimeAfterLanding.Value = LoadedRules.windSecondsAfter;
            numericUpDownFinalApproachTime.Value = Convert.ToDecimal(LoadedRules.finalApproachTime);

            if (LoadedRules.allScoresUsed == true)
            {
                comboBoxScoresUsed.SelectedItem = comboBoxScoresUsed.Items[0];
            }
            else
            {
                comboBoxScoresUsed.SelectedItem = comboBoxScoresUsed.Items[1];
            }

            comboBoxRejumpAngleChange.SelectedItem = comboBoxRejumpAngleChange.Items[(LoadedRules.directionOut / 10) - 1];

            for (int i = 0; i < SelectedCompetitors.Count; i++)
            {
                try
                {
                    ExistingTeams.Remove(SelectedCompetitors[i].team);
                    SelectedTeams.Add(SelectedCompetitors[i].team);
                }
                catch
                {
                }
            }
            UpdateTeamSelection();
            UpdateCompetitorGridsFromData();
        }

        private void UpdateTeamSelection()
        {
            comboBoxCompetitorTeam.Items.Clear();
            SelectedTeams.Clear();
            ExistingTeams.Clear();
            for (int i = 0; i < listBoxSelectedTeams.Items.Count; i++)
            {
                comboBoxCompetitorTeam.Items.Add(listBoxSelectedTeams.Items[i].ToString());
            }
            for (int i = 0; i < listBoxExistingTeams.Items.Count; i++)
            {
                ExistingTeams.Add(listBoxExistingTeams.Items[i].ToString());
            }
            for (int i = 0; i < listBoxSelectedTeams.Items.Count; i++)
            {
                SelectedTeams.Add(listBoxSelectedTeams.Items[i].ToString());
            }
        }

        private void RemovedTeamUpdateCompetitors(string Team)
        {
            List<TCompetitor> NewCompetitorList = new List<TCompetitor>();

            for (int i = 0; i < ExistingCompetitors.Count; i++)
            {
                TCompetitor CurrentCompetitor = ExistingCompetitors[i];
                if (CurrentCompetitor.team == Team)
                {
                    CurrentCompetitor.team = "NO TEAM";
                }
                NewCompetitorList.Add(CurrentCompetitor); 
            }
            Connected_Event.SQL_Controller.RemoveTeam(Team);
            ExistingCompetitors = NewCompetitorList;
        }

        private void PopulateExistingCompetitors()
        {
            ExistingCompetitors.Clear();
            for (int i = 0; i < SelectedTeams.Count; i++)
			{
                ExistingCompetitors = Connected_Event.SQL_Controller.GetCompetitorsByTeam(SelectedTeams[i], ExistingCompetitors, SelectedCompetitors);
			}
            UpdateCompetitorGridsFromData();
        }

        private void PopulateExistingTeams()
        {
            ExistingTeams.Clear();
            listBoxExistingTeams.Items.Clear();
            ExistingTeams = Connected_Event.SQL_Controller.GetTeams();
            for (int i = 0; i < ExistingTeams.Count; i++)
            {
                listBoxExistingTeams.Items.Add(ExistingTeams[i]);
            }
        }

        private void RefreshSelectedCompetitors(string Team)
        {  
            for (int i = 0; i < SelectedCompetitors.Count; i++)
            {
                TCompetitor CurrentCompetitor = SelectedCompetitors[i];
                if (CurrentCompetitor.team == Team)
                {
                    SelectedCompetitors.Remove(CurrentCompetitor);
                    i--;
                }
            }
            UpdateCompetitorGridsFromData();
        }

        private void UpdateCompetitorGridsFromData()
        {
            dataGridExistingCompetitors.Rows.Clear();
            dataGridSelectedCompetitors.Rows.Clear();
            for (int i = 0; i < ExistingCompetitors.Count; i++)
            {
                dataGridExistingCompetitors.Rows.Add(ExistingCompetitors[i].ID.ToString(), ExistingCompetitors[i].name, ExistingCompetitors[i].team, ExistingCompetitors[i].nationality);
            }
            for (int i = 0; i < SelectedCompetitors.Count; i++)
            {
                dataGridSelectedCompetitors.Rows.Add(SelectedCompetitors[i].ID.ToString(), SelectedCompetitors[i].name, SelectedCompetitors[i].team, SelectedCompetitors[i].nationality);
            }
            int ModOfCompetitors;
            Math.DivRem(dataGridSelectedCompetitors.Rows.Count - 1, Convert.ToInt16(numericUpDownCompetitorsPerTeam.Value), out ModOfCompetitors);
            if (ModOfCompetitors != 0)
            {
                labelWarning.Visible = true;
            }
            else
            {
                labelWarning.Visible = false;
            }
        }

        private List<TCompetitor> GetSelectedCompetitors(DataGridView Datagrid)
        {
            List<TCompetitor> LocalSelectedCompetitors = new List<TCompetitor>();
            for (int i = 0; i < Datagrid.SelectedRows.Count; i++)
            {
                if (Datagrid.SelectedRows[i].Cells[0].Value != null)
                {
                    TCompetitor CurrentCompetitor = new TCompetitor();
                    CurrentCompetitor.ID = Convert.ToInt16(Datagrid.SelectedRows[i].Cells[0].Value);
                    CurrentCompetitor.name = Datagrid.SelectedRows[i].Cells[1].Value.ToString();
                    CurrentCompetitor.team = Datagrid.SelectedRows[i].Cells[2].Value.ToString();
                    CurrentCompetitor.nationality = Datagrid.SelectedRows[i].Cells[3].Value.ToString();
                    LocalSelectedCompetitors.Add(CurrentCompetitor);
                }
            }
            return LocalSelectedCompetitors;
        }

        public DateTime ReturnDateTimePickerValue()
        {
            return dateTimePicker.Value;
        }

        private bool SaveEvent()
        {
            bool ErrorShown = false;
            try
            {
                EventName = textBoxEventName.Text;
                Rules.preset = comboBoxRulePreset.SelectedItem.ToString();
                Rules.noOfCompetitorsPerTeam = Convert.ToInt16(numericUpDownCompetitorsPerTeam.Value);
                Rules.compHalt = Convert.ToSingle(numericUpDownCompMaxWind.Value);
                Rules.maxScored = Convert.ToInt16(numericUpDownMaxScore.Value);
                Rules.windout = Convert.ToInt16(numericUpDownRejumpWindspeed.Value);
                Rules.windSecondsPrior = Convert.ToInt16(numericUpDownTimeBeforeLanding.Value);
                Rules.windSecondsAfter = Convert.ToInt16(numericUpDownTimeAfterLanding.Value);
                Rules.finalApproachTime = Convert.ToSingle(numericUpDownFinalApproachTime.Value);
                if (Convert.ToInt16(comboBoxScoresUsed.Text.Substring(4)) == Rules.noOfCompetitorsPerTeam)
                {
                    Rules.allScoresUsed = true;
                }
                else
                {
                    Rules.allScoresUsed = false;
                }
                char[] CharactersToTrim = new char[1];
                CharactersToTrim[0] = '°';
                Rules.directionOut = Convert.ToInt16(comboBoxRejumpAngleChange.Text.TrimEnd(CharactersToTrim));

                if ( // Sorry about this godawful bit of code. Best way to do it :/
                EventName != "" &&
                EventName.Length < 255 &&
                Rules.preset != "" &&
                Rules.noOfCompetitorsPerTeam >= 1 &&
                Rules.compHalt >= 1 &&
                Rules.compHalt <= 100 &&
                Rules.maxScored >= 1 &&
                Rules.maxScored <= 100 &&
                Rules.windout >= 1 &&
                Rules.windout <= 100 &&
                Rules.windSecondsPrior >= 1 &&
                Rules.windSecondsPrior <= 300 &&
                Rules.windSecondsAfter >= 1 &&
                Rules.windSecondsAfter <= 300 &&
                Rules.finalApproachTime >= 0.1 &&
                Rules.finalApproachTime <= 100 &&
                Rules.directionOut >= 10 &&
                Rules.directionOut <= 180
                )
                {
                    Connected_Event.SaveEvent(Rules, EventName, dateTimePicker.Value, SelectedCompetitors, SelectedTeams);
                    tabControl.TabPages.Remove(tabControl.SelectedTab);
                    tabControl.SelectedTab = tabControl.TabPages[0];
                    return true;
                }
                else
                {
                    ErrorShown = true;
                    MessageBox.Show("Rules are invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch
            {
                if (ErrorShown == false)
                {
                    MessageBox.Show("Rules are invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return false;
        }

        #region Events

        private void numericUpDownCompetitorsPerTeam_ValueChanged(object sender, EventArgs e)
        {
            comboBoxScoresUsed.Items.Clear();
            comboBoxScoresUsed.Text = "";
            comboBoxScoresUsed.Items.Add("Best " + numericUpDownCompetitorsPerTeam.Value.ToString());
            if (numericUpDownCompetitorsPerTeam.Value != 1)
            {
                comboBoxScoresUsed.Items.Add("Best " + (numericUpDownCompetitorsPerTeam.Value - 1).ToString());
            }
            UpdateCompetitorGridsFromData();
            comboBoxScoresUsed.SelectedItem = comboBoxScoresUsed.Items[0];
        }

        private void buttonCreateTeamShow_Click(object sender, EventArgs e)
        {
            if (groupBoxCreateTeam.Visible == false)
            { groupBoxCreateTeam.Visible = true; }
            else
            { groupBoxCreateTeam.Visible = false; }
        }

        private void buttonTeamCreate_Click(object sender, EventArgs e)
        {
            string TeamName = textBoxTeamCreate.Text;
            if (TeamName != "" && TeamName.Length < 255)
            {
                if (CheckTeamIsValid(TeamName))
                {
                    listBoxExistingTeams.Items.Add(TeamName);
                    textBoxTeamCreate.Text = "";
                }
                else
                {
                    MessageBox.Show("Team already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Team doesn't have a name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemoveSelectedTeam_Click(object sender, EventArgs e)
        {
            try
            {
                string TeamName = listBoxExistingTeams.SelectedItem.ToString();
                if (MessageBox.Show(("Are you sure you wish to permanently remove the selected team " + TeamName + " and unlink the competitors associated with it?"), "Remove Team?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBoxExistingTeams.Items.Remove(listBoxExistingTeams.SelectedItem);
                    RemovedTeamUpdateCompetitors(TeamName);
                    Connected_Event.SQL_Controller.RemoveTeam(TeamName);
                }
            }
            catch
            {
                MessageBox.Show("No team Selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTeamExistingToSelected_Click(object sender, EventArgs e)
        {
            if (listBoxExistingTeams.SelectedItem != null)
            {
                listBoxSelectedTeams.Items.Add(listBoxExistingTeams.SelectedItem);
                listBoxExistingTeams.Items.Remove(listBoxExistingTeams.SelectedItem);
                UpdateTeamSelection();
                PopulateExistingCompetitors();
            }
        }

        private void buttonTeamSelectedToExisting_Click(object sender, EventArgs e)
        {
            if (listBoxSelectedTeams.SelectedItem != null)
            {
                string Team = listBoxSelectedTeams.SelectedItem.ToString();
                listBoxExistingTeams.Items.Add(listBoxSelectedTeams.SelectedItem);
                listBoxSelectedTeams.Items.Remove(listBoxSelectedTeams.SelectedItem);
                UpdateTeamSelection();
                RefreshSelectedCompetitors(Team);
                PopulateExistingCompetitors();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBoxCreateTeam.Visible = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to cancel? Any unsaved changes you have made will be lost.", "Return to menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tabControl.TabPages.Remove(tabControl.SelectedTab);
                tabControl.SelectedTab = tabControl.TabPages[0];
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveEvent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (SaveEvent() == true && Rules.noOfCompetitorsPerTeam > 1)
            {
                Connected_Event.ProceedToEventTeams();
            }
            else
            {
                Connected_Event.TeamsSetup = true;
                //TODO: Go straight to event, all competitors are not in teams.
            }
        }

        private void buttonCompetitorCreate_Click(object sender, EventArgs e)
        {
            if (textBoxCompetitorName.Text != "" && textBoxCompetitorName.Text.Length < 255)
            {
                if (textBoxCompetitorNationality.Text != "" && textBoxCompetitorNationality.Text.Length < 255)
                {
                    if (comboBoxCompetitorTeam.SelectedItem != null)
                    {
                        TCompetitor CurrentCompetitor = new TCompetitor();
                        CurrentCompetitor.name = textBoxCompetitorName.Text;
                        CurrentCompetitor.nationality = textBoxCompetitorNationality.Text;
                        CurrentCompetitor.team = comboBoxCompetitorTeam.Text;

                        if (CheckCompetitorIsValid(CurrentCompetitor.name))
                        {
                            if (!Connected_Event.SQL_Controller.DoesCompetitorExist(CurrentCompetitor))
                            {
                                Connected_Event.SQL_Controller.CreateCompetitor(CurrentCompetitor);
                                CurrentCompetitor.ID = Connected_Event.SQL_Controller.GetLastInsertKey();
                                ExistingCompetitors.Add(CurrentCompetitor);
                                textBoxCompetitorName.Text = "";
                                UpdateCompetitorGridsFromData();
                            }
                            #region Error Messages
                            else
                            {
                                MessageBox.Show("Duplicate Competitor already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Competitors must have unique names.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Competitor doesn't have a team.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Competitor doesn't have a nationality.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Competitor doesn't have a name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                        #endregion
        }
                        
        private void buttonCompetitorExistingToSelected_Click(object sender, EventArgs e)
        {
            if (dataGridExistingCompetitors.SelectedCells != null)
            {
                List<TCompetitor> LocalSelectedCompetitors = GetSelectedCompetitors(dataGridExistingCompetitors);
                for (int i = 0; i < LocalSelectedCompetitors.Count; i++)
                {
                    ExistingCompetitors.Remove(LocalSelectedCompetitors[i]);
                    SelectedCompetitors.Add(LocalSelectedCompetitors[i]);
                }
                UpdateCompetitorGridsFromData();
            }
        }

        private void buttonCompetitorSelectedToExisting_Click(object sender, EventArgs e)
        {
            if (dataGridSelectedCompetitors.SelectedCells != null)
            {
                List<TCompetitor> LocalExistingCompetitors = GetSelectedCompetitors(dataGridSelectedCompetitors);
                for (int i = 0; i < LocalExistingCompetitors.Count; i++)
                {
                    SelectedCompetitors.Remove(LocalExistingCompetitors[i]);
                    ExistingCompetitors.Add(LocalExistingCompetitors[i]);
                }
                UpdateCompetitorGridsFromData();
            }
        }

        private void buttonCreateCompetitorShow_Click(object sender, EventArgs e)
        {
            if (groupBoxCreateCompetitor.Visible == false)
            { groupBoxCreateCompetitor.Visible = true; }
            else
            { groupBoxCreateCompetitor.Visible = false; }
        }

        private void buttonRemoveCompetitor_Click(object sender, EventArgs e)
        {
            try
            {
                List<TCompetitor> LocalSelectedCompetitors = GetSelectedCompetitors(dataGridExistingCompetitors);
                if (MessageBox.Show("Are you sure you wish to permanently remove the selected competitors?", "Remove Competitor?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < LocalSelectedCompetitors.Count; i++)
                    {
                        ExistingCompetitors.Remove(LocalSelectedCompetitors[i]);
                        Connected_Event.SQL_Controller.RemoveCompetitor(LocalSelectedCompetitors[i].ID);
                    }
                    UpdateCompetitorGridsFromData();
                }
            }
            catch
            {
                MessageBox.Show("No Competitor Selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCompetitorCreateClose_Click(object sender, EventArgs e)
        {
            groupBoxCreateCompetitor.Visible = false;
        }

        #endregion
    }
}
