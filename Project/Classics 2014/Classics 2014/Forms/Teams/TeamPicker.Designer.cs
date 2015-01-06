namespace CMS.Forms
{
    partial class TeamPicker
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
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.inputAssignDefault = new System.Windows.Forms.Button();
            this.inputAddTeam = new System.Windows.Forms.Button();
            this.inputRemoveTeam = new System.Windows.Forms.Button();
            this.inputFillRemaining = new System.Windows.Forms.Button();
            this.inputSwitchStyle = new System.Windows.Forms.Button();
            this.inputFilterOption = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.inputSaveAndContinue = new System.Windows.Forms.Button();
            this.inputSave = new System.Windows.Forms.Button();
            this.inputCancel = new System.Windows.Forms.Button();
            this.tableLayoutMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 3;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutMain.Controls.Add(this.inputAssignDefault, 0, 1);
            this.tableLayoutMain.Controls.Add(this.inputAddTeam, 0, 3);
            this.tableLayoutMain.Controls.Add(this.inputRemoveTeam, 0, 4);
            this.tableLayoutMain.Controls.Add(this.inputFillRemaining, 0, 5);
            this.tableLayoutMain.Controls.Add(this.inputSwitchStyle, 0, 6);
            this.tableLayoutMain.Controls.Add(this.tableLayoutPanel1, 0, 8);
            this.tableLayoutMain.Controls.Add(this.inputFilterOption, 0, 2);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 9;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // inputAssignDefault
            // 
            this.inputAssignDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.inputAssignDefault, 2);
            this.inputAssignDefault.Location = new System.Drawing.Point(3, 103);
            this.inputAssignDefault.Name = "inputAssignDefault";
            this.inputAssignDefault.Size = new System.Drawing.Size(186, 23);
            this.inputAssignDefault.TabIndex = 0;
            this.inputAssignDefault.Text = "Assign to Default Teams";
            this.inputAssignDefault.UseVisualStyleBackColor = true;
            // 
            // inputAddTeam
            // 
            this.inputAddTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.inputAddTeam, 2);
            this.inputAddTeam.Location = new System.Drawing.Point(3, 163);
            this.inputAddTeam.Name = "inputAddTeam";
            this.inputAddTeam.Size = new System.Drawing.Size(186, 23);
            this.inputAddTeam.TabIndex = 2;
            this.inputAddTeam.Text = "Add Team";
            this.inputAddTeam.UseVisualStyleBackColor = true;
            // 
            // inputRemoveTeam
            // 
            this.inputRemoveTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.inputRemoveTeam, 2);
            this.inputRemoveTeam.Location = new System.Drawing.Point(3, 193);
            this.inputRemoveTeam.Name = "inputRemoveTeam";
            this.inputRemoveTeam.Size = new System.Drawing.Size(186, 23);
            this.inputRemoveTeam.TabIndex = 3;
            this.inputRemoveTeam.Text = "Remove Team";
            this.inputRemoveTeam.UseVisualStyleBackColor = true;
            // 
            // inputFillRemaining
            // 
            this.inputFillRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.inputFillRemaining, 2);
            this.inputFillRemaining.Location = new System.Drawing.Point(3, 223);
            this.inputFillRemaining.Name = "inputFillRemaining";
            this.inputFillRemaining.Size = new System.Drawing.Size(186, 23);
            this.inputFillRemaining.TabIndex = 4;
            this.inputFillRemaining.Text = "Fill Remaining Teams";
            this.inputFillRemaining.UseVisualStyleBackColor = true;
            // 
            // inputSwitchStyle
            // 
            this.inputSwitchStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.inputSwitchStyle, 2);
            this.inputSwitchStyle.Location = new System.Drawing.Point(3, 253);
            this.inputSwitchStyle.Name = "inputSwitchStyle";
            this.inputSwitchStyle.Size = new System.Drawing.Size(186, 23);
            this.inputSwitchStyle.TabIndex = 5;
            this.inputSwitchStyle.Text = "Switch View";
            this.inputSwitchStyle.UseVisualStyleBackColor = true;
            // 
            // inputFilterOption
            // 
            this.inputFilterOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.inputFilterOption, 2);
            this.inputFilterOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputFilterOption.FormattingEnabled = true;
            this.inputFilterOption.Items.AddRange(new object[] {
            "Show Both",
            "Show Full Only",
            "Show Not-Full Only",
            "Highlight Both",
            "Highlight Full",
            "Highlight Not-Full"});
            this.inputFilterOption.Location = new System.Drawing.Point(3, 134);
            this.inputFilterOption.Name = "inputFilterOption";
            this.inputFilterOption.Size = new System.Drawing.Size(186, 21);
            this.inputFilterOption.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutMain.SetColumnSpan(this.tableLayoutPanel1, 3);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.inputSaveAndContinue, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputSave, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputCancel, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 683);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(346, 34);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // inputSaveAndContinue
            // 
            this.inputSaveAndContinue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSaveAndContinue.Location = new System.Drawing.Point(3, 8);
            this.inputSaveAndContinue.Name = "inputSaveAndContinue";
            this.inputSaveAndContinue.Size = new System.Drawing.Size(109, 23);
            this.inputSaveAndContinue.TabIndex = 0;
            this.inputSaveAndContinue.Text = "Save + Continue";
            this.inputSaveAndContinue.UseVisualStyleBackColor = true;
            // 
            // inputSave
            // 
            this.inputSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSave.Location = new System.Drawing.Point(118, 8);
            this.inputSave.Name = "inputSave";
            this.inputSave.Size = new System.Drawing.Size(109, 23);
            this.inputSave.TabIndex = 1;
            this.inputSave.Text = "Save";
            this.inputSave.UseVisualStyleBackColor = true;
            // 
            // inputCancel
            // 
            this.inputCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inputCancel.Location = new System.Drawing.Point(233, 8);
            this.inputCancel.Name = "inputCancel";
            this.inputCancel.Size = new System.Drawing.Size(110, 23);
            this.inputCancel.TabIndex = 2;
            this.inputCancel.Text = "Cancel";
            this.inputCancel.UseVisualStyleBackColor = true;
            // 
            // TeamPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutMain);
            this.Name = "TeamPicker";
            this.Size = new System.Drawing.Size(1280, 720);
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Button inputAssignDefault;
        private System.Windows.Forms.Button inputAddTeam;
        private System.Windows.Forms.Button inputRemoveTeam;
        private System.Windows.Forms.Button inputFillRemaining;
        private System.Windows.Forms.Button inputSwitchStyle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button inputSaveAndContinue;
        private System.Windows.Forms.Button inputSave;
        private System.Windows.Forms.Button inputCancel;
        private System.Windows.Forms.ComboBox inputFilterOption;
    }
}
