using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Classics_2014.MySQL;

namespace Classics_2014.Accuracy.Reports
{
    partial class ReportCreation : UserControl
    {
        List<Leaderboard> LeaderboardReports = new List<Leaderboard>();
        List<TeamReport> TeamReports = new List<TeamReport>();
        List<LandingReport> LandingReports = new List<LandingReport>();
        SQL_Controller sqlController;
        Accuracy_Event connectedEvent;
        Control ActiveReport;
        List<AccuracyLanding> landings;
        int eventId;
        bool selectEntireTeam;
        public ReportCreation(SQL_Controller sqlController, Accuracy_Event connectedEvent, int eventId)
        {
            InitializeComponent();
            listBoxEventList.Items.AddRange(new String[]{"Leaderboard", "Competitor", "Landing"});
            if (connectedEvent.Rules.noOfCompetitorsPerTeam != 1)
            {
                listBoxEventList.Items.Add("Team");
            }
            this.sqlController = sqlController;
            this.connectedEvent = connectedEvent;
            this.eventId = eventId;
            ActiveReport = dataGridViewLockedLeaderboard;
            Populate();
            listBoxEventList.SelectedIndex = 0;
        }
        public void Update(int UserID, int Round, DataGridViewCell newCell)
        {
            while (Round >= dataGridViewLockedLeaderboard.Columns.Count -3)
            {
                dataGridViewLockedLeaderboard.Columns.Add("Round" + (dataGridViewLockedLeaderboard.Columns.Count - 3), "Round" + (dataGridViewLockedLeaderboard.Columns.Count - 3));
            }
            foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
            {
                if (r.Cells[0].Value.ToString() == UserID.ToString())
                {
                    r.Cells[Round + 3] = (DataGridViewCell)newCell.Clone();
                    r.Cells[Round + 3].Value = newCell.Value;
                }
            }
            foreach (Leaderboard l in LeaderboardReports)
            {
                l.Update(UserID, Round, newCell);
            }
        }
        /// <summary>
        /// If a non Landing change has occured to the Event Leaderboard
        /// </summary>
        /// <param name="Repop"></param>
        public void Update()
        {
            dataGridViewLockedLeaderboard.Rows.Clear();
            Populate();
        }
        private void radioButtonNew_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNew.Checked) 
            {
                radioButtonExist.Checked = false;
                listBoxEventList.Items.Clear();
                listBoxEventList.Items.AddRange(new String[] { "Leaderboard", "Competitor", "Landing" });
                if (connectedEvent.Rules.noOfCompetitorsPerTeam != 1)
                {
                    listBoxEventList.Items.Add("Team");
                }
                textBoxReportName.Text = "Insert Report Name";
                textBoxReportName.Enabled = true;
                buttonCreateReport.Enabled = true;
                listBoxEventList.SelectedIndex = 0;
                ActiveReport.Visible = false;
                ActiveReport.Enabled = false;
                dataGridViewLockedLeaderboard.Visible = true;
                dataGridViewLockedLeaderboard.Enabled = true;
                ActiveReport = dataGridViewLockedLeaderboard;
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
                    listBoxEventList.Items.Add(L.reportName);

                }
                foreach (TeamReport t in TeamReports)
                {
                    listBoxEventList.Items.Add(t.NameOfReport);
                }
                foreach (LandingReport l in LandingReports)
                {
                    listBoxEventList.Items.Add(l.NameOfReport); //Make sure to use UserSelectedName
                }
            }
            textBoxReportName.Enabled = false;
            buttonCreateReport.Enabled = false;
            if (listBoxEventList.Items.Count > 0)
            {
                listBoxEventList.SelectedIndex = 0;
            }
        }

        private void listBoxEventList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEventList.SelectedItem != null)
            {
                if (radioButtonExist.Checked)
                {
                        foreach (Leaderboard L in LeaderboardReports)
                        {
                            if (listBoxEventList.SelectedItem.ToString() == L.reportName) 
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
                            if (listBoxEventList.SelectedItem.ToString() == t.NameOfReport)
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
                        foreach (LandingReport l in LandingReports)
                        {
                            if (listBoxEventList.SelectedItem.ToString() == l.NameOfReport) //Also Change these Rob
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
                    if (listBoxEventList.SelectedItem.ToString() == "Leaderboard")
                    {
                        dataGridViewLockedLeaderboard.ClearSelection();
                        dataGridViewLockedLeaderboard.SelectAll();
                        dataGridViewLockedLeaderboard.Enabled = false;
                        selectEntireTeam = false;
                    }
                    else if ((listBoxEventList.SelectedItem.ToString() == "Team") && (connectedEvent.Rules.noOfCompetitorsPerTeam != 1))
                    {
                        dataGridViewLockedLeaderboard.ClearSelection();
                        dataGridViewLockedLeaderboard.Enabled = true;
                        dataGridViewLockedLeaderboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        selectEntireTeam = true;
                    }
                    else if (listBoxEventList.SelectedItem.ToString() == "Landing")
                    {
                        dataGridViewLockedLeaderboard.ClearSelection();
                        dataGridViewLockedLeaderboard.Enabled = true;
                        dataGridViewLockedLeaderboard.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        selectEntireTeam = false;
                    }
                    else
                    {
                        dataGridViewLockedLeaderboard.ClearSelection();
                        dataGridViewLockedLeaderboard.Enabled = true;
                        dataGridViewLockedLeaderboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        selectEntireTeam = false;
                    }
                }
            }
        }
        public void Populate()
        {
            List<Team> Teams = sqlController.GetTeamsForEvent(connectedEvent.EventID);
            landings = sqlController.GetLandingsForEvent(eventId, connectedEvent.EventType);
            DataGridViewCell cellToEdit;
            for (int Ti = 0; Ti < Teams.Count; Ti++)
            {
                for (int Ci = 0; Ci < Teams[Ti].Competitors.Count; Ci++)
                {
                    dataGridViewLockedLeaderboard.Rows.Add(Teams[Ti].Competitors[Ci].ID, Teams[Ti].Competitors[Ci].name, Teams[Ti].Competitors[Ci].nationality, Teams[Ti].Name);
                    foreach (AccuracyLanding l in landings)
                    {
                        if (l.UID == Teams[Ti].Competitors[Ci].ID)
                        {
                            while (l.round > dataGridViewLockedLeaderboard.ColumnCount - 4)
                            {
                                dataGridViewLockedLeaderboard.Columns.Add("columnRound" + (l.round), "Round " + (l.round));
                            }
                            cellToEdit = dataGridViewLockedLeaderboard[l.round + 3, dataGridViewLockedLeaderboard.Rows.Count - 1];
                            cellToEdit.Value = l.score;
                            cellToEdit.Style.BackColor = Color.LightGreen;
                            if (l.modified == true)
                            {
                                cellToEdit.Style.BackColor = Color.Yellow;
                                if (l.windDataPrior == null) { cellToEdit.Style.BackColor = Color.LightBlue; }
                            }
                            if (l.windDataPrior == null)
                            {
                                cellToEdit.Style.BackColor = Color.LightBlue;
                            }
                            else if (l.rejumpable)
                            {
                                cellToEdit.Style.ForeColor = Color.Red;
                            }
                        }
                    }
                }

            }
        }

        private void dataGridViewLockedLeaderboard_SelectionChanged(object sender, EventArgs e)
        {
            string teamName;
            if (listBoxEventList.SelectedItem != null)
            {
                if ((selectEntireTeam)&&(dataGridViewLockedLeaderboard.SelectedRows.Count != 0))
                {
                    teamName = dataGridViewLockedLeaderboard.SelectedRows[0].Cells["ColumnCompetitorTeam"].Value.ToString();
                    foreach (DataGridViewRow c in dataGridViewLockedLeaderboard.Rows)
                    {
                        if (c.Cells["ColumnCompetitorTeam"].Value.ToString() == teamName) { c.Selected = true; }
                    }
                }
                else if (listBoxEventList.SelectedItem.ToString() == "Landing")
                {
                    if ((dataGridViewLockedLeaderboard.SelectedCells.Count == 0) || (dataGridViewLockedLeaderboard.SelectedCells[0].ColumnIndex < 3))
                    {
                        dataGridViewLockedLeaderboard.ClearSelection();
                    }
                }
            }
        }
         
        private void buttonCreateReport_Click(object sender, EventArgs e)
        {
            string reportName = "";
           
            if (GetReportName (ref reportName))
            {
                switch (listBoxEventList.SelectedItem.ToString())
                {
                    case "Leaderboard":
                        Leaderboard newLeaderBoard = new Leaderboard(connectedEvent.EventID, reportName, sqlController, connectedEvent, new Action<Leaderboard>(RemoveReport));
                        if (!newLeaderBoard.CloseOnStart)
                          {
                        splitContainer1.Panel2.Controls.Add(newLeaderBoard);
                        newLeaderBoard.Dock = DockStyle.Fill;
                        LeaderboardReports.Add(newLeaderBoard);
                        ActiveReport.Visible = false;
                        ActiveReport.Enabled = false;
                        newLeaderBoard.Visible = true;
                        newLeaderBoard.Enabled = true;
                        ActiveReport = newLeaderBoard;
                        radioButtonExist.Checked = true;
                        }
                            break;
                    case "Team":
                            if (dataGridViewLockedLeaderboard.SelectedRows.Count > 0)
                            {
                                TeamReport report = new TeamReport(dataGridViewLockedLeaderboard.SelectedRows, dataGridViewLockedLeaderboard.Columns.Count, reportName, new Action<TeamReport>(RemoveReport));
                                splitContainer1.Panel2.Controls.Add(report);
                                report.Dock = DockStyle.Fill;
                                TeamReports.Add(report);
                                ActiveReport.Visible = false;
                                ActiveReport.Enabled = false;
                                report.Visible = true;
                                report.Enabled = true;
                                ActiveReport = report;
                                radioButtonExist.Checked = true;
                            }
                        break;
                    case "Competitor":
                        if (dataGridViewLockedLeaderboard.SelectedRows.Count > 0)
                        {
                            TeamReport report = new TeamReport(dataGridViewLockedLeaderboard.SelectedRows, dataGridViewLockedLeaderboard.Columns.Count, reportName, new Action<TeamReport>(RemoveReport));
                            splitContainer1.Panel2.Controls.Add(report);
                            report.Dock = DockStyle.Fill;
                            TeamReports.Add(report);
                            ActiveReport.Visible = false;
                            ActiveReport.Enabled = false;
                            report.Visible = true;
                            report.Enabled = true;
                            ActiveReport = report;
                            radioButtonExist.Checked = true;
                        }
                        break;
                    case "Landing":
                        if (!(dataGridViewLockedLeaderboard.SelectedCells.Count == 0) && !(dataGridViewLockedLeaderboard.SelectedCells[0].ColumnIndex < 4)&& (dataGridViewLockedLeaderboard.SelectedCells[0].Style.BackColor != Color.LightBlue ))
                        {
                            foreach (AccuracyLanding l in landings)
                            {
                                if ((l.UID == Convert.ToInt16(dataGridViewLockedLeaderboard.SelectedCells[0].OwningRow.Cells[0].Value)) && (l.round == dataGridViewLockedLeaderboard.SelectedCells[0].ColumnIndex - 3)) 
                                {
                                    LandingReport newReport = new LandingReport(l, reportName, connectedEvent, new Action<LandingReport>(RemoveReport));
                                    splitContainer1.Panel2.Controls.Add(newReport);
                                    newReport.Dock = DockStyle.Fill;
                                    LandingReports.Add(newReport);
                                    ActiveReport.Visible = false;
                                    ActiveReport.Enabled = false;
                                    newReport.Visible = true;
                                    newReport.Enabled = true;
                                    ActiveReport = newReport;
                                    radioButtonExist.Checked = true;
                                }
                            }
                        }
                        break;
                }
            }
        }
        public void RemoveReport(LandingReport l)
        {
            LandingReports.Remove(l);
            radioButtonNew.Checked = true;
        }
                public void RemoveReport(TeamReport l)
        {
            TeamReports.Remove(l);
            radioButtonNew.Checked = true;
        }
                public void RemoveReport(Leaderboard l)
        {
            LeaderboardReports.Remove(l);
            radioButtonNew.Checked = true;
        }
        private bool GetReportName(ref string strToInsert)
        {
             strToInsert = textBoxReportName.Text;
            if (string.IsNullOrEmpty(strToInsert)){MessageBox.Show("Please choose a valid name");return false;}//ToDo Update This Message Box
            switch (listBoxEventList.SelectedItem.ToString())
            {
                case "Leaderboard":
                    foreach (Leaderboard l in LeaderboardReports)
                    {
                        if (l.Name == strToInsert + " Leaderboard")
                        {
                            { MessageBox.Show("Please choose a Name not already in use"); return false; }
                        }
                    }
                    strToInsert += " Leaderboard";
                    break;
                case "Team":
                    foreach (TeamReport t in TeamReports)
                    {
                        if (t.NameOfReport == strToInsert + " Team Report")
                        {
                            { MessageBox.Show("Please choose a Name not already in use"); return false; }
                        }
                    }
                    strToInsert += " Team Report";
                    break;
                case "Competitor":
                    foreach (TeamReport t in TeamReports)
                    {
                        if (t.NameOfReport == strToInsert + " Competitor Report")
                        {
                            { MessageBox.Show("Please choose a Name not already in use"); return false; }
                        }
                    }
                    strToInsert += " Competitor Report";
                    break;
                case "Landing":
                    foreach (LandingReport l in LandingReports)
                    {
                        if (l.NameOfReport == strToInsert + " Landing Report")
                        {
                            { MessageBox.Show("Please choose a Name not already in use"); return false; }
                        }
                    }
                    strToInsert += " Landing Report";
                    break;
            }
            return true;
        } 

        private void textBoxReportName_Enter(object sender, EventArgs e)
        {
            if (textBoxReportName.Text == "Insert Report Name")
            {
                textBoxReportName.Text = "";
            }
        }

        private void textBoxReportName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxReportName.Text)) 
            {
                textBoxReportName.Text = "Insert Report Name";
            }
        }
    }
}
