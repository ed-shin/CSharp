using System;
using System.IO.Ports;

namespace Utility.Comm
{
    /// <summary>
    /// Serial Interface 
    /// </summary>
    public class Serial
    {
        public delegate void ReceivedDataEventDelegate(byte[] data);
        public event ReceivedDataEventDelegate ReceivedDataEvent;

        private SerialPort _serialPort = null;
        private string _comport = null;
        private int _baudrate = 115200;
        private int _sleepTime = 1;

        public int Interval
        {
            get { return _sleepTime; }
            set { _sleepTime = value; }
        }

        public bool IsOpen
        {
            get
            {
                if (_serialPort != null)
                    return _serialPort.IsOpen;

                return false;
            }
        }
        
        public bool Open(string comport, int baudrate = 115200, int dataBit = 8, StopBits stopBits = StopBits.One, Parity parity = Parity.None)
        {
            if (_serialPort == null)
            {
                _comport = comport;
                _baudrate = baudrate;

                _serialPort = new SerialPort(_comport, _baudrate);
                _serialPort.DataBits = 8;
                _serialPort.StopBits = StopBits.One;
                _serialPort.Parity = Parity.None;
                _serialPort.DataReceived += _serialPort_DataReceived;

                Console.WriteLine(string.Format("try connecting to '{0}' port", _serialPort.PortName));

                try
                {
                    _serialPort.Open();
                    if (_serialPort.IsOpen)
                    {
                        Console.WriteLine("success to coneect..");
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("fail connecting..");
                    Console.WriteLine(ex.Message);
                }

                _serialPort.Dispose();
                _serialPort = null;

                return false;
            }
            else
            {
                if (_serialPort.IsOpen)
                    return true;
                else
                {
                    this.Close();
                    return this.Open(_serialPort.PortName, _serialPort.BaudRate, _serialPort.DataBits, _serialPort.StopBits, _serialPort.Parity);
                }
            }
        }

        public void Close()
        {
            if (_serialPort != null)
            {
                Console.WriteLine(string.Format("'{0}' port closing..", _serialPort.PortName));

                _serialPort.DiscardInBuffer();
                _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null;

                Console.WriteLine("port closed..");
            }
            else
                Console.WriteLine("already, port is not connected");
        }

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int readCount = _serialPort.BytesToRead;

                byte[] recvData = new byte[readCount];

                _serialPort.Read(recvData, 0, readCount);

                if (ReceivedDataEvent != null)
                    ReceivedDataEvent(recvData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string[] GetPorts()
        {
            return SerialPort.GetPortNames();
        }
    }
}
