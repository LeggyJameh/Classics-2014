namespace CMS.Accuracy
{
    partial class EventAccuracy
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
            this.tabControlEvent = new System.Windows.Forms.TabControl();
            this.tabPageScores = new System.Windows.Forms.TabPage();
            this.groupboxControllerListArea = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelName = new System.Windows.Forms.Label();
            this.dataGridViewScore = new System.Windows.Forms.DataGridView();
            this.ColumnUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIntermixTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRound1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonNextRound = new System.Windows.Forms.Button();
            this.buttonRenameCompetitor = new System.Windows.Forms.Button();
            this.buttonUnassignLanding = new System.Windows.Forms.Button();
            this.buttonEditLanding = new System.Windows.Forms.Button();
            this.buttonManualLanding = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonRejump = new System.Windows.Forms.Button();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.tabControlEvent.SuspendLayout();
            this.tabPageScores.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScore)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEvent
            // 
            this.tabControlEvent.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlEvent.Controls.Add(this.tabPageScores);
            this.tabControlEvent.Controls.Add(this.tabPageReports);
            this.tabControlEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEvent.Location = new System.Drawing.Point(0, 0);
            this.tabControlEvent.Name = "tabControlEvent";
            this.tabControlEvent.SelectedIndex = 0;
            this.tabControlEvent.Size = new System.Drawing.Size(1280, 800);
            this.tabControlEvent.TabIndex = 0;
            // 
            // tabPageScores
            // 
            this.tabPageScores.Controls.Add(this.groupboxControllerListArea);
            this.tabPageScores.Controls.Add(this.tableLayoutPanel1);
            this.tabPageScores.Location = new System.Drawing.Point(4, 4);
            this.tabPageScores.Name = "tabPageScores";
            this.tabPageScores.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScores.Size = new System.Drawing.Size(1272, 774);
            this.tabPageScores.TabIndex = 0;
            this.tabPageScores.Text = "Scores";
            this.tabPageScores.UseVisualStyleBackColor = true;
            // 
            // groupboxControllerListArea
            // 
            this.groupboxControllerListArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupboxControllerListArea.Location = new System.Drawing.Point(1069, 3);
            this.groupboxControllerListArea.Name = "groupboxControllerListArea";
            this.groupboxControllerListArea.Size = new System.Drawing.Size(200, 768);
            this.groupboxControllerListArea.TabIndex = 1;
            this.groupboxControllerListArea.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewScore, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1066, 768);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(3, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(1060, 50);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Accuracy Event --";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewScore
            // 
            this.dataGridViewScore.AllowUserToAddRows = false;
            this.dataGridViewScore.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewScore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewScore.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnUID,
            this.ColumnName,
            this.ColumnTeam,
            this.ColumnNationality,
            this.ColumnIntermixTeam,
            this.ColumnRound1});
            this.dataGridViewScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewScore.Location = new System.Drawing.Point(3, 53);
            this.dataGridViewScore.MultiSelect = false;
            this.dataGridViewScore.Name = "dataGridViewScore";
            this.dataGridViewScore.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewScore, 3);
            this.dataGridViewScore.RowTemplate.Height = 20;
            this.dataGridViewScore.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewScore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewScore.Size = new System.Drawing.Size(1060, 662);
            this.dataGridViewScore.TabIndex = 1;
            this.dataGridViewScore.SelectionChanged += new System.EventHandler(this.dataGridViewScore_SelectionChanged);
            // 
            // ColumnUID
            // 
            this.ColumnUID.HeaderText = "ID";
            this.ColumnUID.Name = "ColumnUID";
            this.ColumnUID.ReadOnly = true;
            this.ColumnUID.Visible = false;
            this.ColumnUID.Width = 24;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Competitor Name";
            this.ColumnName.MinimumWidth = 50;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 104;
            // 
            // ColumnTeam
            // 
            this.ColumnTeam.HeaderText = "Team";
            this.ColumnTeam.Name = "ColumnTeam";
            this.ColumnTeam.ReadOnly = true;
            this.ColumnTeam.Visible = false;
            this.ColumnTeam.Width = 59;
            // 
            // ColumnNationality
            // 
            this.ColumnNationality.HeaderText = "Nationality";
            this.ColumnNationality.Name = "ColumnNationality";
            this.ColumnNationality.ReadOnly = true;
            this.ColumnNationality.Width = 81;
            // 
            // ColumnIntermixTeam
            // 
            this.ColumnIntermixTeam.HeaderText = "Scoring Team";
            this.ColumnIntermixTeam.Name = "ColumnIntermixTeam";
            this.ColumnIntermixTeam.ReadOnly = true;
            this.ColumnIntermixTeam.Width = 90;
            // 
            // ColumnRound1
            // 
            this.ColumnRound1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnRound1.HeaderText = "Round 1";
            this.ColumnRound1.Name = "ColumnRound1";
            this.ColumnRound1.ReadOnly = true;
            this.ColumnRound1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnRound1.Width = 68;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 11;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonNextRound, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonRenameCompetitor, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonUnassignLanding, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonEditLanding, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonManualLanding, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonClose, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonConfirm, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonRejump, 9, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 721);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1060, 44);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // buttonNextRound
            // 
            this.buttonNextRound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNextRound.Location = new System.Drawing.Point(583, 3);
            this.buttonNextRound.Name = "buttonNextRound";
            this.buttonNextRound.Size = new System.Drawing.Size(94, 38);
            this.buttonNextRound.TabIndex = 1;
            this.buttonNextRound.Text = "Next Round";
            this.buttonNextRound.UseVisualStyleBackColor = true;
            this.buttonNextRound.Click += new System.EventHandler(this.buttonNextRound_Click);
            // 
            // buttonRenameCompetitor
            // 
            this.buttonRenameCompetitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRenameCompetitor.Location = new System.Drawing.Point(483, 3);
            this.buttonRenameCompetitor.Name = "buttonRenameCompetitor";
            this.buttonRenameCompetitor.Size = new System.Drawing.Size(94, 38);
            this.buttonRenameCompetitor.TabIndex = 4;
            this.buttonRenameCompetitor.Text = "Rename Competitor";
            this.buttonRenameCompetitor.UseVisualStyleBackColor = true;
            this.buttonRenameCompetitor.Click += new System.EventHandler(this.buttonRenameCompetitor_Click);
            // 
            // buttonUnassignLanding
            // 
            this.buttonUnassignLanding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUnassignLanding.Enabled = false;
            this.buttonUnassignLanding.Location = new System.Drawing.Point(383, 3);
            this.buttonUnassignLanding.Name = "buttonUnassignLanding";
            this.buttonUnassignLanding.Size = new System.Drawing.Size(94, 38);
            this.buttonUnassignLanding.TabIndex = 6;
            this.buttonUnassignLanding.Text = "Unassign Landing";
            this.buttonUnassignLanding.UseVisualStyleBackColor = true;
            this.buttonUnassignLanding.Click += new System.EventHandler(this.buttonUnassignLanding_Click);
            // 
            // buttonEditLanding
            // 
            this.buttonEditLanding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditLanding.Location = new System.Drawing.Point(283, 3);
            this.buttonEditLanding.Name = "buttonEditLanding";
            this.buttonEditLanding.Size = new System.Drawing.Size(94, 38);
            this.buttonEditLanding.TabIndex = 3;
            this.buttonEditLanding.Text = "Edit Score";
            this.buttonEditLanding.UseVisualStyleBackColor = true;
            this.buttonEditLanding.Click += new System.EventHandler(this.buttonEditLanding_Click);
            // 
            // buttonManualLanding
            // 
            this.buttonManualLanding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonManualLanding.Location = new System.Drawing.Point(183, 3);
            this.buttonManualLanding.Name = "buttonManualLanding";
            this.buttonManualLanding.Size = new System.Drawing.Size(94, 38);
            this.buttonManualLanding.TabIndex = 7;
            this.buttonManualLanding.Text = "Manual Landing";
            this.buttonManualLanding.UseVisualStyleBackColor = true;
            this.buttonManualLanding.Click += new System.EventHandler(this.buttonManualLanding_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClose.Location = new System.Drawing.Point(83, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(94, 38);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConfirm.Location = new System.Drawing.Point(783, 3);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(94, 38);
            this.buttonConfirm.TabIndex = 8;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonRejump
            // 
            this.buttonRejump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRejump.Location = new System.Drawing.Point(883, 3);
            this.buttonRejump.Name = "buttonRejump";
            this.buttonRejump.Size = new System.Drawing.Size(94, 38);
            this.buttonRejump.TabIndex = 9;
            this.buttonRejump.Text = "Rejump";
            this.buttonRejump.UseVisualStyleBackColor = true;
            this.buttonRejump.Click += new System.EventHandler(this.buttonRejump_Click);
            // 
            // tabPageReports
            // 
            this.tabPageReports.Location = new System.Drawing.Point(4, 4);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Size = new System.Drawing.Size(1272, 774);
            this.tabPageReports.TabIndex = 2;
            this.tabPageReports.Text = "Reports";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // EventAccuracy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlEvent);
            this.Name = "EventAccuracy";
            this.Size = new System.Drawing.Size(1280, 800);
            this.tabControlEvent.ResumeLayout(false);
            this.tabPageScores.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScore)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlEvent;
        private System.Windows.Forms.TabPage tabPageScores;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.DataGridView dataGridViewScore;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonNextRound;
        private System.Windows.Forms.Button buttonEditLanding;
        private System.Windows.Forms.Button buttonRenameCompetitor;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonUnassignLanding;
        private System.Windows.Forms.Button buttonManualLanding;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIntermixTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRound1;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonRejump;
        private System.Windows.Forms.GroupBox groupboxControllerListArea;
    }
}
