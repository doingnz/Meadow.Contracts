namespace Meadow.Hardware;

/// <summary>
/// A contract for Meadow devices that support network interfaces
/// </summary>
public interface INetworkAdapterController
{
    /// <summary>
    /// The event raised when a network adapter has connected to a network
    /// </summary>
    event NetworkConnectionHandler NetworkConnected;
    /// <summary>
    /// The event raised when a network adapter has disconnected from a network
    /// </summary>
    event NetworkDisconnectionHandler NetworkDisconnected;

    /// <summary>
    /// A collection of network adapters
    /// </summary>
    INetworkAdapterCollection NetworkAdapters { get; }
}
