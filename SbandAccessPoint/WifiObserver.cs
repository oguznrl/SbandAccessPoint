using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SbandAccessPoint
{
    internal class WifiObserver : SystemObserver
    {
        public WifiObserver()
        {
        }

        public override bool receivePacket(ref String packet)
        {
            Random rnd = new Random();
            rnd.Next();
            
            if (rnd.Next()<int.MaxValue/2)
            {
                packet = rnd.Next().ToString();
                Console.WriteLine(packet+" is received packet. \n");
                return true;
            }
            else 
            { 
                return false; 
            }
            
        }

        public override bool receivePair(ref UInt64 uuid)
        {

            Random rnd = new Random();
            if (rnd.Next() < int.MaxValue / 2)
            {
                uuid = (ulong)(rnd.Next()<<32 | rnd.Next());
                Console.WriteLine(uuid + " is received pairing demand. \n");
                return true; 
            }
            else { 
                return false; 
            }
        }
    }
}
