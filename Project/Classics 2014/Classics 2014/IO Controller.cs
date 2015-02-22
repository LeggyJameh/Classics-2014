using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;

namespace CMS
{
    class IO_Controller
    {
        Serial_Controller Serial_Controller;
        Camera_Controller Camera_Controller;
        Network_Controller Network_Controller;
        public readonly ConcurrentQueue<Data> Data_queue = new ConcurrentQueue<Data>();
        public readonly AutoResetEvent _signal = new AutoResetEvent(false);
        public Boolean Cameras_Active;
        public Boolean Serial_Input { get { return Serial_Controller.IsActive; } }
        public IO_Controller(Action LostSerialInput)
        {
             Serial_Controller = new Serial_Controller(ref Data_queue, ref _signal,LostSerialInput);
             Camera_Controller = new Camera_Controller();
             Network_Controller = new Network_Controller();

            // DebugIOWINDOW newWindow = new DebugIOWINDOW(Data_queue, _signal);//Comment out this line for standard usage
             //newWindow.Show();//Comment out this line for standard usage
        }
        public bool[] CheckIO()
        {
            Boolean[] replies = new bool[3];
            replies[0] = Serial_Controller.IsActive; //Comment out this line for debug
           // replies[0] = true;//Comment out this line for standard usage
            replies[1] = Camera_Controller.Active;
            replies[2] = Network_Controller.Active;
            return replies;
        }
        public void EndThreads()
        {
            Serial_Controller.CloseThread();
        }
    }
}
