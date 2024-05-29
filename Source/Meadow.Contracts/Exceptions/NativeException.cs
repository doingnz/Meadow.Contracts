using System;

namespace Meadow;

/// <summary>
/// Encapsulates a native hardware exception 
/// </summary>
public class NativeException : Exception
{
    /// <summary>
    /// Optional Error Code information from the underlying OS
    /// </summary>
    public int? ErrorCode { get; }

    /// <summary>
    /// Creates a NativeException object
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public NativeException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Creates a NativeException object
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="errorCode">The error code associated with the exception.</param>
    public NativeException(string message, int errorCode)
        : base(message)
    {
        this.ErrorCode = errorCode;
    }
}
