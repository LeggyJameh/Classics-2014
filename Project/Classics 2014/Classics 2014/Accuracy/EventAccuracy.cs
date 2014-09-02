using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace Classics_2014.Accuracy
{
    partial class EventAccuracy : UserControl
    {
        Accuracy_Event Connected_Event;
        TabControl tabControl;
        int CurrentCellValue;
        bool TeamedEvent;
        int RoundNumber = 1;
        bool Admin = false;

        public EventAccuracy(Accuracy_Event Event, TabControl Main)
        {
            Connected_Event = Event;
            tabControl = Main;
            InitializeComponent();
            labelName.Text = "Accuracy Event " + Connected_Event.Name;
            LoadTeamsIntoGrid();
        }

        public EventAccuracy(Accuracy_Event Event, TabControl Main, bool Admin)
        {
            this.Admin = Admin;
            if (Admin)
            {
                dataGridViewScore.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
            Connected_Event = Event;
            tabControl = Main;
            InitializeComponent();
            labelName.Text = "Accuracy Event " + Connected_Event.Name;
            LoadTeamsIntoGrid();
        }

        public void MethodAddLanding(AccuracyLanding Landing)
        {
            dataGridViewLandings.Invoke((MethodInvoker)(() => dataGridViewLandings.Rows.Add(Landing.ID, Landing.TimeOfLanding, Landing.score, "No")));
        }

        public void MakeLandingComplete(int LandingID)
        {
            for (int i = 0; i < dataGridViewLandings.RowCount - 1; i++)
            {
                if (Convert.ToInt16(dataGridViewLandings[0, i].Value) == LandingID)
                {
                    dataGridViewLandings.Invoke((MethodInvoker)(() => dataGridViewLandings[3, i].Value = "Yes"));
                }
            }
        }

        private void LoadTeamsIntoGrid()
        {
            if (Connected_Event.Teams.Count > 1) // If teams, not singles.
            {
                TeamedEvent = true;
                for (int i = 0; i < Connected_Event.Teams.Count; i++)
                {
                    for (int i2 = 0; i2 < Connected_Event.Teams[i].Count; i2++)
                    {
                        dataGridViewScore.Rows.Add(Connected_Event.Teams[i][i2].ID, Connected_Event.Teams[i][i2].name, Connected_Event.Teams[i][i2].team, Connected_Event.Teams[i][i2].nationality, Connected_Event.TeamNames[i]);
                    }
                }
            }
            else // If singles
            {
                for (int i = 0; i < Connected_Event.Teams.Count; i++)
                {
                    for (int i2 = 0; i2 < Connected_Event.Teams[i].Count; i2++)
                    {
                        dataGridViewScore.Rows.Add(Connected_Event.Teams[i][i2].ID, Connected_Event.Teams[i][i2].name, Connected_Event.Teams[i][i2].team, Connected_Event.Teams[i][i2].nationality, "N/A");
                    }
                }
            }
        }

        public void LoadExistingEventLandings()
        {
            List<Accuracy.MySqlReturnLanding> Landings = Connected_Event.SQL_Controller.GetLandingsForAccuracyEvent(Connected_Event.EventID, Connected_Event);

            for (int i = 0; i < Landings.Count; i++)
            {
                for (int i2 = 0; i2 < dataGridViewScore.Rows.Count; i2++)
                {
                    if (Convert.ToInt16(dataGridViewScore.Rows[i2].Cells[0].Value) == Landings[i].UID)
                    {
                        int Column = Landings[i].Round + 4;
                        dataGridViewScore.Rows[i2].Cells[Column].Value = Landings[i].score;
                        dataGridViewScore.Rows[i2].Cells[Column].Style.BackColor = Color.LightGreen;

                        if (Landings[i].Modified == true) // If score has been manually reset
                        {
                            dataGridViewScore.Rows[i2].Cells[Column].Style.BackColor = Color.Yellow;
                        }

                        if (Landings[i].windDataPrior == null) // If there is no wind data and therefore a manual entry.
                        {
                            dataGridViewScore.Rows[i2].Cells[Column].Style.BackColor = Color.LightBlue;
                        }

                        Landings[i].dataGridCell = dataGridViewScore.Rows[i2].Cells[Column];
                    }
                }

                Connected_Event.CompletedLandings.Add((AccuracyLanding)Landings[i]);
            }
        }

        public void ScoreEdit(String Score)
        {
            labelLatestScore.Invoke((MethodInvoker)(() => labelLatestScore.Text = Score));
            timer1.Start();
        }

        private void buttonMakeActive_Click(object sender, EventArgs e)
        {
            if (Connected_Event.IsActive == false)
            {
                Connected_Event.makeActive();
                buttonMakeActive.BackColor = Color.Green;
            }
            else
            {
                Connected_Event.makeInactive();
                buttonMakeActive.BackColor = Color.Red;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelLatestScore.Text = "--";
            timer1.Stop();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (Connected_Event.IsActive == false)
            {
                tabControl.TabPages.Remove(tabControl.SelectedTab);
                tabControl.SelectedTab = tabControl.TabPages[0];
                Connected_Event.EventTab = null;
            }
            else
            {
                MessageBox.Show("Event is active, please make event inactive and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditLanding_Click(object sender, EventArgs e)
        {
            if (Admin)
            {
                if (dataGridViewScore.SelectedCells.Count != 0)
                {
                    if (dataGridViewScore.SelectedCells[0].Value != null)
                    {
                        if (dataGridViewScore.SelectedCells[0].ColumnIndex >= 4)
                        {
                            int NewScore = CustomMessageBox.Show(Connected_Event.ruleSet.maxScored);
                            dataGridViewScore.SelectedCells[0].Value = NewScore;
                            dataGridViewScore.SelectedCells[0].Style.BackColor = Color.Yellow;
                            Connected_Event.SQL_Controller.ModifyLanding(Connected_Event.GetLandingIDFromCell(dataGridViewScore.SelectedCells[0]), NewScore);
                        }
                    }
                }
            }
            else
            {
                if (dataGridViewScore.SelectedRows.Count != 0)
                {
                    if (dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber].Value != null)
                    {
                        if (dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber].Style.BackColor != Color.LightBlue)
                        {
                            int NewScore = CustomMessageBox.Show(Connected_Event.ruleSet.maxScored);
                            dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber].Value = NewScore;
                            dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber].Style.BackColor = Color.Yellow;
                            Connected_Event.SQL_Controller.ModifyLanding(Connected_Event.GetLandingIDFromCell(dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber]), NewScore);
                        }
                    }
                }
            }
        }

        private void buttonManualLanding_Click(object sender, EventArgs e)
        {
            if (Admin)
            {
                if (dataGridViewScore.SelectedCells.Count != 0)
                {
                    if (dataGridViewScore.SelectedCells[0].Value == null)
                    {
                        if (dataGridViewScore.SelectedCells[0].ColumnIndex >= 4)
                        {
                            int NewScore = CustomMessageBox.Show(Connected_Event.ruleSet.maxScored);
                            dataGridViewScore.SelectedCells[0].Value = NewScore;
                            dataGridViewScore.SelectedCells[0].Style.BackColor = Color.LightBlue;

                            int LandingID;
                            LandingID = Connected_Event.SQL_Controller.CreateAccuracyLanding(Connected_Event.EventID, NewScore);

                            Connected_Event.SQL_Controller.AssignCompetitorToLanding(Convert.ToInt16(dataGridViewScore.Rows[dataGridViewScore.SelectedCells[0].RowIndex].Cells[0].Value),
                            RoundNumber, LandingID, Connected_Event.EventID);
                        }
                    }
                }
            }
            else
            {
                if (dataGridViewScore.SelectedRows.Count != 0)
                {
                    if (dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber].Value == null)
                    {
                        int NewScore = CustomMessageBox.Show(Connected_Event.ruleSet.maxScored);
                        dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber].Value = NewScore;
                        dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber].Style.BackColor = Color.LightBlue;

                        int LandingID;
                        LandingID = Connected_Event.SQL_Controller.CreateAccuracyLanding(Connected_Event.EventID, NewScore);

                        Connected_Event.SQL_Controller.AssignCompetitorToLanding(Convert.ToInt16(dataGridViewScore.SelectedRows[0].Cells[0].Value),
                        RoundNumber, LandingID, Connected_Event.EventID);
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

        private void buttonUnassignLanding_Click(object sender, EventArgs e)
        {
            bool LandingNew = false;
            int LandingID = Connected_Event.GetLandingIDFromCell(dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber]);

            for (int i = 0; i < dataGridViewLandings.Rows.Count; i++)
            {
                if (Convert.ToInt16(dataGridViewLandings.Rows[i].Cells[0].Value) == LandingID)
                {
                    LandingNew = true;
                    dataGridViewLandings.Rows[i].Visible = true;
                }
            }
            if (LandingNew == true)
            {
                dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber].Value = null;
                dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber].Style.BackColor = Color.White;

                Connected_Event.SQL_Controller.AssignCompetitorToLanding(-1, 1, LandingID, Connected_Event.EventID);
            }
            else
            {
                MessageBox.Show("Landing is old. Can only reassign landings from current session.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (dataGridViewScore.SelectedRows[0].Cells[4+RoundNumber].Value == null)
            {
                if (dataGridViewLandings.SelectedRows.Count != 0 && dataGridViewLandings.SelectedRows[0].Cells[1].Value != null)
                {
                    int IndexInList = 0;
                    string SelectedLandingIsComplete = dataGridViewLandings.SelectedRows[0].Cells[3].Value.ToString();
                    AccuracyLanding CurrentLanding = new AccuracyLanding();
                    switch (SelectedLandingIsComplete)
                    {
                        case "Yes":
                            for (int i = 0; i < Connected_Event.CompletedLandings.Count; i++)
                            {
                                if (Connected_Event.CompletedLandings[i].ID == Convert.ToInt16(dataGridViewLandings.SelectedRows[0].Cells[0].Value))
                                {
                                    IndexInList = i;
                                }
                            }
                            CurrentLanding = Connected_Event.CompletedLandings[IndexInList];
                            break;

                        case "No":
                            for (int i = 0; i < Connected_Event.LandingInProgress.Count; i++)
                            {
                                if (Connected_Event.LandingInProgress[i].ID == Convert.ToInt16(dataGridViewLandings.SelectedRows[0].Cells[0].Value))
                                {
                                    IndexInList = i;
                                }
                            }
                            CurrentLanding = Connected_Event.LandingInProgress[IndexInList];
                            break;
                    }

                    CurrentLanding.dataGridCell = dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber];
                    dataGridViewLandings.SelectedRows[0].Visible = false;
                    dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber].Value = CurrentLanding.score;
                    dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber].ReadOnly = true;
                    dataGridViewScore.SelectedRows[0].Cells[4 + RoundNumber].Style.BackColor = Color.LightGreen;

                    Connected_Event.SQL_Controller.AssignCompetitorToLanding(Convert.ToInt16(dataGridViewScore.SelectedRows[0].Cells[0].Value), RoundNumber,
                    CurrentLanding.ID, Connected_Event.EventID);

                    switch (SelectedLandingIsComplete)
                    {
                        case "Yes":
                            Connected_Event.CompletedLandings[IndexInList] = CurrentLanding;
                            break;

                        case "No":
                            Connected_Event.LandingInProgress[IndexInList] = CurrentLanding;
                            break;
                    }

                    CurrentLanding = null;
                    SelectFirstVisibleRowOnDataGrid(dataGridViewLandings); // Selects the first landing on the list for convenience.
                    dataGridViewScore.Rows[dataGridViewScore.SelectedRows[0].Index + 1].Selected = true;
                }
            }
        }

        private void buttonRemoveLanding_Click(object sender, EventArgs e)
        {
            int LandingID = Convert.ToInt16(dataGridViewLandings.SelectedRows[0].Cells[0].Value);
            // Add check if uncommitted row
            dataGridViewLandings.Rows.Remove(dataGridViewLandings.SelectedRows[0]);
            Connected_Event.SQL_Controller.RemoveAccuracyLanding(LandingID, Connected_Event.EventID);
            SelectFirstVisibleRowOnDataGrid(dataGridViewLandings);
        }

        private void buttonRenameCompetitor_Click(object sender, EventArgs e)
        {
            string NewName = CustomMessageBox.Show();
            int UID = Convert.ToInt16(dataGridViewScore.SelectedRows[0].Cells[0].Value);

            if (Connected_Event.SQL_Controller.ModifyCompetitorName(UID, NewName))
            {
                dataGridViewScore.SelectedRows[0].Cells[1].Value = NewName;
            }
        }

        private void buttonRejump_Click(object sender, EventArgs e)
        {
            int LandingID = Convert.ToInt16(dataGridViewLandings.SelectedRows[0].Cells[0].Value);
            // Add check if uncommitted row
            // Rethink what Rejump actually means, a Out of range rejump is possible. Just skip to next competitor?
            dataGridViewLandings.Rows.Remove(dataGridViewLandings.SelectedRows[0]);
            Connected_Event.SQL_Controller.RemoveAccuracyLanding(LandingID, Connected_Event.EventID);
            SelectFirstVisibleRowOnDataGrid(dataGridViewLandings);
            dataGridViewScore.Rows[dataGridViewScore.SelectedRows[0].Index + 1].Selected = true;
        }

    }
}
