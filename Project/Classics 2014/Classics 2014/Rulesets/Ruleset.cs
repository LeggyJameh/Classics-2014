using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CMS.Ruleset
{
    [Serializable]
    public class Ruleset
    {
        public EventStage stage;
        public int competitorsPerTeam;
        public Ruleset()
        {
            stage = EventStage.SetupRules;
            competitorsPerTeam = 0;
        }
    }
}
