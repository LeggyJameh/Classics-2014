namespace CMS
{
    partial class EventLoader
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewEvents = new System.Windows.Forms.DataGridView();
            this.ColumnEventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEventDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSetup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewEventProperties = new System.Windows.Forms.DataGridView();
            this.ColumnProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewEventCompetitors = new System.Windows.Forms.DataGridView();
            this.ColumnCompetitorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompetitorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompetitorTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventCompetitors)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewEvents, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewEventProperties, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewEventCompetitors, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonLoad, 4, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1280, 800);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridViewEvents
            // 
            this.dataGridViewEvents.AllowUserToAddRows = false;
            this.dataGridViewEvents.AllowUserToDeleteRows = false;
            this.dataGridViewEvents.AllowUserToResizeRows = false;
            this.dataGridViewEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEvents.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEventID,
            this.ColumnEventName,
            this.ColumnEventDate,
            this.ColumnEventType,
            this.ColumnSetup,
            this.ColumnStage});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewEvents, 7);
            this.dataGridViewEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEvents.Location = new System.Drawing.Point(3, 43);
            this.dataGridViewEvents.MultiSelect = false;
            this.dataGridViewEvents.Name = "dataGridViewEvents";
            this.dataGridViewEvents.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewEvents, 3);
            this.dataGridViewEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEvents.Size = new System.Drawing.Size(974, 714);
            this.dataGridViewEvents.TabIndex = 0;
            this.dataGridViewEvents.SelectionChanged += new System.EventHandler(this.dataGridViewEvents_SelectionChanged);
            // 
            // ColumnEventID
            // 
            this.ColumnEventID.HeaderText = "ID";
            this.ColumnEventID.Name = "ColumnEventID";
            this.ColumnEventID.ReadOnly = true;
            this.ColumnEventID.Visible = false;
            // 
            // ColumnEventName
            // 
            this.ColumnEventName.HeaderText = "Name of Event";
            this.ColumnEventName.Name = "ColumnEventName";
            this.ColumnEventName.ReadOnly = true;
            // 
            // ColumnEventDate
            // 
            this.ColumnEventDate.HeaderText = "Date of Event";
            this.ColumnEventDate.Name = "ColumnEventDate";
            this.ColumnEventDate.ReadOnly = true;
            // 
            // ColumnEventType
            // 
            this.ColumnEventType.HeaderText = "Type of Event";
            this.ColumnEventType.Name = "ColumnEventType";
            this.ColumnEventType.ReadOnly = true;
            // 
            // ColumnSetup
            // 
            this.ColumnSetup.HeaderText = "Ready?";
            this.ColumnSetup.Name = "ColumnSetup";
            this.ColumnSetup.ReadOnly = true;
            // 
            // ColumnStage
            // 
            this.ColumnStage.HeaderText = "Setup Stage";
            this.ColumnStage.Name = "ColumnStage";
            this.ColumnStage.ReadOnly = true;
            // 
            // dataGridViewEventProperties
            // 
            this.dataGridViewEventProperties.AllowUserToResizeRows = false;
            this.dataGridViewEventProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEventProperties.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewEventProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEventProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnProperty,
            this.ColumnValue});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEventProperties.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewEventProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEventProperties.Location = new System.Drawing.Point(983, 43);
            this.dataGridViewEventProperties.MultiSelect = false;
            this.dataGridViewEventProperties.Name = "dataGridViewEventProperties";
            this.dataGridViewEventProperties.ReadOnly = true;
            this.dataGridViewEventProperties.RowHeadersVisible = false;
            this.dataGridViewEventProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewEventProperties.Size = new System.Drawing.Size(294, 334);
            this.dataGridViewEventProperties.TabIndex = 1;
            // 
            // ColumnProperty
            // 
            this.ColumnProperty.HeaderText = "Property";
            this.ColumnProperty.Name = "ColumnProperty";
            this.ColumnProperty.ReadOnly = true;
            // 
            // ColumnValue
            // 
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.ReadOnly = true;
            // 
            // dataGridViewEventCompetitors
            // 
            this.dataGridViewEventCompetitors.AllowUserToResizeRows = false;
            this.dataGridViewEventCompetitors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEventCompetitors.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewEventCompetitors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEventCompetitors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCompetitorID,
            this.ColumnCompetitorName,
            this.ColumnCompetitorTeam});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEventCompetitors.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewEventCompetitors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEventCompetitors.Location = new System.Drawing.Point(983, 423);
            this.dataGridViewEventCompetitors.MultiSelect = false;
            this.dataGridViewEventCompetitors.Name = "dataGridViewEventCompetitors";
            this.dataGridViewEventCompetitors.ReadOnly = true;
            this.dataGridViewEventCompetitors.RowHeadersVisible = false;
            this.dataGridViewEventCompetitors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewEventCompetitors.Size = new System.Drawing.Size(294, 334);
            this.dataGridViewEventCompetitors.TabIndex = 2;
            // 
            // ColumnCompetitorID
            // 
            this.ColumnCompetitorID.HeaderText = "ID";
            this.ColumnCompetitorID.Name = "ColumnCompetitorID";
            this.ColumnCompetitorID.ReadOnly = true;
            this.ColumnCompetitorID.Visible = false;
            // 
            // ColumnCompetitorName
            // 
            this.ColumnCompetitorName.HeaderText = "Name";
            this.ColumnCompetitorName.Name = "ColumnCompetitorName";
            this.ColumnCompetitorName.ReadOnly = true;
            // 
            // ColumnCompetitorTeam
            // 
            this.ColumnCompetitorTeam.HeaderText = "Team";
            this.ColumnCompetitorTeam.Name = "ColumnCompetitorTeam";
            this.ColumnCompetitorTeam.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 7);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(974, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Event Browser";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(983, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "Event Settings";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(983, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 40);
            this.label3.TabIndex = 5;
            this.label3.Text = "Event Competitors";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonCancel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonCancel, 2);
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(243, 763);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(194, 34);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonLoad
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonLoad, 2);
            this.buttonLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoad.Location = new System.Drawing.Point(543, 763);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(194, 34);
            this.buttonLoad.TabIndex = 7;
            this.buttonLoad.Text = "Load Event";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // EventLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EventLoader";
            this.Size = new System.Drawing.Size(1280, 800);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventCompetitors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridViewEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEventID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEventDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSetup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStage;
        private System.Windows.Forms.DataGridView dataGridViewEventProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProperty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.DataGridView dataGridViewEventCompetitors;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompetitorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompetitorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompetitorTeam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonLoad;
    }
}
