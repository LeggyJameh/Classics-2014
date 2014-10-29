using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using Classics_2014.MySQL;

namespace Classics_2014.Accuracy.Reports
{
    partial class Leaderboard : UserControl
    {
        public string reportName;
        private SQL_Controller sqlController;
        public bool autoUpdate = false;
        private Form undockedForm = null;
        private int eventId;
        private Accuracy_Event connectedEvent;
        List<AccuracyLanding> landings;
        Action<Leaderboard> Close;
        Bitmap display;
        public bool CloseOnStart = false;
        public Leaderboard(int eventID, String reportName, SQL_Controller sqlController, Accuracy_Event connectedEvent,Action<Leaderboard> Close)
        {
            InitializeComponent();
            this.reportName = reportName;
            this.eventId = eventID;
            this.sqlController = sqlController;
            this.connectedEvent = connectedEvent;
            autoUpdate = false;
            this.Close = Close;
            Populate();
            if (connectedEvent.Rules.noOfCompetitorsPerTeam > 1)
            {
                buttonSortAsSingles.Visible = true;
                buttonSortAsTeam.Visible = true;
            }
            
        }
        public void Update(int UserID, int Round, DataGridViewCell newCell)
        {
            if (autoUpdate)
            {
                foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
                {
                    while (Round > dataGridViewLockedLeaderboard.ColumnCount - 5)
                    {
                        dataGridViewLockedLeaderboard.Columns.Add("Round" + (dataGridViewLockedLeaderboard.ColumnCount - 5), "Round" + (dataGridViewLockedLeaderboard.ColumnCount - 5));
                    }
                    if (r.Cells[0].Value.ToString() == UserID.ToString())
                    {
                        r.Cells[Round + 4] = (DataGridViewCell)newCell.Clone();
                        r.Cells[Round + 4].Value  = newCell.Value;
                        if (connectedEvent.Rules.noOfCompetitorsPerTeam == 1)
                        {
                            complexSingleSort();
                        }
                        else
                        {
                            TeamSort();
                        }
                    }

                }
                dataGridViewLockedLeaderboard.Refresh();
            }
        }
        /// <summary>
        /// If a non Landing change has occured to the Event Leaderboard
        /// </summary>
        /// <param name="Repop"></param>
        public void Update()
        {
            if (autoUpdate)
            {
                dataGridViewLockedLeaderboard.Rows.Clear();
                Populate();
                if (connectedEvent.Rules.noOfCompetitorsPerTeam == 1)
                {
                    complexSingleSort();
                }
                else
                {
                    TeamSort();
                }
            }
        }
        public void Populate()
        {
            List<Team> Teams = sqlController.GetTeamsForEvent(connectedEvent.EventID);
            landings = sqlController.GetLandingsForEvent(eventId, connectedEvent.EventType);
            DataGridViewCell cellToEdit;
            for (int Ti = 0; Ti < Teams.Count; Ti++)
            {
                for (int Ci = 0; Ci < Teams[Ti].Competitors.Count; Ci++)
                {
                    dataGridViewLockedLeaderboard.Rows.Add(Teams[Ti].Competitors[Ci].ID, Ci + 1, Teams[Ti].Competitors[Ci].name, Teams[Ti].Competitors[Ci].nationality, Teams[Ti].Name);
                    foreach (AccuracyLanding l in landings)
                    {
                        if (l.UID == Teams[Ti].Competitors[Ci].ID)
                        {
                            while (l.round > dataGridViewLockedLeaderboard.ColumnCount - 5)
                            {
                                dataGridViewLockedLeaderboard.Columns.Add("columnRound" + (l.round), "Round " + (l.round));
                            }
                            cellToEdit = dataGridViewLockedLeaderboard[l.round + 4, dataGridViewLockedLeaderboard.Rows.Count - 1];
                            cellToEdit.Value = l.score;
                            cellToEdit.Style.BackColor = Color.LightGreen;
                            if (l.modified == true)
                            {
                                cellToEdit.Style.BackColor = Color.Yellow;
                                if (l.windDataPrior == null) { cellToEdit.Style.BackColor = Color.LightBlue; }
                            }
                            if (l.windDataPrior == null)
                            {
                                cellToEdit.Style.BackColor = Color.LightBlue;
                            }
                            if (l.rejumpable)
                            {
                                cellToEdit.Style.ForeColor = Color.Red;
                            }
                        }
                    }
                }

            }

            if (connectedEvent.Rules.noOfCompetitorsPerTeam == 1)
            {
                complexSingleSort();
            }
            else
            {
                TeamSort();
            }
        }
        private int TeamScoresAdd(string teamName, int column)
        {
            int total = 0;
            int indexPosition=0;
            int[] teamScores = new int[connectedEvent.Rules.noOfCompetitorsPerTeam];

            foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
            {
                if (r.Cells[4].Value.ToString() == teamName)
                {
                  teamScores[indexPosition] = Convert.ToInt16(r.Cells[column].Value);
                  indexPosition++;
                }
            }
        
            
            Array.Sort(teamScores);
            for (int i2 = 0; i2 < Convert.ToInt16(connectedEvent.Rules.ScoresUsed.Substring(5)); i2++)
            {
                total += teamScores[i2];
            }
            return total;
        }
        private void TeamSort()
        {
            complexSingleSort();
            int[,] uidInfo; //= new int[dataGridViewLockedLeaderboard.RowCount, 5]; // Uids, Position, Score, maxRound scored, Final Position
            List<string> teams = new List<string>();
            int CurrentMaxPosition;
            List<DataGridViewRow> teamsToReadd = new List<DataGridViewRow>();
            int[,] uidInfoSwap = new int[1, 6];
            int i = 0;
            int CurrentRoundIndex;
            Boolean finished = false, Tie = false, blocked = false;
            foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
            {
                if (!teams.Contains(r.Cells[4].Value.ToString()))
                {
                    i++;
                    teams.Add(r.Cells[4].Value.ToString());
                }
            }
            uidInfo = new int[i,5];
            teams.Clear();
            i = 0;
            foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
            {
                if (!teams.Contains(r.Cells[4].Value.ToString()))
                {
                    teams.Add(r.Cells[4].Value.ToString());
                    uidInfo[i, 0] = Convert.ToInt16(r.Cells[0].Value);
                    uidInfo[i, 1] = i;
                    uidInfo[i, 2] = 0;
                    uidInfo[i, 3] = GetTeamMaxIndex(r.Cells[4].ToString());
                    uidInfo[i, 4] = i;
                    if (uidInfo[i, 3] < 5) { MessageBox.Show("Cannot order Leaderboard Prior to atleast 1 finished round, if required please insert and later remove manual landings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); CloseOnStart = true; return; } // If we returned 4 it means that it cut the moment it hit 5, I.E When we started and so no round is ready
                    i++;
                }
            }

             //Here we assigning all of the basic variables such as ID max scored round, and position
            CurrentRoundIndex = uidInfo[0, 3];//Here is where I edited the 1 in case it broke anything
            for (int ii = 0; ii < teams.Count; ii++)
            {
                if (uidInfo[ii, 3] < CurrentRoundIndex)
                {
                    CurrentRoundIndex = uidInfo[ii, 3];
                }
            }
            // Here we are calculating the first max round to calculate to;
                for (int iii = 0; iii < teams.Count; iii++)
                {
                    for (int x = 5; x < CurrentRoundIndex; x++)
                    {
                        uidInfo[iii, 2] += TeamScoresAdd(teams[iii], x);
                    }
                }
             //Here we assigning The first set of max values
            do//Here we start the sorting Loop
            {
                for (int x = 1; x < teams.Count; x++) // From second place down, X= The uid selected in the Array
                {
                    blocked = false;
                    Tie = false;//reset tie

                    while ((!blocked) && (!Tie) && (uidInfo[x, 3] >= CurrentRoundIndex) && (x != 0) && (uidInfo[x - 1, 3] >= CurrentRoundIndex) && (x < teams.Count))//If someone becomes leader x = 0, so it skips to player 2 again, the round being switched to must also be above or at current round. 
                    {
                        if (uidInfo[x, 2] < uidInfo[x - 1, 2]) // The score is lower than the one it is being checked against
                        {
                            for (int y = 0; y < 5; y++)
                            {
                                uidInfoSwap[0, y] = uidInfo[x - 1, y]; // The value of the comeptitor dropping down is stored
                                uidInfo[x - 1, y] = uidInfo[x, y];// The value just saved is overwritten by the victor
                                uidInfo[x, y] = uidInfoSwap[0, y];//And the backup is replaced where the previous value was, and the process is repeated for all values

                            }
                            x--;//X is decremented by one, to allow the round another chance to be moved up as otherwise it would only ever increase once
                        }

                        else if (uidInfo[x, 2] == uidInfo[x - 1, 2])//If the two scores are the same, and the previous if was not set
                        {
                            if ((uidInfo[x, 3] == CurrentRoundIndex) || (uidInfo[x, 3] == CurrentRoundIndex))// If one of them cannot continue
                            {
                                for (int z = 5; z <= CurrentRoundIndex; z++)//Checking all the items
                                {
                                    int TeamScoreA = TeamScoresAdd(teams[uidInfo[x, 1]], z), TeamScoreB = TeamScoresAdd(teams[uidInfo[x - 1, 1]], z);
                                    Console.WriteLine(z);
                                    if (TeamScoreA < TeamScoreB)//If the value for the Swapper is lower
                                    {
                                        for (int y = 0; y < 5; y++)
                                        {
                                            uidInfoSwap[0, y] = uidInfo[x - 1, y]; // The value of the comeptitor dropping down is stored
                                            uidInfo[x - 1, y] = uidInfo[x, y];// The value just saved is overwritten by the victor
                                            uidInfo[x, y] = uidInfoSwap[0, y];//And the backup is replaced where the previous value was, and the process is repeated for all values

                                        }
                                        x--;//X is decremented by one, to allow the round another chance to be moved up as otherwise it would only ever increase once
                                    }

                                    else if ((TeamScoreA != TeamScoreB))
                                    {
                                        blocked = true;
                                        break;//Checker loses first of the cliff
                                    }
                                    else if (z == CurrentRoundIndex - 1)// if we are at the last iteration at there has been no differentiation
                                    {
                                        uidInfo[x, 4] = uidInfo[x - 1, 4]; // this makes the Final Position variable identical, which is used later
                                        Tie = true;
                                        blocked = true;
                                    }
                                }
                            }
                            else { blocked = true; }
                        }
                        else { blocked = true; }
                        finished = false;//If anything has been done in here we give it another shot before packing it in
                    }
                }

                //Sort
                CurrentRoundIndex++;
                for (int i4 = 0; i4 < teams.Count; i4++)
                {
                     if ((uidInfo[i4, 2] >= CurrentRoundIndex) && (CurrentRoundIndex < dataGridViewLockedLeaderboard.ColumnCount)) { uidInfo[i4, 2] += TeamScoresAdd(teams[uidInfo[i4,1]], CurrentRoundIndex); } // If no 1 is high enough we put him through
                }
                 if (CurrentRoundIndex > teams.Count) { finished = true; }
            } while (!finished);
            // Here is where all the Adding takes place
            CurrentMaxPosition = 1;
            for (int V = 0; V < teams.Count; V++)//Search for each team
            {
                for (int c = 0; c < dataGridViewLockedLeaderboard.RowCount; c++)//Searche Each Row
                {
                    if (dataGridViewLockedLeaderboard.Rows[c].Cells[4].Value.ToString() == teams[V])
                    {
                            dataGridViewLockedLeaderboard[1, c].Value = CurrentMaxPosition;
                            teamsToReadd.Add(dataGridViewLockedLeaderboard.Rows[c]);

                    }
                }
                CurrentMaxPosition++;
            }
             dataGridViewLockedLeaderboard.Rows.Clear();
             foreach (DataGridViewRow r in teamsToReadd)
             {
                 dataGridViewLockedLeaderboard.Rows.Add(r);
             }
        
}


        private int GetTeamMaxIndex(string teamName)
        {
            int prevWorst = 0, newInt;
            foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
            {
                if (r.Cells[4].ToString() == teamName)
                {
                    if (prevWorst == 0) { prevWorst = GetMaxIndex(r.Index); }
                    newInt = GetMaxIndex(r.Index);
                    if (newInt < prevWorst) { newInt = prevWorst; }
                }
            }
            return prevWorst;
        }


        private void complexSingleSort()
        {
            int[,] uidInfo = new int[dataGridViewLockedLeaderboard.RowCount, 5]; // Uids, Position, Score, maxRound scored, Final Position
            int CurrentMaxPosition;
            List<DataGridViewRow> competitorsToReadd = new List<DataGridViewRow>();
              int[,] uidInfoSwap = new int[1, 6];
            int i = 0;
            int CurrentRoundIndex;
            Boolean finished = false, Tie = false, blocked = false ;
            foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
            {
                uidInfo[i, 0] = Convert.ToInt16(r.Cells[0].Value);
                uidInfo[i, 1] = i;
                uidInfo[i, 2] = 0;
                uidInfo[i, 3] = GetMaxIndex(i);
                uidInfo[i, 4] = i;
                if (uidInfo[i, 3] < 4) { MessageBox.Show("Cannot order Leaderboard Prior to atleast 1 finished round, if required please insert and later remove manual landings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Close(this); return; } // If we returned 4 it means that it cut the moment it hit 5, I.E When we started and so no round is ready
                 i++;
            } //Here we assigning all of the basic variables such as ID max scored round, and position
            CurrentRoundIndex = uidInfo[1,3];
            for (int ii = 0; ii < dataGridViewLockedLeaderboard.RowCount; ii++)
            {
                if (uidInfo[ii, 3] < CurrentRoundIndex)
                {
                    CurrentRoundIndex = uidInfo[ii, 3];
                }
            }

                foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
                {
                    for (int iii = 5; iii <= CurrentRoundIndex; iii++)
                    {
                        uidInfo[r.Index, 2] += Convert.ToInt16(r.Cells[iii].Value);
                    }
                } //Here we assigning The first set of max values
            do//Here we start the sorting Loop
            {            
                for (int x = 1; x < dataGridViewLockedLeaderboard.RowCount; x++) // From second place down, X= The uid selected in the Array
                {
                    blocked = false;
                    Tie = false;//reset tie

                        while ((!blocked)&&(!Tie)&&(uidInfo[x,3]>= CurrentRoundIndex) && (x != 0) && (uidInfo[x - 1, 3] >= CurrentRoundIndex)&&(x < dataGridViewLockedLeaderboard.RowCount))//If someone becomes leader x = 0, so it skips to player 2 again, the round being switched to must also be above or at current round. 
                        {
                            if (uidInfo[x, 2] < uidInfo[x - 1, 2]) // The score is lower than the one it is being checked against
                            {
                                for (int y = 0; y < 5; y++)
                                {
                                    uidInfoSwap[0, y] = uidInfo[x - 1, y]; // The value of the comeptitor dropping down is stored
                                    uidInfo[x - 1, y] = uidInfo[x, y];// The value just saved is overwritten by the victor
                                    uidInfo[x, y] = uidInfoSwap[0, y];//And the backup is replaced where the previous value was, and the process is repeated for all values

                                }
                                 x--;//X is decremented by one, to allow the round another chance to be moved up as otherwise it would only ever increase once
                            }

                            else if (uidInfo[x, 2] == uidInfo[x - 1, 2])//If the two scores are the same, and the previous if was not set
                            {
                                if ((uidInfo[x, 3] == CurrentRoundIndex) || (uidInfo[x, 3] == CurrentRoundIndex))// If one of them cannot continue
                                {
                                    for (int z = 5; z <= CurrentRoundIndex; z++)//Checking all the items
                                    {
                                        if ((Convert.ToInt16(dataGridViewLockedLeaderboard[z, uidInfo[x, 1]].Value)) < (Convert.ToInt16(dataGridViewLockedLeaderboard[z, uidInfo[x - 1, 1]].Value))) //If the value for the Swapper is lower
                                        {
                                            for (int y = 0; y < 5; y++)
                                            {
                                                uidInfoSwap[0, y] = uidInfo[x - 1, y]; // The value of the comeptitor dropping down is stored
                                                uidInfo[x - 1, y] = uidInfo[x, y];// The value just saved is overwritten by the victor
                                                uidInfo[x, y] = uidInfoSwap[0, y];//And the backup is replaced where the previous value was, and the process is repeated for all values

                                            }
                                            x--;//X is decremented by one, to allow the round another chance to be moved up as otherwise it would only ever increase once
                                        }
                                        else if ((Convert.ToInt16(dataGridViewLockedLeaderboard[z, uidInfo[x, 1]].Value)) != (Convert.ToInt16(dataGridViewLockedLeaderboard[z, uidInfo[x - 1, 1]].Value)))
                                        {
                                            blocked = true;
                                            break;//Checker loses first of the cliff
                                        }
                                        else if (z == CurrentRoundIndex)// if we are at the last iteration at there has been no differentiation
                                        {
                                            uidInfo[x, 4] = uidInfo[x - 1, 4]; // this makes the Final Position variable identical, which is used later
                                            Tie = true;
                                            blocked = true;
                                        }
                                    }
                                }
                                else { blocked = true; }
                            }
                            else { blocked = true; }
                            finished = false;//If anything has been done in here we give it another shot before packing it in
                        }
                    }
                
                //Sort
                CurrentRoundIndex++;
                for (int i4 = 0; i4 < dataGridViewLockedLeaderboard.RowCount; i4++)
                {
                    if ((uidInfo[i4, 2] >= CurrentRoundIndex) && (CurrentRoundIndex < dataGridViewLockedLeaderboard.ColumnCount)) { uidInfo[i4, 2] += Convert.ToInt16(dataGridViewLockedLeaderboard[CurrentRoundIndex, uidInfo[i4, 1]].Value); } // If no 1 is high enough we put him through
                }
                 if (CurrentRoundIndex > dataGridViewLockedLeaderboard.RowCount) { finished = true; }
            } while (!finished);
            // Here is where all the Adding takes place
            CurrentMaxPosition = 1;
            for (int V = 0; V < dataGridViewLockedLeaderboard.RowCount; V++)//Search for each Competitor
            {
                for (int c = 0; c < dataGridViewLockedLeaderboard.RowCount; c++)//Searche Each Row
                {
                    if (Convert.ToInt16(dataGridViewLockedLeaderboard[0, c].Value) == uidInfo[V, 0])
                    {
                        if ((V != 0) && (uidInfo[V, 4] == uidInfo[V - 1, 4]))
                        {
                            dataGridViewLockedLeaderboard[1, c].Value = competitorsToReadd[V - 1].Cells[1].Value;
                            competitorsToReadd.Add(dataGridViewLockedLeaderboard.Rows[c]);
                        }
                        else
                        {
                            dataGridViewLockedLeaderboard[1, c].Value = CurrentMaxPosition;
                            competitorsToReadd.Add(dataGridViewLockedLeaderboard.Rows[c]);
                            CurrentMaxPosition++;
                        }

                    }
                }
            }
            dataGridViewLockedLeaderboard.Rows.Clear();
            foreach (DataGridViewRow r in competitorsToReadd)
            {
                dataGridViewLockedLeaderboard.Rows.Add(r);
            }
        }
        private int GetMaxIndex(int RowIndex)
        {
            int i;
            for ( i = 5; i < dataGridViewLockedLeaderboard.ColumnCount; i++)
            {
                if (dataGridViewLockedLeaderboard[i,RowIndex].Value == null)
                {
                    return i-1;
                }
            }
            return i-1;
        }
    

        private void buttonAutoUpdate_Click(object sender, EventArgs e)
        {
            autoUpdate = !autoUpdate;
            if (autoUpdate)
            {
                buttonAutoUpdate.ForeColor = Color.Green;
                dataGridViewLockedLeaderboard.Rows.Clear();
                Populate();
            }
            else { buttonAutoUpdate.ForeColor = Color.Crimson; }
        }

        private void buttonUndock_Click(object sender, EventArgs e)
        {
            if (undockedForm == null)
            {
                undockedForm = new Form();
                undockedForm.Controls.Add(dataGridViewLockedLeaderboard);
                undockedForm.FormClosed += new FormClosedEventHandler(undockedForm_FormClosed);
                undockedForm.Show();
                buttonUndock.Text = "Dock";
            }
            else
            {
                undockedForm.Close();
                undockedForm = null;
                buttonUndock.Text = "Undock";
            }
        }

        void undockedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            splitContainerLeaderboard.Panel1.Controls.Add(dataGridViewLockedLeaderboard);
            undockedForm = null;
            buttonUndock.Text = "Undock";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close(this);
        }

        private void buttonSortAsSingles_Click(object sender, EventArgs e)
        {
            complexSingleSort();
        }

        private void buttonSortAsTeam_Click(object sender, EventArgs e)
        {
            TeamSort();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            
                PrintDialog printDialog = new PrintDialog();
                PrintDocument printDocument1 = new PrintDocument();
                display = new Bitmap(dataGridViewLockedLeaderboard.Width, dataGridViewLockedLeaderboard.Height);
                dataGridViewLockedLeaderboard.DrawToBitmap(display, dataGridViewLockedLeaderboard.ClientRectangle);
                DialogResult result = printDialog.ShowDialog();
                printDialog.Document = printDocument1;
                if (result == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialogue = new SaveFileDialog();
            saveFileDialogue.DefaultExt = "BMP";
            saveFileDialogue.InitialDirectory = Directory.GetCurrentDirectory();
            display = new Bitmap(dataGridViewLockedLeaderboard.Width, dataGridViewLockedLeaderboard.Height);
            dataGridViewLockedLeaderboard.DrawToBitmap(display, dataGridViewLockedLeaderboard.ClientRectangle);
            DialogResult result = saveFileDialogue.ShowDialog();
            if (result == DialogResult.OK)
            {
                display.Save(saveFileDialogue.FileName);
            }
        }

        private void buttonDeselect_Click(object sender, EventArgs e)
        {
            dataGridViewLockedLeaderboard.ClearSelection();
        }
    }
}
