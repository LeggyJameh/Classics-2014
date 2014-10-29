namespace Classics_2014
{
    partial class DebugIOWINDOW
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownSpeed = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownDirection = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownScore = new System.Windows.Forms.NumericUpDown();
            this.buttonPassScore = new System.Windows.Forms.Button();
            this.buttonActivate = new System.Windows.Forms.Button();
            this.timerInput = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDirection)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScore)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownSpeed);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 39);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wind Speed";
            // 
            // numericUpDownSpeed
            // 
            this.numericUpDownSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownSpeed.Location = new System.Drawing.Point(3, 16);
            this.numericUpDownSpeed.Name = "numericUpDownSpeed";
            this.numericUpDownSpeed.Size = new System.Drawing.Size(152, 20);
            this.numericUpDownSpeed.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownDirection);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 39);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wind Direction";
            // 
            // numericUpDownDirection
            // 
            this.numericUpDownDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownDirection.Location = new System.Drawing.Point(3, 16);
            this.numericUpDownDirection.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownDirection.Name = "numericUpDownDirection";
            this.numericUpDownDirection.Size = new System.Drawing.Size(152, 20);
            this.numericUpDownDirection.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownScore);
            this.groupBox3.Location = new System.Drawing.Point(12, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(86, 39);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Score";
            // 
            // numericUpDownScore
            // 
            this.numericUpDownScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownScore.Location = new System.Drawing.Point(3, 16);
            this.numericUpDownScore.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownScore.Name = "numericUpDownScore";
            this.numericUpDownScore.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownScore.TabIndex = 7;
            // 
            // buttonPassScore
            // 
            this.buttonPassScore.Location = new System.Drawing.Point(104, 115);
            this.buttonPassScore.Name = "buttonPassScore";
            this.buttonPassScore.Size = new System.Drawing.Size(75, 23);
            this.buttonPassScore.TabIndex = 4;
            this.buttonPassScore.Text = "Pass Score";
            this.buttonPassScore.UseVisualStyleBackColor = true;
            this.buttonPassScore.Click += new System.EventHandler(this.buttonPassScore_Click);
            // 
            // buttonActivate
            // 
            this.buttonActivate.BackColor = System.Drawing.Color.Red;
            this.buttonActivate.Location = new System.Drawing.Point(12, 144);
            this.buttonActivate.Name = "buttonActivate";
            this.buttonActivate.Size = new System.Drawing.Size(167, 23);
            this.buttonActivate.TabIndex = 5;
            this.buttonActivate.Text = "Press to activate";
            this.buttonActivate.UseVisualStyleBackColor = false;
            this.buttonActivate.Click += new System.EventHandler(this.buttonActivate_Click);
            // 
            // timerInput
            // 
            this.timerInput.Interval = 1000;
            this.timerInput.Tick += new System.EventHandler(this.timerInput_Tick);
            // 
            // DebugIOWINDOW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 169);
            this.Controls.Add(this.buttonActivate);
            this.Controls.Add(this.buttonPassScore);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebugIOWINDOW";
            this.Opacity = 0.5D;
            this.ShowIcon = false;
            this.Text = "DebugIOWINDOW";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDirection)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownSpeed;
        private System.Windows.Forms.NumericUpDown numericUpDownDirection;
        private System.Windows.Forms.NumericUpDown numericUpDownScore;
        private System.Windows.Forms.Button buttonPassScore;
        private System.Windows.Forms.Button buttonActivate;
        private System.Windows.Forms.Timer timerInput;
    }
}