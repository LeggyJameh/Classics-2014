using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace CMS.Accuracy.Reports
{
     partial class LandingReport : UserControl
    {
        public string NameOfReport;
        Bitmap display;
        Form undockedForm;
        ReportCreation reportCreator;
        AccuracyLanding landingToDisplay;
        Microsoft.Office.Interop.Excel.Application xlApp; 
        public LandingReport(ReportCreation reportCreator, AccuracyLanding landingToDisplay, string Name)
        {
            InitializeComponent();
            this.NameOfReport = Name;
            this.reportCreator = reportCreator;
            groupBoxReport.Text = NameOfReport;
            this.landingToDisplay = landingToDisplay;
            for (int i = landingToDisplay.windDataPrior.Length - 1; i >= 1; i--)
           {
                DisplayWind(landingToDisplay.windDataPrior[i]); //Cycle through to 
            }
            ListViewItem LandingItem = new ListViewItem(new string[] { landingToDisplay.time, landingToDisplay.windDataPrior[0].speed.ToString(), landingToDisplay.windDataPrior[0].direction.ToString(), landingToDisplay.score.ToString() });
            LandingItem.BackColor = Color.LightBlue;
            listBoxWindLog.Items.Add(LandingItem);
            for (int i = 1; i < landingToDisplay.windDataAfter.Length; i++)
            {
                DisplayWind(landingToDisplay.windDataAfter[i]); 
            }
        }
        private void DisplayWind(TWind windData)
        {
            ListViewItem itemToAdd = new ListViewItem(new string[]{windData.time, windData.speed.ToString(), windData.direction.ToString()});
            if (windData.time == null)
            {
                return;
            }
             if (windData.speed > 3)
                {
                  itemToAdd.ForeColor = Color.Red;
                }
                    
            listBoxWindLog.Items.Add(itemToAdd);
        }
        
        private void buttonClose_Click(object sender, EventArgs e)
        {
            reportCreator.RemoveReport(this);
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
        }
         
         private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
         {
             System.Drawing.Image img = display;
             System.Drawing.Rectangle m = e.MarginBounds;

             if ((double)img.Width / (double)img.Height > (double)m.Width / (double)m.Height) // image is wider
             {
                 m.Height = (int)((double)img.Height / (double)img.Width * (double)m.Width);
             }
             else
             {
                 m.Width = (int)((double)img.Width / (double)img.Height * (double)m.Height);
             }
             e.Graphics.DrawImage(img, m);
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

         private void button1_Click(object sender, EventArgs e)
         {
             xlApp = new Microsoft.Office.Interop.Excel.Application();
             Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
             Worksheet ws = (Worksheet)wb.Worksheets[1];

             ws.Cells[1, 1].Value2 = "Time";
             ws.Cells[1, 2].Value2 = "Speed";
             ws.Cells[1, 3].Value2 = "Direction";
             ws.Cells[1, 4].Value2 = "Score";
             ws.Cells[1, 1].EntireRow.Font.Bold = true;

             for (int i = landingToDisplay.windDataPrior.Length - 1; i >= 1; i--)
             {
                 ws.Cells[(landingToDisplay.windDataPrior.Length + 1) - i ,1].Value2 = landingToDisplay.windDataPrior[i].time;
                 ws.Cells[(landingToDisplay.windDataPrior.Length + 1) - i, 2].Value2 = landingToDisplay.windDataPrior[i].speed;
                 ws.Cells[(landingToDisplay.windDataPrior.Length + 1) - i, 3].Value2 = landingToDisplay.windDataPrior[i].direction;//Cycle through to 
             }
             ws.Cells[landingToDisplay.windDataPrior.Length + 1, 1] = landingToDisplay.windDataPrior[0].time;
             ws.Cells[landingToDisplay.windDataPrior.Length + 1, 2] = landingToDisplay.windDataPrior[0].speed;
             ws.Cells[landingToDisplay.windDataPrior.Length + 1, 3] = landingToDisplay.windDataPrior[0].direction;
             ws.Cells[landingToDisplay.windDataPrior.Length + 1, 4] = landingToDisplay.score;
             for (int i = 1; i < landingToDisplay.windDataAfter.Length; i++)
             {
                 ws.Cells[landingToDisplay.windDataPrior.Length+ i + 1, 1].Value2 = landingToDisplay.windDataAfter[i].time;
                 ws.Cells[landingToDisplay.windDataPrior.Length + i + 1, 2].Value2 = landingToDisplay.windDataAfter[i].speed;
                 ws.Cells[landingToDisplay.windDataPrior.Length + i + 1, 3].Value2 = landingToDisplay.windDataAfter[i].direction;
             }
             xlApp.Visible = true;
         }
    }
}
