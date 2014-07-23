using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Runtime.Serialization;
using System.Threading;
using System.Collections.Concurrent;
using Microsoft.Win32;
namespace Classics_2014
{
    class Serial_Controller
    {
        enum Hardware
        {
            LandingPad
        }
        #region Variables and constants

        byte[] buffer;
        SerialPort port;
        private Thread ListenThread;
        private readonly ConcurrentQueue<Data> _queue;
        private readonly AutoResetEvent _signal;
        String portName;
        Action ReadOperation;
        public bool IsActive { get { return port.IsOpen; } private set; }//ToDo Add a check to make sure that the format is correct
        public Boolean WindDirection { get; private set; }
        public Boolean WindSpeed { get; private set; }

        #endregion

        public Serial_Controller(ref ConcurrentQueue<Data> _queue, ref AutoResetEvent _signal)
        {
            this._queue = _queue;
            this._signal = _signal;
            portName = "COM" + GetComPort();
            ListenThread = new Thread(new ThreadStart(ThreadLoop));
        }
        private void ThreadLoop()
        {
            ConnectPort();
            DetermineConnection();
            ReadOperation();
        }
        private void ConnectPort()
        {
            do
            {
                try
                {
                    port = new SerialPort(portName);
                    port.Open();
                }
                catch
                {
                    Thread.Sleep(1000);
                    //TODO Error Catching for opening Port (All we do now is restart... which may be correct
                }
            } while (!port.IsOpen);
        }
        private int GetComPort()
        {
            string Directory = @"HKEY_LOCAL_MACHINE\HARDWARE\DEVICEMAP\SERIALCOMM";
            string SubKey = "\\Device\\ProlificSerial0";
            string Port = Registry.GetValue(Directory, SubKey, "COM5").ToString();
            int ComNum = Convert.ToInt16(Port.Substring(3));
            return ComNum;
        }
        private void DetermineConnection()
        {
            //ToDo Determine Connections
            ReadOperation = new System.Action(AccuracyReadAndSplit);
        }

        #region Read And Split Procedures
        private void AccuracyReadAndSplit()
        {
            buffer = new byte[19];
            do
            {

                Data_Accuracy Data = new Data_Accuracy();
                if (port.BytesToRead >= 19)
                {
                    try
                    {
                        port.Read(buffer, 0, 19);


                        ASCIIEncoding eEnconder = new ASCIIEncoding();
                        string asciiString;
                        asciiString = eEnconder.GetString(buffer);
                        Data = SplitStream(asciiString);
                    }
                    catch
                    { //ToDo Stream Is Incorrect Format after Port set up}
                    }
                    _queue.Enqueue(Data);
                    _signal.Set();
                }
            } while (true);
        }
        private Data_Accuracy SplitStream(string asciiStream)
        {
            Data_Accuracy Data = new Data_Accuracy();
            if (asciiStream[17] == '*') { Data.IsLanding = true; Data.LandingScore = Convert.ToByte(asciiStream.Substring(1, 2)); }
            Data.Speed = float.Parse(asciiStream.Substring(3, 2) + '.' + asciiStream[5]);
            Data.Direction = Convert.ToUInt16(asciiStream.Substring(6, 3));
            Data.Time = asciiStream.Substring(10, 2);
            Data.Time += ':';
            Data.Time += asciiStream.Substring(12, 2);
            Data.Time += ':';
            Data.Time += asciiStream.Substring(14, 2);
            return Data;

        }

        #endregion
    }
}

