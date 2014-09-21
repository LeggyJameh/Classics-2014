using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classics_2014
{
    internal partial class ModifyLanding : Form
    {
        public int NewScore;
        public ModifyLanding()
        {
            InitializeComponent();
        }

        public ModifyLanding(int MaxScore)
        {
            InitializeComponent();
            numericUpDownScore.Maximum = MaxScore;
            numericUpDownScore.Focus();
            this.numericUpDownScore.KeyDown += new KeyEventHandler(numericUpDownScore_KeyDown);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            NewScore = Convert.ToInt16(numericUpDownScore.Value);
            this.Close();
        }

        private void numericUpDownScore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonOk.PerformClick();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            NewScore = -1;
            this.Close();
        }

    }

    public partial class CustomMessageBox
    {
        public static int Show(int MaxScore)
        {
            // using construct ensures the resources are freed when form is closed
            using (var form = new ModifyLanding(MaxScore))
            {
                form.ShowDialog();
                {
                    return form.NewScore;
                }
            }
        }
    }
}
