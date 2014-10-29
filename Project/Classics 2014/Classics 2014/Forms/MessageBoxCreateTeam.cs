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
    internal partial class MessageBoxCreateTeam : Form
    {
        public string Team;
        Classics_2014.MySQL.SQL_Controller SQL_Controller;
        public MessageBoxCreateTeam(Classics_2014.MySQL.SQL_Controller SQL_Controller)
        {
            InitializeComponent();
            inputName.Focus();
            this.SQL_Controller = SQL_Controller;
        }

        public MessageBoxCreateTeam()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (
                inputName.Text != "")
            {
                Team = inputName.Text;
                if (SQL_Controller.DoesTeamExist(Team) != true)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Team already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    partial class CustomMessageBox
    {
        /// <summary>
        /// Create Team
        /// </summary>
        /// <param name="SQL_Controller"></param>
        /// <returns></returns>
        public static string Show(Classics_2014.MySQL.SQL_Controller SQL_Controller)
        {
            using (var form = new MessageBoxCreateTeam(SQL_Controller))
            {
                form.ShowDialog();
                {
                    return form.Team;
                }
            }
        }
    }
}
