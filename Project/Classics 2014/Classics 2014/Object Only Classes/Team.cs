using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classics_2014
{
    class Team
    {
        public List<EventCompetitor> Competitors;
        public string Name;
        public Team()
        {
            Competitors = new List<EventCompetitor>();
            Name = "";
        }
        public Team(string Name)
        {
            this.Name = Name;
        }
    }
}
