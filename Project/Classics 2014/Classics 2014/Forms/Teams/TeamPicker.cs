using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS.Forms
{
    partial class TeamPicker : UserControl
    {
        private Event Connected_Event;
        public List<Team> teams;
        public List<Competitor> unassignedCompetitors;
        private Teams.TeamPickSimple teamPickSimple;
        private Teams.TeamPickAdvanced teamPickAdvanced;


        public TeamPicker()
        {
            InitializeComponent();
        }
    }
}
