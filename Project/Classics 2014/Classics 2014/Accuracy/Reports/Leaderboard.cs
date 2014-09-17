﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classics_2014.Accuracy.Reports
{
    partial class Leaderboard : UserControl
    {
        public string reportName;
        private SQL_Controller sqlController;
        private bool autoUpdate;
        private Form undockedForm = null;
        private int eventId;
        private Accuracy_Event connectedEvent;
        List<MySqlReturnLanding> landings;
        public Leaderboard(int eventID, String reportName, SQL_Controller sqlController, Accuracy_Event connectedEvent)
        {
            InitializeComponent();
            this.reportName = reportName;
            this.eventId = eventID;
            this.sqlController = sqlController;
            this.connectedEvent = connectedEvent;
            autoUpdate = false;
            Populate();
        }
        public void Update(int UserID, int Round, DataGridViewCell newCell)
        {
            foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
            {
                if (r.Cells[0].Value.ToString() == UserID.ToString())
                {
                    r.Cells[Round + 4] = newCell;
                    if (connectedEvent.ruleSet.noOfCompetitorsPerTeam == 1)
                    {
                        complexSingleSort();
                    }
                    else
                    {
                        TeamSort();
                    }
                }

            }
        }
        /// <summary>
        /// If a non Landing change has occured to the Event Leaderboard
        /// </summary>
        /// <param name="Repop"></param>
        public void Update()
        {
            dataGridViewLockedLeaderboard.Rows.Clear();
            Populate();
            if (connectedEvent.ruleSet.noOfCompetitorsPerTeam == 1)
            {
               complexSingleSort();
            }
            else
            {
                TeamSort();
            }
        }
        public void Populate()
        {
            MySqlTeamsReturn competitors = sqlController.GetTeamsForEvent(connectedEvent.EventID);
            landings = sqlController.GetLandingsForAccuracyEvent(eventId, connectedEvent);
            DataGridViewCell cellToEdit;
            for (int iT = 0; iT < competitors.Teams.Count; iT++)
            {
                for (int iC = 0; iC < competitors.Teams[iT].Count; iC++)
                {
                    dataGridViewLockedLeaderboard.Rows.Add(competitors.Teams[iT][iC].ID, iC+1, competitors.Teams[iT][iC].name, competitors.Teams[iT][iC].nationality, competitors.TeamNames[iT]);
                    foreach (MySqlReturnLanding l in landings)
                    {
                        if (l.UID == competitors.Teams[iT][iC].ID)
                        {
                            while (l.Round > dataGridViewLockedLeaderboard.ColumnCount - 5)
                            {
                                dataGridViewLockedLeaderboard.Columns.Add("columnRound" + (l.Round), "Round " + (l.Round));
                            }
                            cellToEdit = dataGridViewLockedLeaderboard[l.Round + 4, dataGridViewLockedLeaderboard.Rows.Count - 1];
                            cellToEdit.Value = l.score;
                            cellToEdit.Style.BackColor = Color.LightGreen;
                            if (l.Modified == true)
                            {
                                cellToEdit.Style.BackColor = Color.Yellow;
                                if (l.windDataPrior == null) { cellToEdit.Style.BackColor = Color.LightBlue; }
                            }
                            if (l.windDataPrior == null)
                            {
                                cellToEdit.Style.BackColor = Color.LightBlue;
                            }
                        }
                    }
                }

            }

            if (connectedEvent.ruleSet.noOfCompetitorsPerTeam == 1)
            {
                complexSingleSort();
            }
            else
            {
                TeamSort();
            }
        }
        private void TeamSort()
        {
           
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
                 if (uidInfo[i, 3] == 4) {MessageBox.Show("Error Can Not Sort Before Round 1 Complete"); return;} // If we returned 4 it means that it cut the moment it hit 5, I.E When we started and so no round is ready
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
            // Here we are calculating the first max round to calculate to;
            foreach (DataGridViewRow r in dataGridViewLockedLeaderboard.Rows)
            {
                for (int iii = 5; iii < CurrentRoundIndex; iii++)
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
                                    for (int z = 5; z < CurrentRoundIndex; z++)//Checking all the items
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
                                        else if (z == CurrentRoundIndex - 1)// if we are at the last iteration at there has been no differentiation
                                        {
                                            uidInfo[x, 4] = uidInfo[x - 1, 4]; // this makes the Final Position variable identical, which is used later
                                            Tie = true;
                                            blocked = true;
                                        }
                                    }
                                }
                            }
                            else { blocked = true; }
                            finished = false;//If anything has been done in here we give it another shot before packing it in
                        }
                    }
                
                //Sort
                CurrentRoundIndex++;
                if ((uidInfo[0, 2] >= CurrentRoundIndex) && (CurrentRoundIndex < dataGridViewLockedLeaderboard.ColumnCount)) { uidInfo[0, 2] += Convert.ToInt16(dataGridViewLockedLeaderboard[CurrentRoundIndex, uidInfo[0, 1]].Value); } // If no 1 is high enough we put him through
                else if (CurrentRoundIndex > dataGridViewLockedLeaderboard.RowCount) { finished = true; }
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
                if (string.IsNullOrEmpty(dataGridViewLockedLeaderboard[i,RowIndex].Value.ToString()))
                {
                    return i-1;
                }
            }
            return i;
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
                undockedForm.Hide();
                undockedForm = null;

            }
        }

        void undockedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            undockedForm = null;
        }
    }
}
