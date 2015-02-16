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
    partial class GroupManager : UserControl
    {
        Engine Engine;
        List<string> groups;
        List<int> groupMemberCount = new List<int>();
        CompetitorEditor returnCE;
        bool saved = true;

        public GroupManager(Engine engine, List<string> currentGroups, CompetitorEditor competitorEditor)
        {
            this.Engine = engine;
            this.groups = currentGroups;
            this.returnCE = competitorEditor;
            InitializeComponent();
            getMemberCounts();
            refreshGrid();
            saved = true;
        }

        private void getMemberCounts()
        {
            for (int i = 0; i < groups.Count; i++)
            {
                groupMemberCount.Add(Engine.SQL_Controller.GetNumberCompetitorsInGroup(groups[i]));
            }
        }

        private void refreshGrid()
        {
            dataGridGroups.Rows.Clear();
            for (int i = 0; i < groups.Count; i++)
            {
                dataGridGroups.Rows.Add(groups[i], groupMemberCount[i]);
            }
        }

        private void returnValues()
        {
            saved = true;
            returnCE.groupReturn(groups);
        }

        private void inputAddGroup_Click(object sender, EventArgs e)
        {
            string groupName = MessageBoxes.CreateGroup();
            if (groupName != "" && groupName != null)
            {
                bool unique = true;

                for (int i = 0; i < groups.Count; i++)
                {
                    if (groupName == groups[i])
                    {
                        unique = false;
                    }
                }

                if (unique)
                {
                    groups.Add(groupName);
                    groupMemberCount.Add(0);
                    refreshGrid();
                }
                else
                {
                    MessageBox.Show("Group name is already taken!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            saved = false;
        }

        private void inputRemoveGroup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to remove the selected groups?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dataGridGroups.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < dataGridGroups.SelectedRows.Count; i++)
                    {
                        groups.Remove(dataGridGroups.SelectedRows[i].Cells[0].Value.ToString());
                    }
                    refreshGrid();
                }
                else
                {
                    MessageBox.Show("No rows selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            saved = false;
        }

        private void inputSave_Click(object sender, EventArgs e)
        {
            returnValues();
        }

        private void inputExit_Click(object sender, EventArgs e)
        {
            if (saved)
            {
                Engine.mainForm.selectTab((TabPage)returnCE.Parent);
                Engine.mainForm.removeTab((TabPage)this.Parent);
            }
            else
            {
                DialogResult checker = MessageBox.Show("Save before exiting?", "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

                switch (checker)
                {
                    case DialogResult.Yes:
                        returnValues();
                        Engine.mainForm.selectTab((TabPage)returnCE.Parent);
                        Engine.mainForm.removeTab((TabPage)this.Parent);
                        break;
                    case DialogResult.No:
                        Engine.mainForm.selectTab((TabPage)returnCE.Parent);
                        Engine.mainForm.removeTab((TabPage)this.Parent);
                        break;
                }
            }
        }
    }
}
