namespace Classics_2014.Accuracy.Reports
{
    partial class Leaderboard
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
            this.dataGridViewLockedLeaderboard = new System.Windows.Forms.DataGridView();
            this.splitContainerLeaderboard = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAutoUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonUndock = new System.Windows.Forms.Button();
            this.groupBoxPrint = new System.Windows.Forms.GroupBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.ColumnHiddenUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompetitorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCompetitorNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompetitorTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLockedLeaderboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeaderboard)).BeginInit();
            this.splitContainerLeaderboard.Panel1.SuspendLayout();
            this.splitContainerLeaderboard.Panel2.SuspendLayout();
            this.splitContainerLeaderboard.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewLockedLeaderboard
            // 
            this.dataGridViewLockedLeaderboard.AllowUserToAddRows = false;
            this.dataGridViewLockedLeaderboard.AllowUserToDeleteRows = false;
            this.dataGridViewLockedLeaderboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLockedLeaderboard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnHiddenUID,
            this.ColumnCompetitorName,
            this.columnCompetitorNationality,
            this.ColumnCompetitorTeam});
            this.dataGridViewLockedLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLockedLeaderboard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewLockedLeaderboard.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLockedLeaderboard.Name = "dataGridViewLockedLeaderboard";
            this.dataGridViewLockedLeaderboard.ReadOnly = true;
            this.dataGridViewLockedLeaderboard.Size = new System.Drawing.Size(783, 524);
            this.dataGridViewLockedLeaderboard.TabIndex = 1;
            // 
            // splitContainerLeaderboard
            // 
            this.splitContainerLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLeaderboard.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLeaderboard.Name = "splitContainerLeaderboard";
            // 
            // splitContainerLeaderboard.Panel1
            // 
            this.splitContainerLeaderboard.Panel1.Controls.Add(this.dataGridViewLockedLeaderboard);
            // 
            // splitContainerLeaderboard.Panel2
            // 
            this.splitContainerLeaderboard.Panel2.Controls.Add(this.groupBox2);
            this.splitContainerLeaderboard.Panel2.Controls.Add(this.groupBox1);
            this.splitContainerLeaderboard.Panel2.Controls.Add(this.groupBoxPrint);
            this.splitContainerLeaderboard.Size = new System.Drawing.Size(875, 524);
            this.splitContainerLeaderboard.SplitterDistance = 783;
            this.splitContainerLeaderboard.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonAutoUpdate);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(88, 60);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // buttonAutoUpdate
            // 
            this.buttonAutoUpdate.ForeColor = System.Drawing.Color.Green;
            this.buttonAutoUpdate.Location = new System.Drawing.Point(1, 5);
            this.buttonAutoUpdate.Name = "buttonAutoUpdate";
            this.buttonAutoUpdate.Size = new System.Drawing.Size(86, 51);
            this.buttonAutoUpdate.TabIndex = 1;
            this.buttonAutoUpdate.Text = "AutoUpdate";
            this.buttonAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonUndock);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(88, 60);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // buttonUndock
            // 
            this.buttonUndock.Location = new System.Drawing.Point(1, 5);
            this.buttonUndock.Name = "buttonUndock";
            this.buttonUndock.Size = new System.Drawing.Size(86, 51);
            this.buttonUndock.TabIndex = 1;
            this.buttonUndock.Text = "Undock";
            this.buttonUndock.UseVisualStyleBackColor = true;
            // 
            // groupBoxPrint
            // 
            this.groupBoxPrint.Controls.Add(this.buttonPrint);
            this.groupBoxPrint.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxPrint.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPrint.Name = "groupBoxPrint";
            this.groupBoxPrint.Size = new System.Drawing.Size(88, 60);
            this.groupBoxPrint.TabIndex = 0;
            this.groupBoxPrint.TabStop = false;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(2, 3);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(86, 51);
            this.buttonPrint.TabIndex = 0;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            // 
            // ColumnHiddenUID
            // 
            this.ColumnHiddenUID.HeaderText = "This should be invisible";
            this.ColumnHiddenUID.Name = "ColumnHiddenUID";
            this.ColumnHiddenUID.ReadOnly = true;
            this.ColumnHiddenUID.Visible = false;
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
            // Leaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerLeaderboard);
            this.Name = "Leaderboard";
            this.Size = new System.Drawing.Size(875, 524);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLockedLeaderboard)).EndInit();
            this.splitContainerLeaderboard.Panel1.ResumeLayout(false);
            this.splitContainerLeaderboard.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeaderboard)).EndInit();
            this.splitContainerLeaderboard.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxPrint.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLockedLeaderboard;
        private System.Windows.Forms.SplitContainer splitContainerLeaderboard;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonAutoUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonUndock;
        private System.Windows.Forms.GroupBox groupBoxPrint;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHiddenUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompetitorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCompetitorNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompetitorTeam;
    }
}
