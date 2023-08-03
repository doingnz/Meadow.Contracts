namespace Meadow.Networking;

/// <summary>
/// The status of a cell network
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
