using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicni_trikotnik
{
    public class Gosenica
    {
        public static Random Izberi_nakljucno = new Random();
        public static List<int> Stevila = new List<int>();
        public static List<int> Pozicije_X = new List<int>();
        public static List<int> Pozicije_Y = new List<int>();
        public static int Rezultat, Operator, Moj_Rezultat, Stevec = 0;
        public static string Operator_racun;

        public static void Uredi_vse()
        {
            Operator = Izberi_nakljucno.Next(0, 2);

            if (Operator == 1)
            {
                Operator_racun = "+";
            }

            else
            {
                Operator_racun = "-";
            }

            Stevila.Clear();

            for (int indeks = 0; indeks < 101; indeks++)
            {
                Stevila.Add(indeks);
            }
        }

        public static bool Preveri_Rezultata()
        {
            if (Moj_Rezultat == Rezultat)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
