using System;
using System.Collections.Generic;

namespace Meadow.Hardware
{
    /// <summary>
    /// Contract for a pin
    /// </summary>
    public interface IPin : IEquatable<IPin>
    {
        /// <summary>
        /// The IPinController associated with this IPin
        /// </summary>
        public IPinController Controller { get; }

        /// <summary>
        /// Supported channels
        /// </summary>
        IList<IChannelInfo>? SupportedChannels { get; }

        /// <summary>
        /// The name of the pin
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The key object for the pin
        /// </summary>
        object Key { get; }

        /// <summary>
        /// To string 
        /// </summary>
        /// <returns>The pin name</returns>
        public string ToString() => Name;
    }
}