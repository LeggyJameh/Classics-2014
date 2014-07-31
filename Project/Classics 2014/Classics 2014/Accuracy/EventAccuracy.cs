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
            Connected_Event.makeActive();
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
                if (e.ColumnIndex > 3)
                {
                    switch (e.Button)
                    {
                        case (System.Windows.Forms.MouseButtons.Left):
                            if (dataGridViewScore[e.ColumnIndex, e.RowIndex].Value == null)
                            {
                                if (dataGridViewLandings.SelectedRows[0] != null)
                                {
                                    AccuracyLanding CurrentLanding;
                                    CurrentLanding = Connected_Event.AssignLanding(Convert.ToInt16(dataGridViewLandings.SelectedRows[0].Cells[0].Value), (DataGridViewCell)dataGridViewScore[e.ColumnIndex, e.RowIndex]);

                                    if (CurrentLanding.ID != -1)
                                    {
                                        dataGridViewScore[e.ColumnIndex, e.RowIndex].Value = CurrentLanding.score;

                                        Connected_Event.SQL_Controller.AssignCompetitorToLanding(Convert.ToInt16(dataGridViewScore[0, e.RowIndex].Value),
                                            Convert.ToInt16(dataGridViewScore.Columns[e.ColumnIndex].Name.Substring(11)),
                                            CurrentLanding.ID, Connected_Event.EventID);

                                        dataGridViewLandings.Rows.Remove(dataGridViewLandings.SelectedRows[0]);
                                        Connected_Event.RemoveCompletedLanding(CurrentLanding);
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
    }
}
