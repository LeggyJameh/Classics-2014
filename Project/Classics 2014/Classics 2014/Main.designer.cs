namespace Classics_2014
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "T",
            "S",
            "D"}, -1);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCompetition = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonModifyCompetitorData = new System.Windows.Forms.Button();
            this.buttonMainSettings = new System.Windows.Forms.Button();
            this.tabWind = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tabEventLoad = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.EventBrowserButtonLoad = new System.Windows.Forms.Button();
            this.EventBrowserButtonCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.EventBrowserListBoxCompetitors = new System.Windows.Forms.ListBox();
            this.EventBrowserLabelCompetitors = new System.Windows.Forms.Label();
            this.EventBrowserEventGrid = new System.Windows.Forms.DataGridView();
            this.ColumnEventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEventDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timerScoreTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxSideDirection = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxSideSpeed = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxSideScore = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.listBoxWindLog = new System.Windows.Forms.ListView();
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Speed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Direction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelError = new System.Windows.Forms.Label();
            this.chartWind = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.trackBarWindZoom = new System.Windows.Forms.TrackBar();
            this.numericUpDownChartZoom = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabWind.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tabEventLoad.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventBrowserEventGrid)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartWind)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWindZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChartZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabWind);
            this.tabControl.Controls.Add(this.tabEventLoad);
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1113, 631);
            this.tabControl.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.AutoScroll = true;
            this.tabMain.Controls.Add(this.tableLayoutPanel9);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1105, 605);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main Menu";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel9.Controls.Add(this.buttonCompetition, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.buttonLoad, 1, 3);
            this.tableLayoutPanel9.Controls.Add(this.buttonExit, 1, 11);
            this.tableLayoutPanel9.Controls.Add(this.buttonHelp, 1, 7);
            this.tableLayoutPanel9.Controls.Add(this.buttonModifyCompetitorData, 1, 5);
            this.tableLayoutPanel9.Controls.Add(this.buttonMainSettings, 1, 9);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 13;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.16691F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333403F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333403F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333403F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333403F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.33257F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.16691F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1099, 599);
            this.tableLayoutPanel9.TabIndex = 5;
            // 
            // buttonCompetition
            // 
            this.buttonCompetition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCompetition.Location = new System.Drawing.Point(369, 90);
            this.buttonCompetition.Name = "buttonCompetition";
            this.buttonCompetition.Size = new System.Drawing.Size(360, 44);
            this.buttonCompetition.TabIndex = 0;
            this.buttonCompetition.Text = "Start New Event";
            this.buttonCompetition.UseVisualStyleBackColor = true;
            this.buttonCompetition.Click += new System.EventHandler(this.buttonCompetition_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(369, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoad.Location = new System.Drawing.Point(369, 164);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(360, 44);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load Previous Events";
            this.buttonLoad.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Location = new System.Drawing.Point(369, 460);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(360, 44);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHelp.Location = new System.Drawing.Point(369, 312);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(360, 44);
            this.buttonHelp.TabIndex = 3;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            // 
            // buttonModifyCompetitorData
            // 
            this.buttonModifyCompetitorData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonModifyCompetitorData.Location = new System.Drawing.Point(369, 238);
            this.buttonModifyCompetitorData.Name = "buttonModifyCompetitorData";
            this.buttonModifyCompetitorData.Size = new System.Drawing.Size(360, 44);
            this.buttonModifyCompetitorData.TabIndex = 6;
            this.buttonModifyCompetitorData.Text = "Modify Competitors";
            this.buttonModifyCompetitorData.UseVisualStyleBackColor = true;
            // 
            // buttonMainSettings
            // 
            this.buttonMainSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMainSettings.Location = new System.Drawing.Point(369, 386);
            this.buttonMainSettings.Name = "buttonMainSettings";
            this.buttonMainSettings.Size = new System.Drawing.Size(360, 44);
            this.buttonMainSettings.TabIndex = 7;
            this.buttonMainSettings.Text = "Settings";
            this.buttonMainSettings.UseVisualStyleBackColor = true;
            // 
            // tabWind
            // 
            this.tabWind.Controls.Add(this.tableLayoutPanel7);
            this.tabWind.Location = new System.Drawing.Point(4, 22);
            this.tabWind.Name = "tabWind";
            this.tabWind.Size = new System.Drawing.Size(1105, 605);
            this.tabWind.TabIndex = 1;
            this.tabWind.Text = "Anemometer Control";
            this.tabWind.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.chartWind, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 2);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.13014F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.86986F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1105, 605);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // tabEventLoad
            // 
            this.tabEventLoad.Controls.Add(this.tableLayoutPanel1);
            this.tabEventLoad.Location = new System.Drawing.Point(4, 22);
            this.tabEventLoad.Name = "tabEventLoad";
            this.tabEventLoad.Size = new System.Drawing.Size(1105, 605);
            this.tabEventLoad.TabIndex = 3;
            this.tabEventLoad.Text = "Event Browser";
            this.tabEventLoad.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1105, 605);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.EventBrowserButtonLoad, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.EventBrowserButtonCancel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 558);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1099, 44);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // EventBrowserButtonLoad
            // 
            this.EventBrowserButtonLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventBrowserButtonLoad.Location = new System.Drawing.Point(3, 3);
            this.EventBrowserButtonLoad.Name = "EventBrowserButtonLoad";
            this.EventBrowserButtonLoad.Size = new System.Drawing.Size(543, 38);
            this.EventBrowserButtonLoad.TabIndex = 0;
            this.EventBrowserButtonLoad.Text = "Load Event";
            this.EventBrowserButtonLoad.UseVisualStyleBackColor = true;
            // 
            // EventBrowserButtonCancel
            // 
            this.EventBrowserButtonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventBrowserButtonCancel.Location = new System.Drawing.Point(552, 3);
            this.EventBrowserButtonCancel.Name = "EventBrowserButtonCancel";
            this.EventBrowserButtonCancel.Size = new System.Drawing.Size(544, 38);
            this.EventBrowserButtonCancel.TabIndex = 1;
            this.EventBrowserButtonCancel.Text = "Cancel";
            this.EventBrowserButtonCancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.EventBrowserEventGrid, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1099, 549);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.EventBrowserListBoxCompetitors, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.EventBrowserLabelCompetitors, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(882, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(214, 543);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // EventBrowserListBoxCompetitors
            // 
            this.EventBrowserListBoxCompetitors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventBrowserListBoxCompetitors.FormattingEnabled = true;
            this.EventBrowserListBoxCompetitors.Location = new System.Drawing.Point(3, 30);
            this.EventBrowserListBoxCompetitors.Name = "EventBrowserListBoxCompetitors";
            this.EventBrowserListBoxCompetitors.ScrollAlwaysVisible = true;
            this.EventBrowserListBoxCompetitors.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.EventBrowserListBoxCompetitors.Size = new System.Drawing.Size(208, 510);
            this.EventBrowserListBoxCompetitors.TabIndex = 0;
            // 
            // EventBrowserLabelCompetitors
            // 
            this.EventBrowserLabelCompetitors.AutoSize = true;
            this.EventBrowserLabelCompetitors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventBrowserLabelCompetitors.Location = new System.Drawing.Point(3, 0);
            this.EventBrowserLabelCompetitors.Name = "EventBrowserLabelCompetitors";
            this.EventBrowserLabelCompetitors.Size = new System.Drawing.Size(208, 27);
            this.EventBrowserLabelCompetitors.TabIndex = 1;
            this.EventBrowserLabelCompetitors.Text = "Competitors";
            this.EventBrowserLabelCompetitors.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // EventBrowserEventGrid
            // 
            this.EventBrowserEventGrid.AllowUserToAddRows = false;
            this.EventBrowserEventGrid.AllowUserToDeleteRows = false;
            this.EventBrowserEventGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EventBrowserEventGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EventBrowserEventGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEventID,
            this.ColumnEventName,
            this.ColumnEventDate});
            this.EventBrowserEventGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventBrowserEventGrid.Location = new System.Drawing.Point(3, 3);
            this.EventBrowserEventGrid.MultiSelect = false;
            this.EventBrowserEventGrid.Name = "EventBrowserEventGrid";
            this.EventBrowserEventGrid.ReadOnly = true;
            this.EventBrowserEventGrid.Size = new System.Drawing.Size(873, 543);
            this.EventBrowserEventGrid.TabIndex = 2;
            // 
            // ColumnEventID
            // 
            this.ColumnEventID.HeaderText = "ID";
            this.ColumnEventID.Name = "ColumnEventID";
            this.ColumnEventID.ReadOnly = true;
            this.ColumnEventID.Visible = false;
            // 
            // ColumnEventName
            // 
            this.ColumnEventName.HeaderText = "Name";
            this.ColumnEventName.Name = "ColumnEventName";
            this.ColumnEventName.ReadOnly = true;
            // 
            // ColumnEventDate
            // 
            this.ColumnEventDate.HeaderText = "Date";
            this.ColumnEventDate.Name = "ColumnEventDate";
            this.ColumnEventDate.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 637);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1244, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timerScoreTimer
            // 
            this.timerScoreTimer.Enabled = true;
            this.timerScoreTimer.Interval = 15000;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1244, 637);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.textBoxSideDirection, 0, 6);
            this.tableLayoutPanel6.Controls.Add(this.label13, 0, 5);
            this.tableLayoutPanel6.Controls.Add(this.textBoxSideSpeed, 0, 4);
            this.tableLayoutPanel6.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.textBoxSideScore, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.listBoxWindLog, 0, 7);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(1122, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 8;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(119, 631);
            this.tableLayoutPanel6.TabIndex = 1;
            this.tableLayoutPanel6.Visible = false;
            // 
            // textBoxSideDirection
            // 
            this.textBoxSideDirection.AutoSize = true;
            this.textBoxSideDirection.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxSideDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSideDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSideDirection.ForeColor = System.Drawing.Color.White;
            this.textBoxSideDirection.Location = new System.Drawing.Point(3, 292);
            this.textBoxSideDirection.Name = "textBoxSideDirection";
            this.textBoxSideDirection.Size = new System.Drawing.Size(113, 91);
            this.textBoxSideDirection.TabIndex = 8;
            this.textBoxSideDirection.Text = "000";
            this.textBoxSideDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(3, 262);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 30);
            this.label13.TabIndex = 7;
            this.label13.Text = "Wind Direction (°)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSideSpeed
            // 
            this.textBoxSideSpeed.AutoSize = true;
            this.textBoxSideSpeed.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxSideSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSideSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSideSpeed.ForeColor = System.Drawing.Color.White;
            this.textBoxSideSpeed.Location = new System.Drawing.Point(3, 171);
            this.textBoxSideSpeed.Name = "textBoxSideSpeed";
            this.textBoxSideSpeed.Size = new System.Drawing.Size(113, 91);
            this.textBoxSideSpeed.TabIndex = 6;
            this.textBoxSideSpeed.Text = "000";
            this.textBoxSideSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(3, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 30);
            this.label11.TabIndex = 5;
            this.label11.Text = "Wind Speed (m/s)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSideScore
            // 
            this.textBoxSideScore.AutoSize = true;
            this.textBoxSideScore.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxSideScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSideScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSideScore.ForeColor = System.Drawing.Color.White;
            this.textBoxSideScore.Location = new System.Drawing.Point(3, 50);
            this.textBoxSideScore.Name = "textBoxSideScore";
            this.textBoxSideScore.Size = new System.Drawing.Size(113, 91);
            this.textBoxSideScore.TabIndex = 4;
            this.textBoxSideScore.Text = "--";
            this.textBoxSideScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 30);
            this.label9.TabIndex = 3;
            this.label9.Text = "Score";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxWindLog
            // 
            this.listBoxWindLog.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listBoxWindLog.BackColor = System.Drawing.Color.Black;
            this.listBoxWindLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxWindLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Time,
            this.Speed,
            this.Direction});
            this.listBoxWindLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxWindLog.ForeColor = System.Drawing.Color.White;
            this.listBoxWindLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewItem1.StateImageIndex = 0;
            this.listBoxWindLog.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listBoxWindLog.LabelWrap = false;
            this.listBoxWindLog.Location = new System.Drawing.Point(3, 386);
            this.listBoxWindLog.MultiSelect = false;
            this.listBoxWindLog.Name = "listBoxWindLog";
            this.listBoxWindLog.Size = new System.Drawing.Size(113, 242);
            this.listBoxWindLog.TabIndex = 9;
            this.listBoxWindLog.UseCompatibleStateImageBehavior = false;
            this.listBoxWindLog.View = System.Windows.Forms.View.Details;
            this.listBoxWindLog.Visible = false;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 50;
            // 
            // Speed
            // 
            this.Speed.Text = "Speed";
            this.Speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Speed.Width = 30;
            // 
            // Direction
            // 
            this.Direction.Text = "Direction";
            this.Direction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Direction.Width = 30;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(4, 640);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 3;
            // 
            // chartWind
            // 
            chartArea1.AxisX.Interval = 30D;
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.ScaleView.Size = 3600D;
            chartArea1.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.Interval = 0.5D;
            chartArea1.AxisY.Maximum = 10D;
            chartArea1.CursorX.AutoScroll = false;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chartWind.ChartAreas.Add(chartArea1);
            this.chartWind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartWind.Location = new System.Drawing.Point(3, 210);
            this.chartWind.Name = "chartWind";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "SeriesWindDirection";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartWind.Series.Add(series1);
            this.chartWind.Size = new System.Drawing.Size(1099, 360);
            this.chartWind.TabIndex = 0;
            this.chartWind.Text = "chart1";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 4;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel8.Controls.Add(this.trackBarWindZoom, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.numericUpDownChartZoom, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 576);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(1099, 26);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // trackBarWindZoom
            // 
            this.trackBarWindZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarWindZoom.Location = new System.Drawing.Point(3, 3);
            this.trackBarWindZoom.Maximum = 120;
            this.trackBarWindZoom.Minimum = 2;
            this.trackBarWindZoom.Name = "trackBarWindZoom";
            this.trackBarWindZoom.Size = new System.Drawing.Size(213, 20);
            this.trackBarWindZoom.TabIndex = 2;
            this.trackBarWindZoom.TickFrequency = 5;
            this.trackBarWindZoom.Value = 60;
            this.trackBarWindZoom.Scroll += new System.EventHandler(this.trackBarWindZoom_Scroll);
            // 
            // numericUpDownChartZoom
            // 
            this.numericUpDownChartZoom.Dock = System.Windows.Forms.DockStyle.Left;
            this.numericUpDownChartZoom.Location = new System.Drawing.Point(222, 3);
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
            this.numericUpDownChartZoom.Size = new System.Drawing.Size(103, 20);
            this.numericUpDownChartZoom.TabIndex = 3;
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
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(331, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = ":Minutes Shown";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1244, 659);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Competition Manager System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabWind.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tabEventLoad.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventBrowserEventGrid)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartWind)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWindZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChartZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabWind;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonCompetition;
        private System.Windows.Forms.Timer timerScoreTimer;
        private System.Windows.Forms.TabPage tabEventLoad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button EventBrowserButtonLoad;
        private System.Windows.Forms.Button EventBrowserButtonCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ListBox EventBrowserListBoxCompetitors;
        private System.Windows.Forms.Label EventBrowserLabelCompetitors;
        private System.Windows.Forms.DataGridView EventBrowserEventGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEventID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEventDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label textBoxSideScore;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label textBoxSideSpeed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label textBoxSideDirection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listBoxWindLog;
        private System.Windows.Forms.ColumnHeader Speed;
        private System.Windows.Forms.ColumnHeader Direction;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.Button buttonModifyCompetitorData;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonMainSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWind;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TrackBar trackBarWindZoom;
        private System.Windows.Forms.NumericUpDown numericUpDownChartZoom;
        private System.Windows.Forms.Label label1;

    }
}

