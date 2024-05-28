namespace Meadow.Peripherals.Sensors.Location.Gnss;

/// <summary>
/// Active satellite selection for GSA messages.
/// </summary>
public enum ActiveSatelliteSelection
{
    /// <summary>
    /// Unspecified satellite selection.
    /// </summary>
    Unknown,
    /// <summary>
    /// Automatic satellite selection.
    /// </summary>
    Automatic,
    /// <summary>
    /// Manual Satellite selection.
    /// </summary>
    Manual
}