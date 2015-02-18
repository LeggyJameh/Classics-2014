using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    class EventLoader
    {
        Engine Engine;
        LoadScreen loadScreen;
        public List<Event> events;

        public EventLoader(Engine engine)
        {
            this.Engine = engine;
            events = new List<Event>();
            loadEventsFromDatabase();
            loadScreen = new LoadScreen(this);
            Engine.mainForm.addNewTab("Load Event", loadScreen);
        }

        public void Close()
        {
            Engine.mainForm.removeTab((System.Windows.Forms.TabPage)loadScreen.Parent);
            Engine.RemoveLoader();
            this.loadScreen = null;
            this.Engine = null;
        }

        public void RemoveEvent(Event _event)
        {
            Engine.SQL_Controller.RemoveEvent(_event.EventID);
            events.Remove(_event);
        }

        public void LoadEvent(Event Event)
        {
            Engine.LoadEvent(Event);
        }

        public void loadEventsFromDatabase()
        {
            events = Engine.SQL_Controller.GetEvents();
        }

    }
}
