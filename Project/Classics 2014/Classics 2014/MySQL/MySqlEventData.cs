using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.MySQL
{
    [Serializable]
    class MySqlEventData
    {
        public List<Competitor> competitors;
        public Ruleset.Ruleset rules;

        public MySqlEventData()
        {
            competitors = new List<Competitor>();
            rules = new Ruleset.Ruleset();
        }
    }
}
