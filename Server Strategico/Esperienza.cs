using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Strategico
{
    internal class Esperienza
    {
        public static int exp_Level_Up = 100;
        public static int level_Up = 0;
        public static double moltiplicatore = 0.62;

        public static void LevelUp(Variabili.Player player)
        {
            switch (player.Livello)
            {
                case 0:
                    if (player.Esperienza >= exp_Level_Up + (exp_Level_Up * player.Livello * 0.35))
                    {
                        player.Esperienza -= exp_Level_Up;
                        player.Livello++;
                    }
                    break;
                case 1:
                    if (player.Esperienza >= exp_Level_Up + (exp_Level_Up * player.Livello * 0.45))
                    {
                        player.Esperienza -= exp_Level_Up;
                        player.Livello++;
                    }
                    break;
                case 2:
                    if (player.Esperienza >= exp_Level_Up + (exp_Level_Up * player.Livello * 0.45))
                    {
                        player.Esperienza -= exp_Level_Up;
                        player.Livello++;
                    }
                    break;
                default:
                    if (player.Esperienza >= exp_Level_Up + (exp_Level_Up * player.Livello * moltiplicatore))
                    {
                        player.Esperienza -= exp_Level_Up;
                        player.Livello++;
                        if (player.Livello >= 10)
                            moltiplicatore += 0.09;
                        if (player.Livello >= 20)
                            moltiplicatore += 0.13;
                        if (player.Livello >= 40)
                            moltiplicatore += 0.22;
                    }
                    break;
            }
        }
    }
}
