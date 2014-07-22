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
        Data dataToPassUp;
        private readonly ConcurrentQueue<Data> _queue;
        private readonly AutoResetEvent _signal;
        String portName;
        Action ReadOperation;

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
            //ToDo 
        }
        
        #region Read And Split Procedures
        private void AccuracyReadAndSplit()
        {
            //ToDo Pass Into Accuracy Class Type
        //            private void ListenThreadMethod()
        //{
        //    do
        //    {
               
        //        dataTable = new EdataTable();
        //        if (port.BytesToRead >= 19)
        //        {
        //            port.Read(buffer, 0, 19);


        //            ASCIIEncoding eEnconder = new ASCIIEncoding();
        //            string asciiString;
        //            asciiString = eEnconder.GetString(buffer);
        //            try
        //            {
        //                dataTable = SplitStream(asciiString);
        //            }
        //            catch { }
        //            _queue.Enqueue(dataTable); 
        //            _signal.Set();
        //        }
        //    } while (true);
        //}
        //private EdataTable SplitStream(string asciiStream)
        //{
        //    if (asciiStream[17] == '*') { dataTable.IsLanding = true; dataTable.LandingScore = Convert.ToByte(asciiStream.Substring(1, 2)); }
        //        dataTable.Wind.Speed = float.Parse(asciiStream.Substring(3, 2) + '.' + asciiStream[5]);
        //        dataTable.Wind.Direction = Convert.ToUInt16(asciiStream.Substring(6, 3));
        //        dataTable.Wind.Time = asciiStream.Substring(10, 2);
        //        dataTable.Wind.Time += ':';
        //        dataTable.Wind.Time += asciiStream.Substring(12, 2);
        //        dataTable.Wind.Time += ':';
        //        dataTable.Wind.Time += asciiStream.Substring(14, 2);
        //        return dataTable;
            
        //}
        }
        #endregion
    }
}
