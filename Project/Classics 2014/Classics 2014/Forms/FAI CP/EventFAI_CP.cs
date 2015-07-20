using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS.FAI_CP
{
    partial class EventFAI_CP : UserControl
    {
        public FAI_CP_Event connected_Event;
        private Dictionary<EventCompetitor, List<FAI_CPLanding>> data;
        private Ruleset.FAI_CPRules rules;
        //private Reports.ReportCreation currentReportForm;
        public int roundNumber = 1;
        const int columnCountUptoFirstRound = 3;

        /// <summary>
        /// Init for event. landings can be null if event is new.
        /// </summary>
        public EventFAI_CP(FAI_CP_Event connected_Event, List<FAI_CPLanding> landings)
        {
            this.connected_Event = connected_Event;
            rules = (Ruleset.FAI_CPRules)connected_Event.Rules;
            InitializeComponent();
            setupAccuracy();
            label1.Text = connected_Event.Name;
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
                dataGridAccuracyScores.Columns["EID"].Visible = false;
                dataGridSpeedScores.Columns["EID"].Visible = false;
                dataGridDistanceScores.Columns["EID"].Visible = false;
            }
        }

        /// <summary>
        /// Selects the first blank cell in the table specified
        /// </summary>
        private void selectFirstBlankCell(DataGridView grid)
        {
            DataGridViewCell bestCell = grid.Rows[0].Cells[columnCountUptoFirstRound];

            foreach (DataGridViewRow r in grid.Rows)
            {
                foreach (DataGridViewCell c in r.Cells)
                {
                    if (c.Value == null || c.Value.ToString() == "")
                    {
                        if ((c.ColumnIndex < bestCell.ColumnIndex || bestCell.Value != null) && c.ColumnIndex >= (columnCountUptoFirstRound - 1))
                        {
                            bestCell = c;
                        }
                    }
                }
            }

            grid.ClearSelection();
            bestCell.Selected = true;
        }

        private void inputClose_Click(object sender, EventArgs e)
        {
            if (MBox.Generic.Show(MBox.GenericMBoxType.ClosingCheckNoSave) == DialogResult.Yes)
            {
                connected_Event.Exit();
            }
        }
    }
}
