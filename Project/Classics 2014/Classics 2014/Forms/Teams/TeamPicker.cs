using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS.Forms
{
    partial class TeamPicker : UserControl
    {
        #region Variables and such like
        private Event Connected_Event;
        public List<Team> teams;
        public List<Competitor> unassignedCompetitors;
        private Teams.TeamPickAdvanced teamPickAdvanced;
        #endregion

        public TeamPicker(Event connected_event)
        {
            this.Connected_Event = connected_event;
            teams = new List<Team>();
            InitializeComponent();
            teamPickAdvanced = new Teams.TeamPickAdvanced(this);
            this.tableLayoutMain.Controls.Add(teamPickAdvanced, 0, 0);
            tableLayoutMain.SetRowSpan(teamPickAdvanced, 8);
            teamPickAdvanced.Dock = DockStyle.Fill;

            unassignedCompetitors = new List<Competitor>();
            foreach (Competitor c in Connected_Event.Teams[0].Competitors)
            {
                unassignedCompetitors.Add(c);
            }
            teamPickAdvanced.refreshGrid();
        }

        #region Control Events

        private void inputAssignDefault_Click(object sender, EventArgs e)
        {

        }

        private void inputFilterOption_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void inputAddTeam_Click(object sender, EventArgs e)
        {

        }

        private void inputRemoveTeam_Click(object sender, EventArgs e)
        {

        }

        private void inputFillRemaining_Click(object sender, EventArgs e)
        {

        }

        private void inputAddTo_Click(object sender, EventArgs e)
        {
            List<string> teamNames = new List<string>();
            foreach (Team t in teams)
            {
                teamNames.Add(t.Name);
            }

            string currentTeam = ""; // Get currentTeam
            throw new NotImplementedException();
            string newTeam = MessageBoxes.SwitchTeam(teamNames, currentTeam);

            // Move the currently selected competitors to the new team.
        }

        private void inputRemoveFrom_Click(object sender, EventArgs e)
        {

        }
    }
#endregion
}
