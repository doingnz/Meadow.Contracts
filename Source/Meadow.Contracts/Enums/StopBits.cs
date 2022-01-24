namespace Meadow.Hardware
{
    /// <summary>
    /// Specifies the number of stop bits used on the SerialPort object.
    /// </summary>
    public enum StopBits
    {
        /// <summary>
        /// No stop bits are used.
        /// </summary>
        None,
        /// <summary>
        /// One stop bit is used.
        /// </summary>
        One,
        /// <summary>
        /// Two stop bits are used.
        /// </summary>
        Two,
        /// <summary>
        /// One and one half stop bits are used.
        /// </summary>
        OnePointFive
    }

}
