namespace Classics_2014
{
    partial class windGraphingControllercs
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.chartWind = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.trackBarWindZoom = new System.Windows.Forms.TrackBar();
            this.numericUpDownChartZoom = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownWindOverChartBar = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDirectionChangeGraphLimit = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonUseEventSettings = new System.Windows.Forms.Button();
            this.checkBoxAutoScroll = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.labelChartDirection = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelChartTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxSelectSeries = new System.Windows.Forms.ComboBox();
            this.comboBoxBothOut = new System.Windows.Forms.ComboBox();
            this.comboBoxDirectionOut = new System.Windows.Forms.ComboBox();
            this.comboBoxWindOut = new System.Windows.Forms.ComboBox();
            this.comboBoxNormalColour = new System.Windows.Forms.ComboBox();
            this.numericUpDownHourSearch = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartWind)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWindZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChartZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindOverChartBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDirectionChangeGraphLimit)).BeginInit();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHourSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.chartWind, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel10, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel11, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 4;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.97603F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.02397F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1132, 718);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // chartWind
            // 
            chartArea1.AxisX.Interval = 30D;
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.Interval = 60D;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.AxisX.ScaleView.Size = 3600D;
            chartArea1.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            chartArea1.AxisY.Interval = 0.5D;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.AxisY.Maximum = 10D;
            stripLine1.BackColor = System.Drawing.Color.Red;
            stripLine1.BorderColor = System.Drawing.Color.Red;
            stripLine1.ForeColor = System.Drawing.Color.Red;
            stripLine1.Interval = -1D;
            stripLine1.IntervalOffset = 7D;
            stripLine1.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            stripLine1.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            stripLine1.Text = "Wind Out";
            chartArea1.AxisY.StripLines.Add(stripLine1);
            chartArea1.CursorX.AutoScroll = false;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 91.67554F;
            chartArea1.InnerPlotPosition.Width = 93.91548F;
            chartArea1.InnerPlotPosition.X = 5.526F;
            chartArea1.InnerPlotPosition.Y = 2.23404F;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 94F;
            chartArea1.Position.Width = 94F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 3F;
            this.chartWind.ChartAreas.Add(chartArea1);
            this.chartWind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartWind.Location = new System.Drawing.Point(3, 164);
            this.chartWind.Name = "chartWind";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "SeriesWindDirection";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartWind.Series.Add(series1);
            this.chartWind.Size = new System.Drawing.Size(1126, 519);
            this.chartWind.TabIndex = 0;
            this.chartWind.Text = "chart1";
            this.chartWind.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartWind_MouseMove);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 12;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Controls.Add(this.trackBarWindZoom, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.numericUpDownChartZoom, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.numericUpDownWindOverChartBar, 4, 0);
            this.tableLayoutPanel8.Controls.Add(this.numericUpDownDirectionChangeGraphLimit, 7, 0);
            this.tableLayoutPanel8.Controls.Add(this.label2, 5, 0);
            this.tableLayoutPanel8.Controls.Add(this.label3, 8, 0);
            this.tableLayoutPanel8.Controls.Add(this.buttonUseEventSettings, 10, 0);
            this.tableLayoutPanel8.Controls.Add(this.checkBoxAutoScroll, 11, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 689);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(1126, 26);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // trackBarWindZoom
            // 
            this.trackBarWindZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarWindZoom.Location = new System.Drawing.Point(3, 3);
            this.trackBarWindZoom.Maximum = 120;
            this.trackBarWindZoom.Minimum = 2;
            this.trackBarWindZoom.Name = "trackBarWindZoom";
            this.trackBarWindZoom.Size = new System.Drawing.Size(159, 20);
            this.trackBarWindZoom.TabIndex = 2;
            this.trackBarWindZoom.TickFrequency = 5;
            this.trackBarWindZoom.Value = 60;
            this.trackBarWindZoom.Scroll += new System.EventHandler(this.trackBarWindZoom_Scroll);
            // 
            // numericUpDownChartZoom
            // 
            this.numericUpDownChartZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownChartZoom.Location = new System.Drawing.Point(168, 3);
            this.numericUpDownChartZoom.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericUpDownChartZoom.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownChartZoom.Name = "numericUpDownChartZoom";
            this.numericUpDownChartZoom.Size = new System.Drawing.Size(76, 20);
            this.numericUpDownChartZoom.TabIndex = 3;
            this.numericUpDownChartZoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownChartZoom.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownChartZoom.ValueChanged += new System.EventHandler(this.numericUpDownChartZoom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(250, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Minutes Shown";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownWindOverChartBar
            // 
            this.numericUpDownWindOverChartBar.DecimalPlaces = 1;
            this.numericUpDownWindOverChartBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownWindOverChartBar.Location = new System.Drawing.Point(432, 3);
            this.numericUpDownWindOverChartBar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownWindOverChartBar.Name = "numericUpDownWindOverChartBar";
            this.numericUpDownWindOverChartBar.Size = new System.Drawing.Size(76, 20);
            this.numericUpDownWindOverChartBar.TabIndex = 5;
            this.numericUpDownWindOverChartBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownWindOverChartBar.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownWindOverChartBar.ValueChanged += new System.EventHandler(this.numericUpDownWindOverChartBar_ValueChanged);
            // 
            // numericUpDownDirectionChangeGraphLimit
            // 
            this.numericUpDownDirectionChangeGraphLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownDirectionChangeGraphLimit.Location = new System.Drawing.Point(696, 3);
            this.numericUpDownDirectionChangeGraphLimit.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDownDirectionChangeGraphLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDirectionChangeGraphLimit.Name = "numericUpDownDirectionChangeGraphLimit";
            this.numericUpDownDirectionChangeGraphLimit.Size = new System.Drawing.Size(76, 20);
            this.numericUpDownDirectionChangeGraphLimit.TabIndex = 6;
            this.numericUpDownDirectionChangeGraphLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownDirectionChangeGraphLimit.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDownDirectionChangeGraphLimit.ValueChanged += new System.EventHandler(this.numericUpDownDirectionChangeGraphLimit_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(514, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Speed Over Bar Height";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(778, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "Direction Change Indicator";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonUseEventSettings
            // 
            this.buttonUseEventSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUseEventSettings.Location = new System.Drawing.Point(960, 3);
            this.buttonUseEventSettings.Name = "buttonUseEventSettings";
            this.buttonUseEventSettings.Size = new System.Drawing.Size(76, 20);
            this.buttonUseEventSettings.TabIndex = 9;
            this.buttonUseEventSettings.Text = "Use Event Options";
            this.buttonUseEventSettings.UseVisualStyleBackColor = true;
            this.buttonUseEventSettings.Click += new System.EventHandler(this.buttonUseEventSettings_Click);
            // 
            // checkBoxAutoScroll
            // 
            this.checkBoxAutoScroll.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxAutoScroll.AutoSize = true;
            this.checkBoxAutoScroll.Checked = true;
            this.checkBoxAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoScroll.Location = new System.Drawing.Point(1046, 4);
            this.checkBoxAutoScroll.Name = "checkBoxAutoScroll";
            this.checkBoxAutoScroll.Size = new System.Drawing.Size(77, 17);
            this.checkBoxAutoScroll.TabIndex = 10;
            this.checkBoxAutoScroll.Text = "Auto Scroll";
            this.checkBoxAutoScroll.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 6;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.labelChartDirection, 2, 0);
            this.tableLayoutPanel10.Controls.Add(this.label5, 3, 0);
            this.tableLayoutPanel10.Controls.Add(this.labelChartTime, 4, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 134);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(1126, 24);
            this.tableLayoutPanel10.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(166, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Wind Direction (°) :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelChartDirection
            // 
            this.labelChartDirection.BackColor = System.Drawing.Color.Transparent;
            this.labelChartDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelChartDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChartDirection.ForeColor = System.Drawing.Color.Black;
            this.labelChartDirection.Location = new System.Drawing.Point(366, 0);
            this.labelChartDirection.Name = "labelChartDirection";
            this.labelChartDirection.Size = new System.Drawing.Size(194, 24);
            this.labelChartDirection.TabIndex = 9;
            this.labelChartDirection.Text = "No Data";
            this.labelChartDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(566, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Time:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelChartTime
            // 
            this.labelChartTime.AutoSize = true;
            this.labelChartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelChartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChartTime.ForeColor = System.Drawing.Color.Black;
            this.labelChartTime.Location = new System.Drawing.Point(766, 0);
            this.labelChartTime.Name = "labelChartTime";
            this.labelChartTime.Size = new System.Drawing.Size(194, 24);
            this.labelChartTime.TabIndex = 11;
            this.labelChartTime.Text = "Time";
            this.labelChartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 5;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.Controls.Add(this.label11, 3, 2);
            this.tableLayoutPanel11.Controls.Add(this.label10, 2, 2);
            this.tableLayoutPanel11.Controls.Add(this.label9, 1, 2);
            this.tableLayoutPanel11.Controls.Add(this.label8, 3, 0);
            this.tableLayoutPanel11.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.comboBoxSelectSeries, 3, 3);
            this.tableLayoutPanel11.Controls.Add(this.comboBoxBothOut, 1, 3);
            this.tableLayoutPanel11.Controls.Add(this.comboBoxDirectionOut, 3, 1);
            this.tableLayoutPanel11.Controls.Add(this.comboBoxWindOut, 2, 1);
            this.tableLayoutPanel11.Controls.Add(this.comboBoxNormalColour, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.numericUpDownHourSearch, 2, 3);
            this.tableLayoutPanel11.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 4;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(1126, 125);
            this.tableLayoutPanel11.TabIndex = 5;
            // 
            // comboBoxSelectSeries
            // 
            this.comboBoxSelectSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectSeries.FormattingEnabled = true;
            this.comboBoxSelectSeries.Location = new System.Drawing.Point(678, 85);
            this.comboBoxSelectSeries.Name = "comboBoxSelectSeries";
            this.comboBoxSelectSeries.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelectSeries.TabIndex = 5;
            this.comboBoxSelectSeries.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectSeries_SelectedIndexChanged);
            // 
            // comboBoxBothOut
            // 
            this.comboBoxBothOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBothOut.FormattingEnabled = true;
            this.comboBoxBothOut.Items.AddRange(new object[] {
            "Aqua",
            "Aquamarine",
            "Bisque",
            "Black",
            "Blue",
            "Blue Violet",
            "Brown",
            "Burly Wood",
            "Cadet Blue",
            "Chartreuse",
            "Chocolate",
            "Coral",
            "Cornflower Blue",
            "Crimson",
            "Cyan",
            "Dark Blue",
            "Dark Cyan",
            "Dark Goldenrod",
            "Dark Gray",
            "Dark Green",
            "Dark Khaki",
            "Dark Magenta",
            "Dark Olive Green",
            "Dark Orange",
            "Dark Orchid",
            "Dark Red",
            "Dark Salmon",
            "Dark Sea Green",
            "Dark Slate Blue",
            "Dark SlateGray",
            "Dark Turquoise",
            "Dark Violet",
            "Deep Pink",
            "Deep Sky Blue",
            "Dim Gray",
            "Dodger Blue",
            "Firebrick",
            "Forest Green",
            "Gold",
            "Goldenrod",
            "Gray",
            "Green",
            "Green Yellow",
            "Hot Pink",
            "Indian Red",
            "Indigo",
            "Khaki",
            "Lawn Green",
            "Light Blue",
            "Light Coral",
            "Light Green",
            "Light Gray",
            "Light Pink",
            "Light Salmon",
            "Light Sea Green",
            "Light Sky Blue",
            "Light Slate Gray",
            "Light Steel Blue",
            "Lime",
            "Lime Green",
            "Magenta",
            "Maroon",
            "Medium Aquamarine",
            "Medium Blue",
            "Medium Orchid",
            "Medium Purple",
            "Medium Sea Green",
            "Medium Slate Blue",
            "Medium Spring Green",
            "Medium Turquoise",
            "Medium Violet Red",
            "Midnight Blue",
            "Navy",
            "Olive",
            "Olive Drab",
            "Orange",
            "Orange Red",
            "Orchid",
            "Pale Green",
            "Pale Turquoise",
            "Pale Violet Red",
            "Peach Puff",
            "Peru",
            "Pink",
            "Plum",
            "Powder Blue",
            "Purple",
            "Red",
            "Rosy Brown",
            "Royal Blue",
            "Saddle Brown",
            "Salmon",
            "Sandy Brown",
            "Sea Green",
            "Sienna",
            "Sky Blue",
            "Slate Blue",
            "Slate Gray",
            "Spring Green",
            "Steel Blue",
            "Tan",
            "Teal",
            "Thistle",
            "Tomato",
            "Turquoise",
            "Violet",
            "Wheat",
            "Yellow",
            "Yellow Green"});
            this.comboBoxBothOut.Location = new System.Drawing.Point(228, 85);
            this.comboBoxBothOut.Name = "comboBoxBothOut";
            this.comboBoxBothOut.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBothOut.TabIndex = 3;
            this.comboBoxBothOut.SelectedIndexChanged += new System.EventHandler(this.comboBoxBothOut_SelectedIndexChanged);
            // 
            // comboBoxDirectionOut
            // 
            this.comboBoxDirectionOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirectionOut.FormattingEnabled = true;
            this.comboBoxDirectionOut.Items.AddRange(new object[] {
            "Aqua",
            "Aquamarine",
            "Bisque",
            "Black",
            "Blue",
            "Blue Violet",
            "Brown",
            "Burly Wood",
            "Cadet Blue",
            "Chartreuse",
            "Chocolate",
            "Coral",
            "Cornflower Blue",
            "Crimson",
            "Cyan",
            "Dark Blue",
            "Dark Cyan",
            "Dark Goldenrod",
            "Dark Gray",
            "Dark Green",
            "Dark Khaki",
            "Dark Magenta",
            "Dark Olive Green",
            "Dark Orange",
            "Dark Orchid",
            "Dark Red",
            "Dark Salmon",
            "Dark Sea Green",
            "Dark Slate Blue",
            "Dark SlateGray",
            "Dark Turquoise",
            "Dark Violet",
            "Deep Pink",
            "Deep Sky Blue",
            "Dim Gray",
            "Dodger Blue",
            "Firebrick",
            "Forest Green",
            "Gold",
            "Goldenrod",
            "Gray",
            "Green",
            "Green Yellow",
            "Hot Pink",
            "Indian Red",
            "Indigo",
            "Khaki",
            "Lawn Green",
            "Light Blue",
            "Light Coral",
            "Light Green",
            "Light Gray",
            "Light Pink",
            "Light Salmon",
            "Light Sea Green",
            "Light Sky Blue",
            "Light Slate Gray",
            "Light Steel Blue",
            "Lime",
            "Lime Green",
            "Magenta",
            "Maroon",
            "Medium Aquamarine",
            "Medium Blue",
            "Medium Orchid",
            "Medium Purple",
            "Medium Sea Green",
            "Medium Slate Blue",
            "Medium Spring Green",
            "Medium Turquoise",
            "Medium Violet Red",
            "Midnight Blue",
            "Navy",
            "Olive",
            "Olive Drab",
            "Orange",
            "Orange Red",
            "Orchid",
            "Pale Green",
            "Pale Turquoise",
            "Pale Violet Red",
            "Peach Puff",
            "Peru",
            "Pink",
            "Plum",
            "Powder Blue",
            "Purple",
            "Red",
            "Rosy Brown",
            "Royal Blue",
            "Saddle Brown",
            "Salmon",
            "Sandy Brown",
            "Sea Green",
            "Sienna",
            "Sky Blue",
            "Slate Blue",
            "Slate Gray",
            "Spring Green",
            "Steel Blue",
            "Tan",
            "Teal",
            "Thistle",
            "Tomato",
            "Turquoise",
            "Violet",
            "Wheat",
            "Yellow",
            "Yellow Green"});
            this.comboBoxDirectionOut.Location = new System.Drawing.Point(678, 23);
            this.comboBoxDirectionOut.Name = "comboBoxDirectionOut";
            this.comboBoxDirectionOut.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDirectionOut.TabIndex = 2;
            this.comboBoxDirectionOut.SelectedIndexChanged += new System.EventHandler(this.comboBoxDirectionOut_SelectedIndexChanged);
            // 
            // comboBoxWindOut
            // 
            this.comboBoxWindOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWindOut.FormattingEnabled = true;
            this.comboBoxWindOut.Items.AddRange(new object[] {
            "Aqua",
            "Aquamarine",
            "Bisque",
            "Black",
            "Blue",
            "Blue Violet",
            "Brown",
            "Burly Wood",
            "Cadet Blue",
            "Chartreuse",
            "Chocolate",
            "Coral",
            "Cornflower Blue",
            "Crimson",
            "Cyan",
            "Dark Blue",
            "Dark Cyan",
            "Dark Goldenrod",
            "Dark Gray",
            "Dark Green",
            "Dark Khaki",
            "Dark Magenta",
            "Dark Olive Green",
            "Dark Orange",
            "Dark Orchid",
            "Dark Red",
            "Dark Salmon",
            "Dark Sea Green",
            "Dark Slate Blue",
            "Dark SlateGray",
            "Dark Turquoise",
            "Dark Violet",
            "Deep Pink",
            "Deep Sky Blue",
            "Dim Gray",
            "Dodger Blue",
            "Firebrick",
            "Forest Green",
            "Gold",
            "Goldenrod",
            "Gray",
            "Green",
            "Green Yellow",
            "Hot Pink",
            "Indian Red",
            "Indigo",
            "Khaki",
            "Lawn Green",
            "Light Blue",
            "Light Coral",
            "Light Green",
            "Light Gray",
            "Light Pink",
            "Light Salmon",
            "Light Sea Green",
            "Light Sky Blue",
            "Light Slate Gray",
            "Light Steel Blue",
            "Lime",
            "Lime Green",
            "Magenta",
            "Maroon",
            "Medium Aquamarine",
            "Medium Blue",
            "Medium Orchid",
            "Medium Purple",
            "Medium Sea Green",
            "Medium Slate Blue",
            "Medium Spring Green",
            "Medium Turquoise",
            "Medium Violet Red",
            "Midnight Blue",
            "Navy",
            "Olive",
            "Olive Drab",
            "Orange",
            "Orange Red",
            "Orchid",
            "Pale Green",
            "Pale Turquoise",
            "Pale Violet Red",
            "Peach Puff",
            "Peru",
            "Pink",
            "Plum",
            "Powder Blue",
            "Purple",
            "Red",
            "Rosy Brown",
            "Royal Blue",
            "Saddle Brown",
            "Salmon",
            "Sandy Brown",
            "Sea Green",
            "Sienna",
            "Sky Blue",
            "Slate Blue",
            "Slate Gray",
            "Spring Green",
            "Steel Blue",
            "Tan",
            "Teal",
            "Thistle",
            "Tomato",
            "Turquoise",
            "Violet",
            "Wheat",
            "Yellow",
            "Yellow Green"});
            this.comboBoxWindOut.Location = new System.Drawing.Point(453, 23);
            this.comboBoxWindOut.Name = "comboBoxWindOut";
            this.comboBoxWindOut.Size = new System.Drawing.Size(121, 21);
            this.comboBoxWindOut.TabIndex = 1;
            this.comboBoxWindOut.SelectedIndexChanged += new System.EventHandler(this.comboBoxWindout_SelectedIndexChanged);
            // 
            // comboBoxNormalColour
            // 
            this.comboBoxNormalColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNormalColour.FormattingEnabled = true;
            this.comboBoxNormalColour.Items.AddRange(new object[] {
            "Aqua",
            "Aquamarine",
            "Bisque",
            "Black",
            "Blue",
            "Blue Violet",
            "Brown",
            "Burly Wood",
            "Cadet Blue",
            "Chartreuse",
            "Chocolate",
            "Coral",
            "Cornflower Blue",
            "Crimson",
            "Cyan",
            "Dark Blue",
            "Dark Cyan",
            "Dark Goldenrod",
            "Dark Gray",
            "Dark Green",
            "Dark Khaki",
            "Dark Magenta",
            "Dark Olive Green",
            "Dark Orange",
            "Dark Orchid",
            "Dark Red",
            "Dark Salmon",
            "Dark Sea Green",
            "Dark Slate Blue",
            "Dark SlateGray",
            "Dark Turquoise",
            "Dark Violet",
            "Deep Pink",
            "Deep Sky Blue",
            "Dim Gray",
            "Dodger Blue",
            "Firebrick",
            "Forest Green",
            "Gold",
            "Goldenrod",
            "Gray",
            "Green",
            "Green Yellow",
            "Hot Pink",
            "Indian Red",
            "Indigo",
            "Khaki",
            "Lawn Green",
            "Light Blue",
            "Light Coral",
            "Light Green",
            "Light Gray",
            "Light Pink",
            "Light Salmon",
            "Light Sea Green",
            "Light Sky Blue",
            "Light Slate Gray",
            "Light Steel Blue",
            "Lime",
            "Lime Green",
            "Magenta",
            "Maroon",
            "Medium Aquamarine",
            "Medium Blue",
            "Medium Orchid",
            "Medium Purple",
            "Medium Sea Green",
            "Medium Slate Blue",
            "Medium Spring Green",
            "Medium Turquoise",
            "Medium Violet Red",
            "Midnight Blue",
            "Navy",
            "Olive",
            "Olive Drab",
            "Orange",
            "Orange Red",
            "Orchid",
            "Pale Green",
            "Pale Turquoise",
            "Pale Violet Red",
            "Peach Puff",
            "Peru",
            "Pink",
            "Plum",
            "Powder Blue",
            "Purple",
            "Red",
            "Rosy Brown",
            "Royal Blue",
            "Saddle Brown",
            "Salmon",
            "Sandy Brown",
            "Sea Green",
            "Sienna",
            "Sky Blue",
            "Slate Blue",
            "Slate Gray",
            "Spring Green",
            "Steel Blue",
            "Tan",
            "Teal",
            "Thistle",
            "Tomato",
            "Turquoise",
            "Violet",
            "Wheat",
            "Yellow",
            "Yellow Green"});
            this.comboBoxNormalColour.Location = new System.Drawing.Point(228, 23);
            this.comboBoxNormalColour.Name = "comboBoxNormalColour";
            this.comboBoxNormalColour.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNormalColour.TabIndex = 0;
            this.comboBoxNormalColour.SelectedIndexChanged += new System.EventHandler(this.comboBoxNormalColour_SelectedIndexChanged);
            // 
            // numericUpDownHourSearch
            // 
            this.numericUpDownHourSearch.InterceptArrowKeys = false;
            this.numericUpDownHourSearch.Location = new System.Drawing.Point(453, 85);
            this.numericUpDownHourSearch.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownHourSearch.Name = "numericUpDownHourSearch";
            this.numericUpDownHourSearch.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownHourSearch.TabIndex = 4;
            this.numericUpDownHourSearch.ValueChanged += new System.EventHandler(this.dateTimePickerChartTimeFinder_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(453, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Graph Colour Wind Speed Over";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(228, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Graph Colour All is Well";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(678, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(205, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Graph Colour Direction Change Exceeded";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(228, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Graph Colour Wind and Direction Breach";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(453, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Go To Hour";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(678, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Open Master File";
            // 
            // windGraphingControllercs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel7);
            this.DoubleBuffered = true;
            this.Name = "windGraphingControllercs";
            this.Size = new System.Drawing.Size(1132, 718);
            this.tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartWind)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWindZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChartZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindOverChartBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDirectionChangeGraphLimit)).EndInit();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHourSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWind;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TrackBar trackBarWindZoom;
        private System.Windows.Forms.NumericUpDown numericUpDownChartZoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownWindOverChartBar;
        private System.Windows.Forms.NumericUpDown numericUpDownDirectionChangeGraphLimit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonUseEventSettings;
        private System.Windows.Forms.CheckBox checkBoxAutoScroll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelChartDirection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelChartTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.ComboBox comboBoxBothOut;
        private System.Windows.Forms.ComboBox comboBoxDirectionOut;
        private System.Windows.Forms.ComboBox comboBoxWindOut;
        private System.Windows.Forms.ComboBox comboBoxNormalColour;
        private System.Windows.Forms.NumericUpDown numericUpDownHourSearch;
        private System.Windows.Forms.ComboBox comboBoxSelectSeries;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;

    }
}
