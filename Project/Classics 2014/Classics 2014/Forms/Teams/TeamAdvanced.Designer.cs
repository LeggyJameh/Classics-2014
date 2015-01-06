namespace CMS.Forms.Teams
{
    partial class TeamAdvanced
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
            this.labelTeamName = new System.Windows.Forms.Label();
            this.inputShowHide = new System.Windows.Forms.Button();
            this.dataGridCompetitors = new System.Windows.Forms.DataGridView();
            this.pictureBoxTeamImage = new System.Windows.Forms.PictureBox();
            this.labelTeamCount = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompetitors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTeamImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.inputShowHide, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTeamName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridCompetitors, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxTeamImage, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTeamCount, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1044, 230);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelTeamName
            // 
            this.labelTeamName.AutoSize = true;
            this.labelTeamName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeamName.Location = new System.Drawing.Point(33, 0);
            this.labelTeamName.Name = "labelTeamName";
            this.labelTeamName.Size = new System.Drawing.Size(808, 30);
            this.labelTeamName.TabIndex = 1;
            this.labelTeamName.Text = "TEAM NAME";
            this.labelTeamName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // inputShowHide
            // 
            this.inputShowHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputShowHide.Location = new System.Drawing.Point(3, 3);
            this.inputShowHide.Name = "inputShowHide";
            this.inputShowHide.Size = new System.Drawing.Size(24, 24);
            this.inputShowHide.TabIndex = 0;
            this.inputShowHide.Text = "+";
            this.inputShowHide.UseVisualStyleBackColor = true;
            this.inputShowHide.Click += new System.EventHandler(this.inputShowHide_Click);
            // 
            // dataGridCompetitors
            // 
            this.dataGridCompetitors.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridCompetitors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridCompetitors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridCompetitors, 2);
            this.dataGridCompetitors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridCompetitors.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridCompetitors.Location = new System.Drawing.Point(3, 33);
            this.dataGridCompetitors.Name = "dataGridCompetitors";
            this.dataGridCompetitors.Size = new System.Drawing.Size(838, 194);
            this.dataGridCompetitors.TabIndex = 2;
            // 
            // pictureBoxTeamImage
            // 
            this.pictureBoxTeamImage.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxTeamImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTeamImage.Location = new System.Drawing.Point(847, 33);
            this.pictureBoxTeamImage.Name = "pictureBoxTeamImage";
            this.pictureBoxTeamImage.Size = new System.Drawing.Size(194, 194);
            this.pictureBoxTeamImage.TabIndex = 3;
            this.pictureBoxTeamImage.TabStop = false;
            // 
            // labelTeamCount
            // 
            this.labelTeamCount.AutoSize = true;
            this.labelTeamCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTeamCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeamCount.Location = new System.Drawing.Point(847, 0);
            this.labelTeamCount.Name = "labelTeamCount";
            this.labelTeamCount.Size = new System.Drawing.Size(194, 30);
            this.labelTeamCount.TabIndex = 4;
            this.labelTeamCount.Text = "0 / 5";
            this.labelTeamCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TeamAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TeamAdvanced";
            this.Size = new System.Drawing.Size(1044, 230);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompetitors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTeamImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTeamName;
        private System.Windows.Forms.Button inputShowHide;
        private System.Windows.Forms.DataGridView dataGridCompetitors;
        private System.Windows.Forms.PictureBox pictureBoxTeamImage;
        private System.Windows.Forms.Label labelTeamCount;

    }
}
