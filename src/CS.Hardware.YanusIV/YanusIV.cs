using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS.Hardware.Device;

namespace CS.Hardware.YanusIV
{
    /// <summary>
    /// The yanus iv.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class YanusIV : GalvoBase
    {
        public override bool IsBusy
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsInitialized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override void Shutdown()
        {
            throw new NotImplementedException();
        }

        public override void PointAndFire(double x, double y, double time)
        {
            throw new NotImplementedException();
        }

        public override void SetPosition(double x, double y)
        {
            throw new NotImplementedException();
        }

        public override void SetRelativePosition(double deltaX, double deltaY)
        {
            throw new NotImplementedException();
        }

        public override void GetPosition(out double x, out double y)
        {
            throw new NotImplementedException();
        }

        public override void GetLimits(out double minX, out double maxX, out double minY, out double maxY)
        {
            throw new NotImplementedException();
        }

        public override void Home()
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
