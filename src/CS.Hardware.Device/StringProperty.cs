namespace CS.Hardware.Device
{
    using System.Globalization;

    /// <summary>
    /// The string property.
    /// </summary>
    public class StringProperty : PropertyBase
    {
        /// <summary>
        /// The value.
        /// </summary>
        private string value;

        /// <summary>
        /// Gets the kind.
        /// </summary>
        public override PropertyType Kind
        {
            get
            {
                return PropertyType.String;
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
            val = 0d;
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public override void GetValue(out long val)
        {
            val = 0L;
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
        /// Sets the property value from a string input.
        /// </summary>
        /// <param name="val">
        /// The string value to set the property to.
        /// </param>
        public override void SetValue(string val)
        {
            this.value = val;
        }

        /// <summary>
        /// Sets the property value from a double input.
        /// </summary>
        /// <param name="val">
        /// The double value to set the property to.
        /// </param>
        public override void SetValue(double val)
        {
            this.value = val.ToString("E", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Sets the property value from a long input.
        /// </summary>
        /// <param name="val">
        /// The long value to set the property to.
        /// </param>
        public override void SetValue(long val)
        {
            this.value = val.ToString("E", CultureInfo.InvariantCulture);
        }
    }
}
