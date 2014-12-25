namespace CMS
{
    partial class CompetitorEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inputModifySelected = new System.Windows.Forms.Button();
            this.inputFindAndReplace = new System.Windows.Forms.Button();
            this.inputFilter = new System.Windows.Forms.Button();
            this.inputIDCheck = new System.Windows.Forms.CheckBox();
            this.dataGridCompetitors = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputSave = new System.Windows.Forms.Button();
            this.inputExit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompetitors)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputModifySelected, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.inputFindAndReplace, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.inputFilter, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.inputIDCheck, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.dataGridCompetitors, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.inputSave, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.inputExit, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545455F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545454F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545454F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545454F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545454F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545454F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.18182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545454F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1018, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Competitors";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1027, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Options";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inputModifySelected
            // 
            this.inputModifySelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.inputModifySelected, 2);
            this.inputModifySelected.Location = new System.Drawing.Point(1027, 36);
            this.inputModifySelected.Name = "inputModifySelected";
            this.inputModifySelected.Size = new System.Drawing.Size(250, 23);
            this.inputModifySelected.TabIndex = 2;
            this.inputModifySelected.Text = "Modify Selected";
            this.inputModifySelected.UseVisualStyleBackColor = true;
            this.inputModifySelected.Click += new System.EventHandler(this.inputModifySelected_Click);
            // 
            // inputFindAndReplace
            // 
            this.inputFindAndReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.inputFindAndReplace, 2);
            this.inputFindAndReplace.Location = new System.Drawing.Point(1027, 68);
            this.inputFindAndReplace.Name = "inputFindAndReplace";
            this.inputFindAndReplace.Size = new System.Drawing.Size(250, 23);
            this.inputFindAndReplace.TabIndex = 3;
            this.inputFindAndReplace.Text = "Find + Replace";
            this.inputFindAndReplace.UseVisualStyleBackColor = true;
            this.inputFindAndReplace.Click += new System.EventHandler(this.inputFindAndReplace_Click);
            // 
            // inputFilter
            // 
            this.inputFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.inputFilter, 2);
            this.inputFilter.Location = new System.Drawing.Point(1027, 100);
            this.inputFilter.Name = "inputFilter";
            this.inputFilter.Size = new System.Drawing.Size(250, 23);
            this.inputFilter.TabIndex = 4;
            this.inputFilter.Text = "Filter";
            this.inputFilter.UseVisualStyleBackColor = true;
            this.inputFilter.Click += new System.EventHandler(this.inputFilter_Click);
            // 
            // inputIDCheck
            // 
            this.inputIDCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inputIDCheck.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.inputIDCheck, 2);
            this.inputIDCheck.Location = new System.Drawing.Point(1205, 700);
            this.inputIDCheck.Name = "inputIDCheck";
            this.inputIDCheck.Size = new System.Drawing.Size(72, 17);
            this.inputIDCheck.TabIndex = 5;
            this.inputIDCheck.Text = "Show IDs";
            this.inputIDCheck.UseVisualStyleBackColor = true;
            this.inputIDCheck.CheckedChanged += new System.EventHandler(this.inputIDCheck_CheckedChanged);
            // 
            // dataGridCompetitors
            // 
            this.dataGridCompetitors.AllowUserToAddRows = false;
            this.dataGridCompetitors.AllowUserToDeleteRows = false;
            this.dataGridCompetitors.AllowUserToResizeColumns = false;
            this.dataGridCompetitors.AllowUserToResizeRows = false;
            this.dataGridCompetitors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCompetitors.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridCompetitors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridCompetitors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCompetitors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnName,
            this.ColumnNationality,
            this.ColumnTeam});
            this.dataGridCompetitors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridCompetitors.Location = new System.Drawing.Point(3, 35);
            this.dataGridCompetitors.Name = "dataGridCompetitors";
            this.dataGridCompetitors.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridCompetitors, 7);
            this.dataGridCompetitors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridCompetitors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridCompetitors.Size = new System.Drawing.Size(1018, 682);
            this.dataGridCompetitors.TabIndex = 6;
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
            // 
            // ColumnNationality
            // 
            this.ColumnNationality.HeaderText = "Nationality";
            this.ColumnNationality.Name = "ColumnNationality";
            // 
            // ColumnTeam
            // 
            this.ColumnTeam.HeaderText = "Team";
            this.ColumnTeam.Name = "ColumnTeam";
            // 
            // inputSave
            // 
            this.inputSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.inputSave, 2);
            this.inputSave.Location = new System.Drawing.Point(1027, 132);
            this.inputSave.Name = "inputSave";
            this.inputSave.Size = new System.Drawing.Size(250, 23);
            this.inputSave.TabIndex = 7;
            this.inputSave.Text = "Save Changes";
            this.inputSave.UseVisualStyleBackColor = true;
            this.inputSave.Click += new System.EventHandler(this.inputSave_Click);
            // 
            // inputExit
            // 
            this.inputExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.inputExit, 2);
            this.inputExit.Location = new System.Drawing.Point(1027, 164);
            this.inputExit.Name = "inputExit";
            this.inputExit.Size = new System.Drawing.Size(250, 23);
            this.inputExit.TabIndex = 9;
            this.inputExit.Text = "Close";
            this.inputExit.UseVisualStyleBackColor = true;
            this.inputExit.Click += new System.EventHandler(this.inputExit_Click);
            // 
            // CompetitorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CompetitorEditor";
            this.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompetitors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button inputModifySelected;
        private System.Windows.Forms.Button inputFindAndReplace;
        private System.Windows.Forms.Button inputFilter;
        private System.Windows.Forms.CheckBox inputIDCheck;
        private System.Windows.Forms.DataGridView dataGridCompetitors;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTeam;
        private System.Windows.Forms.Button inputSave;
        private System.Windows.Forms.Button inputExit;
    }
}
