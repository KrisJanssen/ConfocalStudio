using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Hardware.Device
{
    /// <summary>
    /// The alvo interface.
    /// </summary>
    public interface IGalvo
    {
        void PointAndFire(double x, double y, double time);


    }
}
