namespace CMS
{
    partial class TeamManager
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridTeams = new System.Windows.Forms.DataGridView();
            this.ColumnTeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMembers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputAddTeam = new System.Windows.Forms.Button();
            this.inputRemoveTeam = new System.Windows.Forms.Button();
            this.inputSave = new System.Windows.Forms.Button();
            this.inputExit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTeams)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridTeams, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputAddTeam, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputRemoveTeam, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.inputSave, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.inputExit, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridTeams
            // 
            this.dataGridTeams.AllowUserToAddRows = false;
            this.dataGridTeams.AllowUserToDeleteRows = false;
            this.dataGridTeams.AllowUserToResizeColumns = false;
            this.dataGridTeams.AllowUserToResizeRows = false;
            this.dataGridTeams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTeams.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridTeams.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTeams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTeamName,
            this.ColumnMembers});
            this.dataGridTeams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridTeams.Location = new System.Drawing.Point(3, 3);
            this.dataGridTeams.Name = "dataGridTeams";
            this.dataGridTeams.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridTeams, 5);
            this.dataGridTeams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridTeams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTeams.Size = new System.Drawing.Size(954, 714);
            this.dataGridTeams.TabIndex = 0;
            // 
            // ColumnTeamName
            // 
            this.ColumnTeamName.HeaderText = "Team Name";
            this.ColumnTeamName.Name = "ColumnTeamName";
            // 
            // ColumnMembers
            // 
            this.ColumnMembers.HeaderText = "Members";
            this.ColumnMembers.Name = "ColumnMembers";
            // 
            // inputAddTeam
            // 
            this.inputAddTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputAddTeam.Location = new System.Drawing.Point(963, 13);
            this.inputAddTeam.Name = "inputAddTeam";
            this.inputAddTeam.Size = new System.Drawing.Size(314, 23);
            this.inputAddTeam.TabIndex = 1;
            this.inputAddTeam.Text = "Add Team";
            this.inputAddTeam.UseVisualStyleBackColor = true;
            this.inputAddTeam.Click += new System.EventHandler(this.inputAddTeam_Click);
            // 
            // inputRemoveTeam
            // 
            this.inputRemoveTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputRemoveTeam.Location = new System.Drawing.Point(963, 63);
            this.inputRemoveTeam.Name = "inputRemoveTeam";
            this.inputRemoveTeam.Size = new System.Drawing.Size(314, 23);
            this.inputRemoveTeam.TabIndex = 2;
            this.inputRemoveTeam.Text = "Remove Selected";
            this.inputRemoveTeam.UseVisualStyleBackColor = true;
            this.inputRemoveTeam.Click += new System.EventHandler(this.inputRemoveTeam_Click);
            // 
            // inputSave
            // 
            this.inputSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSave.Location = new System.Drawing.Point(963, 113);
            this.inputSave.Name = "inputSave";
            this.inputSave.Size = new System.Drawing.Size(314, 23);
            this.inputSave.TabIndex = 3;
            this.inputSave.Text = "Save";
            this.inputSave.UseVisualStyleBackColor = true;
            this.inputSave.Click += new System.EventHandler(this.inputSave_Click);
            // 
            // inputExit
            // 
            this.inputExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputExit.Location = new System.Drawing.Point(963, 163);
            this.inputExit.Name = "inputExit";
            this.inputExit.Size = new System.Drawing.Size(314, 23);
            this.inputExit.TabIndex = 4;
            this.inputExit.Text = "Close";
            this.inputExit.UseVisualStyleBackColor = true;
            this.inputExit.Click += new System.EventHandler(this.inputExit_Click);
            // 
            // TeamManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TeamManager";
            this.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTeams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridTeams;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMembers;
        private System.Windows.Forms.Button inputAddTeam;
        private System.Windows.Forms.Button inputRemoveTeam;
        private System.Windows.Forms.Button inputSave;
        private System.Windows.Forms.Button inputExit;
    }
}
