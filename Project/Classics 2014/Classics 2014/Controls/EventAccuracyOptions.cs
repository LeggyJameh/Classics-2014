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
        public EventAccuracyOptions(TabControl Main, Serial_Controller Serial_Controller, SQL_Controller Sql_Controller)
        {
            InitializeComponent();
            tabControl = Main;
            //TODO: Add MySQL Team list query here, to enter into existingteams list.
            this.textBoxTeamCreate.KeyDown += new KeyEventHandler(textBoxTeamCreate_KeyDown);
            this.listBoxExistingTeams.KeyDown += new KeyEventHandler(listBoxExistingTeams_KeyDown);
        }

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
                if (MessageBox.Show(("Are you sure you wish to remove the selected team " + TeamName), "Remove Team?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBoxExistingTeams.Items.Remove(listBoxExistingTeams.SelectedItem);
                    //TODO: Add MySQL removeTeam query here.
                }
            }
            catch
            {
                MessageBox.Show("No team Selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void buttonTeamExistingToSelected_Click(object sender, EventArgs e)
        {
            listBoxSelectedTeams.Items.Add(listBoxExistingTeams.SelectedItem);
            listBoxExistingTeams.Items.Remove(listBoxExistingTeams.SelectedItem);
        }

        private void buttonTeamSelectedToExisting_Click(object sender, EventArgs e)
        {
            listBoxExistingTeams.Items.Add(listBoxSelectedTeams.SelectedItem);
            listBoxSelectedTeams.Items.Remove(listBoxSelectedTeams.SelectedItem);
        }

        private void textBoxTeamCreate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonTeamCreate.PerformClick();
            }
        }

        private void listBoxExistingTeams_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                buttonRemoveSelectedTeam.PerformClick();
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
    }
}
