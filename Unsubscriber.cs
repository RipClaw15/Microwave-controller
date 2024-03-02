using System.Collections.Generic;
using System;
using WpfApp1;

class Unsubscriber : IDisposable
{
    
    private List<IObserver<Stare>> _observers;
    private IObserver<Stare> _observer;
    public Unsubscriber(List<IObserver<Stare>> observers,
    IObserver<Stare> observer)
    {
        this._observers = observers;
        this._observer = observer;
    }
    public void Dispose()
    {
        if (!(_observer == null)) _observers.Remove(_observer);
    }
}