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
        List<string> availableGroups = new List<string>();
        bool saved = true;
        string Nfilter;
        #endregion

        public CompetitorEditor(Engine engine)
        {
            InitializeComponent();
            this.Engine = engine;
            Nfilter = "";
            loadCompetitorsAndGroups();
            refreshGrid();
        }

        /// <summary>
        /// Pulls all of the competitors from the database.
        /// </summary>
        private void loadCompetitorsAndGroups()
        {
            competitors = Engine.SQL_Controller.GetCompetitors();
            availableGroups = Engine.SQL_Controller.GetAllGroups();
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
                if (c.name.ToUpper().Contains(filter) || c.nationality.ToUpper().Contains(filter) || c.group.ToUpper().Contains(filter))
                {
                    dataGridCompetitors.Rows.Add(c.ID, c.name, c.nationality, c.group);
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
                if (c.name.ToUpper().Contains(filter) || c.nationality.ToUpper().Contains(filter) || c.group.ToUpper().Contains(filter))
                {
                    dataGridCompetitors.Rows.Add(c.ID, c.name, c.nationality, c.group);
                }
            }

            foreach (DataGridViewRow r in dataGridCompetitors.SelectedRows) // Deselect default selected row(s).
            {
                r.Selected = false;
            }
            foreach (DataGridViewRow r in dataGridCompetitors.Rows) // Select the previously selected row(s).
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
                currentCompetitor.group = dataGridCompetitors.SelectedRows[i].Cells[3].Value.ToString();

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
        /// Function through which group manager returns groups after edits finished.
        /// </summary>
        public void groupReturn(List<string> groups)
        {
            availableGroups = groups;

            for (int i = 0; i < competitors.Count; i++)
            {
                bool groupExists = false;
                for (int i2 = 0; i2 < groups.Count; i2++)
                {
                    if (competitors[i].group == groups[i2])
                    {
                        groupExists = true;
                    }
                }
                if (!groupExists)
                {
                    competitors[i].group = "";
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
                if (showMessages) { MBox.Generic.Show(MBox.GenericMBoxType.SavingFailed); }
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
            Competitor currentCompetitor = MessageBoxes.CreateCompetitor(availableGroups);
            if (currentCompetitor != null)
            {
                bool unique = true;
                for (int i = 0; i < competitors.Count; i++)
                {
                    if (currentCompetitor.name == competitors[i].name && currentCompetitor.nationality == competitors[i].nationality && currentCompetitor.group == competitors[i].group)
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

        private void inputCreateGroup_Click(object sender, EventArgs e)
        {
            string groupName = MessageBoxes.CreateGroup();
            bool unique = true;

            for (int i = 0; i < availableGroups.Count; i++)
            {
                if (groupName == availableGroups[i])
                {
                    unique = false;
                }
            }

            if (unique)
            {
                availableGroups.Add(groupName);
            }
            else
            {
                MessageBox.Show("Group name is already taken!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            saved = false;
        }

        private void inputManageGroups_Click(object sender, EventArgs e)
        {
            Engine.mainForm.openSimpleGroupManager(availableGroups, this);
        }
        
        private void inputModifySelected_Click(object sender, EventArgs e)
        {
            #region variables and the such like
            Competitor currentModelCompetitor;
            List<Competitor> currentlySelected = getSelectedCompetitors();
            string existingName = "";
            string existingNationality = "";
            string existingGroup = "";
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

                    if (currentlySelected[i].group != currentlySelected[i2].group)
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
                existingGroup = currentlySelected[0].group;
            }

            currentModelCompetitor = MessageBoxes.ModifyCompetitor(existingName, existingNationality, existingGroup, availableGroups);
            
            #endregion

            #region apply changes
            if (currentModelCompetitor != null)
            {
                if (existingName != currentModelCompetitor.name)
                {
                    for (int i = 0; i < currentlySelected.Count; i++)
                    {
                        currentlySelected[i].name = currentModelCompetitor.name;
                    }
                }

                if (existingNationality != currentModelCompetitor.nationality)
                {
                    for (int i = 0; i < currentlySelected.Count; i++)
                    {
                        currentlySelected[i].nationality = currentModelCompetitor.nationality;
                    }
                }

                if (existingGroup != currentModelCompetitor.group)
                {
                    for (int i = 0; i < currentlySelected.Count; i++)
                    {
                        currentlySelected[i].group = currentModelCompetitor.group;
                    }
                }

                bool AllUnique = true;
                foreach (Competitor c in currentlySelected)
                {
                    foreach (Competitor k in currentlySelected)
                    {
                        if (c.name == k.name && c.nationality == k.nationality && c.group == k.group && c.ID != k.ID) // If all but the ID are the same between two competitors
                        {
                            AllUnique = false; // Don't apply the changes.
                        }
                    }
                }

                foreach (Competitor c in currentlySelected)
                {
                    foreach (Competitor k in competitors)
                    {
                        if (c.name == k.name && c.nationality == k.nationality && c.group == k.group && c.ID != k.ID) // If all but the ID are the same between two competitors
                        {
                            AllUnique = false; // Don't apply the changes.
                        }
                    }
                }

                if (AllUnique)
                {
                    foreach (Competitor c in currentlySelected)
                    {
                        foreach (Competitor k in competitors)
                        {
                            if (c.ID == k.ID)
                            {
                                k.name = c.name;
                                k.nationality = c.nationality;
                                k.group = c.group;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Modification would result in duplicate competitors, edit failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DialogResult checker = MBox.Generic.Show(MBox.GenericMBoxType.ClosingCheckSave);

                switch (checker)
                {
                    case DialogResult.Yes:
                        if (save(false))
                        {
                            Engine.mainForm.removeTab((TabPage)this.Parent);
                        }
                        else
                        {
                            MBox.Generic.Show(MBox.GenericMBoxType.SavingFailed);
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
