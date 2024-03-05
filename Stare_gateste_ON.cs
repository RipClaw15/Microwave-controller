using System;
using System.Windows;
using System.Windows.Threading;

namespace WpfApp1
    {
    public class Stare_gateste_ON : Stare
    {
        private static Stare_gateste_ON instance;
        private MainWindow mainWindow;
        private DispatcherTimer timer;
        private Context context;

        private Stare_gateste_ON() { }

        public static Stare_gateste_ON Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Stare_gateste_ON();
                }
                return instance;
            }
        }

        public int Timp_ramas { get; set; } = 30;

        public override void Tick_ceas(Context context)
        {
            if (mainWindow != null && Timp_ramas > 0)
            {
                Timp_ramas--;
                mainWindow?.Set_timer($"  {Timp_ramas}");
            }
            else
            {
                context.Stare_curenta = Stare_usa_deschisa.Instance;
                context.NotifyObservers();
                mainWindow?.Set_timer("Donee");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (mainWindow != null && Timp_ramas > 0)
            {
                Timp_ramas--;
                mainWindow?.Set_timer($"  {Timp_ramas}");
            }
            else
            {
                timer.Stop();
                context.Stare_curenta = Stare_usa_deschisa.Instance;
                context.NotifyObservers();
                mainWindow?.Set_timer("Done");
            }
        }

        public void ResetTimer()
        {
            Timp_ramas = 30;
            mainWindow?.Set_timer($"  {Timp_ramas}");
        }

        public override void Deschide_usa(Context context)
        {
            // Stop and reset the timer when leaving the cooking state
            if (timer != null && timer.IsEnabled)
            {
                timer.Stop();
                ResetTimer();
            }

            // Transition to the "Door Open" state
            context.Stare_curenta = Stare_usa_deschisa.Instance;

            // Notify observers
            context.NotifyObservers();
        }

        public override void Gateste(Context context)
        {
            this.mainWindow = ((MainWindow)Application.Current.MainWindow);
            this.context = context;

            if (timer == null || !timer.IsEnabled)
            {
                // Initialize and start the timer
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += Timer_Tick;
                timer.Start();
            }

            // Set the current state to the cooking state
            context.Stare_curenta = this;

            // Notify observers
            context.NotifyObservers();
        }
       
        public override void Inchide_usa(Context context)
        {

        }

        public void Stare_gateste_onBehavior()
        {
            Console.WriteLine("Stare gateste on");
        }
    }


}




