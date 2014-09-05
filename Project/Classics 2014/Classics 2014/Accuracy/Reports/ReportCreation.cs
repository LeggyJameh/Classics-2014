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
    partial class ReportCreation : UserControl
    {
        List<Leaderboard> LeaderboardReports = new List<Leaderboard>();
        List<TeamReport> TeamReports = new List<TeamReport>();
        List<CompetitorReport> CompetitorReports = new List<CompetitorReport>();
        List<LandingReport> LandingReports = new List<LandingReport>();
        SQL_Controller sqlController;
        Accuracy_Event connectedEvent;
        Control ActiveReport;
        int eventId;
        bool selectEntireTeam;
        public ReportCreation(SQL_Controller sqlController, Accuracy_Event connectedEvent, int eventId)
        {
            InitializeComponent();
            this.sqlController = sqlController;
            this.connectedEvent = connectedEvent;
            this.eventId = eventId;
            ActiveReport = dataGridViewLockedLeaderboard;
            Populate();
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
                listBoxEventList.Items.Add("Landing");
                textBoxReportName.Text = "Insert Report Name";
                textBoxReportName.Enabled = true;
                buttonCreateReport.Enabled = true;
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
                foreach (LandingReport l in LandingReports)
                {
                    listBoxEventList.Items.Add(l.Name);
                }
            }
            textBoxReportName.Enabled = false;
            buttonCreateReport.Enabled = false;
        }

        private void listBoxEventList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEventList.SelectedItem != null)
            {
                if (radioButtonExist.Checked)
                {
                    foreach (Leaderboard L in LeaderboardReports)
                    {
                        if (listBoxEventList.SelectedValue.ToString() == L.Name)
                        {
                            ActiveReport.Visible = false;
                            ActiveReport.Enabled = false;
                            L.Visible = true;
                            L.Enabled = true;
                            ActiveReport = L;

                        }
                    }
                    foreach (TeamReport t in TeamReports)
                    {
                        if (listBoxEventList.SelectedValue.ToString() == t.Name)
                        {
                            ActiveReport.Visible = false;
                            ActiveReport.Enabled = false;
                            t.Visible = true;
                            t.Enabled = true;
                            ActiveReport = t;

                            dataGridViewLockedLeaderboard.ClearSelection();
                            dataGridViewLockedLeaderboard.Enabled = true;
                            dataGridViewLockedLeaderboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        }
                    }
                    foreach (CompetitorReport c in CompetitorReports)
                    {
                        if (listBoxEventList.SelectedValue.ToString() == c.Name)
                        {
                            ActiveReport.Visible = false;
                            ActiveReport.Enabled = false;
                            c.Visible = true;
                            c.Enabled = true;
                            ActiveReport = c;
                        }
                    }
                    foreach (LandingReport l in LandingReports)
                    {
                        if (listBoxEventList.SelectedValue.ToString() == l.Name)
                        {
                            ActiveReport.Visible = false;
                            ActiveReport.Enabled = false;
                            l.Visible = true;
                            l.Enabled = true;
                            ActiveReport = l;
                        }
                    }
                }
                else
                {
                    if (listBoxEventList.SelectedValue.ToString() == "Leaderboard")
                    {
                        dataGridViewLockedLeaderboard.ClearSelection();
                        dataGridViewLockedLeaderboard.SelectAll();
                        dataGridViewLockedLeaderboard.Enabled = false;
                    }
                    else if (listBoxEventList.SelectedValue.ToString() == "Team")
                    {
                        dataGridViewLockedLeaderboard.ClearSelection();
                        dataGridViewLockedLeaderboard.Enabled = true;
                        dataGridViewLockedLeaderboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        selectEntireTeam = true;
                    }
                    else if (listBoxEventList.SelectedValue.ToString() == "Landing")
                    {
                        dataGridViewLockedLeaderboard.ClearSelection();
                        dataGridViewLockedLeaderboard.Enabled = true;
                        dataGridViewLockedLeaderboard.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    }
                    else
                    {
                        dataGridViewLockedLeaderboard.ClearSelection();
                        dataGridViewLockedLeaderboard.Enabled = true;
                        dataGridViewLockedLeaderboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    }
                }
            }
        }
        public void Populate()
        {
            List<TCompetitor> competitors = sqlController.GetCompetitorsForEvent(eventId);
            List<MySqlReturnLanding> landings = sqlController.GetLandingsForAccuracyEvent(eventId, connectedEvent);
            DataGridViewCell cellToEdit;
            foreach (TCompetitor c in competitors)
            {
                dataGridViewLockedLeaderboard.Rows.Add(c.ID,c.name, c.nationality, c.team);
                foreach (MySqlReturnLanding l in landings)
                {
                    if (l.UID == c.ID)
                    {
                        while (l.Round > dataGridViewLockedLeaderboard.ColumnCount - 3)
                        {
                            dataGridViewLockedLeaderboard.Columns.Add("columnRound" + (dataGridViewLockedLeaderboard.ColumnCount - 2), "Round " + (dataGridViewLockedLeaderboard.ColumnCount - 2));
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
