namespace CS.Hardware.Device
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Configuration;

    /// <summary>
    /// The property collection.
    /// </summary>
    public class PropertyCollection : IEnumerable<KeyValuePair<string, IProperty>>
    {
        /// <summary>
        /// The properties.
        /// </summary>
        private Dictionary<string, IProperty> properties;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyCollection"/> class.
        /// </summary>
        public PropertyCollection()
        {
            this.properties = new Dictionary<string, IProperty>();
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count
        {
            get
            {
                return this.properties.Count;
            }
        }

        /// <summary>
        /// Gets the names.
        /// </summary>
        public List<string> Names
        {
            get
            {
                return this.properties.Keys.ToList();
            }
        }

        /// <summary>
        /// The create property.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <exception cref="DuplicatePropertyException">
        /// Gets thrown when a property with the same key already exists.
        /// </exception>
        /// <exception cref="InvalidPropertyException">
        /// Gets thrown when there is an attempt to create an unknown datatype. 
        /// </exception>
        public void CreateProperty(string name, string value, PropertyType type)
        {
            if (this.properties.ContainsKey(name))
            {
                throw new DuplicatePropertyException("A property already exists with the key: " + name);
            }

            IProperty prop;

            switch (type)
            {
                case PropertyType.String:
                    prop = new StringProperty();
                    break;

                case PropertyType.Integer:
                    prop = new IntegerProperty();
                    break;

                case PropertyType.Float:
                    prop = new FloatProperty();
                    break;

                default:
                    throw new InvalidPropertyException("Attempt to set an invalid property type.");
            }

            // Assign a value to our property.
            prop.SetValue(value);

            // Actually add it to the collection.
            this.properties.Add(name, prop);
        }

        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="IProperty"/>.
        /// </returns>
        /// <exception cref="PropertyNotFoundException">
        /// Gets thrown when a property with the specified key is not found.
        /// </exception>
        public IProperty Find(string name)
        {
            if (!this.properties.ContainsKey(name))
            {
                throw new PropertyNotFoundException("Property " + name + " not found!");
            }
            
            return this.properties[name];
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <exception cref="PropertyNotFoundException">
        /// Gets thrown if the specified property is not found.
        /// </exception>
        public void Get(string name, out string value)
        {
            // TODO: This seems dodgy. Perhaps find a better way to do all this.
            value = string.Empty;

            IProperty prop = this.Find(name);

            // If the value is not cached, we get it from HW.
            if (!prop.IsCached)
            {
                if (prop.TryUpdate())
                {
                    prop.GetValue(out value);
                }
            }
            else
            {
                prop.GetValue(out value);
            }
        }

        /// <summary>
        /// The set.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <exception cref="PropertyNotFoundException">
        /// Gets thrown if the specified property is not found.
        /// </exception>
        public void Set(string name, string value)
        {
            // Try and get the property.
            IProperty prop = this.Find(name);

            // If the property is not read-only we can try and set it.
            if (!prop.IsReadOnly)
            {
                if (prop.IsAllowed(value))
                { 
                    // TODO: Consider the order of operations here... 
                    // Should we check success on the Try before setting 
                    // the value or should we just always set it?
                    /*if (prop.TryApply())
                    {
                        prop.SetValue(value);
                    }
                    prop.SetValue(value);*/

                    prop.TryApply();
                }
            }
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public IEnumerator<KeyValuePair<string, IProperty>> GetEnumerator()
        {
            return this.properties.GetEnumerator();
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
