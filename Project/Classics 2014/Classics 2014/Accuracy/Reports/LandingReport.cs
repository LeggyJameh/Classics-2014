using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classics_2014.Accuracy.Reports
{
     partial class LandingReport : UserControl
    {
        Accuracy_Event connectedEvent;
        public string NameOfReport;
        ushort previousWindData;
        bool started = false;
        public LandingReport(AccuracyLanding landingToDisplay, String Name, Accuracy_Event ConnectedEvent)
        {
            InitializeComponent();
            this.NameOfReport = Name;
            connectedEvent = ConnectedEvent;
            groupBoxReport.Text = NameOfReport;
            for (int i = landingToDisplay.windDataPrior.Length - 1; i >= 0; i--)
            {
                DisplayWind(landingToDisplay.windDataPrior[i]);
            }
            ListViewItem LandingTime = new ListViewItem(new string[]{ landingToDisplay.LandingWind.time, landingToDisplay.LandingWind.speed.ToString(), landingToDisplay.LandingWind.direction.ToString(),landingToDisplay.score.ToString()});
            LandingTime.BackColor = Color.LightBlue;
            listBoxWindLog.Items.Add(LandingTime);
            for (int i = 1; i < landingToDisplay.WindDataAfter.Length; i++)
            {
                
            }
        }
        private void DisplayWind(TWind windData)
        {
            ListViewItem itemToAdd = new ListViewItem(new string[]{windData.time, windData.speed.ToString(), windData.direction.ToString()});
            if (started)
            {
                if (IsDirectionOut(windData, previousWindData))
                {
                    if (windData.speed > 3)
                    {
                        itemToAdd.ForeColor = Color.Red;
                    }
                }
                else if (windData.speed > connectedEvent.ruleSet.windout)
                {
                    itemToAdd.ForeColor = Color.Red;
                    if (windData.speed > connectedEvent.ruleSet.compHalt)
                    {
                        itemToAdd.BackColor = Color.Black;
                    }
                }

            }
            started = true;
            listBoxWindLog.Items.Add(itemToAdd);
            previousWindData = windData.direction;

        }
        private bool IsDirectionOut(TWind wind, int prevData)
        {
            int minimum, maximum, minOverFlow, maxOverFlow;
            if (prevData < connectedEvent.ruleSet.directionOut)
            {
                minimum = 0;
                minOverFlow = (360 - ((int)connectedEvent.ruleSet.directionOut - prevData));
                if ((wind.direction <= prevData) || (wind.direction > minOverFlow)) { return false; }
            }
            else
            {
                minimum = prevData - (int)connectedEvent.ruleSet.directionOut;
                if (wind.direction < minimum) { return true; }
                else if (prevData > wind.direction) { return false; }
            }
            //Max checks
            if ((prevData + (int)connectedEvent.ruleSet.directionOut) > 360)
            {
                maximum = 360;
                maxOverFlow = 0 + ((prevData + (int)connectedEvent.ruleSet.directionOut) - 360);
                if ((wind.direction >= prevData) || (wind.direction < maxOverFlow)) { return false; }
            }
            else
            {
                maximum = prevData + (int)connectedEvent.ruleSet.directionOut;
                if (wind.direction > maximum) { return true; }
            }

            return false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            
        }
    }
}
