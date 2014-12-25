using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace CMS.Accuracy.Reports
{
    public partial class TeamReport : UserControl
    {
        public string NameOfReport;
        Action<TeamReport> Close;
        Form undockedForm;
        public TeamReport(DataGridViewSelectedRowCollection competitors, int countNeeded, string nameofReport, Action<TeamReport> Close)
        {
            InitializeComponent();
            NameOfReport = nameofReport;
            this.Close = Close;
            while (dataGridView1.ColumnCount < countNeeded)
            {
                dataGridView1.Columns.Add("Round" + (dataGridView1.Columns.Count - 3), "Round " + (dataGridView1.Columns.Count - 3));
            }
            int i;
            DataGridViewRow newRow;
            foreach (DataGridViewRow r in competitors)
            {
                
                i = 0;
                newRow = new DataGridViewRow();
                newRow = (DataGridViewRow)r.Clone();
                foreach (DataGridViewCell c in r.Cells)
                {
                    newRow.Cells[i].Value = c.Value;
                    newRow.Cells[i].Style.BackColor =c.Style.BackColor;
                    newRow.Cells[i].Style.ForeColor = c.Style.ForeColor;
                    i++;
                }
                dataGridView1.Rows.Add(newRow);
            }

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close(this);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Bitmap display;
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument1 = new PrintDocument();
            display = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(display, dataGridView1.ClientRectangle);
            DialogResult result = printDialog.ShowDialog();
            printDialog.Document = printDocument1;
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Bitmap display;
            SaveFileDialog saveFileDialogue = new SaveFileDialog();
            saveFileDialogue.DefaultExt = "BMP";
            saveFileDialogue.InitialDirectory = Directory.GetCurrentDirectory();
            display = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(display, dataGridView1.ClientRectangle);
            DialogResult result = saveFileDialogue.ShowDialog();
            if (result == DialogResult.OK)
            {
                display.Save(saveFileDialogue.FileName);
            }
        }
        private void buttonUndock_Click(object sender, EventArgs e)
        {
            if (undockedForm == null)
            {
                undockedForm = new Form();
                undockedForm.Controls.Add(dataGridView1);
                undockedForm.FormClosed += new FormClosedEventHandler(undockedForm_FormClosed);
                undockedForm.Show();
                buttonDock.Text = "Dock";
            }
            else
            {
                undockedForm.Close();
                undockedForm = null;
                buttonDock.Text = "Undock";
            }
        }
        void undockedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           splitContainer1.Panel1.Controls.Add(dataGridView1);
            undockedForm = null;
            buttonDock.Text = "Undock";
        }

        private void buttonDeselct_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
