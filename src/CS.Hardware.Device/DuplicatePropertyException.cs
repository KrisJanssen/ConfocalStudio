namespace CS.Hardware.Device
{
    using System;

    /// <summary>
    /// The duplicate property exception gets thrown upon trying to create a <see cref="IProperty"/> in
    /// the propertycollection with a key that already exists.
    /// </summary>
    internal class DuplicatePropertyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicatePropertyException"/> class.
        /// </summary>
        public DuplicatePropertyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicatePropertyException"/> class.
        /// </summary>
        /// <param name="message">
        /// The <see cref="DuplicatePropertyException"/> message.
        /// </param>
        public DuplicatePropertyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicatePropertyException"/> class.
        /// </summary>
        /// <param name="message">
        /// The <see cref="DuplicatePropertyException"/> message.
        /// </param>
        /// <param name="inner">
        /// The inner exception.
        /// </param>
        public DuplicatePropertyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
