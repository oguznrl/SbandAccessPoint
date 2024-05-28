using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbandAccessPoint
{
    internal class WifiPoint : AccessPoint
    {
        bool pairStatus;
        bool packetStatus;
        String receivedPacket;
        UInt64 uuid;
        public WifiObserver observerWifi = new WifiObserver();

        public WifiPoint(ulong deviceID, List<ulong> connectedDevice, int remindDeviceSlot) : base(deviceID, connectedDevice, remindDeviceSlot)
        {

        }
        public WifiPoint() { }
        public override bool addWifiDevice(AccessPoint device)
        {
            throw new NotImplementedException();
        }

        public override bool removeWifiDevice(AccessPoint device)
        {
            throw new NotImplementedException();
        }

        public override void sendPacketForSattelite()
        {
            try
            { 
                antennaSubscriber.transmitPacket(); //  handlePacket(dequeued_data);
                wifiSubscriber.transmitPacket(); //  wifiSubscriber.handlePacket(dequeued_data);
                remindDeviceSlot++;
            }
            catch
            {

            }
            
        }

        public override bool retrievePacket()
        {
            pairStatus = observerWifi.receivePair(ref uuid);

            packetStatus = observerWifi.receivePacket(ref receivedPacket);
            if (pairStatus)
            {
                ConnectedDevice.Add(uuid);
                wifiSubscriber.handlePacket("ACK" + uuid);
                remindDeviceSlot--;
                return true;
            }
            else if (packetStatus)  
            {
                antennaSubscriber.handlePacket(receivedPacket);
                return true;
            }
            return false;
        }
    }
}
