﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Classics_2014
{
    public partial class Main : Form
    {
        int flopsToMaintainColourDirection, flopsToMaintainColourSpeed;
        public Boolean Locked=false;
        Engine MainEngine;
        
        public Main()
        {
            this.KeyPreview = true;
            InitializeComponent();
            System.Media.SoundPlayer audioPlayer = new System.Media.SoundPlayer();
            textBoxSideSpeed.ForeColor = UserSettings.Default.sideTextStandarColour;
            textBoxSideDirection.ForeColor = UserSettings.Default.sideTextStandarColour;
            windGraphingControllercs windGraphingControllercs2 = new windGraphingControllercs();
            windGraphingControllercs2.Dock = DockStyle.Fill;
            tabControl.TabPages[1].Controls.Add(windGraphingControllercs2);
            MainEngine = new Engine(this, tabControl, windGraphingControllercs2);
            for (int i = 0; i < 60; i++)
            {
                ListViewItem NewItem = (ListViewItem)listBoxWindLog.Items[0].Clone();
                listBoxWindLog.Items.Add(NewItem);
            }
            listBoxWindLog.Visible = true;
            tableLayoutPanel6.Visible = true;

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            UserSettings.Default.Save();
            MainEngine.CloseThreads();
            this.Close();
        }
        private void buttonCompetition_Click(object sender, EventArgs e)
        {
            string EventName = CustomMessageBox.ShowEventPicker();
            switch (EventName)
            {
                case "IntAccuracy":
                    TabPage NewPage = new TabPage();
                    Classics_2014.Accuracy.EventAccuracyOptions EventTab = MainEngine.StartNewAccuracyEvent();
                    NewPage.Controls.Add(EventTab);
                    EventTab.Dock = DockStyle.Fill;
                    NewPage.Text = "New Event";
                    tabControl.TabPages.Add(NewPage);
                    tabControl.SelectedTab = NewPage;
                    break;
            }
        }
        public void UpdateWind(TWind windData)
        {
            if (textBoxSideSpeed.Text != "000") 
            {
            SetColoursForText(windData, UserSettings.Default.DangerDirectionChange, UserSettings.Default.DangerWindSpeed);
            }
            textBoxSideSpeed.Text = windData.speed.ToString();
            textBoxSideDirection.Text = windData.direction.ToString();
            if (flopsToMaintainColourSpeed == 0)
            {
                textBoxSideSpeed.ForeColor = UserSettings.Default.sideTextStandarColour;
            }
            else 
            { 
                flopsToMaintainColourSpeed--;
                if (UserSettings.Default.AudioAlarmsEnabled) { System.Media.SystemSounds.Asterisk.Play(); }
                
            }
            if (flopsToMaintainColourDirection == 0)
            {
                textBoxSideSpeed.ForeColor = UserSettings.Default.sideTextStandarColour;
            }
            else 
            { 
                flopsToMaintainColourDirection--;
                if (UserSettings.Default.AudioAlarmsEnabled) { System.Media.SystemSounds.Beep.Play(); }
                
            }
                
        }
        public void UpdatelistBoxWindLog(TWind[] wind)
        {
            listBoxWindLog.Invoke((MethodInvoker)(() => listBoxWindLog.BeginUpdate()));
            for (int i = 0; i < wind.Length; i++)
            {
                string[] NewItems = new string[3];
                NewItems[0] = wind[i].time;
                NewItems[1] = wind[i].speed.ToString();
                NewItems[2] = wind[i].direction.ToString();
                ListViewItem NewListItem = new ListViewItem(NewItems);
                listBoxWindLog.Invoke((MethodInvoker)(() => listBoxWindLog.Items[i] = NewListItem));
            }
            listBoxWindLog.Invoke((MethodInvoker)(() => listBoxWindLog.EndUpdate()));
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainEngine.CloseThreads();
            UserSettings.Default.Save();
            Thread.Sleep(100);
            
        }
        private bool IsDirectionOut(TWind wind, int directionLimit)
        {
            int prevData = Convert.ToInt16(textBoxSideDirection.Text);
            int minimum, maximum, minOverFlow, maxOverFlow;
            if (Convert.ToInt16(textBoxSideDirection.Text) < directionLimit)
            {
                minimum = 0;
                minOverFlow = (360 - ((directionLimit - prevData)));
                if ((wind.direction <= prevData) || (wind.direction > minOverFlow)) { return false; }
            }
            else
            {
                minimum = prevData - directionLimit;
                if (wind.direction < minimum) { return true; }
                else if (prevData > wind.direction) { return false; }
            }
            //Max checks
            if (prevData + directionLimit > 360)
            {
                maximum = 360;
                maxOverFlow = 0 + ((prevData + directionLimit) - 360);
                if ((wind.direction >= prevData) || (wind.direction < maxOverFlow)) { return false; }
            }
            else
            {
                maximum = prevData + directionLimit;
                if (wind.direction > maximum) { return true; }
            }

            return false;
        }

        public void SetColoursForText(TWind wind, int directionLimit, float speedLimit)
        {
            if (IsDirectionOut(wind, directionLimit))
            {
                flopsToMaintainColourDirection = UserSettings.Default.flopsToMaintainColourDirection;
                textBoxSideDirection.ForeColor = UserSettings.Default.sideTextDirectionOutColour;
            }
            if (wind.speed > speedLimit)
            {

                flopsToMaintainColourSpeed = UserSettings.Default.flopsToMaintainColourSpeed;
                textBoxSideSpeed.ForeColor = UserSettings.Default.sideTextWindOutColour;
            }
            if (flopsToMaintainColourDirection == 0)
            {
                textBoxSideDirection.ForeColor = UserSettings.Default.sideTextStandarColour;
            }
            if (flopsToMaintainColourSpeed == 0)
            {
                textBoxSideDirection.ForeColor = UserSettings.Default.sideTextStandarColour;
            }
        }

        private void buttonMainSettings_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Add(new TabPage("Options"));
            tabControl.TabPages[tabControl.TabPages.Count - 1].Controls.Add(new StandardOptionsPage(MainEngine.windGraph, tabControl));
            tabControl.SelectTab(tabControl.TabPages.Count - 1);
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyData == (Keys.Control|Keys.Shift|Keys.L))
           {
               if (!Locked) { LockScreen lockScreen = new LockScreen(this); Locked = true; this.Enabled = false; }
     
           }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            EventLoader CurrentEventLoader = new EventLoader(MainEngine, tabControl);
            CurrentEventLoader.Dock = DockStyle.Fill;
            tabControl.TabPages.Add(new TabPage("Load Event"));
            tabControl.TabPages[tabControl.TabPages.Count - 1].Controls.Add(CurrentEventLoader);
            tabControl.SelectTab(tabControl.TabPages.Count - 1);
        }
        
    }
}

