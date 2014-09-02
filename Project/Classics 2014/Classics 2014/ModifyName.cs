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
    internal partial class ModifyName : Form
    {
        public string NewName;
        public ModifyName()
        {
            InitializeComponent();
            textBoxName.Focus();
            this.textBoxName.KeyDown += new KeyEventHandler(numericUpDownScore_KeyDown);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            NewName = textBoxName.Text;
            this.Close();
        }

        private void numericUpDownScore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonOk.PerformClick();
            }
        }

    }

    public partial class CustomMessageBox
    {
        public static string Show()
        {
            // using construct ensures the resources are freed when form is closed
            using (var form = new ModifyName())
            {
                form.ShowDialog();
                {
                    return form.NewName;
                }
            }
        }
    }
}
