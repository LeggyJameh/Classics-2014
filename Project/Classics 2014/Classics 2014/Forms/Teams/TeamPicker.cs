using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace CMS
{
    partial class TeamPicker : UserControl
    {
        #region Variables and such like
        private int competitorsPerTeam;
        private char[] trimChars = new char[2]{'T', 'C'}; // For trimming node names.
        private Event Connected_Event;
        private ObservableCollection<Team> teams;
        private ObservableCollection<Competitor> unassignedCompetitors;
        private FilterOption filterOption;
        private const string fakeCompetitorName = "Fake Competitor";
        #endregion

        public TeamPicker(Event connected_event, int competitorsPerTeam)
        {
            this.Connected_Event = connected_event;
            this.competitorsPerTeam = competitorsPerTeam;
            teams = new ObservableCollection<Team>();
            InitializeComponent();
            filterOption = FilterOption.Both;
            inputFilterOption.SelectedIndex = 0;

            unassignedCompetitors = new ObservableCollection<Competitor>();
            if (Connected_Event.Teams.Count < 1) // If new
            {
                foreach (Competitor c in Connected_Event.UnassignedCompetitors)
                {
                    unassignedCompetitors.Add(c);
                }
            }
            else // If Loading
            {
                foreach (Team t in Connected_Event.Teams)
                {
                    t.addUpdateDelegate(new SubCollectionUpdatedDelegate(teams_CollectionChanged));
                    teams.Add(t);
                }

                foreach (Competitor c in Connected_Event.UnassignedCompetitors)
                {
                    unassignedCompetitors.Add(c);
                }
                refreshTeamTree();
            }
            refreshCompetitorGrid();

            teams.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(teams_CollectionChanged);
            unassignedCompetitors.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(unassignedCompetitors_CollectionChanged);
            treeViewTeams.AfterSelect += new TreeViewEventHandler(treeViewTeams_AfterSelect);
        }

        /// <summary>
        /// Causes the teampicker to reload all teams as the competitor editor has been used.
        /// </summary>
        public void refreshCompetitors()
        {
            Connected_Event.engine.mainForm.selectTab((TabPage)this.Parent);
            MessageBox.Show("Competitors have been modified. Teams must be reloaded.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            List<int> IDs = new List<int>();
            List<Competitor> tempCompetitors = new List<Competitor>();

            foreach (Competitor c in unassignedCompetitors)
            {
                IDs.Add(c.ID);
            }

            tempCompetitors = Connected_Event.SQL_Controller.GetCompetitorsByIDList(IDs);
            unassignedCompetitors.Clear();

            foreach (Competitor c in tempCompetitors)
            {
                unassignedCompetitors.Add(c);
            }

            IDs.Clear();
            foreach (Team t in teams)
            {
                foreach (EventCompetitor c in t.Competitors)
                {
                    IDs.Add(c.ID);
                }

                tempCompetitors = Connected_Event.SQL_Controller.GetCompetitorsByIDList(IDs);

                foreach (EventCompetitor c in t.Competitors)
                {
                    foreach (Competitor n in tempCompetitors)
                    {
                        if (c.ID == n.ID)
                        {
                            c.group = n.group;
                            c.name = n.name;
                            c.nationality = n.nationality;
                        }
                    }
                }
            }
        }

        private void save()
        {
            Connected_Event.SaveCurrentStage();
            List<Team> tempTeams = new List<Team>();
            foreach (Team t in teams)
            {
                t.EventID = Connected_Event.EventID;
                tempTeams.Add(t);
                Connected_Event.SQL_Controller.ModifyTeam(t);
            }
            Connected_Event.Teams = tempTeams;
        }

        private void backToEventInit()
        {
            foreach (Team t in teams)
            {
                foreach (EventCompetitor c in t.Competitors)
                {
                    if (c.ID != -1)
                    {
                        unassignedCompetitors.Add((Competitor)c);
                    }
                }
            }

            Connected_Event.UnassignedCompetitors.Clear();

            foreach (Competitor c in unassignedCompetitors)
            {
                Connected_Event.UnassignedCompetitors.Add(c);
            }
            Connected_Event.PreviousStage();
        }

        /// <summary>
        /// Fills the teams to the maximum allowed number with fake competitors.
        /// </summary>
        private void fillTeams()
        {
            foreach (Team t in teams)
            {
                int noEmpty = competitorsPerTeam - t.Competitors.Count;

                for (int i = 0; i < noEmpty; i++)
                {
                    EventCompetitor fake = new EventCompetitor();
                    fake.EID = "";
                    fake.group = "";
                    fake.ID = -1;
                    fake.name = fakeCompetitorName;
                    fake.nationality = "Zerg";
                    t.Competitors.Add(fake);
                }
            }
        }

        /// <summary>
        /// Function that is called to ensure that the next stage can be loaded. Returns true if all is in order.
        /// </summary>
        private bool canContinue()
        {
            bool underfilledTeams = false;
            bool overfilledteams = false;
            bool emptyTeams = false;

            foreach (Team t in teams)
            {
                if (t.Competitors.Count > competitorsPerTeam)
                {
                    overfilledteams = true;
                }
                if (t.Competitors.Count < competitorsPerTeam)
                {
                    underfilledTeams = true;
                }
                if (t.Competitors.Count == 0)
                {
                    emptyTeams = true;
                }
            }

            if (overfilledteams)
            {
                MessageBox.Show("There are overfilled teams, please remove some competitors and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (underfilledTeams)
            {
                string selection = MessageBoxes.underfilledTeamsCheck();

                switch (selection)
                {
                    case "Fill teams":
                        fillTeams();
                        break;
                    case "Cancel":
                        return false;
                        break;
                }
            }

            if (emptyTeams)
            {
                DialogResult result = MessageBox.Show("There are empty teams, remove them?", "Empty teams detected", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

                switch (result)
                {
                    case DialogResult.Yes:
                        List<Team> teamsToRemove = new List<Team>();
                        foreach (Team t in teams)
                        {
                            if (t.Competitors.Count == 0)
                            {
                                teamsToRemove.Add(t);
                            }
                        }

                        foreach (Team t in teamsToRemove)
                        {
                            teams.Remove(t);
                        }
                        break;
                    case DialogResult.Cancel:
                        return false;
                        break;
                }
            }
            return true;
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
            treeViewTeams.Nodes.Clear();
            switch (filterOption)
            {
                case FilterOption.Both:
                    foreach (Team t in teams)
                    {
                        ti++;
                        ci = 0;
                        treeViewTeams.Nodes.Add("T" + t.ID.ToString(), t.Name); // Will make name of node T[ID].
                        foreach (EventCompetitor c in t.Competitors)
                        {
                            treeViewTeams.Nodes[ti].Nodes.Add("C" + c.ID.ToString(), c.name); // Will make name of node C[ID]
                            ci++;
                        }
                    }
                    break;

                case FilterOption.Full:
                    foreach (Team t in teams)
                    {
                        if (t.Competitors.Count >= competitorsPerTeam)
                        {
                            ti++;
                            ci = 0;
                            treeViewTeams.Nodes.Add("T" + t.ID.ToString(), t.Name); // Will make name of node T[ID].
                            foreach (EventCompetitor c in t.Competitors)
                            {
                                treeViewTeams.Nodes[ti].Nodes.Add("C" + c.ID.ToString(), c.name); // Will make name of node C[ID]
                                ci++;
                            }
                        }
                    }
                    break;

                case FilterOption.NotFull:
                    foreach (Team t in teams)
                    {
                        if (t.Competitors.Count < competitorsPerTeam)
                        {
                            ti++;
                            ci = 0;
                            treeViewTeams.Nodes.Add("T" + t.ID.ToString(), t.Name); // Will make name of node T[ID].
                            foreach (EventCompetitor c in t.Competitors)
                            {
                                treeViewTeams.Nodes[ti].Nodes.Add("C" + c.ID.ToString(), c.name); // Will make name of node C[ID]
                                ci++;
                            }
                        }
                    }
                    break;
            }
            treeViewTeams.ResumeLayout();
        }

        /// <summary>
        /// Gets the currently highlighted team, if any, from the tree view. Otherwise returns null if none are highlighted.
        /// </summary>
        private Team getSelectedNodeTeam()
        {
            if (treeViewTeams.SelectedNode != null)
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
            return null;
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
            currentTeam.addUpdateDelegate(new SubCollectionUpdatedDelegate(teams_CollectionChanged));
            teams.Add(currentTeam);
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
                dataGridViewProperties.SuspendLayout();
                dataGridViewProperties.Rows.Clear();
                Team t = getSelectedNodeTeam();

                if (t != null)
                {
                    if (treeViewTeams.SelectedNode.Level == 0) // If team
                    {
                        dataGridViewProperties.Rows.Add("Name:", t.Name);
                        dataGridViewProperties.Rows.Add("Member Count:", t.Competitors.Count.ToString());
                    }
                    else // If competitor
                    {
                        EventCompetitor c = getSelectedNodeCompetitor();
                        if (c != null)
                        {
                            dataGridViewProperties.Rows.Add("Name:", c.name);
                            dataGridViewProperties.Rows.Add("Nationality:", c.nationality);
                            dataGridViewProperties.Rows.Add("Group:", c.group);
                            dataGridViewProperties.Rows.Add("Event ID:", c.EID);
                        }
                    }
                }
                if (t.TeamImage != null)
                {
                    pictureBoxTeamImage.Image = t.TeamImage;
                }
                else
                {
                    pictureBoxTeamImage.Image = CMS.Properties.Resources.AddImage;
                }
            }
            else
            {
                pictureBoxTeamImage.Image = CMS.Properties.Resources.AddImage;
            }
            dataGridViewProperties.ResumeLayout();
        }

        #region Control Events

        private void inputAssignDefault_Click(object sender, EventArgs e)
        {
            List<Competitor> competitorsToRemove = new List<Competitor>();
            foreach (Competitor c in unassignedCompetitors)
            {
                string currentGroup = c.group;
                bool unique = true;

                foreach (Team t in teams) // Check to see if a team with this name already exists.
                { 
                    if (t.Name == currentGroup)
                    {
                        unique = false;
                    }
                }

                if (unique)
                {
                    createTeam(currentGroup);
                    teams[teams.Count - 1].Competitors.Add(new EventCompetitor(c));
                    competitorsToRemove.Add(c);
                }
                else
                {
                    Team currentTeam = new Team();
                    // Check if duplicate competitor exists, if not, insert competitor
                    foreach (Team t in teams)
                    {
                        if (t.Name == currentGroup)
                        {
                            currentTeam = t;
                        }
                    }

                    if (currentTeam.ID != -1)
                    {
                        unique = true;
                        foreach (EventCompetitor ec in currentTeam.Competitors)
                        {
                            if (ec.ID == c.ID)
                            {
                                unique = false;
                            }
                        }

                        if (unique)
                        {
                            currentTeam.Competitors.Add(new EventCompetitor(c));
                            competitorsToRemove.Add(c);
                        }
                        else
                        {
                            competitorsToRemove.Add(c);
                        }
                    }
                }
            }

            foreach (Competitor c in competitorsToRemove)
            {
                unassignedCompetitors.Remove(c);
            }
        }

        private void inputFilterOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (inputFilterOption.SelectedIndex)
            {
                case 0:
                    filterOption = FilterOption.Both;
                    break;
                case 1:
                    filterOption = FilterOption.Full;
                    break;
                case 2:
                    filterOption = FilterOption.NotFull;
                    break;
            }
            refreshTeamTree();
        }

        private void inputAddTeam_Click(object sender, EventArgs e)
        {
            List<string> names = getAllTeamNames();

            string newName = MessageBoxes.CreateTeam();
            bool unique = true;

            if (newName != null && newName != "") // Make sure the user did not leave the message box empty or cancelled.
            {
                foreach (string t in names) // Check to see if team already exists.
                {
                    if (newName == t)
                    {
                        unique = false;
                    }
                }

                if (unique) // If it's unique, add it.
                {
                    createTeam(newName);
                }
                else
                {
                    MessageBox.Show("Team already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void inputRemoveTeam_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to remove the selected team?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Team teamToRemove = getSelectedNodeTeam();
                if (teamToRemove != null)
                {

                    foreach (EventCompetitor c in teamToRemove.Competitors)
                    {
                        unassignedCompetitors.Add((Competitor)c);
                    }

                    teams.Remove(teamToRemove);
                    Connected_Event.SQL_Controller.RemoveTeam(teamToRemove);
                    teamToRemove = null;
                }
                else
                {
                    MessageBox.Show("Error", "No team selected.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void inputFillRemaining_Click(object sender, EventArgs e)
        {
            fillTeams();
        }

        private void inputAddTo_Click(object sender, EventArgs e)
        {
            List<int> competitorsToMove = new List<int>();
            Team team = getSelectedNodeTeam(); // Get the team
            List<Competitor> competitorsToRemove = new List<Competitor>();

            if (team != null)
            {
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
                                team.Competitors.Add(new EventCompetitor(c));
                                competitorsToRemove.Add(c);
                            }
                        }
                    }

                    foreach (Competitor c in competitorsToRemove)
                    {
                        unassignedCompetitors.Remove(c);
                    }
                
                }
                else
                {
                    MessageBox.Show("No competitors selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("No team selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void inputRemoveFrom_Click(object sender, EventArgs e)
        {
            EventCompetitor currentCompetitor = getSelectedNodeCompetitor();
            Team currentTeam = getSelectedNodeTeam();

            if (currentCompetitor != null)
            {
                int teamIndex = teams.IndexOf(currentTeam);
                teams[teamIndex].Competitors.Remove(currentCompetitor);

                if (currentCompetitor.ID != -1)
                {
                    unassignedCompetitors.Add((Competitor)currentCompetitor);
                }
            }
        }

        private void inputEmptyTeam_Click(object sender, EventArgs e)
        {
            Team currentTeam = getSelectedNodeTeam();
            int teamIndex = teams.IndexOf(currentTeam);

            foreach (EventCompetitor c in teams[teamIndex].Competitors)
            {
                if (c.ID != -1)
                {
                    unassignedCompetitors.Add((Competitor)c);
                }
            }
            teams[teamIndex].Competitors.Clear();
        }

        private void pictureBoxTeamImage_Click(object sender, EventArgs e)
        {
            Team selectedTeam = getSelectedNodeTeam();

            if (selectedTeam != null)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap currentImage = (Bitmap)Image.FromFile(dialog.FileName);
                    selectedTeam.TeamImage = currentImage;
                    pictureBoxTeamImage.Image = currentImage;
                }
            }
            else
            {
                MessageBox.Show("No team selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void inputSaveAndContinue_Click(object sender, EventArgs e)
        {
            save();
            if (canContinue())
            {
                save();
                Connected_Event.NextStage();
            }
        }

        private void inputSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void inputBack_Click(object sender, EventArgs e)
        {
            backToEventInit();
        }

        private void inputCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to save your changes before cancelling?", "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

            switch (result)
            {
                case DialogResult.Yes:
                    save();
                    Connected_Event.Exit();
                    break;
                case DialogResult.No:
                    Connected_Event.Exit();
                    break;
            }
        }
    }
#endregion
}
