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
    partial class CompetitorSelector : UserControl
    {
        #region variables and the such like
        private CompetitorSelectorData data;
        private DataGridViewCellStyle selectedStyle;
        private DataGridViewCellStyle defaultStyle;
        private string noGroupName;

        public Event Connected_Event;
        #endregion

        #region filterVariables
        string NfilterGroup; // dont reference, use filterGroup instead.
        string NfilterCompetitor; // dont reference, use filterCompetitor instead.
        SelectedOption selectionShowGroup;
        bool showCompetitorsUnselectedGroups;
        #endregion

        public CompetitorSelector(Event Connected_Event)
        {
            this.Connected_Event = Connected_Event;
            InitializeComponent();
            setup();
            setupForm();
            ReloadData();
            inputGroupShow.SelectedIndex = 0;
        }

        /// <summary>
        /// Initialises variables.
        /// </summary>
        private void setup()
        {
            data = new CompetitorSelectorData();
            showCompetitorsUnselectedGroups = false;
            NfilterCompetitor = "";
            NfilterGroup = "";
            noGroupName = "[No Group]";
        }

        /// <summary>
        /// Set form and control options.
        /// </summary>
        private void setupForm()
        {
            selectionShowGroup = SelectedOption.All;
            defaultStyle = dataGridCompetitors.DefaultCellStyle.Clone();
            selectedStyle = dataGridCompetitors.DefaultCellStyle.Clone();
            selectedStyle.BackColor = Color.LightGreen;
            selectedStyle.SelectionBackColor = Color.Green;
            selectedStyle.SelectionForeColor = Color.White;
        }

        /// <summary>
        /// Deletes all rows from competitor grid and re-loads from virtual data.
        /// </summary>
        private void refreshCompetitorGrid()
        {
            dataGridCompetitors.Rows.Clear();

            foreach (Competitor c in data.GetCompetitors())
            {
                if (data.GroupValue(c.group) || showCompetitorsUnselectedGroups) // If group has been selected or showing unselected groups' competitors.
                {
                    if (c.name.ToUpper().Contains(filterCompetitor) || c.nationality.ToUpper().Contains(filterCompetitor) || c.group.ToUpper().Contains(filterCompetitor))
                    {
                        int rowIndex = dataGridCompetitors.Rows.Add(c.ID, c.name, c.nationality, c.group); // Add the competitor to the grid.
                        if (data.CompetitorValue(c)) // if the competitor has been selected,
                        {
                            foreach (DataGridViewCell cell in dataGridCompetitors.Rows[rowIndex].Cells) // Get all cells on that row
                            {
                                cell.Style = selectedStyle; // Switch to selected style.
                            }
                        }
                        else
                        {
                            foreach (DataGridViewCell cell in dataGridCompetitors.Rows[rowIndex].Cells)
                            {
                                cell.Style = defaultStyle;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Deletes all rows from competitor grid and re-loads from virtual data, but maintains selected rows on grid.
        /// </summary>
        private void refreshCompetitorGridKeepSelection()
        {
            List<int> selectedRowUID = new List<int>();
            foreach (DataGridViewRow r in dataGridCompetitors.SelectedRows)
            {
                selectedRowUID.Add(Convert.ToInt16(r.Cells[0].Value));
            }
            dataGridCompetitors.Rows.Clear();

            foreach (Competitor c in data.GetCompetitors())
            {
                if (data.GroupValue(c.group) || showCompetitorsUnselectedGroups) // If group has been selected or showing unselected groups' competitors.
                {
                    if (c.name.ToUpper().Contains(filterCompetitor) || c.nationality.ToUpper().Contains(filterCompetitor) || c.group.ToUpper().Contains(filterCompetitor))
                    {
                        int rowIndex = dataGridCompetitors.Rows.Add(c.ID, c.name, c.nationality, c.group); // Add the competitor to the grid.
                        if (data.CompetitorValue(c)) // if the competitor has been selected,
                        {
                            foreach (DataGridViewCell cell in dataGridCompetitors.Rows[rowIndex].Cells) // Get all cells on that row
                            {
                                cell.Style = selectedStyle; // Switch to selected style.
                            }
                        }
                        else
                        {
                            foreach (DataGridViewCell cell in dataGridCompetitors.Rows[rowIndex].Cells)
                            {
                                cell.Style = defaultStyle;
                            }
                        }
                    }
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
        /// Deletes all rows from group grid and re-loads from virtual data.
        /// </summary>
        private void refreshGroupGrid()
        {
            foreach (string group in data.GetGroups())
            {
                if (!data.GroupValue(group))
                {
                    foreach (Competitor c in data.GetCompetitors())
                    {
                        if (c.group == group)
                        {
                            data.SetValue(c, false);
                        }
                    }
                }
            }

            dataGridGroups.Rows.Clear();
            List<string> groupsToAdd = new List<string>();

            foreach (string t in data.GetGroups())
            {
                if ((data.GroupValue(t) && selectionShowGroup == SelectedOption.Selected)
                    || (!data.GroupValue(t) && selectionShowGroup == SelectedOption.Unselected)
                    || selectionShowGroup == SelectedOption.All)
                {
                    if (t.ToUpper().Contains(filterGroup))
                    {
                        groupsToAdd.Add(t);
                    }
                }
            }

            foreach (string t in groupsToAdd)
            {
                int rowIndex = dataGridGroups.Rows.Add(t, Connected_Event.SQL_Controller.GetNumberCompetitorsInGroup(t));
                if (data.GroupValue(t)) // If group selected,
                {
                    foreach (DataGridViewCell cell in dataGridGroups.Rows[rowIndex].Cells) // Get all cells on that row
                    {
                        cell.Style = selectedStyle; // Switch to selected style.
                    }
                }
                else
                {
                    foreach (DataGridViewCell cell in dataGridGroups.Rows[rowIndex].Cells) // Get all cells on that row
                    {
                        cell.Style = defaultStyle; // Switch to default style.
                    }
                }
            }
        }

        /// <summary>
        /// Reloads the competitors and groups from the database.
        /// </summary>
        public void ReloadData()
        {
            List<string> tempGroups = Connected_Event.SQL_Controller.GetGroups(false);
            if (data.GroupCount() > 0) // If first load.
            {
                data.AddGroup(noGroupName);
                for (int Ti = 0; Ti < tempGroups.Count; Ti++)
                {
                    data.AddGroup(tempGroups[Ti]);
                    List<Competitor> tempCompetitors = Connected_Event.SQL_Controller.GetCompetitorsByGroup(tempGroups[Ti]);

                    for (int Ci = 0; Ci < tempCompetitors.Count; Ci++)
                    {
                        data.AddCompetitor(tempCompetitors[Ci]);
                    }
                }
            }
            else // If reloading
            {
                for (int Ti = 0; Ti < tempGroups.Count; Ti++)
                {
                    if (!data.Contains(tempGroups[Ti]))  // If the group does not already exist..
                    {
                        data.AddGroup(tempGroups[Ti]);
                    }

                    List<Competitor> tempCompetitors = Connected_Event.SQL_Controller.GetCompetitorsByGroup(tempGroups[Ti]);

                    for (int Ci = 0; Ci < tempCompetitors.Count; Ci++)
                    {
                        if (!data.Contains(tempCompetitors[Ci])) // If the competitor does not already exist...
                        {
                            data.AddCompetitor(tempCompetitors[Ci]);
                        }
                    }
                }

                foreach (Competitor c1 in data.GetCompetitors()) // Remove duplicate ID competitors who have had values changed.
                {
                    foreach (Competitor c2 in data.GetCompetitors())
                    {
                        if (c1 != c2)
                        {
                            if (c1.ID == c2.ID)
                            {
                                data.RemoveCompetitor(c1);
                            }
                        }
                    }
                }
            }
            refreshGroupGrid();
            refreshCompetitorGrid();
        }

        /// <summary>
        /// Returns the list of competitors that have been selected.
        /// </summary>
        public List<Competitor> GetSelectedCompetitors()
        {
            List<Competitor> competitorsToReturn = new List<Competitor>();
            foreach (Competitor c in data.GetCompetitors())
            {
                if (data.CompetitorValue(c))
                {
                    competitorsToReturn.Add(c);
                }
            }
            return competitorsToReturn;
        }

        public void LoadCompetitorsFromEvent()
        {
            List<Competitor> tempCompetitors = new List<Competitor>();
            foreach (Competitor c in Connected_Event.UnassignedCompetitors)
            {
                int index = data.GetIndexOf(c.ID);
                if (index != -1)
                {
                    tempCompetitors.Add(data.GetCompetitorAt(index));
                }
            }

            foreach (Competitor c in tempCompetitors)
            {
                data.SetValue(c.group, true);
                data.SetValue(c, true);
            }

            refreshCompetitorGrid();
            refreshGroupGrid();
        }

        #region get set operators

        private string filterGroup
        {
            get
            {
                return NfilterGroup;
            }
            set
            {
                if (value == "")
                {
                    inputGroupFilter.Text = "Filter";
                    labelGroupCurrentFilter1.Visible = false;
                    labelGroupCurrentFilter2.Text = "";
                }
                else
                {
                    inputGroupFilter.Text = "Remove Filter";
                    labelGroupCurrentFilter1.Visible = true;
                    labelGroupCurrentFilter2.Text = value;
                }
                NfilterGroup = value.ToUpper();
            }
        }

        private string filterCompetitor
        {
            get
            {
                return NfilterCompetitor;
            }
            set
            {
                if (value == "")
                {
                    inputCompetitorFilter.Text = "Filter";
                    labelCompetitorCurrentFilter1.Visible = false;
                    labelCompetitorCurrentFilter2.Text = "";
                }
                else
                {
                    inputCompetitorFilter.Text = "Remove Filter";
                    labelCompetitorCurrentFilter1.Visible = true;
                    labelCompetitorCurrentFilter2.Text = value;
                }
                NfilterCompetitor = value.ToUpper();
            }
        }
        #endregion

        #region Control Events

        private void inputGroupSelect_Click(object sender, EventArgs e)
        {
            if (dataGridGroups.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow r in dataGridGroups.SelectedRows)
                {
                    data.SetValue(r.Cells[0].Value.ToString(), true);
                }
            }
            refreshGroupGrid();
            refreshCompetitorGridKeepSelection();
        }

        private void inputGroupDeselect_Click(object sender, EventArgs e)
        {
            if (dataGridGroups.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow r in dataGridGroups.SelectedRows)
                {
                    data.SetValue(r.Cells[0].Value.ToString(), false);
                }
            }
            refreshGroupGrid();
            refreshCompetitorGrid();
        }

        private void inputGroupAdd_Click(object sender, EventArgs e)
        {
            string group = MessageBoxes.CreateGroup();
            if (group != "")
            {
                data.AddGroup(group, true);
                refreshGroupGrid();
                refreshCompetitorGridKeepSelection();
            }
        }

        private void inputGroupRemove_Click(object sender, EventArgs e)
        {
            bool remove = false;
            if (dataGridGroups.SelectedRows.Count > 0)
            {
                if (dataGridGroups.SelectedRows.Count > 1) // Different ones for plurals. Yay. ^.^
                {
                    if (MessageBox.Show("Are you sure you wish to remove the selected groups?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        remove = true;
                    }
                }
                else
                {
                    if (MessageBox.Show("Are you sure you wish to remove the selected group?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        remove = true;
                    }
                }

                if (remove) // If the result of the dialog was yes.
                {
                    List<string> groupsToRemove = new List<string>();
                    foreach (DataGridViewRow r in dataGridGroups.SelectedRows)
                    {
                        groupsToRemove.Add(r.Cells[0].Value.ToString());
                    }

                    foreach (string t in groupsToRemove)
                    {
                        data.RemoveGroup(t);

                        foreach (Competitor c in data.GetCompetitors())
                        {
                            if (c.group == t)
                            {
                                Competitor newC = c;
                                newC.group = noGroupName;
                                data.AddCompetitor(newC, data.CompetitorValue(c));
                                data.RemoveCompetitor(c);
                            }
                        }
                    }
                }
            }
            refreshGroupGrid();
            refreshCompetitorGrid();
        }

        private void inputGroupFilter_Click(object sender, EventArgs e)
        {
            if (filterGroup == "")
            {
                filterGroup = MessageBoxes.filterString(filterGroup);
            }
            else
            {
                filterGroup = "";
            }
            refreshGroupGrid();
        }

        private void inputGroupShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectionShowGroup = (SelectedOption)inputGroupShow.SelectedIndex;
            refreshGroupGrid();
        }

        private void inputCompetitorSelect_Click(object sender, EventArgs e)
        {
            if (dataGridCompetitors.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow r in dataGridCompetitors.SelectedRows)
                {
                    Competitor c = new Competitor();
                    c.ID = Convert.ToInt16(r.Cells[0].Value);
                    c.name = r.Cells[1].Value.ToString();
                    c.nationality = r.Cells[2].Value.ToString();
                    c.group = r.Cells[3].Value.ToString();
                    data.SetValue(c, true);
                    if (!data.GroupValue(c.group))
                    {
                        data.SetValue(c.group, true);
                    }
                }
            }
            refreshCompetitorGridKeepSelection();
        }

        private void inputCompetitorDeselect_Click(object sender, EventArgs e)
        {
            if (dataGridCompetitors.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow r in dataGridCompetitors.SelectedRows)
                {
                    Competitor c = new Competitor();
                    c.ID = Convert.ToInt16(r.Cells[0].Value);
                    c.name = r.Cells[1].Value.ToString();
                    c.nationality = r.Cells[2].Value.ToString();
                    c.group = r.Cells[3].Value.ToString();
                    data.SetValue(c, false);
                }
            }
            refreshCompetitorGridKeepSelection();
        }

        private void inputCompetitorAdd_Click(object sender, EventArgs e)
        {
            List<string> tempGroups = new List<string>();
            foreach (string t in data.GetGroups())
            {
                if (data.GroupValue(t))
                {
                    tempGroups.Add(t);
                }
            }
            Competitor c = MessageBoxes.CreateCompetitor(tempGroups);
            if (c != null)
            {
                data.AddCompetitor(c, false);
                Connected_Event.SQL_Controller.CreateCompetitor(c);
                refreshCompetitorGridKeepSelection();
            }
        }

        private void inputCompetitorRemove_Click(object sender, EventArgs e)
        {
            bool remove = false;
            if (dataGridCompetitors.SelectedRows.Count > 0)
            {
                if (dataGridCompetitors.SelectedRows.Count > 1) // Different ones for plurals. Yay. ^.^
                {
                    if (MessageBox.Show("Are you sure you wish to remove the selected competitors?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        remove = true;
                    }
                }
                else
                {
                    if (MessageBox.Show("Are you sure you wish to remove the selected competitor?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        remove = true;
                    }
                }

                if (remove) // If the result of the dialog was yes.
                {
                    foreach (DataGridViewRow r in dataGridCompetitors.SelectedRows)
                    {
                        Competitor c = new Competitor();
                        c.ID = Convert.ToInt16(r.Cells[0].Value);
                        c.name = r.Cells[1].Value.ToString();
                        c.nationality = r.Cells[2].Value.ToString();
                        c.group = r.Cells[3].Value.ToString();

                        data.RemoveCompetitor(c);
                        Connected_Event.SQL_Controller.RemoveCompetitor(c.ID);
                    }
                }
            }
            refreshCompetitorGrid();
        }

        private void inputCompetitorFilter_Click(object sender, EventArgs e)
        {
            if (filterCompetitor == "")
            {
                filterCompetitor = MessageBoxes.filterString(filterCompetitor);
            }
            else
            {
                filterCompetitor = "";
            }
            refreshCompetitorGrid();
        }

        private void inputCompetitorShow_CheckedChanged(object sender, EventArgs e)
        {
            showCompetitorsUnselectedGroups = inputCompetitorShow.Checked;
            if (showCompetitorsUnselectedGroups)
            {
                refreshCompetitorGridKeepSelection();
            }
            else
            {
                refreshCompetitorGrid();
            }
        }

        private void inputEditCompetitors_Click(object sender, EventArgs e)
        {
            Connected_Event.engine.mainForm.openCompetitorEditor();
        }
    }
        #endregion
}
