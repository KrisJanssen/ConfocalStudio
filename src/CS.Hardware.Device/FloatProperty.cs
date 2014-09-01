namespace CS.Hardware.Device
{
    using System;

    /// <summary>
    /// The float property.
    /// </summary>
    public class FloatProperty : PropertyBase
    {
        /// <summary>
        /// The value.
        /// </summary>
        private double value;

        /// <summary>
        /// Gets the kind.
        /// </summary>
        public override PropertyType Kind
        {
            get
            {
                return PropertyType.Float;
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
            val = this.value;
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void GetValue(out long val)
        {
            val = Convert.ToInt64(this.value);
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void GetValue(out string val)
        {
            val = Convert.ToString(this.value);
        }

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void SetValue(string val)
        {
            this.value = Convert.ToDouble(val);
        }

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void SetValue(double val)
        {
            this.value = val;
        }

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void SetValue(long val)
        {
            this.value = Convert.ToDouble(val);
        }
    }
}
