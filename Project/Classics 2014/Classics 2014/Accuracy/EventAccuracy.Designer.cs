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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlEvent = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelLatestScore = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.listBoxScores = new System.Windows.Forms.ListBox();
            this.dataGridViewScore = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRemoveLanding = new System.Windows.Forms.Button();
            this.buttonNextRound = new System.Windows.Forms.Button();
            this.buttonMakeActive = new System.Windows.Forms.Button();
            this.buttonEditLanding = new System.Windows.Forms.Button();
            this.buttonRenameCompetitor = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ColumnUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIntermixTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRound1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlEvent.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScore)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1266, 768);
            this.tableLayoutPanel1.TabIndex = 0;
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
            // listBoxScores
            // 
            this.listBoxScores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxScores.FormattingEnabled = true;
            this.listBoxScores.Location = new System.Drawing.Point(1015, 153);
            this.listBoxScores.Name = "listBoxScores";
            this.tableLayoutPanel1.SetRowSpan(this.listBoxScores, 2);
            this.listBoxScores.Size = new System.Drawing.Size(248, 612);
            this.listBoxScores.TabIndex = 2;
            // 
            // dataGridViewScore
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
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
            this.ColumnRound1});
            this.dataGridViewScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewScore.Location = new System.Drawing.Point(3, 53);
            this.dataGridViewScore.MultiSelect = false;
            this.dataGridViewScore.Name = "dataGridViewScore";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewScore, 2);
            this.dataGridViewScore.RowTemplate.Height = 20;
            this.dataGridViewScore.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewScore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewScore.Size = new System.Drawing.Size(1006, 662);
            this.dataGridViewScore.TabIndex = 1;
            this.dataGridViewScore.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewScore_CellMouseClick);
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonRemoveLanding, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonNextRound, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonMakeActive, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonEditLanding, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonRenameCompetitor, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonClose, 6, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 721);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1006, 44);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // buttonRemoveLanding
            // 
            this.buttonRemoveLanding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRemoveLanding.Location = new System.Drawing.Point(206, 3);
            this.buttonRemoveLanding.Name = "buttonRemoveLanding";
            this.buttonRemoveLanding.Size = new System.Drawing.Size(94, 38);
            this.buttonRemoveLanding.TabIndex = 0;
            this.buttonRemoveLanding.Text = "Remove Landing";
            this.buttonRemoveLanding.UseVisualStyleBackColor = true;
            // 
            // buttonNextRound
            // 
            this.buttonNextRound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNextRound.Location = new System.Drawing.Point(306, 3);
            this.buttonNextRound.Name = "buttonNextRound";
            this.buttonNextRound.Size = new System.Drawing.Size(94, 38);
            this.buttonNextRound.TabIndex = 1;
            this.buttonNextRound.Text = "Next Round";
            this.buttonNextRound.UseVisualStyleBackColor = true;
            // 
            // buttonMakeActive
            // 
            this.buttonMakeActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMakeActive.Location = new System.Drawing.Point(406, 3);
            this.buttonMakeActive.Name = "buttonMakeActive";
            this.buttonMakeActive.Size = new System.Drawing.Size(94, 38);
            this.buttonMakeActive.TabIndex = 2;
            this.buttonMakeActive.Text = "Toggle Active";
            this.buttonMakeActive.UseVisualStyleBackColor = true;
            this.buttonMakeActive.Click += new System.EventHandler(this.buttonMakeActive_Click);
            // 
            // buttonEditLanding
            // 
            this.buttonEditLanding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditLanding.Location = new System.Drawing.Point(506, 3);
            this.buttonEditLanding.Name = "buttonEditLanding";
            this.buttonEditLanding.Size = new System.Drawing.Size(94, 38);
            this.buttonEditLanding.TabIndex = 3;
            this.buttonEditLanding.Text = "Edit Landing";
            this.buttonEditLanding.UseVisualStyleBackColor = true;
            // 
            // buttonRenameCompetitor
            // 
            this.buttonRenameCompetitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRenameCompetitor.Location = new System.Drawing.Point(606, 3);
            this.buttonRenameCompetitor.Name = "buttonRenameCompetitor";
            this.buttonRenameCompetitor.Size = new System.Drawing.Size(94, 38);
            this.buttonRenameCompetitor.TabIndex = 4;
            this.buttonRenameCompetitor.Text = "Rename Competitor";
            this.buttonRenameCompetitor.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClose.Location = new System.Drawing.Point(706, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(94, 38);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.ColumnTeam.Visible = false;
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
            // ColumnRound1
            // 
            this.ColumnRound1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnRound1.HeaderText = "Round 1";
            this.ColumnRound1.Name = "ColumnRound1";
            this.ColumnRound1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnRound1.Width = 73;
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
            this.tableLayoutPanel2.ResumeLayout(false);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonRemoveLanding;
        private System.Windows.Forms.Button buttonNextRound;
        private System.Windows.Forms.Button buttonMakeActive;
        private System.Windows.Forms.Button buttonEditLanding;
        private System.Windows.Forms.Button buttonRenameCompetitor;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIntermixTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRound1;
    }
}
