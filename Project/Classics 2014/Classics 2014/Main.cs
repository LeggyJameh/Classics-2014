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

                if (Speed)
                {
                    chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = BothOutChartColour));
                }
            }
        }
        private bool IsDirectionOut(TWind wind, int prevData)
        {
            //ToDo Check you checks Mofo
            int minimum, maximum, minOverFlow, maxOverFlow;
            //Min Checks 300 292 5
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
        }
        private void numericUpDownChartZoom_ValueChanged(object sender, EventArgs e)
        {
            trackBarWindZoom.Value = (int)numericUpDownChartZoom.Value;
            chartWind.ChartAreas[0].AxisX.Interval = (int)numericUpDownChartZoom.Value / 2;
            chartWind.ChartAreas[0].AxisX.ScaleView.Size = (int)numericUpDownChartZoom.Value * 60;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainEngine.CloseThreads();
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
                if (dataPoint != null)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            WindoutChartColour = Color.FromName(comboBoxWindOut.SelectedItem.ToString());
            ResetGraphColours();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectionoutChartColour = Color.FromName(comboBoxDirectionOut.SelectedItem.ToString());
            ResetGraphColours();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            BothOutChartColour = Color.FromName(comboBoxBothOut.SelectedItem.ToString());
            ResetGraphColours();
        }

        private void buttonUseEventSettings_Click(object sender, EventArgs e)
        {
            if (MainEngine.activeEvent != null)
            {
                //MainEngine.activeEvent.rules
            }
        }
    }
}
