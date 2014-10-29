namespace Classics_2014.Accuracy.Reports
{
    partial class TeamReport
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.hiddenUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.competitorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoringTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonDock = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.groupBoxPrint = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonDeselct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxPrint.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxPrint);
            this.splitContainer1.Size = new System.Drawing.Size(850, 542);
            this.splitContainer1.SplitterDistance = 752;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hiddenUID,
            this.competitorName,
            this.Nationality,
            this.ScoringTeam});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(752, 542);
            this.dataGridView1.TabIndex = 1;
            // 
            // hiddenUID
            // 
            this.hiddenUID.HeaderText = "uid";
            this.hiddenUID.Name = "hiddenUID";
            this.hiddenUID.ReadOnly = true;
            this.hiddenUID.Visible = false;
            this.hiddenUID.Width = 46;
            // 
            // competitorName
            // 
            this.competitorName.HeaderText = "Competitor Name";
            this.competitorName.Name = "competitorName";
            this.competitorName.ReadOnly = true;
            // 
            // Nationality
            // 
            this.Nationality.HeaderText = "Nationality";
            this.Nationality.Name = "Nationality";
            this.Nationality.ReadOnly = true;
            // 
            // ScoringTeam
            // 
            this.ScoringTeam.HeaderText = "Scoring Team";
            this.ScoringTeam.Name = "ScoringTeam";
            this.ScoringTeam.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonDock);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 141);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(94, 47);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // buttonDock
            // 
            this.buttonDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDock.Location = new System.Drawing.Point(3, 16);
            this.buttonDock.Name = "buttonDock";
            this.buttonDock.Size = new System.Drawing.Size(88, 28);
            this.buttonDock.TabIndex = 0;
            this.buttonDock.Text = "Undock";
            this.buttonDock.UseVisualStyleBackColor = true;
            this.buttonDock.Click += new System.EventHandler(this.buttonUndock_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(94, 47);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Location = new System.Drawing.Point(3, 16);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 28);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonPrint);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 47);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrint.Location = new System.Drawing.Point(3, 16);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(88, 28);
            this.buttonPrint.TabIndex = 0;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // groupBoxPrint
            // 
            this.groupBoxPrint.Controls.Add(this.buttonClose);
            this.groupBoxPrint.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxPrint.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPrint.Name = "groupBoxPrint";
            this.groupBoxPrint.Size = new System.Drawing.Size(94, 47);
            this.groupBoxPrint.TabIndex = 0;
            this.groupBoxPrint.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClose.Location = new System.Drawing.Point(3, 16);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 28);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonDeselct);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 188);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(94, 47);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // buttonDeselct
            // 
            this.buttonDeselct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeselct.Location = new System.Drawing.Point(3, 16);
            this.buttonDeselct.Name = "buttonDeselct";
            this.buttonDeselct.Size = new System.Drawing.Size(88, 28);
            this.buttonDeselct.TabIndex = 0;
            this.buttonDeselct.Text = "Deselect";
            this.buttonDeselct.UseVisualStyleBackColor = true;
            this.buttonDeselct.Click += new System.EventHandler(this.buttonDeselct_Click);
            // 
            // TeamReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TeamReport";
            this.Size = new System.Drawing.Size(850, 542);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxPrint.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxPrint;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiddenUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn competitorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoringTeam;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonDock;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonDeselct;

    }
}
