using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.ObjectModel;

namespace CMS.MySQL
{
    // Working 29/10/14.
    partial class SQL_Controller
    {
        private MySqlLanding SerialiseLanding(Landing Landing)
        {
            MySqlLanding NewLanding = new MySqlLanding();

            NewLanding.ID = Landing.ID;
            NewLanding.UID = Landing.UID;
            NewLanding.eventID = Landing.eventID;
            BinaryFormatter f = new BinaryFormatter();
            MemoryStream m = new MemoryStream();
            f.Serialize(m, Landing);
            NewLanding.Data = m.ToArray();

            return NewLanding;
        }

        private CMS.Accuracy.AccuracyLanding DeserialiseAccuracyLanding(MySqlLanding Landing, EventType Type) // Should be able to determine which type of landing it is, provided all event types are in and all landings derive from Landing class.
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter f = new BinaryFormatter();
            m.Write(Landing.Data, 0, Landing.Data.Length);
            m.Seek(0, SeekOrigin.Begin);
            CMS.Accuracy.AccuracyLanding deSerializedLanding = (CMS.Accuracy.AccuracyLanding)f.Deserialize(m);
            return deSerializedLanding;
        }

        private MySqlEvent SerialiseEvent(Event Event)
        {
            MySqlEvent NewEvent = new MySqlEvent();

            NewEvent.ID = Event.EventID;
            NewEvent.Name = Event.Name;
            NewEvent.Date = Event.Date;
            NewEvent.Type = Event.EventType;

            BinaryFormatter f = new BinaryFormatter();
            MemoryStream m = new MemoryStream();
            if (Event.Rules != null)
            {
                MySqlEventData data = new MySqlEventData();
                data.rules = Event.Rules;
                data.competitors = Event.UnassignedCompetitors;
                try
                { f.Serialize(m, data); }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
                NewEvent.Data = m.ToArray();
            }

            return NewEvent;
        }

        private Event DeserialiseEvent(MySqlEvent Event)
        {
            if (Event.Name != "" && Event.Name != null)
            {
                switch (Event.Type)
                {
                    case EventType.INTL_ACCURACY:
                        Accuracy.Accuracy_Event deSerialisedEvent = new Accuracy.Accuracy_Event();

                        MemoryStream m = new MemoryStream();
                        BinaryFormatter f = new BinaryFormatter();
                        m.Write(Event.Data, 0, Event.Data.Length);
                        m.Seek(0, SeekOrigin.Begin);

                        MySqlEventData data = (MySqlEventData)f.Deserialize(m);
                        deSerialisedEvent.Rules = data.rules;
                        deSerialisedEvent.UnassignedCompetitors = data.competitors;
                        deSerialisedEvent.EventType = Event.Type;
                        deSerialisedEvent.EventID = Event.ID;
                        deSerialisedEvent.Name = Event.Name;
                        deSerialisedEvent.Date = Event.Date;
                        return deSerialisedEvent;
                        break;
                }
            }
            return null;
        }

        private MySqlTeam SerialiseTeam(Team Team)
        {
            MySqlTeam NewTeam = new MySqlTeam();

            NewTeam.ID = Team.ID;
            NewTeam.EventID = Team.EventID;
            NewTeam.Name = Team.Name;

            BinaryFormatter f = new BinaryFormatter();
            MemoryStream m = new MemoryStream();
            try
            { f.Serialize(m, Team.Competitors); }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            NewTeam.Data = m.ToArray();

            f = new BinaryFormatter();
            m = new MemoryStream();

            if (Team.TeamImage != null)
            {
                try
                { f.Serialize(m, Team.TeamImage); }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }

                NewTeam.Image = m.ToArray();
            }

            return NewTeam;
        }

        private Team DeserialiseTeam(MySqlTeam Team)
        {
            Team deSerialisedTeam = new Team();

            MemoryStream m = new MemoryStream();
            BinaryFormatter f = new BinaryFormatter();
            m.Write(Team.Data, 0, Team.Data.Length);
            m.Seek(0, SeekOrigin.Begin);
            deSerialisedTeam.Competitors = (ObservableCollection<EventCompetitor>)f.Deserialize(m);

            m = new MemoryStream();
            f = new BinaryFormatter();
            m.Write(Team.Image, 0, Team.Image.Length);
            m.Seek(0, SeekOrigin.Begin);
            if (m.Length >= 2) // If image exists...
            {
                try
                {
                    deSerialisedTeam.TeamImage = (System.Drawing.Bitmap)f.Deserialize(m);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Image failed to load", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }

            deSerialisedTeam.EventID = Team.EventID;
            deSerialisedTeam.ID = Team.ID;
            deSerialisedTeam.Name = Team.Name;

            return deSerialisedTeam;
        }
    }
}
