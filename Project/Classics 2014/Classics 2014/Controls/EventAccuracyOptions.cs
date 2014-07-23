using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classics_2014.Controls
{
    public partial class EventAccuracyOptions : UserControl
    {
        TabControl tabControl;
        List<TCompetitor> SelectedCompetitors = new List<TCompetitor>();
        List<TCompetitor> ExistingCompetitors = new List<TCompetitor>();
        List<string> SelectedTeams = new List<string>();
        List<string> ExistingTeams = new List<string>();
        SQL_Controller MySQL_Controller;

        public EventAccuracyOptions(TabControl Main, SQL_Controller Controller)
        {
            InitializeComponent();
            tabControl = Main;
            MySQL_Controller = Controller;
            //TODO: Add MySQL Team list query here, to enter into existingteams list.
            #region KeyDown Functions
            this.textBoxTeamCreate.KeyDown += new KeyEventHandler(textBoxTeamCreate_KeyDown);
            this.listBoxExistingTeams.KeyDown += new KeyEventHandler(listBoxExistingTeams_KeyDown);
            this.textBoxCompetitorName.KeyDown += new KeyEventHandler(textBoxCompetitorEntry_KeyDown);
            this.textBoxCompetitorNationality.KeyDown += new KeyEventHandler(textBoxCompetitorEntry_KeyDown);
            this.listBoxExistingTeams.KeyDown += new KeyEventHandler(listBoxExistingTeams_KeyDown);
            this.listBoxSelectedTeams.KeyDown += new KeyEventHandler(listBoxSelectedTeams_KeyDown);
            this.listBoxExistingCompetitors.KeyDown += new KeyEventHandler(listBoxExistingCompetitors_KeyDown);
            this.listBoxSelectedCompetitors.KeyDown +=new KeyEventHandler(listBoxSelectedCompetitors_KeyDown);
        }

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

        private void listBoxExistingCompetitors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonCompetitorExistingToSelected.PerformClick();
            }
        }

        private void listBoxSelectedCompetitors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonCompetitorSelectedToExisting.PerformClick();
            }
        }

        #endregion

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
            for (int i = 0; i < listBoxExistingCompetitors.Items.Count; i++)
            {
                if (listBoxExistingCompetitors.Items[i].ToString() == CompetitorFullName) { IsValid = false; }
            }

            for (int i = 0; i < listBoxSelectedCompetitors.Items.Count; i++)
            {
                if (listBoxSelectedCompetitors.Items[i].ToString() == CompetitorFullName) { IsValid = false; }
            }
            return IsValid;
        }

        private void UpdateTeamSelection()
        {
            comboBoxCompetitorTeam.Items.Clear();
            for (int i = 0; i < listBoxSelectedTeams.Items.Count; i++)
            {
                comboBoxCompetitorTeam.Items.Add(listBoxSelectedTeams.Items[i].ToString());
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
            ExistingCompetitors = NewCompetitorList;
        }

        private void MovedTeamFromSelectedToExisting(string TeamName)
        {
        }

        private void PopulateExistingCompetitors()
        {
            for (int i = 0; i < ExistingTeams.Count; i++)
			{
                ExistingCompetitors = MySQL_Controller.GetCompetitorsByTeam(ExistingTeams[i], ExistingCompetitors);
			}
        }

        private void PopulateExistingTeams()
        {
            ExistingTeams.Clear();
            ExistingTeams = MySQL_Controller.GetTeams();
        }

        #region Events

        private void numericUpDownCompetitorsPerTeam_ValueChanged(object sender, EventArgs e)
        {
            comboBoxScoresUsed.Items.Clear();
            comboBoxScoresUsed.Items.Add("Top " + numericUpDownCompetitorsPerTeam.Value.ToString());
            comboBoxScoresUsed.Items.Add("Top " + (numericUpDownCompetitorsPerTeam.Value - 1).ToString());
            comboBoxScoresUsed.SelectedItem = 0;
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
            if (TeamName != "")
            {
                if (CheckTeamIsValid(TeamName))
                {
                    //TODO: Add MySQL addTeam query here.
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
                if (MessageBox.Show(("Are you sure you wish to remove the selected team " + TeamName + " and all the competitors associated with it?"), "Remove Team?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBoxExistingTeams.Items.Remove(listBoxExistingTeams.SelectedItem);
                    RemovedTeamUpdateCompetitors(TeamName);
                    MySQL_Controller.RemoveTeam(TeamName);
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
            }
        }

        private void buttonTeamSelectedToExisting_Click(object sender, EventArgs e)
        {
            if (listBoxSelectedTeams.SelectedItem != null)
            {
                listBoxExistingTeams.Items.Add(listBoxSelectedTeams.SelectedItem);
                listBoxSelectedTeams.Items.Remove(listBoxSelectedTeams.SelectedItem);
                UpdateTeamSelection();
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
            //TODO: Save the bloody event..
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //TODO: Start the event..
        }

        private void buttonCompetitorCreate_Click(object sender, EventArgs e)
        {
            if (textBoxCompetitorName.Text != "")
            {
                if (textBoxCompetitorNationality.Text != "")
                {
                    if (comboBoxCompetitorTeam.SelectedItem != null)
                    {
                        TCompetitor CurrentCompetitor = new TCompetitor();
                        CurrentCompetitor.name = textBoxCompetitorName.Text;
                        CurrentCompetitor.nationality = textBoxCompetitorNationality.Text;
                        CurrentCompetitor.team = comboBoxCompetitorTeam.Text;

                        if (CheckCompetitorIsValid(CurrentCompetitor.name))
                        {
                            if (MySQL_Controller.DoesCompetitorExist(CurrentCompetitor))
                            {
                                MySQL_Controller.CreateCompetitor(CurrentCompetitor);
                                CurrentCompetitor.ID = MySQL_Controller.GetLastInsertKey();
                                listBoxExistingCompetitors.Items.Add(CurrentCompetitor.name);
                                ExistingCompetitors.Add(CurrentCompetitor);
                                textBoxCompetitorName.Text = "";
                            }
                        }
                        #region Error Messages
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
            if (listBoxExistingCompetitors.SelectedItem != null)
            {
                listBoxSelectedCompetitors.Items.Add(listBoxExistingCompetitors.SelectedItem);
                listBoxExistingCompetitors.Items.Remove(listBoxExistingCompetitors.SelectedItem);
            }
        }

        private void buttonCompetitorSelectedToExisting_Click(object sender, EventArgs e)
        {
            if (listBoxSelectedCompetitors.SelectedItem != null)
            {
                listBoxExistingCompetitors.Items.Add(listBoxSelectedCompetitors.SelectedItem);
                listBoxSelectedCompetitors.Items.Remove(listBoxSelectedCompetitors.SelectedItem);
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
                string CompetitorName = listBoxExistingCompetitors.SelectedItem.ToString();
                if (MessageBox.Show(("Are you sure you wish to remove the selected competitor " + CompetitorName), "Remove Competitor?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBoxExistingCompetitors.Items.Remove(listBoxExistingCompetitors.SelectedItem);
                    //TODO: Add MySQL removeCompetitor query here.
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
