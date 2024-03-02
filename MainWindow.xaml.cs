using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;

namespace WpfApp1
{
    
    public partial class MainWindow : Window, IAfisaj_microunde, IObserver<Stare>, IComponentConnector
    { 
        private IDisposable un_subscriber;
        private Context c;
        private bool isRunning;

        public MainWindow()
        {
            InitializeComponent();
            c = new Context(Stare_usa_inchisa.Instance);
            Subscribe(c);

            Ticks();
        }
        
        public virtual void Subscribe(IObservable<Stare> context)
        {
            un_subscriber = context.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            un_subscriber.Dispose();
        }


        async void Ticks()
        {
            while (true)
            {
                await Task.Delay(1000);

                
                if (isRunning)
                {
                    
                    c.Tick_ceas();
                }
            }
        }


        private void but_deschide_Click(object sender, RoutedEventArgs e)
        {
            c.Deschide_usa();
            
        }

        private void but_inchide_Click(object sender, RoutedEventArgs e)
        {
            c.Inchide_usa();
           
        }

        private void but_pornire_Click(object sender, RoutedEventArgs e)
        {
            c.Gateste();
            
        }


        public void OnCompleted()
        {
            //throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            //throw new NotImplementedException();
        }

        public void OnNext(Stare value)
        {
            switch (value)
            {
                case Stare_usa_deschisa deschisaInstance:
                    Set_usa_deschisa();
                    Set_gateste_OFF();
                    break;
                case Stare_usa_inchisa inchisaInstance:
                    Set_usa_inchisa();
                    break;
                case Stare_gateste_ON gatesteONInstance:
                    Set_gateste_ON();
                    
                    break;
                    
            }
        }



        public void Set_gateste_OFF()
        {
            lab_gateste.Content = "Gateste OFF";
        }

        public void Set_gateste_ON()
        {
            lab_gateste.Content = "Gateste ON";
        }

        public void Set_timp_ramas()
        {
            lab_timer.Content = "Timp ramas:";
        }

        public void Set_usa_deschisa()
        {
            lab_usa.Content = "Usa Deschisa";
        }

        public void Set_usa_inchisa()
        {
            lab_usa.Content = "Usa Inchisa";
        }

        public void Set_timer(string content)
        {
            
            Dispatcher.Invoke(() =>
            {
                lab_timer.Content = content;
            });
        }

    }
}
