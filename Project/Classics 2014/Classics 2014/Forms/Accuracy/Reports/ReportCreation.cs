using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMS.MySQL;
using System.Collections.ObjectModel;

namespace CMS.Accuracy.Reports
{
    partial class ReportCreation : UserControl
    {
        #region Variables and such like
        public Dictionary<EventCompetitor, ObservableCollection<AccuracyLanding>> data;
        public Ruleset.AccuracyRules rules;
        public ObservableCollection<Team> teams;

        private List<Leaderboard> LeaderboardReports = new List<Leaderboard>();
        private List<TeamReport> TeamReports = new List<TeamReport>();
        private List<LandingReport> LandingReports = new List<LandingReport>();
        private Accuracy_Event Connected_Event;
        private EventAccuracy MainEvent;
        private UserControl ActiveReport;
        private List<AccuracyLanding> landings;
        private bool selectEntireTeam;
        #endregion

        public ReportCreation(Accuracy_Event connectedEvent, EventAccuracy accEvent, Dictionary<EventCompetitor, List<AccuracyLanding>> eventData)
        {
            this.Connected_Event = connectedEvent;
            this.MainEvent = accEvent;
            InitializeComponent();
            loadTeams();
            loadData(eventData);
            loadRules();
            MainEvent.reportsUpdateDelegate = new UpdateAccuracyDataDelegate(reloadData);
            refreshLeaderboard();
            listBoxEventList.Items.AddRange(new String[]{"Leaderboard", "Competitor", "Landing"});
            if (connectedEvent.Rules.competitorsPerTeam != 1)
            {
                listBoxEventList.Items.Add("Team");
            }
            listBoxEventList.SelectedIndex = 0;
        }

        #region Loading

        /// <summary>
        /// Initialises teams, adds them from the event and adds the event handler for updating.
        /// </summary>
        private void loadTeams()
        {
            teams = new ObservableCollection<Team>();

            foreach (Team t in Connected_Event.Teams)
            {
                teams.Add(t);
            }

            teams.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(teams_CollectionChanged);
        }

        /// <summary>
        /// Initialises data and adds it from the event.
        /// </summary>
        private void loadData(Dictionary<EventCompetitor, List<AccuracyLanding>> eventData)
        {
            data = new Dictionary<EventCompetitor, ObservableCollection<AccuracyLanding>>();

            foreach (EventCompetitor c in eventData.Keys)
            {
                ObservableCollection<AccuracyLanding> currentLandingList = new ObservableCollection<AccuracyLanding>();
                currentLandingList.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(landingsUpdate);

                foreach (AccuracyLanding l in eventData[c])
                {
                    currentLandingList.Add(l);
                }
                data.Add(c, currentLandingList);
            }
        }

        /// <summary>
        /// Loads the rules from the connected event and allows access to them by child controls.
        /// </summary>
        private void loadRules()
        {
            rules = (Ruleset.AccuracyRules)Connected_Event.Rules;
        }

        /// <summary>
        /// Called whenever there is a landing update.
        /// </summary>
        private void reloadData(Dictionary<EventCompetitor, List<AccuracyLanding>> eventData)
        {
            foreach (EventCompetitor c in data.Keys)
            {
                data[c].Clear();

                foreach (AccuracyLanding l in eventData[c])
                {
                    data[c].Add(l);
                }
            }
        }

        #endregion

        /// <summary>
        /// Makes the ActiveReport appear over the dataGridLeaderboard.
        /// </summary>
        private void swapLeaderboardForReport()
        {
            tableLayoutPanel1.Controls.Add(ActiveReport);
            tableLayoutPanel1.SetColumn(ActiveReport, 2);
            tableLayoutPanel1.SetRow(ActiveReport, 2);
            tableLayoutPanel1.SetColumnSpan(ActiveReport, 1);
            tableLayoutPanel1.SetRowSpan(ActiveReport, 4);
            ActiveReport.Dock = DockStyle.Fill;
            dataGridLeaderboard.Enabled = false;
            dataGridLeaderboard.Visible = false;
            ActiveReport.Enabled = true;
            ActiveReport.Visible = true;
        }

        /// <summary>
        /// Replaces the dataGridLeaderboard in its rightful place and removes the ActiveReport.
        /// </summary>
        private void swapReportForLeaderboard()
        {
            if (ActiveReport != null)
            {
                ActiveReport.Enabled = false;
                ActiveReport.Visible = false;
            }
            dataGridLeaderboard.Enabled = true;
            dataGridLeaderboard.Visible = true;
            tableLayoutPanel1.Controls.Remove(ActiveReport);
        }


        void teams_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            refreshLeaderboard();
            foreach (Leaderboard l in LeaderboardReports)
            {
                l.RefreshGrid();
            }

            foreach (TeamReport tr in TeamReports)
            {
                //tr.Refresh_Teams();
            }

            foreach (LandingReport lr in LandingReports)
            {
                //lr.Refresh_Teams();
            }
        }

        void landingsUpdate(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            refreshLeaderboard();

            foreach (Leaderboard l in LeaderboardReports)
            {
                l.RefreshGrid();
            }

            foreach (TeamReport tr in TeamReports)
            {
                //tr.Refresh_Data();
            }

            foreach (LandingReport lr in LandingReports)
            {
                //lr.Refresh_Data();
            }
        }

        /// <summary>
        /// Completely updates the main datagrid.
        /// </summary>
        private void refreshLeaderboard()
        {
            dataGridLeaderboard.Rows.Clear();

            while (MainEvent.roundNumber >= dataGridLeaderboard.Columns.Count - 3)
            {
                dataGridLeaderboard.Columns.Add("Round" + (dataGridLeaderboard.Columns.Count - 3), "Round " + (dataGridLeaderboard.Columns.Count - 3));
            }

            foreach (Team t in teams)
            {
                foreach (EventCompetitor c in t.Competitors)
                {
                    int currentRow = dataGridLeaderboard.Rows.Add(c.ID, c.name, c.nationality, t.Name);
                    EventCompetitor currentCompetitor = null;

                    foreach (EventCompetitor k in data.Keys)
                    {
                        if (c.ID == k.ID)
                        {
                            currentCompetitor = k;
                        }
                    }

                    if (currentCompetitor != null)
                    {
                        foreach (AccuracyLanding l in data[c])
                        {
                            DataGridViewCell currentCell = dataGridLeaderboard.Rows[currentRow].Cells[3 + l.round];
                            currentCell.Value = l.score;

                            if (l.rejumpable) // If rejumpable
                            {
                                currentCell.Style.BackColor = MainEvent.rejumpableColour;
                                currentCell.Style.SelectionBackColor = MainEvent.rejumpableSelectedColor;
                            }

                            if (l.windDataPrior == null) // If no wind data and therefore manual
                            {
                                currentCell.Style.BackColor = MainEvent.manualScoreColour;
                                currentCell.Style.SelectionBackColor = MainEvent.manualScoreSelectedColor;
                            }

                            if (l.modified) // If Modified score
                            {
                                currentCell.Style.BackColor = MainEvent.modifiedScoreColour;
                                currentCell.Style.SelectionBackColor = MainEvent.modifiedScoreSelectedColor;
                            }
                        }
                    }
                }
            }
        }


        public void Update(int UserID, int Round, DataGridViewCell newCell)
        {
            while (Round >= dataGridLeaderboard.Columns.Count -3)
            {
                dataGridLeaderboard.Columns.Add("Round" + (dataGridLeaderboard.Columns.Count - 3), "Round" + (dataGridLeaderboard.Columns.Count - 3));
            }
            foreach (DataGridViewRow r in dataGridLeaderboard.Rows)
            {
                if (r.Cells[0].Value.ToString() == UserID.ToString())
                {
                    r.Cells[Round + 3] = (DataGridViewCell)newCell.Clone();
                    r.Cells[Round + 3].Value = newCell.Value;
                }
            }
        }

        /// <summary>
        /// If a non Landing change has occured to the Event Leaderboard
        /// </summary>
        /// <param name="Repop"></param>
        public void Update()
        {
            refreshLeaderboard();
        }

        private void radioButtonNew_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNew.Checked) 
            {
                radioButtonExist.Checked = false;
                listBoxEventList.Items.Clear();
                listBoxEventList.Items.AddRange(new String[] { "Leaderboard", "Competitor", "Landing" });
                if (Connected_Event.Rules.competitorsPerTeam != 1)
                {
                    listBoxEventList.Items.Add("Team");
                }
                textBoxReportName.Text = "Insert Report Name";
                textBoxReportName.Enabled = true;
                buttonCreateReport.Enabled = true;
                listBoxEventList.SelectedIndex = 0;
                swapReportForLeaderboard();
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

                                dataGridLeaderboard.ClearSelection();
                                dataGridLeaderboard.Enabled = true;
                                dataGridLeaderboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                        swapLeaderboardForReport();
                }
                else
                {
                    if (listBoxEventList.SelectedItem.ToString() == "Leaderboard")
                    {
                        dataGridLeaderboard.ClearSelection();
                        dataGridLeaderboard.SelectAll();
                        dataGridLeaderboard.Enabled = false;
                        selectEntireTeam = false;
                    }
                    else if ((listBoxEventList.SelectedItem.ToString() == "Team") && (Connected_Event.Rules.competitorsPerTeam != 1))
                    {
                        dataGridLeaderboard.ClearSelection();
                        dataGridLeaderboard.Enabled = true;
                        dataGridLeaderboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        selectEntireTeam = true;
                    }
                    else if (listBoxEventList.SelectedItem.ToString() == "Landing")
                    {
                        dataGridLeaderboard.ClearSelection();
                        dataGridLeaderboard.Enabled = true;
                        dataGridLeaderboard.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        selectEntireTeam = false;
                    }
                    else
                    {
                        dataGridLeaderboard.ClearSelection();
                        dataGridLeaderboard.Enabled = true;
                        dataGridLeaderboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        selectEntireTeam = false;
                    }
                }
            }
        }

        private void dataGridViewLockedLeaderboard_SelectionChanged(object sender, EventArgs e)
        {
            string teamName;
            if (listBoxEventList.SelectedItem != null)
            {
                if ((selectEntireTeam)&&(dataGridLeaderboard.SelectedRows.Count != 0))
                {
                    teamName = dataGridLeaderboard.SelectedRows[0].Cells["ColumnCompetitorTeam"].Value.ToString();
                    foreach (DataGridViewRow c in dataGridLeaderboard.Rows)
                    {
                        if (c.Cells["ColumnCompetitorTeam"].Value.ToString() == teamName) { c.Selected = true; }
                    }
                }
                else if (listBoxEventList.SelectedItem.ToString() == "Landing")
                {
                    if ((dataGridLeaderboard.SelectedCells.Count == 0) || (dataGridLeaderboard.SelectedCells[0].ColumnIndex < 3))
                    {
                        dataGridLeaderboard.ClearSelection();
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
                        Leaderboard newLeaderBoard = new Leaderboard(this,textBoxReportName.Text);
                          if (!newLeaderBoard.CloseOnStart)
                          {
                              LeaderboardReports.Add(newLeaderBoard);
                              ActiveReport = newLeaderBoard;
                              swapLeaderboardForReport();
                              radioButtonExist.Checked = true;
                          }
                        break;
                    case "Team":
                            if (dataGridLeaderboard.SelectedRows.Count > 0)
                            {
                                TeamReport report = new TeamReport(dataGridLeaderboard.SelectedRows, dataGridLeaderboard.Columns.Count, reportName, new Action<TeamReport>(RemoveReport));
                                TeamReports.Add(report);
                                ActiveReport = report;
                                swapLeaderboardForReport();
                            }
                        break;
                    case "Competitor":
                        if (dataGridLeaderboard.SelectedRows.Count > 0)
                        {
                            TeamReport report = new TeamReport(dataGridLeaderboard.SelectedRows, dataGridLeaderboard.Columns.Count, reportName, new Action<TeamReport>(RemoveReport));
                            TeamReports.Add(report);
                            ActiveReport = report;
                            swapLeaderboardForReport();
                        }
                        break;
                    case "Landing":
                        if (!(dataGridLeaderboard.SelectedCells.Count == 0) && !(dataGridLeaderboard.SelectedCells[0].ColumnIndex < 4)&& (dataGridLeaderboard.SelectedCells[0].Style.BackColor != Color.LightBlue ))
                        {
                            foreach (KeyValuePair<EventCompetitor, ObservableCollection<AccuracyLanding>> pair in data)
                            {
                                foreach (AccuracyLanding l in pair.Value)
                                {
                                    if ((l.UID == Convert.ToInt16(dataGridLeaderboard.SelectedCells[0].OwningRow.Cells[0].Value)) && (l.round == dataGridLeaderboard.SelectedCells[0].ColumnIndex - 3))
                                    {
                                        LandingReport newReport = new LandingReport(this, l, textBoxReportName.Text);
                                        LandingReports.Add(newReport);
                                        ActiveReport = newReport;
                                        swapLeaderboardForReport();
                                        radioButtonExist.Checked = true;
                                    }
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
