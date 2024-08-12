using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using CommonReferences;

namespace SensorValue
{

    public delegate void OnNewSensorValue(SensorValue sensorValueArg);
    public class PumpSensorValues
    {
        public event OnNewSensorValue newSensorValueEvent;
        System.Timers.Timer timerBase; // Specificam explicit ca folosim System.Timers.Timer
                                       // Timer timerBase;
        Random myRandom;

        private string patientCode;

        public PumpSensorValues(string patientCode, int periodSecondsBetweenValues) : this(periodSecondsBetweenValues)
        {
            this.patientCode = patientCode;
        }

        public PumpSensorValues(int periodSecondsBetweenValues)
        {
            //start the random number generator
            myRandom = new Random();
            //define the timer for pumping sensor values
            timerBase = new System.Timers.Timer();
            timerBase.Interval = periodSecondsBetweenValues * 1000; //interval between ticks
            timerBase.Elapsed += new ElapsedEventHandler(timerBase_Elapsed);
        }
        public void StartPumping()
        {
            timerBase.Start();
        }

        public void StopPumping()
        {
            timerBase.Stop();
        }

        private void timerBase_Elapsed(Object sender, ElapsedEventArgs e)
        {
            int minNumber, maxNumber; double valueRandom;

            int maxSensorTyper = System.Enum.GetValues(typeof(SensorType)).GetUpperBound(0);

            int typeRandom = myRandom.Next(1, maxSensorTyper + 1);
            SensorType sensorTypeRandom = (SensorType)typeRandom;


            switch (sensorTypeRandom)
            {
                case SensorType.SkinTemperature:
                    minNumber = 36;
                    maxNumber = 40;
                    valueRandom = myRandom.Next(minNumber * 10, (maxNumber + 1) * 10) / 10.0;
                    break;
                case SensorType.BloodGlucose:
                    minNumber = 80;
                    maxNumber = 300;
                    valueRandom = myRandom.Next(minNumber, maxNumber + 1);
                    break;
                case SensorType.HeartRate:
                    minNumber = 30;
                    maxNumber = 200;
                    valueRandom = myRandom.Next(minNumber, maxNumber + 1);
                    break;
                default:
                    valueRandom = 0;
                    break;
            }
            SensorValue sensorRandom = new SensorValue(patientCode, sensorTypeRandom, valueRandom, DateTime.Now);
            Program.DisplaySensorValues("New sensor value arrived : ", sensorRandom);
            if (newSensorValueEvent != null)
            {
                newSensorValueEvent(sensorRandom);
            }
            
        }
    }
}
