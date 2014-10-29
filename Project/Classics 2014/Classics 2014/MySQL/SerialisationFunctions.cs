using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Classics_2014.MySQL
{
    // Working 29/10/14.
    class SerialisationFunctions
    {
        public MySqlLanding SerialiseLanding(Landing Landing)
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

        public Classics_2014.Accuracy.AccuracyLanding DeserialiseAccuracyLanding(MySqlLanding Landing, EventType Type) // Should be able to determine which type of landing it is, provided all event types are in and all landings derive from Landing class.
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter f = new BinaryFormatter();
            m.Write(Landing.Data, 0, Landing.Data.Length);
            m.Seek(0, SeekOrigin.Begin);
            Classics_2014.Accuracy.AccuracyLanding deSerializedLanding = (Classics_2014.Accuracy.AccuracyLanding)f.Deserialize(m);
            return deSerializedLanding;
        }

        public MySqlEvent SerialiseEvent(Event Event)
        {
            MySqlEvent NewEvent = new MySqlEvent();

            NewEvent.ID = Event.EventID;
            NewEvent.Name = Event.Name;
            NewEvent.Date = Event.Date;
            NewEvent.Type = Event.EventType;

            BinaryFormatter f = new BinaryFormatter();
            MemoryStream m = new MemoryStream();
            try
            { f.Serialize(m, Event.Rules); }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            NewEvent.Data = m.ToArray();

            return NewEvent;
        }

        public Event DeserialiseEvent(MySqlEvent Event)
        {
            switch (Event.Type)
            {
                case EventType.Accuracy:
                    Accuracy.Accuracy_Event deSerialisedEvent = new Accuracy.Accuracy_Event();

                    MemoryStream m = new MemoryStream();
                    BinaryFormatter f = new BinaryFormatter();
                    m.Write(Event.Data, 0, Event.Data.Length);
                    m.Seek(0, SeekOrigin.Begin);

                    deSerialisedEvent.Rules = (Ruleset.AccuracyRules)f.Deserialize(m);
                    deSerialisedEvent.EventID = Event.ID;
                    deSerialisedEvent.Name = Event.Name;
                    deSerialisedEvent.Date = Event.Date;
                    return deSerialisedEvent;
                    break;
            }
            return null;
        }
    }
}
