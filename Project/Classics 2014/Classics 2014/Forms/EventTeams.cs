using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classics_2014
{
    partial class EventTeams : UserControl
    {
        List<EventCompetitor> Competitors;
        int EventID;
        int CompetitorsPerTeam;
        List<Team> Teams;
        int LastFakeCompetitor = 0;
        Event Connected_Event;

        public EventTeams(Event Connected_Event, List<Competitor> Competitors, int EventID, int CompetitorsPerTeam, List<string> SelectedTeams)
        {
            this.Connected_Event = Connected_Event;
            this.CompetitorsPerTeam = CompetitorsPerTeam;
            this.EventID = EventID;
            this.Competitors = GlobalFunctions.ConvertCompetitorsForEvent(Competitors);

            Teams = new List<Team>();
            Team newTeam = new Team();
            newTeam.Name = "NO TEAM";
            newTeam.Competitors = new List<EventCompetitor>();
            Teams.Add(newTeam);
            for (int i = 0; i < SelectedTeams.Count; i++)
            {
                string Name = SelectedTeams[i];
                if (Name != "NO TEAM")
                {
                    Team CurrentTeam = new Team();
                    CurrentTeam.Name = Name;
                    CurrentTeam.Competitors = new List<EventCompetitor>();
                    Teams.Add(CurrentTeam);
                }
            }

            InitializeComponent();
            numericUpDownCompetitorsPerTeam.Value = CompetitorsPerTeam;
            PlaceCompetitorsInDefaultTeams();
            RefreshAll();
        }

        

        private void PlaceCompetitorsInDefaultTeams()
        {
            for (int i = 0; i < Teams.Count; i++)
            {
                Teams[i].Competitors.Clear();
            }

            for (int Ci = 0; Ci < Competitors.Count; Ci++)
            {
                for (int Ti = 0; Ti < Teams.Count; Ti++)
                {
                    if (Competitors[Ci].team == Teams[Ti].Name)
                    {
                        Teams[Ti].Competitors.Add(Competitors[Ci]);
                    }
                }
            }
        }

        private void RefreshAll()
        {
            comboBoxTeamSelection.Items.Clear();
            listBoxTeams.Items.Clear();
            dataGridViewCompetitors.Rows.Clear();
            comboBoxTeamSelection.Items.Add("NO TEAM");

            for (int Ti = 0; Ti < Teams.Count; Ti++)
            {
                if (Teams[Ti].Name != "NO TEAM")
                {
                    comboBoxTeamSelection.Items.Add(Teams[Ti].Name);
                    listBoxTeams.Items.Add(Teams[Ti].Name);
                }
                for (int Ci = 0; Ci < Teams[Ti].Competitors.Count; Ci++)
                {
                    if (Teams[Ti].Name == "NO TEAM") // If no team, add blank Scoring Team Column.
                    {
                        dataGridViewCompetitors.Rows.Add(Teams[Ti].Competitors[Ci].ID, Teams[Ti].Competitors[Ci].name, Teams[Ti].Competitors[Ci].team, Teams[Ti].Competitors[Ci].nationality, "");
                    }
                    else // Otherwise, use scoring team xD
                    {
                        dataGridViewCompetitors.Rows.Add(Teams[Ti].Competitors[Ci].ID, Teams[Ti].Competitors[Ci].name, Teams[Ti].Competitors[Ci].team, Teams[Ti].Competitors[Ci].nationality, Teams[Ti].Name);
                    }
                }
            }

            labelTeamsFilled.Text = GetTeamsFullOrEmpty() + " / " + (Teams.Count -1) ;
            
        }

        private int GetTeamsFullOrEmpty()
        {
            int TeamsFull = 0;
            labelWarning.Text = "";
            for (int i = 1; i < Teams.Count; i++) 
            {
                if (Teams[i].Competitors.Count == CompetitorsPerTeam || Teams[i].Competitors.Count == 0)
                {
                    TeamsFull++;
                }
                if (Teams[i].Competitors.Count > CompetitorsPerTeam)
                {
                    labelWarning.Text = "Team " + Teams[i].Name + " is overfilled, please redistribute competitors or change the number of competitors per team.";
                }
            }
            return TeamsFull;
        }

        private void buttonAddTeam_Click(object sender, EventArgs e)
        {
            string NewTeamName = CustomMessageBox.Show(ModifyNameTypes.Scoring_Team);
            bool isUnique = true;
            for (int Ti = 0; Ti < Teams.Count; Ti++)
            {
                if (Teams[Ti].Name == NewTeamName)
                {
                    isUnique = false;
                }
            }
            if (isUnique == true)
            {
                Team NewTeam = new Team();
                NewTeam.Name = NewTeamName;
                NewTeam.Competitors = new List<EventCompetitor>();
                Teams.Add(NewTeam);
                RefreshAll();
            }
            else
            {
                MessageBox.Show("A team with that name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemoveTeam_Click(object sender, EventArgs e)
        {
            if (listBoxTeams.SelectedItem != null) // Add error
            {
                string TeamName = listBoxTeams.SelectedItem.ToString();
                for (int Ti = 0; Ti < Teams.Count; Ti++)
                {
                    if (Teams[Ti].Name == TeamName)
                    {
                        for (int Ci = 0; Ci < Teams[Ti].Competitors.Count; Ci++) // Copy the team contents over to "NO TEAM"
                        {
                            Teams[0].Competitors.Add(Teams[Ti].Competitors[Ci]);
                        }
                        Teams.Remove(Teams[Ti]);
                    }
                }
                RefreshAll();
            }
        }

        private void numericUpDownCompetitorsPerTeam_ValueChanged(object sender, EventArgs e)
        {
            CompetitorsPerTeam = Convert.ToInt16(numericUpDownCompetitorsPerTeam.Value);
            labelTeamsFilled.Text = GetTeamsFullOrEmpty() + " / " + (Teams.Count - 1);
        }

        private void comboBoxTeamSelection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string DestinationTeam = comboBoxTeamSelection.SelectedItem.ToString();
            int DestinationTeamID = 0;

            for (int i = 0; i < Teams.Count; i++)
            {
                if (Teams[i].Name == DestinationTeam)
                {
                    DestinationTeamID = i;
                }
            }

            if (dataGridViewCompetitors.SelectedRows != null && comboBoxTeamSelection.SelectedItem.ToString() != "")
            {
                List<int> UIDToMove = new List<int>();
                for (int i = 0; i < dataGridViewCompetitors.SelectedRows.Count; i++)
                {
                    if (dataGridViewCompetitors.SelectedRows[i].Cells[0].Value != null)
                    {
                        UIDToMove.Add(Convert.ToInt16(dataGridViewCompetitors.SelectedRows[i].Cells[0].Value));
                    }
                }

                for (int Ti = 0; Ti < Teams.Count; Ti++)
                {
                    if (Teams[Ti].Name != DestinationTeam)
                    {
                        for (int Ci = 0; Ci < Teams[Ti].Competitors.Count; Ci++)
                        {
                            bool hasBeenMoved = false;
                            for (int i = 0; i < UIDToMove.Count; i++)
                            {
                                if (hasBeenMoved == false)
                                {
                                    if (Teams[Ti].Competitors[Ci].ID == UIDToMove[i])
                                    {
                                        Teams[DestinationTeamID].Competitors.Add(Teams[Ti].Competitors[Ci]);
                                        Teams[Ti].Competitors.RemoveAt(Ci);
                                        hasBeenMoved = true;
                                        Ci--;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            RefreshAll();
        }

        private void AddFakeCompetitor(int TeamIndex)
        {
            LastFakeCompetitor++;
            EventCompetitor NewCompetitor = new EventCompetitor();
            NewCompetitor.ID = -1;
            NewCompetitor.name = "Fake Competitor " + LastFakeCompetitor;
            NewCompetitor.team = "N/A";
            NewCompetitor.nationality = "N/A";
            NewCompetitor.EID = "";
            Teams[TeamIndex].Competitors.Add(NewCompetitor);
        }

        private void buttonAddFakeCompetitor_Click(object sender, EventArgs e)
        {
            AddFakeCompetitor(0);
            RefreshAll();
        }

        private void buttonRemoveFakeCompetitor_Click(object sender, EventArgs e)
        {
            bool RemovedMember = false;
            if (LastFakeCompetitor > 0)
            {
                for (int Ti = 0; Ti < Teams.Count; Ti++)
                {
                    for (int Ci = 0; Ci < Teams[Ti].Competitors.Count; Ci++)
                    {
                        if (Teams[Ti].Competitors[Ci].name == "Fake Competitor " + LastFakeCompetitor)
                        {
                            Teams[Ti].Competitors.RemoveAt(Ci);
                            RemovedMember = true;
                        }
                    }
                }
            }

            if (RemovedMember == true)
            {
                LastFakeCompetitor--;
                RefreshAll();
            }
            else
            {
                labelWarning.Text = "Could not remove last competitor.";
            }
        }

        private bool NoTeamCheck()
        {
            if (Teams[0].Competitors.Count > 0)
            {
                if (MessageBox.Show("There are still competitors with no team, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private bool CheckCompetitorCount()
        {
            int Competitors = 0;
            for (int i = 1; i < Teams.Count; i++)
            {
                for (int i2 = 0; i2 < Teams[i].Competitors.Count; i2++)
                {
                    Competitors++;
                }
            }
            return (Competitors > 0);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (CheckCompetitorCount())
            {
                if (NoTeamCheck())
                {
                    if (GetTeamsFullOrEmpty() == Teams.Count - 1)
                    {
                        Connected_Event.TabControl.TabPages.Remove(Connected_Event.TabControl.SelectedTab);
                        Connected_Event.TabControl.SelectedTab = Connected_Event.TabControl.TabPages[0];
                        Connected_Event.SaveEventTeams(CompetitorsPerTeam, Teams);
                        Connected_Event.ProceedToEvent();
                        switch (Connected_Event.EventType)
                        {
                            case EventType.Accuracy:
                                Accuracy.Accuracy_Event accEvent = (Connected_Event as Accuracy.Accuracy_Event);
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not all teams full or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please organise competitors into teams.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Connected_Event.SQL_Controller.RemoveEvent(EventID);
            Connected_Event.ReturnToOptions();
        }

        private void buttonFillTeams_Click(object sender, EventArgs e)
        {
            for (int Ti = 0; Ti < Teams.Count; Ti++)
            {
                if (Teams[Ti].Competitors.Count < CompetitorsPerTeam && Teams[Ti].Competitors.Count != 0 && Teams[Ti].Name != "NO TEAM")
                {
                    int StartCount = Teams[Ti].Competitors.Count;
                    for (int i2 = 0; i2 < CompetitorsPerTeam - StartCount; i2++)
                    {
                        AddFakeCompetitor(Ti);
                    }
                }
            }
            RefreshAll();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Connected_Event.TabControl.TabPages.Remove(Connected_Event.TabControl.SelectedTab);
            Connected_Event.TabControl.SelectedTab = Connected_Event.TabControl.TabPages[0];
            Connected_Event.SaveEventTeams(CompetitorsPerTeam, Teams);
        }

    }
}
