using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS
{
    partial class StandardOptionsPage : UserControl
    {
        Main MainForm;
        UserControl rightControl;
        public StandardOptionsPage( Main main)
        {
            this.MainForm = main;
            InitializeComponent();
            listBoxOptionsMenu.SelectedIndex = 0;

            //ToDo Add
        }

        /// <summary>
        /// Fits the control to the correct place and dimensions on the options panel.
        /// </summary>
        private void fitControl()
        {
            rightControl.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(rightControl);
            tableLayoutPanel1.SetColumn(rightControl, 1);
            tableLayoutPanel1.SetRow(rightControl, 1);
            tableLayoutPanel1.SetRowSpan(rightControl, 2);
        }

        private void listBoxOptionsMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rightControl != null)
            {
                tableLayoutPanel1.Controls.Remove(rightControl);
                rightControl = null;
            }

            switch (listBoxOptionsMenu.SelectedItem.ToString())
            {
                case "Common Display":
                    CommonDisplayOptions optionsDisplay = new CommonDisplayOptions();
                    rightControl = optionsDisplay;
                    fitControl();
                    break;
                case "Accuracy":
                    Accuracy.AccuracyOptionsMenu aOptionsMenu = new Accuracy.AccuracyOptionsMenu();
                    aOptionsMenu.Dock = DockStyle.Fill;
                    rightControl = aOptionsMenu;
                    fitControl();
                    break;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            MainForm.removeTab((TabPage)this.Parent);
        }
    }
}
