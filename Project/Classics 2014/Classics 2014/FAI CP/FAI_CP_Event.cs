using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.FAI_CP
{
    class FAI_CP_Event : Event
    {
        public FAI_CPEventController controller;
        Ruleset.FAI_CPRules rules;

        public FAI_CP_Event(MySQL.SQL_Controller SQL_Controller, IO_Controller IO_Controller, Engine Engine, FAI_CPEventController EventController)
        {
            this.IO_Controller = IO_Controller;
            this.SQL_Controller = SQL_Controller;
            this.engine = Engine;
            this.controller = EventController;
            RequiresSerial = true;
            EventType = CMS.EventType.FAI_CP;
            EventID = -1;
            rules = new Ruleset.FAI_CPRules();
            currentWindow = new EventFAI_CPInit(this, false);
            controller.AddTab(currentWindow);
        }
    }
}
