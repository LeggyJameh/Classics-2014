using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS
{
    partial class CompetitorEditor : UserControl
    {
        #region variables and the such like
        Engine Engine;
        List<Competitor> competitors = new List<Competitor>();
        #endregion

        public CompetitorEditor(Engine engine)
        {
            InitializeComponent();
            this.Engine = engine;
            loadCompetitors();
            refreshGrid();
        }

        /// <summary>
        /// Pulls all of the competitors from the database.
        /// </summary>
        private void loadCompetitors()
        {
            competitors = Engine.SQL_Controller.GetCompetitors();
        }

        /// <summary>
        /// Removes all rows from the grid and re-gathers data from locally stored competitor list.
        /// </summary>
        private void refreshGrid()
        {
            dataGridCompetitors.Rows.Clear();
            for (int i = 0; i < competitors.Count; i++)
            {
                dataGridCompetitors.Rows.Add(competitors[i].ID, competitors[i].name, competitors[i].nationality, competitors[i].team);
            }
        }

        /// <summary>
        /// Gathers all of the currently selected rows from the grid.
        /// </summary>
        private List<Competitor> getSelectedCompetitors()
        {
            List<Competitor> competitorsToReturn = new List<Competitor>();
            for (int i = 0; i < dataGridCompetitors.SelectedCells.Count; i++)
            {
                int rowIndex = dataGridCompetitors.SelectedCells[i].RowIndex;
                Competitor currentCompetitor = new Competitor();

                currentCompetitor.ID = Convert.ToInt16(dataGridCompetitors.Rows[rowIndex].Cells[0].Value);
                currentCompetitor.name = dataGridCompetitors.Rows[rowIndex].Cells[1].Value.ToString();
                currentCompetitor.nationality = dataGridCompetitors.Rows[rowIndex].Cells[2].Value.ToString();
                currentCompetitor.team = dataGridCompetitors.Rows[rowIndex].Cells[3].Value.ToString();

                if (competitorsToReturn.Count == 0)
                {
                    competitorsToReturn.Add(currentCompetitor);
                }

                for (int i2 = 0; i2 < competitorsToReturn.Count; i2++)
                {
                    if (competitorsToReturn[i2].ID != currentCompetitor.ID)
                    {
                        competitorsToReturn.Add(currentCompetitor);
                    }
                } 
            }
            return competitorsToReturn;
        }

        #region Get set Operators
        public bool IDVisible
        {
            set
            {
                dataGridCompetitors.Columns[0].Visible = value;
            }
        }
        #endregion

        #region Events
        private void inputIDCheck_CheckedChanged(object sender, EventArgs e)
        {
            IDVisible = inputIDCheck.Checked;
        }

        private void inputModifySelected_Click(object sender, EventArgs e)
        {
            #region variables and the such like
            Competitor currentModelCompetitor;
            List<Competitor> currentlySelected = getSelectedCompetitors();
            string existingName = "";
            string existingNationality = "";
            string existingTeam = "";
            bool[] sameVars = new bool[3]
            {
                true,
                true,
                true
            };
            #endregion

            #region get changes
            for (int i = 0; i < currentlySelected.Count; i++)
            {
                for (int i2 = i; i2 < currentlySelected.Count; i2++)
                {
                    if (currentlySelected[i].name != currentlySelected[i2].name)
                    {
                        sameVars[0] = false;
                    }

                    if (currentlySelected[i].nationality != currentlySelected[i2].nationality)
                    {
                        sameVars[1] = false;
                    }

                    if (currentlySelected[i].team != currentlySelected[i2].team)
                    {
                        sameVars[2] = false;
                    }
                }
            }

            if (sameVars[0])
            {
                existingName = currentlySelected[0].name;
            }

            if (sameVars[1])
            {
                existingNationality = currentlySelected[0].nationality;
            }

            if (sameVars[2])
            {
                existingTeam = currentlySelected[0].team;
            }

            currentModelCompetitor = MessageBoxes.ModifyCompetitor(existingName, existingNationality, existingTeam, Engine.SQL_Controller.GetAllTeams());
            #endregion

            #region apply changes
            if (currentModelCompetitor != null)
            {
                if (existingName != currentModelCompetitor.name)
                {
                    for (int i = 0; i < competitors.Count; i++)
                    {
                        for (int i2 = 0; i2 < currentlySelected.Count; i2++)
                        {
                            if (competitors[i].ID == currentlySelected[i2].ID)
                            {
                                competitors[i].name = currentModelCompetitor.name;
                            }
                        }
                    }
                }

                if (existingNationality != currentModelCompetitor.nationality)
                {
                    for (int i = 0; i < competitors.Count; i++)
                    {
                        for (int i2 = 0; i2 < currentlySelected.Count; i2++)
                        {
                            if (competitors[i].ID == currentlySelected[i2].ID)
                            {
                                competitors[i].nationality = currentModelCompetitor.nationality;
                            }
                        }
                    }
                }

                if (existingTeam != currentModelCompetitor.team)
                {
                    for (int i = 0; i < competitors.Count; i++)
                    {
                        for (int i2 = 0; i2 < currentlySelected.Count; i2++)
                        {
                            if (competitors[i].ID == currentlySelected[i2].ID)
                            {
                                competitors[i].team = currentModelCompetitor.team;
                            }
                        }
                    }
                }
            #endregion

                refreshGrid();
            }
        }

        private void inputFindAndReplace_Click(object sender, EventArgs e)
        {

        }

        private void inputFilter_Click(object sender, EventArgs e)
        {

        }

        private void inputSave_Click(object sender, EventArgs e)
        {

        }

        private void inputExit_Click(object sender, EventArgs e)
        {

        }
    }
        #endregion
}
