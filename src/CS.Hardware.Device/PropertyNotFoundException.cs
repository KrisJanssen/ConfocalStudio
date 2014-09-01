namespace CS.Hardware.Device
{
    using System;

    /// <summary>
    /// The invalid property exception gets thrown upon trying to create a <see cref="IProperty"/> in
    /// the propertycollection with a key that already exists.
    /// </summary>
    internal class PropertyNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyNotFoundException"/> class.
        /// </summary>
        public PropertyNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// The <see cref="PropertyNotFoundException"/> message.
        /// </param>
        public PropertyNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// The <see cref="PropertyNotFoundException"/> message.
        /// </param>
        /// <param name="inner">
        /// The inner exception.
        /// </param>
        public PropertyNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}