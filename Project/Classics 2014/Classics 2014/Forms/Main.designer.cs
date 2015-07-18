namespace CMS
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "T",
            "S",
            "D"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxSideDirection = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxSideSpeed = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.listBoxWindLog = new System.Windows.Forms.ListView();
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Speed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Direction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelError = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabWind);
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1140, 744);
            this.tabControl.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.AutoScroll = true;
            this.tabMain.Controls.Add(this.tableLayoutPanel9);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1132, 718);
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
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.76484F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.76484F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.76484F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.76484F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.76367F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.17696F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1126, 712);
            this.tableLayoutPanel9.TabIndex = 5;
            // 
            // buttonCompetition
            // 
            this.buttonCompetition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCompetition.Location = new System.Drawing.Point(378, 203);
            this.buttonCompetition.Name = "buttonCompetition";
            this.buttonCompetition.Size = new System.Drawing.Size(369, 44);
            this.buttonCompetition.TabIndex = 0;
            this.buttonCompetition.Text = "Start New Event";
            this.buttonCompetition.UseVisualStyleBackColor = true;
            this.buttonCompetition.Click += new System.EventHandler(this.buttonCompetition_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::CMS.Properties.Resources.Logo;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(378, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(369, 194);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoad.Location = new System.Drawing.Point(378, 277);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(369, 44);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load Previous Events";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Location = new System.Drawing.Point(378, 573);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(369, 44);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHelp.Location = new System.Drawing.Point(378, 425);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(369, 44);
            this.buttonHelp.TabIndex = 3;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            // 
            // buttonModifyCompetitorData
            // 
            this.buttonModifyCompetitorData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonModifyCompetitorData.Location = new System.Drawing.Point(378, 351);
            this.buttonModifyCompetitorData.Name = "buttonModifyCompetitorData";
            this.buttonModifyCompetitorData.Size = new System.Drawing.Size(369, 44);
            this.buttonModifyCompetitorData.TabIndex = 6;
            this.buttonModifyCompetitorData.Text = "Modify Competitors";
            this.buttonModifyCompetitorData.UseVisualStyleBackColor = true;
            this.buttonModifyCompetitorData.Click += new System.EventHandler(this.buttonModifyCompetitorData_Click);
            // 
            // buttonMainSettings
            // 
            this.buttonMainSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMainSettings.Location = new System.Drawing.Point(378, 499);
            this.buttonMainSettings.Name = "buttonMainSettings";
            this.buttonMainSettings.Size = new System.Drawing.Size(369, 44);
            this.buttonMainSettings.TabIndex = 7;
            this.buttonMainSettings.Text = "Settings";
            this.buttonMainSettings.UseVisualStyleBackColor = true;
            this.buttonMainSettings.Click += new System.EventHandler(this.buttonMainSettings_Click);
            // 
            // tabWind
            // 
            this.tabWind.Location = new System.Drawing.Point(4, 22);
            this.tabWind.Name = "tabWind";
            this.tabWind.Size = new System.Drawing.Size(1132, 718);
            this.tabWind.TabIndex = 1;
            this.tabWind.Text = "Anemometer Control";
            this.tabWind.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 750);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1274, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1274, 750);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.textBoxSideDirection, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.label13, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.textBoxSideSpeed, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.listBoxWindLog, 0, 4);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(1149, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 5;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(121, 744);
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
            this.textBoxSideDirection.Location = new System.Drawing.Point(3, 185);
            this.textBoxSideDirection.Name = "textBoxSideDirection";
            this.textBoxSideDirection.Size = new System.Drawing.Size(115, 111);
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
            this.label13.Location = new System.Drawing.Point(3, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 37);
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
            this.textBoxSideSpeed.Location = new System.Drawing.Point(3, 37);
            this.textBoxSideSpeed.Name = "textBoxSideSpeed";
            this.textBoxSideSpeed.Size = new System.Drawing.Size(115, 111);
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
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 37);
            this.label11.TabIndex = 5;
            this.label11.Text = "Wind Speed (m/s)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.listBoxWindLog.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listBoxWindLog.LabelWrap = false;
            this.listBoxWindLog.Location = new System.Drawing.Point(3, 299);
            this.listBoxWindLog.MultiSelect = false;
            this.listBoxWindLog.Name = "listBoxWindLog";
            this.listBoxWindLog.Size = new System.Drawing.Size(115, 442);
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::CMS.Properties.Resources.MenuBackground;
            this.ClientSize = new System.Drawing.Size(1274, 772);
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
            this.Text = "Competition Manager System v0.5 Alpha";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
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

    }
}

