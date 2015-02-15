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
    partial class LoadScreen : UserControl
    {
        EventLoader EventLoader;

        public LoadScreen(EventLoader EventLoader)
        {
            this.EventLoader = EventLoader;
            InitializeComponent();
        }

        private void refreshEventGrid()
        {
            dataGridEvents.Rows.Clear();
            foreach (Event e in EventLoader.events)
            {
                dataGridEvents.Rows.Add(e.EventID, e.Name, e.Date.ToShortDateString(), e.EventType.ToString());
            }
        }

        public int getSelectedEventIndex()
        {
            if (dataGridEvents.SelectedRows != null)
            {
                if (dataGridEvents.SelectedRows.Count > 0)
                {
                    int eventID = Convert.ToInt16(dataGridEvents.SelectedRows[0].Cells[0].Value);

                    for (int i = 0; i < EventLoader.events.Count; i++)
                    {
                        if (EventLoader.events[i].EventID == eventID)
                        {
                            return i;
                        }
                    }
                }
            }
            return -1;
        }
    }
}
