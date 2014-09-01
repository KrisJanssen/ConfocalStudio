namespace CS.Hardware.Device
{
    /// <summary>
    /// Represents a property of a Device.
    /// </summary>
    public interface IProperty
    {
        /// <summary>
        /// Gets the type of the backing value.
        /// </summary>
        PropertyType Kind { get; }

        /// <summary>
        /// Gets a value indicating whether has value.
        /// </summary>
        bool HasValue { get; }

        /// <summary>
        /// Gets a value indicating whether has limits.
        /// </summary>
        bool HasLimits { get; }

        /// <summary>
        /// Gets the lower limit.
        /// </summary>
        double LowerLimit { get; }

        /// <summary>
        /// Gets the upper limit.
        /// </summary>
        double UpperLimit { get; }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        void GetValue(out double val);

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        void GetValue(out long val);

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        void GetValue(out string val);

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The s val.
        /// </param>
        void SetValue(string val);

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The d val.
        /// </param>
        void SetValue(double val);

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="val">
        /// The l val.
        /// </param>
        void SetValue(long val);

        /// <summary>
        /// The set limits.
        /// </summary>
        /// <param name="lowerLimit">
        /// The lower limit.
        /// </param>
        /// <param name="upperLimit">
        /// The upper limit.
        /// </param>
        void SetLimits(double lowerLimit, double upperLimit);
    }
}
