namespace CMS.FAI_CP
{
    partial class EventFAI_CP
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelAccuracy = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridAccuracyScores = new System.Windows.Forms.DataGridView();
            this.inputAccuracyNextRound = new System.Windows.Forms.Button();
            this.inputClose1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelSpeed = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridSpeedScores = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelDistance = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridDistanceScores = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ColumnUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanelAccuracy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAccuracyScores)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanelSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSpeedScores)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanelDistance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDistanceScores)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1274, 684);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanelAccuracy);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1266, 658);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Accuracy";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelAccuracy
            // 
            this.tableLayoutPanelAccuracy.ColumnCount = 4;
            this.tableLayoutPanelAccuracy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelAccuracy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanelAccuracy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanelAccuracy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanelAccuracy.Controls.Add(this.dataGridAccuracyScores, 0, 0);
            this.tableLayoutPanelAccuracy.Controls.Add(this.inputAccuracyNextRound, 1, 2);
            this.tableLayoutPanelAccuracy.Controls.Add(this.inputClose1, 3, 2);
            this.tableLayoutPanelAccuracy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAccuracy.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelAccuracy.Name = "tableLayoutPanelAccuracy";
            this.tableLayoutPanelAccuracy.RowCount = 3;
            this.tableLayoutPanelAccuracy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelAccuracy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelAccuracy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelAccuracy.Size = new System.Drawing.Size(1260, 652);
            this.tableLayoutPanelAccuracy.TabIndex = 0;
            // 
            // dataGridAccuracyScores
            // 
            this.dataGridAccuracyScores.AllowUserToAddRows = false;
            this.dataGridAccuracyScores.AllowUserToDeleteRows = false;
            this.dataGridAccuracyScores.AllowUserToResizeColumns = false;
            this.dataGridAccuracyScores.AllowUserToResizeRows = false;
            this.dataGridAccuracyScores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAccuracyScores.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridAccuracyScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridAccuracyScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAccuracyScores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnUID,
            this.ColumnEID,
            this.ColumnName});
            this.tableLayoutPanelAccuracy.SetColumnSpan(this.dataGridAccuracyScores, 4);
            this.dataGridAccuracyScores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAccuracyScores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridAccuracyScores.Location = new System.Drawing.Point(3, 3);
            this.dataGridAccuracyScores.Name = "dataGridAccuracyScores";
            this.dataGridAccuracyScores.ReadOnly = true;
            this.dataGridAccuracyScores.RowHeadersVisible = false;
            this.dataGridAccuracyScores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridAccuracyScores.Size = new System.Drawing.Size(1254, 242);
            this.dataGridAccuracyScores.TabIndex = 0;
            // 
            // inputAccuracyNextRound
            // 
            this.inputAccuracyNextRound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputAccuracyNextRound.Location = new System.Drawing.Point(759, 625);
            this.inputAccuracyNextRound.Name = "inputAccuracyNextRound";
            this.inputAccuracyNextRound.Size = new System.Drawing.Size(145, 23);
            this.inputAccuracyNextRound.TabIndex = 2;
            this.inputAccuracyNextRound.Text = "Next Round";
            this.inputAccuracyNextRound.UseVisualStyleBackColor = true;
            // 
            // inputClose1
            // 
            this.inputClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputClose1.Location = new System.Drawing.Point(1111, 625);
            this.inputClose1.Name = "inputClose1";
            this.inputClose1.Size = new System.Drawing.Size(146, 23);
            this.inputClose1.TabIndex = 3;
            this.inputClose1.Text = "Close";
            this.inputClose1.UseVisualStyleBackColor = true;
            this.inputClose1.Click += new System.EventHandler(this.inputClose_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanelSpeed);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1266, 658);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Speed";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelSpeed
            // 
            this.tableLayoutPanelSpeed.ColumnCount = 2;
            this.tableLayoutPanelSpeed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSpeed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSpeed.Controls.Add(this.dataGridSpeedScores, 0, 0);
            this.tableLayoutPanelSpeed.Location = new System.Drawing.Point(33, 56);
            this.tableLayoutPanelSpeed.Name = "tableLayoutPanelSpeed";
            this.tableLayoutPanelSpeed.RowCount = 2;
            this.tableLayoutPanelSpeed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSpeed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSpeed.Size = new System.Drawing.Size(973, 528);
            this.tableLayoutPanelSpeed.TabIndex = 0;
            // 
            // dataGridSpeedScores
            // 
            this.dataGridSpeedScores.AllowUserToAddRows = false;
            this.dataGridSpeedScores.AllowUserToDeleteRows = false;
            this.dataGridSpeedScores.AllowUserToResizeColumns = false;
            this.dataGridSpeedScores.AllowUserToResizeRows = false;
            this.dataGridSpeedScores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridSpeedScores.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridSpeedScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridSpeedScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSpeedScores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridSpeedScores.Location = new System.Drawing.Point(3, 3);
            this.dataGridSpeedScores.Name = "dataGridSpeedScores";
            this.dataGridSpeedScores.ReadOnly = true;
            this.dataGridSpeedScores.RowHeadersVisible = false;
            this.dataGridSpeedScores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridSpeedScores.Size = new System.Drawing.Size(240, 150);
            this.dataGridSpeedScores.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanelDistance);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1266, 658);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Distance";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelDistance
            // 
            this.tableLayoutPanelDistance.ColumnCount = 2;
            this.tableLayoutPanelDistance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDistance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDistance.Controls.Add(this.dataGridDistanceScores, 0, 0);
            this.tableLayoutPanelDistance.Location = new System.Drawing.Point(0, 95);
            this.tableLayoutPanelDistance.Name = "tableLayoutPanelDistance";
            this.tableLayoutPanelDistance.RowCount = 2;
            this.tableLayoutPanelDistance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDistance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDistance.Size = new System.Drawing.Size(919, 380);
            this.tableLayoutPanelDistance.TabIndex = 0;
            // 
            // dataGridDistanceScores
            // 
            this.dataGridDistanceScores.AllowUserToAddRows = false;
            this.dataGridDistanceScores.AllowUserToDeleteRows = false;
            this.dataGridDistanceScores.AllowUserToResizeColumns = false;
            this.dataGridDistanceScores.AllowUserToResizeRows = false;
            this.dataGridDistanceScores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDistanceScores.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridDistanceScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridDistanceScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDistanceScores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridDistanceScores.Location = new System.Drawing.Point(3, 3);
            this.dataGridDistanceScores.Name = "dataGridDistanceScores";
            this.dataGridDistanceScores.ReadOnly = true;
            this.dataGridDistanceScores.RowHeadersVisible = false;
            this.dataGridDistanceScores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridDistanceScores.Size = new System.Drawing.Size(240, 150);
            this.dataGridDistanceScores.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1266, 658);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Reports";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1274, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "THE VANU; THEY\'RE HERE TOO!!!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColumnUID
            // 
            this.ColumnUID.HeaderText = "UID";
            this.ColumnUID.Name = "ColumnUID";
            this.ColumnUID.ReadOnly = true;
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
            // EventFAI_CP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EventFAI_CP";
            this.Size = new System.Drawing.Size(1280, 720);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanelAccuracy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAccuracyScores)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanelSpeed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSpeedScores)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanelDistance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDistanceScores)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAccuracy;
        private System.Windows.Forms.DataGridView dataGridAccuracyScores;
        private System.Windows.Forms.Button inputAccuracyNextRound;
        private System.Windows.Forms.Button inputClose1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSpeed;
        private System.Windows.Forms.DataGridView dataGridSpeedScores;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDistance;
        private System.Windows.Forms.DataGridView dataGridDistanceScores;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;

    }
}
