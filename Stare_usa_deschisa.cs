using System;


namespace WpfApp1
{
    public class Stare_usa_deschisa : Stare
    {       
        private static Stare_usa_deschisa? instance;       
        private Stare_usa_deschisa() { }   
        public static Stare_usa_deschisa Instance
        {
            get
            {               
                if (instance == null)
                {
                    instance = new Stare_usa_deschisa();
                }
                return instance;
            }
        }
        public override void Deschide_usa(Context context)
        {
           
        }
        public override void Gateste(Context context)
        {
            
        }

        public override void Inchide_usa(Context context)
        {
            //schimb stare
            context.Stare_curenta = Stare_usa_inchisa.Instance;
            //notifica observatorii  
            context.NotifyObservers();
        }

        public override void Tick_ceas(Context context)
        {
            throw new NotImplementedException();
        }

        public void Stare_usa_deschisaBehavior()
        {
            Console.WriteLine("Stare deschide usa");
        }
    }

}
