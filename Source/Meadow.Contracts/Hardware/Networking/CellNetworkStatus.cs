namespace Meadow.Networking;

/// <summary>
/// The operator status of a cell network
/// </summary>
public enum CellNetworkStatus
{
    /// <summary>
    /// Unknown status
    /// </summary>
    Unknown = 0,
    /// <summary>
    /// Operator is available
    /// </summary>
    OperatorAvailable = 1,
    /// <summary>
    /// Current operator
    /// </summary>
    CurrentOperator = 2,
    /// <summary>
    /// Operator is forbidden
    /// </summary>
    OperatorForbidden = 3,
    /// <summary>
    /// Operator status is undefined
    /// </summary>
    OperatorUndefined = 0xff
};

/// <summary>
/// State of the cell
/// </summary>
public enum CellNetworkState
{
    /// <summary>
    /// Resume Cell
    /// </summary>
    Resumed = 0,
    /// <summary>
    /// Paused Cell 
    /// </summary>
    Paused = 1,
    /// <summary>
    /// Tracking GPS location
    /// </summary>
    TrackingGPSLocation = 2,
    /// <summary>
    /// Fetching signal quality
    /// </summary>
    FetchingSignalQuality = 3,
    /// <summary>
    /// Execute network scan
    /// </summary>
    ScanningNetworks = 4,
};