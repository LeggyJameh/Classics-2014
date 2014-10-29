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
        public Label MainLabel;
        public ModifyName()
        {
            InitializeComponent();
            MainLabel = label1;
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

    partial class CustomMessageBox
    {
        public static string Show(ModifyNameTypes Type)
        {
            using (var form = new ModifyName())
            {
                switch (Type)
                {
                    case ModifyNameTypes.Competitor: form.MainLabel.Text = "What would you like to set the competitor's name to?"; break;
                    case ModifyNameTypes.Scoring_Team: form.MainLabel.Text = "What would you like to set the scoring team's name to?"; break;
                    case ModifyNameTypes.Team: form.MainLabel.Text = "What would you like to set the team's name to?"; break;
                }
                form.ShowDialog();
                {
                    return form.NewName;
                }
            }
        }
    }
}
