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
        public static int[] Stevila = new int[6];
        public static int[] Moja_Stevila = new int[6];
        public static int Stopnja, Stevec = 0;

        public static void Uredi_vse()
        { 
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
