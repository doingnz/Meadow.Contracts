using System.Text;

namespace Meadow.Peripherals.Sensors.Location.Gnss;

/// <summary>
/// Represents information about the satellites in view in a GNSS receiver.
/// </summary>
public struct SatellitesInView : IGnssResult
{
    /// <summary>
    /// Gets or sets the Talker ID associated with the data, which describes the system in use.
    /// The default value is "GP".
    /// </summary>
    public string TalkerID { get; set; }

    /// <summary>
    /// Gets the full name associated with the TalkerID via the `KnownTalkerIDs` property of the Lookups class.
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
    /// Gets the array of Satellite objects representing the satellites in view.
    /// </summary>
    public Satellite[] Satellites { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SatellitesInView"/> struct.
    /// </summary>
    /// <param name="satellites">The array of Satellite objects representing the satellites in view.</param>
    public SatellitesInView(Satellite[] satellites)
    {
        TalkerID = "GP";
        Satellites = satellites;
    }

    /// <summary>
    /// Returns a string representation of the SatellitesInView object.
    /// </summary>
    /// <returns>A multiline string representation of the SatellitesInView object.</returns>
    public override string ToString()
    {
        StringBuilder outString = new();

        outString.Append("SatellitesInView: {\r\n");
        outString.Append($"\tTalker ID: {TalkerID}, talker name: {TalkerSystemName}\r\n");
        outString.Append($"\tSatellites:\r\n");
        foreach (var sat in Satellites)
        {
            outString.Append($"\t{sat}\r\n");
        }
        outString.Append("}");

        return outString.ToString();
    }
}
