namespace CS.Hardware.Device
{
    /// <summary>
    /// The galvo base.
    /// </summary>
    public abstract class GalvoBase : DeviceBase, IXYStage, IGalvo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GalvoBase"/> class.
        /// </summary>
        protected GalvoBase()
            : base(DeviceType.Galvo)
        {
        }

        /// <summary>
        /// The point and fire.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <param name="time">
        /// The time.
        /// </param>
        public abstract void PointAndFire(double x, double y, double time);

        /// <summary>
        /// The set position.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        public abstract void SetPosition(double x, double y);

        /// <summary>
        /// The set relative position.
        /// </summary>
        /// <param name="deltaX">
        /// The delta x.
        /// </param>
        /// <param name="deltaY">
        /// The delta y.
        /// </param>
        public abstract void SetRelativePosition(double deltaX, double deltaY);

        /// <summary>
        /// The get position.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        public abstract void GetPosition(out double x, out double y);

        /// <summary>
        /// The get limits.
        /// </summary>
        /// <param name="minX">
        /// The min x.
        /// </param>
        /// <param name="maxX">
        /// The max x.
        /// </param>
        /// <param name="minY">
        /// The min y.
        /// </param>
        /// <param name="maxY">
        /// The max y.
        /// </param>
        public abstract void GetLimits(out double minX, out double maxX, out double minY, out double maxY);

        /// <summary>
        /// The home.
        /// </summary>
        public abstract void Home();

        /// <summary>
        /// The stop.
        /// </summary>
        public abstract void Stop();
    }
}
