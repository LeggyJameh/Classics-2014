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
        List<Competitor> SelectedCompetitors = new List<Competitor>();
        List<Competitor> ExistingCompetitors = new List<Competitor>();
        List<string> SelectedTeams = new List<string>();
        List<string> ExistingTeams = new List<string>();
        Rulesets.AccuracyRuleset Rules = new Rulesets.AccuracyRuleset();
        string EventName = "";
        #region Structs
        Rulesets.AccuracyRuleset Fai = new Rulesets.AccuracyRuleset
        {
            maxScored = 16,
            noOfCompetitorsPerTeam = 5,
            preset = "FAI",
        };
        Rulesets.AccuracyRuleset CISM = new Rulesets.AccuracyRuleset
        {
            maxScored = 20,
            noOfCompetitorsPerTeam = 5,
            preset = "C.I.S.M",
        };
        Rulesets.AccuracyRuleset CISMJunior = new Rulesets.AccuracyRuleset
        {
            maxScored = 20,
            noOfCompetitorsPerTeam = 1,
            preset = "C.I.S.M Junior",
        };
        Rulesets.AccuracyRuleset NationalSeniors = new Rulesets.AccuracyRuleset
        {
            maxScored = 20,
            preset = "National Seniors",
        };
        Rulesets.AccuracyRuleset NationalPOPS = new Rulesets.AccuracyRuleset
        {
            maxScored = 100,
            preset = "National POPS",
        };
        Rulesets.AccuracyRuleset NationalIntermediates = new Rulesets.AccuracyRuleset
        {
            maxScored = 500,
            noOfCompetitorsPerTeam = 1,
            preset = "National Intermediates",
        };
        Rulesets.AccuracyRuleset NationalJuniors = new Rulesets.AccuracyRuleset
        {
            maxScored = 2500,
            noOfCompetitorsPerTeam = 1,
            preset = "National Juniors",
        };
        Rulesets.AccuracyRuleset Paragliding = new Rulesets.AccuracyRuleset
        {
            maxScored = 2500,
            preset = "Paragliding",
        };
        #endregion
        public EventAccuracyOptions(TabControl Main, Accuracy_Event aEvent)
        {
            InitializeComponent();
            tabControl = Main;
            Connected_Event = aEvent;
            PopulateExistingTeams();
            int NoOfPreviousEvents = Connected_Event.SQL_Controller.GetNoOfEventsByTypeOnDay(DateTime.Today, EventType.Accuracy);
            textBoxEventName.Text = "Accuracy Event " + (NoOfPreviousEvents + 1).ToString() + " " + DateTime.Today.ToShortDateString();
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
            numericUpDownDirectionChangePrior.Maximum = numericUpDownTimeBeforeLanding.Value;
            numericUpDownDirectionChangeAfter.Maximum = numericUpDownTimeAfterLanding.Value;
            numericUpDownWindSpeedNeededForDirectionRule.Maximum = numericUpDownRejumpWindspeed.Value;
        }

        public EventAccuracyOptions(TabControl Main, Accuracy_Event aEvent, Rulesets.AccuracyRuleset LoadRules, string LoadEventName, DateTime LoadDate, List<Competitor> LoadSelectedCompetitors)
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

        #region Load Specific



        private void LoadEvent(DateTime LoadedDate, Rulesets.AccuracyRuleset LoadedRules)
        {
            dateTimePicker.Value = LoadedDate;
            textBoxEventName.Text = EventName;
            comboBoxRulePreset.SelectedItem = LoadedRules.preset;
            numericUpDownCompetitorsPerTeam.Value = LoadedRules.noOfCompetitorsPerTeam;
            numericUpDownCompMaxWind.Value = Convert.ToDecimal(LoadedRules.compHalt);
            numericUpDownMaxScore.Value = LoadedRules.maxScored;
            numericUpDownRejumpWindspeed.Value = Convert.ToDecimal(LoadedRules.windout);
            numericUpDownTimeBeforeLanding.Value = LoadedRules.windSecondsPrior;
            numericUpDownTimeAfterLanding.Value = LoadedRules.windSecondsAfter;
            numericUpDownWindSpeedNeededForDirectionRule.Value = Convert.ToDecimal(LoadedRules.windSpeedNeededForDirectionChangeRujumps);
            comboBoxScoresUsed.SelectedItem = comboBoxScoresUsed.SelectedValue = LoadedRules.ScoresUsed;

            comboBoxRejumpAngleChange.SelectedItem = comboBoxRejumpAngleChange.Items[(LoadedRules.directionOut / 10) - 1];

            for (int i = 0; i < SelectedCompetitors.Count; i++)
            {
                if (ExistingTeams.Remove(SelectedCompetitors[i].team))
                {
                    SelectedTeams.Add(SelectedCompetitors[i].team);
                }
                
            }

            PopulateExistingCompetitors();

            for (int i = 0; i < SelectedCompetitors.Count; i++)
            {
                ExistingCompetitors.Remove(SelectedCompetitors[i]);
            }

            UpdateTeamsFromLists();
            UpdateCompetitorGridsFromData();
        }

        private void UpdateTeamsFromLists()
        {
            listBoxSelectedTeams.Items.Clear();
            listBoxExistingTeams.Items.Clear();
            for (int i = 0; i < ExistingTeams.Count; i++)
            {
                listBoxExistingTeams.Items.Add(ExistingTeams[i]);
            }
            for (int i = 0; i < SelectedTeams.Count; i++)
            {
                listBoxSelectedTeams.Items.Add(SelectedTeams[i]);
            }
        }

        #endregion

        

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
            List<Competitor> NewCompetitorList = new List<Competitor>();

            for (int i = 0; i < ExistingCompetitors.Count; i++)
            {
                Competitor CurrentCompetitor = ExistingCompetitors[i];
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
                Competitor CurrentCompetitor = SelectedCompetitors[i];
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
            Math.DivRem(dataGridSelectedCompetitors.Rows.Count, Convert.ToInt16(numericUpDownCompetitorsPerTeam.Value), out ModOfCompetitors);
            if (ModOfCompetitors != 0)
            {
                labelWarning.Visible = true;
            }
            else
            {
                labelWarning.Visible = false;
            }
        }

        private List<Competitor> GetSelectedCompetitors(DataGridView Datagrid)
        {
            List<Competitor> LocalSelectedCompetitors = new List<Competitor>();
            for (int i = 0; i < Datagrid.SelectedRows.Count; i++)
            {
                if (Datagrid.SelectedRows[i].Cells[0].Value != null)
                {
                    Competitor CurrentCompetitor = new Competitor();
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

        private bool CheckOneCompetitorPerTeam()
        {
            if (numericUpDownCompetitorsPerTeam.Value == 1)
            {
                if (MessageBox.Show("Are you sure you wish to start a singles event?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private bool SaveEvent(int Stage)
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
                Rules.windSpeedNeededForDirectionChangeRujumps = Convert.ToSingle(numericUpDownWindSpeedNeededForDirectionRule.Value);
                Rules.Stage = Stage;
                Rules.ScoresUsed = comboBoxScoresUsed.Text;
                Rules.timeCheckAngleChangePrior = Convert.ToInt16(numericUpDownDirectionChangePrior.Value);
                Rules.timeCheckAngleChangeAfter = Convert.ToInt16(numericUpDownDirectionChangeAfter.Value);

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
            if (numericUpDownCompetitorsPerTeam.Value > 6)
            {
                comboBoxScoresUsed.Items.Add("Best 5");
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
            SaveEvent(0);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (SelectedCompetitors.Count >= 1)
            {
                if (CheckOneCompetitorPerTeam())
                {
                    if (SaveEvent(1) == true)
                    {
                        if (Rules.noOfCompetitorsPerTeam > 1)
                        {
                            Connected_Event.ProceedToEventTeams();
                        }
                        else
                        {
                            List<Team> SinglesTeam = new List<Team>();
                            Team newTeam = new Team();
                            newTeam.Name = "N/A";
                            SinglesTeam.Add(newTeam);
                            List<EventCompetitor> ConvertedCompetitors = GlobalFunctions.ConvertCompetitorsForEvent(SelectedCompetitors);
                            for (int i = 0; i < ConvertedCompetitors.Count; i++)
                            {
                                SinglesTeam[0].Competitors.Add(ConvertedCompetitors[i]);   
                            }

                            Connected_Event.Teams = SinglesTeam;
                            Connected_Event.SQL_Controller.SaveTeams(Connected_Event.EventID, Connected_Event.Teams);
                            Connected_Event.ruleSet.Stage = 1;
                            Connected_Event.ProceedToEvent();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select competitors.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        Competitor CurrentCompetitor = new Competitor();
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
                List<Competitor> LocalSelectedCompetitors = GetSelectedCompetitors(dataGridExistingCompetitors);
                for (int i = 0; i < LocalSelectedCompetitors.Count; i++)
                {
                    for (int i2 = 0; i2 < ExistingCompetitors.Count; i2++)
                    {
                        if (ExistingCompetitors[i2].ID == LocalSelectedCompetitors[i].ID)
                        {
                            ExistingCompetitors.RemoveAt(i2);
                        }
                    }
                    SelectedCompetitors.Add(LocalSelectedCompetitors[i]);
                }
                UpdateCompetitorGridsFromData();
            }
        }

        private void buttonCompetitorSelectedToExisting_Click(object sender, EventArgs e)
        {
            if (dataGridSelectedCompetitors.SelectedCells != null)
            {
                List<Competitor> LocalExistingCompetitors = GetSelectedCompetitors(dataGridSelectedCompetitors);
                for (int i = 0; i < LocalExistingCompetitors.Count; i++)
                {
                    for (int i2 = 0; i2 < SelectedCompetitors.Count; i2++)
                    {
                        if (SelectedCompetitors[i2].ID == LocalExistingCompetitors[i].ID)
                        {
                            SelectedCompetitors.RemoveAt(i2);
                        }
                    }
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
                List<Competitor> LocalSelectedCompetitors = GetSelectedCompetitors(dataGridExistingCompetitors);
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

        private void numericUpDownRejumpWindspeed_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownCompMaxWind.Minimum = (numericUpDownRejumpWindspeed.Value + Convert.ToDecimal(0.5));
            numericUpDownWindSpeedNeededForDirectionRule.Maximum = numericUpDownRejumpWindspeed.Value;
        }

        #endregion

        private void comboBoxRulePreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxRulePreset.SelectedItem.ToString())
            {
                case"Custom":
                    numericUpDownMaxScore.Enabled = true;
                    numericUpDownCompetitorsPerTeam.Enabled = true;
                    break;
                case"FAI":
                    numericUpDownMaxScore.Value = Fai.maxScored;
                    numericUpDownCompetitorsPerTeam.Value = Fai.noOfCompetitorsPerTeam;
                    numericUpDownMaxScore.Enabled = false;
                    numericUpDownCompetitorsPerTeam.Enabled = false;
                    break;
                case "C.I.S.M Senior":
                    numericUpDownMaxScore.Value = CISM.maxScored;
                    numericUpDownCompetitorsPerTeam.Value = CISM.noOfCompetitorsPerTeam;
                    numericUpDownMaxScore.Enabled = false;
                    numericUpDownCompetitorsPerTeam.Enabled = false;
                    break;
                case "C.I.S.M Junior":
                    numericUpDownMaxScore.Value = CISMJunior.maxScored;
                    numericUpDownCompetitorsPerTeam.Value = CISMJunior.noOfCompetitorsPerTeam;
                    numericUpDownMaxScore.Enabled = false;
                    numericUpDownCompetitorsPerTeam.Enabled = false;
                    break;
                case "National Senior":
                    numericUpDownMaxScore.Value = CISMJunior.maxScored;
                    numericUpDownMaxScore.Enabled = false;
                    numericUpDownCompetitorsPerTeam.Enabled = true;
                    break;
                case "National Pops":
                    numericUpDownMaxScore.Value = NationalPOPS.maxScored;
                    numericUpDownMaxScore.Enabled = false;
                    numericUpDownCompetitorsPerTeam.Enabled = true;
                    break;
                case "National Intermediate ":
                    numericUpDownMaxScore.Value = NationalIntermediates.maxScored;
                    numericUpDownCompetitorsPerTeam.Value = NationalIntermediates.noOfCompetitorsPerTeam;
                    numericUpDownMaxScore.Enabled = false;
                    numericUpDownCompetitorsPerTeam.Enabled = true;
                    break;
                case "National Junior":
                    numericUpDownMaxScore.Value = NationalJuniors.maxScored;
                    numericUpDownCompetitorsPerTeam.Value = NationalJuniors.noOfCompetitorsPerTeam;
                    numericUpDownMaxScore.Enabled = false;
                    numericUpDownCompetitorsPerTeam.Enabled = true;
                    break;
                case "Paragliding":
                     numericUpDownMaxScore.Value = Paragliding.maxScored;
                    numericUpDownMaxScore.Enabled = false;
                    numericUpDownCompetitorsPerTeam.Enabled = true;
                    break;
            }
        }

        private void numericUpDownTimeBeforeLanding_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownTimeBeforeLanding.Value < numericUpDownDirectionChangePrior.Value)
            {
                numericUpDownDirectionChangePrior.Value = numericUpDownTimeBeforeLanding.Value;
            }
            numericUpDownDirectionChangePrior.Maximum = numericUpDownTimeBeforeLanding.Value;
        }

        private void numericUpDownTimeAfterLanding_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownTimeAfterLanding.Value < numericUpDownDirectionChangeAfter.Value)
            {
                numericUpDownDirectionChangeAfter.Value = numericUpDownTimeAfterLanding.Value;
            }
            numericUpDownDirectionChangeAfter.Maximum = numericUpDownTimeAfterLanding.Value;
        }

    }
}
