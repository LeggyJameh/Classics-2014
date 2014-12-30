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
    partial class TeamManager : UserControl
    {
        Engine Engine;
        List<string> teams;
        List<int> teamMemberCount = new List<int>();
        CompetitorEditor returnCE;
        bool saved = true;

        public TeamManager(Engine engine, List<string> currentTeams, CompetitorEditor competitorEditor)
        {
            this.Engine = engine;
            this.teams = currentTeams;
            this.returnCE = competitorEditor;
            InitializeComponent();
            getMemberCounts();
            refreshGrid();
            saved = true;
        }

        private void getMemberCounts()
        {
            for (int i = 0; i < teams.Count; i++)
            {
                teamMemberCount.Add(Engine.SQL_Controller.GetNumberCompetitorsInTeam(teams[i]));
            }
        }

        private void refreshGrid()
        {
            dataGridTeams.Rows.Clear();
            for (int i = 0; i < teams.Count; i++)
            {
                dataGridTeams.Rows.Add(teams[i], teamMemberCount[i]);
            }
        }

        private void returnValues()
        {
            saved = true;
            returnCE.teamReturn(teams);
        }

        private void inputAddTeam_Click(object sender, EventArgs e)
        {
            string teamName = MessageBoxes.CreateTeam();
            if (teamName != "" && teamName != null)
            {
                bool unique = true;

                for (int i = 0; i < teams.Count; i++)
                {
                    if (teamName == teams[i])
                    {
                        unique = false;
                    }
                }

                if (unique)
                {
                    teams.Add(teamName);
                    teamMemberCount.Add(0);
                    refreshGrid();
                }
                else
                {
                    MessageBox.Show("Team name is already taken!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            saved = false;
        }

        private void inputRemoveTeam_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to remove the selected teams?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dataGridTeams.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < dataGridTeams.SelectedRows.Count; i++)
                    {
                        teams.Remove(dataGridTeams.SelectedRows[i].Cells[0].Value.ToString());
                    }
                    refreshGrid();
                }
                else
                {
                    MessageBox.Show("No rows selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            saved = false;
        }

        private void inputSave_Click(object sender, EventArgs e)
        {
            returnValues();
        }

        private void inputExit_Click(object sender, EventArgs e)
        {
            if (saved)
            {
                Engine.mainForm.selectTab((TabPage)returnCE.Parent);
                Engine.mainForm.removeTab((TabPage)this.Parent);
            }
            else
            {
                DialogResult checker = MessageBox.Show("Save before exiting?", "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

                switch (checker)
                {
                    case DialogResult.Yes:
                        returnValues();
                        Engine.mainForm.selectTab((TabPage)returnCE.Parent);
                        Engine.mainForm.removeTab((TabPage)this.Parent);
                        break;
                    case DialogResult.No:
                        Engine.mainForm.selectTab((TabPage)returnCE.Parent);
                        Engine.mainForm.removeTab((TabPage)this.Parent);
                        break;
                }
            }
        }
    }
}
