using System;
using System.Text;

namespace Meadow.Peripherals.Sensors.Location.Gnss;

/// <summary>
/// Active satellite information (GSA message information).
/// </summary>
public struct ActiveSatellites : IGnssResult
{
    /// <summary>
    /// The first two letters (after the starting delimiter) comprise the
    /// Talker ID, which describes the system in use, for instance "GL" means
    /// that the data came from the GLONASS system. "BD" means BeiDou, etc.
    ///
    /// Default value is "GP".
    /// </summary>
    public string TalkerID { get; set; }

    /// <summary>
    /// Retrieves the full name associated with the TalkerID via the
    /// `KnownTalkerIDs` property of the Lookups class.
    /// </summary>
    public string TalkerSystemName
    {
        get
        {
            string name = Lookups.KnownTalkerIDs[TalkerID];
            return name ?? "";
        }
    }

    /// <summary>
    /// Time the reading was generated.
    /// </summary>
    public DateTime TimeOfReading { get; set; }

    /// <summary>
    /// Dimensional fix type (No fix, 2D or 3D?)
    /// </summary>
    public DimensionalFixType Dimensions { get; set; }

    /// <summary>
    /// Satellite selection type (Automatic or manual).
    /// </summary>
    public ActiveSatelliteSelection SatelliteSelection { get; set; }

    /// <summary>
    /// PRNs of the satellites used in the fix.
    /// </summary>
    public string[]? SatellitesUsedForFix { get; set; }

    /// <summary>
    /// Dilution of precision for the reading.
    /// </summary>
    public decimal DilutionOfPrecision { get; set; }

    /// <summary>
    /// Horizontal dilution of precision for the reading.
    /// </summary>
    public decimal HorizontalDilutionOfPrecision { get; set; }

    /// <summary>
    /// Vertical dilution of precision for the reading.
    /// </summary>
    public decimal VerticalDilutionOfPrecision { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ActiveSatellites"/> struct.
    /// </summary>
    public ActiveSatellites()
    {
        TalkerID = "GP";
        TimeOfReading = default;
        Dimensions = DimensionalFixType.None;
        SatelliteSelection = ActiveSatelliteSelection.Automatic;
        SatellitesUsedForFix = null;
        DilutionOfPrecision = 0m;
        HorizontalDilutionOfPrecision = 0m;
        VerticalDilutionOfPrecision = 0m;
    }

    /// <summary>
    /// Returns a formatted string representing the <see cref="ActiveSatellites"/> struct.
    /// </summary>
    /// <returns>A formatted string representing the <see cref="ActiveSatellites"/> struct.</returns>
    public override string ToString()
    {
        StringBuilder outString = new();

        outString.Append("Active Satellites: {\r\n");
        outString.Append($"\tTalker ID: {TalkerID}, talker name: {TalkerSystemName}\r\n");
        outString.Append($"\tTime of reading: {TimeOfReading}\r\n");
        outString.Append($"\tNumber of satellites involved in fix: {SatellitesUsedForFix?.Length}\r\n");
        outString.Append($"\tDilution of precision: {DilutionOfPrecision:f2}\r\n");
        outString.Append($"\tHDOP: {HorizontalDilutionOfPrecision:f2}\r\n");
        outString.Append($"\tVDOP: {VerticalDilutionOfPrecision:f2}\r\n");
        if (SatellitesUsedForFix != null)
        {
            outString.Append($"\tSatellites used for fix:\r\n");
            foreach (var sat in SatellitesUsedForFix)
            {
                outString.Append($"\t{sat}\r\n");
            }
        }
        outString.Append("}");

        return outString.ToString();
    }
}
