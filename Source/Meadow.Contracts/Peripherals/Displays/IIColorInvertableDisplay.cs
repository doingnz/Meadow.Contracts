namespace Meadow.Peripherals.Displays;

/// <summary>
/// Represents a display that supports rotation in 90 degree increments
/// </summary>
public interface IColorInvertableDisplay
{
    /// <summary>
    /// Invert the display colors
    /// True to invert, false for normal colors
    /// </summary>
    public void InvertDisplayColor(bool invert);

    /// <summary>
    /// Gets whether the display color is inverted
    /// </summary>
    public bool IsColorInverted { get; }
}