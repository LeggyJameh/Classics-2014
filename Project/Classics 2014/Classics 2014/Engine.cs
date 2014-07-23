using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classics_2014
{
    class Engine
    {
        IO_Controller IO_Controller;
        SQL_Controller SQL_Controller;
        public Engine()
        {
            IO_Controller = new IO_Controller();
            SQL_Controller = new SQL_Controller();
        }
    }
}
