using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CMS
{
    class Team
    {
        public int ID;
        public int EventID;
        public string Name;
        public List<EventCompetitor> Competitors;
        public Bitmap TeamImage;
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
