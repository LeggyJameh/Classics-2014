using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

namespace Classics_2014
{
    class Network_Controller
    {
        private readonly ConcurrentQueue<Data> Data_queue = new ConcurrentQueue<Data>();
        private readonly AutoResetEvent _signal = new AutoResetEvent(false);
        public Network_Controller()
        {
            Serial_Controller SerialController = new Serial_Controller(ref Data_queue, ref _signal);
        }
    }
}
