using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomMessageBox;

namespace CMS
{
    static class MessageBoxes
    {
        public static Competitor CreateCompetitor(List<string> selectedTeams)
        {
            Competitor currentCompetitor = new Competitor();
            string[] strings = new string[3];
            strings[0] = "Name:";
            strings[1] = "Nationality:";
            strings[2] = "Team:";

            ComboBox cb = new ComboBox();
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 0; i < selectedTeams.Count; i++)
            {
                cb.Items.Add(selectedTeams[i]);
            }
            if (cb.Items.Count > 0)
            {
                cb.SelectedItem = cb.Items[0];
            }

            List<object> outputs = CustomMessageBox.CustomMessageBox.Show("Create competitor", Properties.Resources.Icon, strings, new TextBox(), new TextBox(), cb);
            if (outputs != null)
            {
                currentCompetitor.name = outputs[0].ToString();
                currentCompetitor.nationality = outputs[1].ToString();
                currentCompetitor.team = outputs[2].ToString();
                return currentCompetitor;
            }
            else
            {
                return null;
            }
        }

        public static string CreateTeam()
        {
            string teamName;
            string[] strings = new string[1];
            strings[0] = "Team name:";
            List<object> outputs = CustomMessageBox.CustomMessageBox.Show("Add Team", Properties.Resources.Icon, strings, new TextBox());

            if (outputs != null)
            {
                teamName = (string)outputs[0];
                return teamName;
            }
            else
            {
                return null;
            }
        }

        public static string ModifyTeamName()
        {
            string teamName;
            string[] strings = new string[1];
            strings[0] = "Team name:";
            List<object> outputs = CustomMessageBox.CustomMessageBox.Show("Modify Team", Properties.Resources.Icon, strings, new TextBox());

            if (outputs != null)
            {
                teamName = (string)outputs[0];
                return teamName;
            }
            else
            {
                return null;
            }
        }

        public static string SwitchTeam(List<string> possibleTeams, string previousTeam)
        {
            string finalTeam;
            string[] strings = new string[1];
            strings[0] = "Assign competitors to team:";
            ComboBox cb = new ComboBox();
            foreach (string s in possibleTeams)
            {
                cb.Items.Add(s);
            }
            List<object> outputs = CustomMessageBox.CustomMessageBox.Show("Assign team", Properties.Resources.Icon, strings, cb);

            if (outputs != null)
            {
                finalTeam = (string)outputs[0];
                return finalTeam;
            }
            else
            {
                return previousTeam;
            }
        }

        public static string ModifyCompetitorName()
        {
            string name;
            string[] strings = new string[1];
            strings[0] = "Name:";
            List<object> outputs = CustomMessageBox.CustomMessageBox.Show("Modify Competitor", Properties.Resources.Icon, strings, new TextBox());

            if (outputs != null)
            {
                name = (string)outputs[0];
                return name;
            }
            else
            {
                return null;
            }
        }

        public static Competitor ModifyCompetitor(string currentName, string currentNationality, string currentTeam, List<string> existingTeams)
        {
            Competitor currentCompetitor = new Competitor();
            string[] strings = new string[3];
            strings[0] = "Name:";
            strings[1] = "Nationality:";
            strings[2] = "Team:";

            ComboBox cb = new ComboBox();
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 0; i < existingTeams.Count; i++)
            {
                cb.Items.Add(existingTeams[i]);
            }
            cb.SelectedItem = currentTeam;

            TextBox tb1 = new TextBox();
            tb1.Text = currentName;

            TextBox tb2 = new TextBox();
            tb2.Text = currentNationality;

            List<object> outputs = CustomMessageBox.CustomMessageBox.Show("Create competitor", Properties.Resources.Icon, strings, tb1, tb2, cb);
            if (outputs != null)
            {
                currentCompetitor.name = outputs[0].ToString();
                currentCompetitor.nationality = outputs[1].ToString();
                currentCompetitor.team = outputs[2].ToString();
                return currentCompetitor;
            }
            else
            {
                return null;
            }
        }

        public static string filterString(string oldFilter)
        {
            string newFilter;

            string[] strings = new string[1];
            strings[0] = "Filter keyword:";

            TextBox tb = new TextBox();
            tb.Text = oldFilter;

            List<object> outputs = CustomMessageBox.CustomMessageBox.Show("Filter", Properties.Resources.Icon, strings, tb);

            if (outputs != null)
            {
                newFilter = (string)outputs[0];
                return newFilter;
            }
            else
            {
                return oldFilter;
            }
        }

        public static int ModifyScore(int originalScore, int maximumscore)
        {
            int score;
            string[] strings = new string[1];
            strings[0] = "New Score:";

            NumericUpDown nud = new NumericUpDown();
            nud.Minimum = 0;
            nud.Value = originalScore;
            nud.Maximum = maximumscore;
            nud.DecimalPlaces = 0;

            List<object> outputs = CustomMessageBox.CustomMessageBox.Show("Modify Score", Properties.Resources.Icon, strings, new NumericUpDown());

            if (outputs != null)
            {
                score = (int)outputs[0];
                return score;
            }
            else
            {
                return originalScore;
            }
        }
    }
}
