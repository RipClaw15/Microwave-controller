using System;
using System.Collections.Generic;


namespace WpfApp1
{
    public class Context : IObservable<Stare>
    {      
        List<IObserver<Stare>> observers = new List<IObserver<Stare>>();
        private static Context _instance;
        private Stare stare;
        private Context() { }
        public static Context Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Context();

                return _instance;
            }
        }
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.OnNext(Stare_curenta);
            }
        }

        public Context(Stare stare)
        {
            this.stare = stare;
        }

        public Stare Stare
        {
            get => stare;
            set => stare = value;
        }
        public Stare Stare_curenta
        {
            get => stare;
            set => stare = value;
        }
        public string Timp_ramas { get; set; }

        public void Deschide_usa()
        {
            stare.Deschide_usa(this);
        }
        public void Inchide_usa()
        {
            stare.Inchide_usa(this);
        }
        public void Gateste()
        {       
            stare.Gateste(this);     
        }
        public void Tick_ceas()
        {
            if (stare is Stare_gateste_ON gatesteOnState)
            {
                gatesteOnState.Tick_ceas(this);
            }
        }
        public IDisposable Subscribe(IObserver<Stare> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }
    
    }
}
