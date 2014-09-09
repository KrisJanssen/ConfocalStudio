using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Hardware.Device
{
    public abstract class SerialBase : DeviceBase, ISerial
    {
        protected SerialBase()
            : base(DeviceType.Serial)
        {
            
        }
        public abstract PortType GetPortType { get; }

        public abstract void SendCommand(string command);

        public abstract void GetResponse();

        public abstract void Write();

        public abstract void Read();

        public abstract void Purge();
    }
}
