using Meadow.Networking;
using System.Collections.Generic;
namespace Meadow.Hardware;

/// <summary>
/// Provides an abstraction for a cellular INetworkAdapter
/// </summary>
public interface ICellNetworkAdapter : INetworkAdapter
{
    /// <summary>
    /// Gets the adapter's IMEI
    /// </summary>
    string Imei { get; }
    /// <summary>
    /// Gets the adapter's CSQ
    /// </summary>
    string Csq { get; }
    /// <summary>
    /// Gets the adapter's AT comman output
    /// </summary>
    string AtCmdsOutput { get; }

    /// <summary>
    /// Scans for networks the Adapter detects
    /// </summary>
    /// <returns>A list of CellNetworks</returns>
    List<CellNetwork> Scan();
}
