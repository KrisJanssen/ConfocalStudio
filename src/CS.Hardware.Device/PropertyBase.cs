namespace CS.Hardware.Device
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The property base class implements some common functionality shared between different Property types.
    /// </summary>
    public abstract class PropertyBase : IProperty
    {
        #region Private Fields

        /// <summary>
        /// A delegate that can be executed when a property is applied or updated.
        /// </summary>
        private Func<PropertyFuncType, bool> pfunc;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyBase"/> class.
        /// </summary>
        protected PropertyBase()
        {
            this.HasLimits = false;
            this.HasValue = false;
            this.IsCached = false;
            this.IsCached = false;
            this.pfunc = null;
        }

        /// <summary>
        /// Gets type of the property.
        /// </summary>
        public abstract PropertyType Type { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the property has limits.
        /// </summary>
        public bool HasLimits { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether the property has value.
        /// </summary>
        public bool HasValue { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether the property value is cached.
        /// </summary>
        public bool IsCached { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether is read only.
        /// </summary>
        public virtual bool IsReadOnly { get; protected set; }

        /// <summary>
        /// The is allowed.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public abstract bool IsAllowed(double val);

        /// <summary>
        /// The is allowed.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public abstract bool IsAllowed(long val);

        /// <summary>
        /// The is allowed.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public abstract bool IsAllowed(string val);

        /// <summary>
        /// The clear allowed values.
        /// </summary>
        public abstract void ClearAllowedValues();

        /// <summary>
        /// The get allowed values.
        /// </summary>
        /// <param name="values">
        /// The values.
        /// </param>
        public abstract void GetAllowedValues(out Dictionary<string, double> values);

        /// <summary>
        /// The get allowed values.
        /// </summary>
        /// <param name="values">
        /// The values.
        /// </param>
        public abstract void GetAllowedValues(out Dictionary<string, long> values);

        /// <summary>
        /// The get allowed values.
        /// </summary>
        /// <param name="values">
        /// The values.
        /// </param>
        public abstract void GetAllowedValues(out Dictionary<string, string> values);

        /// <summary>
        /// The add allowed value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public abstract void AddAllowedValue(string val, double data);

        /// <summary>
        /// The add allowed value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public abstract void AddAllowedValue(string val, long data);

        /// <summary>
        /// The add allowed value.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public abstract void AddAllowedValue(string val, string data);

        /// <summary>
        /// Gets the property value as a double.
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
        /// The get limits.
        /// </summary>
        /// <param name="min">
        /// The min.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        public abstract void GetLimits(out double min, out double max);

        /// <summary>
        /// The get limits.
        /// </summary>
        /// <param name="min">
        /// The min.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        public abstract void GetLimits(out long min, out long max);

        /// <summary>
        /// The get limits.
        /// </summary>
        /// <param name="min">
        /// The min.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        public abstract void GetLimits(out string min, out string max);

        /// <summary>
        /// The set limits.
        /// </summary>
        /// <param name="lowerLimit">
        /// The lower limit.
        /// </param>
        /// <param name="upperLimit">
        /// The upper limit.
        /// </param>
        public abstract void SetLimits(double lowerLimit, double upperLimit);

        /// <summary>
        /// The set limits.
        /// </summary>
        /// <param name="lowerLimit">
        /// The lower limit.
        /// </param>
        /// <param name="upperLimit">
        /// The upper limit.
        /// </param>
        public abstract void SetLimits(long lowerLimit, long upperLimit);

        /// <summary>
        /// The set limits.
        /// </summary>
        /// <param name="lowerLimit">
        /// The lower limit.
        /// </param>
        /// <param name="upperLimit">
        /// The upper limit.
        /// </param>
        public abstract void SetLimits(string lowerLimit, string upperLimit);

        /// <summary>
        /// Registers a <see cref="Func{PropertyFuncType,bool}"/> that is executed upon update or apply of a property value.
        /// </summary>
        /// <param name="propertyFunc">
        /// The p func.
        /// </param>
        public void RegisterPropertyFunction(Func<PropertyFuncType, bool> propertyFunc)
        {
            this.pfunc = propertyFunc;
        }

        /// <summary>
        /// The try apply.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool TryApply()
        {
            // TODO: Consider a caching system.
            if (this.pfunc != null)
            {
                return this.pfunc(PropertyFuncType.Apply);
            }

            // If there is no function delegate, we can return true.
            return true;
        }

        /// <summary>
        /// The try update.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool TryUpdate()
        {
            // TODO: Consider a caching system.
            if (this.pfunc != null)
            {
                return this.pfunc(PropertyFuncType.Update);
            }

            // If there is no function delegate, we can return true.
            return true;
        }
    }
}
