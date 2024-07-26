using System;

namespace Meadow.Hardware;

/// <summary>
/// Specifies the bitrate for CAN communication.
/// </summary>
public enum CanBitrate
{
    /// <summary>
    /// 5 kbps CAN bitrate.
    /// </summary>
    Can_5kbps,

    /// <summary>
    /// 10 kbps CAN bitrate.
    /// </summary>
    Can_10kbps,

    /// <summary>
    /// 20 kbps CAN bitrate.
    /// </summary>
    Can_20kbps,

    /// <summary>
    /// 33 kbps CAN bitrate.
    /// </summary>
    Can_33kbps,

    /// <summary>
    /// 40 kbps CAN bitrate.
    /// </summary>
    Can_40kbps,

    /// <summary>
    /// 47 kbps CAN bitrate.
    /// </summary>
    Can_47kbps,

    /// <summary>
    /// 50 kbps CAN bitrate.
    /// </summary>
    Can_50kbps,

    /// <summary>
    /// 80 kbps CAN bitrate.
    /// </summary>
    Can_80kbps,

    /// <summary>
    /// 83 kbps CAN bitrate.
    /// </summary>
    Can_83kbps,

    /// <summary>
    /// 95 kbps CAN bitrate.
    /// </summary>
    Can_95kbps,

    /// <summary>
    /// 100 kbps CAN bitrate.
    /// </summary>
    Can_100kbps,

    /// <summary>
    /// 125 kbps CAN bitrate.
    /// </summary>
    Can_125kbps,

    /// <summary>
    /// 200 kbps CAN bitrate.
    /// </summary>
    Can_200kbps,

    /// <summary>
    /// 250 kbps CAN bitrate.
    /// </summary>
    Can_250kbps,

    /// <summary>
    /// 500 kbps CAN bitrate.
    /// </summary>
    Can_500kbps,

    /// <summary>
    /// 800 kbps CAN bitrate.
    /// </summary>
    Can_800kbps,

    /// <summary>
    /// 1 Mbps CAN bitrate.
    /// </summary>
    Can_1Mbps,

    /// <summary>
    /// Flexible Data Rate
    /// </summary>
    Can_FD,
}

/// <summary>
/// Represents an overload frame for CAN communication.
/// </summary>
public class OverloadFrame : Frame
{
}

/// <summary>
/// Represents an active error frame for CAN communication.
/// </summary>
public class ActiveErrorFrame : Frame
{
}

/// <summary>
/// Represents a standard remote transfer request frame (RTR) for CAN communication.
/// </summary>
public class StandardRtrFrame : RemoteTransferRequestFrame
{
}

/// <summary>
/// Represents an extended remote transfer request (RTR) frame for CAN communication.
/// </summary>
public class ExtendedRtrFrame : RemoteTransferRequestFrame
{
}


/// <summary>
/// Represents an extended data frame for CAN communication.
/// </summary>
public class ExtendedDataFrame : DataFrame
{
}

/// <summary>
/// Represents a remote transfer request frame for CAN communication.
/// </summary>
public class RemoteTransferRequestFrame : DataFrame
{
}

/// <summary>
/// Represents a standard data frame for CAN communication.
/// </summary>
public class StandardDataFrame : DataFrame
{
}

/// <summary>
/// Represents an abstract data frame for CAN communication, inheriting from Frame.
/// </summary>
public abstract class DataFrame : Frame
{
    /// <summary>
    /// Gets or sets the identifier for the data frame.
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Gets or sets the payload of the data frame.
    /// </summary>
    public byte[] Payload { get; set; } = new byte[0];
}

/// <summary>
/// Represents an abstract base class for CAN (Controller Area Network) frames.
/// </summary>
public abstract class Frame : ICanFrame
{
}

/// <summary>
/// Represents a CAN (Controller Area Network) frame.
/// </summary>
public interface ICanFrame
{
}

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
