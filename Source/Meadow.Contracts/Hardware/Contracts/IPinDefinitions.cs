using System.Collections.Generic;
using System.Linq;

namespace Meadow.Hardware
{
    /// <summary>
    /// Contract for device pin lists.
    /// </summary>
    public interface IPinDefinitions : IEnumerable<IPin>
    {
        /// <summary>
        /// Convenience property which contains all the pins available on the 
        /// device.
        /// </summary>
        /// <value>All the pins.</value>
        IList<IPin> AllPins { get; }

        IPin this[string name]
        {
            get => AllPins.FirstOrDefault(p =>
                string.Compare(p.Name, name, true) == 0
                || string.Compare($"{p.Key}", name, true) == 0);
        }

        /// <summary>
        /// Gets or sets the IPinController associated with the IPins
        /// </summary>
        IPinController Controller { get; set; }
    }
}
