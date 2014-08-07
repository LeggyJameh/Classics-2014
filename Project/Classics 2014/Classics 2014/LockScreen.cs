using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Classics_2014
{
    class LockScreen : Form
    {
        
        public LockScreen( Form tocover)
        {
            InitializeComponent();
            this.BackColor = Color.DarkGray;
            this.Opacity = 0.70;      // If I have made this too visible/Dificult to see through, ya can edit it 
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.AutoScaleMode = AutoScaleMode.None;
            this.Location = tocover.PointToScreen(Point.Empty);
            this.ClientSize = tocover.ClientSize;
            tocover.LocationChanged += Cover_LocationChanged;
            tocover.ClientSizeChanged += Cover_ClientSizeChanged;
            this.Show(tocover);
            tocover.Focus();
            textBoxPassWordInput.Focus();
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int value = 1;
                DwmSetWindowAttribute(tocover.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }
        }
        private void Cover_LocationChanged(object sender, EventArgs e)
        {
            this.Location = this.Owner.PointToScreen(Point.Empty);
        }
        private void Cover_ClientSizeChanged(object sender, EventArgs e)
        {
            this.ClientSize = this.Owner.ClientSize;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Restore owner
            Main form =(Main) this.Owner;
            form.Locked = false;
            form.Enabled = true;
            this.Owner.LocationChanged -= Cover_LocationChanged;
            this.Owner.ClientSizeChanged -= Cover_ClientSizeChanged;
            if (!this.Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
            {
                int value = 1;
                DwmSetWindowAttribute(this.Owner.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }
            base.OnFormClosing(e);
        }
        private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);

        private void InitializeComponent()
        {
            this.textBoxPassWordInput = new System.Windows.Forms.TextBox();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPassWordInput
            // 
            this.textBoxPassWordInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPassWordInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxPassWordInput.Location = new System.Drawing.Point(72, 90);
            this.textBoxPassWordInput.Name = "textBoxPassWordInput";
            this.textBoxPassWordInput.PasswordChar = '*';
            this.textBoxPassWordInput.Size = new System.Drawing.Size(144, 20);
            this.textBoxPassWordInput.TabIndex = 0;
            this.textBoxPassWordInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPassWordInput_KeyDown);
            this.textBoxPassWordInput.Leave += new System.EventHandler(this.textBoxPassWordInput_Leave);
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonUnlock.Location = new System.Drawing.Point(102, 116);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(75, 23);
            this.buttonUnlock.TabIndex = 1;
            this.buttonUnlock.Text = "Unlock";
            this.buttonUnlock.UseVisualStyleBackColor = true;
            this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
            // 
            // LockScreen
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttonUnlock);
            this.Controls.Add(this.textBoxPassWordInput);
            this.Name = "LockScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox textBoxPassWordInput;
        private Button buttonUnlock;

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            if (textBoxPassWordInput.Text == UserSettings.Default.userLockPassword)
            {
                
                this.Close();
            }
        }

        private void textBoxPassWordInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                buttonUnlock_Click(new object(), new EventArgs());
            }
        }

        private void textBoxPassWordInput_Leave(object sender, EventArgs e)
        {
            textBoxPassWordInput.Focus();
        }

    }
}