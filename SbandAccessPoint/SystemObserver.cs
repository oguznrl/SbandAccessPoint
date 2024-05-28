using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbandAccessPoint
{
    abstract class SystemObserver
    {
        protected SystemObserver() { }

        public abstract bool receivePair(ref UInt64 uuid);
        public abstract bool receivePacket(ref String packet);
    }
}
