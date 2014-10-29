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
    partial class StandardOptionsPage : UserControl
    {
        windGraphingControllercs windGraph;
        TabControl tabControl;
        public StandardOptionsPage(windGraphingControllercs windGraph, TabControl tabControl)
        {
            this.tabControl = tabControl;
            this.windGraph = windGraph;
            InitializeComponent();
            listBoxOptionsMenu.SelectedIndex = 0;

            //ToDo Add
        }

        private void listBoxOptionsMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitContainerOptions.Panel2.Controls.Clear();

            switch (listBoxOptionsMenu.SelectedItem.ToString())
            {
                case "Common Display":
                    CommonDisplayOptions optionsDisplay = new CommonDisplayOptions( windGraph);
                    optionsDisplay.Dock = DockStyle.Fill;
                    splitContainerOptions.Panel2.Controls.Add(optionsDisplay);
                    break;
                case "Accuracy":
                    Accuracy.AccuracyOptionsMenu aOptionsMenu = new Accuracy.AccuracyOptionsMenu();
                    aOptionsMenu.Dock = DockStyle.Fill;
                    splitContainerOptions.Panel2.Controls.Add(aOptionsMenu);
                    break;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove((TabPage)this.Parent);
        }
    }
}
