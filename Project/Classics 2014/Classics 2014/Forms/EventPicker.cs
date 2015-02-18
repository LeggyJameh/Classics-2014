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
    public partial class EventPicker : Form
    {
        public EventType eventType;
        public EventPicker()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(EventPickerKeyDown);
        }

        private void buttonStartEvent_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EventPickerKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonStartEvent.PerformClick();
            }
        }

        private void SelectionChange(object sender, EventArgs e)
        {
            RadioButton CurrentButton = (RadioButton)sender;
            radioButtonFAIArtistic.Checked = false;
            radioButtonFAICanopyPiloting.Checked = false;
            radioButtonFAICF2Way.Checked = false;
            radioButtonFAICF4Way.Checked = false;
            radioButtonFAICF8Way.Checked = false;
            radioButtonFAIFS4Way.Checked = false;
            radioButtonFAIFS8Way.Checked = false;
            radioButtonFAIParaski.Checked = false;
            radioButtonFAISpeed.Checked = false;
            radioButtonFAIStyleAndAccuracy.Checked = false;
            radioButtonFAIVFS.Checked = false;
            radioButtonFAIWingsuit.Checked = false;
            radioButtonIntAccuracy.Checked = false;
            radioButtonIntArtistic.Checked = false;
            radioButtonIntCanopyPiloting.Checked = false;
            radioButtonIntCF2Way.Checked = false;
            radioButtonIntCF4Way.Checked = false;
            radioButtonIntFS4Way.Checked = false;
            radioButtonIntFS8Way.Checked = false;
            radioButtonIntFSSpeed.Checked = false;
            radioButtonIntParaski.Checked = false;
            radioButtonIntSpeed.Checked = false;
            radioButtonIntStyleAndAccuracy.Checked = false;
            radioButtonIntVFS.Checked = false;
            radioButtonIntWingsuit.Checked = false;
            CurrentButton.Checked = true;

            eventType = (EventType)Convert.ToInt16(CurrentButton.Tag);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            eventType = EventType.NONE;
            this.Close();
        }
    }

    class EventPickerMessageBox
    {
        public static EventType ShowEventPicker()
        {
            // using construct ensures the resources are freed when form is closed
            using (var form = new EventPicker())
            {
                form.ShowDialog();
                {
                    return form.eventType;
                }
            }
        }
    }
}
