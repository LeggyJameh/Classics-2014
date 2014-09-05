using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classics_2014.Accuracy.Reports
{
    public partial class ReportCreation : UserControl
    {
        List<Leaderboard> LeaderboardReports = new List<Leaderboard>();
        List<TeamReport> TeamReports = new List<TeamReport>();
        List<CompetitorReport> CompetitorReports = new List<CompetitorReport>();
        List<LandingReport> LandingReports = new List<LandingReport>();
        SQL_Controller sqlController;
        Accuracy_Event connectedEvent;
        int eventId;
         ReportCreation(SQL_Controller sqlController, Accuracy_Event connectedEvent, int eventId)
        {
            InitializeComponent();
            this.sqlController = sqlController;
            this.connectedEvent = connectedEvent;
            this.eventId = eventId;
        }

        private void radioButtonNew_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNew.Checked) 
            {
                radioButtonExist.Checked = false;
                listBoxEventList.Items.Clear();
                listBoxEventList.Items.Add("Leaderboard");
                listBoxEventList.Items.Add("Team");
                listBoxEventList.Items.Add("Competitor");
                listBoxEventList.Items.Add("Wind");
            }
        }

        private void radioButtonExist_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonExist.Checked) 
            { 
                radioButtonNew.Checked = false;
                listBoxEventList.Items.Clear();
                foreach (Leaderboard L in LeaderboardReports)
                {
                    listBoxEventList.Items.Add(L.Name);
                }
                foreach (TeamReport t in TeamReports)
                {
                    listBoxEventList.Items.Add(t.Name);
                }
                foreach (CompetitorReport c in CompetitorReports)
                {
                    listBoxEventList.Items.Add(c.Name);
                }
            }
        }

        private void listBoxEventList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEventList.SelectedItem != null)
            {

            }
        }
        public void Update()
        {
            List<TCompetitor> competitors = sqlController.GetCompetitorsForEvent(eventId);
            List<MySqlReturnLanding> landings = sqlController.GetLandingsForAccuracyEvent(eventId, connectedEvent);
            DataGridViewCell cellToEdit;
            foreach (TCompetitor c in competitors)
            {
                dataGridViewLockedLeaderboard.Rows.Add(c.name, c.nationality, c.team);
                foreach (MySqlReturnLanding l in landings)
                {
                    if (l.UID == c.ID)
                    {
                        while (l.Round > dataGridViewLockedLeaderboard.ColumnCount - 2)
                        {
                            dataGridViewLockedLeaderboard.Columns.Add("columnRound" + (dataGridViewLockedLeaderboard.ColumnCount - 1), "Round " + (dataGridViewLockedLeaderboard.ColumnCount - 1));
                        }
                        cellToEdit = dataGridViewLockedLeaderboard[l.Round + 2, dataGridViewLockedLeaderboard.Rows.Count - 1];
                        cellToEdit.Style.BackColor = Color.LightGreen;
                        if (l.Modified == true)
                        {
                            cellToEdit.Style.BackColor = Color.Yellow;
                            if (l.windDataPrior == null) { cellToEdit.Style.BackColor = Color.LightBlue; }
                        }
                    }
                }
            }

        }
    }
}
