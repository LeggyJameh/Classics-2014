using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace Classics_2014
{
     partial class windGraphingControllercs : UserControl
    {
         public Engine MainEngine;
         string seriesSelectedValue;
        DataPoint prevData;
        public windGraphingControllercs()
        {
            InitializeComponent();
            InitializeSelf();
        }
        public void InitializeSelf()
        {
            PopulateSeriesList();
            comboBoxSelectSeries.SelectedItem = "Recent";
        }
        private void PopulateSeriesList()
        {
            List<string> names = new List<string>();
            comboBoxSelectSeries.Items.Add("Recent");
            string[] Names = (Directory.GetFiles(Directory.GetCurrentDirectory() + "\\" + "OldMasterFiles"));//ToDo Edit path here as well
            foreach (string s in Names)
            {
                names.Add(s.Substring(s.LastIndexOf('\\') + 1));
            }
            comboBoxSelectSeries.Items.AddRange(names.ToArray());
        }
        public void UpdateWindGraph(TWind wind)
        {
            if (seriesSelectedValue == "Recent")
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
        }
        public void UpdateWindGraphNonInvokable(TWind wind)
        {
            if (2 < (chartWind.Series[0].Points.Count))
            {
                prevData = chartWind.Series[0].Points[chartWind.Series[0].Points.Count - 2];
            }
            chartWind.Series[0].Points.AddXY(wind.time, wind.speed);
            chartWind.Series[0].Points[chartWind.Series[0].Points.Count - 1].Tag = wind.direction.ToString();
            if (2 < (chartWind.Series[0].Points.Count))
            {
                prevData = chartWind.Series[0].Points[chartWind.Series[0].Points.Count - 2];
                PointColorCheckSetNonInvokable(wind, chartWind.Series[0].Points.Count - 1);
                if (checkBoxAutoScroll.Checked)
                {
                    if (chartWind.ChartAreas[0].AxisX.ScrollBar.IsVisible == true)
                    {
                        if (checkBoxAutoScroll.Checked)
                        {
                            chartWind.ChartAreas[0].AxisX.ScaleView.Position += 1;
                        }
                    }
                }
            }
        }

        private void PointColorCheckSet(TWind wind, int index)
        {
            bool Speed = false;
            bool directionOut;
            if (wind.speed > chartWind.ChartAreas[0].AxisY.StripLines[0].IntervalOffset) { 
                chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = UserSettings.Default.graphWindOut)); 
                Speed = true;
            } //If wind out
            else { chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = UserSettings.Default.graphNormal)); }
            directionOut = IsDirectionOut(wind, Convert.ToInt16(prevData.Tag.ToString()));
            if (directionOut)
            {
                chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = UserSettings.Default.graphDirectionOut));
                chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index - 1].Color = UserSettings.Default.graphDirectionOut));
                if (Speed)
                {
                    chartWind.Invoke((MethodInvoker)(() => chartWind.Series[0].Points[index].Color = UserSettings.Default.graphBothOut));
                }
            }
        }
        private void PointColorCheckSetNonInvokable(TWind wind, int index)
        {
            bool Speed = false;
            bool directionOut;
            if (wind.speed > chartWind.ChartAreas[0].AxisY.StripLines[0].IntervalOffset) { chartWind.Series[0].Points[index].Color = UserSettings.Default.graphWindOut; Speed = true; } //If wind out
            else { chartWind.Series[0].Points[index].Color = UserSettings.Default.graphNormal; }
            directionOut = IsDirectionOut(wind, Convert.ToInt16(prevData.Tag.ToString()));
            if (directionOut)
            {
                chartWind.Series[0].Points[index].Color = UserSettings.Default.graphDirectionOut;
                chartWind.Series[0].Points[index - 1].Color = UserSettings.Default.graphDirectionOut;
                if (Speed)
                {
                    chartWind.Series[0].Points[index].Color = UserSettings.Default.graphBothOut;
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
            chartWind.ChartAreas[0].AxisX.LabelStyle.Interval = (int)numericUpDownChartZoom.Value * 2;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserSettings.Default.Save();
            MainEngine.CloseThreads();
        }

        public void ResetGraphColours()
        {
            for (int i = 2; i < chartWind.Series[0].Points.Count; i++)
            {
                prevData = chartWind.Series[0].Points[i - 1];
                PointColorCheckSetNonInvokable(new TWind { speed = (float)chartWind.Series[0].Points[i].YValues[0], direction = (ushort)Convert.ToInt16(chartWind.Series[0].Points[i].Tag.ToString()) }, i);
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
                if ((dataPoint != null) && (dataPoint.Tag != null))
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

        private void buttonUseEventSettings_Click(object sender, EventArgs e)
        {
            if (MainEngine.activeEvent is Accuracy.Accuracy_Event)
            {
                Accuracy.Accuracy_Event Event = (MainEngine.activeEvent as Accuracy.Accuracy_Event);
                chartWind.ChartAreas[0].AxisY.StripLines[0].IntervalOffset = Event.ruleSet.windout;
                numericUpDownWindOverChartBar.Value = (decimal)(Event.ruleSet.windout);
                numericUpDownDirectionChangeGraphLimit.Value = Event.ruleSet.directionOut;
                ResetGraphColours();
            }
            else { MessageBox.Show("No event suitable for transplanting rules.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }


        }

        private void dateTimePickerChartTimeFinder_ValueChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < chartWind.Series[0].Points.Count; i++)
            {
                DataPoint dP = chartWind.Series[0].Points[i];
                int hour = Convert.ToInt16(dP.AxisLabel.Substring(0, 2));
                if (hour == numericUpDownHourSearch.Value)
                {
                    chartWind.ChartAreas[0].AxisX.ScaleView.Position = i;
                    return;
                }
            }
            MessageBox.Show("Hour not on record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void comboBoxSelectSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartWind.ChartAreas.SuspendUpdates();
            try
            {
                if ((string)comboBoxSelectSeries.SelectedItem != "")
                {
                    chartWind.Series[0].Points.Clear();
                    seriesSelectedValue = (string)comboBoxSelectSeries.SelectedItem;
                    if ((seriesSelectedValue == "Recent") && (chartWind.FindForm().IsHandleCreated))
                    {
                                MainEngine.DeSerializeGraph(new StreamReader(MainEngine.fileStream));
                    }
                    else
                    {MainEngine.DeSerializeGraph(new StreamReader(Directory.GetCurrentDirectory() + "\\OldMasterFiles\\" + seriesSelectedValue)); }
                    
                }
            }
            catch (Exception ex)
            {
            }
            chartWind.ChartAreas.ResumeUpdates();
        }
    }
}
