using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace CMS.Accuracy
{
    class AccuracyEventData
    {
        EventCompetitor competitor;
        List<AccuracyLanding> landings;

        public AccuracyEventData()
        {
            this.competitor = new EventCompetitor();
            this.landings = new List<AccuracyLanding>();
        }

        public AccuracyEventData(EventCompetitor competitor)
        {
            this.competitor = competitor;
            this.landings = new List<AccuracyLanding>();
        }

        public AccuracyEventData(List<AccuracyLanding> landings)
        {
            this.competitor = new EventCompetitor();
            this.landings = new List<AccuracyLanding>();
        }

        public AccuracyEventData(EventCompetitor competitor, List<AccuracyLanding> landings)
        {
            this.competitor = competitor;
            this.landings = landings;
        }

        public EventCompetitor Competitor
        {
            get
            {
                return competitor;
            }
            set
            {
                competitor = value;
            }
        }

        public AccuracyLanding this[int index]
        {
            get
            {
                return landings[index];
            }
            set
            {
                landings[index] = value;
            }
        }

        public int IndexOf(AccuracyLanding landing)
        {
            for (int i = 0; i < landings.Count; i++)
            {
                if (landings[i] == landing)
                {
                    return i;
                }
            }
            return -1;
        }

        public int Count
        {
            get
            {
                return landings.Count;
            }
        }

        public bool Contains(AccuracyLanding landing)
        {
            foreach (AccuracyLanding l in landings)
            {
                if (landing == l)
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            landings.Clear();
        }

        public void Add(AccuracyLanding landing)
        {
            landings.Add(landing);
        }

        public void Add(List<AccuracyLanding> _landings)
        {
            foreach (AccuracyLanding l in _landings)
            {
                landings.Add(l);
            }
        }

        public void Remove(AccuracyLanding landing)
        {
            landings.Remove(landing);
        }

        public void Remove(List<AccuracyLanding> _landings)
        {
            foreach (AccuracyLanding l in _landings)
            {
                landings.Remove(l);
            }
        }

        public void RemoveAt(int index)
        {
            landings.RemoveAt(index);
        }

    }
}
