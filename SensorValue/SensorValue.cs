using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using CommonReferences;

namespace SensorValue
{
    /*public enum SensorType
    {
        None,
        SkinTemperature,
        HeartRate,
        BloodGlucose
    }*/
   
    public class SensorValue
    {
        private string _patientCode;
        private SensorType _type;
        private double _value;
        private DateTime _timeStamp;

        #region properties
        public string PatientCode
        {
            get { return _patientCode; }
            set { _patientCode = value; }
        }
        public SensorType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }
        public string TimeStampString
        {
            get { return _timeStamp.ToString("dd-MMM-yy HH:mm:ss"); }
            set { _timeStamp = DateTime.ParseExact(value, "dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture); }
        }
        #endregion

        public string TypeToString
        {
            get { return _type.ToString(); }
        }

        #region constructors
        public SensorValue()
        {
            _type = SensorType.None;
        }
        public SensorValue(string patientCode, SensorType type, double value, DateTime timeStamp)
        {
            this._patientCode = patientCode;
            this._type = type;
            this._value = value;
            this._timeStamp = timeStamp;
        }
        public SensorValue(SensorType type, double value, string timeStamp)
        {
            this._type = type;
            this._value = value;
            this.TimeStampString = timeStamp;
        }
        public SensorValue(SensorType type, double value, DateTime timeStamp)
        {
            this._type = type;
            this._value = value;
            this._timeStamp = timeStamp;
        }
        #endregion
    }
}
