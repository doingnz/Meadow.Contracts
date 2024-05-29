namespace Meadow.Peripherals.Sensors.Location.Gnss;

/// <summary>
/// Represents the fix type or quality of a Global Navigation Satellite System (GNSS) location fix.
/// </summary>
public enum FixType
{
    /// <summary>
    /// An invalid or unknown fix type.
    /// </summary>
    Invalid = 0,

    /// <summary>
    /// Standard Positioning Service (SPS) fix. This is a standard GPS fix.
    /// </summary>
    SPS = 1,

    /// <summary>
    /// Differential GPS (DGPS) fix, using corrections from a base station for increased accuracy.
    /// </summary>
    DGPS = 2,

    /// <summary>
    /// Pulse Per Second (PPS) fix, using high-precision time synchronization.
    /// </summary>
    PPS = 3,

    /// <summary>
    /// Real-Time Kinematic (RTK) fix, providing centimeter-level precision.
    /// </summary>
    RealTimeKinematic = 4,

    /// <summary>
    /// Floating Real-Time Kinematic (RTK) fix, providing decimeter-level precision.
    /// </summary>
    FloatRTK = 5,

    /// <summary>
    /// Dead reckoning fix, estimated based on previous location data.
    /// </summary>
    DeadReckoning = 6,

    /// <summary>
    /// Manual input fix, entered manually by the user.
    /// </summary>
    ManualInput = 7,

    /// <summary>
    /// Simulation fix, generated for testing or simulation purposes.
    /// </summary>
    Simulation = 8
}