namespace CS.Hardware.Device
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The string property.
    /// </summary>
    public class StringProperty : PropertyBase
    {
        #region Private Fields

        /// <summary>
        /// The backing value.
        /// </summary>
        private string value;

        /// <summary>
        /// The dictionary holding the allowed values, if any, for this property.
        /// </summary>
        private Dictionary<string, string> allowedvalues;

        #endregion

        /// <summary>
        /// Returns the backing type, which is string.
        /// </summary>
        public override PropertyType Type
        {
            get
            {
                return PropertyType.String;
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
            // Convert to string and call the correct overload.
            return this.IsAllowed(this.FromDouble(val));
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
            // Convert to string and call the correct overload.
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
            if (this.allowedvalues.Count != 0)
            {
                return this.allowedvalues.ContainsValue(val);
            }

            // If there are no elements in the dictionary, the value should be allowed.
            return true;
        }

        /// <summary>
        /// The clear allowed values.
        /// </summary>
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
        public override void GetAllowedValues(out Dictionary<string, double> values)
        {
            // Transform the <string, string> Dictionary to <string, double> using Linq
            // Works because Dictionary<TKey, TVal> is also IEnumerable<KeyValuePair<TKey, TVal>
            // http://stackoverflow.com/questions/2968356/linq-transform-dictionarykey-value-to-dictionaryvalue-key
            values = this.allowedvalues.ToDictionary(kvp => kvp.Key, kvp => this.ToDouble(kvp.Value));
        }

        /// <summary>
        /// The get allowed values.
        /// </summary>
        /// <param name="values">
        /// The values.
        /// </param>
        public override void GetAllowedValues(out Dictionary<string, long> values)
        {
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
            values = this.allowedvalues;
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
            this.AddAllowedValue(val, this.FromDouble(data));
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
            this.AddAllowedValue(val, this.FromLong(data));
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
            this.allowedvalues.Add(val, data);
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void GetValue(out double val)
        {
            val = this.ToDouble(this.value);
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void GetValue(out long val)
        {
            val = this.ToLong(this.value);
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void GetValue(out string val)
        {
            val = this.value;
        }

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void SetValue(string val)
        {
            this.value = val;
        }

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void SetValue(double val)
        {
            this.SetValue(this.FromDouble(val));
        }

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void SetValue(long val)
        {
            this.SetValue(this.FromLong(val));
        }

        /// <summary>
        /// The get limits.
        /// </summary>
        /// <param name="min">
        /// The min.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        public override void GetLimits(out double min, out double max)
        {
            min = 0d;
            max = 0d;
        }

        /// <summary>
        /// The get limits.
        /// </summary>
        /// <param name="min">
        /// The min.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        public override void GetLimits(out long min, out long max)
        {
            min = 0L;
            max = 0L;
        }

        /// <summary>
        /// The get limits.
        /// </summary>
        /// <param name="min">
        /// The min.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        public override void GetLimits(out string min, out string max)
        {
            min = string.Empty;
            max = string.Empty;
        }

        /// <summary>
        /// The set limits.
        /// </summary>
        /// <param name="lowerLimit">
        /// The lower limit.
        /// </param>
        /// <param name="upperLimit">
        /// The upper limit.
        /// </param>
        public override void SetLimits(double lowerLimit, double upperLimit)
        {
            // Do nothing, setting limits makes no sense for strings.
        }

        /// <summary>
        /// The set limits.
        /// </summary>
        /// <param name="lowerLimit">
        /// The lower limit.
        /// </param>
        /// <param name="upperLimit">
        /// The upper limit.
        /// </param>
        public override void SetLimits(long lowerLimit, long upperLimit)
        {
            // Do nothing, setting limits makes no sense for strings.
        }

        /// <summary>
        /// The set limits.
        /// </summary>
        /// <param name="lowerLimit">
        /// The lower limit.
        /// </param>
        /// <param name="upperLimit">
        /// The upper limit.
        /// </param>
        public override void SetLimits(string lowerLimit, string upperLimit)
        {
            // Do nothing, setting limits makes no sense for strings.
        }

        #region Private Convenience Methods

        /// <summary>
        /// The from double.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string FromDouble(double val)
        {
            // We use a round-trip safe ("R") conversion from double to string.
            return val.ToString("R");
        }

        /// <summary>
        /// The from long.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string FromLong(long val)
        {
            // Round-trip safety is not an issue for long
            return val.ToString();
        }

        /// <summary>
        /// The to double.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        private double ToDouble(string val)
        {
            return Convert.ToDouble(val);
        }

        /// <summary>
        /// The to long.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        private long ToLong(string val)
        {
            return Convert.ToInt64(val);
        }

        #endregion
    }
}
