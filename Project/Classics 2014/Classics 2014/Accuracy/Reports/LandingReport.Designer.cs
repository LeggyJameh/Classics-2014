namespace Classics_2014.Accuracy.Reports
{
    partial class LandingReport
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxReport = new System.Windows.Forms.GroupBox();
            this.listBoxWindLog = new System.Windows.Forms.ListView();
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Speed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Direction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxPrint = new System.Windows.Forms.GroupBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.groupBoxClose = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxReport.SuspendLayout();
            this.groupBoxPrint.SuspendLayout();
            this.groupBoxClose.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxReport);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox6);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxPrint);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxClose);
            this.splitContainer1.Size = new System.Drawing.Size(585, 405);
            this.splitContainer1.SplitterDistance = 499;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxReport
            // 
            this.groupBoxReport.Controls.Add(this.listBoxWindLog);
            this.groupBoxReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxReport.Location = new System.Drawing.Point(0, 0);
            this.groupBoxReport.Name = "groupBoxReport";
            this.groupBoxReport.Size = new System.Drawing.Size(499, 405);
            this.groupBoxReport.TabIndex = 0;
            this.groupBoxReport.TabStop = false;
            this.groupBoxReport.Text = "ReportName";
            // 
            // listBoxWindLog
            // 
            this.listBoxWindLog.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listBoxWindLog.BackColor = System.Drawing.Color.White;
            this.listBoxWindLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxWindLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Time,
            this.Speed,
            this.Direction,
            this.columnScore});
            this.listBoxWindLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxWindLog.ForeColor = System.Drawing.Color.Black;
            this.listBoxWindLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listBoxWindLog.LabelWrap = false;
            this.listBoxWindLog.Location = new System.Drawing.Point(3, 18);
            this.listBoxWindLog.MultiSelect = false;
            this.listBoxWindLog.Name = "listBoxWindLog";
            this.listBoxWindLog.Size = new System.Drawing.Size(493, 384);
            this.listBoxWindLog.TabIndex = 10;
            this.listBoxWindLog.UseCompatibleStateImageBehavior = false;
            this.listBoxWindLog.View = System.Windows.Forms.View.Details;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 131;
            // 
            // Speed
            // 
            this.Speed.Text = "Speed";
            this.Speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Speed.Width = 178;
            // 
            // Direction
            // 
            this.Direction.Text = "Direction";
            this.Direction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Direction.Width = 115;
            // 
            // columnScore
            // 
            this.columnScore.Text = "Score";
            // 
            // groupBoxPrint
            // 
            this.groupBoxPrint.Controls.Add(this.buttonPrint);
            this.groupBoxPrint.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxPrint.Location = new System.Drawing.Point(0, 43);
            this.groupBoxPrint.Name = "groupBoxPrint";
            this.groupBoxPrint.Size = new System.Drawing.Size(82, 47);
            this.groupBoxPrint.TabIndex = 1;
            this.groupBoxPrint.TabStop = false;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrint.Location = new System.Drawing.Point(3, 16);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(76, 28);
            this.buttonPrint.TabIndex = 2;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // groupBoxClose
            // 
            this.groupBoxClose.Controls.Add(this.buttonClose);
            this.groupBoxClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxClose.Location = new System.Drawing.Point(0, 0);
            this.groupBoxClose.Name = "groupBoxClose";
            this.groupBoxClose.Size = new System.Drawing.Size(82, 43);
            this.groupBoxClose.TabIndex = 0;
            this.groupBoxClose.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClose.Location = new System.Drawing.Point(3, 16);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(76, 24);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // printDialog
            // 
            this.printDialog.AllowPrintToFile = false;
            this.printDialog.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonSave);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(0, 90);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(82, 46);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Location = new System.Drawing.Point(3, 16);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(76, 27);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // LandingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "LandingReport";
            this.Size = new System.Drawing.Size(585, 405);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxReport.ResumeLayout(false);
            this.groupBoxPrint.ResumeLayout(false);
            this.groupBoxClose.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxPrint;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.GroupBox groupBoxClose;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBoxReport;
        private System.Windows.Forms.ListView listBoxWindLog;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader Speed;
        private System.Windows.Forms.ColumnHeader Direction;
        private System.Windows.Forms.ColumnHeader columnScore;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonSave;
    }
}
