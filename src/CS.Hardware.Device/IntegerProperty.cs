using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Hardware.Device
{
    using System.Threading;

    /// <summary>
    /// The integer property.
    /// </summary>
    public class IntegerProperty : PropertyBase
    {
        #region Private Fields

        /// <summary>
        /// The value.
        /// </summary>
        private long value;

        /// <summary>
        /// The allowedvalues.
        /// </summary>
        private Dictionary<string, long> allowedvalues;

        /// <summary>
        /// The minvalue.
        /// </summary>
        private long minvalue;

        /// <summary>
        /// The maxvalue.
        /// </summary>
        private long maxvalue;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerProperty"/> class.
        /// </summary>
        public IntegerProperty()
        {
            this.allowedvalues = new Dictionary<string, long>();
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public override PropertyType Type
        {
            get
            {
                return PropertyType.Integer;
            }
        }

        public override bool IsAllowed(double val)
        {
            return this.IsAllowed(this.FromDouble(val));
        }

        public override bool IsAllowed(long val)
        {
            if (this.allowedvalues.Count != 0)
            {
                return this.allowedvalues.ContainsValue(val);
            }

            // If there are no elements in the dictionary, the value should be allowed.
            return true;
        }

        public override bool IsAllowed(string val)
        {
            return this.IsAllowed(this.FromString(val));
        }

        public override void ClearAllowedValues()
        {
            this.allowedvalues.Clear();
        }

        public override void GetAllowedValues(out Dictionary<string, double> values)
        {
            // Transform the <string, string> Dictionary to <string, double> using Linq
            // Works because Dictionary<TKey, TVal> is also IEnumerable<KeyValuePair<TKey, TVal>
            // http://stackoverflow.com/questions/2968356/linq-transform-dictionarykey-value-to-dictionaryvalue-key
            values = this.allowedvalues.ToDictionary(kvp => kvp.Key, kvp => this.ToDouble(kvp.Value));
        }

        public override void GetAllowedValues(out Dictionary<string, long> values)
        {
            values = this.allowedvalues;
        }

        public override void GetAllowedValues(out Dictionary<string, string> values)
        {
            values = this.allowedvalues.ToDictionary(kvp => kvp.Key, kvp => this.ToString(kvp.Value));
        }

        public override void AddAllowedValue(string val, string data)
        {
            this.AddAllowedValue(val, this.FromString(data));
        }

        public override void AddAllowedValue(string val, double data)
        {
            this.AddAllowedValue(val, this.FromDouble(data));
        }

        public override void AddAllowedValue(string val, long data)
        {
            this.allowedvalues.Add(val, data);
        }

        public override void GetValue(out double val)
        {
            val = this.ToDouble(this.value);
        }

        public override void GetValue(out long val)
        {
            val = this.value;
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
            this.SetValue(this.FromDouble(val));
        }

        public override void SetValue(long val)
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

        public override void GetLimits(out double min, out double max)
        {
            if (this.HasLimits)
            {
                min = this.ToDouble(this.minvalue);
                max = this.ToDouble(this.maxvalue);
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
                min = this.minvalue;
                max = this.maxvalue;
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
            this.SetLimits(this.FromDouble(lowerLimit), this.FromDouble(upperLimit));
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
            this.SetLimits(this.FromString(lowerLimit), this.FromString(upperLimit));
        }

        #region Private Convenience Methods

        private long FromDouble(double val)
        {
            return Convert.ToInt64(val);
        }

        private long FromString(string val)
        {
            return Convert.ToInt64(val);
        }

        private double ToDouble(long val)
        {
            return Convert.ToDouble(val);
        }

        private string ToString(long val)
        {
            return val.ToString();
        }

        #endregion
    }



}
