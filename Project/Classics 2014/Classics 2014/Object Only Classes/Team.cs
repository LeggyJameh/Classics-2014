using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections.ObjectModel;

namespace CMS
{
    class Team : ICloneable
    {
        public int ID;
        public int EventID;
        public string Name;
        public ObservableCollection<EventCompetitor> Competitors;
        public Bitmap TeamImage;
        SubCollectionUpdatedDelegate updateDelegate;

        public Team()
        {
            Competitors = new ObservableCollection<EventCompetitor>();
            Name = "";
            ID = -1;
        }
        public Team(string Name)
        {
            Competitors = new ObservableCollection<EventCompetitor>();
            this.Name = Name;
            ID = -1;
        }
        public Team(SubCollectionUpdatedDelegate updateDelegate)
        {
            Competitors = new ObservableCollection<EventCompetitor>();
            Name = "";
            ID = -1;
            this.updateDelegate = updateDelegate;
            Competitors.CollectionChanged +=new System.Collections.Specialized.NotifyCollectionChangedEventHandler(updateDelegate);
        }
        public Team(string Name, SubCollectionUpdatedDelegate updateDelegate)
        {
            Competitors = new ObservableCollection<EventCompetitor>();
            this.Name = Name;
            ID = -1;
            this.updateDelegate = updateDelegate;
            Competitors.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(updateDelegate);
        }

        public void addUpdateDelegate(SubCollectionUpdatedDelegate updateDelegate)
        {
            this.updateDelegate = updateDelegate;
            Competitors.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(updateDelegate);
        }

        public object Clone()
        {
            Team newTeam = new Team(updateDelegate);
            newTeam.Competitors = new ObservableCollection<EventCompetitor>();
            foreach (EventCompetitor c in Competitors)
            {
                newTeam.Competitors.Add((EventCompetitor)c.Clone());
            }
            newTeam.EventID = this.EventID;
            newTeam.ID = this.ID;
            newTeam.Name = this.Name;
            newTeam.TeamImage = this.TeamImage;
            return newTeam;
        }
    }
}
