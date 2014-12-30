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
        List<string> availableTeams = new List<string>();
        bool saved = true;
        string Nfilter;
        #endregion

        public CompetitorEditor(Engine engine)
        {
            InitializeComponent();
            this.Engine = engine;
            Nfilter = "";
            loadCompetitorsAndTeams();
            refreshGrid();
        }

        /// <summary>
        /// Pulls all of the competitors from the database.
        /// </summary>
        private void loadCompetitorsAndTeams()
        {
            competitors = Engine.SQL_Controller.GetCompetitors();
            availableTeams = Engine.SQL_Controller.GetAllTeams();
            saved = true;
        }

        /// <summary>
        /// Removes all rows from the grid and re-gathers data from locally stored competitor list.
        /// </summary>
        private void refreshGrid()
        {
            dataGridCompetitors.Rows.Clear();
            foreach (Competitor c in competitors)
            {
                if (c.name.ToUpper().Contains(filter) || c.nationality.ToUpper().Contains(filter) || c.team.ToUpper().Contains(filter))
                {
                    dataGridCompetitors.Rows.Add(c.ID, c.name, c.nationality, c.team);
                }
            }
        }

        /// <summary>
        /// Removes all rows from the grid and re-gathers data from locally stored competitor list. Keeps selection in-tact.
        /// </summary>
        private void refreshGridKeepSelection()
        {
            List<int> selectedRowUID = new List<int>();
            foreach (DataGridViewRow r in dataGridCompetitors.SelectedRows)
            {
                selectedRowUID.Add(Convert.ToInt16(r.Cells[0].Value));
            }

            dataGridCompetitors.Rows.Clear();
            foreach (Competitor c in competitors)
            {
                if (c.name.ToUpper().Contains(filter) || c.nationality.ToUpper().Contains(filter) || c.team.ToUpper().Contains(filter))
                {
                    dataGridCompetitors.Rows.Add(c.ID, c.name, c.nationality, c.team);
                }
            }

            foreach (DataGridViewRow r in dataGridCompetitors.Rows)
            {
                foreach (int c in selectedRowUID)
                {
                    if (Convert.ToInt16(r.Cells[0].Value) == c)
                    {
                        r.Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// Gathers all of the currently selected rows from the grid.
        /// </summary>
        private List<Competitor> getSelectedCompetitors()
        {
            List<Competitor> competitorsToReturn = new List<Competitor>();
            for (int i = 0; i < dataGridCompetitors.SelectedRows.Count; i++)
            {
                Competitor currentCompetitor = new Competitor();

                currentCompetitor.ID = Convert.ToInt16(dataGridCompetitors.SelectedRows[i].Cells[0].Value);
                currentCompetitor.name = dataGridCompetitors.SelectedRows[i].Cells[1].Value.ToString();
                currentCompetitor.nationality = dataGridCompetitors.SelectedRows[i].Cells[2].Value.ToString();
                currentCompetitor.team = dataGridCompetitors.SelectedRows[i].Cells[3].Value.ToString();

                if (competitorsToReturn.Count == 0)
                {
                    competitorsToReturn.Add(currentCompetitor);
                }

                bool unique = true;
                for (int i2 = 0; i2 < competitorsToReturn.Count; i2++)
                {
                    if (competitorsToReturn[i2].ID == currentCompetitor.ID)
                    {
                        unique = false;
                    }
                }

                if (unique == true) competitorsToReturn.Add(currentCompetitor);
            }
            return competitorsToReturn;
        }

        /// <summary>
        /// Function through which team manager returns teams after edits finished.
        /// </summary>
        public void teamReturn(List<string> teams)
        {
            availableTeams = teams;

            for (int i = 0; i < competitors.Count; i++)
            {
                bool teamExists = false;
                for (int i2 = 0; i2 < teams.Count; i2++)
                {
                    if (competitors[i].team == teams[i2])
                    {
                        teamExists = true;
                    }
                }
                if (!teamExists)
                {
                    competitors[i].team = "";
                }
            }

            refreshGrid();
            saved = false;
        }

        private bool save(bool showMessages)
        {
            if (showMessages) { MessageBox.Show("Please wait, saving.", "Saving...", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            if (Engine.SQL_Controller.SaveCompetitorsOverwriteAndRemoveExcess(competitors))
            {
                if (showMessages) { MessageBox.Show("Save completed.", "Operation completed sucessfully", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                saved = true;
                Engine.RefreshAllCompetitorUsers();
                return true;
            }
            else
            {
                if (showMessages) { MessageBox.Show("An error occured and saving was aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                return false;
            }
        }

        #region Get set Operators
        private bool IDVisible
        {
            set
            {
                dataGridCompetitors.Columns[0].Visible = value;
            }
        }

        private string filter
        {
            get
            {
                return Nfilter;
            }
            set
            {
                if (value == "")
                {
                    inputFilter.Text = "Filter";
                    labelFilter1.Visible = false;
                    labelFilter2.Text = "";
                }
                else
                {
                    inputFilter.Text = "Remove Filter";
                    labelFilter1.Visible = true;
                    labelFilter2.Text = value;
                }
                Nfilter = value.ToUpper();
            }
        }
        #endregion

        #region Events

        private void inputAddCompetitor_Click(object sender, EventArgs e)
        {
            Competitor currentCompetitor = MessageBoxes.CreateCompetitor(availableTeams);
            if (currentCompetitor != null)
            {
                bool unique = true;
                for (int i = 0; i < competitors.Count; i++)
                {
                    if (currentCompetitor.name == competitors[i].name && currentCompetitor.nationality == competitors[i].nationality && currentCompetitor.team == competitors[i].team)
                    {
                        unique = false;
                    }
                }
                if (unique)
                {
                    competitors.Add(currentCompetitor);
                    refreshGridKeepSelection();
                }
                else
                {
                    MessageBox.Show("Duplicate competitor already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            saved = false;
        }

        private void inputRemoveCompetitor_Click(object sender, EventArgs e)
        {
            List<Competitor> competitorsToRemove = getSelectedCompetitors();

            if (MessageBox.Show("Are you sure you wish to remove the selected competitors?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < competitorsToRemove.Count; i++)
			    {
			        for (int i2 = 0; i2 < competitors.Count; i2++)
			        {
			            if (competitorsToRemove[i].ID == competitors[i2].ID)
                        {
                            competitors.Remove(competitors[i2]);
                            i2--;
                        }
			        }
			    }
                refreshGrid();
            }
            saved = false;
        }

        private void inputCreateTeam_Click(object sender, EventArgs e)
        {
            string teamName = MessageBoxes.CreateTeam();
            bool unique = true;

            for (int i = 0; i < availableTeams.Count; i++)
            {
                if (teamName == availableTeams[i])
                {
                    unique = false;
                }
            }

            if (unique)
            {
                availableTeams.Add(teamName);
            }
            else
            {
                MessageBox.Show("Team name is already taken!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            saved = false;
        }

        private void inputManageTeams_Click(object sender, EventArgs e)
        {
            Engine.mainForm.openSimpleTeamManager(availableTeams, this);
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

            currentModelCompetitor = MessageBoxes.ModifyCompetitor(existingName, existingNationality, existingTeam, availableTeams);
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
                refreshGridKeepSelection();
            }
            #endregion
            saved = false;
        }

        private void inputFilter_Click(object sender, EventArgs e)
        {
            if (filter == "")
            {
                filter = MessageBoxes.filterString(filter);
            }
            else
            {
                filter = "";
            }
            refreshGrid();
        }

        private void inputSave_Click(object sender, EventArgs e)
        {
            save(true);
        }

        private void inputExit_Click(object sender, EventArgs e)
        {
            if (saved)
            {
                Engine.mainForm.removeTab((TabPage)this.Parent);
            }
            else
            {
                DialogResult checker = MessageBox.Show("Save before exiting?", "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

                switch (checker)
                {
                    case DialogResult.Yes:
                        if (save(false))
                        {
                            Engine.mainForm.removeTab((TabPage)this.Parent);
                        }
                        else
                        {
                            MessageBox.Show("An error occured and saving was aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case DialogResult.No:
                        Engine.mainForm.removeTab((TabPage)this.Parent);
                        break;
                }
            }
        }

        private void inputIDCheck_CheckedChanged(object sender, EventArgs e)
        {
            IDVisible = inputIDCheck.Checked;
        }
    }
        #endregion
}
