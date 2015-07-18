using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace CMS.Accuracy.Reports
{
    partial class Leaderboard : UserControl
    {
        public string reportName;
        int roundColumnCount;
        bool autoUpdate;
        bool sortTeams;
        ReportCreation reportCreator;
        Form undockedForm = null;
        Bitmap display;
        Microsoft.Office.Interop.Excel.Application xlApp;
        public bool CloseOnStart = false;


        public Leaderboard(ReportCreation reportCreator, string reportName)
        {
            InitializeComponent();
            autoUpdate = false;
            sortTeams = false;
            roundColumnCount = 0;
            this.reportCreator = reportCreator;
            this.reportName = reportName;

            if (reportCreator.rules.competitorsPerTeam > 1) // if teams
            {
                dataGridLeaderboard.Columns["ColumnTeam"].Visible = true;
            }
            else // if singles
            {
                dataGridLeaderboard.Columns["ColumnTeam"].Visible = false;
            }
            RefreshGrid();
        }

        public void RefreshGrid()
        {
            dataGridLeaderboard.SuspendLayout();
            dataGridLeaderboard.Rows.Clear();

            if (!dataGridLeaderboard.Columns.Contains("ColumnTeam"))
            {
                dataGridLeaderboard.Columns.Insert(5, new DataGridViewColumn(dataGridLeaderboard.Columns[0].CellTemplate) { Name = "ColumnTeam", HeaderText = "Team" });
            }

            int lowestRound = 0;
            int highestRound = 0;
            bool zeroRound = false;
            int numScores = 0;

            getRoundState(out highestRound, out lowestRound, out zeroRound, out numScores);
            
            if (!zeroRound) // If the round that everyone has reached is above or equal to one.
            {
                // Check sorting mode
                if (sortTeams) // if sorting for teams..
                #region Teams
                {
                    dataGridLeaderboard.Columns.Remove(dataGridLeaderboard.Columns["ColumnTeam"]);
                    List<LeaderboardTeam> teams = getTeams();
                    getTeamScoresForRound(teams, lowestRound); // Get the scores for the highest common round for both teams and competitors.
                    reRankScores(teams); // Rank the teams based on score.
                    teams = reorganiseScores(teams); // Re-order the list using the ranks.

                    foreach (LeaderboardTeam t in teams)
                    {
                        int count = 1;
                        foreach (LeaderboardCompetitor c in t.members)
                        {
                            c.rank = count;
                            count++;
                        }
                        reRankScores(t.members); // Rank the competitors based on score.
                        t.members = reorganiseScores(t.members); // Re-order the list using the ranks.
                    }

                    if (highestRound != lowestRound) // Ooooooh, we got a jump-off over here!
                    {
                        for (int round = lowestRound + 1; round < highestRound + 1; round++) // For each round, from the round after the highest common round to the highest round anyone is on...
                        {
                            List<LeaderboardTeam> jumpOffTeams = new List<LeaderboardTeam>();
                            foreach (LeaderboardTeam t in teams)
                            {
                                List<LeaderboardCompetitor> jumpOffCompetitors = new List<LeaderboardCompetitor>();
                                if (!teamOnRound(lowestRound, t)) // If the entire team is not on the highest common round...
                                {
                                    if (!inputTeamJumpOffDisable.Checked) // If we are allowing teams to switch positions..
                                    {
                                        if (teamOnRound(round, t)) // If the entire team's members are on this round..
                                        {
                                            jumpOffTeams.Add(t); // Add the team to the jump-off list.
                                        }
                                    }
                                    for (int i = 0; i < t.members.Count - 1; i++) // For each of the team's members..
                                    {
                                        if (t.members[i].landings.Count == round) // Check if they are on this round. If they are..
                                        {
                                            jumpOffCompetitors = getAdjacentCompetitorsOnSameRound(t.members, i); // Get all adjacent members that are also on that round.
                                            if (jumpOffCompetitors.Count > 1)
                                            {
                                                getScoresForRound(round, jumpOffCompetitors); // Get the new score total for upto round i.
                                                reRankScores(jumpOffCompetitors); // Re-rank the competitors.
                                                jumpOffCompetitors = reorganiseScores(jumpOffCompetitors); // Reorganise the competitors based on their rank.

                                                foreach (LeaderboardCompetitor jc in jumpOffCompetitors) // Insert new ranks into main scores.
                                                {
                                                    t.members[jc.rank - 1] = jc;
                                                }
                                                //i = t.members.IndexOf(jumpOffCompetitors[jumpOffCompetitors.Count - 1]); // Set the for loop enumerator to the end of the jump-off group
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    #region Adding to datagrid

                    if (roundColumnCount < highestRound)
                    {
                        for (int i = 0; i < (highestRound - roundColumnCount); i++)
                        {
                            dataGridLeaderboard.Columns.Add("ColumnRound" + (roundColumnCount + 1 + i).ToString(), "Round " + (roundColumnCount + 1 + i).ToString());
                        }
                        roundColumnCount = highestRound;
                    }

                    if (teams.Count > 0) // If there's any teams at all....
                    {
                        int teamCounter = 0;
                        foreach (LeaderboardTeam t in teams) // Loop through all of the teams...
                        {
                            teamCounter = dataGridLeaderboard.Rows.Add(-1, t.rank, "", t.name); // Add the team name to the datagrid.
                            dataGridLeaderboard["ColumnRound" + lowestRound, teamCounter].Value = t.score;

                            foreach (DataGridViewCell c in dataGridLeaderboard.Rows[teamCounter].Cells) // For all of the cells on the team name row, make them the correct colour.
                            {
                                c.Style.BackColor = UserSettings.Default.leaderboardTeamNameRowColour;
                                c.Style.SelectionBackColor = UserSettings.Default.leaderboardTeamNameRowSelectedColour;
                                c.Style.Font = new Font(dataGridLeaderboard.Font, FontStyle.Bold);
                            }

                            int competitorCounter = 1;
                            foreach (LeaderboardCompetitor c in t.members) // Loop through all of the competitors
                            {
                                dataGridLeaderboard.Rows.Add(c.competitor.ID, c.rank, c.competitor.EID, c.competitor.name, c.competitor.nationality); // and add them to datagrid.
                                int landingCounter = 1;
                                foreach (AccuracyLanding l in c.landings) // Loop through the landings of this competitor
                                {
                                    DataGridViewCell currentCell = dataGridLeaderboard[(4 + landingCounter), teamCounter + competitorCounter];
                                    currentCell.Value = l.score.ToString(); // And add the score for each landing to the datagrid.

                                    currentCell.Style.BackColor = dataGridLeaderboard.DefaultCellStyle.BackColor;
                                    currentCell.Style.SelectionBackColor = dataGridLeaderboard.DefaultCellStyle.SelectionBackColor;

                                    if (inputHighlighting.Checked)
                                    {
                                        currentCell.Style.BackColor = UserSettings.Default.scoreGoodLandingColour;
                                        currentCell.Style.SelectionBackColor = UserSettings.Default.scoreGoodLandingSelectedColour;

                                        if (l.rejumpable)
                                        {
                                            currentCell.Style.BackColor = UserSettings.Default.scoreRejumpableColour;
                                            currentCell.Style.SelectionBackColor = UserSettings.Default.scoreRejumpableSelectedColour;
                                        }

                                        if (l.windDataPrior == null) // If no wind data and therefore manual...
                                        {
                                            currentCell.Style.BackColor = UserSettings.Default.scoreManualColour;
                                            currentCell.Style.SelectionBackColor = UserSettings.Default.scoreManualSelectedColour;
                                        }

                                        if (l.modified)
                                        {
                                            currentCell.Style.BackColor = UserSettings.Default.scoreModifiedColour;
                                            currentCell.Style.SelectionBackColor = UserSettings.Default.scoreModifiedSelectedColour;
                                        }
                                    }
                                    landingCounter++;
                                }
                                competitorCounter++;
                            }
                            teamCounter++;
                        }
                    }
                    #endregion
                }
                #endregion
                else // if sorting for singles..
                #region Singles
                {
                    List<LeaderboardCompetitor> scores = new List<LeaderboardCompetitor>();
                    List<LeaderboardCompetitor> tempScores = new List<LeaderboardCompetitor>(); // Temporary list used for reorganising the main list.

                    foreach (KeyValuePair<EventCompetitor, ObservableCollection<AccuracyLanding>> pair in reportCreator.data)
                    {
                        scores.Add(new LeaderboardCompetitor(pair.Key, pair.Value, 0)); // Compile a full LeaderboardClass List for all competitors
                    }

                    getScoresForRound(lowestRound, scores); // Get the scores upto the highest common round.

                    int count = 1; // Enumerator for foreach loop
                    
                    foreach (LeaderboardCompetitor c in scores) // Setup the ranks.
                    {
                        c.rank = count;
                        count++;
                    }

                    reRankScores(scores);
                    scores = reorganiseScores(scores);

                    #region ComplexSort

                    if (highestRound != lowestRound) // If there are any jump off's occuring...
                    {
                        for (int i = (lowestRound + 1); i < (highestRound + 1); i++) // Starting with the first round after the highest common round...
                        {
                            for (int c = 0; c < scores.Count - 1; c++) // For each competitor
                            {
                                if (scores[c].landings.Count == i) // If that competitor is on round i..
                                {
                                    tempScores = getAdjacentCompetitorsOnSameRound(scores, c); // Get all the adjacent competitors on the same round.
                                    if (tempScores.Count > 1)
                                    {
                                        //c = scores.IndexOf(tempScores[(tempScores.Count - 1)]); // Set the competitor loop to the last competitor in the adjacent group, so it does not select the same group again.
                                        getScoresForRound(i, tempScores); // Get the new score total for upto round i.
                                        reRankScores(tempScores); // Rank these scores
                                        tempScores = reorganiseScores(tempScores); // Reorganise the scores based on rank.

                                        foreach (LeaderboardCompetitor tc in tempScores) // Insert new ranks into main scores.
                                        {
                                            scores[tc.rank - 1] = tc;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    if (roundColumnCount < highestRound)
                    {
                        for (int i = 0; i < (highestRound - roundColumnCount); i++)
                        {
                            dataGridLeaderboard.Columns.Add("ColumnRound" + (roundColumnCount + 1 + i).ToString(), "Round " + (roundColumnCount + 1 + i).ToString());
                        }
                        roundColumnCount = highestRound;
                    }

                    if (scores.Count > 0) // If there's any scores at all....
                    {
                        int competitorCounter = 0;
                        foreach (LeaderboardCompetitor c in scores) // Loop through all of the competitors
                        {
                            string team = "";
                            if (reportCreator.teams != null)
                            {
                                foreach (Team t in reportCreator.teams)
                                {
                                    if (t.Competitors.Contains(c.competitor))
                                    {
                                        team = t.Name;
                                    }
                                }
                            }
                            dataGridLeaderboard.Rows.Add(c.competitor.ID, c.rank, c.competitor.EID, c.competitor.name, c.competitor.nationality, team); // and add them to datagrid.
                            int landingCounter = 1;
                            foreach (AccuracyLanding l in c.landings) // Loop through the landings of this competitor
                            {
                                DataGridViewCell currentCell = dataGridLeaderboard[(5 + landingCounter), competitorCounter];
                                currentCell.Value = l.score.ToString(); // And add the score for each landing to the datagrid.

                                currentCell.Style.BackColor = dataGridLeaderboard.DefaultCellStyle.BackColor;
                                currentCell.Style.SelectionBackColor = dataGridLeaderboard.DefaultCellStyle.SelectionBackColor;

                                if (inputHighlighting.Checked)
                                {
                                    currentCell.Style.BackColor = UserSettings.Default.scoreGoodLandingColour;
                                    currentCell.Style.SelectionBackColor = UserSettings.Default.scoreGoodLandingSelectedColour;

                                    if (l.rejumpable)
                                    {
                                        currentCell.Style.BackColor = UserSettings.Default.scoreRejumpableColour;
                                        currentCell.Style.SelectionBackColor = UserSettings.Default.scoreRejumpableSelectedColour;
                                    }

                                    if (l.windDataPrior == null) // If no wind data and therefore manual...
                                    {
                                        currentCell.Style.BackColor = UserSettings.Default.scoreManualColour;
                                        currentCell.Style.SelectionBackColor = UserSettings.Default.scoreManualSelectedColour;
                                    }

                                    if (l.modified)
                                    {
                                        currentCell.Style.BackColor = UserSettings.Default.scoreModifiedColour;
                                        currentCell.Style.SelectionBackColor = UserSettings.Default.scoreModifiedSelectedColour;
                                    }
                                }
                                landingCounter++;
                            }
                            competitorCounter++;
                        }
                    }
                }
                #endregion
            }
            dataGridLeaderboard.ResumeLayout();
        }

        #region RefreshGrid-Related functions

        /// <summary>
        /// Returns true if the entire team's members are all on the round specified.
        /// </summary>
        private bool teamOnRound(int round, LeaderboardTeam team)
        {
            foreach (LeaderboardCompetitor c in team.members) // For every member..
            {
                if (c.landings.Count != round) // Check if they are on the round specified, and if not..
                {
                    return false; // return false
                }
            }
            // If the check succeeds, return true.
            return true;
        }

        /// <summary>
        /// Compiles the scores of the entire team, and the individual members upto and including the round specified.
        /// </summary>
        private void getTeamScoresForRound(List<LeaderboardTeam> teams, int round)
        {
            foreach (LeaderboardTeam team in teams)
            {
                int teamScoreTotal = 0;
                foreach (LeaderboardCompetitor competitor in team.members)
                {
                    int competitorScoreTotal = 0;
                    if (competitor.landings.Count >= round)
                    {
                        for (int i = 0; i < round; i++)
                        {
                            teamScoreTotal += competitor.landings[i].score;
                            competitorScoreTotal += competitor.landings[i].score;
                        }
                    }
                    competitor.score = competitorScoreTotal;
                }
                team.score = teamScoreTotal;
            }
        }


        /// <summary>
        /// Get's the competitors of the team that has been passed in as well as all of their landing data.
        /// </summary>
        private List<LeaderboardCompetitor> getCompetitorsForTeam(Team team)
        {
            List<LeaderboardCompetitor> competitors = new List<LeaderboardCompetitor>();

            foreach (EventCompetitor c in team.Competitors) // For each competitor in the team..
            {
                if (reportCreator.data.Keys.Contains(c)) // Make sure data for the competitor exists, and if it does...
                {
                    competitors.Add(new LeaderboardCompetitor(c, reportCreator.data[c], 0)); // Add the competitor and all their data to the competitor list.
                }
            }

            return competitors;
        }

        /// <summary>
        /// Collects the team data from reportCreation and compiles it with the competitor and landing data. Gives them all arbitrary ranks.
        /// </summary>
        private List<LeaderboardTeam> getTeams()
        {
            List<LeaderboardTeam> teams = new List<LeaderboardTeam>();

            int count = 1;
            foreach (Team t in reportCreator.teams) // For each team in the event...
            {
                teams.Add(new LeaderboardTeam(0, 0, count, t.Name, getCompetitorsForTeam(t))); // Get all of the team data and add it to the list.
                count++;
            }
            return teams;
        }

        /// <summary>
        /// Takes the scores and reranks them. Lower = lower rank. Uses ranks already existing in the list only. Competitor Version.
        /// </summary>
        private void reRankScores(List<LeaderboardCompetitor> scores)
        {
            List<int> ranks = new List<int>();
            List<int> includedScores = new List<int>();

            foreach (LeaderboardCompetitor c in scores) // Get ranks..
            {
                ranks.Add(c.rank);
            }

            ranks.Sort();

            foreach (LeaderboardCompetitor c in scores) // For the number of scores..
            {
                int lowestScore = 9999;
                int lowestScoreIndex = 0;

                for (int i = 0; i < scores.Count; i++) // Check against other scores.
                {
                    if (scores[i].score < lowestScore && !includedScores.Contains(i)) // If it is lowest so far and hasn't already been used..
                    {
                        lowestScore = scores[i].score;
                        lowestScoreIndex = i;
                    }
                }

                // With the lowest score found..
                includedScores.Add(lowestScoreIndex); // Prevent it from being used again
                scores[lowestScoreIndex].rank = ranks[0];
                ranks.RemoveAt(0);
            }
        }

        /// <summary>
        /// Takes the scores and reranks them. Lower = lower rank. Uses ranks already existing in the list only. Team Version.
        /// </summary>
        private void reRankScores(List<LeaderboardTeam> scores)
        {
            List<int> ranks = new List<int>();
            List<int> includedScores = new List<int>();

            foreach (LeaderboardTeam t in scores) // Get ranks..
            {
                ranks.Add(t.rank);
            }

            ranks.Sort();

            foreach (LeaderboardTeam t in scores) // For the number of scores..
            {
                int lowestScore = 9999;
                int lowestScoreIndex = 0;

                for (int i = 0; i < scores.Count; i++) // Check against other scores.
                {
                    if (scores[i].score < lowestScore && !includedScores.Contains(i)) // If it is lowest so far and hasn't already been used..
                    {
                        lowestScore = scores[i].score;
                        lowestScoreIndex = i;
                    }
                }

                // With the lowest score found..
                includedScores.Add(lowestScoreIndex); // Prevent it from being used again
                scores[lowestScoreIndex].rank = ranks[0];
                ranks.RemoveAt(0);
            }
        }

        /// <summary>
        /// Re-orders the scores based on the rank that has been set. Not on scores. Team Version.
        /// </summary>
        private List<LeaderboardTeam> reorganiseScores(List<LeaderboardTeam> scores)
        {
            List<int> ranks = new List<int>();
            List<LeaderboardTeam> tempScores = new List<LeaderboardTeam>(); // Create a temporary list that will replace the main list when edit's complete.

            foreach (LeaderboardTeam t in scores) // Get ranks..
            {
                ranks.Add(t.rank);
            }

            ranks.Sort();

            for (int i = ranks[0]; i < ranks[0] + scores.Count; i++) // For ranks 1-..?
            {
                foreach (LeaderboardTeam t in scores) // Find the one that has that rank.
                {
                    if (t.rank == i)
                    {
                        tempScores.Add(t);
                    }
                }
            }
            return tempScores; // Replace main list with edited version.
        }

        /// <summary>
        /// Re-orders the scores based on the rank that has been set. Not on scores. Competitor Version.
        /// </summary>
        private List<LeaderboardCompetitor> reorganiseScores(List<LeaderboardCompetitor> scores)
        {
            List<int> ranks = new List<int>();
            List<LeaderboardCompetitor> tempScores = new List<LeaderboardCompetitor>(); // Create a temporary list that will replace the main list when edit's complete.

            foreach (LeaderboardCompetitor c in scores) // Get ranks..
            {
                ranks.Add(c.rank);
            }

            ranks.Sort();

            for (int i = ranks[0]; i < ranks[0] + scores.Count; i++) // For ranks 1-..?
            {
                foreach (LeaderboardCompetitor c in scores) // Find the one that has that rank.
                {
                    if (c.rank == i)
                    {
                        tempScores.Add(c);
                    }
                }
            }
            return tempScores; // Replace main list with edited version.
        }

        /// <summary>
        /// Groups together adjacent scores with same round. Used for jump-offs.
        /// </summary>
        private List<LeaderboardCompetitor> getAdjacentCompetitorsOnSameRound(List<LeaderboardCompetitor> scores, int currentCompetitor)
        {
            List<LeaderboardCompetitor> jumpOffCandidates = new List<LeaderboardCompetitor>();

            for (int i = currentCompetitor; i < scores.Count; i++)
            {
                if (scores[i].landings.Count >= scores[currentCompetitor].landings.Count)
                {
                    jumpOffCandidates.Add(scores[i]);
                }
                else
                {
                    return jumpOffCandidates;
                }
            }
            return jumpOffCandidates;
        }


        /// <summary>
        /// Gets the highest and lowest rounds that people have reached, and ensures that nobody is on round zero. (Everyone has a score)
        /// </summary>
        private void getRoundState(out int highestRound, out int lowestRound, out bool zeroRound, out int numScores)
        {
            highestRound = 0;
            lowestRound = 9999;
            zeroRound = false;
            numScores = 0;

            foreach (KeyValuePair<EventCompetitor, ObservableCollection<AccuracyLanding>> pair in reportCreator.data) // Determine the lowest round - the round that everyone has reached. If zero round true, some people still have yet to complete the first round.
            {
                if (pair.Value.Count < lowestRound && pair.Value.Count > 0)
                {
                    lowestRound = pair.Value.Count;
                }

                if (pair.Value.Count > highestRound)
                {
                    highestRound = pair.Value.Count;
                }

                if (pair.Value.Count == 0) // If anyone has yet to complete a round, make zeroRound true and do not organise the list.
                {
                    zeroRound = true;
                }
                numScores++;
            }
        }

        /// <summary>
        /// Returns the score totals for each competitor given at the round given.
        /// </summary>
        private void getScoresForRound(int round, List<LeaderboardCompetitor> competitors)
        {
            int count = 0; // Enumerator for loop
            foreach (LeaderboardCompetitor c in competitors)
            {
                int currentScore = 0;
                for (int i = 0; i < round; i++)
                {
                    currentScore += c.landings[i].score; // combine the scores of all the rounds up until the highest round.
                }
                c.score = currentScore;
                count++;
            }
        }

        #endregion

        #region Control Events

        /// <summary>
        /// Closing event for the undocked form.
        /// </summary>
        private void undockedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tableLayoutPanel1.Controls.Add(dataGridLeaderboard, 0, 0);
            tableLayoutPanel1.SetRowSpan(dataGridLeaderboard, 10);
            undockedForm = null;
            inputToggleDock.Text = "Undock";
        }

        private void inputSortSwitch_Click(object sender, EventArgs e)
        {
            if (sortTeams) // if currently sorting for teams,
            {
                sortTeams = false; // Sort for singles instead.
                RefreshGrid();
                inputSortSwitch.Text = "Sort as Teams";
                labelSortType.Text = "Currently Sorting: Singles";
            }
            else // if currently sorting for singles.
            {
                sortTeams = true; // Sort for teams instead.
                RefreshGrid();
                inputSortSwitch.Text = "Sort as Singles";
                labelSortType.Text = "Currently Sorting: Teams";
            }
        }

        private void inputToggleDock_Click(object sender, EventArgs e)
        {
            if (undockedForm == null) // If not already docked,
            {
                undockedForm = new Form();
                undockedForm.Controls.Add(dataGridLeaderboard);
                undockedForm.Text = reportName;
                undockedForm.Icon = CMS.Properties.Resources.Icon;
                undockedForm.FormClosed += new FormClosedEventHandler(undockedForm_FormClosed);
                undockedForm.Show();
                tableLayoutPanel1.Controls.Remove(dataGridLeaderboard);
                inputToggleDock.Text = "Dock";
            }
            else // if already docked, close it and run the close event instead.
            {
                undockedForm.Close();
            }
        }

        private void inputAutoUpdate_Click(object sender, EventArgs e)
        {
            autoUpdate = !autoUpdate;
            if (autoUpdate)
            {
                inputAutoUpdate.ForeColor = Color.Green;
                // TODO: Make delegate to force refresh on every update of data.
            }
            else { inputAutoUpdate.ForeColor = Color.Red; }
        }

        private void inputDeselectGrid_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridLeaderboard.Rows)
            {
                r.Selected = false;
            }
        }

        private void inputSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialogue = new SaveFileDialog();
            saveFileDialogue.DefaultExt = "BMP";
            saveFileDialogue.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            display = new Bitmap(dataGridLeaderboard.Width, dataGridLeaderboard.Height);
            dataGridLeaderboard.DrawToBitmap(display, dataGridLeaderboard.ClientRectangle);
            DialogResult result = saveFileDialogue.ShowDialog();
            if (result == DialogResult.OK)
            {
                display.Save(saveFileDialogue.FileName);
            }
        }

        private void inputExportToExcel_Click(object sender, EventArgs e)
        {
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = xlApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            foreach (DataGridViewColumn col in dataGridLeaderboard.Columns)
            {
                if (col.Index != 0)
                {
                    ws.Cells[1, col.Index].Value = col.HeaderText;
                }
            }
            ws.Cells[1, 1].EntireRow.Font.Bold = true;

            foreach (DataGridViewRow row in dataGridLeaderboard.Rows)
            {
                foreach (DataGridViewCell c in row.Cells)
                {
                    if (c.ColumnIndex != 0)
                    {
                        ws.Cells[row.Index + 2, c.ColumnIndex].Value2 = c.Value;
                    }
                }
            }
            xlApp.Visible = true;
        }

        private void inputPrint_Click(object sender, EventArgs e)
        {

        }

        private void inputClose_Click(object sender, EventArgs e)
        {
            reportCreator.RemoveReport(this);
        }

        private void inputHighlighting_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void inputTeamJumpOffDisable_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
        #endregion
}
