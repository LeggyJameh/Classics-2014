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
        private string reportName;
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
            Update();
        }
        public void Update()
        {
            List<TCompetitor> competitors = sqlController.GetCompetitorsForEvent(eventId);
            List<MySqlReturnLanding> landings = sqlController.GetLandingsForAccuracyEvent(eventId, connectedEvent);
            DataGridViewCell cellToEdit;
            foreach (TCompetitor c in competitors)
            {
                dataGridViewLockedLeaderboard.Rows.Add(c.name, c.nationality, c.team);
                foreach (MySqlReturnLanding l in landings)
                {
                    if (l.UID == c.ID)
                    {
                        while (l.Round > dataGridViewLockedLeaderboard.ColumnCount - 2)
                        {
                            dataGridViewLockedLeaderboard.Columns.Add("columnRound" + (dataGridViewLockedLeaderboard.ColumnCount - 1), "Round " + (dataGridViewLockedLeaderboard.ColumnCount - 1));
                        }
                        cellToEdit = dataGridViewLockedLeaderboard[l.Round + 2, dataGridViewLockedLeaderboard.Rows.Count - 1];
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
    }
}
