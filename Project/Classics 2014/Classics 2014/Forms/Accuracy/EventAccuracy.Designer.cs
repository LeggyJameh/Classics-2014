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
            this.tableLayoutPanelEvent = new System.Windows.Forms.TableLayoutPanel();
            this.labelEventName = new System.Windows.Forms.Label();
            this.dataGridScores = new System.Windows.Forms.DataGridView();
            this.ColumnUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnR1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.inputManualLanding = new System.Windows.Forms.Button();
            this.inputEditScore = new System.Windows.Forms.Button();
            this.inputUnassignLanding = new System.Windows.Forms.Button();
            this.inputRejump = new System.Windows.Forms.Button();
            this.inputNextRound = new System.Windows.Forms.Button();
            this.inputConfirm = new System.Windows.Forms.Button();
            this.inputClose = new System.Windows.Forms.Button();
            this.tabControlEvent = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridScores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControlEvent.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelEvent
            // 
            this.tableLayoutPanelEvent.ColumnCount = 11;
            this.tableLayoutPanelEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanelEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanelEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanelEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanelEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanelEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanelEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanelEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanelEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelEvent.Controls.Add(this.labelEventName, 0, 0);
            this.tableLayoutPanelEvent.Controls.Add(this.dataGridScores, 0, 1);
            this.tableLayoutPanelEvent.Controls.Add(this.pictureBox1, 8, 0);
            this.tableLayoutPanelEvent.Controls.Add(this.inputManualLanding, 0, 2);
            this.tableLayoutPanelEvent.Controls.Add(this.inputEditScore, 1, 2);
            this.tableLayoutPanelEvent.Controls.Add(this.inputUnassignLanding, 2, 2);
            this.tableLayoutPanelEvent.Controls.Add(this.inputRejump, 3, 2);
            this.tableLayoutPanelEvent.Controls.Add(this.inputNextRound, 5, 2);
            this.tableLayoutPanelEvent.Controls.Add(this.inputConfirm, 4, 2);
            this.tableLayoutPanelEvent.Controls.Add(this.inputClose, 7, 2);
            this.tableLayoutPanelEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelEvent.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelEvent.Name = "tableLayoutPanelEvent";
            this.tableLayoutPanelEvent.RowCount = 3;
            this.tableLayoutPanelEvent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelEvent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEvent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelEvent.Size = new System.Drawing.Size(1266, 688);
            this.tableLayoutPanelEvent.TabIndex = 0;
            // 
            // labelEventName
            // 
            this.labelEventName.AutoSize = true;
            this.tableLayoutPanelEvent.SetColumnSpan(this.labelEventName, 8);
            this.labelEventName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEventName.Location = new System.Drawing.Point(3, 0);
            this.labelEventName.Name = "labelEventName";
            this.labelEventName.Size = new System.Drawing.Size(1236, 30);
            this.labelEventName.TabIndex = 10;
            this.labelEventName.Text = "WHERE THE EVENT NAME BE AT? IS IT WITH DA G\'S?";
            this.labelEventName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridScores
            // 
            this.dataGridScores.AllowUserToAddRows = false;
            this.dataGridScores.AllowUserToDeleteRows = false;
            this.dataGridScores.AllowUserToResizeColumns = false;
            this.dataGridScores.AllowUserToResizeRows = false;
            this.dataGridScores.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridScores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnUID,
            this.ColumnEID,
            this.ColumnName,
            this.ColumnTeam,
            this.ColumnR1});
            this.tableLayoutPanelEvent.SetColumnSpan(this.dataGridScores, 8);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridScores.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridScores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridScores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridScores.Location = new System.Drawing.Point(3, 33);
            this.dataGridScores.MultiSelect = false;
            this.dataGridScores.Name = "dataGridScores";
            this.dataGridScores.RowHeadersVisible = false;
            this.dataGridScores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridScores.Size = new System.Drawing.Size(1236, 622);
            this.dataGridScores.TabIndex = 11;
            // 
            // ColumnUID
            // 
            this.ColumnUID.HeaderText = "UID";
            this.ColumnUID.Name = "ColumnUID";
            this.ColumnUID.ReadOnly = true;
            this.ColumnUID.Visible = false;
            // 
            // ColumnEID
            // 
            this.ColumnEID.HeaderText = "Event ID";
            this.ColumnEID.Name = "ColumnEID";
            this.ColumnEID.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnTeam
            // 
            this.ColumnTeam.HeaderText = "Team";
            this.ColumnTeam.Name = "ColumnTeam";
            this.ColumnTeam.ReadOnly = true;
            // 
            // ColumnR1
            // 
            this.ColumnR1.HeaderText = "Round 1";
            this.ColumnR1.Name = "ColumnR1";
            this.ColumnR1.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::CMS.Properties.Resources.SplitterBar;
            this.pictureBox1.Location = new System.Drawing.Point(1245, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanelEvent.SetRowSpan(this.pictureBox1, 3);
            this.pictureBox1.Size = new System.Drawing.Size(14, 682);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // inputManualLanding
            // 
            this.inputManualLanding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputManualLanding.Location = new System.Drawing.Point(3, 661);
            this.inputManualLanding.Name = "inputManualLanding";
            this.inputManualLanding.Size = new System.Drawing.Size(143, 23);
            this.inputManualLanding.TabIndex = 0;
            this.inputManualLanding.Text = "Manual Landing";
            this.inputManualLanding.UseVisualStyleBackColor = true;
            this.inputManualLanding.Click += new System.EventHandler(this.inputManualLanding_Click);
            // 
            // inputEditScore
            // 
            this.inputEditScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputEditScore.Location = new System.Drawing.Point(152, 661);
            this.inputEditScore.Name = "inputEditScore";
            this.inputEditScore.Size = new System.Drawing.Size(143, 23);
            this.inputEditScore.TabIndex = 1;
            this.inputEditScore.Text = "Edit Score";
            this.inputEditScore.UseVisualStyleBackColor = true;
            this.inputEditScore.Click += new System.EventHandler(this.inputEditScore_Click);
            // 
            // inputUnassignLanding
            // 
            this.inputUnassignLanding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputUnassignLanding.Location = new System.Drawing.Point(301, 661);
            this.inputUnassignLanding.Name = "inputUnassignLanding";
            this.inputUnassignLanding.Size = new System.Drawing.Size(143, 23);
            this.inputUnassignLanding.TabIndex = 2;
            this.inputUnassignLanding.Text = "Unassign Landing";
            this.inputUnassignLanding.UseVisualStyleBackColor = true;
            this.inputUnassignLanding.Click += new System.EventHandler(this.inputUnassignLanding_Click);
            // 
            // inputRejump
            // 
            this.inputRejump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputRejump.Location = new System.Drawing.Point(450, 661);
            this.inputRejump.Name = "inputRejump";
            this.inputRejump.Size = new System.Drawing.Size(143, 23);
            this.inputRejump.TabIndex = 6;
            this.inputRejump.Text = "Rejump";
            this.inputRejump.UseVisualStyleBackColor = true;
            this.inputRejump.Click += new System.EventHandler(this.inputRejump_Click);
            // 
            // inputNextRound
            // 
            this.inputNextRound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputNextRound.Location = new System.Drawing.Point(748, 661);
            this.inputNextRound.Name = "inputNextRound";
            this.inputNextRound.Size = new System.Drawing.Size(143, 23);
            this.inputNextRound.TabIndex = 3;
            this.inputNextRound.Text = "Next Round";
            this.inputNextRound.UseVisualStyleBackColor = true;
            this.inputNextRound.Click += new System.EventHandler(this.inputNextRound_Click);
            // 
            // inputConfirm
            // 
            this.inputConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputConfirm.Location = new System.Drawing.Point(599, 661);
            this.inputConfirm.Name = "inputConfirm";
            this.inputConfirm.Size = new System.Drawing.Size(143, 23);
            this.inputConfirm.TabIndex = 5;
            this.inputConfirm.Text = "Confirm";
            this.inputConfirm.UseVisualStyleBackColor = true;
            this.inputConfirm.Click += new System.EventHandler(this.inputConfirm_Click);
            // 
            // inputClose
            // 
            this.inputClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputClose.Location = new System.Drawing.Point(1096, 661);
            this.inputClose.Name = "inputClose";
            this.inputClose.Size = new System.Drawing.Size(143, 23);
            this.inputClose.TabIndex = 9;
            this.inputClose.Text = "Close";
            this.inputClose.UseVisualStyleBackColor = true;
            this.inputClose.Click += new System.EventHandler(this.inputClose_Click);
            // 
            // tabControlEvent
            // 
            this.tabControlEvent.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlEvent.Controls.Add(this.tabPage1);
            this.tabControlEvent.Controls.Add(this.tabPage2);
            this.tabControlEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEvent.Location = new System.Drawing.Point(0, 0);
            this.tabControlEvent.Multiline = true;
            this.tabControlEvent.Name = "tabControlEvent";
            this.tabControlEvent.SelectedIndex = 0;
            this.tabControlEvent.Size = new System.Drawing.Size(1280, 720);
            this.tabControlEvent.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanelEvent);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1272, 694);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Score Table";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1272, 694);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reports";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // EventAccuracy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlEvent);
            this.Name = "EventAccuracy";
            this.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutPanelEvent.ResumeLayout(false);
            this.tableLayoutPanelEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridScores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControlEvent.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEvent;
        private System.Windows.Forms.Button inputManualLanding;
        private System.Windows.Forms.Button inputEditScore;
        private System.Windows.Forms.Button inputUnassignLanding;
        private System.Windows.Forms.Button inputClose;
        private System.Windows.Forms.Label labelEventName;
        private System.Windows.Forms.Button inputRejump;
        private System.Windows.Forms.Button inputConfirm;
        private System.Windows.Forms.Button inputNextRound;
        private System.Windows.Forms.DataGridView dataGridScores;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControlEvent;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnR1;
    }
}
