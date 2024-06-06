﻿using Meadow.Hardware;
using System;
using System.Collections.Generic;

namespace Meadow;

/// <summary>
/// Represents a handler function to process captured Meadow system errors
/// </summary>
/// <param name="error">Information about the captured error</param>
/// <param name="recommendReset">Indicates if the OS or core believes the device should be reset due to this error</param>
/// <param name="forceReset">Setting this to true will cause the device to reset after returning from the handler</param>
public delegate void MeadowSystemErrorHandler(MeadowSystemErrorInfo error, bool recommendReset, out bool forceReset);

/// <summary>
/// An interface that encapsulates all of the data related to platform reliability
/// </summary>
public interface IReliabilityService
{
    /// <summary>
    /// This event is raised in the event that an exception or error occurs outside of the managed stack, such as with a coprocessor
    /// </summary>
    public event MeadowSystemErrorHandler MeadowSystemError;

    /// <summary>
    /// Returns true is the last device boot followed a crash
    /// </summary>
    public bool LastBootWasFromCrash { get; }
    /// <summary>
    /// Returns if there is crash data available
    /// </summary>
    public bool IsCrashDataAvailable { get; }
    /// <summary>
    /// Gets the last system reset reason
    /// </summary>
    public ResetReason LastResetReason { get; }
    /// <summary>
    /// Gets the total number of times the system has been reset
    /// </summary>
    public int SystemResetCount { get; }
    /// <summary>
    /// Gets the total number of times the system has been power cycled
    /// </summary>
    public int SystemPowerCycleCount { get; }
    /// <summary>
    /// Gets the total time the device has been up since last reset or power cycle
    /// </summary>
    public TimeSpan UpTime { get; }

    /// <summary>
    /// Retrieves any messages generated by the Meadow host OS prior to starting the Meadow stack
    /// </summary>
    /// <returns></returns>
    public IEnumerable<PlatformOsMessage>? GetStartupMessages();
    /// <summary>
    /// Gets all existing crash report data
    /// </summary>
    /// <returns>A list (typically with a length of 0 or 1) of on-device crash reports</returns>
    public string[] GetCrashData();
    /// <summary>
    /// Erases all existing crash report data
    /// </summary>
    public void ClearCrashData();

    /// <summary>
    /// Override this method to provide specific behaviors when System Errors occur
    /// </summary>
    /// <param name="errorInfo">The MeadowSystemErrorInfo describing the error details</param>
    public void OnMeadowSystemError(MeadowSystemErrorInfo errorInfo);

    /// <summary>
    /// Override this method to provide specific behaviors the device boots after a crash
    /// </summary>
    /// <remarks>Additional crash information is available by calling GetCrashData()</remarks>
    public void OnBootFromCrash();
}

