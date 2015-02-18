namespace CMS
{
    partial class GroupManager
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
            this.dataGridGroups = new System.Windows.Forms.DataGridView();
            this.ColumnGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMembers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputAddGroup = new System.Windows.Forms.Button();
            this.inputRemoveGroup = new System.Windows.Forms.Button();
            this.inputSave = new System.Windows.Forms.Button();
            this.inputExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridGroups, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.inputAddGroup, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.inputRemoveGroup, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.inputSave, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.inputExit, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridGroups
            // 
            this.dataGridGroups.AllowUserToAddRows = false;
            this.dataGridGroups.AllowUserToDeleteRows = false;
            this.dataGridGroups.AllowUserToResizeColumns = false;
            this.dataGridGroups.AllowUserToResizeRows = false;
            this.dataGridGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridGroups.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridGroups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnGroupName,
            this.ColumnMembers});
            this.dataGridGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridGroups.Location = new System.Drawing.Point(3, 33);
            this.dataGridGroups.Name = "dataGridGroups";
            this.dataGridGroups.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridGroups, 5);
            this.dataGridGroups.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridGroups.Size = new System.Drawing.Size(1018, 684);
            this.dataGridGroups.TabIndex = 0;
            // 
            // ColumnGroupName
            // 
            this.ColumnGroupName.HeaderText = "Group Name";
            this.ColumnGroupName.Name = "ColumnGroupName";
            // 
            // ColumnMembers
            // 
            this.ColumnMembers.HeaderText = "Members";
            this.ColumnMembers.Name = "ColumnMembers";
            // 
            // inputAddGroup
            // 
            this.inputAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputAddGroup.Location = new System.Drawing.Point(1027, 33);
            this.inputAddGroup.Name = "inputAddGroup";
            this.inputAddGroup.Size = new System.Drawing.Size(250, 23);
            this.inputAddGroup.TabIndex = 1;
            this.inputAddGroup.Text = "Add Group";
            this.inputAddGroup.UseVisualStyleBackColor = true;
            this.inputAddGroup.Click += new System.EventHandler(this.inputAddGroup_Click);
            // 
            // inputRemoveGroup
            // 
            this.inputRemoveGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputRemoveGroup.Location = new System.Drawing.Point(1027, 63);
            this.inputRemoveGroup.Name = "inputRemoveGroup";
            this.inputRemoveGroup.Size = new System.Drawing.Size(250, 23);
            this.inputRemoveGroup.TabIndex = 2;
            this.inputRemoveGroup.Text = "Remove Selected";
            this.inputRemoveGroup.UseVisualStyleBackColor = true;
            this.inputRemoveGroup.Click += new System.EventHandler(this.inputRemoveGroup_Click);
            // 
            // inputSave
            // 
            this.inputSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSave.Location = new System.Drawing.Point(1027, 93);
            this.inputSave.Name = "inputSave";
            this.inputSave.Size = new System.Drawing.Size(250, 23);
            this.inputSave.TabIndex = 3;
            this.inputSave.Text = "Save";
            this.inputSave.UseVisualStyleBackColor = true;
            this.inputSave.Click += new System.EventHandler(this.inputSave_Click);
            // 
            // inputExit
            // 
            this.inputExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputExit.Location = new System.Drawing.Point(1027, 123);
            this.inputExit.Name = "inputExit";
            this.inputExit.Size = new System.Drawing.Size(250, 23);
            this.inputExit.TabIndex = 4;
            this.inputExit.Text = "Close";
            this.inputExit.UseVisualStyleBackColor = true;
            this.inputExit.Click += new System.EventHandler(this.inputExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1018, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Groups";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GroupManager";
            this.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridGroups;
        private System.Windows.Forms.Button inputAddGroup;
        private System.Windows.Forms.Button inputRemoveGroup;
        private System.Windows.Forms.Button inputSave;
        private System.Windows.Forms.Button inputExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMembers;
        private System.Windows.Forms.Label label1;
    }
}
