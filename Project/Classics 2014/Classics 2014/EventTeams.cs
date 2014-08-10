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
        List<TCompetitor> Competitors;
        int EventID;
        int CompetitorsPerTeam;
        List<List<TCompetitor>> Teams = new List<List<TCompetitor>>();
        List<string> TeamNames = new List<string>();
        int LastIntermixTeam = 0;
        int LastFakeCompetitor = 0;
        Event Connected_Event;

        public EventTeams(Event ConnectedEvent, List<TCompetitor> PassCompetitors, int PassEventID, int PassCompetitorsPerTeam, List<string> SelectedTeams)
        {
            Connected_Event = ConnectedEvent;
            CompetitorsPerTeam = PassCompetitorsPerTeam;
            EventID = PassEventID;
            Competitors = PassCompetitors;
            TeamNames.Add("NO TEAM");
            List<TCompetitor> NOTEAMTeam = new List<TCompetitor>();
            Teams.Add(NOTEAMTeam);

            for (int i = 0; i < SelectedTeams.Count; i++)
            {
                string Name = SelectedTeams[i];
                if (Name != "NO TEAM")
                {
                    TeamNames.Add(Name);
                    List<TCompetitor> CurrentTeam = new List<TCompetitor>();
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
                Teams[i].Clear();
            }

            for (int i = 0; i < Competitors.Count; i++)
            {
                int CurrentTeamIndex = TeamNames.IndexOf(Competitors[i].team);
                Teams[CurrentTeamIndex].Add(Competitors[i]);
            }
        }

        private void RefreshAll()
        {
            comboBoxTeamSelection.Items.Clear();
            listBoxTeams.Items.Clear();
            dataGridViewCompetitors.Rows.Clear();
            comboBoxTeamSelection.Items.Add("NO TEAM");

            for (int i = 0; i < TeamNames.Count; i++)
            {
                if (TeamNames[i] != "NO TEAM")
                {
                    comboBoxTeamSelection.Items.Add(TeamNames[i]);
                    listBoxTeams.Items.Add(TeamNames[i]);
                }
            }

            for (int i = 0; i < Teams.Count; i++)
            {
                for (int i2 = 0; i2 < Teams[i].Count; i2++)
                {
                    if (TeamNames[i] != "NO TEAM")
                    {
                        dataGridViewCompetitors.Rows.Add(Teams[i][i2].ID, Teams[i][i2].name, Teams[i][i2].team, Teams[i][i2].nationality, TeamNames[i]);
                    }
                    else
                    {
                        dataGridViewCompetitors.Rows.Add(Teams[i][i2].ID, Teams[i][i2].name, Teams[i][i2].team, Teams[i][i2].nationality, "");
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
                if (Teams[i].Count == CompetitorsPerTeam || Teams[i].Count == 0)
                {
                    TeamsFull++;
                }
                if (Teams[i].Count > CompetitorsPerTeam)
                {
                    labelWarning.Text = "Team " + TeamNames[i] + " is overfilled, please redistribute competitors or change the number of competitors per team.";
                }
            }
            return TeamsFull;
        }

        private void buttonAddTeam_Click(object sender, EventArgs e)
        {
            LastIntermixTeam++;
            TeamNames.Add("Intermix " + LastIntermixTeam);
            List<TCompetitor> NewTeam = new List<TCompetitor>();
            Teams.Add(NewTeam);
            RefreshAll();
        }

        private void buttonRemoveTeam_Click(object sender, EventArgs e)
        {
            if (LastIntermixTeam != 0)
            {
                int TeamIndex = TeamNames.IndexOf("Intermix " + LastIntermixTeam);
                for (int i = 0; i < Teams[TeamIndex].Count; i++)
                {
                    TCompetitor CurrentCompetitor = Teams[TeamIndex][i];
                    Teams[TeamIndex].Remove(CurrentCompetitor);
                    Teams[0].Add(CurrentCompetitor);
                    i--;
                }

                TeamNames.RemoveAt(TeamIndex);
                Teams.RemoveAt(TeamIndex);
                
                LastIntermixTeam--;
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
            int NewTeamIndex;
            if (dataGridViewCompetitors.SelectedRows != null && comboBoxTeamSelection.SelectedItem.ToString() != "")
            {
                try
                {
                    NewTeamIndex = TeamNames.IndexOf(comboBoxTeamSelection.SelectedItem.ToString());
                }
                catch
                {
                    NewTeamIndex = 0;
                }

                for (int i = 0; i < dataGridViewCompetitors.SelectedRows.Count; i++)
                {
                    if (dataGridViewCompetitors.SelectedRows[i].Cells[0].Value != null && NewTeamIndex != 0)
                    {
                        int TeamIndex;
                        
                        try
                        {
                            if (dataGridViewCompetitors.SelectedRows[i].Cells[4].Value.ToString() != "")
                            {
                                TeamIndex = TeamNames.IndexOf(dataGridViewCompetitors.SelectedRows[i].Cells[4].Value.ToString());
                            }
                            else
                            {
                                TeamIndex = 0;
                            }
                        }
                        catch
                        {
                            TeamIndex = 0;
                        }

                        TCompetitor CurrentCompetitor;
                        CurrentCompetitor.ID = Convert.ToInt16(dataGridViewCompetitors.SelectedRows[i].Cells[0].Value);
                        CurrentCompetitor.name = dataGridViewCompetitors.SelectedRows[i].Cells[1].Value.ToString();
                        CurrentCompetitor.team = dataGridViewCompetitors.SelectedRows[i].Cells[2].Value.ToString();
                        CurrentCompetitor.nationality = dataGridViewCompetitors.SelectedRows[i].Cells[3].Value.ToString();

                        try
                        {
                            Teams[TeamIndex].Remove(CurrentCompetitor);
                            Teams[NewTeamIndex].Add(CurrentCompetitor);
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
            }
            RefreshAll();
        }

        private void AddFakeCompetitor(int TeamIndex)
        {
            LastFakeCompetitor++;
            TCompetitor NewCompetitor = new TCompetitor();
            NewCompetitor.ID = -1;
            NewCompetitor.name = "Fake Competitor " + LastFakeCompetitor;
            NewCompetitor.team = "N/A";
            NewCompetitor.nationality = "N/A";
            Teams[TeamIndex].Add(NewCompetitor);
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
                for (int i = 0; i < Teams.Count; i++)
                {
                    for (int i2 = 0; i2 < Teams[i].Count; i2++)
                    {
                        if (Teams[i][i2].name == "Fake Competitor " + LastFakeCompetitor)
                        {
                            Teams[i].RemoveAt(i2);
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
            if (Teams[0].Count > 0)
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
                for (int i2 = 0; i2 < Teams[i].Count; i2++)
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
                        Connected_Event.SaveEventTeams(CompetitorsPerTeam, Teams, TeamNames);
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
            for (int i = 0; i < Teams.Count; i++)
            {
                if (Teams[i].Count < CompetitorsPerTeam && Teams[i].Count != 0 && TeamNames[i] != "NO TEAM")
                {
                    int StartCount = Teams[i].Count;
                    for (int i2 = 0; i2 < CompetitorsPerTeam - StartCount; i2++)
                    {
                        AddFakeCompetitor(i);
                    }
                }
            }
            RefreshAll();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Connected_Event.TabControl.TabPages.Remove(Connected_Event.TabControl.SelectedTab);
            Connected_Event.TabControl.SelectedTab = Connected_Event.TabControl.TabPages[0];
            Connected_Event.SaveEventTeamsIncludeNOTEAM(CompetitorsPerTeam, Teams, TeamNames);
        }

    }
}
