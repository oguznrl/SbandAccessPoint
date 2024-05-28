using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbandAccessPoint
{
    abstract class TranscieverHandler
    {
        public Queue<String> transcieverQueue = new Queue<String>();

        public abstract void handlePacket(String packet);
        public abstract void transmitPacket();
    }
}
