using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS.FAI_CP
{
    partial class EventFAI_CP
    {
        CPAccuracyScorer accuracyScorer;

        /// <summary>
        /// Init for accuracy-related stuff for the class.
        /// </summary>
        private void setupAccuracy()
        {
            accuracyScorer = new CPAccuracyScorer(this);
            tableLayoutPanelAccuracy.Controls.Add(accuracyScorer, 0, 1);
            tableLayoutPanelAccuracy.SetColumnSpan(accuracyScorer, 4);
            accuracyScorer.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void refreshAccuracyGrid()
        {
            dataGridAccuracyScores.SuspendLayout();
            dataGridAccuracyScores.Rows.Clear();

            //if (reportsUpdateDelegate != null)
            //{
            //    reportsUpdateDelegate(data);
            //}

            foreach (EventCompetitor c in data.Keys)
            {
                dataGridAccuracyScores.Rows.Add(c.ID, c.EID, c.name);
                foreach (FAI_CPLanding l in data[c])
                {
                    DataGridViewCell currentCell = dataGridAccuracyScores.Rows[dataGridAccuracyScores.Rows.Count - 1].Cells[l.round + (columnCountUptoFirstRound - 1 /* -1 because index not count */)];
                    currentCell.Value = l.score;
                    currentCell.Tag = "ID" + l.ID + "|UID" + l.UID; // Tagging up the cell for reference points.
                    currentCell.Style.BackColor = CMS.UserSettings.Default.scoreGoodLandingColour;
                    currentCell.Style.SelectionBackColor = CMS.UserSettings.Default.scoreGoodLandingSelectedColour;

                    if (l.rejumpable) // If rejumpable
                    {
                        currentCell.Style.BackColor = CMS.UserSettings.Default.scoreRejumpableColour;
                        currentCell.Style.SelectionBackColor = CMS.UserSettings.Default.scoreRejumpableSelectedColour;
                    }

                    if (l.windDataPrior == null) // If no wind data and therefore manual
                    {
                        currentCell.Style.BackColor = CMS.UserSettings.Default.scoreManualColour;
                        currentCell.Style.SelectionBackColor = CMS.UserSettings.Default.scoreManualSelectedColour;
                    }

                    if (l.modified) // If Modified score
                    {
                        currentCell.Style.BackColor = CMS.UserSettings.Default.scoreModifiedColour;
                        currentCell.Style.SelectionBackColor = CMS.UserSettings.Default.scoreModifiedSelectedColour;
                    }
                }
            }
            dataGridAccuracyScores.ResumeLayout();
            selectFirstBlankCell(dataGridAccuracyScores);
        }

        /// <summary>
        /// Procedure used by the scorer to pass over landings.
        /// </summary>
        public void createAccuracyLanding(int score)
        {
            
        }

        private void inputAccuracyNextRound_Click(object sender, EventArgs e)
        {

        }
    }
}
