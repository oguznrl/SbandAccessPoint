using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbandAccessPoint
{
    internal class WifiComposite : AccessPoint
    {
        public List<AccessPoint> accessPoints = new List<AccessPoint>();
        public int deviceLimit = 8;
        public WifiComposite() : base()
        {
        }

        public WifiComposite(ulong deviceID, List<ulong> connectedDevice) : base(deviceID, connectedDevice)
        {
        }

        public override bool addWifiDevice(AccessPoint device)
        {
            accessPoints.Add(device);
            deviceLimit--;
            return true;
        }

        public override bool removeWifiDevice(AccessPoint device)
        {
            accessPoints.Remove(device);
            deviceLimit++;
            return true;
        }

        public bool expandLine()
        {
            accessPoints.Add(new WifiPoint());
            deviceLimit--;
            return true;
        }
        public override void sendPacketForSattelite()
        {
            foreach (var item in accessPoints)
            {
                item.sendPacketForSattelite();
            }
        }
        public override bool retrievePacket()
        {
            bool sufficient_device_flag = false;
            foreach (var item in accessPoints)
            {
                if (item.remindDeviceSlot!=0)
                {
                    sufficient_device_flag = true;
                    break;
                }
            }
            if (!sufficient_device_flag)
            {
                expandLine();
            }
            foreach (var item in accessPoints)
            {
                item.retrievePacket();
            }
            return true;
        }
    }
}
