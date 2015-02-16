using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace CMS.Forms
{
    partial class TeamPicker : UserControl
    {
        #region Variables and such like
        private char[] trimChars = new char[2]{'T', 'C'}; // For trimming node names.
        private Event Connected_Event;
        private ObservableCollection<Team> teams;
        private ObservableCollection<Competitor> unassignedCompetitors;
        #endregion

        public TeamPicker(Event connected_event)
        {
            this.Connected_Event = connected_event;
            teams = new ObservableCollection<Team>();
            InitializeComponent();

            unassignedCompetitors = new ObservableCollection<Competitor>();
            foreach (Competitor c in Connected_Event.Teams[0].Competitors)
            {
                unassignedCompetitors.Add(c);
            }
            refreshCompetitorGrid();

            teams.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(teams_CollectionChanged);
            unassignedCompetitors.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(unassignedCompetitors_CollectionChanged);
            treeViewTeams.AfterSelect += new TreeViewEventHandler(treeViewTeams_AfterSelect);
        }

        private void refreshCompetitorGrid()
        {
            dataGridCompetitors.SuspendLayout();
            dataGridCompetitors.Rows.Clear();
            foreach (Competitor c in unassignedCompetitors)
            {
                dataGridCompetitors.Rows.Add(c.ID, c.name, c.nationality, c.group);
            }
            dataGridCompetitors.ResumeLayout();
        }

        private void refreshTeamTree()
        {
            int ti = -1; // Team Index
            int ci = 0; // Competitor Index

            treeViewTeams.SuspendLayout();
            foreach (Team t in teams)
            {
                ci = 0;
                treeViewTeams.Nodes.Add("T" + t.ID.ToString(), t.Name); // Will make name of node T[ID].
                ti++;
                foreach (EventCompetitor c in t.Competitors)
                {
                    treeViewTeams.Nodes[ti].Nodes.Add("C" + t.ID.ToString(), c.name); // Will make name of node C[ID]
                    ci++;
                }
            }
            treeViewTeams.ResumeLayout();
        }

        /// <summary>
        /// Gets the currently highlighted team, if any, from the tree view. Otherwise returns null if none are highlighted.
        /// </summary>
        private Team getSelectedNodeTeam()
        {
            if (treeViewTeams.SelectedNode.Level < 1) // If team node selected
            {
                int teamID = Convert.ToInt16(treeViewTeams.SelectedNode.Name.TrimStart(trimChars)); // Get ID from name.
                return getTeamFromID(teamID);
            }
            else
            {
                int teamID = Convert.ToInt16(treeViewTeams.SelectedNode.Parent.Name.TrimStart(trimChars)); // Get team from parent node.
                return getTeamFromID(teamID);
            }
        }

        /// <summary>
        /// Gets the currently highlighted competitor, if any, from the tree view. Otherwise returns null if none are highlighted, or cannot be found.
        /// </summary>
        private EventCompetitor getSelectedNodeCompetitor()
        {
            Team team;
            if (treeViewTeams.SelectedNode.Level >= 1)
            {
                team = getTeamFromID(Convert.ToInt16(treeViewTeams.SelectedNode.Parent.Name.TrimStart(trimChars)));
                int competitorID = Convert.ToInt16(treeViewTeams.SelectedNode.Name.TrimStart(trimChars));
                foreach (EventCompetitor c in team.Competitors)
                {
                    if (c.ID == competitorID)
                    {
                        return c;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets a team object from its ID. Returns null if none found.
        /// </summary>
        private Team getTeamFromID(int ID)
        {
            foreach (Team t in teams)
            {
                if (t.ID == ID)
                {
                    return t;
                }
            }
            return null;
        }

        private List<string> getAllTeamNames()
        {
            List<string> names = new List<string>();
            foreach (Team t in teams)
            {
                names.Add(t.Name);
            }
            return names;
        }

        private void createTeam(string teamName)
        {
            Team currentTeam = Connected_Event.SQL_Controller.CreateTeam(Connected_Event.EventID, teamName);
        }

        private void unassignedCompetitors_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            refreshCompetitorGrid(); 
        }

        private void teams_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            refreshTeamTree();
        }

        private void treeViewTeams_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewTeams.SelectedNode != null)
            {
                listViewSelectionProperties.SuspendLayout();
                listViewSelectionProperties.Items.Clear();
                Team t = getSelectedNodeTeam();
                List<ListViewItem> items = new List<ListViewItem>();

                if (treeViewTeams.SelectedNode.Level == 0) // If team
                {
                    items.Add(new ListViewItem("Name:", listViewSelectionProperties.Groups[0]));
                    items.Add(new ListViewItem(t.Name, listViewSelectionProperties.Groups[0]));
                    items.Add(new ListViewItem("Count:", listViewSelectionProperties.Groups[0]));
                    items.Add(new ListViewItem(t.Competitors.Count.ToString(), listViewSelectionProperties.Groups[0]));
                }
                else // If competitor
                {
                    EventCompetitor c = getSelectedNodeCompetitor();
                    items.Add(new ListViewItem("Name:", listViewSelectionProperties.Groups[0]));
                    items.Add(new ListViewItem(c.name, listViewSelectionProperties.Groups[0]));
                    items.Add(new ListViewItem("Nationality:", listViewSelectionProperties.Groups[0]));
                    items.Add(new ListViewItem(c.nationality, listViewSelectionProperties.Groups[0]));
                    items.Add(new ListViewItem("Group:", listViewSelectionProperties.Groups[0]));
                    items.Add(new ListViewItem(c.group, listViewSelectionProperties.Groups[0]));
                    items.Add(new ListViewItem("Event ID:", listViewSelectionProperties.Groups[0]));
                    items.Add(new ListViewItem(c.EID, listViewSelectionProperties.Groups[0]));
                }

                foreach (ListViewItem g in items)
                {
                    listViewSelectionProperties.Items.Add(g);
                }

                items = null;
                pictureBoxTeamImage.Image = t.TeamImage;
            }
            else
            {
                pictureBoxTeamImage.Image = null;
            }
        }

        #region Control Events

        private void inputAssignDefault_Click(object sender, EventArgs e)
        {

        }

        private void inputFilterOption_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void inputAddTeam_Click(object sender, EventArgs e)
        {
            List<string> names = getAllTeamNames();

            string newName = MessageBoxes.CreateTeam();
            bool unique = true;

            foreach (string t in names)
            {
                if (newName == t)
                {
                    unique = false;
                }
            }

            if (unique)
            {
                createTeam(newName);
            }
        }

        private void inputRemoveTeam_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to remove the selected team?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

            }
        }

        private void inputFillRemaining_Click(object sender, EventArgs e)
        {

        }

        private void inputAddTo_Click(object sender, EventArgs e)
        {
            List<int> competitorsToMove = new List<int>();
            Team team = getSelectedNodeTeam(); // Get the team
            Team tempTeam = (Team)team.Clone(); // Clone the team

            foreach (DataGridViewRow r in dataGridCompetitors.SelectedRows) // Get all of the ID's of competitors to be moved.
            {
                competitorsToMove.Add(Convert.ToInt16(r.Cells[0].Value));
            }

            if (competitorsToMove.Count > 0)
            {
                foreach (Competitor c in unassignedCompetitors) // Add all of the competitors to the tempTeam.
                {
                    foreach (int id in competitorsToMove)
                    {
                        if (c.ID == id)
                        {
                            tempTeam.Competitors.Add((EventCompetitor)c);
                        }
                    }
                }

                team = tempTeam; // Make the team equal to the temp team, forcing the refresh event on control.

                foreach (Competitor c in unassignedCompetitors) // Remove the competitors from the unassigned list.
                {
                    foreach (int id in competitorsToMove)
                    {
                        if (c.ID == id)
                        {
                            unassignedCompetitors.Remove(c);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No competitors selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void inputRemoveFrom_Click(object sender, EventArgs e)
        {

        }
    }
#endregion
}
