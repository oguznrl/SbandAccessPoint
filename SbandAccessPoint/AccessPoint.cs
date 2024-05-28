using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SbandAccessPoint
{
    abstract class AccessPoint
    {
        public UInt64 deviceID;
        public List<UInt64> ConnectedDevice = new List<ulong>();
        public int remindDeviceSlot = 50;
        public TranscieverHandler wifiSubscriber = new WifiHandler();
        public static TranscieverHandler antennaSubscriber = new AntennaHandler();

        protected AccessPoint() { 
        
        }
        protected AccessPoint(ulong deviceID,List<ulong> connectedDevice, int remindDeviceSlot)
        {
            ConnectedDevice = connectedDevice;
            this.deviceID = deviceID;
            this.remindDeviceSlot = remindDeviceSlot;
        }

        protected AccessPoint(ulong deviceID, List<ulong> connectedDevice)
        {
            this.deviceID = deviceID;
            ConnectedDevice = connectedDevice;
        }

        public abstract void sendPacketForSattelite();
        public abstract bool retrievePacket();
        public abstract bool addWifiDevice(AccessPoint device);
        public abstract bool removeWifiDevice(AccessPoint device);
    }
}
