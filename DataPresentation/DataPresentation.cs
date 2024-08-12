using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SensorValue;
using CommonReferences;
using TCPCommunication;

namespace DataPresentation
{
    public partial class DataPresentation : Form
    {
        Dictionary<PatientCodeEnum, PumpSensorValues> dictPatientPump = new Dictionary<PatientCodeEnum, PumpSensorValues>();



        private void startPumping(PatientCodeEnum patCodeEnum, int periodSeconds)
        {
            if (dictPatientPump.ContainsKey(patCodeEnum))
            {
                MessageBox.Show("The selected patient has the pump already started");
                return;
            }

            PumpSensorValues sensorValuesPump = new PumpSensorValues(patCodeEnum.ToString(), periodSeconds);
            sensorValuesPump.StartPumping();
            sensorValuesPump.newSensorValueEvent += new OnNewSensorValue(OnNewSensorValueHandler);
            dictPatientPump.Add(patCodeEnum, sensorValuesPump);
        }

        /* public enum PatientCodeEnum
         {
             Patient_01,
             Patient_02,
             Patient_03,
             Patient_04,
             Patient_05,
             Patient_06
         } */

        public delegate void VoidFunctionDelegate();
        private bool displayTheReceivingData = true;
        private bool sendAlsoThroughTCP = false;
        private TCPCommServer tcpCommServer;
        private TCPCommClient tcpCommClient;

        public DataPresentation()
        {
            InitializeComponent();
            cbPatientCodeStart.DataSource = Enum.GetValues(typeof(PatientCodeEnum));
            cbPacientFilter.DataSource = Enum.GetValues(typeof(PatientCodeEnum));

            tcpCommServer = new TCPCommServer();
            tcpCommServer.newSignalReceivedEvent += new NewSignalReceived(tcpCommServer_newSignalReceivedEvent);

        }

        void tcpCommServer_newSignalReceivedEvent(SensorValue.SensorValue sensorValue)
        {
            OnNewSensorValueHandler(sensorValue);
        }

        List<SensorValue.SensorValue> sensorValueList = new List<SensorValue.SensorValue>();

        void OnNewSensorValueHandler(SensorValue.SensorValue sensorValueArg)
        {
            if (sensorValueArg == null || string.IsNullOrEmpty(sensorValueArg.PatientCode) || sensorValueArg.Type == null)
            {
                // Log or handle invalid sensor value
                Console.WriteLine("Invalid sensor value received.");
                return;
            }

            // Insert the arrived value into Database
            DataStore.DAL_PatientData.AddData(sensorValueArg);

            // Insert the arrived value into current list and display the list into datagrid
            sensorValueList.Insert(0, sensorValueArg);
            this.BeginInvoke(new VoidFunctionDelegate(BindDataGridToListOfValues));
        }

        private void BindDataGridToListOfValues()
        {
            dgSensorValueList.DataSource = null;
            dgSensorValueList.DataSource = sensorValueList;
        }

        private void bStartPumping_Click(object sender, EventArgs e)
        {
            int timePeriodSeconds = 1;
            if (cbPatientCodeStart.SelectedItem != null && tbTimePeriod.Text != string.Empty)
            {
                try
                {
                    timePeriodSeconds = Convert.ToInt32(tbTimePeriod.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: the Time period text cannot be converted into integer -> " + ex.Message);
                    return;
                }

                PatientCodeEnum currPatient = (PatientCodeEnum)cbPatientCodeStart.SelectedItem;
                startPumping(currPatient, timePeriodSeconds);
            }
        }

        private void bStopPumping_Click(object sender, EventArgs e)
        {
            PatientCodeEnum currPaatientStop = (PatientCodeEnum)cbPatientCodeStart.SelectedItem;
            if (dictPatientPump.ContainsKey(currPaatientStop))
            {
                PumpSensorValues pumpToBeStopped = dictPatientPump[currPaatientStop];
                pumpToBeStopped.StopPumping();
                dictPatientPump.Remove(currPaatientStop);
            }
            else
            {
                MessageBox.Show("The selected patient has no pump values started");
            }
        }


        List<SensorValue.SensorValue> sensorValueListPast = new List<SensorValue.SensorValue>();

        private void bDisplayData_Click(object sender, EventArgs e)
        {
            displayTheReceivingData = false;
            PatientCodeEnum selectedPatient = (PatientCodeEnum)cbPacientFilter.SelectedItem;
            DateTime selectedDay = dayCalendar.SelectionStart;

            sensorValueListPast = DataStore.DAL_PatientData.GetData(selectedPatient, selectedDay);

            dgSensorValueList.DataSource = null;
            dgSensorValueList.DataSource = sensorValueListPast;
        }

        private void bReceivedData_Click(object sender, EventArgs e)
        {
            displayTheReceivingData = true;
            BindDataGridToListOfValues();
        }

        private void DataPresentation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcpCommServer != null) tcpCommServer.Dispose();
            if(tcpCommClient != null) tcpCommClient.Dispose();

        }

    }
}
