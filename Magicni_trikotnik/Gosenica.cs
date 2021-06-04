using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Magicni_trikotnik
{
    public class Gosenica
    {
        public static Random Izberi_nakljucno = new Random();
        public static List<string> Sadje_imena = new List<string>();
        private static List<string> Sadje = new List<string>()
        {
            "hruška", "jagoda", "pomaranča", "grozdje", "limona", "češnja", "jabolko"
        };
        public static int Stevilo, Poskusi = 3;
        public static string Izbrano_sadje, Moje_sadje;

        public static void Izmisli()
        {
            Sadje_imena.Clear();
            Stevilo = Izberi_nakljucno.Next(Sadje.Count);
            Izbrano_sadje = Sadje[Stevilo];
        }

        public static bool Preveri_Rezultata()
        {
            if (Moje_sadje == Izbrano_sadje)
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
