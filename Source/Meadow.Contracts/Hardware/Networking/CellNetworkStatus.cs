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
    CellResume = 0,
    /// <summary>
    /// Pause Cell 
    /// </summary>
    CellPause = 1,
    /// <summary>
    /// Execute AT command for GPS location
    /// </summary>
    CellGPS = 2,
    /// <summary>
    /// Execute AT command for Signal Quality
    /// </summary>
    CellSignalQuality = 3,
    /// <summary>
    /// Execute AT command for Scanner Network
    /// </summary>
    CellScan = 4,
};