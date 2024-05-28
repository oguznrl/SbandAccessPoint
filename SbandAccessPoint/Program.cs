using SbandAccessPoint;
using System;
using System.Threading;
using System.Timers;

internal class Program
{
    private static System.Timers.Timer receive_packet_timer;
    private static System.Timers.Timer send_packet_timer;
    private static WifiComposite composite = new WifiComposite();
    private static void Main(string[] args)
    {
        composite.addWifiDevice(new WifiPoint());
        composite.addWifiDevice(new WifiPoint());
        SetTimer();
        Console.ReadLine();
        receive_packet_timer.Stop();
        receive_packet_timer.Dispose();
        send_packet_timer.Stop();
        send_packet_timer.Dispose();
        Console.WriteLine("Hello World\n");

    }

    private static void SetTimer()
    {
        // Create a timer with a two second interval.
        receive_packet_timer = new System.Timers.Timer(500);
        send_packet_timer = new System.Timers.Timer(700);
        // Hook up the Elapsed event for the timer. 
        receive_packet_timer.Elapsed += receive_data_event;
        receive_packet_timer.AutoReset = true;
        receive_packet_timer.Enabled = true;

        send_packet_timer.Elapsed += send_data_event;
        send_packet_timer.AutoReset = true;
        send_packet_timer.Enabled = true;

    }

    private static void receive_data_event(Object source, ElapsedEventArgs e)
    {
        composite.retrievePacket();
    }
    private static void send_data_event(Object source, ElapsedEventArgs e)
    {
        composite.sendPacketForSattelite();
    }
}