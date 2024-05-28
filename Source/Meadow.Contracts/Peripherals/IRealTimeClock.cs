using System;

namespace Meadow.Hardware;

/// <summary>
/// Abstraction for Real-time clock devices
/// </summary>
public interface IRealTimeClock
{
    /// <summary>
    /// Stops or starts the clock oscillator
    /// </summary>
    public bool IsRunning { get; set; }

    /// <summary>
    /// Reads the RTC time
    /// </summary>
    /// <returns></returns>
    public DateTimeOffset GetTime();
    /// <summary>
    /// Sets the RTC time
    /// </summary>
    /// <param name="time"></param>
    public void SetTime(DateTimeOffset time);
}
