using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS.Accuracy
{
    partial class EventAccuracyInit : UserControl
    {
        #region variables and the such like
        Accuracy_Event Connected_Event;
        List<Competitor> competitors = new List<Competitor>();
        List<bool> selectedCompetitors = new List<bool>();
        List<string> teams = new List<string>();
        List<bool> selectedTeams = new List<bool>();
        Ruleset.AccuracyRules rules = new Ruleset.AccuracyRules();
        string eventName = "";
        DataGridViewCellStyle SelectedStyle;
        bool scoresUsedShowUnusualOptions = false;
        const float windspeedDiff = 0.5f; /// The minimum difference between safe and rejump windspeeds.
        #endregion

        public EventAccuracyInit(Accuracy_Event Connected_Event)
        {
            this.Connected_Event = Connected_Event;
            InitializeComponent();
            getTeams();
            setupInputs();
            SelectedStyle = dataGridTeams.DefaultCellStyle.Clone();
            SelectedStyle.BackColor = Color.LightGreen;
            SelectedStyle.SelectionBackColor = Color.DarkGreen;
            SelectedStyle.SelectionForeColor = Color.White;
        }

        /// <summary>
        /// Pulls the teams from the database and inserts the team names into the team dataGrid.
        /// </summary>
        private void getTeams()
        {
            teams = Connected_Event.SQL_Controller.GetCTeams(false);

            for (int i = 0; i < teams.Count; i++)
            {
                selectedTeams.Add(false);
                dataGridTeams.Rows.Add(i, teams[i]);
                List<Competitor> TempCompetitors = Connected_Event.SQL_Controller.GetCompetitorsByCTeam(teams[i], new List<Competitor>());
                for (int i2 = 0; i2 < TempCompetitors.Count; i2++)
                {
                    competitors.Add(TempCompetitors[i2]);
                    selectedCompetitors.Add(false);
                }
            }
        }

        /// <summary>
        /// Groups the selected competitors for export & saving.
        /// </summary>
        private List<Competitor> getSelectedCompetitors()
        {
            List<Competitor> competitorsToReturn = new List<Competitor>();

            for (int i = 0; i < selectedCompetitors.Count; i++)
            {
                if (selectedCompetitors[i] == true)
                {
                    competitorsToReturn.Add(competitors[i]);
                }
            }

            return competitorsToReturn;
        }

        private List<string> getSelectedTeamNames()
        {
            List<string> currentList = new List<string>();
            for (int i = 0; i < selectedTeams.Count; i++)
            {
                if (selectedTeams[i])
                {
                    currentList.Add(teams[i]);
                }
            }
            return currentList;
        }

        /// <summary>
        /// Checks to see if all the fields have valid results in them.
        /// </summary>
        private bool inputCorrect()
        {
            if ( // Sorry about this godawful bit of code. Best way to do it :/
                eventName != "" &&
                eventName.Length < 255 &&
                rules.preset != null &&
                rules.competitorsPerTeam >= 1 &&
                rules.windspeedSafe >= 1 &&
                rules.windspeedSafe <= 100 &&
                rules.maxScore >= 1 &&
                rules.maxScore <= 100 &&
                rules.windspeedRejump >= 1 &&
                rules.windspeedRejump <= 100 &&
                rules.windSecondsPriorLand >= 1 &&
                rules.windSecondsPriorLand <= 300 &&
                rules.windSecondsAfterLand >= 1 &&
                rules.windSecondsAfterLand <= 300 &&
                rules.directionChangeFA >= 10 &&
                rules.directionChangeFA <= 180
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Takes the input from direction change and removes the ° char.
        /// </summary>
        private int getAngle(string degrees)
        {
            char[] charsToRemove = new char[1];
            charsToRemove[0] = '°';
            return Convert.ToInt16(degrees.TrimEnd(charsToRemove));
        }

        /// <summary>
        /// Compiles the rules, checks validity and saves the event correctly.
        /// </summary>
        /// <returns>If the rules were valid.</returns>
        private bool compileDataAndSave()
        {
            DateTime date = inputDate.Value;
            string eventName = inputName.Text.Trim();

            Ruleset.AccuracyRules rules = new Ruleset.AccuracyRules();
            rules.windspeedSafe = Convert.ToSingle(inputMaxWind.Value);
            rules.directionChangeFA = getAngle(inputFADirectionChange.SelectedValue.ToString());
            rules.maxScore = Convert.ToInt16(inputMaxScore.Value);
            rules.competitorsPerTeam = Convert.ToInt16(inputCompetitorsPerTeam.Value);
            rules.preset = inputRuleSet.SelectedText;
            rules.scoresUsed = inputScoresUsed.SelectedValue.ToString();
            rules.stage = EventStage.SetupRules;
            rules.timeAfterFA = Convert.ToInt16(inputFATimeAfter.Value);
            rules.timePriorFA = Convert.ToInt16(inputFATimePrior.Value);
            rules.windspeedRejump = Convert.ToSingle(inputLegalWindspeed.Value);
            rules.windSecondsAfterLand = Convert.ToInt16(inputWindDataAfter.Value);
            rules.windSecondsPriorLand = Convert.ToInt16(inputWindDataPrior.Value);
            rules.windspeedFA = Convert.ToSingle(inputFALegalWindspeed.Value);

            if (inputCorrect())
            {
                Connected_Event.saveEventRulesStage(getSelectedCompetitors(), rules, date, eventName);
                return true;
            }
            else
            {
                return false;
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
            inputScoresUsed.SelectedIndex = 0;
            inputFADirectionChange.SelectedIndex = 8;
            labelWarning.Text = "";
            inputTeamShow.SelectedIndex = 0;
            windspeedSafe = 5.0f;
            windspeedRejump = 4.0f;
            windspeedFA = 3.0f;
            competitorsPerTeam = 5;
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
            string teamName = teams[teamID];

            for (int i = 0; i < competitors.Count; i++)
            {
                if (competitors[i].team == teamName)
                {
                    dataGridCompetitors.Rows.Add(competitors[i].ID, competitors[i].name, competitors[i].nationality, competitors[i].team);
                }
            }
        }

        /// <summary>
        /// Clears the competitor grid and re-adds all selected competitors.
        /// </summary>
        private void refreshCompetitorGrid()
        {
            dataGridCompetitors.Rows.Clear();
            for (int Ci = 0; Ci < competitors.Count; Ci++)
            {
                for (int Ti = 0; Ti < teams.Count; Ti++)
                {
                    if (competitors[Ci].team == teams[Ti])
                    {
                        if (selectedTeams[Ti] == true)
                        {
                            dataGridCompetitors.Rows.Add(competitors[Ci].ID, competitors[Ci].name, competitors[Ci].nationality, competitors[Ci].team);
                        }
                    }
                }
            }
            organiseCompetitorGrid();
        }

        #region Control Events

        private void inputTeamSelect_Click(object sender, EventArgs e)
        {
            if (dataGridTeams.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridTeams.SelectedRows.Count; i++)
                {
                    int ID = Convert.ToInt16(dataGridTeams.SelectedRows[i].Cells[0].Value);
                    if (selectedTeams[ID] != true)
                    {
                        selectTeam(ID);
                        selectedTeams[ID] = true;
                        dataGridTeams.SelectedRows[i].Cells[1].Style = SelectedStyle;
                    }
                }
            }
        }

        private void inputTeamDeselect_Click(object sender, EventArgs e)
        {
            if (dataGridTeams.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridTeams.SelectedRows.Count; i++)
                {
                    int ID = Convert.ToInt16(dataGridTeams.SelectedRows[i].Cells[0].Value);
                    if (selectedTeams[ID] == true)
                    {
                        selectedTeams[ID] = false;
                        refreshCompetitorGrid();
                        dataGridTeams.SelectedRows[i].Cells[1].Style = dataGridTeams.DefaultCellStyle;
                    }
                }
            }
        }

        private void inputTeamAdd_Click(object sender, EventArgs e)
        {
            string Team = MessageBoxes.CreateTeam();
            if (Team != null)
            {
                teams.Add(Team);
                selectedTeams.Add(false);
                dataGridTeams.Rows.Add(teams.Count - 1, Team);
            }
        }

        private void inputTeamRemove_Click(object sender, EventArgs e)
        {
            if (dataGridTeams.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(("Are you sure you wish to remove the team " + dataGridTeams.SelectedRows[0].Cells[1].Value + " ?"), "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int ID = Convert.ToInt16(dataGridTeams.SelectedRows[0].Cells[0].Value);
                    Connected_Event.SQL_Controller.RemoveCTeam(teams[ID]);
                    for (int i = 0; i < competitors.Count; i++)
                    {
                        if (competitors[i].team == teams[ID])
                        {
                            competitors[i].team = "NO TEAM";
                            selectedCompetitors[i] = false;
                        }
                    }
                    selectedTeams[ID] = false;
                    teams[ID] = "";
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
                for (int i = 0; i < dataGridCompetitors.SelectedRows.Count; i++)
                {
                    int ID = Convert.ToInt16(dataGridCompetitors.SelectedRows[i].Cells[0].Value);
                    for (int i2 = 0; i2 < competitors.Count; i2++)
                    {
                        if (competitors[i2].ID == ID)
                        {
                            if (selectedCompetitors[i2] != true)
                            {
                                selectedCompetitors[i2] = true;
                                for (int i3 = 0; i3 < dataGridCompetitors.SelectedRows[i].Cells.Count; i3++)
                                {
                                    dataGridCompetitors.SelectedRows[i].Cells[i3].Style = SelectedStyle;
                                }
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
                for (int i = 0; i < dataGridCompetitors.SelectedRows.Count; i++)
                {
                    int ID = Convert.ToInt16(dataGridCompetitors.SelectedRows[i].Cells[0].Value);
                    for (int i2 = 0; i2 < competitors.Count; i2++)
                    {
                        if (competitors[i2].ID == ID)
                        {
                            if (selectedCompetitors[i2] == true)
                            {
                                selectedCompetitors[i2] = false;
                                for (int i3 = 0; i3 < dataGridCompetitors.SelectedRows[i].Cells.Count; i3++)
                                {
                                    dataGridCompetitors.SelectedRows[i].Cells[i3].Style = dataGridCompetitors.DefaultCellStyle;
                                }
                            }
                        }
                    }
                }
            }

        }

        private void inputCompetitorAdd_Click(object sender, EventArgs e)
        {
            Competitor newCompetitor = MessageBoxes.CreateCompetitor(getSelectedTeamNames());
            if (newCompetitor != null)
            {
                Connected_Event.SQL_Controller.CreateCompetitor(newCompetitor);
                competitors.Add(newCompetitor);
                selectedCompetitors.Add(false);
                dataGridCompetitors.Rows.Add(newCompetitor.ID, newCompetitor.name, newCompetitor.nationality, newCompetitor.team);
            }
        }

        private void inputCompetitorRemove_Click(object sender, EventArgs e)
        {
            if (dataGridCompetitors.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(("Are you sure you wish to remove the competitor " + dataGridCompetitors.SelectedRows[0].Cells[1].Value + " ?"), "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int ID = Convert.ToInt16(dataGridCompetitors.SelectedRows[0].Cells[0].Value);
                    for (int i = 0; i < competitors.Count; i++)
                    {
                        if (competitors[i].ID == ID)
                        {
                            competitors[i].team = "";
                            selectedCompetitors[i] = false;
                            Connected_Event.SQL_Controller.RemoveCompetitor(ID);
                            refreshCompetitorGrid();
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
            Connected_Event.engine.openCompetitorEditor();
        }
        #endregion
        #endregion

        #region Control Events

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (compileDataAndSave())
            {
                Connected_Event.proceedToSetupTeams();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            compileDataAndSave();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
        }

        private void inputCompetitorsPerTeam_ValueChanged(object sender, EventArgs e)
        {
            competitorsPerTeam = Convert.ToInt16(inputCompetitorsPerTeam.Value);
        }

        private void inputMaxWind_ValueChanged(object sender, EventArgs e)
        {
            windspeedSafe = Convert.ToSingle(inputMaxWind.Value);
        }

        private void inputLegalWindspeed_ValueChanged(object sender, EventArgs e)
        {
            windspeedRejump = Convert.ToSingle(inputLegalWindspeed.Value);
        }

        private void inputFALegalWindspeed_ValueChanged(object sender, EventArgs e)
        {
            windspeedFA = Convert.ToSingle(inputFALegalWindspeed.Value);
        }

        private void inputScoresUsed_SelectedValueChanged(object sender, EventArgs e)
        {
            if (inputScoresUsed.SelectedItem.ToString() == "More...")
            {
                scoresUsedShowUnusualOptions = true;

                // Force update the UI. xD
                int temp = competitorsPerTeam;
                competitorsPerTeam = 1;
                competitorsPerTeam = temp;
            }
        }

        #endregion

        #region Rules variables get set operators

        private int competitorsPerTeam
        {
            get
            {
                return rules.competitorsPerTeam;
            }
            set
            {
                inputScoresUsed.Items.Clear();
                if (!scoresUsedShowUnusualOptions)
                {
                    if (value > 6)
                    {
                        inputScoresUsed.Items.Add("Top " + value);
                        inputScoresUsed.Items.Add("Top " + (value - 1));
                        inputScoresUsed.Items.Add("Top 5");
                        inputScoresUsed.Items.Add("More...");
                    }
                    else
                    {
                        inputScoresUsed.Items.Add("Top " + value);
                        inputScoresUsed.Items.Add("Top " + (value - 1));
                        inputScoresUsed.Items.Add("More...");
                    }
                }
                else
                {
                    for (int i = value; i > 0; i--)
                    {
                        inputScoresUsed.Items.Add("Top " + i);
                    }
                }
                inputScoresUsed.SelectedIndex = 0;
                rules.competitorsPerTeam = value;
            }
        }

        private float windspeedSafe
        {
            get
            {
                return rules.windspeedSafe;
            }
            set
            {
                if (windspeedRejump > (value - windspeedDiff))
                {
                    windspeedRejump = Convert.ToSingle(value - windspeedDiff);
                }
                inputMaxWind.Value = (decimal)value;
                rules.windspeedSafe = value;
            }
        }

        private float windspeedRejump
        {
            get
            {
                return rules.windspeedRejump;
            }
            set
            {
                if (windspeedSafe < (value + windspeedDiff))
                {
                    windspeedSafe = Convert.ToSingle(value + windspeedDiff);
                }
                if (windspeedFA > value)
                {
                    windspeedFA = value;
                }
                inputLegalWindspeed.Value = (decimal)value;
                rules.windspeedRejump = value;
            }
        }

        private float windspeedFA
        {
            get
            {
                return rules.windspeedFA;
            }
            set
            {
                if (value > windspeedRejump)
                {
                    windspeedRejump = value;
                }
                inputFALegalWindspeed.Value = (decimal)value;
                rules.windspeedFA = value;
            }
        }

        #endregion
    }
}
