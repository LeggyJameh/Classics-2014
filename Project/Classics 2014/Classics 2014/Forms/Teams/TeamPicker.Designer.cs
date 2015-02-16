namespace CMS.Forms
{
    partial class TeamPicker
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Properties", System.Windows.Forms.HorizontalAlignment.Left);
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.inputAssignDefault = new System.Windows.Forms.Button();
            this.inputAddTeam = new System.Windows.Forms.Button();
            this.inputRemoveTeam = new System.Windows.Forms.Button();
            this.inputFillRemaining = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.inputSaveAndContinue = new System.Windows.Forms.Button();
            this.inputSave = new System.Windows.Forms.Button();
            this.inputCancel = new System.Windows.Forms.Button();
            this.inputFilterOption = new System.Windows.Forms.ComboBox();
            this.inputAddTo = new System.Windows.Forms.Button();
            this.inputRemoveFrom = new System.Windows.Forms.Button();
            this.pictureBoxTeamImage = new System.Windows.Forms.PictureBox();
            this.dataGridCompetitors = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeViewTeams = new System.Windows.Forms.TreeView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.listViewSelectionProperties = new System.Windows.Forms.ListView();
            this.columnItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTeamImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompetitors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 6;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutMain.Controls.Add(this.inputAssignDefault, 4, 2);
            this.tableLayoutMain.Controls.Add(this.inputAddTeam, 4, 4);
            this.tableLayoutMain.Controls.Add(this.inputRemoveTeam, 4, 5);
            this.tableLayoutMain.Controls.Add(this.inputFillRemaining, 4, 6);
            this.tableLayoutMain.Controls.Add(this.tableLayoutPanel1, 2, 9);
            this.tableLayoutMain.Controls.Add(this.inputFilterOption, 4, 3);
            this.tableLayoutMain.Controls.Add(this.inputAddTo, 4, 7);
            this.tableLayoutMain.Controls.Add(this.inputRemoveFrom, 4, 8);
            this.tableLayoutMain.Controls.Add(this.pictureBoxTeamImage, 4, 1);
            this.tableLayoutMain.Controls.Add(this.dataGridCompetitors, 0, 0);
            this.tableLayoutMain.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutMain.Controls.Add(this.treeViewTeams, 2, 0);
            this.tableLayoutMain.Controls.Add(this.pictureBox2, 3, 0);
            this.tableLayoutMain.Controls.Add(this.listViewSelectionProperties, 4, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 11;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // inputAssignDefault
            // 
            this.inputAssignDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.inputAssignDefault, 2);
            this.inputAssignDefault.Location = new System.Drawing.Point(1083, 432);
            this.inputAssignDefault.Name = "inputAssignDefault";
            this.inputAssignDefault.Size = new System.Drawing.Size(194, 23);
            this.inputAssignDefault.TabIndex = 0;
            this.inputAssignDefault.Text = "Assign to Default Teams";
            this.inputAssignDefault.UseVisualStyleBackColor = true;
            this.inputAssignDefault.Click += new System.EventHandler(this.inputAssignDefault_Click);
            // 
            // inputAddTeam
            // 
            this.inputAddTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.inputAddTeam, 2);
            this.inputAddTeam.Location = new System.Drawing.Point(1083, 493);
            this.inputAddTeam.Name = "inputAddTeam";
            this.inputAddTeam.Size = new System.Drawing.Size(194, 23);
            this.inputAddTeam.TabIndex = 2;
            this.inputAddTeam.Text = "Add Team";
            this.inputAddTeam.UseVisualStyleBackColor = true;
            this.inputAddTeam.Click += new System.EventHandler(this.inputAddTeam_Click);
            // 
            // inputRemoveTeam
            // 
            this.inputRemoveTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.inputRemoveTeam, 2);
            this.inputRemoveTeam.Location = new System.Drawing.Point(1083, 523);
            this.inputRemoveTeam.Name = "inputRemoveTeam";
            this.inputRemoveTeam.Size = new System.Drawing.Size(194, 23);
            this.inputRemoveTeam.TabIndex = 3;
            this.inputRemoveTeam.Text = "Remove Team";
            this.inputRemoveTeam.UseVisualStyleBackColor = true;
            this.inputRemoveTeam.Click += new System.EventHandler(this.inputRemoveTeam_Click);
            // 
            // inputFillRemaining
            // 
            this.inputFillRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.inputFillRemaining, 2);
            this.inputFillRemaining.Location = new System.Drawing.Point(1083, 553);
            this.inputFillRemaining.Name = "inputFillRemaining";
            this.inputFillRemaining.Size = new System.Drawing.Size(194, 23);
            this.inputFillRemaining.TabIndex = 4;
            this.inputFillRemaining.Text = "Fill Remaining Teams";
            this.inputFillRemaining.UseVisualStyleBackColor = true;
            this.inputFillRemaining.Click += new System.EventHandler(this.inputFillRemaining_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutMain.SetColumnSpan(this.tableLayoutPanel1, 4);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.inputSaveAndContinue, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputSave, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputCancel, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(731, 683);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(346, 34);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // inputSaveAndContinue
            // 
            this.inputSaveAndContinue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSaveAndContinue.Location = new System.Drawing.Point(3, 8);
            this.inputSaveAndContinue.Name = "inputSaveAndContinue";
            this.inputSaveAndContinue.Size = new System.Drawing.Size(109, 23);
            this.inputSaveAndContinue.TabIndex = 0;
            this.inputSaveAndContinue.Text = "Save + Continue";
            this.inputSaveAndContinue.UseVisualStyleBackColor = true;
            // 
            // inputSave
            // 
            this.inputSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSave.Location = new System.Drawing.Point(118, 8);
            this.inputSave.Name = "inputSave";
            this.inputSave.Size = new System.Drawing.Size(109, 23);
            this.inputSave.TabIndex = 1;
            this.inputSave.Text = "Save";
            this.inputSave.UseVisualStyleBackColor = true;
            // 
            // inputCancel
            // 
            this.inputCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inputCancel.Location = new System.Drawing.Point(233, 8);
            this.inputCancel.Name = "inputCancel";
            this.inputCancel.Size = new System.Drawing.Size(110, 23);
            this.inputCancel.TabIndex = 2;
            this.inputCancel.Text = "Cancel";
            this.inputCancel.UseVisualStyleBackColor = true;
            // 
            // inputFilterOption
            // 
            this.inputFilterOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.inputFilterOption, 2);
            this.inputFilterOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputFilterOption.FormattingEnabled = true;
            this.inputFilterOption.Items.AddRange(new object[] {
            "Show Both",
            "Show Full Only",
            "Show Not-Full Only",
            "Highlight Both",
            "Highlight Full",
            "Highlight Not-Full"});
            this.inputFilterOption.Location = new System.Drawing.Point(1083, 464);
            this.inputFilterOption.Name = "inputFilterOption";
            this.inputFilterOption.Size = new System.Drawing.Size(194, 21);
            this.inputFilterOption.TabIndex = 7;
            this.inputFilterOption.SelectedIndexChanged += new System.EventHandler(this.inputFilterOption_SelectedIndexChanged);
            // 
            // inputAddTo
            // 
            this.inputAddTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.inputAddTo, 2);
            this.inputAddTo.Location = new System.Drawing.Point(1083, 583);
            this.inputAddTo.Name = "inputAddTo";
            this.inputAddTo.Size = new System.Drawing.Size(194, 23);
            this.inputAddTo.TabIndex = 9;
            this.inputAddTo.Text = "Add to Team";
            this.inputAddTo.UseVisualStyleBackColor = true;
            this.inputAddTo.Click += new System.EventHandler(this.inputAddTo_Click);
            // 
            // inputRemoveFrom
            // 
            this.inputRemoveFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.inputRemoveFrom, 2);
            this.inputRemoveFrom.Location = new System.Drawing.Point(1083, 613);
            this.inputRemoveFrom.Name = "inputRemoveFrom";
            this.inputRemoveFrom.Size = new System.Drawing.Size(194, 23);
            this.inputRemoveFrom.TabIndex = 10;
            this.inputRemoveFrom.Text = "Remove from Team";
            this.inputRemoveFrom.UseVisualStyleBackColor = true;
            this.inputRemoveFrom.Click += new System.EventHandler(this.inputRemoveFrom_Click);
            // 
            // pictureBoxTeamImage
            // 
            this.tableLayoutMain.SetColumnSpan(this.pictureBoxTeamImage, 2);
            this.pictureBoxTeamImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTeamImage.Location = new System.Drawing.Point(1083, 233);
            this.pictureBoxTeamImage.Name = "pictureBoxTeamImage";
            this.pictureBoxTeamImage.Size = new System.Drawing.Size(194, 192);
            this.pictureBoxTeamImage.TabIndex = 11;
            this.pictureBoxTeamImage.TabStop = false;
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
            this.ColumnGroup});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridCompetitors.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridCompetitors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridCompetitors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridCompetitors.Location = new System.Drawing.Point(3, 3);
            this.dataGridCompetitors.Name = "dataGridCompetitors";
            this.dataGridCompetitors.RowHeadersVisible = false;
            this.tableLayoutMain.SetRowSpan(this.dataGridCompetitors, 10);
            this.dataGridCompetitors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCompetitors.Size = new System.Drawing.Size(514, 674);
            this.dataGridCompetitors.TabIndex = 13;
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
            // ColumnGroup
            // 
            this.ColumnGroup.HeaderText = "Group";
            this.ColumnGroup.Name = "ColumnGroup";
            this.ColumnGroup.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::CMS.Properties.Resources.SplitterBar;
            this.pictureBox1.Location = new System.Drawing.Point(523, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutMain.SetRowSpan(this.pictureBox1, 10);
            this.pictureBox1.Size = new System.Drawing.Size(14, 674);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // treeViewTeams
            // 
            this.treeViewTeams.BackColor = System.Drawing.SystemColors.Control;
            this.treeViewTeams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTeams.Location = new System.Drawing.Point(543, 3);
            this.treeViewTeams.Name = "treeViewTeams";
            this.tableLayoutMain.SetRowSpan(this.treeViewTeams, 10);
            this.treeViewTeams.Size = new System.Drawing.Size(514, 674);
            this.treeViewTeams.TabIndex = 15;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CMS.Properties.Resources.SplitterBar;
            this.pictureBox2.Location = new System.Drawing.Point(1063, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.tableLayoutMain.SetRowSpan(this.pictureBox2, 10);
            this.pictureBox2.Size = new System.Drawing.Size(14, 674);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // listViewSelectionProperties
            // 
            this.listViewSelectionProperties.BackColor = System.Drawing.SystemColors.Control;
            this.listViewSelectionProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnItem,
            this.columnValue});
            this.tableLayoutMain.SetColumnSpan(this.listViewSelectionProperties, 2);
            this.listViewSelectionProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "Properties";
            listViewGroup1.Name = "Properties";
            this.listViewSelectionProperties.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listViewSelectionProperties.Location = new System.Drawing.Point(1083, 3);
            this.listViewSelectionProperties.MultiSelect = false;
            this.listViewSelectionProperties.Name = "listViewSelectionProperties";
            this.listViewSelectionProperties.Size = new System.Drawing.Size(194, 224);
            this.listViewSelectionProperties.TabIndex = 17;
            this.listViewSelectionProperties.UseCompatibleStateImageBehavior = false;
            // 
            // columnItem
            // 
            this.columnItem.Text = "Item";
            // 
            // columnValue
            // 
            this.columnValue.Text = "Value";
            // 
            // TeamPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutMain);
            this.Name = "TeamPicker";
            this.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTeamImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompetitors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Button inputAssignDefault;
        private System.Windows.Forms.Button inputAddTeam;
        private System.Windows.Forms.Button inputRemoveTeam;
        private System.Windows.Forms.Button inputFillRemaining;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button inputSaveAndContinue;
        private System.Windows.Forms.Button inputSave;
        private System.Windows.Forms.Button inputCancel;
        private System.Windows.Forms.ComboBox inputFilterOption;
        private System.Windows.Forms.Button inputAddTo;
        private System.Windows.Forms.Button inputRemoveFrom;
        private System.Windows.Forms.PictureBox pictureBoxTeamImage;
        private System.Windows.Forms.DataGridView dataGridCompetitors;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGroup;
        private System.Windows.Forms.TreeView treeViewTeams;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListView listViewSelectionProperties;
        private System.Windows.Forms.ColumnHeader columnItem;
        private System.Windows.Forms.ColumnHeader columnValue;
    }
}
