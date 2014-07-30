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
    partial class EventAccuracy : UserControl
    {
        Accuracy_Event Connected_Event;
        TabControl tabControl;

        public EventAccuracy(Accuracy_Event Event, TabControl Main)
        {
            Connected_Event = Event;
            tabControl = Main;
            InitializeComponent();
            labelName.Text = "Accuracy Event " + Connected_Event.Name;
            LoadTeamsIntoGrid();
        }

        

        private void LoadTeamsIntoGrid()
        {
            for (int i = 0; i < Connected_Event.Teams.Count; i++)
            {
                for (int i2 = 0; i2 < Connected_Event.Teams[i].Count; i2++)
                {
                    dataGridViewScore.Rows.Add(Connected_Event.Teams[i][i2].ID, Connected_Event.Teams[i][i2].name, Connected_Event.Teams[i][i2].team, Connected_Event.Teams[i][i2].nationality, Connected_Event.TeamNames[i]);
                }
            }
        }
    }
}
