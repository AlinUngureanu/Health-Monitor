using System;
using CommonReferences;

namespace SensorValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Instantierea clasei SensorValue\n\r");

            // instantiation using the default constructor; the measurement values ​​are given using the properties
            SensorValue sensor1 = new SensorValue();
            sensor1.Type = SensorType.BloodGlucose;
            sensor1.TimeStamp = DateTime.Now;
            sensor1.Value = 100; //mg/d1
            DisplaySensorValues("Primul sensor initializat ", sensor1);

            // instantiation using the constructor with parameters
            SensorValue sensor2 = new SensorValue(SensorType.SkinTemperature, 36.7, "23-Jan-10 14:56:00");
            DisplaySensorValues("Al doilea sensor initializat ", sensor2);
            PumpSensorValues sensorValuesPump = new PumpSensorValues(3);
            sensorValuesPump.StartPumping();

            Console.ReadLine();
            sensorValuesPump.StopPumping();
        }

        internal static void DisplaySensorValues(string headerText, SensorValue sensor)
        {
            Console.WriteLine("\t " + headerText);
            Console.WriteLine("\t\t Type = {0} ", sensor.TypeToString);
            Console.WriteLine("\t\t TimeStamp = {0} ", sensor.TimeStampString);
            Console.WriteLine("\t\t Value = {0} ", sensor.Value.ToString("0.00"));

        }
    }
}