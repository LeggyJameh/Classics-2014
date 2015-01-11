namespace CMS
{
    partial class TeamAdvanced
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
            this.pictureBoxTeamImage = new System.Windows.Forms.PictureBox();
            this.inputMinimise = new System.Windows.Forms.Button();
            this.inputRemove = new System.Windows.Forms.Button();
            this.inputClear = new System.Windows.Forms.Button();
            this.inputConfirm = new System.Windows.Forms.Button();
            this.dataGridTeam = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTeamName = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTeamImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxTeamImage, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.inputMinimise, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputRemove, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.inputClear, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.inputConfirm, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataGridTeam, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTeamName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelID, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 230);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxTeamImage
            // 
            this.pictureBoxTeamImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTeamImage.Location = new System.Drawing.Point(827, 33);
            this.pictureBoxTeamImage.Name = "pictureBoxTeamImage";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBoxTeamImage, 4);
            this.pictureBoxTeamImage.Size = new System.Drawing.Size(194, 194);
            this.pictureBoxTeamImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxTeamImage.TabIndex = 0;
            this.pictureBoxTeamImage.TabStop = false;
            // 
            // inputMinimise
            // 
            this.inputMinimise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputMinimise.Location = new System.Drawing.Point(3, 3);
            this.inputMinimise.Name = "inputMinimise";
            this.inputMinimise.Size = new System.Drawing.Size(24, 24);
            this.inputMinimise.TabIndex = 1;
            this.inputMinimise.Text = "+";
            this.inputMinimise.UseVisualStyleBackColor = true;
            this.inputMinimise.Click += new System.EventHandler(this.inputExit_Click);
            // 
            // inputRemove
            // 
            this.inputRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.inputRemove, 2);
            this.inputRemove.Location = new System.Drawing.Point(3, 38);
            this.inputRemove.Name = "inputRemove";
            this.inputRemove.Size = new System.Drawing.Size(94, 23);
            this.inputRemove.TabIndex = 2;
            this.inputRemove.Text = "Remove Team";
            this.inputRemove.UseVisualStyleBackColor = true;
            // 
            // inputClear
            // 
            this.inputClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.inputClear, 2);
            this.inputClear.Location = new System.Drawing.Point(3, 78);
            this.inputClear.Name = "inputClear";
            this.inputClear.Size = new System.Drawing.Size(94, 23);
            this.inputClear.TabIndex = 3;
            this.inputClear.Text = "Clear Team";
            this.inputClear.UseVisualStyleBackColor = true;
            // 
            // inputConfirm
            // 
            this.inputConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.inputConfirm, 2);
            this.inputConfirm.Location = new System.Drawing.Point(3, 118);
            this.inputConfirm.Name = "inputConfirm";
            this.inputConfirm.Size = new System.Drawing.Size(94, 23);
            this.inputConfirm.TabIndex = 4;
            this.inputConfirm.Text = "Confirm Team";
            this.inputConfirm.UseVisualStyleBackColor = true;
            // 
            // dataGridTeam
            // 
            this.dataGridTeam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTeam.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridTeam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTeam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnName,
            this.ColumnNationality,
            this.ColumnCTeam});
            this.dataGridTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridTeam.Location = new System.Drawing.Point(103, 33);
            this.dataGridTeam.Name = "dataGridTeam";
            this.dataGridTeam.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridTeam, 4);
            this.dataGridTeam.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridTeam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTeam.Size = new System.Drawing.Size(718, 194);
            this.dataGridTeam.TabIndex = 7;
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Visible = false;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnNationality
            // 
            this.ColumnNationality.HeaderText = "Nationality";
            this.ColumnNationality.Name = "ColumnNationality";
            this.ColumnNationality.ReadOnly = true;
            // 
            // ColumnCTeam
            // 
            this.ColumnCTeam.HeaderText = "Competitor Team";
            this.ColumnCTeam.Name = "ColumnCTeam";
            this.ColumnCTeam.ReadOnly = true;
            // 
            // labelTeamName
            // 
            this.labelTeamName.AutoSize = true;
            this.labelTeamName.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelTeamName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeamName.Location = new System.Drawing.Point(103, 0);
            this.labelTeamName.Name = "labelTeamName";
            this.labelTeamName.Size = new System.Drawing.Size(718, 30);
            this.labelTeamName.TabIndex = 8;
            this.labelTeamName.Text = " TEAM NAME";
            this.labelTeamName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.Location = new System.Drawing.Point(827, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(194, 30);
            this.labelID.TabIndex = 9;
            this.labelID.Text = "ID: ";
            this.labelID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Team
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Team";
            this.Size = new System.Drawing.Size(1024, 230);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTeamImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTeam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxTeamImage;
        private System.Windows.Forms.Button inputMinimise;
        private System.Windows.Forms.Button inputRemove;
        private System.Windows.Forms.Button inputClear;
        private System.Windows.Forms.Button inputConfirm;
        private System.Windows.Forms.DataGridView dataGridTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCTeam;
        private System.Windows.Forms.Label labelTeamName;
        private System.Windows.Forms.Label labelID;
    }
}
