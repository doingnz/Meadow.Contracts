using Meadow.Gateway.WiFi;
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Meadow.Hardware;

/// <summary>
/// Data relating to a WiFi connection.
/// </summary>
public class WirelessNetworkConnectionEventArgs : NetworkConnectionEventArgs
{
    /// <summary>
    /// SSID of the network the device is connected to.
    /// </summary>
    public string Ssid { get; private set; }

    /// <summary>
    /// BSSID (MAC) of the network the device is connected to.
    /// </summary>
    public PhysicalAddress Bssid { get; private set; }

    /// <summary>
    /// WiFi channel the device is currently using.
    /// </summary>
    public byte Channel { get; private set; }

    /// <summary>
    /// Authentication type used to connect to the network.
    /// </summary>
    public NetworkAuthenticationType AuthenticationType { get; private set; }

    /// <summary>
    /// Date and time the event was generated.
    /// </summary>
    public DateTime When { get; private set; }

    /// <summary>
    /// Construct a WirelessNetworkConnectionEventArgs request.
    /// </summary>
    /// <param name="ipAddress">IP address of the device.</param>
    /// <param name="subnet">Subnet of the device.</param>
    /// <param name="gateway">Gateway address of the device.</param>
    /// <param name="ssid">SSID of the network the device is connected to.</param>
    /// <param name="bssid">BSSID of the network the device is connected to.</param>
    /// <param name="channel">Channel the device is connected to.</param>
    /// <param name="authenticationType">Method of authentication used to connect to the network.</param>
    public WirelessNetworkConnectionEventArgs(IPAddress ipAddress, IPAddress subnet, IPAddress gateway, string ssid, PhysicalAddress bssid, byte channel, NetworkAuthenticationType authenticationType)
        : base(ipAddress, subnet, gateway)
    {
        Ssid = ssid;
        Bssid = bssid;
        Channel = channel;
        AuthenticationType = authenticationType;
        When = DateTime.Now;
    }
}
