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

        public EventAccuracyOptions(TabControl Main, Accuracy_Event aEvent)
        {
            InitializeComponent();
            tabControl = Main;
            Connected_Event = aEvent;
            PopulateExistingTeams();
            #region KeyDown Functions
            this.textBoxTeamCreate.KeyDown += new KeyEventHandler(textBoxTeamCreate_KeyDown);
            this.listBoxExistingTeams.KeyDown += new KeyEventHandler(listBoxExistingTeams_KeyDown);
            this.textBoxCompetitorName.KeyDown += new KeyEventHandler(textBoxCompetitorEntry_KeyDown);
            this.textBoxCompetitorNationality.KeyDown += new KeyEventHandler(textBoxCompetitorEntry_KeyDown);
            this.listBoxExistingTeams.KeyDown += new KeyEventHandler(listBoxExistingTeams_KeyDown);
            this.listBoxSelectedTeams.KeyDown += new KeyEventHandler(listBoxSelectedTeams_KeyDown);
            this.dataGridExistingCompetitors.KeyDown += new KeyEventHandler(dataGridExistingCompetitors_KeyDown);
            this.dataGridSelectedCompetitors.KeyDown +=new KeyEventHandler(dataGridSelectedCompetitors_KeyDown);
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
        }

        private List<TCompetitor> GetSelectedCompetitors(DataGridView Datagrid)
        {
            List<TCompetitor> LocalSelectedCompetitors = new List<TCompetitor>();
            for (int i = 0; i < Datagrid.SelectedRows.Count; i++)
            {
                TCompetitor CurrentCompetitor = new TCompetitor();
                CurrentCompetitor.ID = Convert.ToInt16(Datagrid[0, i].Value);
                CurrentCompetitor.name = Datagrid[1, i].Value.ToString();
                CurrentCompetitor.team = Datagrid[2, i].Value.ToString();
                CurrentCompetitor.nationality = Datagrid[3, i].Value.ToString();
                LocalSelectedCompetitors.Add(CurrentCompetitor);
            }
            return LocalSelectedCompetitors;
        }

        #region Events

        private void numericUpDownCompetitorsPerTeam_ValueChanged(object sender, EventArgs e)
        {
            comboBoxScoresUsed.Items.Clear();
            comboBoxScoresUsed.Text = "";
            comboBoxScoresUsed.Items.Add("Top " + numericUpDownCompetitorsPerTeam.Value.ToString());
            if (numericUpDownCompetitorsPerTeam.Value != 1)
            {
                comboBoxScoresUsed.Items.Add("Top " + (numericUpDownCompetitorsPerTeam.Value - 1).ToString());
            }
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
            //TODO: Save the bloody event..
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //TODO: Start the event..
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


        private void buttonCompetitorModifyTeam_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonCompetitorModifyNationality_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
