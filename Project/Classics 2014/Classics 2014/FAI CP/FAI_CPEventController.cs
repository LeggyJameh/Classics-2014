using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using CMS.MySQL;
using System.Threading;
using System.Collections.Concurrent;
using System.Windows.Forms;

namespace CMS.FAI_CP
{
    class FAI_CPEventController
    {
        #region variables and the such like
        Engine engine;
        public List<Accuracy.AccuracyLanding> Landings = new List<Accuracy.AccuracyLanding>();
        public ObservableCollection<FAI_CP_Event> Events = new ObservableCollection<FAI_CP_Event>();
        SQL_Controller SQL_Controller;
        IO_Controller IO_Controller;
        #endregion

        public FAI_CPEventController(SQL_Controller SQL_Controller, IO_Controller IO_Controller, Engine engine)
        {
            this.SQL_Controller = SQL_Controller;
            this.IO_Controller = IO_Controller;
            this.engine = engine;
        }

        public FAI_CP_Event AddEvent()
        {
            FAI_CP_Event newEvent = new FAI_CP_Event(SQL_Controller, IO_Controller, engine, this);
            newEvent.EventID = SQL_Controller.CreateEvent(newEvent);
            Events.Add(newEvent);
            return newEvent;
        }

        public void AddTab(UserControl tab)
        {
            engine.mainForm.addNewTab("New Event", tab);
        }
    }
}
