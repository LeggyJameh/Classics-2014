namespace Classics_2014
{
    partial class StandardOptionsPage
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
            this.splitContainerOptions = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.listBoxOptionsMenu = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOptions)).BeginInit();
            this.splitContainerOptions.Panel1.SuspendLayout();
            this.splitContainerOptions.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerOptions
            // 
            this.splitContainerOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOptions.Location = new System.Drawing.Point(0, 0);
            this.splitContainerOptions.Name = "splitContainerOptions";
            // 
            // splitContainerOptions.Panel1
            // 
            this.splitContainerOptions.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainerOptions.Size = new System.Drawing.Size(735, 489);
            this.splitContainerOptions.SplitterDistance = 89;
            this.splitContainerOptions.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonClose, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBoxOptionsMenu, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.27402F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.725971F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(89, 489);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClose.Location = new System.Drawing.Point(3, 464);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(83, 22);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // listBoxOptionsMenu
            // 
            this.listBoxOptionsMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxOptionsMenu.FormattingEnabled = true;
            this.listBoxOptionsMenu.Items.AddRange(new object[] {
            "Common Display",
            "Accuracy",
            "Style",
            "Paraski",
            "Speed",
            "Formation",
            "Canopy Piloting",
            "Canopy Formation"});
            this.listBoxOptionsMenu.Location = new System.Drawing.Point(3, 3);
            this.listBoxOptionsMenu.Name = "listBoxOptionsMenu";
            this.listBoxOptionsMenu.Size = new System.Drawing.Size(83, 455);
            this.listBoxOptionsMenu.TabIndex = 0;
            this.listBoxOptionsMenu.SelectedIndexChanged += new System.EventHandler(this.listBoxOptionsMenu_SelectedIndexChanged);
            // 
            // StandardOptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainerOptions);
            this.Name = "StandardOptionsPage";
            this.Size = new System.Drawing.Size(735, 489);
            this.splitContainerOptions.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOptions)).EndInit();
            this.splitContainerOptions.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerOptions;
        private System.Windows.Forms.ListBox listBoxOptionsMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonClose;
    }
}
