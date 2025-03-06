
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

            int unità = player.Guerrieri_Barbari_PVE + player.Lancieri_Barbari_PVE + player.Arceri_Barbari_PVE + player.Catapulte_Barbari_PVE;
            if (unità < 22)
                Add_Troops_PVE(14, 8, 6, 1, player);

            while (true)
            {
                if (player.Livello > 6 && guerriero >= Esercito.EsercitoNemico.Guerriero.TempoReclutamento * 2) player.Guerrieri_Barbari_PVE += 1;
                if (player.Livello > 10 && lanciere >= Esercito.EsercitoNemico.Lanciere.TempoReclutamento * 2) player.Lancieri_Barbari_PVE += 1;
                if (player.Livello > 15 && arciere >= Esercito.EsercitoNemico.Arciere.TempoReclutamento * 2) player.Arceri_Barbari_PVE += 1;
                if (player.Livello > 21 && catapulta >= Esercito.EsercitoNemico.Catapulta.TempoReclutamento * 2) player.Catapulte_Barbari_PVE += 1;

                if (player.Livello > 5 && guerriero >= Esercito.EsercitoNemico.Guerriero.TempoReclutamento * 2)
                    Add_Troops_PVE(1, 1, 0, 0, player);

                if (respawn == 120)
                {
                    Add_Troops_PVE(2, 2, 5, 0, player);
                    respawn = 0;
                }
                int liv = player.Livello_Barbari_PVE + 1;
                liv = player.Livello_Barbari_PVE * 3;

                if (player.Livello > liv)
                    player.Livello_Barbari_PVE++;
                

                if (guerriero >= Esercito.EsercitoNemico.Guerriero.TempoReclutamento * 2)
                {
                    Add_Troops_PVE(1, 0, 0, 0, player);
                    guerriero = 0;
                }
                if (lanciere >= Esercito.EsercitoNemico.Lanciere.TempoReclutamento * 2 && player.Livello >= 8)
                {
                    Add_Troops_PVE(0, 1, 0, 0, player);
                    lanciere = 0;
                }
                if (arciere >= Esercito.EsercitoNemico.Arciere.TempoReclutamento * 2 && player.Livello >= 16)
                {
                    Add_Troops_PVE(0, 0, 1, 0, player);
                    arciere = 0;
                }
                if (catapulta >= Esercito.EsercitoNemico.Catapulta.TempoReclutamento * 2 && player.Livello >= 23)
                {
                    Add_Troops_PVE(0, 0, 0, 1, player);
                    catapulta = 0;
                }

                player.forza_Esercito_PVE =
                    player.Guerrieri_Barbari_PVE * ((Esercito.EsercitoNemico.Guerriero.Salute * 0.33) + (Esercito.EsercitoNemico.Guerriero.Attacco * 0.72)) +
                    player.Lancieri_Barbari_PVE * ((Esercito.EsercitoNemico.Lanciere.Salute * 0.33) + (Esercito.EsercitoNemico.Lanciere.Attacco * 0.72)) +
                    player.Arceri_Barbari_PVE * ((Esercito.EsercitoNemico.Arciere.Salute * 0.33) + (Esercito.EsercitoNemico.Arciere.Attacco * 0.72)) +
                    player.Catapulte_Barbari_PVE * ((Esercito.EsercitoNemico.Catapulta.Salute * 0.33) + (Esercito.EsercitoNemico.Catapulta.Attacco * 0.72));

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
            int unità = Variabili.Barbari.PVP.Guerrieri + Variabili.Barbari.PVP.Lancieri + Variabili.Barbari.PVP.Arceri + Variabili.Barbari.PVP.Catapulte;
            if (unità < 72)
                Add_Troops_PVP(52,38,21,10);

            while (true)
            {
                if (players.Count > 4 && guerriero >= Esercito.EsercitoNemico.Guerriero.TempoReclutamento * 2) Variabili.Barbari.PVP.Guerrieri += 1;
                if (players.Count > 8 && lanciere >= Esercito.EsercitoNemico.Lanciere.TempoReclutamento * 2) Variabili.Barbari.PVP.Lancieri += 1;
                if (players.Count > 12 && arciere >= Esercito.EsercitoNemico.Arciere.TempoReclutamento * 2) Variabili.Barbari.PVP.Arceri += 1;
                if (players.Count > 16 && catapulta >= Esercito.EsercitoNemico.Catapulta.TempoReclutamento * 2) Variabili.Barbari.PVP.Catapulte += 1;

                if (players.Count >= 2 && guerriero >= Esercito.EsercitoNemico.Guerriero.TempoReclutamento * 2)
                    Add_Troops_PVP(1,1,0,0);

                if (respawn == 120)
                {
                    Add_Troops_PVP(1,1,3,0);
                    respawn = 0;
                }
                //int liv = Variabili.Barbari.PVP.Livello + 1; // Non mi convince... va fatto meglio
                //liv = Variabili.Barbari.PVP.Livello * 3;
                //
                //if (Variabili.Barbari.PVP.Livello > liv)
                //    Variabili.Barbari.PVP.Livello++;


                if (guerriero >= Esercito.EsercitoNemico.Guerriero.TempoReclutamento * 2)
                {
                    Add_Troops_PVP(1, 0, 0, 0);
                    guerriero = 0;
                }
                if (lanciere >= Esercito.EsercitoNemico.Lanciere.TempoReclutamento * 2 && players.Count >= 2)
                {
                    Add_Troops_PVP(0, 1, 0, 0);
                    lanciere = 0;
                }
                if (arciere >= Esercito.EsercitoNemico.Arciere.TempoReclutamento * 2 && players.Count >= 3)
                {
                    Add_Troops_PVP(0, 0, 1, 0);
                    arciere = 0;
                }
                if (catapulta >= Esercito.EsercitoNemico.Catapulta.TempoReclutamento * 2 && players.Count >= 4)
                {
                    Add_Troops_PVP(0, 0, 0, 1);
                    catapulta = 0;
                }

                Server_Strategico.dati.forza_Esercito_Att_PVP =
                    Variabili.Barbari.PVP.Guerrieri * ((Esercito.EsercitoNemico.Guerriero.Salute * 0.25) + (Esercito.EsercitoNemico.Guerriero.Attacco * 0.30)) +
                    Variabili.Barbari.PVP.Lancieri * ((Esercito.EsercitoNemico.Lanciere.Salute * 0.25) + (Esercito.EsercitoNemico.Lanciere.Attacco * 0.30)) +
                    Variabili.Barbari.PVP.Arceri * ((Esercito.EsercitoNemico.Arciere.Salute * 0.25) + (Esercito.EsercitoNemico.Arciere.Attacco * 0.30)) +
                    Variabili.Barbari.PVP.Catapulte * ((Esercito.EsercitoNemico.Catapulta.Salute * 0.25) + (Esercito.EsercitoNemico.Catapulta.Attacco * 0.30));

                guerriero++;
                lanciere++;
                arciere++;
                catapulta++;
                respawn++;
                Thread.Sleep(1000);
            }
        }
        static void Add_Troops_PVP(int guerrieri, int lancieri, int arcieri, int catapulte)
        {
            Variabili.Barbari.PVP.Guerrieri += guerrieri;
            Variabili.Barbari.PVP.Lancieri += lancieri;
            Variabili.Barbari.PVP.Arceri += arcieri;
            Variabili.Barbari.PVP.Catapulte += catapulte;
        }
        static void Add_Troops_PVE(int guerrieri, int lancieri, int arcieri, int catapulte, Variabili.Player player)
        {
            player.Guerrieri_Barbari_PVE += guerrieri;
            player.Lancieri_Barbari_PVE += lancieri;
            player.Arceri_Barbari_PVE += arcieri;
            player.Catapulte_Barbari_PVE += catapulte;
        }
    }
}
