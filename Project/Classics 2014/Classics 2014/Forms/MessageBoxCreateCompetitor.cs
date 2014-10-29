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
    internal partial class MessageBoxCreateCompetitor : Form
    {
        public Competitor Competitor = new Competitor();
        Classics_2014.MySQL.SQL_Controller SQL_Controller;
        public MessageBoxCreateCompetitor(Classics_2014.MySQL.SQL_Controller SQL_Controller)
        {
            InitializeComponent();
            inputName.Focus();
            this.SQL_Controller = SQL_Controller;
        }

        public MessageBoxCreateCompetitor()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (
                inputName.Text != "" &&
                inputNationality.Text != "" &&
                inputTeam.Text != "")
            {
                Competitor.name = inputName.Text;
                Competitor.nationality = inputNationality.Text;
                Competitor.team = inputTeam.Text;
                if (SQL_Controller.DoesCompetitorExist(Competitor) != true)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Competitor already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    partial class CustomMessageBox
    {
        /// <summary>
        /// Create Competitor
        /// </summary>
        /// <param name="SQL_Controller"></param>
        /// <returns></returns>
        public static Competitor Show(Classics_2014.MySQL.SQL_Controller SQL_Controller, int Blarg)
        {
            using (var form = new MessageBoxCreateCompetitor(SQL_Controller))
            {
                form.ShowDialog();
                {
                    return form.Competitor;
                }
            }
        }
    }
}
