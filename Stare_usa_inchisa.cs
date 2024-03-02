using System;


namespace WpfApp1
{
    public class Stare_usa_inchisa : Stare
    {        
        private static Stare_usa_inchisa? instance;      
        private Stare_usa_inchisa(){ }       
        public static Stare_usa_inchisa Instance
        {
            get
            {       
                if (instance == null)
                {
                    instance = new Stare_usa_inchisa();
                }
                return instance;
            }
        }
        public override void Deschide_usa(Context context)
        {   //schimb stare
            context.Stare_curenta = Stare_usa_deschisa.Instance;            
            context.NotifyObservers();
        }

        public override void Gateste(Context context)
        {   
            //schimb stare
            context.Stare_curenta = Stare_gateste_ON.Instance;
            //schimb afisare
            //notifica observatorii  
            context.NotifyObservers();
        }
        public override void Inchide_usa(Context context)
        {
            
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
