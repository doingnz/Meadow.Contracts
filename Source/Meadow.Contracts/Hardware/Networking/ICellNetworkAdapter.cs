namespace Meadow.Hardware;

/// <summary>
/// Provides an abstraction for a cellular INetworkAdapter
/// </summary>
public interface ICellNetworkAdapter : INetworkAdapter
{
    string Imei { get; }
    string Csq { get; }
    string PppdOutput { get; }
}
