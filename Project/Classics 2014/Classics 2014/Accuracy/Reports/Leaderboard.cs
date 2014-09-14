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
    partial class Leaderboard : UserControl
    {
        public string reportName;
        private SQL_Controller sqlController;
        private bool autoUpdate;
        private Form undockedForm;
        private int eventId;
        private Accuracy_Event connectedEvent;
        public Leaderboard(int eventID, String reportName, SQL_Controller sqlController, Accuracy_Event connectedEvent)
        {
            InitializeComponent();
            this.reportName = reportName;
            this.eventId = eventID;
            this.sqlController = sqlController;
            this.connectedEvent = connectedEvent;
            autoUpdate = false;
            Populate();
        }
        public void Update(int UserID, int Round, DataGridViewCell newCell)
        {
            foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
            {
                if (r.Cells[0].Value.ToString() == UserID.ToString())
                {
                    r.Cells[Round + 4] = newCell;
                }
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
        public void Populate()
        {
            List<TCompetitor> competitors = sqlController.GetCompetitorsForEvent(eventId);
            List<MySqlReturnLanding> landings = sqlController.GetLandingsForAccuracyEvent(eventId, connectedEvent);
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
                            dataGridViewLockedLeaderboard.Columns.Add("columnRound" + (dataGridViewLockedLeaderboard.ColumnCount - 4), "Round " + (dataGridViewLockedLeaderboard.ColumnCount - 4));
                        }

                        cellToEdit = dataGridViewLockedLeaderboard[l.Round + 4, dataGridViewLockedLeaderboard.Rows.Count - 1];
                        cellToEdit.Value = l.score;
                        cellToEdit.Style.BackColor = Color.LightGreen;
                        if (l.Modified == true)
                        {
                            cellToEdit.Style.BackColor = Color.Yellow;
                            if (l.windDataPrior == null) { cellToEdit.Style.BackColor = Color.LightBlue; }
                        }

                    }
                }

            }
        }
        private void Sort()
        {
            int[,] leaderBoard = new int[3, dataGridViewLockedLeaderboard.RowCount];// ID POS Score
            for (int d = 0; d < dataGridViewLockedLeaderboard.RowCount; d++) { leaderBoard[2, d] = 0; }
            int ii = 0;
            foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
            {
                leaderBoard[0, ii] = Convert.ToInt16(r.Cells[0].Value);
                ii++;
            }; // Assigning the User Ids
             ii = 0;

            for (int i = 6; i <= dataGridViewLockedLeaderboard.Columns.Count; i++)
            {
                if (IsDatagridViewColumnFull(dataGridViewLockedLeaderboard.Columns[i]))
                {
                    ii = 0;
                    foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
                    {
                        leaderBoard[2, ii] += Convert.ToInt16(r.Cells[i].Value);
                        ii++;
                    }
                }
            }
            leaderBoard = rearrangedLeaderBoard(leaderBoard);
        }
        private int[,] rearrangedLeaderBoard(int[,] leaderBoardPrior)
        {
            int[,] rearrangedLeaderBoard = leaderBoardPrior;

            return rearrangedLeaderBoard;

        }
        private Boolean IsDatagridViewColumnFull(DataGridViewColumn columnToCheck)
        {
            foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
            {
                if ((r.Cells[columnToCheck.Index].Value == null)||(r.Cells[columnToCheck.Index].Value == DBNull.Value)) { return false; }
            }
            return true;
        }
        private void buttonAutoUpdate_Click(object sender, EventArgs e)
        {
            autoUpdate = !autoUpdate;
            if (autoUpdate)
            {
                buttonAutoUpdate.ForeColor = Color.Green;
                dataGridViewLockedLeaderboard.Rows.Clear();
                Populate();
            }
            else { buttonAutoUpdate.ForeColor = Color.Crimson; }
        }

        private void buttonUndock_Click(object sender, EventArgs e)
        {
            if (undockedForm != null)
            {
                undockedForm = new Form();
                undockedForm.Controls.Add(dataGridViewLockedLeaderboard);
                undockedForm.FormClosed += new FormClosedEventHandler(undockedForm_FormClosed);
                undockedForm.Show();
                buttonUndock.Text = "Dock";
            }
            else
            {
                undockedForm.Hide();
                undockedForm = null;

            }
        }

        void undockedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            undockedForm = null;
        }
    }
}
