namespace Meadow;

/// <summary>
/// Provides an abstraction for peripherals that have a battery and that can read information about that battery
/// </summary>
public interface IBatteryBackedPeripheral
{
    /// <summary>
    /// Reads the state of the battery
    /// </summary>
    /// <returns><b>True</b> if the battery voltage is low, otherwise <b>False</b></returns>
    bool IsBatteryLow();
}
