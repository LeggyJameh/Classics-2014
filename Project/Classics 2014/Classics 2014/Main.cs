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
        Boolean SpeedOut;
        DataPoint prevData;
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
            if (2 < (chartWind.Series[0].Points.Count))
            {
                prevData = chartWind.Series[0].Points[chartWind.Series[0].Points.Count - 2];
            }
            chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points.AddXY(wind.time, wind.speed)));
            chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[chartWind.Series[0].Points.Count - 1].Tag = wind.direction.ToString()));
            if (2 < (chartWind.Series[0].Points.Count))
            {
                prevData = chartWind.Series[0].Points[chartWind.Series[0].Points.Count - 2];
                PointColorCheckSet(wind, chartWind.Series[0].Points.Count - 1);
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
            bool both = false;
            if (wind.speed > chartWind.ChartAreas[0].AxisY.StripLines[0].IntervalOffset) { chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = Color.OrangeRed)); both = true; } //If wind out
            else { chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = Color.Blue)); }

            if (IsDirectionOut(wind, Convert.ToInt16(prevData.Tag.ToString())))
            {
                chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = Color.Yellow));
                if (SpeedOut)
                {
                    chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = Color.DarkRed));
                } //If Direction out

                else { chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = Color.Blue)); }
                if (both)
                {
                    chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = Color.Purple));
                }
            }
        }
            private bool IsDirectionOut(TWind wind, int prevData)
            {
                //ToDo Check you checks Mofo
                 int minimum, maximum,minOverFlow, maxOverFlow;
                 bool OutMin = false;
                //Min Checks
                 if (prevData > numericUpDownDirectionChangeGraphLimit.Value)
                 {
                     minimum = 0;
                     minOverFlow = (360 - ((int)numericUpDownDirectionChangeGraphLimit.Value -prevData)); 
                     if((wind.direction < prevData)||(wind.direction > minOverFlow)) {  return false; }
                 }
                 else
                     {
                     minimum = prevData-(int) numericUpDownDirectionChangeGraphLimit.Value;
                     if (wind.direction < minimum) {OutMin = true;}
                     }
                //Max checks
                if ((prevData + (int)numericUpDownDirectionChangeGraphLimit.Value)>360)
                {
                    maximum = 360;
                    maxOverFlow = 0+ ((prevData + (int)numericUpDownDirectionChangeGraphLimit.Value)-360);
                    if ((wind.direction > prevData) || (wind.direction < maxOverFlow)) { return false;}
                }
                else
                {
                   maximum = prevData + (int)numericUpDownDirectionChangeGraphLimit.Value;
                   if (wind.direction < maximum) { if (OutMin) { return false; } }
                }
              
                return true;
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

        private void numericUpDownWindOverChartBar_ValueChanged(object sender, EventArgs e)
        {
            if ((double)numericUpDownWindOverChartBar.Value > chartWind.ChartAreas[0].AxisY.Maximum) { numericUpDownWindOverChartBar.Value = (decimal)chartWind.ChartAreas[0].AxisY.Maximum; }
            chartWind.ChartAreas[0].AxisY.StripLines[0].IntervalOffset = (double)numericUpDownWindOverChartBar.Value;
            for (int i = 0; i < chartWind.Series[0].Points.Count; i++)
			{
			 PointColorCheckSet(new TWind{speed = (float) chartWind.Series[0].Points[i].YValues[0], direction = (ushort)Convert.ToInt16(chartWind.Series[0].Points[i].Tag.ToString())}, i);
			}
            
            //ToDO Make graph detect line changes and edit colour
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
                }
                else
                {
                    labelChartDirection.Text = "No Data";
                }
            }
            else
            {
                labelChartDirection.Text = "No Data";
            }
            
        
        }

        private void numericUpDownDirectionChangeGraphLimit_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chartWind.Series[0].Points.Count; i++)
            {
                PointColorCheckSet(new TWind { speed = (float)chartWind.Series[0].Points[i].YValues[0], direction = (ushort)Convert.ToInt16(chartWind.Series[0].Points[i].Tag.ToString()) }, i);
            }
        }
    }
}
