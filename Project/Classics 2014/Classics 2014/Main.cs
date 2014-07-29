using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace Classics_2014
{
    public partial class Main : Form
    {
        Engine MainEngine;
        public Main()
        {
            InitializeComponent();
            MainEngine = new Engine(this, tabControl);
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
            Application.Exit();
        }

        private void buttonCompetition_Click(object sender, EventArgs e)
        {
            TabPage NewPage = new TabPage();
           Classics_2014.Accuracy.EventAccuracyOptions EventTab = MainEngine.StartNewAccuracyEvent();
            NewPage.Controls.Add(EventTab);
            EventTab.Dock = DockStyle.Fill;
            NewPage.Text = "New Event";
            tabControl.TabPages.Add(NewPage);
            tabControl.SelectedTab = NewPage;
        }
        public void UpdateWind(TWind windData)
        {
                textBoxSideSpeed.Invoke((MethodInvoker)(() => textBoxSideSpeed.Text = windData.speed.ToString()));
                textBoxSideDirection.Invoke((MethodInvoker)(() => textBoxSideDirection.Text = windData.direction.ToString()));
        }
        private void timerScoreTimer_Tick(object sender, EventArgs e)
        {
            timerScoreTimer.Stop();
        }
        public void UpdatelistBoxWindLog(TWind[] wind)
        {
            listBoxWindLog.Invoke((MethodInvoker)(() => listBoxWindLog.BeginUpdate()));
            for (int i = 1; i < wind.Length; i++)
            {
                string[] NewItem = new string[3];
                NewItem[0] = wind[i].time;
                NewItem[1] = wind[i].speed.ToString();
                NewItem[2] = wind[i].direction.ToString();
                ListViewItem NewListItem = new ListViewItem(NewItem);
                listBoxWindLog.Invoke((MethodInvoker)(() => listBoxWindLog.Items[i] = NewListItem));
            }
            listBoxWindLog.Invoke((MethodInvoker)(() => listBoxWindLog.EndUpdate()));
        }
        public void UpdateWindGraph(TWind wind)
        {
            chartWind.Invoke((MethodInvoker)(()=> chartWind.Series[0].Points.AddXY(wind.time, wind.speed)));
        }

        private void trackBarWindZoom_Scroll(object sender, EventArgs e)
        {
            numericUpDownChartZoom.Value = trackBarWindZoom.Value;
            chartWind.ChartAreas[0].AxisX.Interval = trackBarWindZoom.Value / 2;
            chartWind.ChartAreas[0].AxisX.ScaleView.Size = trackBarWindZoom.Value * 60;
        }
        private void numericUpDownChartZoom_ValueChanged(object sender, EventArgs e)
        {
            trackBarWindZoom.Value = (int)numericUpDownChartZoom.Value;
            chartWind.ChartAreas[0].AxisX.Interval = (int)numericUpDownChartZoom.Value / 2;
            chartWind.ChartAreas[0].AxisX.ScaleView.Size =(int) numericUpDownChartZoom.Value * 60;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainEngine.CloseThreads();
        }
    }
}
