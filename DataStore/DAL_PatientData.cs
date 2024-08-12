using SensorValue;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CommonReferences;

namespace DataStore
{
    public class DAL_PatientData
    {
        public static void AddData(SensorValue.SensorValue sensorData)
        {
            // Verificare dacă sensorData sau una dintre proprietățile sale este null sau goală
            if (sensorData == null)
            {
                throw new ArgumentNullException(nameof(sensorData), "Sensor data is null.");
            }

            if (string.IsNullOrEmpty(sensorData.PatientCode))
            {
                Console.WriteLine(sensorData.PatientCode);
                throw new ArgumentException("Patient code is null or empty.", nameof(sensorData.PatientCode));
            }

            if (sensorData.Type == null) // Asumând că sensorData.Type poate fi null
            {
                Console.WriteLine(sensorData.Type);
                throw new ArgumentException("Sensor type is null.", nameof(sensorData.Type));
            }

            SqlConnection conn = new SqlConnection
            {
                ConnectionString = @"Data Source=DESKTOP-9GKFSI5\SQLEXPRESS;Initial Catalog=PatientData;Integrated Security=True;"
            };

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO patientdata (id, patient_code, sensor_type, timestamp, value) " +
                              "VALUES (@id, @patient_code, @sensor_type, @timestamp, @value)";

            cmd.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
            cmd.Parameters.AddWithValue("@patient_code", sensorData.PatientCode.ToString());
            cmd.Parameters.AddWithValue("@sensor_type", sensorData.Type);
            cmd.Parameters.AddWithValue("@timestamp", sensorData.TimeStamp);
            cmd.Parameters.AddWithValue("@value", sensorData.Value);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Înregistrează excepția originală și aruncă o nouă excepție cu un mesaj detaliat
                throw new Exception("Error adding PatientData: " + ex.Message, ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<SensorValue.SensorValue> GetData(PatientCodeEnum patCode, DateTime currDay)
        {
            List<SensorValue.SensorValue> sensorValueList = new List<SensorValue.SensorValue>();

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-9GKFSI5\\SQLEXPRESS;Initial Catalog=PatientData;Integrated Security=True;");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT id, patient_code, sensor_type, timestamp, value FROM PatientData " +
                              "WHERE patient_code = @patient_code AND timestamp >= @minTime AND timestamp < @maxTime";
            cmd.Parameters.AddWithValue("@patient_code", patCode.ToString());
            cmd.Parameters.AddWithValue("@minTime", currDay.Date);
            cmd.Parameters.AddWithValue("@maxTime", currDay.Date.AddDays(1));

            SqlDataReader reader = null;
            try
            {
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SensorValue.SensorValue pItem = new SensorValue.SensorValue();
                    if (reader["patient_code"] != DBNull.Value) pItem.PatientCode = (string)reader["patient_code"];
                    if (reader["sensor_type"] != DBNull.Value)
                    {
                        string strType = (string)reader["sensor_type"];
                        pItem.Type = (SensorType)Enum.Parse(typeof(SensorType), strType);
                    }
                    if (reader["timestamp"] != DBNull.Value) pItem.TimeStamp = (DateTime)reader["timestamp"];
                    if (reader["value"] != DBNull.Value) pItem.Value = Convert.ToDouble(reader["value"]);
                    sensorValueList.Add(pItem);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error on reading from PatientData table " + ex.Message, ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                cmd.Connection.Close();
            }
            return sensorValueList;
        }
    }
}