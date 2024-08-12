using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SensorValue;
using CommonReferences;

namespace TCPCommunication
{
    public delegate void NewSignalReceived(SensorValue.SensorValue sensorValue);

    public class TCPCommServer
    {
        private Int16 _port = 1020;
        private string _thisServerIP = "0.0.0.0";

        protected TcpListener server;
        protected List<Thread> ServerThreadList = new List<Thread>();

        private bool _isRunning = false;
        public event NewSignalReceived newSignalReceivedEvent;

        #region properties 
        public bool IsRunning
        {
            get { return _isRunning; }
        }
        #endregion

        #region Constructors
        public TCPCommServer()
        {
            try
            {
                StartTCPServer();
                _isRunning = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error when trying to open the TCP server ", ex);
            }
        }
        #endregion 

        private void StartTCPServer()
        {
            if (_isRunning)
            {
                return;
            }
            Thread newThread = new Thread(StartInNewThread);
            ServerThreadList.Add(newThread);
            newThread.Start();
        }

        private void StartInNewThread()
        {
            server = new TcpListener(IPAddress.Parse(_thisServerIP), _port);
            server.Start();

            while (_isRunning)
            {
                if (server.Pending())
                {
                    RemouveClosedThreadsFromList();
                    TcpClient tempClient = server.AcceptTcpClient();
                    Thread newThread = new Thread(new ParameterizedThreadStart(ClientThread));
                    ServerThreadList.Add(newThread);
                    newThread.Start(tempClient);
                }
                Thread.Sleep(100);
            }
            server.Stop();
        }

        private void RemouveClosedThreadsFromList()
        {
            List<Thread> myAliveThreadList = new List<Thread>();
            foreach (Thread thread in ServerThreadList)
            {
                if (thread.IsAlive)
                {
                    myAliveThreadList.Add(thread);
                }
                else
                {
                    thread.Abort();
                }
            }
            ServerThreadList = myAliveThreadList;
        }

        private void CloseTCPServer()
        {
            if (server != null)
            {
                server.Stop();
            }
            foreach (Thread thread in ServerThreadList)
            {
                thread.Abort();
            }
            server = null;
        }

        private void ClientThread(object clientData)
        {
            TcpClient client = (TcpClient)clientData;
            NetworkStream stream = client.GetStream();
            stream.ReadTimeout = 60 * 1000;

            List<byte> signalValueInBytes = new List<byte>();
            int bufData = 0;

            try
            {
                while (client.Connected && stream.DataAvailable)
                {
                    bufData = stream.ReadByte();
                    if (bufData == -1) break;
                    signalValueInBytes.Add((byte)bufData);
                }

                ASCIIEncoding enc = new ASCIIEncoding();
                string receivedText = enc.GetString(signalValueInBytes.ToArray());
                UnpackSignalAndRaiseTheEvent(receivedText);
            }
            catch (Exception ex)
            {
                throw new Exception("Error when reading values sent by TCP client ", ex);
            }
        }

        private void UnpackSignalAndRaiseTheEvent(string packedSignalValue)
        {
            string strTimeStamp = string.Empty;
            string strSignalValue = string.Empty;
            string strPatientCode = string.Empty;
            string signalName = string.Empty;

            string[] ValuesList = packedSignalValue.Split('#');
            foreach (string value in ValuesList) // Modificarea numelui variabilei de la packedSignalValue la value
            {
                if (value.Length > 0)
                {
                    string[] valueFields = value.Split(',');
                    signalName = valueFields[0];
                    SensorType sensorType = (SensorType)Enum.Parse(typeof(SensorType), signalName);
                    strTimeStamp = valueFields[1];
                    DateTime timeStamp;
                    DateTime.TryParse(strTimeStamp, out timeStamp);
                    strPatientCode = valueFields[2];
                    strSignalValue = valueFields[3];

                    string[] dataValuesList = valueFields[3].Split(';');
                    List<double> dataValueList = new List<double>();
                    try
                    {
                        foreach (string currDataValue in dataValuesList)
                        {
                            string strDataValue = (currDataValue.TrimStart('[')).TrimEnd(']');
                            double doubleValue;
                            Double.TryParse(strDataValue, out doubleValue);
                            dataValueList.Add(doubleValue);
                        }
                        SendNewDataReceivedEvent(new SensorValue.SensorValue(strPatientCode, sensorType, dataValueList[0], timeStamp));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error when unpacking the text received from TCP client ", ex);
                    }
                }
            }
        }

        protected void SendNewDataReceivedEvent(SensorValue.SensorValue e)
        {
            if (this.newSignalReceivedEvent != null) 
                this.newSignalReceivedEvent(e);
        }

        public void Dispose()
        {
            try
            {
                foreach (Thread thread in ServerThreadList)
                {
                    thread.Abort();
                }
                ServerThreadList.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception(" Error on closing TCP server connection -> " + ex.Message);
            }
        }


    }
}
