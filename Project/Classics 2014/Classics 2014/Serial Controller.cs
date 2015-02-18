using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Runtime.Serialization;
using System.Threading;
using System.Collections.Concurrent;
using Microsoft.Win32;
namespace CMS
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
        public bool IsActive { get { return port.IsOpen; } private set{} }//ToDo Add a check to make sure that the format is correct
        public Boolean WindDirection { get; private set; }
        public Boolean WindSpeed { get; private set; }
        ASCIIEncoding eEnconder = new ASCIIEncoding();
        EventType incomingType;
        Action CloseSerialInputs;
        #endregion

        public Serial_Controller(ref ConcurrentQueue<Data> _queue, ref AutoResetEvent _signal, Action LostSerialInput)
        {
            this._queue = _queue;
            this._signal = _signal;
            portName = "COM" + GetComPort();
            ListenThread = new Thread(new ThreadStart(ThreadLoop));
            ListenThread.Start();
        }
        private void ThreadLoop()
        {
            do
            {
                ConnectPort();
                DetermineConnection();
                ReadOperation();
                
            } while (true);
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
            string Port;
            string Directory = @"HKEY_LOCAL_MACHINE\HARDWARE\DEVICEMAP\SERIALCOMM";
            string SubKey = "\\Device\\ProlificSerial0";
            try
            {
                Port = Registry.GetValue(Directory, SubKey, "COM5").ToString();
            }
            catch
            {
                Port = "COM5";
            }
            int ComNum = Convert.ToInt16(Port.Substring(3));
            return ComNum;
        }
        private void DetermineConnection()
        {
            //ToDo Determine Connections
            ReadOperation = new System.Action(AccuracyReadAndSplit);
            incomingType = EventType.INTL_ACCURACY;
            WindDirection = true;
            WindSpeed = true;
            
        }
        public void CloseThread()
        {
            ListenThread.Abort();
            port.Close();
        }
        #region Read And Split Procedures
        #region Accuracy
        private void AccuracyReadAndSplit()
        {
            buffer = new byte[19];
            do
            {
                try
                {
                    Data_Accuracy Data = new Data_Accuracy();
                    if (port.BytesToRead >= 19)
                    {
                        port.Read(buffer, 0, 19);
                        string asciiString;
                        asciiString = eEnconder.GetString(buffer);
                        Data = SplitStream(asciiString);
                        _queue.Enqueue(Data);
                        _signal.Set();
                    }
                }
                catch
                { //ToDo Stream Is Incorrect Format after Port set up}
                    if (!port.IsOpen)
                    {
                        ConnectPort();
                    }
                }
            } while (true);
        }
        private Data_Accuracy SplitStream(string asciiStream)
        {
            Data_Accuracy Data = new Data_Accuracy();
            if (asciiStream[17] == '*')
            { 
                Data.IsLanding = true; Data.LandingScore = Convert.ToByte(asciiStream.Substring(1, 2));
            }
            Data.Speed = float.Parse(asciiStream.Substring(3, 2) + '.' + asciiStream[5]);
            Data.Direction = Convert.ToUInt16(asciiStream.Substring(6, 3));

            Data.Time = "";
            Data.Time += DateTime.Now.Hour.ToString("00");
            Data.Time += ":";
            Data.Time += DateTime.Now.Minute.ToString("00");
            Data.Time += ":";
            Data.Time += DateTime.Now.Second.ToString("00");
            Data.dataType = incomingType;
            return Data;

        }
        #endregion 
        #endregion
    }
}

