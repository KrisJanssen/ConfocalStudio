namespace CS.Hardware.Device
{
    /// <summary>
    /// The XYStage interface defines the basic methods and properties of any XY Stage device.
    /// </summary>
    public interface IXYStage
    {
        /// <summary>
        /// Sets the XY position of the stage using the standard SI unit (meter)
        /// </summary>
        /// <param name="x">
        /// The x coordinate (meter).
        /// </param>
        /// <param name="y">
        /// The y coordinate (meter).
        /// </param>
        void SetPosition(double x, double y);

        /// <summary>
        /// Sets the relative position using the standard SI unit (meter).
        /// </summary>
        /// <param name="deltaX">
        /// The x coordinate (meter).
        /// </param>
        /// <param name="deltaY">
        /// The y coordinate (meter).
        /// </param>
        void SetRelativePosition(double deltaX, double deltaY);

        /// <summary>
        /// Gets the current position of the XYStage using the standard SI unit (meter)
        /// </summary>
        /// <param name="x">
        /// The x coordinate (meter).
        /// </param>
        /// <param name="y">
        /// The y coordinate (meter).
        /// </param>
        void GetPosition(out double x, out double y);

        /// <summary>
        /// Gets the motion range limits of the device.
        /// </summary>
        /// <param name="minX">
        /// The minimum x position in meters.
        /// </param>
        /// <param name="maxX">
        /// The maximum x position in meters.
        /// </param>
        /// <param name="minY">
        /// The minimum y position in meters.
        /// </param>
        /// <param name="maxY">
        /// The maximum y position in meters.
        /// </param>
        void GetLimits(out double minX, out double maxX, out double minY, out double maxY);

        /// <summary>
        /// Move the XYStage back to its home position.
        /// </summary>
        void Home();

        /// <summary>
        /// Stops any motion of the XYStage.
        /// </summary>
        void Stop();
    }
}
