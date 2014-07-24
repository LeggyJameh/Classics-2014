using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace Classics_2014
{
    public partial class Main : Form
    {
        Engine MainEngine;
        public Main()
        {
            InitializeComponent();
            MainEngine = new Engine(this, tabControl);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCompetition_Click(object sender, EventArgs e)
        {
            TabPage NewPage = new TabPage();
           Classics_2014.Accuracy.EventAccuracyOptions EventTab = MainEngine.StartNewAccuracyEvent();
            NewPage.Controls.Add(EventTab);
            EventTab.Dock = DockStyle.Fill;
            NewPage.Text = "New Event";
            tabControl.TabPages.Add(NewPage);
            tabControl.SelectedTab = NewPage;
        }
        public void UpdateWind(TWind windData)
        {
            
        }
    }
}
