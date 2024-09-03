using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Server_Strategico.Variabili;

namespace Server_Strategico
{
    internal class Barbari
    {
        public static bool start = false;

        public static async void Barbari_PVE(Variabili.Player player)
        {
            int guerriero = 0, lanciere = 0, arciere = 0, catapulta = 0, i = 0;
            int respawn = 0;

            player.Guerrieri_Barbari_PVE += 14;
            player.Lancieri_Barbari_PVE += 8;
            player.Arceri_Barbari_PVE += 6;
            player.Catapulte_Barbari_PVE += 1;

            while (true)
            {
                if (player.Livello > 7 && guerriero >= Variabili.EsercitoNemico.Guerriero.TempoReclutamento - 3) player.Guerrieri_Barbari_PVE += 1;
                if (player.Livello > 10 && lanciere >= Variabili.EsercitoNemico.Lanciere.TempoReclutamento - 3) player.Lancieri_Barbari_PVE += 1;
                if (player.Livello > 18 && arciere >= Variabili.EsercitoNemico.Arciere.TempoReclutamento - 3) player.Arceri_Barbari_PVE += 1;
                if (player.Livello > 25 && catapulta >= Variabili.EsercitoNemico.Catapulta.TempoReclutamento - 3) player.Catapulte_Barbari_PVE += 1;

                if (player.Livello > 5)
                {
                    player.Guerrieri_Barbari_PVE += 1;
                    player.Lancieri_Barbari_PVE += 1;
                }

                if (guerriero >= Variabili.EsercitoNemico.Guerriero.TempoReclutamento)
                {
                    player.Guerrieri_Barbari_PVE++;
                    guerriero = 0;
                }
                if (lanciere >= Variabili.EsercitoNemico.Lanciere.TempoReclutamento && player.Livello >= 8)
                {
                    player.Lancieri_Barbari_PVE++;
                    lanciere = 0;
                }
                if (arciere >= Variabili.EsercitoNemico.Arciere.TempoReclutamento && player.Livello >= 16)
                {
                    player.Arceri_Barbari_PVE++;
                    arciere = 0;
                }
                if (catapulta >= Variabili.EsercitoNemico.Catapulta.TempoReclutamento && player.Livello >= 23)
                {
                    player.Catapulte_Barbari_PVE++;
                    catapulta = 0;
                }

                Server_Strategico.dati.forza_Esercito_Att_PVE =
                    player.Guerrieri_Barbari_PVE * ((Variabili.EsercitoNemico.Guerriero.Salute * 0.33) + (Variabili.EsercitoNemico.Guerriero.Attacco * 0.72)) +
                    player.Lancieri_Barbari_PVE * ((Variabili.EsercitoNemico.Lanciere.Salute * 0.33) + (Variabili.EsercitoNemico.Lanciere.Attacco * 0.72)) +
                    player.Arceri_Barbari_PVE * ((Variabili.EsercitoNemico.Arciere.Salute * 0.33) + (Variabili.EsercitoNemico.Arciere.Attacco * 0.72)) +
                    player.Catapulte_Barbari_PVE * ((Variabili.EsercitoNemico.Catapulta.Salute * 0.33) + (Variabili.EsercitoNemico.Catapulta.Attacco * 0.72));

                guerriero++;
                lanciere++;
                arciere++;
                catapulta++;
                respawn++;
                Thread.Sleep(1000);
            }
        }
        public static async void Barbari_PVP(Dictionary<string, Variabili.Player> players)
        {
            int guerriero = 0, lanciere = 0, arciere = 0, catapulta = 0, i = 0;
            int respawn = 0;

            Variabili.Barbari.PVP.Guerrieri += 52;
            Variabili.Barbari.PVP.Lancieri += 38;
            Variabili.Barbari.PVP.Arceri += 21;
            Variabili.Barbari.PVP.Catapulte += 10;

            while (true)
            {
                if (players.Count > 4 && guerriero >= Variabili.EsercitoNemico.Guerriero.TempoReclutamento - 3) Variabili.Barbari.PVP.Guerrieri += 1;
                if (players.Count > 8 && lanciere >= Variabili.EsercitoNemico.Lanciere.TempoReclutamento - 3) Variabili.Barbari.PVP.Lancieri += 1;
                if (players.Count > 12 && arciere >= Variabili.EsercitoNemico.Arciere.TempoReclutamento - 3) Variabili.Barbari.PVP.Arceri += 1;
                if (players.Count > 16 && catapulta >= Variabili.EsercitoNemico.Catapulta.TempoReclutamento - 3) Variabili.Barbari.PVP.Catapulte += 1;

                if (players.Count > 3)
                {
                    Variabili.Barbari.PVP.Guerrieri += 1;
                    Variabili.Barbari.PVP.Lancieri += 1;
                }

                if (guerriero >= Variabili.EsercitoNemico.Guerriero.TempoReclutamento)
                {
                    Variabili.Barbari.PVP.Guerrieri++;
                    guerriero = 0;
                }
                if (lanciere >= Variabili.EsercitoNemico.Lanciere.TempoReclutamento && players.Count >= 2)
                {
                    Variabili.Barbari.PVP.Lancieri++;
                    lanciere = 0;
                }
                if (arciere >= Variabili.EsercitoNemico.Arciere.TempoReclutamento && players.Count >= 3)
                {
                    Variabili.Barbari.PVP.Arceri++;
                    arciere = 0;
                }
                if (catapulta >= Variabili.EsercitoNemico.Catapulta.TempoReclutamento && players.Count >= 4)
                {
                    Variabili.Barbari.PVP.Catapulte++;
                    catapulta = 0;
                }

                Server_Strategico.dati.forza_Esercito_Att_PVP =
                    Variabili.Barbari.PVP.Guerrieri * ((Variabili.EsercitoNemico.Guerriero.Salute * 0.33) + (Variabili.EsercitoNemico.Guerriero.Attacco * 0.72)) +
                    Variabili.Barbari.PVP.Lancieri * ((Variabili.EsercitoNemico.Lanciere.Salute * 0.33) + (Variabili.EsercitoNemico.Lanciere.Attacco * 0.72)) +
                    Variabili.Barbari.PVP.Arceri * ((Variabili.EsercitoNemico.Arciere.Salute * 0.33) + (Variabili.EsercitoNemico.Arciere.Attacco * 0.72)) +
                    Variabili.Barbari.PVP.Catapulte * ((Variabili.EsercitoNemico.Catapulta.Salute * 0.33) + (Variabili.EsercitoNemico.Catapulta.Attacco * 0.72));

                guerriero++;
                lanciere++;
                arciere++;
                catapulta++;
                respawn++;
                Thread.Sleep(1000);
            }
        }
    }
}
