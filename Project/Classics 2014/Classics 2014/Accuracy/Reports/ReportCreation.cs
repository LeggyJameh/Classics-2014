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
        List<MySqlReturnLanding> landings;
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
            listBoxEventList.SelectedIndex = 0;
        }
        public void Update(int UserID, int Round, DataGridViewCell newCell)
        {
            foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
            {
                if (r.Cells[0].Value.ToString() == UserID.ToString())
                {
                    r.Cells[Round + 3] = newCell;
                }
            }
            foreach (Leaderboard l in LeaderboardReports)
            {
                l.Update(UserID, Round, newCell);
            }
            foreach (TeamReport t in TeamReports)
            {
                //ToDo Update Method
            }
            foreach (CompetitorReport c in CompetitorReports)
            {
                //ToDo Update Method
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
                listBoxEventList.Items.Add("Leaderboard");
                listBoxEventList.Items.Add("Team");
                listBoxEventList.Items.Add("Competitor");
                listBoxEventList.Items.Add("Landing");
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
                            if (listBoxEventList.SelectedItem.ToString() == L.Name)
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
                            if (listBoxEventList.SelectedItem.ToString() == t.Name)
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
                            if (listBoxEventList.SelectedItem.ToString() == c.Name)
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
                    else if ((listBoxEventList.SelectedItem.ToString() == "Team") && (connectedEvent.ruleSet.noOfCompetitorsPerTeam != 1))
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
            List<TCompetitor> competitors = sqlController.GetCompetitorsForEvent(eventId);
            landings = sqlController.GetLandingsForAccuracyEvent(eventId, connectedEvent);
            DataGridViewCell cellToEdit;
            foreach (TCompetitor c in competitors)
            {
                dataGridViewLockedLeaderboard.Rows.Add(c.ID, c.name, c.nationality, c.team);
                foreach (MySqlReturnLanding l in landings)
                {
                    if (l.UID == c.ID)
                    {
                        while (l.Round > dataGridViewLockedLeaderboard.ColumnCount - 4)
                        {
                            dataGridViewLockedLeaderboard.Columns.Add("columnRound" + (l.Round), "Round " + (l.Round));
                        }

                        cellToEdit = dataGridViewLockedLeaderboard[l.Round + 3, dataGridViewLockedLeaderboard.Rows.Count - 1];
                        cellToEdit.Value = l.score;
                        cellToEdit.Style.BackColor = Color.LightGreen;
                        if (l.Modified == true)
                        {
                            cellToEdit.Style.BackColor = Color.Yellow;
                            if (l.windDataPrior == null) { cellToEdit.Style.BackColor = Color.LightBlue; }
                        }
                        if (l.windDataPrior == null)
                        {
                            cellToEdit.Style.BackColor = Color.LightBlue;
                        }

                    }
                }

            }
        }

        private void dataGridViewLockedLeaderboard_SelectionChanged(object sender, EventArgs e)
        {
            string teamName;
            if (selectEntireTeam)
            {
                teamName = dataGridViewLockedLeaderboard.SelectedRows[0].Cells["ColumnCompetitorTeam"].Value.ToString();
                foreach (DataGridViewRow c in dataGridViewLockedLeaderboard.Rows)
                {
                    if(c.Cells["ColumnCompetitorTeam"].Value.ToString() == teamName) {c.Selected = true;}
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
         
        private void buttonCreateReport_Click(object sender, EventArgs e)
        {
            string reportName = "";
           
            if (GetReportName (ref reportName))
            {
                switch (listBoxEventList.SelectedItem.ToString())
                {
                    case "Leaderboard":
                        break;
                    case "Team":
                        break;
                    case "Competitor":
                        break;
                    case "Landing":
                        if (!(dataGridViewLockedLeaderboard.SelectedCells.Count == 0) && !(dataGridViewLockedLeaderboard.SelectedCells[0].ColumnIndex < 3)&& (dataGridViewLockedLeaderboard.SelectedCells[0].Style.BackColor != Color.LightBlue ))
                        {
                            foreach (MySqlReturnLanding l in landings)
                            {
                                if (l.UID == Convert.ToInt16(dataGridViewLockedLeaderboard.SelectedCells[0].OwningRow.Cells[0].Value))
                                {
                                    LandingReport newReport = new LandingReport(l, reportName, connectedEvent);
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
                        if (t.Name == strToInsert + " Team Report")
                        {
                            { MessageBox.Show("Please choose a Name not already in use"); return false; }
                        }
                    }
                    strToInsert += " Team Report";
                    break;
                case "Competitor":
                    foreach (CompetitorReport c in CompetitorReports)
                    {
                        if (c.Name == strToInsert + " Competitor Report")
                        {
                            { MessageBox.Show("Please choose a Name not already in use"); return false; }
                        }
                    }
                    strToInsert += " Competitor Report";
                    break;
                case "Landing":
                    foreach (LandingReport l in LandingReports)
                    {
                        if (l.Name == strToInsert + " Landing Report")
                        {
                            { MessageBox.Show("Please choose a Name not already in use"); return false; }
                        }
                    }
                    strToInsert += " Landing Report";
                    break;
            }
            return true;
        }
    }
}
