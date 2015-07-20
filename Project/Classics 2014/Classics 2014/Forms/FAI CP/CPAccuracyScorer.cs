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
    partial class CPAccuracyScorer : UserControl
    {
        EventFAI_CP connectedEvent;
        int currentScore = 0;

        public CPAccuracyScorer(EventFAI_CP connectedEvent)
        {
            this.connectedEvent = connectedEvent;
            InitializeComponent();
        }

        private void zoneClick(object sender, EventArgs e)
        {
            if (sender is Panel)
            {
                Panel p = (Panel)sender;
                if (p.Tag.ToString() != "Miss")
                {
                    currentScore += Convert.ToInt16(p.Tag.ToString());
                    connectedEvent.createAccuracyLanding(currentScore);
                    currentScore = 0;
                }
                else
                {
                    currentScore = 0;
                }
            }
        }

        private void gateClick(object sender, EventArgs e)
        {
            if (sender is Panel)
            {
                Panel p = (Panel)sender;
                currentScore += Convert.ToInt16(p.Tag.ToString());
            }
        }
    }
}
