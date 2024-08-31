using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Strategico
{
    internal class Barbari
    {
        public static void Barbari_PVE()
        {
            int a = 0, b = 0, c = 0, d = 0;
            while (true)
            {
                if (a == 3)
                {
                    Variabili.Barbari.PVE.Guerrieri++;
                    a = 0;
                }
                if (b == 4)
                {
                    Variabili.Barbari.PVE.Lancieri++;
                    b = 0;
                }
                if (c == 5)
                {
                    Variabili.Barbari.PVE.Arceri++;
                    c = 0;
                }
                if (d == 6)
                {
                    Variabili.Barbari.PVE.Catapulte++;
                    d = 0;
                }
                a++;
                b++;
                c++;
                d++;
                Thread.Sleep(1000);
            }
        }
    }
}
