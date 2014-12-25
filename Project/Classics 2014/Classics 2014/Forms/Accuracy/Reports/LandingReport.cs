using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CMS.Accuracy.Reports
{
     partial class LandingReport : UserControl
    {
        Accuracy_Event connectedEvent;
        public string NameOfReport;
        ushort previousWindData;
        bool started = false;
        Action<LandingReport> Close;
        Bitmap display;
        Form undockedForm;
        public LandingReport(AccuracyLanding landingToDisplay, String Name, Accuracy_Event ConnectedEvent, Action<LandingReport> Close)
        {
            InitializeComponent();
            this.NameOfReport = Name;
            connectedEvent = ConnectedEvent;
            groupBoxReport.Text = NameOfReport;
            this.Close = Close;
            for (int i = landingToDisplay.windDataPrior.Length - 1; i >= 0; i--)
           {
                DisplayWind(landingToDisplay.windDataPrior[i]);
            }
            //ListViewItem LandingTime = new ListViewItem(new string[]{ landingToDisplay.time, landingToDisplay.LandingWind.speed.ToString(), landingToDisplay.LandingWind.direction.ToString(),landingToDisplay.score.ToString()});
            //LandingTime.BackColor = Color.LightBlue;
            //listBoxWindLog.Items.Add(LandingTime);
            //for (int i = 1; i < landingToDisplay.windDataAfter.Length; i++)
            //{
            //    DisplayWind(landingToDisplay.windDataAfter[i]);
            //}
        }
        private void DisplayWind(TWind windData)
        {
            ListViewItem itemToAdd = new ListViewItem(new string[]{windData.time, windData.speed.ToString(), windData.direction.ToString()});
            if (windData.time == null)
            {
                return;
            }
            if (started)
            {
                if (IsDirectionOut(windData, previousWindData))
                {
                    if (windData.speed > 3)
                    {
                        itemToAdd.ForeColor = Color.Red;
                    }
                }
                else if (windData.speed > connectedEvent.Rules.windspeedRejump)
                {
                    itemToAdd.ForeColor = Color.Red;
                    if (windData.speed > connectedEvent.Rules.windspeedSafe)
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
            if (prevData < connectedEvent.Rules.directionChangeFA)
            {
                minimum = 0;
                minOverFlow = (360 - ((int)connectedEvent.Rules.directionChangeFA - prevData));
                if ((wind.direction <= prevData) || (wind.direction > minOverFlow)) { return false; }
            }
            else
            {
                minimum = prevData - (int)connectedEvent.Rules.directionChangeFA;
                if (wind.direction < minimum) { return true; }
                else if (prevData > wind.direction) { return false; }
            }
            //Max checks
            if ((prevData + (int)connectedEvent.Rules.directionChangeFA) > 360)
            {
                maximum = 360;
                maxOverFlow = 0 + ((prevData + (int)connectedEvent.Rules.directionChangeFA) - 360);
                if ((wind.direction >= prevData) || (wind.direction < maxOverFlow)) { return false; }
            }
            else
            {
                maximum = prevData + (int)connectedEvent.Rules.directionChangeFA;
                if (wind.direction > maximum) { return true; }
            }

            return false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close(this);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            display = new Bitmap(groupBoxReport.DisplayRectangle.Height, groupBoxReport.DisplayRectangle.Width);
            groupBoxReport.DrawToBitmap(display, groupBoxReport.DisplayRectangle);
            DialogResult result = printDialog.ShowDialog();
            printDialog.Document = printDocument1;
            if (result == DialogResult.OK)
            {
                 printDocument1.Print();
            }             
            display.Save("Test.BMP");
        }
         
         private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
         {
             e.Graphics.DrawImage(display, 0, 0);
         }

         private void buttonSave_Click(object sender, EventArgs e)
         {
             SaveFileDialog saveFileDialogue = new SaveFileDialog();
             saveFileDialogue.DefaultExt = "BMP";
             saveFileDialogue.InitialDirectory = Directory.GetCurrentDirectory();
             display = new Bitmap(groupBoxReport.Width, groupBoxReport.Height);
             groupBoxReport.DrawToBitmap(display, groupBoxReport.ClientRectangle);
             DialogResult result = saveFileDialogue.ShowDialog();
             if (result == DialogResult.OK)
             {
                 display.Save(saveFileDialogue.FileName);
             }
         }

         private void buttonDeselect_Click(object sender, EventArgs e)
         {
             listBoxWindLog.SelectedItems.Clear();
         }
         private void buttonUndock_Click(object sender, EventArgs e)
         {
             if (undockedForm == null)
             {
                 undockedForm = new Form();
                 undockedForm.Controls.Add(groupBoxReport);
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
             splitContainer1.Panel1.Controls.Add(groupBoxReport);
             undockedForm = null;
             buttonUndock.Text = "Undock";
         }
    }
}
