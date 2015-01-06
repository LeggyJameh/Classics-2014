using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace CMS.Forms.Teams
{
    partial class TeamAdvanced : UserControl
    {
        bool hidden;
        int maxNumber;
        ReportingTeam team;
        public TeamAdvanced(ref Team team, int maxCompPerTeam)
        {
            this.team = (ReportingTeam)team;
            maxNumber = maxCompPerTeam;
            hidden = false;
            InitializeComponent();
        }

        private void inputShowHide_Click(object sender, EventArgs e)
        {
            if (hidden) // If not visible
            {
                dataGridCompetitors.Visible = true;
                pictureBoxTeamImage.Visible = true;
                inputShowHide.Text = "-";
            }
            else // If visible
            {
                dataGridCompetitors.Visible = false;
                pictureBoxTeamImage.Visible = false;
                inputShowHide.Text = "+";
            }
        }

        public void onTeamChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            //team.
        }
    }
}
