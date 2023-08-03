using System;
using System.Collections.Generic;

namespace Meadow.Hardware;

/// <summary>
/// A base class for IDigitalInterruptPort implementations
/// </summary>
public abstract class DigitalInterruptPortBase : DigitalInputPortBase, IDigitalInterruptPort
{
    private readonly List<Unsubscriber> _unsubscribers = new();

    /// <summary>
    /// Occurs when the state is changed. To enable this, set the InterruptMode at construction
    /// </summary>
    public event EventHandler<DigitalPortResult> Changed = delegate { };

    /// <summary>
    /// Gets or sets a value indicating the type of interrupt monitoring this input.
    /// </summary>
    /// <value><c>true</c> if interrupt enabled; otherwise, <c>false</c>.</value>
    public InterruptMode InterruptMode { get; protected set; }

    /// <summary>
    /// Gets or sets the debounce duration for the port
    /// </summary>
    public abstract TimeSpan DebounceDuration { get; set; }
    /// <summary>
    /// Gets or sets the glitch filter duration for the port
    /// </summary>
    public abstract TimeSpan GlitchDuration { get; set; }

    /// <summary>
    /// Constructor for the DigitalInputPortBase
    /// </summary>
    /// <param name="pin"></param>
    /// <param name="channel"></param>
    /// <param name="interruptMode"></param>
    protected DigitalInterruptPortBase(
        IPin pin,
        IDigitalChannelInfo channel,
        InterruptMode interruptMode = InterruptMode.None
        )
        : base(pin, channel)
    {
        // TODO: check interrupt mode (i.e. if != none, make sure channel info agrees)
        InterruptMode = interruptMode;
    }

    /// <summary>
    /// Gets a list of port State observers
    /// </summary>
    protected List<IObserver<IChangeResult<DigitalState>>> Observers { get; private set; } = new List<IObserver<IChangeResult<DigitalState>>>();

    /// <summary>
    /// Raises the Changed event and notifies all observers of a state change
    /// </summary>
    /// <param name="changeResult"></param>
    protected void RaiseChangedAndNotify(DigitalPortResult changeResult)
    {
        Changed?.Invoke(this, changeResult);
        Observers.ForEach(x => x.OnNext(changeResult));
    }

    /// <summary>
    /// Adds a state observer to the port
    /// </summary>
    /// <param name="observer"></param>
    /// <returns></returns>
    public IDisposable Subscribe(IObserver<IChangeResult<DigitalState>> observer)
    {
        if (!Observers.Contains(observer)) Observers.Add(observer);
        var u = new Unsubscriber(Observers, observer);
        _unsubscribers.Add(u);
        return u;
    }

    /// <summary>
    /// Releases allocated port resources 
    /// </summary>
    /// <param name="disposing"></param>
    protected override void Dispose(bool disposing)
    {
        foreach (var u in _unsubscribers)
        {
            u.Dispose();
        }

        base.Dispose(disposing);
    }

    private class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<IChangeResult<DigitalState>>> _observers;
        private readonly IObserver<IChangeResult<DigitalState>> _observer;

        public Unsubscriber(List<IObserver<IChangeResult<DigitalState>>> observers, IObserver<IChangeResult<DigitalState>> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (!(_observer == null)) _observers.Remove(_observer);
        }
    }
}
