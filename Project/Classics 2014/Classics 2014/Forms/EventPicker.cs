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

            // Temp code
            eventType = EventType.FAI_CP;
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
            foreach (Control c in this.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rb = (RadioButton)c;
                    rb.Checked = false;
                }
            }
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
