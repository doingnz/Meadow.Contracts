using System;

namespace Meadow.Hardware;

/// <summary>
/// Represents a Controller Area Network (CAN) bus interface.
/// </summary>
public interface ICanBus
{
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
    /// Sets the CAN filter.
    /// </summary>
    /// <param name="filter">The filter value.</param>
    void SetFilter(int filter);

    /// <summary>
    /// Sets the CAN mask.
    /// </summary>
    /// <param name="filter">The mask value.</param>
    void SetMask(int filter);
}
