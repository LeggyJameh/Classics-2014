using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS.Accuracy
{
    partial class EventAccuracy : UserControl
    {
        #region Variables and the such like
        private Accuracy_Event Connected_Event;
        private accuracyEventLandingColumn landingList;
        private Reports.ReportCreation currentReportForm;
        private Dictionary<EventCompetitor, List<AccuracyLanding>> data;
        private Ruleset.AccuracyRules rules;

        // Colours that are used in the grid to display properties about the landings.
        public Color modifiedScoreColour = Color.Yellow;
        public Color modifiedScoreSelectedColor = Color.Olive;
        public Color manualScoreColour = Color.LightBlue;
        public Color manualScoreSelectedColor = Color.SteelBlue;
        public Color rejumpableColour = Color.Red;
        public Color rejumpableSelectedColor = Color.DarkRed;
        public Color goodLandingColour = Color.LightGreen;
        public Color goodLandingSelectedColor = Color.ForestGreen;

        public UpdateAccuracyDataDelegate reportsUpdateDelegate;
        public int roundNumber = 1;

        const int columnCountUptofirstRound = 4;
        #endregion

        /// <summary>
        /// Init for event. landings can be null if event is new.
        /// </summary>
        public EventAccuracy(Accuracy_Event connected_Event, List<AccuracyLanding> landings)
        {
            this.Connected_Event = connected_Event;
            rules = (Ruleset.AccuracyRules)Connected_Event.Rules;
            InitializeComponent();
            labelEventName.Text = Connected_Event.Name;
            loadLandingsAndCompetitors(landings);
            loadData();
            checkEventIDStatus();
            checkIsSingles();
            addControllerColumn();
            addReportFormToTab();
            refreshGrid();
        }

        #region Setup and layout
        private void addControllerColumn()
        {
            landingList = Connected_Event.controller.column;
            tableLayoutPanelEvent.Controls.Add(landingList);
            tableLayoutPanelEvent.SetColumn(landingList, 9);
            tableLayoutPanelEvent.SetColumnSpan(landingList, 2);
            tableLayoutPanelEvent.SetRow(landingList, 0);
            tableLayoutPanelEvent.SetRowSpan(landingList, 3);
        }

        private void addReportFormToTab()
        {
            currentReportForm = new Reports.ReportCreation(Connected_Event, this, data);
            currentReportForm.Dock = DockStyle.Fill;
            tabControlEvent.TabPages[1].Controls.Add(currentReportForm);
        }

        /// <summary>
        /// Checks all of the competitors for existance of an event ID. If no EID exists, hides the eventID column in the main datagrid.
        /// </summary>
        private void checkEventIDStatus()
        {
            bool eventIDsExist = false;
            foreach (EventCompetitor c in data.Keys)
            {
                if (c.EID != "" && c.EID != null)
                {
                    eventIDsExist = true;
                }
            }

            if (!eventIDsExist) // If no competitor has an event ID...
            {
                dataGridScores.Columns[1].Visible = false;
            }
        }

        /// <summary>
        /// Checks all of the teams for count. If all are equal to one, hides team column in main datagrid.
        /// </summary>
        private void checkIsSingles()
        {
            bool singles = true;

            foreach (Team t in Connected_Event.Teams)
            {
                if (t.Competitors.Count > 1)
                {
                    singles = false;
                }
            }

            if (singles)
            {
                dataGridScores.Columns[3].Visible = false;
            }
        }

        #endregion

        #region Loading

        /// <summary>
        /// Creates the dictionary, loads all of the competitors into it and adds any existing landings.
        /// </summary>
        private void loadLandingsAndCompetitors(List<AccuracyLanding> landings)
        {
            data = new Dictionary<EventCompetitor, List<AccuracyLanding>>();
            foreach (Team t in Connected_Event.Teams)
            {
                foreach (EventCompetitor c in t.Competitors)
                {
                    data.Add(c, new List<AccuracyLanding>());
                }
            }

            if (landings != null)
            {
                foreach (AccuracyLanding l in landings)
                {
                    foreach (EventCompetitor c in data.Keys)
                    {
                        if (l.UID == c.ID)
                        {
                            data[c].Add(l);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the round to the highest created value and creates enough columns in the datagrid to support it.
        /// </summary>
        private void loadData()
        {
            int currentHighestRoundNum = roundNumber;

            foreach (EventCompetitor c in data.Keys)
            {
                foreach (AccuracyLanding l in data[c])
                {
                    if (l.round > currentHighestRoundNum) // Getting the round that the event is on via the highest round counter on the landings.
                    {
                        currentHighestRoundNum = l.round;
                    }
                }
            }

            if (currentHighestRoundNum > (dataGridScores.Columns.Count - columnCountUptofirstRound)) // Adding additional columns if required.
            {
                int roundsToAdd = currentHighestRoundNum - (dataGridScores.Columns.Count - columnCountUptofirstRound);
                for (int i = 0; i < roundsToAdd; i++)
                {
                    dataGridScores.Columns.Add("ColumnR" + (2 + i), "Round " + (2 + i));
                }
            }

            roundNumber = currentHighestRoundNum;
        }

        #endregion

        #region General

        /// <summary>
        /// Completely refreshes the score grid and maintains the selection.
        /// </summary>
        private void refreshGrid()
        {
            dataGridScores.SuspendLayout();
            dataGridScores.Rows.Clear();

            if (reportsUpdateDelegate != null)
            {
                reportsUpdateDelegate(data);
            }

            foreach (EventCompetitor c in data.Keys)
            {
                string currentTeam = getCompetitorTeamName(c);

                if (currentTeam != "") // Previous function can return "" so check to ensure it doesn't.
                {
                    dataGridScores.Rows.Add(c.ID, c.EID, c.name, currentTeam);
                    foreach (AccuracyLanding l in data[c])
                    {
                        DataGridViewCell currentCell = dataGridScores.Rows[dataGridScores.Rows.Count - 1].Cells[l.round + (columnCountUptofirstRound -1 /* -1 because index not count */)];
                        currentCell.Value = l.score;
                        currentCell.Tag = "ID" + l.ID + "|UID" + l.UID; // Tagging up the cell for reference points.
                        currentCell.Style.BackColor = goodLandingColour;
                        currentCell.Style.SelectionBackColor = goodLandingSelectedColor;

                        if (l.rejumpable) // If rejumpable
                        {
                            currentCell.Style.BackColor = rejumpableColour;
                            currentCell.Style.SelectionBackColor = rejumpableSelectedColor;
                        }

                        if (l.windDataPrior == null) // If no wind data and therefore manual
                        {
                            currentCell.Style.BackColor = manualScoreColour;
                            currentCell.Style.SelectionBackColor = manualScoreSelectedColor;
                        }

                        if (l.modified) // If Modified score
                        {
                            currentCell.Style.BackColor = modifiedScoreColour;
                            currentCell.Style.SelectionBackColor = modifiedScoreSelectedColor;
                        }
                    }
                }
            }

            dataGridScores.ResumeLayout();
            selectFirstBlankCell();
        }

        /// <summary>
        /// Returns the name of the team for the competitor.
        /// </summary>
        private string getCompetitorTeamName(EventCompetitor competitor)
        {
            foreach (Team t in Connected_Event.Teams)
            {
                foreach (EventCompetitor c in t.Competitors)
                {
                    if (c.ID == competitor.ID)
                    {
                        return t.Name;
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// Selects the first blank cell in the table.
        /// </summary>
        private void selectFirstBlankCell()
        {
            DataGridViewCell bestCell = dataGridScores.Rows[0].Cells[columnCountUptofirstRound];

            foreach (DataGridViewRow r in dataGridScores.Rows)
            {
                foreach (DataGridViewCell c in r.Cells)
                {
                    if (c.Value == null || c.Value.ToString() == "")
                    {
                        if ((c.ColumnIndex < bestCell.ColumnIndex || bestCell.Value != null) && c.ColumnIndex >= (columnCountUptofirstRound - 1))
                        {
                            bestCell = c;
                        }
                    }
                }
            }

            dataGridScores.ClearSelection();
            bestCell.Selected = true;
        }

        /// <summary>
        /// Gets a list of the currently selected cells. Will return an empty list if none.
        /// </summary>
        private List<DataGridViewCell> getSelectedCells()
        {
            List<DataGridViewCell> cells = new List<DataGridViewCell>();

            foreach (DataGridViewCell c in dataGridScores.SelectedCells)
            {
                cells.Add(c);
            }

            return cells;
        }

        /// <summary>
        /// Gets the first selected score cell and returns it. Returns null if none found.
        /// </summary>
        private DataGridViewCell getFirstScoreCell()
        {
            List<DataGridViewCell> cells = getSelectedCells();

            if (cells.Count > 0) // If previous function did not return empty.
            {
                foreach (DataGridViewCell c in cells)
                {
                    if (c.ColumnIndex >= columnCountUptofirstRound) // Ensure that it's a score cell column index.
                    {
                        return c;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the landing from a cell. Returns null if none can be found.
        /// </summary>
        private AccuracyLanding getLandingFromCell(DataGridViewCell cell)
        {
            
            if (cell.Tag != null)
            {
                string tag = cell.Tag.ToString();
                int seperator = tag.IndexOf("|");

                int ID = Convert.ToInt16(tag.Substring(2, seperator - 2));
                int UID = Convert.ToInt16(tag.Substring(seperator + 4));

                foreach (EventCompetitor c in data.Keys)
                {
                    if (c.ID == UID)
                    {
                        foreach (AccuracyLanding l in data[c])
                        {
                            if (l.ID == ID)
                            {
                                return l;
                        }
                    }
                }
            }
            }
            return null;
        }

        /// <summary>
        /// Gets the round from the currently selected cell. Returns -1 if unknown.
        /// </summary>
        private int getRoundFromCell(DataGridViewCell cell)
        {
            string name = dataGridScores.Columns[cell.ColumnIndex].Name;
            if (name.Substring(0, 7) == "ColumnR")
            {
                return Convert.ToInt16(name.Substring(7));
            }
            return -1;
        }

        /// <summary>
        /// Gets the competitor associated with the selected cell. Returns null if none is found.
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private EventCompetitor getCompetitorFromCell(DataGridViewCell cell)
        {
            int UID = Convert.ToInt16(dataGridScores.Rows[cell.RowIndex].Cells[0].Value);

            foreach (EventCompetitor c in data.Keys)
            {
                if (c.ID == UID)
                {
                    return c;
                }
            }
            return null;
        }

        /// <summary>
        /// Removes the specified landing from the event, the controller and the database.
        /// </summary>
        private void removeLanding(AccuracyLanding landing, EventCompetitor competitor)
        {
            data[competitor].Remove(landing);
            refreshGrid();
            Connected_Event.controller.removeLanding(landing.ID);
            landing = null;
        }

        /// <summary>
        /// Assigns the landing in the event, the controller and the database.
        /// </summary>
        private void assignLanding(AccuracyLanding landing, EventCompetitor competitor, DataGridViewCell cell)
        {
            landing.UID = competitor.ID;
            landing.round = getRoundFromCell(cell);
            landing.eventID = Connected_Event.EventID;
            data[competitor].Add(landing);
            Connected_Event.controller.assignLanding(landing);
        }

        /// <summary>
        /// Adds a manual landing to the event, the controller and the database. MANUAL LANDINGS ONLY.
        /// </summary>
        private void addLanding(AccuracyLanding landing, EventCompetitor competitor)
        {
            if (landing.windDataPrior == null) // If manual
            {
                landing.UID = competitor.ID;
                landing.eventID = Connected_Event.EventID;
                landing.ID = Connected_Event.SQL_Controller.CreateLanding(landing);
                data[competitor].Add(landing);
                Connected_Event.controller.loadLanding(landing);
            }
        }

        /// <summary>
        /// Unassigns the landing in the event, the controller and the database.
        /// </summary>
        private void unAssignLanding(AccuracyLanding landing, EventCompetitor competitor)
        {
            Connected_Event.controller.unAssignLanding(landing);
            data[competitor].Remove(landing);
        }

        #endregion

        #region Control Events

        private void inputManualLanding_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = getFirstScoreCell();
            AccuracyLanding newLanding;
            EventCompetitor competitor;
            int round = 0;

            if (cell != null)
            {
                if (getLandingFromCell(cell) == null)
                {
                    competitor = getCompetitorFromCell(cell);
                    round = getRoundFromCell(cell);
                    if (round > 0)
                    {
                        newLanding = MessageBoxes.CreateAccuracyLanding(Connected_Event, round);
                        if (newLanding != null)
                        {
                            if (competitor != null)
                            {
                                addLanding(newLanding, competitor);
                            }
                        }
                    }
                    else
                    {
                        MBox.Generic.Show(MBox.GenericMBoxType.CellNotValid);
                    }
                }
                else
                {
                    MBox.Generic.Show(MBox.GenericMBoxType.LandingAlreadyExists);
                }
            }
            else
            {
                MBox.Generic.Show(MBox.GenericMBoxType.NoScoreSelected);
            }
            refreshGrid();
        }

        private void inputEditScore_Click(object sender, EventArgs e)
        {
            DataGridViewCell currentCell = getFirstScoreCell();
            AccuracyLanding currentlanding;
            if (currentCell != null)
            {
                currentlanding = getLandingFromCell(currentCell);

                if (currentlanding != null)
                {
                    currentlanding.score = MessageBoxes.ModifyScore(currentlanding.score, rules.maxScore);
                    currentlanding.modified = true;
                }
                else
                {
                    MBox.Generic.Show(MBox.GenericMBoxType.NoScoreSelected);
                }
            }
            else
            {
                MBox.Generic.Show(MBox.GenericMBoxType.NoScoreSelected);
            }
            refreshGrid();
        }

        private void inputUnassignLanding_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = getFirstScoreCell();
            AccuracyLanding landing;
            EventCompetitor competitor;

            if (cell != null)
            {
                landing = getLandingFromCell(cell);
                competitor = getCompetitorFromCell(cell);

                if (landing != null)
                {
                    if (competitor != null)
                    {
                        unAssignLanding(landing, competitor);
                    }
                }
                else
                {
                    MBox.Generic.Show(MBox.GenericMBoxType.NoLandingSelected);
                }
            }
            else
            {
                MBox.Generic.Show(MBox.GenericMBoxType.NoLandingSelected);
            }
            refreshGrid();
        }

        private void inputNextRound_Click(object sender, EventArgs e)
        {
            roundNumber++;
            dataGridScores.Columns.Add("ColumnR" + roundNumber, "Round " + roundNumber);
        }

        private void inputConfirm_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = getFirstScoreCell();
            AccuracyLanding landing = Connected_Event.controller.getColumnLanding();
            EventCompetitor competitor;

            if (landing != null)
            {
                if (cell != null)
                {
                    if (getLandingFromCell(cell) == null)
                    {
                        competitor = getCompetitorFromCell(cell);
                        if (competitor != null)
                        {
                            assignLanding(landing, competitor, cell);
                        }
                    }
                }
                else
                {
                    MBox.Generic.Show(MBox.GenericMBoxType.CellNotValid);
                }
            }
            else
            {
                MBox.Generic.Show(MBox.GenericMBoxType.NoLandingSelected);
            }
            refreshGrid();
        }

        private void inputRejump_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = getFirstScoreCell();
            AccuracyLanding landing;
            EventCompetitor competitor;

            if (cell != null)
            {
                landing = getLandingFromCell(cell);
                competitor = getCompetitorFromCell(cell);
                if (landing != null)
                {
                    if (competitor != null)
                    {
                        removeLanding(landing, competitor);
                    }
                }
            }
            refreshGrid();
        }

        private void inputClose_Click(object sender, EventArgs e)
        {
            // Check for landings in progress?
            if (MBox.Generic.Show(MBox.GenericMBoxType.ClosingCheckNoSave) == DialogResult.Yes)
            {
                Connected_Event.Exit();
            }
        }
    }
        #endregion
}
