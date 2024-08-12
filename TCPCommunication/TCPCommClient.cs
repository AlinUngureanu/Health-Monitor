using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TCPCommunication
{
    public class TCPCommClient :IDisposable
    {
        private string _serverIP = String.Empty; // Declararea variabilei _serverIP
        protected bool _running = false;
        protected Int16 _port = 1020;
        private List<Thread> myThreadList = new List<Thread>(); // Declararea listei de thread-uri

        #region Constructors 

        private TCPCommClient()
        {
        }

        public TCPCommClient(string serverIP)
        {
            _serverIP = serverIP;
        }

        #endregion

        public void SendSignalData(string patientCode, string key, DateTime timestamp, double signalValue)
        {
            try
            {
                string signalValuePackedIntoString =
                    BuildPacketStringSignalValue(patientCode, key, timestamp, signalValue);
                this.SendSignalText(signalValuePackedIntoString);
            }
            catch (Exception ex)
            {
                throw new Exception("TCP client error on sending signalValue to the server system-> " + ex.Message);
            }
        }

        private string BuildPacketStringSignalValue(string patientCode, string key, DateTime timeStamp, double signalValue)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("#");
            builder.Append(key);
            builder.Append("," + timeStamp.ToString("dd-MMM-yyyy HH:mm:ss"));
            builder.Append("," + patientCode);
            builder.Append("," + signalValue.ToString("0.00", CultureInfo.InvariantCulture));
            builder.Append("#");

            return builder.ToString();
        }

        private void SendSignalText(string signalText)
        {
            try
            {
                RemouveClosedThreadsFromList();
                Thread newThread = new Thread(new ParameterizedThreadStart(SendSignalTextNewThread));
                myThreadList.Add(newThread);
                newThread.Start(signalText);
            }
            catch (Exception ex)
            {
                throw new Exception("TCP client error on sending signalValue to the server system->" + ex.Message);
            }
        }

        private void RemouveClosedThreadsFromList()
        {
            try
            {
                List<Thread> myAliveThreadList = new List<Thread>();
                foreach (Thread thread in myThreadList)
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

                myThreadList = myAliveThreadList;

            }
            catch (Exception ex)
            {
                throw new Exception("TCP Client error when trying to close the unused threads -> ", ex);
            }
        }

        private void SendSignalTextNewThread(Object signalTextObject)
        {
            String signalText = signalTextObject as string;
            if (signalText != null) return;
            try
            {
                TcpClient myTCPClient = new TcpClient(_serverIP, _port);

                NetworkStream stream = myTCPClient.GetStream();

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] buffer = encoding.GetBytes(signalText);

                stream.Write(buffer, 0, buffer.Length);
                myTCPClient.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
                foreach (Thread thread in myThreadList)
                {
                    thread.Abort();
                }
                myThreadList.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception(" Error on closing TCP client connection -> " + ex.Message);
            }
        }
    }
}
