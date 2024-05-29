using System;
using System.Text;

namespace Meadow.Peripherals.Sensors.Location.Gnss;

/// <summary>
/// Decoded data for the VTG - Course over ground and ground speed messages.
/// </summary>
public struct CourseOverGround : IGnssResult
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
    public DateTime? TimeOfReading { get; set; }

    /// <summary>
    /// True heading in degrees.
    /// </summary>
    public decimal TrueHeading { get; set; }

    /// <summary>
    /// Magnetic heading.
    /// </summary>
    public decimal MagneticHeading { get; set; }

    /// <summary>
    /// Speed measured in knots.
    /// </summary>
    public decimal Knots { get; set; }

    /// <summary>
    /// Speed measured in kilometers per hour.
    /// </summary>
    public decimal Kph { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CourseOverGround"/> struct.
    /// </summary>
    public CourseOverGround()
    {
        TalkerID = "GP";
        TimeOfReading = null;
        TrueHeading = 0m;
        MagneticHeading = 0m;
        Knots = 0m;
        Kph = 0m;
    }

    /// <summary>
    /// Returns a formatted string representing the <see cref="CourseOverGround"/> struct.
    /// </summary>
    /// <returns>A formatted string representing the <see cref="CourseOverGround"/> struct.</returns>
    public override string ToString()
    {
        StringBuilder outString = new();

        outString.Append("CourseOverGround: {\r\n");
        outString.Append($"\tTalker ID: {TalkerID}, talker name: {TalkerSystemName}\r\n");
        outString.Append($"\tTime of reading: {TimeOfReading}\r\n");
        outString.Append($"\tTrue Heading: {TrueHeading}\r\n");
        outString.Append($"\tMagnetic Heading: {MagneticHeading}\r\n");
        outString.Append($"\tKnots: {Knots:f2}\r\n");
        outString.Append($"\tKph: {Kph:f2}\r\n");
        outString.Append("}");

        return outString.ToString();
    }
}