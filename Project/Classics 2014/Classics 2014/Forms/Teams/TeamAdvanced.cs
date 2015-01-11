using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace CMS
{
    partial class TeamAdvanced : UserControl
    {
        public ObservableCollection<Competitor> competitors;
        private Bitmap NteamImage;
        private int NteamID;
        private string NteamName;
        private int eventID;

        public Bitmap teamImage
        {
            get
            {
                return NteamImage;
            }
            set
            {
                pictureBoxTeamImage.Image = value;
                NteamImage = value;
            }
        }

        public int teamID
        {
            get
            {
                return NteamID;
            }
            set
            {
                labelID.Text = "ID: " + value;
                NteamID = value;
            }
        }

        public string teamName
        {
            get
            {
                return NteamName;
            }
            set
            {
                labelTeamName.Text = value;
                NteamName = value;
            }
        }

        public TeamAdvanced(Team currentTeam)
        {
            this.teamName = currentTeam.Name;
            this.teamID = currentTeam.ID;
            this.teamImage = currentTeam.TeamImage;
            this.eventID = currentTeam.EventID;
            foreach (Competitor c in currentTeam.Competitors)
            {
                this.competitors.Add(c);
            }
            InitializeComponent();
            competitors.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(competitors_CollectionChanged);
        }

        private void competitors_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            dataGridTeam.Rows.Clear();
            foreach (EventCompetitor c in competitors)
            {
                dataGridTeam.Rows.Add(c.ID, c.name, c.nationality, c.team);
            }
        }


        public Team ReturnTeam()
        {
            Team currentTeam = new Team(teamName);
            currentTeam.ID = teamID;
            currentTeam.Name = teamName;
            currentTeam.TeamImage = teamImage;
            currentTeam.EventID = eventID;

            foreach (EventCompetitor c in competitors)
            {
                currentTeam.Competitors.Add(c);
            }

            return currentTeam;
        }

        private void inputExit_Click(object sender, EventArgs e)
        {
            if (inputClear.Visible == true) // If already visible
            {
                inputClear.Visible = false;
                inputConfirm.Visible = false;
                inputRemove.Visible = false;
                dataGridTeam.Visible = false;
                pictureBoxTeamImage.Visible = false;
                inputMinimise.Text = "+";
            }
            else // If not already visible
            {
                inputClear.Visible = true;
                inputConfirm.Visible = true;
                inputRemove.Visible = true;
                dataGridTeam.Visible = true;
                pictureBoxTeamImage.Visible = true;
                inputMinimise.Text = "-";
            }
        }
    }
}
