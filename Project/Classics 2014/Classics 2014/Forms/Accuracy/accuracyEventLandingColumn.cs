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
    // Working 29/10/14.
    partial class accuracyEventLandingColumn : UserControl
    {
        AccuracyEventController controller;
        public accuracyEventLandingColumn(AccuracyEventController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }
        public void AddLanding(AccuracyLanding newLanding)
        {
            dataGridViewLandings.Rows.Add(newLanding.index, newLanding.time, newLanding.score);
        }

        public void RemoveLanding(AccuracyLanding landing)
        {
            for (int i = 0; i < dataGridViewLandings.Rows.Count; i++)
            {
                if (landing.index == Convert.ToInt16(dataGridViewLandings.Rows[i].Cells[0].Value))
                {
                    dataGridViewLandings.Rows.RemoveAt(i);
                    i = dataGridViewLandings.Rows.Count; // End the loop
                }
            }
            // TODO: Select next row for convenience.
        }

        public int GetIndexOfCurrentLanding()
        {
            if (dataGridViewLandings.SelectedRows.Count > 0)
            {
                return Convert.ToInt16(dataGridViewLandings.SelectedRows[0].Cells[0].Value);
            }
            return -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelLatestScore.Text = "--";
            timer1.Enabled = false;
        }
        public void UpdateScore(string NewScore)
        {
            labelLatestScore.Text = NewScore;
            timer1.Enabled = false;
            timer1.Enabled = true;
        }

        private void buttonRemoveLanding_Click(object sender, EventArgs e)
        {
            if (dataGridViewLandings.SelectedRows.Count > 0)
            {
                int landingIndex = Convert.ToInt16(dataGridViewLandings.SelectedRows[0].Cells[0].Value);
                dataGridViewLandings.Rows.Remove(dataGridViewLandings.SelectedRows[0]);
                controller.removeLanding(landingIndex);
            }
        }
    }
}
