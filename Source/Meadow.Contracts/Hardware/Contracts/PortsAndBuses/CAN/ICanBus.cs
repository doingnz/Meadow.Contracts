using System;

namespace Meadow.Hardware;

/// <summary>
/// Represents a Controller Area Network (CAN) bus interface.
/// </summary>
public interface ICanBus
{
    /// <summary>
    /// Gets or sets the bus bit rate
    /// </summary>
    CanBitrate BitRate { get; set; }

    /// <summary>
    /// Occurs when a CAN frame is received.
    /// </summary>
    event EventHandler<ICanFrame>? FrameReceived;

    /// <summary>
    /// Writes a CAN frame to the specified buffer.
    /// </summary>
    /// <param name="frame">The CAN frame to write.</param>
    void WriteFrame(ICanFrame frame);

    /// <summary>
    /// Checks if a CAN frame is available to read.
    /// </summary>
    /// <returns><c>true</c> if a frame is available; otherwise, <c>false</c>.</returns>
    bool IsFrameAvailable();

    /// <summary>
    /// Reads a CAN frame.
    /// </summary>
    /// <returns>The CAN frame if available; otherwise, <c>null</c>.</returns>
    ICanFrame? ReadFrame();

    /// <summary>
    /// Clears any data currently in the bus receive buffers
    /// </summary>
    void ClearReceiveBuffers();

    /// <summary>
    /// The collection of message acceptance filters for the bus
    /// </summary>
    CanAcceptanceFilterCollection AcceptanceFilters { get; }
}
