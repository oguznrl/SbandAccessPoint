using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbandAccessPoint
{
    internal class WifiHandler : TranscieverHandler
    {
        public override void handlePacket(string packet)
        {
            transcieverQueue.Enqueue(packet);
        }

        public override void transmitPacket()
        {
            Console.WriteLine("Wifi Send ACK for Pairing"+ transcieverQueue.Dequeue()+"\n");
        }
    }
}
