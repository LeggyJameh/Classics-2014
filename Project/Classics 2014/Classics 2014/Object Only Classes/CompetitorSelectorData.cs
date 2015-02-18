using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    class CompetitorSelectorData
    {
        List<string> groups;
        List<bool> groupsSelected;
        List<Competitor> competitors;
        List<bool> competitorsSelected;

        public CompetitorSelectorData()
        {
            groups = new List<string>();
            groupsSelected = new List<bool>();
            competitors = new List<Competitor>();
            competitorsSelected = new List<bool>();
        }

        public int AddCompetitor(Competitor c)
        {
            bool exists = false;
            foreach (Competitor x in competitors)
            {
                if (x == c)
                {
                    exists = true;
                }
            }
            if (exists == false)
            {
                competitors.Add(c);
                competitorsSelected.Add(false);
            }
            return indexOf(c);
        }

        public int AddCompetitor(Competitor c, bool value)
        {
            bool exists = false;
            foreach (Competitor x in competitors)
            {
                if (x == c)
                {
                    exists = true;
                }
            }
            if (exists == false)
            {
                competitors.Add(c);
                competitorsSelected.Add(value);
            }
            return indexOf(c);
        }

        public int InsertCompetitorAt(Competitor c, int index)
        {
            bool exists = false;
            foreach (Competitor x in competitors)
            {
                if (x == c)
                {
                    exists = true;
                }
            }
            if (exists == true)
            {
                competitors.Insert(index, c);
                competitorsSelected.Insert(index, false);
            }
            return indexOf(c);
        }

        public void RemoveCompetitor(Competitor c)
        {
            if (indexOf(c) > 0)
            {
                competitors.Remove(c);
            }
        }

        public void RemoveCompetitorAt(int index)
        {
            if (competitors[index] != null)
            {
                competitors.RemoveAt(index);
            }
        }

        public Competitor GetCompetitorAt(int index)
        {
            if (competitors[index] != null)
            {
                return competitors[index];
            }
            else return null;
        }

        public int GetIndexOf(Competitor competitor)
        {
            return indexOf(competitor);
        }

        public int GetIndexOf(int competitorID)
        {
            foreach (Competitor c in competitors)
            {
                if (c.ID == competitorID)
                {
                    return GetIndexOf(c);
                }
            }
            return -1;
        }

        public bool CompetitorValue(Competitor competitor)
        {
            int index = indexOf(competitor);
            return competitorsSelected[index];
        }

        public bool CompetitorValue(int index)
        {
            return competitorsSelected[index];
        }

        public List<Competitor> GetCompetitors()
        {
            return competitors;
        }

        public void SetValue(Competitor c, bool value)
        {
            int index = indexOf(c);
            if (index != -1)
            {
                competitorsSelected[index] = value;
            }
        }

        public int CompetitorCount()
        {
            return competitors.Count;
        }

        public bool Contains(Competitor c)
        {
            if (indexOf(c) >= 0)
            {
                return true;
            }
            else return false;
        }

        public int AddGroup(string t)
        {
            bool exists = false;
            foreach (string x in groups)
            {
                if (x == t)
                {
                    exists = true;
                }
            }
            if (exists == false)
            {
                groups.Add(t);
                groupsSelected.Add(false);
            }
            return indexOf(t);
        }

        public int AddGroup(string t, bool value)
        {
            bool exists = false;
            foreach (string x in groups)
            {
                if (x == t)
                {
                    exists = true;
                }
            }
            if (exists == false)
            {
                groups.Add(t);
                groupsSelected.Add(value);
            }
            return indexOf(t);
        }

        public int InsertGroupAt(string t, int index)
        {
            bool exists = false;
            foreach (string x in groups)
            {
                if (x == t)
                {
                    exists = true;
                }
            }
            if (exists == true)
            {
                groups.Insert(index, t);
                groupsSelected.Insert(index, false);
            }
            return indexOf(t);
        }

        public void RemoveGroup(string t)
        {
            if (indexOf(t) > 0)
            {
                groups.Remove(t);
            }
        }

        public void RemoveGroupAt(int index)
        {
            if (groups[index] != null)
            {
                groups.RemoveAt(index);
            }
        }

        public string GetGroupAt(int index)
        {
            if (groups[index] != null)
            {
                return groups[index];
            }
            else return "";
        }

        public int GetIndexOf(string group)
        {
            return indexOf(group);
        }

        public bool GroupValue(string group)
        {
            int index = indexOf(group);
            return groupsSelected[index];
        }

        public bool GroupValue(int index)
        {
            return groupsSelected[index];
        }

        public List<string> GetGroups()
        {
            return groups;
        }

        public void SetValue(string t, bool value)
        {
            int index = indexOf(t);
            if (index != -1)
            {
                groupsSelected[index] = value;
            }
        }

        public int GroupCount()
        {
            return groups.Count;
        }

        public bool Contains(string t)
        {
            if (indexOf(t) >= 0)
            {
                return true;
            }
            else return false;
        }

        private int indexOf(Competitor c)
        {
            int index = -1;
            foreach (Competitor x in competitors)
            {
                if (x.ID == c.ID && x.name == c.name && x.nationality == c.nationality && x.group == c.group)
                {
                    index = competitors.IndexOf(x);
                }
            }
            return index;
        }

        private int indexOf(string t)
        {
            int index = -1;
            foreach (string group in groups)
            {
                if (group == t)
                {
                    index = groups.IndexOf(group);
                }
            }
            return index;
        }
    }
}
