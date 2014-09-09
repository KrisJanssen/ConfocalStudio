namespace CS.Hardware.Device
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a property of a Device.
    /// </summary>
    public interface IProperty
    {
        /// <summary>
        /// Gets the type of the backing value.
        /// </summary>
        PropertyType Type { get; }

        /// <summary>
        /// Gets a value indicating whether the propert has limits to its value.
        /// </summary>
        bool HasLimits { get; }

        /// <summary>
        /// Gets a value indicating whether the property has a value.
        /// </summary>
        bool HasValue { get; }

        /// <summary>
        /// Gets a value indicating whether the property value is cached.
        /// </summary>
        bool IsCached { get; }

        /// <summary>
        /// Gets a value indicating whether the property is read only.
        /// </summary>
        bool IsReadOnly { get; }

        /// <summary>
        /// The is allowed.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool IsAllowed(double val);

        /// <summary>
        /// The is allowed.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool IsAllowed(long val);

        /// <summary>
        /// The is allowed.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool IsAllowed(string val);

        /// <summary>
        /// The clear allowed values.
        /// </summary>
        void ClearAllowedValues();

        /// <summary>
        /// The get allowed values.
        /// </summary>
        /// <param name="values">
        /// The values.
        /// </param>
        void GetAllowedValues(out Dictionary<string, double> values);

        /// <summary>
        /// The get allowed values.
        /// </summary>
        /// <param name="values">
        /// The values.
        /// </param>
        void GetAllowedValues(out Dictionary<string, long> values);

        /// <summary>
        /// The get allowed values.
        /// </summary>
        /// <param name="values">
        /// The values.
        /// </param>
        void GetAllowedValues(out Dictionary<string, string> values);

        /// <summary>
        /// The add allowed value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        void AddAllowedValue(string val, string data);

        /// <summary>
        /// The add allowed value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        void AddAllowedValue(string val, double data);

        /// <summary>
        /// The add allowed value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        void AddAllowedValue(string val, long data);

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
        /// Gets the lower limit.
        /// </summary>
        /// <param name="min">
        /// The min.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        void GetLimits(out double min, out double max);

        /// <summary>
        /// Gets the lower limit.
        /// </summary>
        /// <param name="min">
        /// The min.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        void GetLimits(out long min, out long max);

        /// <summary>
        /// Gets the lower limit.
        /// </summary>
        /// <param name="min">
        /// The min.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        void GetLimits(out string min, out string max);

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

        /// <summary>
        /// The set limits.
        /// </summary>
        /// <param name="lowerLimit">
        /// The lower limit.
        /// </param>
        /// <param name="upperLimit">
        /// The upper limit.
        /// </param>
        void SetLimits(long lowerLimit, long upperLimit);

        /// <summary>
        /// The set limits.
        /// </summary>
        /// <param name="lowerLimit">
        /// The lower limit.
        /// </param>
        /// <param name="upperLimit">
        /// The upper limit.
        /// </param>
        void SetLimits(string lowerLimit, string upperLimit);

        /// <summary>
        /// The register property function.
        /// </summary>
        /// <param name="propertyFunc">
        /// The property func.
        /// </param>
        void RegisterPropertyFunction(Func<PropertyFuncType, bool> propertyFunc);

        /// <summary>
        /// The try apply.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool TryApply();

        /// <summary>
        /// The try update.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool TryUpdate();
    }
}
