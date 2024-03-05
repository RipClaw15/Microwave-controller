using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class Microunde : MainWindow
    {
        enum Stare
        {
            STARE_USA_DESCHISA,
            STARE_USA_INCHISA,
            STARE_GATESTE
        }

        Stare stare;

        public void deschide_usa()
        {

            if (stare == Stare.STARE_USA_INCHISA) { lab_usa.Content = "Door opened!"; }

        }

        public void inchide_usa()
        {
            if (stare == Stare.STARE_USA_DESCHISA) { lab_usa.Content = "Door closed!"; }
        }


    }
}
