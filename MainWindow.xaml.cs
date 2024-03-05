using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
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

            
        }
        
        public virtual void Subscribe(IObservable<Stare> context)
        {
            un_subscriber = context.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            un_subscriber.Dispose();
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
            window.Fill = Brushes.Orange;
        }

        public void Set_timp_ramas()
        {
            lab_timer.Content = "Timp ramas:";
        }

        public void Set_usa_deschisa()
        {
            lab_usa.Content = "Door opened";
            foreach (var shape in doorGroup.Children)
            {
                if (shape is Shape)
                {
                    ((Shape)shape).Fill = Brushes.White; // Change Fill color to Orange
                    ((Shape)shape).Stroke = Brushes.Black; // Change Stroke color to Red
                                                         // Adjust other properties as needed
                }
            }
            open_door_front.Fill = Brushes.LightGray;
            window_front.Fill = Brushes.Gray;
            handle_front.Fill = Brushes.Black;
            handle_front1.Fill = Brushes.Black;
            handle_front2.Fill = Brushes.Black;
            handle.Fill = Brushes.Transparent;
            handle.Stroke = Brushes.Transparent;
            window.Fill = Brushes.Transparent;
            window.Stroke = Brushes.Transparent;
            inside.Fill = Brushes.LightGray;
            inside_small.Fill = Brushes.Gray;
            inside_small.Stroke = Brushes.Black;
            inside_plate.Fill = Brushes.Gray;
            inside_plate.Stroke = Brushes.Black;
            line_4.Stroke = Brushes.Black;
            line_2.Stroke = Brushes.Black;
            line_1.Stroke = Brushes.Black;
        }

        public void Set_usa_inchisa()
        {
            lab_usa.Content = "Door closed";
            window.Fill = Brushes.Gray;
            foreach (var shape in doorGroup.Children)
            {
                if (shape is Shape)
                {
                    ((Shape)shape).Fill = Brushes.Transparent; 
                    ((Shape)shape).Stroke = Brushes.Transparent; 
                                                                 
                }
            }
            window.Fill = Brushes.Gray;
            window.Stroke = Brushes.Black;
            handle.Fill = Brushes.Black;
            handle.Stroke = Brushes.Black;
            inside.Fill = Brushes.White;
            inside_plate.Fill = Brushes.Transparent;
            inside_plate.Stroke = Brushes.Transparent;
            inside_small.Fill = Brushes.Transparent;
            inside_small.Stroke = Brushes.Transparent;
            line_4.Stroke = Brushes.Transparent;
            line_2.Stroke = Brushes.Transparent;
            line_1.Stroke = Brushes.Transparent;
        }

        public void Set_timer(string content)
        {
            
            Dispatcher.Invoke(() =>
            {
                lab_timer.Content = content;
            });
            set_timer.Content = "Set_timer";
        }

    }
}
