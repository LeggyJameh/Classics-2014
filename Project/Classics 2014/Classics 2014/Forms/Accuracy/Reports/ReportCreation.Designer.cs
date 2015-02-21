namespace CMS.Accuracy.Reports
{
    partial class ReportCreation
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
            this.textBoxReportName = new System.Windows.Forms.TextBox();
            this.buttonCreateReport = new System.Windows.Forms.Button();
            this.listBoxEventList = new System.Windows.Forms.ListBox();
            this.radioButtonNew = new System.Windows.Forms.RadioButton();
            this.radioButtonExist = new System.Windows.Forms.RadioButton();
            this.dataGridLeaderboard = new System.Windows.Forms.DataGridView();
            this.ColumnUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompetitorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCompetitorNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompetitorTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLeaderboard)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxReportName
            // 
            this.textBoxReportName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxReportName, 2);
            this.textBoxReportName.Location = new System.Drawing.Point(3, 635);
            this.textBoxReportName.Name = "textBoxReportName";
            this.textBoxReportName.Size = new System.Drawing.Size(250, 20);
            this.textBoxReportName.TabIndex = 0;
            this.textBoxReportName.Text = "Insert Report Name";
            this.textBoxReportName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxReportName.Enter += new System.EventHandler(this.textBoxReportName_Enter);
            this.textBoxReportName.Leave += new System.EventHandler(this.textBoxReportName_Leave);
            // 
            // buttonCreateReport
            // 
            this.buttonCreateReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.buttonCreateReport, 2);
            this.buttonCreateReport.Location = new System.Drawing.Point(3, 693);
            this.buttonCreateReport.Name = "buttonCreateReport";
            this.buttonCreateReport.Size = new System.Drawing.Size(250, 23);
            this.buttonCreateReport.TabIndex = 0;
            this.buttonCreateReport.Text = "Create Report";
            this.buttonCreateReport.UseVisualStyleBackColor = true;
            this.buttonCreateReport.Click += new System.EventHandler(this.buttonCreateReport_Click);
            // 
            // listBoxEventList
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.listBoxEventList, 2);
            this.listBoxEventList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEventList.FormattingEnabled = true;
            this.listBoxEventList.Location = new System.Drawing.Point(3, 63);
            this.listBoxEventList.Name = "listBoxEventList";
            this.listBoxEventList.Size = new System.Drawing.Size(250, 564);
            this.listBoxEventList.TabIndex = 0;
            this.listBoxEventList.SelectedIndexChanged += new System.EventHandler(this.listBoxEventList_SelectedIndexChanged);
            // 
            // radioButtonNew
            // 
            this.radioButtonNew.AutoSize = true;
            this.radioButtonNew.Checked = true;
            this.radioButtonNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonNew.Location = new System.Drawing.Point(131, 33);
            this.radioButtonNew.Name = "radioButtonNew";
            this.radioButtonNew.Size = new System.Drawing.Size(122, 24);
            this.radioButtonNew.TabIndex = 0;
            this.radioButtonNew.TabStop = true;
            this.radioButtonNew.Text = "New";
            this.radioButtonNew.UseVisualStyleBackColor = true;
            this.radioButtonNew.CheckedChanged += new System.EventHandler(this.radioButtonNew_CheckedChanged);
            // 
            // radioButtonExist
            // 
            this.radioButtonExist.AutoSize = true;
            this.radioButtonExist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonExist.Location = new System.Drawing.Point(3, 33);
            this.radioButtonExist.Name = "radioButtonExist";
            this.radioButtonExist.Size = new System.Drawing.Size(122, 24);
            this.radioButtonExist.TabIndex = 1;
            this.radioButtonExist.TabStop = true;
            this.radioButtonExist.Text = "Existing";
            this.radioButtonExist.UseVisualStyleBackColor = true;
            this.radioButtonExist.CheckedChanged += new System.EventHandler(this.radioButtonExist_CheckedChanged);
            // 
            // dataGridLeaderboard
            // 
            this.dataGridLeaderboard.AllowUserToAddRows = false;
            this.dataGridLeaderboard.AllowUserToDeleteRows = false;
            this.dataGridLeaderboard.AllowUserToResizeColumns = false;
            this.dataGridLeaderboard.AllowUserToResizeRows = false;
            this.dataGridLeaderboard.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridLeaderboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridLeaderboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLeaderboard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnUID,
            this.ColumnCompetitorName,
            this.columnCompetitorNationality,
            this.ColumnCompetitorTeam});
            this.dataGridLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridLeaderboard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridLeaderboard.Location = new System.Drawing.Point(259, 63);
            this.dataGridLeaderboard.Name = "dataGridLeaderboard";
            this.dataGridLeaderboard.ReadOnly = true;
            this.dataGridLeaderboard.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridLeaderboard, 4);
            this.dataGridLeaderboard.Size = new System.Drawing.Size(1018, 654);
            this.dataGridLeaderboard.TabIndex = 2;
            this.dataGridLeaderboard.SelectionChanged += new System.EventHandler(this.dataGridViewLockedLeaderboard_SelectionChanged);
            // 
            // ColumnUID
            // 
            this.ColumnUID.HeaderText = "HiddenUID";
            this.ColumnUID.Name = "ColumnUID";
            this.ColumnUID.ReadOnly = true;
            this.ColumnUID.Visible = false;
            // 
            // ColumnCompetitorName
            // 
            this.ColumnCompetitorName.HeaderText = "Competitor Name";
            this.ColumnCompetitorName.Name = "ColumnCompetitorName";
            this.ColumnCompetitorName.ReadOnly = true;
            // 
            // columnCompetitorNationality
            // 
            this.columnCompetitorNationality.HeaderText = "Competitor Nationality";
            this.columnCompetitorNationality.Name = "columnCompetitorNationality";
            this.columnCompetitorNationality.ReadOnly = true;
            // 
            // ColumnCompetitorTeam
            // 
            this.ColumnCompetitorTeam.HeaderText = "Competitor Team";
            this.ColumnCompetitorTeam.Name = "ColumnCompetitorTeam";
            this.ColumnCompetitorTeam.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.listBoxEventList, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxReportName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonExist, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonCreateReport, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonNew, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridLeaderboard, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1274, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Reports";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReportCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReportCreation";
            this.Size = new System.Drawing.Size(1280, 720);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLeaderboard)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridLeaderboard;
        private System.Windows.Forms.ListBox listBoxEventList;
        private System.Windows.Forms.RadioButton radioButtonNew;
        private System.Windows.Forms.RadioButton radioButtonExist;
        private System.Windows.Forms.TextBox textBoxReportName;
        private System.Windows.Forms.Button buttonCreateReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompetitorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCompetitorNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompetitorTeam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
    }
}
