using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classics_2014.Accuracy
{
    partial class EventAccuracyInit : UserControl
    {
        Accuracy_Event Connected_Event;
        TabControl TabControl;
        List<Competitor> Competitors = new List<Competitor>();
        List<bool> SelectedCompetitors = new List<bool>();

        List<string> Teams = new List<string>();
        List<bool> SelectedTeams = new List<bool>();

        public EventAccuracyInit(Accuracy_Event Connected_Event, TabControl TabControl)
        {
            this.TabControl = TabControl;
            this.Connected_Event = Connected_Event;
            InitializeComponent();
            getTeams();
            setupInputs();
        }

        /// <summary>
        /// Pulls the teams from the database and inserts the team names into the team dataGrid.
        /// </summary>
        private void getTeams()
        {
            Teams = Connected_Event.SQL_Controller.GetTeams(false);

            for (int i = 0; i < Teams.Count; i++)
            {
                SelectedTeams.Add(false);
                dataGridTeams.Rows.Add(i, Teams[i]);
                List<Competitor> TempCompetitors = Connected_Event.SQL_Controller.GetCompetitorsByTeam(Teams[i], new List<Competitor>());
                for (int i2 = 0; i2 < TempCompetitors.Count; i2++)
                {
                    Competitors.Add(TempCompetitors[i2]);
                    SelectedCompetitors.Add(false);
                }
            }
        }

        /// <summary>
        /// Changes the settings of the input forms to be correct.
        /// </summary>
        private void setupInputs()
        {
            inputDate.Value = DateTime.Today;
            inputName.Text = "Accuracy Event " + (Connected_Event.SQL_Controller.GetNoOfEventsByTypeOnDay(DateTime.Today, EventType.Accuracy) + 1).ToString() + " " + DateTime.Today.ToShortDateString();
            inputRuleSet.SelectedIndex = 0;
            
        }

        #region Competitor & Team Grid Functions

        private void organiseCompetitorGrid()
        {
        }

        /// <summary>
        /// Selects the team and adds all of the competitors to the competitor grid.
        /// </summary>
        /// <param name="teamID"></param>
        private void selectTeam(int teamID)
        {
            string teamName = Teams[teamID];

            for (int i = 0; i < Competitors.Count; i++)
            {
                if (Competitors[i].team == teamName)
                {
                    dataGridCompetitors.Rows.Add(Competitors[i].ID, Competitors[i].name, Competitors[i].nationality, Competitors[i].team);
                }
            }
        }

        /// <summary>
        /// Clears the competitor grid and re-adds all selected competitors.
        /// </summary>
        private void refreshCompetitorGrid()
        {
            dataGridCompetitors.Rows.Clear();
            for (int Ci = 0; Ci < Competitors.Count; Ci++)
            {
                for (int Ti = 0; Ti < Teams.Count; Ti++)
                {
                    if (Competitors[Ci].team == Teams[Ti])
                    {
                        if (SelectedTeams[Ti] == true)
                        {
                            dataGridCompetitors.Rows.Add(Competitors[Ci].ID, Competitors[Ci].name, Competitors[Ci].nationality, Competitors[Ci].team);
                        }
                    }
                }
            }
            organiseCompetitorGrid();
        }

        private void inputTeamSelect_Click(object sender, EventArgs e)
        {
            if (dataGridTeams.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt16(dataGridTeams.SelectedRows[0].Cells[0].Value);
                if (SelectedTeams[ID] != true)
                {
                    selectTeam(ID);
                    SelectedTeams[ID] = true;
                    dataGridTeams.SelectedRows[0].Cells[1].Style.BackColor = Color.LightGreen;
                }
            }
        }

        private void inputTeamDeselect_Click(object sender, EventArgs e)
        {
            if (dataGridTeams.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt16(dataGridTeams.SelectedRows[0].Cells[0].Value);
                if (SelectedTeams[ID] == true)
                {
                    SelectedTeams[ID] = false;
                    refreshCompetitorGrid();
                    dataGridTeams.SelectedRows[0].Cells[1].Style = dataGridTeams.DefaultCellStyle;
                }
            }
        }

        private void inputTeamAdd_Click(object sender, EventArgs e)
        {
            string Team = CustomMessageBox.Show(Connected_Event.SQL_Controller);
            Teams.Add(Team);
            SelectedTeams.Add(false);
            dataGridTeams.Rows.Add(Teams.Count - 1, Team);
        }

        private void inputTeamRemove_Click(object sender, EventArgs e)
        {
            if (dataGridTeams.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(("Are you sure you wish to remove the team " + dataGridTeams.SelectedRows[0].Cells[1].Value + " ?"), "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int ID = Convert.ToInt16(dataGridTeams.SelectedRows[0].Cells[0].Value);
                    Connected_Event.SQL_Controller.RemoveTeam(Teams[ID]);
                    for (int i = 0; i < Competitors.Count; i++)
                    {
                        if (Competitors[i].team == Teams[ID])
                        {
                            Competitors[i].team = "NO TEAM";
                            SelectedCompetitors[i] = false;
                        }
                    }
                    SelectedTeams[ID] = false;
                    Teams[ID] = "";
                    dataGridTeams.Rows.Remove(dataGridTeams.SelectedRows[0]);
                }
            }
        }

        private void inputTeamFilter_Click(object sender, EventArgs e)
        {
            
        }

        private void inputCompetitorSelect_Click(object sender, EventArgs e)
        {
            if (dataGridCompetitors.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt16(dataGridCompetitors.SelectedRows[0].Cells[0].Value);
                for (int i = 0; i < Competitors.Count; i++)
                {
                    if (Competitors[i].ID == ID)
                    {
                        if (SelectedCompetitors[i] != true)
                        {
                            SelectedCompetitors[i] = true;
                            for (int i2 = 0; i2 < dataGridCompetitors.SelectedRows[0].Cells.Count; i2++)
                            {
                                dataGridCompetitors.SelectedRows[0].Cells[i2].Style.BackColor = Color.LightGreen;
                            }
                        }
                    }
                }
            }
        }

        private void inputCompetitorDeselect_Click(object sender, EventArgs e)
        {
            if (dataGridCompetitors.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt16(dataGridCompetitors.SelectedRows[0].Cells[0].Value);
                for (int i = 0; i < Competitors.Count; i++)
                {
                    if (Competitors[i].ID == ID)
                    {
                        if (SelectedCompetitors[i] == true)
                        {
                            SelectedCompetitors[i] = false;
                            for (int i2 = 0; i2 < dataGridCompetitors.SelectedRows[0].Cells.Count; i2++)
                            {
                                dataGridCompetitors.SelectedRows[0].Cells[i2].Style = dataGridCompetitors.DefaultCellStyle;
                            }
                        }
                    }
                }
            }

        }

        private void inputCompetitorAdd_Click(object sender, EventArgs e)
        {
            Competitor newCompetitor = CustomMessageBox.Show(Connected_Event.SQL_Controller, 5);
            Connected_Event.SQL_Controller.CreateCompetitor(newCompetitor);
            Competitors.Add(newCompetitor);
            SelectedCompetitors.Add(false);
            dataGridCompetitors.Rows.Add(newCompetitor.ID, newCompetitor.name, newCompetitor.nationality, newCompetitor.team);
        }

        private void inputCompetitorRemove_Click(object sender, EventArgs e)
        {
            if (dataGridCompetitors.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(("Are you sure you wish to remove the competitor " + dataGridCompetitors.SelectedRows[0].Cells[1].Value + " ?"), "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int ID = Convert.ToInt16(dataGridCompetitors.SelectedRows[0].Cells[0].Value);
                    for (int i = 0; i < Competitors.Count; i++)
                    {
                        if (Competitors[i].ID == ID)
                        {
                            Competitors[i].team = "";
                            SelectedCompetitors[i] = false;
                            Connected_Event.SQL_Controller.RemoveCompetitor(ID);
                        }
                    }
                }
            }
        }

        private void inputCompetitorFilter_Click(object sender, EventArgs e)
        {

        }

        private void inputCompetitorEditor_Click(object sender, EventArgs e)
        {

        }
        #endregion


        private void buttonNext_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
