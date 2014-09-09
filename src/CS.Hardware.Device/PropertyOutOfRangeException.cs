using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Hardware.Device
{
    /// <summary>
    /// The property out of range exception.
    /// </summary>
    internal class PropertyOutOfRangeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyOutOfRangeException"/> class.
        /// </summary>
        public PropertyOutOfRangeException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyOutOfRangeException"/> class.
        /// </summary>
        /// <param name="message">
        /// The <see cref="PropertyOutOfRangeException"/> message.
        /// </param>
        public PropertyOutOfRangeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyOutOfRangeException"/> class.
        /// </summary>
        /// <param name="message">
        /// The <see cref="PropertyOutOfRangeException"/> message.
        /// </param>
        /// <param name="inner">
        /// The inner exception.
        /// </param>
        public PropertyOutOfRangeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
