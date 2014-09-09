namespace CS.Hardware.Device
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The port type enumerator holds all known port types.
    /// </summary>
    public enum PortType
    {
        // ReSharper disable InconsistentNaming
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented",
            Justification = "Reviewed. Suppression is OK here.")]
        InvalidPort,

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented",
            Justification = "Reviewed. Suppression is OK here.")]
        SerialPort,

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented",
            Justification = "Reviewed. Suppression is OK here.")]
        USBPort,

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented",
            Justification = "Reviewed. Suppression is OK here.")]
        HIDPort
        // ReSharper restore InconsistentNaming
    }
}
