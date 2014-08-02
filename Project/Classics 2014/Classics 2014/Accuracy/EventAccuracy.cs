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

        public EventAccuracy(Accuracy_Event Event, TabControl Main)
        {
            Connected_Event = Event;
            tabControl = Main;
            InitializeComponent();
            labelName.Text = "Accuracy Event " + Connected_Event.Name;
            LoadTeamsIntoGrid();
        }
        public int MethodAddLanding(Accuracy.AccuracyLanding Landing)
        {
            Connected_Event.NumberOfLandings++;
            dataGridViewLandings.Invoke((MethodInvoker)(() => dataGridViewLandings.Rows.Add(Connected_Event.NumberOfLandings, Landing.TimeOfLanding, Landing.score)));
            return Connected_Event.NumberOfLandings;
                //ToDo Checks to make sure its under wind and the like
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
                        case (System.Windows.Forms.MouseButtons.Left):
                            if (dataGridViewScore[e.ColumnIndex, e.RowIndex].Value == null)
                            {
                                if (dataGridViewLandings.SelectedRows.Count != 0 && dataGridViewLandings.SelectedRows[0].Cells[2].Value != null)
                                {
                                    AccuracyLanding CurrentLanding;
                                    CurrentLanding = Connected_Event.AssignLanding(Convert.ToInt16(dataGridViewLandings.SelectedRows[0].Cells[0].Value), (DataGridViewCell)dataGridViewScore[e.ColumnIndex, e.RowIndex]);

                                    if (CurrentLanding.ID != -1)
                                    {
                                        dataGridViewScore[e.ColumnIndex, e.RowIndex].Tag = "Edit";
                                        dataGridViewLandings.Rows.Remove(dataGridViewLandings.SelectedRows[0]);
                                        dataGridViewScore[e.ColumnIndex, e.RowIndex].Value = CurrentLanding.score;
                                        dataGridViewScore[e.ColumnIndex, e.RowIndex].ReadOnly = false;
                                        dataGridViewScore[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGreen;
                                        dataGridViewScore[e.ColumnIndex, e.RowIndex].Tag = "";

                                        Connected_Event.SQL_Controller.AssignCompetitorToLanding(Convert.ToInt16(dataGridViewScore[0, e.RowIndex].Value),
                                            Convert.ToInt16(dataGridViewScore.Columns[e.ColumnIndex].Name.Substring(11)),
                                            CurrentLanding.ID, Connected_Event.EventID);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please wait for wind data of landing to be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            break;
                        case (System.Windows.Forms.MouseButtons.Right):
                            break;
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
                if (dataGridViewScore.SelectedCells[0].ColumnIndex >= 4)
                {
                    int NewScore = CustomMessageBox.Show(Connected_Event.ruleSet.maxScored);
                    dataGridViewScore.SelectedCells[0].Value = NewScore;
                    dataGridViewScore.SelectedCells[0].Style.BackColor = Color.Yellow;
                    dataGridViewScore[0, 0].Selected = true;
                    Connected_Event.SQL_Controller.ModifyLanding(Connected_Event.GetLandingIDFromCell(dataGridViewScore.SelectedCells[0]), NewScore);
                }
            }
        }

        private void UpdateTeamLeaderboard()
        {
            dataGridViewTeamLeaderboard.Rows.Clear();
            List<MySqlReturnLanding> Landings = Connected_Event.SQL_Controller.GetLandingsForAccuracyEvent(Connected_Event.EventID, Connected_Event);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateTeamLeaderboard();
        }

    }
}
