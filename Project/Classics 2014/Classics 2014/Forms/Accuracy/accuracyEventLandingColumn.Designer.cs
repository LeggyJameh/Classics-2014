namespace Classics_2014.Accuracy
{
    partial class accuracyEventLandingColumn
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanelLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRemoveLanding = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLatestScore = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewLandings = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanelLayout.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLandings)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelLayout
            // 
            this.tableLayoutPanelLayout.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelLayout.ColumnCount = 1;
            this.tableLayoutPanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLayout.Controls.Add(this.tableLayoutPanel3, 0, 4);
            this.tableLayoutPanelLayout.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelLayout.Controls.Add(this.labelLatestScore, 0, 1);
            this.tableLayoutPanelLayout.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanelLayout.Controls.Add(this.dataGridViewLandings, 0, 3);
            this.tableLayoutPanelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLayout.Name = "tableLayoutPanelLayout";
            this.tableLayoutPanelLayout.RowCount = 5;
            this.tableLayoutPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLayout.Size = new System.Drawing.Size(214, 658);
            this.tableLayoutPanelLayout.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.buttonRemoveLanding, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 613);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(208, 44);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // buttonRemoveLanding
            // 
            this.buttonRemoveLanding.Location = new System.Drawing.Point(57, 3);
            this.buttonRemoveLanding.Name = "buttonRemoveLanding";
            this.buttonRemoveLanding.Size = new System.Drawing.Size(94, 38);
            this.buttonRemoveLanding.TabIndex = 0;
            this.buttonRemoveLanding.Text = "Remove Landing";
            this.buttonRemoveLanding.UseVisualStyleBackColor = true;
            this.buttonRemoveLanding.Click += new System.EventHandler(this.buttonRemoveLanding_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 50);
            this.label1.TabIndex = 4;
            this.label1.Text = "Latest Score:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLatestScore
            // 
            this.labelLatestScore.AutoSize = true;
            this.labelLatestScore.BackColor = System.Drawing.Color.Black;
            this.labelLatestScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLatestScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLatestScore.ForeColor = System.Drawing.Color.White;
            this.labelLatestScore.Location = new System.Drawing.Point(3, 50);
            this.labelLatestScore.Name = "labelLatestScore";
            this.labelLatestScore.Size = new System.Drawing.Size(208, 50);
            this.labelLatestScore.TabIndex = 5;
            this.labelLatestScore.Text = "--";
            this.labelLatestScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Landings";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewLandings
            // 
            this.dataGridViewLandings.AllowUserToResizeColumns = false;
            this.dataGridViewLandings.AllowUserToResizeRows = false;
            this.dataGridViewLandings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLandings.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLandings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLandings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnTime,
            this.ColumnScore});
            this.dataGridViewLandings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLandings.Location = new System.Drawing.Point(3, 123);
            this.dataGridViewLandings.MultiSelect = false;
            this.dataGridViewLandings.Name = "dataGridViewLandings";
            this.dataGridViewLandings.RowHeadersVisible = false;
            this.dataGridViewLandings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLandings.Size = new System.Drawing.Size(208, 484);
            this.dataGridViewLandings.TabIndex = 9;
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Visible = false;
            // 
            // ColumnTime
            // 
            this.ColumnTime.HeaderText = "Time";
            this.ColumnTime.Name = "ColumnTime";
            this.ColumnTime.ReadOnly = true;
            // 
            // ColumnScore
            // 
            this.ColumnScore.HeaderText = "Score";
            this.ColumnScore.Name = "ColumnScore";
            this.ColumnScore.ReadOnly = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // accuracyEventLandingColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelLayout);
            this.Name = "accuracyEventLandingColumn";
            this.Size = new System.Drawing.Size(214, 658);
            this.tableLayoutPanelLayout.ResumeLayout(false);
            this.tableLayoutPanelLayout.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLandings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLatestScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewLandings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonRemoveLanding;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnScore;

    }
}
