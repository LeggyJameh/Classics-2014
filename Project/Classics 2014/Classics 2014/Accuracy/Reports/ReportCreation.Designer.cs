namespace Classics_2014.Accuracy.Reports
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewLockedLeaderboard = new System.Windows.Forms.DataGridView();
            this.ColumnCompetitorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCompetitorNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompetitorTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxRadioCreateExist = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxCreateButton = new System.Windows.Forms.GroupBox();
            this.radioButtonNew = new System.Windows.Forms.RadioButton();
            this.radioButtonExist = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listBoxEventList = new System.Windows.Forms.ListBox();
            this.textBoxEventName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLockedLeaderboard)).BeginInit();
            this.groupBoxRadioCreateExist.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxCreateButton.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxCreateButton);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxRadioCreateExist);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewLockedLeaderboard);
            this.splitContainer1.Size = new System.Drawing.Size(857, 561);
            this.splitContainer1.SplitterDistance = 154;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridViewLockedLeaderboard
            // 
            this.dataGridViewLockedLeaderboard.AllowUserToAddRows = false;
            this.dataGridViewLockedLeaderboard.AllowUserToDeleteRows = false;
            this.dataGridViewLockedLeaderboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLockedLeaderboard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCompetitorName,
            this.columnCompetitorNationality,
            this.ColumnCompetitorTeam});
            this.dataGridViewLockedLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLockedLeaderboard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewLockedLeaderboard.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLockedLeaderboard.Name = "dataGridViewLockedLeaderboard";
            this.dataGridViewLockedLeaderboard.ReadOnly = true;
            this.dataGridViewLockedLeaderboard.Size = new System.Drawing.Size(699, 561);
            this.dataGridViewLockedLeaderboard.TabIndex = 2;
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
            // groupBoxRadioCreateExist
            // 
            this.groupBoxRadioCreateExist.Controls.Add(this.groupBox5);
            this.groupBoxRadioCreateExist.Controls.Add(this.groupBox4);
            this.groupBoxRadioCreateExist.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxRadioCreateExist.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRadioCreateExist.Name = "groupBoxRadioCreateExist";
            this.groupBoxRadioCreateExist.Size = new System.Drawing.Size(154, 65);
            this.groupBoxRadioCreateExist.TabIndex = 0;
            this.groupBoxRadioCreateExist.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxEventList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 496);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 496);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(154, 65);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // groupBoxCreateButton
            // 
            this.groupBoxCreateButton.Controls.Add(this.textBoxEventName);
            this.groupBoxCreateButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxCreateButton.Location = new System.Drawing.Point(0, 431);
            this.groupBoxCreateButton.Name = "groupBoxCreateButton";
            this.groupBoxCreateButton.Size = new System.Drawing.Size(154, 65);
            this.groupBoxCreateButton.TabIndex = 3;
            this.groupBoxCreateButton.TabStop = false;
            // 
            // radioButtonNew
            // 
            this.radioButtonNew.AutoSize = true;
            this.radioButtonNew.Checked = true;
            this.radioButtonNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonNew.Location = new System.Drawing.Point(3, 16);
            this.radioButtonNew.Name = "radioButtonNew";
            this.radioButtonNew.Size = new System.Drawing.Size(67, 27);
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
            this.radioButtonExist.Location = new System.Drawing.Point(3, 16);
            this.radioButtonExist.Name = "radioButtonExist";
            this.radioButtonExist.Size = new System.Drawing.Size(69, 27);
            this.radioButtonExist.TabIndex = 1;
            this.radioButtonExist.TabStop = true;
            this.radioButtonExist.Text = "Existing";
            this.radioButtonExist.UseVisualStyleBackColor = true;
            this.radioButtonExist.CheckedChanged += new System.EventHandler(this.radioButtonExist_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonExist);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(75, 46);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButtonNew);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(78, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(73, 46);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            // 
            // listBoxEventList
            // 
            this.listBoxEventList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEventList.FormattingEnabled = true;
            this.listBoxEventList.Items.AddRange(new object[] {
            "Leaderboard",
            "Team",
            "Competitor",
            "Landing"});
            this.listBoxEventList.Location = new System.Drawing.Point(3, 16);
            this.listBoxEventList.Name = "listBoxEventList";
            this.listBoxEventList.Size = new System.Drawing.Size(148, 477);
            this.listBoxEventList.TabIndex = 0;
            this.listBoxEventList.SelectedIndexChanged += new System.EventHandler(this.listBoxEventList_SelectedIndexChanged);
            // 
            // textBoxEventName
            // 
            this.textBoxEventName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEventName.Location = new System.Drawing.Point(3, 16);
            this.textBoxEventName.Name = "textBoxEventName";
            this.textBoxEventName.Size = new System.Drawing.Size(148, 20);
            this.textBoxEventName.TabIndex = 0;
            this.textBoxEventName.Text = "Insert Report Name";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create Report";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ReportCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ReportCreation";
            this.Size = new System.Drawing.Size(857, 561);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLockedLeaderboard)).EndInit();
            this.groupBoxRadioCreateExist.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBoxCreateButton.ResumeLayout(false);
            this.groupBoxCreateButton.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewLockedLeaderboard;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompetitorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCompetitorNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompetitorTeam;
        private System.Windows.Forms.GroupBox groupBoxCreateButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxEventList;
        private System.Windows.Forms.GroupBox groupBoxRadioCreateExist;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButtonNew;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButtonExist;
        private System.Windows.Forms.TextBox textBoxEventName;
        private System.Windows.Forms.Button button1;
    }
}
