using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    public class Competitor : ICloneable
    {
        public int ID;
        public string name;
        public string group;
        public string nationality;
        public Competitor()
        {
            ID = 0;
            name = "";
            group = "";
            nationality = "";
        }

        public object Clone()
        {
            Competitor newCompetitor = new Competitor();
            newCompetitor.ID = this.ID;
            newCompetitor.name = this.name;
            newCompetitor.nationality = this.nationality;
            newCompetitor.group = this.group;
            return newCompetitor;
        }
    }
}
