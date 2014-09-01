namespace CS.Hardware.Device
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The property base.
    /// </summary>
    public abstract class PropertyBase : IProperty
    {
        /// <summary>
        /// The hasvalue.
        /// </summary>
        private bool hasvalue = false;

        /// <summary>
        /// The haslimits.
        /// </summary>
        private bool haslimits = false;

        /// <summary>
        /// The lowerlimit.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:UseBuiltInTypeAlias", Justification = "Reviewed. Suppression is OK here.")]
        private double lowerlimit = Double.MinValue;

        /// <summary>
        /// The upperlimitlimit.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:UseBuiltInTypeAlias", Justification = "Reviewed. Suppression is OK here.")]
        private double upperlimit = Double.MaxValue;

        /// <summary>
        /// Gets the kind.
        /// </summary>
        public abstract PropertyType Kind { get; }

        /// <summary>
        /// Gets a value indicating whether has value.
        /// </summary>
        public bool HasValue
        {
            get
            {
                return this.hasvalue;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the property has limits.
        /// </summary>
        public bool HasLimits
        {
            get
            {
                return this.haslimits;
            }
        }

        /// <summary>
        /// Gets the lower limit.
        /// </summary>
        public double LowerLimit
        {
            get
            {
                return this.haslimits ? this.upperlimit : 0d;
            }
        }

        /// <summary>
        /// Gets the upper limit.
        /// </summary>
        public double UpperLimit
        {
            get
            {
                return this.haslimits ? this.lowerlimit : 0d;
            }
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public abstract void GetValue(out double val);

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public abstract void GetValue(out long val);

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        public abstract void GetValue(out string val);

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The s val.
        /// </param>
        public abstract void SetValue(string val);

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The d val.
        /// </param>
        public abstract void SetValue(double val);

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The l val.
        /// </param>
        public abstract void SetValue(long val);

        /// <summary>
        /// The set limits.
        /// </summary>
        /// <param name="lowerLimit">
        /// The lower limit.
        /// </param>
        /// <param name="upperLimit">
        /// The upper limit.
        /// </param>
        public void SetLimits(double lowerLimit, double upperLimit)
        {
            this.haslimits = true;

            if (lowerLimit >= upperLimit)
            {
                this.haslimits = false;
            }

            this.lowerlimit = lowerLimit;
            this.upperlimit = upperLimit;
        }
    }
}
