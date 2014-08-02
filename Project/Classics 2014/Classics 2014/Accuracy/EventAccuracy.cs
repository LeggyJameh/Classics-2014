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

        public EventAccuracy(Accuracy_Event Event, TabControl Main)
        {
            Connected_Event = Event;
            tabControl = Main;
            InitializeComponent();
            labelName.Text = "Accuracy Event " + Connected_Event.Name;
            if (Connected_Event.Teams.Count > 0)
            {
                TeamedEvent = true;
                LoadTeamsIntoGrid();
            }
            else
            {
                LoadCompetitorsIntoGrid();
            }
        }
        public void MethodAddLanding(AccuracyLanding Landing)
        {
            dataGridViewIncomingLandings.Invoke((MethodInvoker)(() => dataGridViewIncomingLandings.Rows.Add(Landing.ID, Landing.Index, Landing.TimeOfLanding, Landing.score)));
        }

        public bool MethodRemoveLanding(int Index)
        {
            for (int i = 0; i < dataGridViewIncomingLandings.RowCount; i++)
            {
                if (Convert.ToInt16(dataGridViewIncomingLandings[1, i].Value) == Index)
                {
                    dataGridViewIncomingLandings.Rows.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void AddLandingToReady(AccuracyLanding Landing)
        {
            dataGridViewLandings.Invoke((MethodInvoker)(() => dataGridViewLandings.Rows.Add(Landing.Index, Landing.ID, Landing.TimeOfLanding, Landing.score)));
        }

        private void LoadCompetitorsIntoGrid()
        {
            for (int i = 0; i < Connected_Event.Competitors.Count; i++)
            {
                dataGridViewScore.Rows.Add(Connected_Event.Competitors[i].ID, Connected_Event.Competitors[i].name, Connected_Event.Competitors[i].team, Connected_Event.Competitors[i].nationality, "N/A");
            }
        }

        private void LoadTeamsIntoGrid()
        {
            for (int i = 0; i < Connected_Event.Teams.Count; i++)
            {
                for (int i2 = 0; i2 < Connected_Event.Teams[i].Count; i2++)
                {
                    dataGridViewScore.Rows.Add(Connected_Event.Teams[i][i2].ID, Connected_Event.Teams[i][i2].name, Connected_Event.Teams[i][i2].team, Connected_Event.Teams[i][i2].nationality, Connected_Event.TeamNames[i]);
                }
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

        private void dataGridViewScore_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e != null)
            {
                if (e.ColumnIndex >= 4)
                {
                    switch (e.Button)
                    {
                        #region LeftClick
                        case (System.Windows.Forms.MouseButtons.Left):
                            if (dataGridViewScore[e.ColumnIndex, e.RowIndex].Value == null)
                            {
                                if (dataGridViewLandings.SelectedRows.Count != 0 && dataGridViewLandings.SelectedRows[0].Cells[2].Value != null)
                                {
                                    int IndexInList = 0;
                                    for (int i = 0; i < Connected_Event.CompletedLandings.Count; i++)
			                        {
                                        if (Connected_Event.CompletedLandings[i].ID == Convert.ToInt16(dataGridViewLandings.SelectedRows[0].Cells[1].Value))
                                        {
                                            IndexInList = i;
                                        }
			                        }

                                    AccuracyLanding CurrentLanding = Connected_Event.CompletedLandings[IndexInList];

                                    CurrentLanding.dataGridCell = dataGridViewScore[e.ColumnIndex, e.RowIndex];
                                    dataGridViewLandings.Rows.Remove(dataGridViewLandings.SelectedRows[0]);
                                    dataGridViewScore[e.ColumnIndex, e.RowIndex].Value = CurrentLanding.score;
                                    dataGridViewScore[e.ColumnIndex, e.RowIndex].ReadOnly = true;
                                    dataGridViewScore[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGreen;

                                    Connected_Event.SQL_Controller.AssignCompetitorToLanding(Convert.ToInt16(dataGridViewScore[0, e.RowIndex].Value),
                                    Convert.ToInt16(dataGridViewScore.Columns[e.ColumnIndex].Name.Substring(11)),
                                    CurrentLanding.ID, Connected_Event.EventID);

                                    Connected_Event.CompletedLandings[IndexInList] = CurrentLanding;
                                }
                            }
                            break;
                        #endregion
                        #region RightClick
                        case (System.Windows.Forms.MouseButtons.Right):
                            break;
                        #endregion
                    }
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (Connected_Event.IsActive == false)
            {
            }
            else
            {
                MessageBox.Show("Event is active, please make event inactive and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditLanding_Click(object sender, EventArgs e)
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

        private void buttonManualLanding_Click(object sender, EventArgs e)
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
                        LandingID = Connected_Event.SQL_Controller.CreateAccuracyLanding(Connected_Event.EventID, NewScore, new Byte[1]);

                        Connected_Event.SQL_Controller.AssignCompetitorToLanding(Convert.ToInt16(dataGridViewScore.Rows[dataGridViewScore.SelectedCells[0].RowIndex].Cells[0].Value),
                        Convert.ToInt16(dataGridViewScore.Columns[dataGridViewScore.SelectedCells[0].ColumnIndex].Name.Substring(11)),
                        LandingID, Connected_Event.EventID);
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

        private void buttonUnassignLanding_Click(object sender, EventArgs e)
        {
            //int LandingID = Connected_Event.GetLandingIDFromCell(dataGridViewScore.SelectedCells[0]);
            //dataGridViewScore.SelectedCells[0].Value = null;

            //Connected_Event.SQL_Controller.AssignCompetitorToLanding(-1, 1, LandingID, Connected_Event.EventID);
        }

    }
}
