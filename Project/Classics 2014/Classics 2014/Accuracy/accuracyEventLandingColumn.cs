using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classics_2014.Accuracy
{
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
            dataGridViewLandings.Rows.Add(newLanding.ID, newLanding.TimeOfLanding, newLanding.score);
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
    }
}
