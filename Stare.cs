

namespace WpfApp1
{
    public abstract class Stare
    {

        protected Context ContextInstance { get; set; }
        protected MainWindow MainWindowInstance { get; set; }

        public abstract void Deschide_usa(Context context);

        public abstract void Inchide_usa(Context context);

        public abstract void Gateste(Context context);

        public abstract void Tick_ceas(Context context);

    }
        
}
