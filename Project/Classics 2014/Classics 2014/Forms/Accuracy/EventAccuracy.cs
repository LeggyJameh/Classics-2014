using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace CMS.Accuracy
{
    partial class EventAccuracy : UserControl
    {
        Accuracy_Event Connected_Event;
        int CurrentCellValue;
        bool TeamedEvent;
        Reports.ReportCreation CurrentReportForm;
        int RoundNumber = 1;
        bool Admin = false;
        accuracyEventLandingColumn LandingList;
        Ruleset.AccuracyRules rules;

        #region Loading

        #endregion

        #region General

        #endregion

        #region Control Events

        #endregion

        public EventAccuracy(Accuracy_Event Event)
        {
            Connected_Event = Event;
            rules = (Ruleset.AccuracyRules)Event.Rules;
            InitializeComponent();
            groupboxControllerListArea.Controls.Add(Connected_Event.controller.column);
            labelName.Text = "Accuracy Event " + Connected_Event.Name;
            LoadTeamsIntoGrid();
             CurrentReportForm = new Reports.ReportCreation(Connected_Event.SQL_Controller, Connected_Event, Connected_Event.EventID);
            CurrentReportForm.Dock = DockStyle.Fill;
            tabControlEvent.TabPages[1].Controls.Add(CurrentReportForm);
            Admin = true;
            LandingList = Connected_Event.controller.column;
            if (Admin)
            {
                dataGridViewScore.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
        }

        public EventAccuracy(Accuracy_Event Event, bool Admin)
        {
            this.Admin = true;
            Connected_Event = Event;
            InitializeComponent();
            if (Admin)
            {
                dataGridViewScore.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
            labelName.Text = "Accuracy Event " + Connected_Event.Name;
            LoadTeamsIntoGrid();
        }

        private void LoadTeamsIntoGrid()
        {
            if (Connected_Event.Teams.Count > 1) // If teams, not singles.
            {
                TeamedEvent = true;
                for (int Ti = 0; Ti < Connected_Event.Teams.Count; Ti++)
                {
                    for (int Ci = 0; Ci < Connected_Event.Teams[Ti].Competitors.Count; Ci++)
                    {
                        dataGridViewScore.Rows.Add(Connected_Event.Teams[Ti].Competitors[Ci].ID, Connected_Event.Teams[Ti].Competitors[Ci].name, Connected_Event.Teams[Ti].Competitors[Ci].group, Connected_Event.Teams[Ti].Competitors[Ci].nationality, Connected_Event.Teams[Ti].Name);
                    }
                }
            }
            else // If singles
            {
                for (int Ti = 0; Ti < Connected_Event.Teams.Count; Ti++)
                {
                    for (int Ci = 0; Ci < Connected_Event.Teams[Ti].Competitors.Count; Ci++)
                    {
                        dataGridViewScore.Rows.Add(Connected_Event.Teams[Ti].Competitors[Ci].ID, Connected_Event.Teams[Ti].Competitors[Ci].name, Connected_Event.Teams[Ti].Competitors[Ci].group, Connected_Event.Teams[Ti].Competitors[Ci].nationality, "N/A");
                    }
                }
            }
        }

        public void LoadExistingEventLandings() // Look at
        {
            List<AccuracyLanding> Landings = (List<AccuracyLanding>)Connected_Event.SQL_Controller.GetLandingsForEvent(Connected_Event.EventID, EventType.INTL_ACCURACY);

            for (int i = 0; i < Landings.Count; i++)
            {
                Connected_Event.controller.loadLanding(Landings[i]);
                for (int i2 = 0; i2 < dataGridViewScore.Rows.Count; i2++)
                {
                    while (Landings[i].round + 4 >= dataGridViewScore.Columns.Count)
                    {
                        RoundNumber++;
                        DataGridViewColumn NewColumn = (DataGridViewColumn)dataGridViewScore.Columns[4].Clone();
                        NewColumn.Name = "ColumnRound" + RoundNumber;
                        NewColumn.HeaderText = "Round " + RoundNumber;
                        dataGridViewScore.Columns.Add(NewColumn);
                    }
                    if (Convert.ToInt16(dataGridViewScore.Rows[i2].Cells[0].Value) == Landings[i].UID)
                    {
                        int Column = Landings[i].round + 4;

                        dataGridViewScore.Rows[i2].Cells[Column].Value = Landings[i].score;
                        dataGridViewScore.Rows[i2].Cells[Column].Style.BackColor = Color.LightGreen;

                        if (Landings[i].modified == true) // If score has been manually reset
                        {
                            dataGridViewScore.Rows[i2].Cells[Column].Style.BackColor = Color.Yellow;
                        }

                        if (Landings[i].windDataPrior == null) // If there is no wind data and therefore a manual entry.
                        {
                            dataGridViewScore.Rows[i2].Cells[Column].Style.BackColor = Color.LightBlue;
                        }

                        if (Landings[i].rejumpable == true)
                        {
                            dataGridViewScore.Rows[i2].Cells[Column].Style.ForeColor = Color.Red;
                            dataGridViewScore.Rows[i2].Cells[Column].Style.Font = new Font(DefaultFont, FontStyle.Bold);
                        }

                        Landings[i].dataGridCell = dataGridViewScore.Rows[i2].Cells[Column];
                    }
                }

                Connected_Event.controller.loadLanding((AccuracyLanding)Landings[i]);
                //if (Landings[i].UID == -1)
                //{
                //    Connected_Event.controller.column.AddLanding(
                //    dataGridViewLandings.Rows.Add(Landings[i].ID, "N/A", Landings[i].score, true);
                //}
                //else
                //{
                //    dataGridViewLandings.Rows.Add(Landings[i].ID, "N/A", Landings[i].score, true);
                //    dataGridViewLandings.Rows[dataGridViewLandings.Rows.Count - 2].Visible = false;
                //}
            }
        }

        public void FormatLandingToRejumpable(AccuracyLanding L)
        {
            if (L.dataGridCell != null)
            {
                dataGridViewScore[L.dataGridCell.ColumnIndex, L.dataGridCell.RowIndex].Style.ForeColor = Color.Red;
                dataGridViewScore[L.dataGridCell.ColumnIndex, L.dataGridCell.RowIndex].Style.Font = new Font(DefaultFont, FontStyle.Bold);
            }
        }

        private void SelectFirstUncompletedCompetitorScore()
        {
            for (int i = 0; i < dataGridViewScore.Rows.Count; i++)
            {
                if (dataGridViewScore.Rows[i].Cells[4 + RoundNumber].Value == null)
                {
                    dataGridViewScore.Rows[i].Selected = true;
                    return;
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Connected_Event.Exit();
        }

        private void buttonEditLanding_Click(object sender, EventArgs e)
        {
            AccuracyLanding currentLanding;
            if(dataGridViewScore.SelectedCells.Count != 0)
            {
                if (dataGridViewScore.SelectedCells[0].Value != null)
                {
                    if (dataGridViewScore.SelectedCells[0].ColumnIndex >= 4)
                    {
                        currentLanding = Connected_Event.controller.getLandingFromCell(dataGridViewScore.SelectedCells[0]);
                        currentLanding.score = MessageBoxes.ModifyScore(Convert.ToInt16(dataGridViewScore.SelectedCells[0].Value), rules.maxScore);
                        if (currentLanding.score != -1)
                        {
                            dataGridViewScore.SelectedCells[0].Value = currentLanding.score;
                            dataGridViewScore.SelectedCells[0].Style.BackColor = Color.Yellow;
                            currentLanding.modified = true;

                            Connected_Event.SQL_Controller.ModifyLanding(currentLanding);
                            CurrentReportForm.Update(currentLanding.UID, currentLanding.round, currentLanding.dataGridCell);
                        }
                    }
                }
            }
        }

        private void buttonManualLanding_Click(object sender, EventArgs e)
        {
            AccuracyLanding CurrentLanding;
            if (dataGridViewScore.SelectedCells.Count != 0)
            {
                if (dataGridViewScore.SelectedCells[0].Value == null)
                {
                    if (dataGridViewScore.SelectedCells[0].ColumnIndex >= 4)
                    {
                        int NewScore = MessageBoxes.ModifyScore(Convert.ToInt16(dataGridViewScore.SelectedCells[0].Value), rules.maxScore);
                        if (NewScore != -1)
                        {
                            dataGridViewScore.SelectedCells[0].Value = NewScore;
                            dataGridViewScore.SelectedCells[0].Style.BackColor = Color.LightBlue;

                            CurrentLanding = new AccuracyLanding(DateTime.Now.ToLongTimeString(), NewScore, false, false, true, dataGridViewScore.SelectedCells[0].ColumnIndex - 4, null, null);
                            CurrentLanding.UID = Convert.ToInt16(dataGridViewScore.SelectedCells[0].OwningRow.Cells[0].Value);
                            CurrentLanding.eventID = Connected_Event.EventID;
                            CurrentLanding.ID = Connected_Event.SQL_Controller.CreateLanding(CurrentLanding);
                            CurrentLanding.dataGridCell = dataGridViewScore.SelectedCells[0];

                            Connected_Event.controller.loadLanding(CurrentLanding);

                            CurrentReportForm.Update(CurrentLanding.UID, CurrentLanding.round , CurrentLanding.dataGridCell);
                        }
                    }
                }
            }
        } 

        private void buttonNextRound_Click(object sender, EventArgs e)
        {
            RoundNumber++;
            DataGridViewColumn NewColumn = (DataGridViewColumn)dataGridViewScore.Columns[4].Clone();
            NewColumn.Name = "ColumnRound" + RoundNumber;
            NewColumn.HeaderText = "Round " + RoundNumber;
            dataGridViewScore.Columns.Add(NewColumn);
        }

        private bool SelectFirstVisibleRowOnDataGrid(DataGridView dataGrid)
        {
            if (Admin)
            {
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Visible == true)
                    {
                            dataGrid.ClearSelection();
                            dataGrid.Rows[i].Selected = true;
                    }
                }
                return false;
            }
            else
            {
                dataGrid.ClearSelection();
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Visible == true)
                    {
                        dataGrid.Rows[i].Selected = true;
                        return true;
                    }
                }
                return false;
            }
        }

        private void buttonUnassignLanding_Click(object sender, EventArgs e) 
        {
            if (dataGridViewScore.SelectedCells.Count > 0)
            {
                if (dataGridViewScore.SelectedCells[0].ColumnIndex > 4)
                {
                    AccuracyLanding currentLanding = Connected_Event.controller.getLandingFromCell(dataGridViewScore.SelectedCells[0]);
                    Connected_Event.controller.unAssignLanding(currentLanding);
                }
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if ((dataGridViewScore.SelectedCells.Count > 0) && (Admin))
            {
                if (dataGridViewScore.SelectedCells[0].Value == null)
                {
                    AccuracyLanding currentLanding = Connected_Event.controller.getColumnLanding();
                    if (currentLanding != null)
                    {
                        int UID = Convert.ToInt16(dataGridViewScore.Rows[dataGridViewScore.SelectedCells[0].RowIndex].Cells[0]);

                        currentLanding.UID = UID;
                        currentLanding.dataGridCell = dataGridViewScore.SelectedCells[0];
                        currentLanding.round = dataGridViewScore.SelectedCells[0].ColumnIndex - 4;
                        Connected_Event.controller.assignLanding(currentLanding);
                        CurrentReportForm.Update(UID, currentLanding.round, currentLanding.dataGridCell);
                    }
                }
            }
        }

        private void buttonRenameCompetitor_Click(object sender, EventArgs e)
        {
            string NewName = MessageBoxes.ModifyCompetitorName();
            int UID = Convert.ToInt16(dataGridViewScore.SelectedRows[0].Cells[0].Value);
            string Team = Convert.ToString(dataGridViewScore.SelectedRows[0].Cells[2].Value);
            string Nationality = Convert.ToString(dataGridViewScore.SelectedRows[0].Cells[3].Value);

            if (Connected_Event.SQL_Controller.ModifyCompetitor(UID, NewName, Team, Nationality))
            {
                dataGridViewScore.SelectedRows[0].Cells[1].Value = NewName;
            }
            CurrentReportForm.Update();
        }

        private void buttonRejump_Click(object sender, EventArgs e)
        {
            if (dataGridViewScore.SelectedCells.Count > 0)
            {
                if (dataGridViewScore.SelectedCells[0].ColumnIndex > 4)
                {
                    if (dataGridViewScore.SelectedCells[0].Value != null)
                    {
                        AccuracyLanding landing = Connected_Event.controller.getLandingFromCell(dataGridViewScore.SelectedCells[0]);

                        Connected_Event.controller.removeLanding(landing.ID);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a landing to rejump and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a landing to rejump and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //and here

        private void dataGridViewScore_SelectionChanged(object sender, EventArgs e)
        {
            if (Admin)
            {
                if ((dataGridViewScore.SelectedCells.Count > 0)&&(dataGridViewScore.SelectedCells[0].ColumnIndex < 5))
                {
                    dataGridViewScore.ClearSelection();
                }
            }
        }
    }
}
