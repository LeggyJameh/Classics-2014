using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS.Accuracy
{
    public partial class AccuracyOptionsMenu : UserControl
    {
        public AccuracyOptionsMenu()
        {
            InitializeComponent();
            if (UserSettings.Default.userIsAdvanced)
            {
                tableLayoutPanelAdvancedOptions.Enabled = true;
            }
        }
    }
}
