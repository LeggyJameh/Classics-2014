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
    internal partial class ApplyFilter : Form
    {
        public string keyWord;
        public Label MainLabel;
        public ApplyFilter()
        {
            InitializeComponent();
            MainLabel = label1;
            textBoxName.Focus();
            this.textBoxName.KeyDown += new KeyEventHandler(numericUpDownScore_KeyDown);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            keyWord = textBoxName.Text;
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

    partial class CustomMessageBox
    {
        /// <summary>
        /// Filter keyword
        /// </summary>
        /// <returns></returns>
        public static string Show()
        {
            using (var form = new ApplyFilter())
            {
                form.ShowDialog();
                {
                    return form.keyWord;
                }
            }
        }
    }
}
