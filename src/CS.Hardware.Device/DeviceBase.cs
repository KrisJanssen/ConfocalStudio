namespace CS.Hardware.Device
{
    /// <summary>
    /// The device base.
    /// </summary>
    public abstract class DeviceBase : IDevice
    {
        /// <summary>
        /// The device props.
        /// </summary>
        private readonly PropertyCollection deviceProps;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceBase{T,U}"/> class. 
        /// Initializes a new instance of the <see cref="DeviceBase"/> class.
        /// </summary>
        protected DeviceBase()
        {
            // We always need a PropertyCollection.
            this.deviceProps = new PropertyCollection();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceBase"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        protected DeviceBase(DeviceType type)
            : this()
        {
            this.Type = type;
        }

        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        public abstract bool IsBusy { get; }

        /// <summary>
        /// Gets a value indicating whether is initialized.
        /// </summary>
        public abstract bool IsInitialized { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the get type.
        /// </summary>
        public DeviceType Type { get; private set; }

        /// <summary>
        /// The get property.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void GetProperty(string name, out string value)
        {
            this.deviceProps.Get(name, out value);
        }

        /// <summary>
        /// The set property.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void SetProperty(string name, string value)
        {
            this.deviceProps.Set(name, value);
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// The shutdown.
        /// </summary>
        public abstract void Shutdown();
    }
}
