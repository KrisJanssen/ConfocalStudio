using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Hardware.Device
{
    using System.Dynamic;

    public interface ISerial
    {
        PortType GetPortType { get; }

        void SendCommand(string command);

        void GetResponse();

        void Write();

        void Read();

        void Purge();
    }
}
