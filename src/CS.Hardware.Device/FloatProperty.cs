namespace CS.Hardware.Device
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The float property.
    /// </summary>
    public class FloatProperty : PropertyBase
    {
        #region Private Fields

        private double value;

        private Dictionary<string, double> allowedvalues;

        private double minvalue;

        /// <summary>
        /// The maxvalue.
        /// </summary>
        private double maxvalue;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatProperty"/> class.
        /// </summary>
        public FloatProperty()
        {
            this.allowedvalues = new Dictionary<string, double>();
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public override PropertyType Type
        {
            get
            {
                return PropertyType.Float;
            }
        }

        /// <summary>
        /// The is allowed.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool IsAllowed(double val)
        {
            if (this.allowedvalues.Count != 0)
            {
                return this.allowedvalues.ContainsValue(val);
            }

            // If there are no elements in the dictionary, the value should be allowed.
            return true;
        }

        /// <summary>
        /// The is allowed.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool IsAllowed(long val)
        {
            return this.IsAllowed(this.FromLong(val));
        }

        /// <summary>
        /// The is allowed.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool IsAllowed(string val)
        {
            return this.IsAllowed(this.FromString(val));
        }

        /// <summary>
        /// The clear allowed values.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override void ClearAllowedValues()
        {
            this.allowedvalues.Clear();
        }

        /// <summary>
        /// The get allowed values.
        /// </summary>
        /// <param name="values">
        /// The values.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override void GetAllowedValues(out Dictionary<string, double> values)
        {
            values = this.allowedvalues;
        }

        /// <summary>
        /// The get allowed values.
        /// </summary>
        /// <param name="values">
        /// The values.
        /// </param>
        public override void GetAllowedValues(out Dictionary<string, long> values)
        {
            // Transform the <string, string> Dictionary to <string, double> using Linq
            // Works because Dictionary<TKey, TVal> is also IEnumerable<KeyValuePair<TKey, TVal>
            // http://stackoverflow.com/questions/2968356/linq-transform-dictionarykey-value-to-dictionaryvalue-key
            values = this.allowedvalues.ToDictionary(kvp => kvp.Key, kvp => this.ToLong(kvp.Value));
        }

        /// <summary>
        /// The get allowed values.
        /// </summary>
        /// <param name="values">
        /// The values.
        /// </param>
        public override void GetAllowedValues(out Dictionary<string, string> values)
        {
            // Transform the <string, string> Dictionary to <string, double> using Linq
            // Works because Dictionary<TKey, TVal> is also IEnumerable<KeyValuePair<TKey, TVal>
            // http://stackoverflow.com/questions/2968356/linq-transform-dictionarykey-value-to-dictionaryvalue-key
            values = this.allowedvalues.ToDictionary(kvp => kvp.Key, kvp => this.ToString(kvp.Value));
        }

        /// <summary>
        /// The add allowed value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public override void AddAllowedValue(string val, double data)
        {
            this.allowedvalues.Add(val, data);
        }

        /// <summary>
        /// The add allowed value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public override void AddAllowedValue(string val, long data)
        {
            this.allowedvalues.Add(val, this.FromLong(data));
        }

        /// <summary>
        /// The add allowed value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public override void AddAllowedValue(string val, string data)
        {
            this.allowedvalues.Add(val, this.FromString(data));
        }

        public override void GetValue(out double val)
        {
            val = this.value;
        }

        public override void GetValue(out long val)
        {
            val = this.ToLong(this.value);
        }

        public override void GetValue(out string val)
        {
            val = this.ToString(this.value);
        }

        public override void SetValue(string val)
        {
            this.SetValue(this.FromString(val));
        }

        public override void SetValue(double val)
        {
            if (this.HasLimits)
            {
                if (val >= this.minvalue && val <= this.maxvalue)
                {
                    this.value = val;
                }
                else
                {
                    throw new PropertyOutOfRangeException(
                        "The value: " + val +
                        " was outside of the range min: " + this.minvalue +
                        " - max: " + this.maxvalue);
                }
            }
            else
            {
                this.value = val;
            }
        }

        public override void SetValue(long val)
        {
            this.SetValue(this.FromLong(val));
        }

        public override void GetLimits(out double min, out double max)
        {
            if (this.HasLimits)
            {
                min = this.minvalue;
                max = this.maxvalue;
            }
            else
            {
                min = 0d;
                max = 0d;
            }
        }

        public override void GetLimits(out long min, out long max)
        {
            if (this.HasLimits)
            {
                min = this.ToLong(this.minvalue);
                max = this.ToLong(this.maxvalue);
            }
            else
            {
                min = 0L;
                max = 0L;
            }
        }

        public override void GetLimits(out string min, out string max)
        {
            if (this.HasLimits)
            {
                min = this.ToString(this.minvalue);
                max = this.ToString(this.maxvalue);
            }
            else
            {
                min = string.Empty;
                max = string.Empty;
            }
        }

        public override void SetLimits(double lowerLimit, double upperLimit)
        {
            this.HasLimits = true;
            if (this.allowedvalues.Count != 0)
            {
                this.HasLimits = false;
            }

            if (this.minvalue >= this.maxvalue)
            {
                this.HasLimits = false;
            }

            this.minvalue = lowerLimit;
            this.maxvalue = upperLimit;
        }

        public override void SetLimits(long lowerLimit, long upperLimit)
        {
            this.SetLimits(this.FromLong(lowerLimit), this.FromLong(upperLimit));
        }

        public override void SetLimits(string lowerLimit, string upperLimit)
        {
            this.SetLimits(this.FromString(lowerLimit), this.FromString(upperLimit));
        }

        #region Private Convenience Methods

        private double FromString(string val)
        {
            return Convert.ToDouble(val);
        }

        private double FromLong(long val)
        {
            return Convert.ToDouble(val);
        }

        private string ToString(double val)
        {
            // Ensure that the conversion to string is roundtrip safe.
            return val.ToString("R");
        }

        private long ToLong(double val)
        {
            return Convert.ToInt64(val);
        }

        #endregion
    }
}
