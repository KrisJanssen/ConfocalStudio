namespace CS.Hardware.Device
{
    /// <summary>
    /// The Device interface.
    /// </summary>
    public interface IDevice
    {
        /// <summary>
        /// Gets a value indicating whether the device is busy.
        /// </summary>
        bool IsBusy { get; }

        /// <summary>
        /// Gets a value indicating whether the device is initialized.
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the type of the device.
        /// </summary>
        /// <returns>
        /// The <see cref="DeviceType"/>.
        /// </returns>
        DeviceType Type { get; }

        /// <summary>
        /// The get property.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        void GetProperty(string name, out string value);

        /// <summary>
        /// The set property.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        void SetProperty(string name, string value);

        /// <summary>
        /// Initializes the device.
        /// </summary>
        void Initialize();

        /// <summary>
        /// The shutdown.
        /// </summary>
        void Shutdown();
    }
}
