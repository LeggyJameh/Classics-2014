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
        public static Competitor CreateCompetitor(List<string> selectedGroups)
        {
            Competitor currentCompetitor = new Competitor();
            string[] strings = new string[3];
            strings[0] = "Name:";
            strings[1] = "Nationality:";
            strings[2] = "Group:";

            ComboBox cb = new ComboBox();
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 0; i < selectedGroups.Count; i++)
            {
                cb.Items.Add(selectedGroups[i]);
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
                currentCompetitor.group = outputs[2].ToString();
                return currentCompetitor;
            }
            else
            {
                return null;
            }
        }

        public static string CreateGroup()
        {
            string groupName;
            string[] strings = new string[1];
            strings[0] = "Group name:";
            List<object> outputs = CustomMessageBox.CustomMessageBox.Show("Add Group", Properties.Resources.Icon, strings, new TextBox());

            if (outputs != null)
            {
                groupName = (string)outputs[0];
                return groupName;
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

        public static string ModifyGroupName()
        {
            string groupName;
            string[] strings = new string[1];
            strings[0] = "Group name:";
            List<object> outputs = CustomMessageBox.CustomMessageBox.Show("Modify Group", Properties.Resources.Icon, strings, new TextBox());

            if (outputs != null)
            {
                groupName = (string)outputs[0];
                return groupName;
            }
            else
            {
                return null;
            }
        }

        public static string SwitchGroup(List<string> possibleGroups, string previousGroup)
        {
            string finalGroup;
            string[] strings = new string[1];
            strings[0] = "Assign competitors to group:";
            ComboBox cb = new ComboBox();
            foreach (string s in possibleGroups)
            {
                cb.Items.Add(s);
            }
            List<object> outputs = CustomMessageBox.CustomMessageBox.Show("Assign group", Properties.Resources.Icon, strings, cb);

            if (outputs != null)
            {
                finalGroup = (string)outputs[0];
                return finalGroup;
            }
            else
            {
                return previousGroup;
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

        public static Competitor ModifyCompetitor(string currentName, string currentNationality, string currentGroup, List<string> existingGroups)
        {
            Competitor currentCompetitor = new Competitor();
            string[] strings = new string[3];
            strings[0] = "Name:";
            strings[1] = "Nationality:";
            strings[2] = "Group:";

            ComboBox cb = new ComboBox();
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 0; i < existingGroups.Count; i++)
            {
                cb.Items.Add(existingGroups[i]);
            }
            cb.SelectedItem = currentGroup;

            TextBox tb1 = new TextBox();
            tb1.Text = currentName;

            TextBox tb2 = new TextBox();
            tb2.Text = currentNationality;

            List<object> outputs = CustomMessageBox.CustomMessageBox.Show("Create competitor", Properties.Resources.Icon, strings, tb1, tb2, cb);
            if (outputs != null)
            {
                currentCompetitor.name = outputs[0].ToString();
                currentCompetitor.nationality = outputs[1].ToString();
                currentCompetitor.group = outputs[2].ToString();
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

        public static string underfilledTeamsCheck()
        {
            string result;

            string[] strings = new string[1];
            strings[0] = "Option:";

            ComboBox cb1 = new ComboBox();
            cb1.DropDownStyle = ComboBoxStyle.DropDownList;
            cb1.Items.Add("Fill teams");
            cb1.Items.Add("Leave teams");
            cb1.SelectedIndex = 0;

            List<object> outputs = CustomMessageBox.CustomMessageBox.Show("Teams underfilled", Properties.Resources.Icon, strings, cb1);

            if (outputs != null)
            {
                result = (string)outputs[0];
                return result;
            }
            else
            {
                return "Cancel";
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
