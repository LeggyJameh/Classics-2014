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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewLockedLeaderboard = new System.Windows.Forms.DataGridView();
            this.ColumnHiddenUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompetitorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCompetitorNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompetitorTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainerLeaderboard = new System.Windows.Forms.SplitContainer();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.buttonDeselect = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonSortAsTeam = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonSortAsSingles = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAutoUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonUndock = new System.Windows.Forms.Button();
            this.groupBoxPrint = new System.Windows.Forms.GroupBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLockedLeaderboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeaderboard)).BeginInit();
            this.splitContainerLeaderboard.Panel1.SuspendLayout();
            this.splitContainerLeaderboard.Panel2.SuspendLayout();
            this.splitContainerLeaderboard.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewLockedLeaderboard
            // 
            this.dataGridViewLockedLeaderboard.AllowUserToAddRows = false;
            this.dataGridViewLockedLeaderboard.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Info;
            this.dataGridViewLockedLeaderboard.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLockedLeaderboard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewLockedLeaderboard.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewLockedLeaderboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLockedLeaderboard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnHiddenUID,
            this.ColumnPosition,
            this.ColumnCompetitorName,
            this.columnCompetitorNationality,
            this.ColumnCompetitorTeam});
            this.dataGridViewLockedLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLockedLeaderboard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewLockedLeaderboard.Enabled = false;
            this.dataGridViewLockedLeaderboard.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLockedLeaderboard.Name = "dataGridViewLockedLeaderboard";
            this.dataGridViewLockedLeaderboard.ReadOnly = true;
            this.dataGridViewLockedLeaderboard.Size = new System.Drawing.Size(783, 524);
            this.dataGridViewLockedLeaderboard.TabIndex = 1;
            // 
            // ColumnHiddenUID
            // 
            this.ColumnHiddenUID.HeaderText = "This should be invisible";
            this.ColumnHiddenUID.Name = "ColumnHiddenUID";
            this.ColumnHiddenUID.ReadOnly = true;
            this.ColumnHiddenUID.Visible = false;
            // 
            // ColumnPosition
            // 
            this.ColumnPosition.HeaderText = "Position";
            this.ColumnPosition.Name = "ColumnPosition";
            this.ColumnPosition.ReadOnly = true;
            this.ColumnPosition.Width = 69;
            // 
            // ColumnCompetitorName
            // 
            this.ColumnCompetitorName.HeaderText = "Competitor Name";
            this.ColumnCompetitorName.Name = "ColumnCompetitorName";
            this.ColumnCompetitorName.ReadOnly = true;
            this.ColumnCompetitorName.Width = 104;
            // 
            // columnCompetitorNationality
            // 
            this.columnCompetitorNationality.HeaderText = "Competitor Nationality";
            this.columnCompetitorNationality.Name = "columnCompetitorNationality";
            this.columnCompetitorNationality.ReadOnly = true;
            this.columnCompetitorNationality.Width = 123;
            // 
            // ColumnCompetitorTeam
            // 
            this.ColumnCompetitorTeam.HeaderText = "Competitor Team";
            this.ColumnCompetitorTeam.Name = "ColumnCompetitorTeam";
            this.ColumnCompetitorTeam.ReadOnly = true;
            this.ColumnCompetitorTeam.Width = 103;
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
            this.splitContainerLeaderboard.Panel2.Controls.Add(this.groupBox7);
            this.splitContainerLeaderboard.Panel2.Controls.Add(this.groupBox6);
            this.splitContainerLeaderboard.Panel2.Controls.Add(this.groupBox5);
            this.splitContainerLeaderboard.Panel2.Controls.Add(this.groupBox4);
            this.splitContainerLeaderboard.Panel2.Controls.Add(this.groupBox3);
            this.splitContainerLeaderboard.Panel2.Controls.Add(this.groupBox2);
            this.splitContainerLeaderboard.Panel2.Controls.Add(this.groupBox1);
            this.splitContainerLeaderboard.Panel2.Controls.Add(this.groupBoxPrint);
            this.splitContainerLeaderboard.Size = new System.Drawing.Size(875, 524);
            this.splitContainerLeaderboard.SplitterDistance = 783;
            this.splitContainerLeaderboard.TabIndex = 2;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.buttonDeselect);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(0, 464);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(88, 71);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            // 
            // buttonDeselect
            // 
            this.buttonDeselect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeselect.Location = new System.Drawing.Point(3, 16);
            this.buttonDeselect.Name = "buttonDeselect";
            this.buttonDeselect.Size = new System.Drawing.Size(82, 52);
            this.buttonDeselect.TabIndex = 1;
            this.buttonDeselect.Text = "Deselect Grid";
            this.buttonDeselect.UseVisualStyleBackColor = true;
            this.buttonDeselect.Click += new System.EventHandler(this.buttonDeselect_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonSave);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(0, 393);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(88, 71);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Location = new System.Drawing.Point(3, 16);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(82, 52);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonSortAsTeam);
            this.groupBox5.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 322);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(88, 71);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            // 
            // buttonSortAsTeam
            // 
            this.buttonSortAsTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSortAsTeam.Location = new System.Drawing.Point(3, 16);
            this.buttonSortAsTeam.Name = "buttonSortAsTeam";
            this.buttonSortAsTeam.Size = new System.Drawing.Size(82, 52);
            this.buttonSortAsTeam.TabIndex = 1;
            this.buttonSortAsTeam.Text = "Sort as Team";
            this.buttonSortAsTeam.UseVisualStyleBackColor = true;
            this.buttonSortAsTeam.Visible = false;
            this.buttonSortAsTeam.Click += new System.EventHandler(this.buttonSortAsTeam_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonSortAsSingles);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 251);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(88, 71);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // buttonSortAsSingles
            // 
            this.buttonSortAsSingles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSortAsSingles.Location = new System.Drawing.Point(3, 16);
            this.buttonSortAsSingles.Name = "buttonSortAsSingles";
            this.buttonSortAsSingles.Size = new System.Drawing.Size(82, 52);
            this.buttonSortAsSingles.TabIndex = 1;
            this.buttonSortAsSingles.Text = "Sort as Singles";
            this.buttonSortAsSingles.UseVisualStyleBackColor = true;
            this.buttonSortAsSingles.Visible = false;
            this.buttonSortAsSingles.Click += new System.EventHandler(this.buttonSortAsSingles_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonClose);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 180);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(88, 71);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClose.Location = new System.Drawing.Point(3, 16);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(82, 52);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
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
            this.buttonAutoUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAutoUpdate.ForeColor = System.Drawing.Color.Crimson;
            this.buttonAutoUpdate.Location = new System.Drawing.Point(3, 16);
            this.buttonAutoUpdate.Name = "buttonAutoUpdate";
            this.buttonAutoUpdate.Size = new System.Drawing.Size(82, 41);
            this.buttonAutoUpdate.TabIndex = 1;
            this.buttonAutoUpdate.Text = "AutoUpdate";
            this.buttonAutoUpdate.UseVisualStyleBackColor = true;
            this.buttonAutoUpdate.Click += new System.EventHandler(this.buttonAutoUpdate_Click);
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
            this.buttonUndock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUndock.Location = new System.Drawing.Point(3, 16);
            this.buttonUndock.Name = "buttonUndock";
            this.buttonUndock.Size = new System.Drawing.Size(82, 41);
            this.buttonUndock.TabIndex = 1;
            this.buttonUndock.Text = "Undock";
            this.buttonUndock.UseVisualStyleBackColor = true;
            this.buttonUndock.Click += new System.EventHandler(this.buttonUndock_Click);
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
            this.buttonPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrint.Location = new System.Drawing.Point(3, 16);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(82, 41);
            this.buttonPrint.TabIndex = 0;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
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
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompetitorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCompetitorNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompetitorTeam;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonSortAsSingles;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonSortAsTeam;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button buttonDeselect;
    }
}
