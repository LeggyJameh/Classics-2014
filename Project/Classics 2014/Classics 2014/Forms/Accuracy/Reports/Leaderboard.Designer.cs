namespace CMS.Accuracy.Reports
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.inputPrint = new System.Windows.Forms.Button();
            this.inputClose = new System.Windows.Forms.Button();
            this.inputAutoUpdate = new System.Windows.Forms.Button();
            this.inputToggleDock = new System.Windows.Forms.Button();
            this.inputSortSwitch = new System.Windows.Forms.Button();
            this.labelSortType = new System.Windows.Forms.Label();
            this.inputDeselectGrid = new System.Windows.Forms.Button();
            this.inputExportToExcel = new System.Windows.Forms.Button();
            this.inputSave = new System.Windows.Forms.Button();
            this.inputHighlighting = new System.Windows.Forms.CheckBox();
            this.inputTeamJumpOffDisable = new System.Windows.Forms.CheckBox();
            this.dataGridLeaderboard = new System.Windows.Forms.DataGridView();
            this.ColumnUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRanking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLeaderboard)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.inputPrint, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.inputClose, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.inputAutoUpdate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.inputToggleDock, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.inputSortSwitch, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSortType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputDeselectGrid, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.inputExportToExcel, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.inputSave, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.inputHighlighting, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.inputTeamJumpOffDisable, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.dataGridLeaderboard, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1280, 800);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // inputPrint
            // 
            this.inputPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputPrint.Location = new System.Drawing.Point(1091, 672);
            this.inputPrint.Name = "inputPrint";
            this.inputPrint.Size = new System.Drawing.Size(186, 23);
            this.inputPrint.TabIndex = 1;
            this.inputPrint.Text = "Print";
            this.inputPrint.UseVisualStyleBackColor = true;
            this.inputPrint.Click += new System.EventHandler(this.inputPrint_Click);
            // 
            // inputClose
            // 
            this.inputClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputClose.Location = new System.Drawing.Point(1091, 748);
            this.inputClose.Name = "inputClose";
            this.inputClose.Size = new System.Drawing.Size(186, 23);
            this.inputClose.TabIndex = 4;
            this.inputClose.Text = "Close";
            this.inputClose.UseVisualStyleBackColor = true;
            this.inputClose.Click += new System.EventHandler(this.inputClose_Click);
            // 
            // inputAutoUpdate
            // 
            this.inputAutoUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputAutoUpdate.ForeColor = System.Drawing.Color.Red;
            this.inputAutoUpdate.Location = new System.Drawing.Point(1091, 240);
            this.inputAutoUpdate.Name = "inputAutoUpdate";
            this.inputAutoUpdate.Size = new System.Drawing.Size(186, 23);
            this.inputAutoUpdate.TabIndex = 3;
            this.inputAutoUpdate.Text = "Auto-Update";
            this.inputAutoUpdate.UseVisualStyleBackColor = true;
            this.inputAutoUpdate.Click += new System.EventHandler(this.inputAutoUpdate_Click);
            // 
            // inputToggleDock
            // 
            this.inputToggleDock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputToggleDock.Location = new System.Drawing.Point(1091, 168);
            this.inputToggleDock.Name = "inputToggleDock";
            this.inputToggleDock.Size = new System.Drawing.Size(186, 23);
            this.inputToggleDock.TabIndex = 2;
            this.inputToggleDock.Text = "Undock";
            this.inputToggleDock.UseVisualStyleBackColor = true;
            this.inputToggleDock.Click += new System.EventHandler(this.inputToggleDock_Click);
            // 
            // inputSortSwitch
            // 
            this.inputSortSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSortSwitch.Location = new System.Drawing.Point(1091, 96);
            this.inputSortSwitch.Name = "inputSortSwitch";
            this.inputSortSwitch.Size = new System.Drawing.Size(186, 23);
            this.inputSortSwitch.TabIndex = 5;
            this.inputSortSwitch.Text = "Sort as Teams";
            this.inputSortSwitch.UseVisualStyleBackColor = true;
            this.inputSortSwitch.Click += new System.EventHandler(this.inputSortSwitch_Click);
            // 
            // labelSortType
            // 
            this.labelSortType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSortType.AutoSize = true;
            this.labelSortType.Location = new System.Drawing.Point(1091, 29);
            this.labelSortType.Name = "labelSortType";
            this.labelSortType.Size = new System.Drawing.Size(186, 13);
            this.labelSortType.TabIndex = 9;
            this.labelSortType.Text = "Current Sorting: Singles";
            this.labelSortType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inputDeselectGrid
            // 
            this.inputDeselectGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputDeselectGrid.Location = new System.Drawing.Point(1091, 312);
            this.inputDeselectGrid.Name = "inputDeselectGrid";
            this.inputDeselectGrid.Size = new System.Drawing.Size(186, 23);
            this.inputDeselectGrid.TabIndex = 7;
            this.inputDeselectGrid.Text = "Deselect Grid";
            this.inputDeselectGrid.UseVisualStyleBackColor = true;
            this.inputDeselectGrid.Click += new System.EventHandler(this.inputDeselectGrid_Click);
            // 
            // inputExportToExcel
            // 
            this.inputExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputExportToExcel.Location = new System.Drawing.Point(1091, 600);
            this.inputExportToExcel.Name = "inputExportToExcel";
            this.inputExportToExcel.Size = new System.Drawing.Size(186, 23);
            this.inputExportToExcel.TabIndex = 8;
            this.inputExportToExcel.Text = "Export To Excel";
            this.inputExportToExcel.UseVisualStyleBackColor = true;
            this.inputExportToExcel.Click += new System.EventHandler(this.inputExportToExcel_Click);
            // 
            // inputSave
            // 
            this.inputSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSave.Location = new System.Drawing.Point(1091, 528);
            this.inputSave.Name = "inputSave";
            this.inputSave.Size = new System.Drawing.Size(186, 23);
            this.inputSave.TabIndex = 6;
            this.inputSave.Text = "Save";
            this.inputSave.UseVisualStyleBackColor = true;
            this.inputSave.Click += new System.EventHandler(this.inputSave_Click);
            // 
            // inputHighlighting
            // 
            this.inputHighlighting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputHighlighting.AutoSize = true;
            this.inputHighlighting.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.inputHighlighting.Location = new System.Drawing.Point(1091, 380);
            this.inputHighlighting.Name = "inputHighlighting";
            this.inputHighlighting.Size = new System.Drawing.Size(186, 31);
            this.inputHighlighting.TabIndex = 10;
            this.inputHighlighting.Text = "Enable Highlighting";
            this.inputHighlighting.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.inputHighlighting.UseVisualStyleBackColor = true;
            this.inputHighlighting.CheckedChanged += new System.EventHandler(this.inputHighlighting_CheckedChanged);
            // 
            // inputTeamJumpOffDisable
            // 
            this.inputTeamJumpOffDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTeamJumpOffDisable.AutoSize = true;
            this.inputTeamJumpOffDisable.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.inputTeamJumpOffDisable.Location = new System.Drawing.Point(1091, 446);
            this.inputTeamJumpOffDisable.Name = "inputTeamJumpOffDisable";
            this.inputTeamJumpOffDisable.Size = new System.Drawing.Size(186, 44);
            this.inputTeamJumpOffDisable.TabIndex = 11;
            this.inputTeamJumpOffDisable.Text = "Lock Team Positions to\r\nlast full round";
            this.inputTeamJumpOffDisable.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.inputTeamJumpOffDisable.UseVisualStyleBackColor = true;
            this.inputTeamJumpOffDisable.CheckedChanged += new System.EventHandler(this.inputTeamJumpOffDisable_CheckedChanged);
            // 
            // dataGridLeaderboard
            // 
            this.dataGridLeaderboard.AllowUserToAddRows = false;
            this.dataGridLeaderboard.AllowUserToDeleteRows = false;
            this.dataGridLeaderboard.AllowUserToResizeColumns = false;
            this.dataGridLeaderboard.AllowUserToResizeRows = false;
            this.dataGridLeaderboard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridLeaderboard.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridLeaderboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridLeaderboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLeaderboard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnUID,
            this.ColumnRanking,
            this.ColumnEID,
            this.ColumnName,
            this.ColumnNationality,
            this.ColumnTeam});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridLeaderboard.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridLeaderboard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridLeaderboard.Location = new System.Drawing.Point(3, 3);
            this.dataGridLeaderboard.MultiSelect = false;
            this.dataGridLeaderboard.Name = "dataGridLeaderboard";
            this.dataGridLeaderboard.ReadOnly = true;
            this.dataGridLeaderboard.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridLeaderboard.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridLeaderboard, 11);
            this.dataGridLeaderboard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridLeaderboard.Size = new System.Drawing.Size(1082, 794);
            this.dataGridLeaderboard.TabIndex = 0;
            // 
            // ColumnUID
            // 
            this.ColumnUID.HeaderText = "UID";
            this.ColumnUID.Name = "ColumnUID";
            this.ColumnUID.ReadOnly = true;
            this.ColumnUID.Visible = false;
            // 
            // ColumnRanking
            // 
            this.ColumnRanking.HeaderText = "Ranking";
            this.ColumnRanking.Name = "ColumnRanking";
            this.ColumnRanking.ReadOnly = true;
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
            // ColumnNationality
            // 
            this.ColumnNationality.HeaderText = "Nationality";
            this.ColumnNationality.Name = "ColumnNationality";
            this.ColumnNationality.ReadOnly = true;
            // 
            // ColumnTeam
            // 
            this.ColumnTeam.HeaderText = "Team";
            this.ColumnTeam.Name = "ColumnTeam";
            this.ColumnTeam.ReadOnly = true;
            // 
            // Leaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Leaderboard";
            this.Size = new System.Drawing.Size(1280, 800);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLeaderboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridLeaderboard;
        private System.Windows.Forms.Button inputPrint;
        private System.Windows.Forms.Button inputClose;
        private System.Windows.Forms.Button inputAutoUpdate;
        private System.Windows.Forms.Button inputToggleDock;
        private System.Windows.Forms.Button inputSortSwitch;
        private System.Windows.Forms.Label labelSortType;
        private System.Windows.Forms.Button inputDeselectGrid;
        private System.Windows.Forms.Button inputExportToExcel;
        private System.Windows.Forms.Button inputSave;
        private System.Windows.Forms.CheckBox inputHighlighting;
        private System.Windows.Forms.CheckBox inputTeamJumpOffDisable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRanking;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTeam;
    }
}
