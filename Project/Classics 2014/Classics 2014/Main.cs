using System;
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
        Engine MainEngine;
        DataPoint prevData;
        Color NormalChartColour = Color.CadetBlue, WindoutChartColour = Color.OrangeRed, DirectionoutChartColour = Color.Yellow, BothOutChartColour = Color.Purple;
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
            comboBoxNormalColour.SelectedItem = NormalChartColour.Name;
            comboBoxWindOut.SelectedItem = WindoutChartColour.Name;
            comboBoxDirectionOut.SelectedItem = DirectionoutChartColour.Name;
            comboBoxBothOut.SelectedItem = BothOutChartColour.Name;
            AquireGraph();

        }
        public void DeSerializeGraph()
        {
            StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentGraph.Tx");
            string input;
            string[] args;
            while (!reader.EndOfStream)
            {
                input = reader.ReadLine();
                args = input.Split('*');
                chartWind.Series[0].Points.AddXY(args[0], decimal.Parse(args[1]));
                chartWind.Series[0].Points[chartWind.Series[0].Points.Count - 1].Tag = args[2];
            }
            reader.BaseStream.Close();
            reader.Dispose();
            for (int i = 2; i < chartWind.Series[0].Points.Count; i++)
            {
                prevData = chartWind.Series[0].Points[i - 1];
                PointColorCheckSetNonInvokable(new TWind { speed = (float)chartWind.Series[0].Points[i].YValues[0], direction = (ushort)Convert.ToInt16(chartWind.Series[0].Points[i].Tag.ToString()) }, i);
                trackBarWindZoom_Scroll(this, new EventArgs());
            }

        }
        private void AquireGraph()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentGraph.Tx"))
            {
                DateTime lastCreationTime = File.GetCreationTime(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentGraph.Tx");
                if (lastCreationTime.Date.DayOfYear == DateTime.Now.DayOfYear)
                {
                    DeSerializeGraph();
                    return;
                }
            }
            File.Create(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentGraph.Tx");
            
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            SaveGraph();
            MainEngine.CloseThreads();
            this.Close();
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
            if (2 < (chartWind.Series[0].Points.Count))
            {
                prevData = chartWind.Series[0].Points[chartWind.Series[0].Points.Count - 2];
            }
            chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points.AddXY(wind.time, wind.speed)));
            chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[chartWind.Series[0].Points.Count - 1].Tag = wind.direction.ToString()));
            if (2 < (chartWind.Series[0].Points.Count))
            {
                prevData = chartWind.Series[0].Points[chartWind.Series[0].Points.Count - 2];
                chartWind.Invoke((MethodInvoker)(() => PointColorCheckSet(wind, chartWind.Series[0].Points.Count - 1)));
                if (checkBoxAutoScroll.Checked)
                {
                    if (chartWind.ChartAreas[0].AxisX.ScrollBar.IsVisible == true)
                    {
                        if (checkBoxAutoScroll.Checked)
                        {
                            chartWind.Invoke((MethodInvoker)(() => chartWind.ChartAreas[0].AxisX.ScaleView.Position += 1));
                        }
                    }
                }
            }
        }

        private void PointColorCheckSet(TWind wind, int index)
        {
            bool Speed = false;
            bool directionOut;
            if (wind.speed > chartWind.ChartAreas[0].AxisY.StripLines[0].IntervalOffset) { chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = WindoutChartColour)); Speed = true; } //If wind out
            else { chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = NormalChartColour)); }
            directionOut = IsDirectionOut(wind, Convert.ToInt16(prevData.Tag.ToString()));
            if (directionOut)
            {
                chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = DirectionoutChartColour));
                chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index-1].Color = DirectionoutChartColour));
                if (Speed)
                {
                    chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = BothOutChartColour));
                }
            }
        }
        private void PointColorCheckSetNonInvokable(TWind wind, int index)
        {
            bool Speed = false;
            bool directionOut;
            if (wind.speed > chartWind.ChartAreas[0].AxisY.StripLines[0].IntervalOffset) {  chartWind.Series[0].Points[index].Color = WindoutChartColour; Speed = true; } //If wind out
            else { chartWind.Series[0].Points[index].Color = NormalChartColour; }
            directionOut = IsDirectionOut(wind, Convert.ToInt16(prevData.Tag.ToString()));
            if (directionOut)
            {
                chartWind.Series[0].Points[index].Color = DirectionoutChartColour;
                chartWind.Series[0].Points[index - 1].Color = DirectionoutChartColour;
                if (Speed)
                {chartWind.Series[0].Points[index].Color = BothOutChartColour;
                }
            }
        }
        private bool IsDirectionOut(TWind wind, int prevData)
        {
            int minimum, maximum, minOverFlow, maxOverFlow;
            if (prevData < numericUpDownDirectionChangeGraphLimit.Value)
            {
                minimum = 0;
                minOverFlow = (360 - ((int)numericUpDownDirectionChangeGraphLimit.Value - prevData));
                if ((wind.direction <= prevData) || (wind.direction > minOverFlow)) { return false; }
            }
            else
            {
                minimum = prevData - (int)numericUpDownDirectionChangeGraphLimit.Value;
                if (wind.direction < minimum) { return true; }
                else if (prevData > wind.direction) { return false; }
            }
            //Max checks
            if ((prevData + (int)numericUpDownDirectionChangeGraphLimit.Value) > 360)
            {
                maximum = 360;
                maxOverFlow = 0 + ((prevData + (int)numericUpDownDirectionChangeGraphLimit.Value) - 360);
                if ((wind.direction >= prevData) || (wind.direction < maxOverFlow)) { return false; }
            }
            else
            {
                maximum = prevData + (int)numericUpDownDirectionChangeGraphLimit.Value;
                if (wind.direction > maximum) { return true; }
            }

            return false;
        }
        private void trackBarWindZoom_Scroll(object sender, EventArgs e)
        {
            numericUpDownChartZoom.Value = trackBarWindZoom.Value;
            chartWind.ChartAreas[0].AxisX.Interval = trackBarWindZoom.Value / 2;
            chartWind.ChartAreas[0].AxisX.ScaleView.Size = trackBarWindZoom.Value * 60;
            chartWind.ChartAreas[0].AxisX.LabelStyle.Interval = (int)numericUpDownChartZoom.Value * 2;
        }
        private void numericUpDownChartZoom_ValueChanged(object sender, EventArgs e)
        {
            trackBarWindZoom.Value = (int)numericUpDownChartZoom.Value;
            chartWind.ChartAreas[0].AxisX.Interval = (int)numericUpDownChartZoom.Value / 2;
            chartWind.ChartAreas[0].AxisX.ScaleView.Size = (int)numericUpDownChartZoom.Value * 60;
            chartWind.ChartAreas[0].AxisX.LabelStyle.Interval = (int)numericUpDownChartZoom.Value *2;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainEngine.CloseThreads();
            SaveGraph();
        }
        private void SaveGraph()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentGraph.Tx"))
            {
                File.Create(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentGraph.Tx");
            }
            GC.Collect();
            using (StreamWriter s = new StreamWriter(Directory.GetCurrentDirectory() + "\\RecentMasterFile\\RecentGraph.Tx",true))
            {
                
                for (int i = 0; i < chartWind.Series[0].Points.Count; i++)
                {
                    DataPoint p = chartWind.Series[0].Points[i];
                    s.WriteLine(p.AxisLabel + "*" + p.YValues[0] + "*" + p.Tag.ToString());
                }
            }
        }
        private void ResetGraphColours()
        {
            for (int i = 2; i < chartWind.Series[0].Points.Count; i++)
            {
                prevData = chartWind.Series[0].Points[i - 1];
                PointColorCheckSet(new TWind { speed = (float)chartWind.Series[0].Points[i].YValues[0], direction = (ushort)Convert.ToInt16(chartWind.Series[0].Points[i].Tag.ToString()) }, i);
            }
        }
        private void numericUpDownWindOverChartBar_ValueChanged(object sender, EventArgs e)
        {
            if ((double)numericUpDownWindOverChartBar.Value > chartWind.ChartAreas[0].AxisY.Maximum) { numericUpDownWindOverChartBar.Value = (decimal)chartWind.ChartAreas[0].AxisY.Maximum; }
            chartWind.ChartAreas[0].AxisY.StripLines[0].IntervalOffset = (double)numericUpDownWindOverChartBar.Value;
            ResetGraphColours();
        }

        private void chartWind_MouseMove(object sender, MouseEventArgs e)
        {
            DataPoint dataPoint;
            Point mousePoint = new Point(e.X, e.Y);
            chartWind.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
            if ((int)chartWind.ChartAreas[0].CursorX.Position < chartWind.Series[0].Points.Count)
            {
                if (chartWind.ChartAreas[0].CursorX.Position < 0) { chartWind.ChartAreas[0].CursorX.Position = 0; }
                dataPoint = chartWind.Series[0].Points[(int)chartWind.ChartAreas[0].CursorX.Position];
                if ((dataPoint != null)&&(dataPoint.Tag!= null))
                {
                    labelChartDirection.Text = dataPoint.Tag.ToString();
                    labelChartTime.Text = dataPoint.AxisLabel;
                }
                else
                {
                    labelChartDirection.Text = "No Data";
                    labelChartTime.Text = "No Data";
                    labelChartTime.Text = dataPoint.Color.Name;
                }
            }
            else
            {
                labelChartDirection.Text = "No Data";
                labelChartTime.Text = "No Data";
            }


        }

        private void numericUpDownDirectionChangeGraphLimit_ValueChanged(object sender, EventArgs e)
        {
            ResetGraphColours();
        }

        private void comboBoxNormalColour_SelectedIndexChanged(object sender, EventArgs e)
        {
            NormalChartColour = Color.FromName(comboBoxNormalColour.SelectedItem.ToString());
            ResetGraphColours();
        }

        private void comboBoxWindout_SelectedIndexChanged(object sender, EventArgs e)
        {
            WindoutChartColour = Color.FromName(comboBoxWindOut.SelectedItem.ToString());
            ResetGraphColours();
        }

        private void comboBoxDirectionOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectionoutChartColour = Color.FromName(comboBoxDirectionOut.SelectedItem.ToString());
            ResetGraphColours();
        }

        private void comboBoxBothOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            BothOutChartColour = Color.FromName(comboBoxBothOut.SelectedItem.ToString());
            ResetGraphColours();
        }

        private void buttonUseEventSettings_Click(object sender, EventArgs e)
        {
            if (MainEngine.activeEvent is Accuracy.Accuracy_Event)
            {
                Accuracy.Accuracy_Event Event = (MainEngine.activeEvent as Accuracy.Accuracy_Event);
                chartWind.ChartAreas[0].AxisY.StripLines[0].Interval = Event.ruleSet.windout;
                numericUpDownWindOverChartBar.Value = (decimal)(Event.ruleSet.windout);
                numericUpDownDirectionChangeGraphLimit.Value = Event.ruleSet.directionOut;
                ResetGraphColours();
            }
            else { MessageBox.Show("No event suitable for transplanting rules.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
            
        }

        private void dateTimePickerChartTimeFinder_ValueChanged(object sender, EventArgs e)
        {
            
            foreach (DataPoint dP in chartWind.Series[0].Points)
            {
<<<<<<< HEAD
                //MainEngine.activeEvent.rules
=======
                int hour = Convert.ToInt16(dP.AxisLabel.Substring(0, 2));
                if (hour == numericUpDownHourSearch.Value)
                {
                    chartWind.ChartAreas[0].AxisX.ScaleView.Position = dP.XValue;
                    return;
                }
>>>>>>> origin/master
            }
            MessageBox.Show("Hour not on record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }
    }
}
