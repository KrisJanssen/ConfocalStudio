namespace CS.Hardware.Device
{
    using System;

    /// <summary>
    /// The invalid property exception gets thrown upon trying to create a <see cref="IProperty"/> in
    /// the propertycollection with a key that already exists.
    /// </summary>
    internal class InvalidPropertyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPropertyException"/> class.
        /// </summary>
        public InvalidPropertyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPropertyException"/> class.
        /// </summary>
        /// <param name="message">
        /// The <see cref="DuplicatePropertyException"/> message.
        /// </param>
        public InvalidPropertyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPropertyException"/> class.
        /// </summary>
        /// <param name="message">
        /// The <see cref="DuplicatePropertyException"/> message.
        /// </param>
        /// <param name="inner">
        /// The inner exception.
        /// </param>
        public InvalidPropertyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
