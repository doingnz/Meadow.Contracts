using Meadow.Hardware;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Meadow;

/// <summary>
/// Provides a base implementation for device pin lists.
/// </summary>
public abstract class PinDefinitionBase : IPinDefinitions
{
    private List<IPin>? _pins;

    /// <inheritdoc/>
    public virtual IList<IPin> AllPins
    {
        // lazy load
        get => _pins ??= DiscoverAllPinsViaReflection();
    }

    /// <inheritdoc/>
    public IPinController? Controller { get; set; }

    /// <summary>
    /// Retrieves a pin from <see cref="AllPins"/> by Name or Key
    /// </summary>
    public IPin this[string name]
    {
        get => AllPins.FirstOrDefault(p =>
            string.Compare(p.Name, name, true) == 0
            || string.Compare($"{p.Key}", name, true) == 0)
            ?? throw new KeyNotFoundException();
    }

    /// <summary>
    /// Creates a PinDefinitionBase
    /// </summary>
    protected PinDefinitionBase()
    {
    }

    /// <summary>
    /// Uses reflection to discover all IPin properties
    /// </summary>
    private List<IPin> DiscoverAllPinsViaReflection()
    {
        var list = new List<IPin>();

        foreach (var prop in this.GetType()
            .GetProperties(
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.Public)
            .Where(p => p.CanRead && p.GetIndexParameters().Length == 0 && p.PropertyType == typeof(IPin))
            )
        {
            var pin = prop.GetValue(this) as IPin;

            if (pin != null)
            {
                if (!list.Any(p => p.Name == pin.Name))
                {
                    list.Add(pin);
                }
            }
        }
        return list;
    }

    /// <inheritdoc/>
    public IEnumerator<IPin> GetEnumerator() => AllPins.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}