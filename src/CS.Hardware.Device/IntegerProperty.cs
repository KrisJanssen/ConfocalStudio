using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Hardware.Device
{
    /// <summary>
    /// The integer property.
    /// </summary>
    public class IntegerProperty : PropertyBase
    {
        /// <summary>
        /// The value.
        /// </summary>
        private long value;

        /// <summary>
        /// Gets the kind.
        /// </summary>
        public override PropertyType Kind
        {
            get
            {
                return PropertyType.Integer;
            }
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void GetValue(out double val)
        {
            val = Convert.ToDouble(this.value);
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void GetValue(out long val)
        {
            val = this.value;
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void GetValue(out string val)
        {
            val = this.value.ToString("E", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void SetValue(string val)
        {
            this.value = Convert.ToInt64(val);
        }

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void SetValue(double val)
        {
            this.value = Convert.ToInt64(val);
        }

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void SetValue(long val)
        {
            this.value = Convert.ToInt64(val);
        }
    }
}
