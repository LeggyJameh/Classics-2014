namespace Classics_2014.Accuracy
{
    partial class EventAccuracy
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
            this.tabControlEvent = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelName = new System.Windows.Forms.Label();
            this.dataGridViewScore = new System.Windows.Forms.DataGridView();
            this.listBoxScores = new System.Windows.Forms.ListBox();
            this.ColumnUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIntermixTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssign = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLatestScore = new System.Windows.Forms.Label();
            this.tabControlEvent.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScore)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlEvent
            // 
            this.tabControlEvent.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlEvent.Controls.Add(this.tabPage1);
            this.tabControlEvent.Controls.Add(this.tabPage2);
            this.tabControlEvent.Controls.Add(this.tabPage3);
            this.tabControlEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEvent.Location = new System.Drawing.Point(0, 0);
            this.tabControlEvent.Name = "tabControlEvent";
            this.tabControlEvent.SelectedIndex = 0;
            this.tabControlEvent.Size = new System.Drawing.Size(1280, 800);
            this.tabControlEvent.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1272, 774);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scores";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1272, 774);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Teams";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1272, 774);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Reports";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.labelLatestScore, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxScores, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewScore, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1266, 768);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(3, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(1006, 50);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Accuracy Event --";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewScore
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dataGridViewScore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewScore.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnUID,
            this.ColumnName,
            this.ColumnTeam,
            this.ColumnNationality,
            this.ColumnIntermixTeam,
            this.ColumnScore,
            this.ColumnAssign});
            this.dataGridViewScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewScore.Location = new System.Drawing.Point(3, 53);
            this.dataGridViewScore.MultiSelect = false;
            this.dataGridViewScore.Name = "dataGridViewScore";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewScore, 2);
            this.dataGridViewScore.RowTemplate.Height = 40;
            this.dataGridViewScore.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewScore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewScore.Size = new System.Drawing.Size(1006, 712);
            this.dataGridViewScore.TabIndex = 1;
            // 
            // listBoxScores
            // 
            this.listBoxScores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxScores.FormattingEnabled = true;
            this.listBoxScores.Location = new System.Drawing.Point(1015, 153);
            this.listBoxScores.Name = "listBoxScores";
            this.listBoxScores.Size = new System.Drawing.Size(248, 612);
            this.listBoxScores.TabIndex = 2;
            // 
            // ColumnUID
            // 
            this.ColumnUID.HeaderText = "ID";
            this.ColumnUID.Name = "ColumnUID";
            this.ColumnUID.ReadOnly = true;
            this.ColumnUID.Visible = false;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Competitor Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnTeam
            // 
            this.ColumnTeam.HeaderText = "Team";
            this.ColumnTeam.Name = "ColumnTeam";
            this.ColumnTeam.ReadOnly = true;
            // 
            // ColumnNationality
            // 
            this.ColumnNationality.HeaderText = "Nationality";
            this.ColumnNationality.Name = "ColumnNationality";
            this.ColumnNationality.ReadOnly = true;
            // 
            // ColumnIntermixTeam
            // 
            this.ColumnIntermixTeam.HeaderText = "Scoring Team";
            this.ColumnIntermixTeam.Name = "ColumnIntermixTeam";
            this.ColumnIntermixTeam.ReadOnly = true;
            // 
            // ColumnScore
            // 
            this.ColumnScore.HeaderText = "Score";
            this.ColumnScore.Name = "ColumnScore";
            this.ColumnScore.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnAssign
            // 
            this.ColumnAssign.HeaderText = "";
            this.ColumnAssign.Name = "ColumnAssign";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1015, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 50);
            this.label1.TabIndex = 3;
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
            this.labelLatestScore.Location = new System.Drawing.Point(1015, 50);
            this.labelLatestScore.Name = "labelLatestScore";
            this.labelLatestScore.Size = new System.Drawing.Size(248, 100);
            this.labelLatestScore.TabIndex = 4;
            this.labelLatestScore.Text = "--";
            this.labelLatestScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventAccuracy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlEvent);
            this.Name = "EventAccuracy";
            this.Size = new System.Drawing.Size(1280, 800);
            this.tabControlEvent.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlEvent;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.DataGridView dataGridViewScore;
        private System.Windows.Forms.ListBox listBoxScores;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label labelLatestScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIntermixTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnScore;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnAssign;
        private System.Windows.Forms.Label label1;
    }
}
