using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS.Forms.Teams
{
    partial class TeamPickAdvanced : UserControl
    {
        TeamPicker TeamPicker;

        public TeamPickAdvanced(TeamPicker Owner)
        {
            this.TeamPicker = Owner;
            InitializeComponent();
            loadTeams();
        }

        private void loadTeams()
        {
            foreach (Team t in TeamPicker.teams)
            {
                addTeam(t);
            }
        }

        public List<Team> exportTeams()
        {
            List<Team> teamsToExport = new List<Team>();
            foreach (UserControl c in panelMain.Controls)
            {
                if (c is TeamAdvanced)
                {
                    TeamAdvanced ta = (TeamAdvanced)c;
                    teamsToExport.Add(ta.ReturnTeam());
                }
            }
            return teamsToExport;
        }

        public void refreshGrid()
        {
            dataGridUnassignedCompetitors.Rows.Clear();
            foreach (Competitor c in TeamPicker.unassignedCompetitors)
            {
                dataGridUnassignedCompetitors.Rows.Add(c.ID, c.name, c.nationality, c.team);
            }
        }

        private void addTeam(Team team)
        {
            panelMain.Controls.Add(new TeamAdvanced(team));
        }
    }
}
