namespace CMS
{
    partial class LoadScreen
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
            this.inputLoad = new System.Windows.Forms.Button();
            this.inputCancel = new System.Windows.Forms.Button();
            this.inputDelete = new System.Windows.Forms.Button();
            this.dataGridEvents = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridProperties = new System.Windows.Forms.DataGridView();
            this.ColumnPropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.inputLoad, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.inputCancel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.inputDelete, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridEvents, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridProperties, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // inputLoad
            // 
            this.inputLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputLoad.Location = new System.Drawing.Point(3, 693);
            this.inputLoad.Name = "inputLoad";
            this.inputLoad.Size = new System.Drawing.Size(122, 23);
            this.inputLoad.TabIndex = 0;
            this.inputLoad.Text = "Load";
            this.inputLoad.UseVisualStyleBackColor = true;
            // 
            // inputCancel
            // 
            this.inputCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputCancel.Location = new System.Drawing.Point(131, 693);
            this.inputCancel.Name = "inputCancel";
            this.inputCancel.Size = new System.Drawing.Size(122, 23);
            this.inputCancel.TabIndex = 1;
            this.inputCancel.Text = "Cancel";
            this.inputCancel.UseVisualStyleBackColor = true;
            // 
            // inputDelete
            // 
            this.inputDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputDelete.Location = new System.Drawing.Point(1091, 693);
            this.inputDelete.Name = "inputDelete";
            this.inputDelete.Size = new System.Drawing.Size(186, 23);
            this.inputDelete.TabIndex = 2;
            this.inputDelete.Text = "Delete";
            this.inputDelete.UseVisualStyleBackColor = true;
            // 
            // dataGridEvents
            // 
            this.dataGridEvents.AllowUserToAddRows = false;
            this.dataGridEvents.AllowUserToDeleteRows = false;
            this.dataGridEvents.AllowUserToResizeColumns = false;
            this.dataGridEvents.AllowUserToResizeRows = false;
            this.dataGridEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridEvents.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridEvents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnName,
            this.ColumnDate,
            this.ColumnType});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridEvents, 3);
            this.dataGridEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEvents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridEvents.Location = new System.Drawing.Point(3, 33);
            this.dataGridEvents.MultiSelect = false;
            this.dataGridEvents.Name = "dataGridEvents";
            this.dataGridEvents.RowHeadersVisible = false;
            this.dataGridEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEvents.Size = new System.Drawing.Size(1082, 654);
            this.dataGridEvents.TabIndex = 3;
            this.dataGridEvents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEvents_CellContentClick);
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
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "Date Created";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Event Type";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            // 
            // dataGridProperties
            // 
            this.dataGridProperties.AllowUserToAddRows = false;
            this.dataGridProperties.AllowUserToDeleteRows = false;
            this.dataGridProperties.AllowUserToResizeColumns = false;
            this.dataGridProperties.AllowUserToResizeRows = false;
            this.dataGridProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridProperties.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridProperties.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPropertyName,
            this.ColumnValue});
            this.dataGridProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridProperties.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridProperties.Location = new System.Drawing.Point(1091, 33);
            this.dataGridProperties.MultiSelect = false;
            this.dataGridProperties.Name = "dataGridProperties";
            this.dataGridProperties.ReadOnly = true;
            this.dataGridProperties.RowHeadersVisible = false;
            this.dataGridProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridProperties.Size = new System.Drawing.Size(186, 654);
            this.dataGridProperties.TabIndex = 4;
            // 
            // ColumnPropertyName
            // 
            this.ColumnPropertyName.HeaderText = "Property";
            this.ColumnPropertyName.Name = "ColumnPropertyName";
            this.ColumnPropertyName.ReadOnly = true;
            // 
            // ColumnValue
            // 
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 4);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1274, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Load Event";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LoadScreen";
            this.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProperties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button inputLoad;
        private System.Windows.Forms.Button inputCancel;
        private System.Windows.Forms.Button inputDelete;
        private System.Windows.Forms.DataGridView dataGridEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridView dataGridProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.Label label1;
    }
}
