using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;

namespace Classics_2014
{
    class IO_Controller
    {
        Serial_Controller Serial_Controller;
        Camera_Controller Camera_Controller;
        Network_Controller Network_Controller;
        public readonly ConcurrentQueue<Data> Data_queue = new ConcurrentQueue<Data>();
        public readonly AutoResetEvent _signal = new AutoResetEvent(false);
        public Boolean Cameras_Active;
        public Boolean Serial_Input;
        public IO_Controller()
        {
             Serial_Controller = new Serial_Controller(ref Data_queue, ref _signal);
             Camera_Controller = new Camera_Controller();
        }
        public bool[] CheckIO()
        {
            Boolean[] replies = new bool[2];
            replies[0] = Serial_Controller.
        }
    }
}
