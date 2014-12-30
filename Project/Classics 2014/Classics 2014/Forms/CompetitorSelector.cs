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
        private string noTeamName;

        public Event Connected_Event;
        #endregion

        #region filterVariables
        string NfilterTeam; // dont reference, use filterTeam instead.
        string NfilterCompetitor; // dont reference, use filterCompetitor instead.
        SelectedOption selectionShowTeam;
        bool showCompetitorsUnselectedTeams;
        #endregion

        public CompetitorSelector(Event Connected_Event)
        {
            this.Connected_Event = Connected_Event;
            InitializeComponent();
            setup();
            setupForm();
            ReloadData();
            inputTeamShow.SelectedIndex = 0;
        }

        /// <summary>
        /// Initialises variables.
        /// </summary>
        private void setup()
        {
            data = new CompetitorSelectorData();
            showCompetitorsUnselectedTeams = false;
            NfilterCompetitor = "";
            NfilterTeam = "";
            noTeamName = "[No Team]";
        }

        /// <summary>
        /// Set form and control options.
        /// </summary>
        private void setupForm()
        {
            selectionShowTeam = SelectedOption.All;
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
                if (data.TeamValue(c.team) || showCompetitorsUnselectedTeams) // If team has been selected or showing unselected teams' competitors.
                {
                    if (c.name.ToUpper().Contains(filterCompetitor) || c.nationality.ToUpper().Contains(filterCompetitor) || c.team.ToUpper().Contains(filterCompetitor))
                    {
                        int rowIndex = dataGridCompetitors.Rows.Add(c.ID, c.name, c.nationality, c.team); // Add the competitor to the grid.
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
                if (data.TeamValue(c.team) || showCompetitorsUnselectedTeams) // If team has been selected or showing unselected teams' competitors.
                {
                    if (c.name.ToUpper().Contains(filterCompetitor) || c.nationality.ToUpper().Contains(filterCompetitor) || c.team.ToUpper().Contains(filterCompetitor))
                    {
                        int rowIndex = dataGridCompetitors.Rows.Add(c.ID, c.name, c.nationality, c.team); // Add the competitor to the grid.
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
        /// Deletes all rows from team grid and re-loads from virtual data.
        /// </summary>
        private void refreshTeamGrid()
        {
            foreach (string team in data.GetTeams())
            {
                if (!data.TeamValue(team))
                {
                    foreach (Competitor c in data.GetCompetitors())
                    {
                        if (c.team == team)
                        {
                            data.SetValue(c, false);
                        }
                    }
                }
            }

            dataGridTeams.Rows.Clear();
            List<string> teamsToAdd = new List<string>();

            foreach (string t in data.GetTeams())
            {
                if ((data.TeamValue(t) && selectionShowTeam == SelectedOption.Selected)
                    || (!data.TeamValue(t) && selectionShowTeam == SelectedOption.Unselected)
                    || selectionShowTeam == SelectedOption.All)
                {
                    if (t.ToUpper().Contains(filterTeam))
                    {
                        teamsToAdd.Add(t);
                    }
                }
            }

            foreach (string t in teamsToAdd)
            {
                int rowIndex = dataGridTeams.Rows.Add(t, Connected_Event.SQL_Controller.GetNumberCompetitorsInTeam(t));
                if (data.TeamValue(t)) // If team selected,
                {
                    foreach (DataGridViewCell cell in dataGridTeams.Rows[rowIndex].Cells) // Get all cells on that row
                    {
                        cell.Style = selectedStyle; // Switch to selected style.
                    }
                }
                else
                {
                    foreach (DataGridViewCell cell in dataGridTeams.Rows[rowIndex].Cells) // Get all cells on that row
                    {
                        cell.Style = defaultStyle; // Switch to default style.
                    }
                }
            }
        }

        /// <summary>
        /// Reloads the competitors and teams from the database.
        /// </summary>
        public void ReloadData()
        {
            List<string> tempTeams = Connected_Event.SQL_Controller.GetCTeams(false);
            if (data.TeamCount() > 0) // If first load.
            {
                data.AddTeam(noTeamName);
                for (int Ti = 0; Ti < tempTeams.Count; Ti++)
                {
                    data.AddTeam(tempTeams[Ti]);
                    List<Competitor> tempCompetitors = Connected_Event.SQL_Controller.GetCompetitorsByCTeam(tempTeams[Ti]);

                    for (int Ci = 0; Ci < tempCompetitors.Count; Ci++)
                    {
                        data.AddCompetitor(tempCompetitors[Ci]);
                    }
                }
            }
            else // If reloading
            {
                for (int Ti = 0; Ti < tempTeams.Count; Ti++)
                {
                    if (!data.Contains(tempTeams[Ti]))  // If the team does not already exist..
                    {
                        data.AddTeam(tempTeams[Ti]);
                    }

                    List<Competitor> tempCompetitors = Connected_Event.SQL_Controller.GetCompetitorsByCTeam(tempTeams[Ti]);

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
            refreshTeamGrid();
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

        #region get set operators

        private string filterTeam
        {
            get
            {
                return NfilterTeam;
            }
            set
            {
                if (value == "")
                {
                    inputTeamFilter.Text = "Filter";
                    labelTeamCurrentFilter1.Visible = false;
                    labelTeamCurrentFilter2.Text = "";
                }
                else
                {
                    inputTeamFilter.Text = "Remove Filter";
                    labelTeamCurrentFilter1.Visible = true;
                    labelTeamCurrentFilter2.Text = value;
                }
                NfilterTeam = value.ToUpper();
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

        private void inputTeamSelect_Click(object sender, EventArgs e)
        {
            if (dataGridTeams.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow r in dataGridTeams.SelectedRows)
                {
                    data.SetValue(r.Cells[0].Value.ToString(), true);
                }
            }
            refreshTeamGrid();
            refreshCompetitorGridKeepSelection();
        }

        private void inputTeamDeselect_Click(object sender, EventArgs e)
        {
            if (dataGridTeams.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow r in dataGridTeams.SelectedRows)
                {
                    data.SetValue(r.Cells[0].Value.ToString(), false);
                }
            }
            refreshTeamGrid();
            refreshCompetitorGrid();
        }

        private void inputTeamAdd_Click(object sender, EventArgs e)
        {
            string team = MessageBoxes.CreateTeam();
            if (team != "")
            {
                data.AddTeam(team, true);
                refreshTeamGrid();
                refreshCompetitorGridKeepSelection();
            }
        }

        private void inputTeamRemove_Click(object sender, EventArgs e)
        {
            bool remove = false;
            if (dataGridTeams.SelectedRows.Count > 0)
            {
                if (dataGridTeams.SelectedRows.Count > 1) // Different ones for plurals. Yay. ^.^
                {
                    if (MessageBox.Show("Are you sure you wish to remove the selected teams?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        remove = true;
                    }
                }
                else
                {
                    if (MessageBox.Show("Are you sure you wish to remove the selected team?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        remove = true;
                    }
                }

                if (remove) // If the result of the dialog was yes.
                {
                    List<string> teamsToRemove = new List<string>();
                    foreach (DataGridViewRow r in dataGridTeams.SelectedRows)
                    {
                        teamsToRemove.Add(r.Cells[0].Value.ToString());
                    }

                    foreach (string t in teamsToRemove)
                    {
                        data.RemoveTeam(t);

                        foreach (Competitor c in data.GetCompetitors())
                        {
                            if (c.team == t)
                            {
                                Competitor newC = c;
                                newC.team = noTeamName;
                                data.AddCompetitor(newC, data.CompetitorValue(c));
                                data.RemoveCompetitor(c);
                            }
                        }
                    }
                }
            }
            refreshTeamGrid();
            refreshCompetitorGrid();
        }

        private void inputTeamFilter_Click(object sender, EventArgs e)
        {
            if (filterTeam == "")
            {
                filterTeam = MessageBoxes.filterString(filterTeam);
            }
            else
            {
                filterTeam = "";
            }
            refreshTeamGrid();
        }

        private void inputTeamShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectionShowTeam = (SelectedOption)inputTeamShow.SelectedIndex;
            refreshTeamGrid();
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
                    c.team = r.Cells[3].Value.ToString();
                    data.SetValue(c, true);
                    if (!data.TeamValue(c.team))
                    {
                        data.SetValue(c.team, true);
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
                    c.team = r.Cells[3].Value.ToString();
                    data.SetValue(c, false);
                }
            }
            refreshCompetitorGridKeepSelection();
        }

        private void inputCompetitorAdd_Click(object sender, EventArgs e)
        {
            List<string> tempTeams = new List<string>();
            foreach (string t in data.GetTeams())
            {
                if (data.TeamValue(t))
                {
                    tempTeams.Add(t);
                }
            }
            Competitor c = MessageBoxes.CreateCompetitor(tempTeams);
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
                        c.team = r.Cells[3].Value.ToString();

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
            showCompetitorsUnselectedTeams = inputCompetitorShow.Checked;
            if (showCompetitorsUnselectedTeams)
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
