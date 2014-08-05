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
     partial class CommonDisplayOptions : UserControl
    {
        windGraphingControllercs windGraph;
        public CommonDisplayOptions(windGraphingControllercs windGraph)
        {
            this.windGraph = windGraph;
            InitializeComponent();
            comboBoxNormalColourGraph.SelectedItem = UserSettings.Default.graphNormal.Name;
            comboBoxWindOutGraph.SelectedItem = UserSettings.Default.graphWindOut.Name;
            comboBoxDirectionOutGraph.SelectedItem = UserSettings.Default.graphDirectionOut.Name;
            comboBoxBothOutGraph.SelectedItem = UserSettings.Default.graphBothOut.Name;
            comboBoxDirectionOutSide.SelectedItem = UserSettings.Default.sideTextDirectionOutColour.Name;
            comboBoxNormalColourSide.SelectedItem = UserSettings.Default.sideTextStandarColour.Name;
            comboBoxWindOutColourSide.SelectedItem = UserSettings.Default.sideTextWindOutColour.Name;
            numericUpDownDirectionWarningLength.Value = UserSettings.Default.flopsToMaintainColourDirection;
            numericUpDownWindWarningLength.Value = UserSettings.Default.flopsToMaintainColourSpeed;
            numericUpDownStandDownWarningLength.Value = UserSettings.Default.compHaltLength;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UserSettings.Default.Save();
            windGraph.ResetGraphColours();
        }

        private void comboBoxNormalColourGraph_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserSettings.Default.graphNormal = Color.FromName(comboBoxNormalColourGraph.SelectedItem.ToString().Replace(" ", ""));
        }

        private void comboBoxWindOutGraph_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserSettings.Default.graphWindOut = Color.FromName(comboBoxWindOutGraph.SelectedItem.ToString().Replace(" ", ""));
        }

        private void comboBoxDirectionOutGraph_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserSettings.Default.graphDirectionOut = Color.FromName(comboBoxDirectionOutGraph.SelectedItem.ToString().Replace(" ", ""));
        }

        private void comboBoxBothOutGraph_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserSettings.Default.graphBothOut = Color.FromName(comboBoxBothOutGraph.SelectedItem.ToString().Replace(" ", ""));
        }

        private void comboBoxNormalColourSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserSettings.Default.sideTextStandarColour = Color.FromName(comboBoxNormalColourSide.SelectedItem.ToString().Replace(" ", ""));
        }

        private void comboBoxWindOutColourSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserSettings.Default.sideTextWindOutColour = Color.FromName(comboBoxWindOutColourSide.SelectedItem.ToString().Replace(" ", ""));
        }

        private void comboBoxDirectionOutSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserSettings.Default.sideTextDirectionOutColour = Color.FromName(comboBoxDirectionOutSide.SelectedItem.ToString().Replace(" ", ""));
        }

        private void numericUpDownWindWarningLength_ValueChanged(object sender, EventArgs e)
        {
            UserSettings.Default.flopsToMaintainColourSpeed = (int)numericUpDownWindWarningLength.Value;
        }

        private void numericUpDownDirectionWarningLength_ValueChanged(object sender, EventArgs e)
        {
            UserSettings.Default.flopsToMaintainColourDirection = (int)numericUpDownDirectionWarningLength.Value;
        }

        private void numericUpDownStandDownWarningLength_ValueChanged(object sender, EventArgs e)
        {
            UserSettings.Default.compHaltLength = (int)numericUpDownStandDownWarningLength.Value;
        }

        private void checkBoxIsAdvancedUser_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Default.userIsAdvanced = checkBoxIsAdvancedUser.Checked;
        }

        private void checkBoxEnableSounds_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Default.AudioAlarmsEnabled = checkBoxEnableSounds.Checked;
        }

        private void textBoxPassWord_TextChanged(object sender, EventArgs e)
        {
            UserSettings.Default.userLockPassword = textBoxPassWord.Text;
        }

    }
}
