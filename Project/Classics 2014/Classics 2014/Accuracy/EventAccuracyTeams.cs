using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classics_2014.Accuracy
{
    public partial class EventAccuracyTeams : UserControl
    {
        int NoOfIntermixTeams;
        List<TCompetitor> Competitors;
        int EventID;
        int CompetitorsPerTeam;
        public EventAccuracyTeams(List<TCompetitor> PassCompetitors, int PassEventID, int PassCompetitorsPerTeam)
        {
            CompetitorsPerTeam = PassCompetitorsPerTeam;
            EventID = PassEventID;
            Competitors = PassCompetitors;
            InitializeComponent();
            NoOfIntermixTeams = 0;
        }

        private void buttonAddTeam_Click(object sender, EventArgs e)
        {
            NoOfIntermixTeams++;
            listBoxTeams.Items.Add("Intermix Team " + NoOfIntermixTeams);
        }

        private void buttonRemoveTeam_Click(object sender, EventArgs e)
        {
            listBoxTeams.Items.Remove(listBoxTeams.Items[NoOfIntermixTeams-1]);
            UpdateTeamSelection(NoOfIntermixTeams);
            NoOfIntermixTeams--;
        }

        private void UpdateTeamSelection(int TeamRemoved)
        {
            comboBoxTeamSelection.Items.Clear();
            for (int i = 0; i < listBoxTeams.Items.Count; i++)
            {
                comboBoxTeamSelection.Items.Add(listBoxTeams.Items[i]);   
            }

            for (int i = 0; i < dataGridViewCompetitors.Rows.Count - 1; i++)
            {
                if (dataGridViewCompetitors[4, i].ToString() == ("Intermix Team " + TeamRemoved))
                {
                    dataGridViewCompetitors[4, i].Value = "";
                }
            }
        }
    }
}
