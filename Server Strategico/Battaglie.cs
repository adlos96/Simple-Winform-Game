using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Server_Strategico.Variabili;

namespace Server_Strategico
{
    internal class Battaglie
    {
        public static async Task<bool> Battaglia_Barbari_PVE(Variabili.Player player, Guid clientGuid)
        {
            int tipi_Di_Unità = 0;
            int tipi_Di_Unità_Att = 0;
            await Battaglia_Distanza("Barbari_PVE", player, clientGuid); //Pre battaglia, attaccano le unità a distanza ed i mezzi d'assedio

            int guerrieri   = player.Guerrieri;
            int picchieri   = player.Lancieri;
            int arcieri     = player.Arceri;
            int catapulte   = player.Catapulte;

            int guerrieri_Enemy = player.Guerrieri_Barbari_PVE;
            int picchieri_Enemy = player.Lancieri_Barbari_PVE;
            int arcieri_Enemy   = player.Arceri_Barbari_PVE;
            int catapulte_Enemy = player.Catapulte_Barbari_PVE;

            tipi_Di_Unità = 0;
            tipi_Di_Unità_Att = 0;
            //Cotrollo tipi di unità
            if (guerrieri > 0) tipi_Di_Unità++;
            if (picchieri > 0) tipi_Di_Unità++;
            if (arcieri > 0) tipi_Di_Unità++;
            if (catapulte > 0) tipi_Di_Unità++;

            if (guerrieri_Enemy > 0) tipi_Di_Unità_Att++;
            if (picchieri_Enemy > 0) tipi_Di_Unità_Att++;
            if (arcieri_Enemy > 0) tipi_Di_Unità_Att++;
            if (catapulte_Enemy > 0) tipi_Di_Unità_Att++;

            if (guerrieri + picchieri + arcieri + catapulte == 0)
                tipi_Di_Unità = 1;
            if (guerrieri_Enemy + picchieri_Enemy + arcieri_Enemy + catapulte_Enemy == 0)
                tipi_Di_Unità_Att = 1;

            // Calcolo del danno per il giocatore e il nemico
            double dannoInflittoDalNemico = CalcolareDanno_Invasore(arcieri_Enemy, catapulte_Enemy, guerrieri_Enemy, picchieri_Enemy) / tipi_Di_Unità;
            double dannoInflitto = CalcolareDanno_Giocatore(arcieri, catapulte, guerrieri, picchieri) / tipi_Di_Unità_Att;

            // Applicare il danno alle unità del giocatore
            int guerrieri_Temp = RidurreNumeroSoldati(guerrieri, dannoInflittoDalNemico, Variabili.Esercito.Guerriero.Difesa * guerrieri, Variabili.Esercito.Guerriero.Salute);
            int picchieri_Temp = RidurreNumeroSoldati(picchieri, dannoInflittoDalNemico, Variabili.Esercito.Lanciere.Difesa * picchieri, Variabili.Esercito.Lanciere.Salute);
            int arcieri_Temp = RidurreNumeroSoldati(arcieri, dannoInflittoDalNemico * 0.70, Variabili.Esercito.Arciere.Difesa * arcieri, Variabili.Esercito.Arciere.Salute);
            int catapulte_Temp = RidurreNumeroSoldati(catapulte, dannoInflittoDalNemico, Variabili.Esercito.Catapulta.Difesa * catapulte, Variabili.Esercito.Catapulta.Salute);

            // Applicare il danno alle unità nemiche
            int guerrieri_Enemy_Temp = RidurreNumeroSoldati(guerrieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Guerriero.Difesa * guerrieri_Enemy, Variabili.EsercitoNemico.Guerriero.Salute);
            int picchieri_Enemy_Temp = RidurreNumeroSoldati(picchieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Lanciere.Difesa * picchieri_Enemy, Variabili.EsercitoNemico.Lanciere.Salute);
            int arcieri_Enemy_Temp = RidurreNumeroSoldati(arcieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Arciere.Difesa * arcieri_Enemy, Variabili.EsercitoNemico.Arciere.Salute);
            int catapulte_Enemy_Temp = RidurreNumeroSoldati(catapulte_Enemy, dannoInflitto, Variabili.EsercitoNemico.Catapulta.Difesa * catapulte_Enemy, Variabili.EsercitoNemico.Catapulta.Salute);

            Server.Send(clientGuid, $"Log_Server|Danno inflitto dal giocatore: {(dannoInflitto * tipi_Di_Unità_Att++).ToString("0.00")}\r\n");
            Server.Send(clientGuid, $"Log_Server|Danno inflitto dal nemico: {(dannoInflittoDalNemico * tipi_Di_Unità++).ToString("0.00")}");

            Server.Send(clientGuid, $"Log_Server|Guerrieri: {guerrieri - guerrieri_Temp}\r\n Lancieri: {picchieri - picchieri_Temp}\r\n Arcieri: {arcieri - arcieri_Temp}\r\n Catapulte: {catapulte - catapulte_Temp}\r\n");
            Server.Send(clientGuid, $"Log_Server|Soldati persi dal giocatore:");

            Server.Send(clientGuid, $"Log_Server|Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp}\r\n Lancieri: {picchieri_Enemy - picchieri_Enemy_Temp}\r\n Arcieri: {arcieri_Enemy - arcieri_Enemy_Temp}\r\n Catapulte: {catapulte_Enemy - catapulte_Enemy_Temp}\r\n");
            Server.Send(clientGuid, $"Log_Server|Soldati persi dal nemico:");
            Server.Send(clientGuid, $"Log_Server|Battaglia PVE Completata\r\n");

            player.Esperienza += (guerrieri_Enemy_Temp * Variabili.EsercitoNemico.Guerriero.Esperienza) + (picchieri_Enemy_Temp * Variabili.EsercitoNemico.Lanciere.Esperienza) + (arcieri_Enemy_Temp * Variabili.EsercitoNemico.Arciere.Esperienza) + (catapulte_Enemy_Temp * Variabili.EsercitoNemico.Arciere.Esperienza);

            Console.WriteLine($"Danno inflitto dal nemico: {(dannoInflittoDalNemico * tipi_Di_Unità++).ToString("0.00")}");
            Console.WriteLine($"Danno inflitto dal giocatore: {(dannoInflitto * tipi_Di_Unità_Att++).ToString("0.00")}");
            
            Console.WriteLine($"Guerrieri: {guerrieri - guerrieri_Temp}\r\n Lancieri: {picchieri - picchieri_Temp}\r\n Arcieri: {arcieri - arcieri_Temp}\r\n Catapulte: {catapulte - catapulte_Temp}");
            Console.WriteLine($"Soldati persi dal giocatore:");
            
            Console.WriteLine($"Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp}\r\n Lancieri: {picchieri_Enemy - picchieri_Enemy_Temp}\r\n Arcieri: {arcieri_Enemy - arcieri_Enemy_Temp}\r\n Catapulte: {catapulte_Enemy - catapulte_Enemy_Temp}");
            Console.WriteLine($"Soldati persi dal nemico:");
            Console.WriteLine($"Battaglia PVE Completata");

            // Aggiornare le quantità delle unità
            player.Guerrieri = guerrieri_Temp;
            player.Lancieri = picchieri_Temp;
            player.Arceri = arcieri_Temp;
            player.Catapulte= catapulte_Temp;

            player.Guerrieri_Barbari_PVE = guerrieri_Enemy_Temp;
            player.Lancieri_Barbari_PVE = picchieri_Enemy_Temp;
            player.Arceri_Barbari_PVE = arcieri_Enemy_Temp;
            player.Catapulte_Barbari_PVE = catapulte_Enemy_Temp;

            return false;
        }
        public static async Task<bool> Battaglia_Barbari_PVP(Variabili.Player player, Guid clientGuid)
        {
            int tipi_Di_Unità = 0;
            int tipi_Di_Unità_Att = 0;

            await Battaglia_Distanza("Barbari_PVP", player, clientGuid); //Pre battaglia, attaccano le unità a distanza ed i mezzi d'assedio

            int guerrieri = player.Guerrieri;
            int picchieri = player.Lancieri;
            int arcieri = player.Arceri;
            int catapulte = player.Catapulte;

            int guerrieri_Enemy = player.Guerrieri_Barbari_PVE;
            int picchieri_Enemy = player.Lancieri_Barbari_PVE;
            int arcieri_Enemy = player.Arceri_Barbari_PVE;
            int catapulte_Enemy = player.Catapulte_Barbari_PVE;

            tipi_Di_Unità = 0;
            tipi_Di_Unità_Att = 0;
            //Cotrollo tipi di unità
            if (guerrieri > 0) tipi_Di_Unità++;
            if (picchieri > 0) tipi_Di_Unità++;
            if (arcieri > 0) tipi_Di_Unità++;
            if (catapulte > 0) tipi_Di_Unità++;

            if (guerrieri_Enemy > 0) tipi_Di_Unità_Att++;
            if (picchieri_Enemy > 0) tipi_Di_Unità_Att++;
            if (arcieri_Enemy > 0) tipi_Di_Unità_Att++;
            if (catapulte_Enemy > 0) tipi_Di_Unità_Att++;

            if (guerrieri + picchieri + arcieri + catapulte == 0)
                tipi_Di_Unità = 1;
            if (guerrieri_Enemy + picchieri_Enemy + arcieri_Enemy + catapulte_Enemy == 0)
                tipi_Di_Unità_Att = 1;

            // Calcolo del danno per il giocatore e il nemico
            double dannoInflittoDalNemico = CalcolareDanno_Invasore(arcieri_Enemy, catapulte_Enemy, guerrieri_Enemy, picchieri_Enemy) / tipi_Di_Unità;
            double dannoInflitto = CalcolareDanno_Giocatore(arcieri, catapulte, guerrieri, picchieri) / tipi_Di_Unità_Att;

            // Applicare il danno alle unità del giocatore
            int guerrieri_Temp = RidurreNumeroSoldati(guerrieri, dannoInflittoDalNemico, Variabili.Esercito.Guerriero.Difesa * guerrieri, Variabili.Esercito.Guerriero.Salute);
            int picchieri_Temp = RidurreNumeroSoldati(picchieri, dannoInflittoDalNemico, Variabili.Esercito.Lanciere.Difesa * picchieri, Variabili.Esercito.Lanciere.Salute);
            int arcieri_Temp = RidurreNumeroSoldati(arcieri, dannoInflittoDalNemico * 0.70, Variabili.Esercito.Arciere.Difesa * arcieri, Variabili.Esercito.Arciere.Salute);
            int catapulte_Temp = RidurreNumeroSoldati(catapulte, dannoInflittoDalNemico, Variabili.Esercito.Catapulta.Difesa * catapulte, Variabili.Esercito.Catapulta.Salute);

            // Applicare il danno alle unità nemiche
            int guerrieri_Enemy_Temp = RidurreNumeroSoldati(guerrieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Guerriero.Difesa * guerrieri_Enemy, Variabili.EsercitoNemico.Guerriero.Salute);
            int picchieri_Enemy_Temp = RidurreNumeroSoldati(picchieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Lanciere.Difesa * picchieri_Enemy, Variabili.EsercitoNemico.Lanciere.Salute);
            int arcieri_Enemy_Temp = RidurreNumeroSoldati(arcieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Arciere.Difesa * arcieri_Enemy, Variabili.EsercitoNemico.Arciere.Salute);
            int catapulte_Enemy_Temp = RidurreNumeroSoldati(catapulte_Enemy, dannoInflitto, Variabili.EsercitoNemico.Catapulta.Difesa * catapulte_Enemy, Variabili.EsercitoNemico.Catapulta.Salute);

            Server.Send(clientGuid, $"Log_Server|Danno inflitto dal giocatore: {(dannoInflitto * tipi_Di_Unità_Att++).ToString("0.00")}\r\n");
            Server.Send(clientGuid, $"Log_Server|Danno inflitto dal nemico: {(dannoInflittoDalNemico * tipi_Di_Unità++).ToString("0.00")}");

            Server.Send(clientGuid, $"Log_Server|Guerrieri: {guerrieri - guerrieri_Temp}\r\n Lancieri: {picchieri - picchieri_Temp}\r\n Arcieri: {arcieri - arcieri_Temp}\r\n Catapulte: {catapulte - catapulte_Temp}\r\n");
            Server.Send(clientGuid, $"Log_Server|Soldati persi dal giocatore:");

            Server.Send(clientGuid, $"Log_Server|Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp}\r\n Lancieri: {picchieri_Enemy - picchieri_Enemy_Temp}\r\n Arcieri: {arcieri_Enemy - arcieri_Enemy_Temp}\r\n Catapulte: {catapulte_Enemy - catapulte_Enemy_Temp}\r\n");
            Server.Send(clientGuid, $"Log_Server|Soldati persi dal nemico:");
            Server.Send(clientGuid, $"Log_Server|Battaglia PVP Completata\r\n");

            player.Esperienza += (guerrieri_Enemy_Temp * Variabili.EsercitoNemico.Guerriero.Esperienza) + (picchieri_Enemy_Temp * Variabili.EsercitoNemico.Lanciere.Esperienza) + (arcieri_Enemy_Temp * Variabili.EsercitoNemico.Arciere.Esperienza) + (catapulte_Enemy_Temp * Variabili.EsercitoNemico.Arciere.Esperienza);

            Console.WriteLine($"Danno inflitto dal giocatore: {(dannoInflitto * tipi_Di_Unità_Att++).ToString("0.00")}");
            Console.WriteLine($"Danno inflitto dal nemico: {(dannoInflittoDalNemico * tipi_Di_Unità++).ToString("0.00")}");

            Console.WriteLine($"Soldati persi dal giocatore:");
            Console.WriteLine($"Guerrieri: {guerrieri - guerrieri_Temp}\r\n Lancieri: {picchieri - picchieri_Temp}\r\n Arcieri: {arcieri - arcieri_Temp}\r\n Catapulte: {catapulte - catapulte_Temp}");

            Console.WriteLine($"Soldati persi dal nemico:");
            Console.WriteLine($"Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp}\r\n Lancieri: {picchieri_Enemy - picchieri_Enemy_Temp}\r\n Arcieri: {arcieri_Enemy - arcieri_Enemy_Temp}\r\n Catapulte: {catapulte_Enemy - catapulte_Enemy_Temp}");
            Console.WriteLine($"Battaglia PVP Completata");

            // Aggiornare le quantità delle unità
            player.Guerrieri = guerrieri_Temp;
            player.Lancieri = picchieri_Temp;
            player.Arceri = arcieri_Temp;
            player.Catapulte = catapulte_Temp;

            player.Guerrieri_Barbari_PVE = guerrieri_Enemy_Temp;
            player.Lancieri_Barbari_PVE = picchieri_Enemy_Temp;
            player.Arceri_Barbari_PVE = arcieri_Enemy_Temp;
            player.Catapulte_Barbari_PVE = catapulte_Enemy_Temp;
            return false;
        }
        public static async Task<bool> Battaglia_PVP(Variabili.Player player, Guid clientGuid, Variabili.Player player2, Guid clientGuid2)
        {
            int tipi_Di_Unità = 0;
            int tipi_Di_Unità_Att = 0;

            await Battaglia_Distanza(player, clientGuid, player2, clientGuid2); //Pre battaglia, attaccano le unità a distanza ed i mezzi d'assedio

            int guerrieri = player.Guerrieri;                   //Giocatore attaccante
            int picchieri = player.Lancieri;                    //Giocatore attaccante
            int arcieri = player.Arceri;                        //Giocatore attaccante
            int catapulte = player.Catapulte;                   //Giocatore attaccante

            int guerrieri_Enemy = player2.Guerrieri;     //GIcoatore in difesa
            int picchieri_Enemy = player2.Lancieri;      //GIcoatore in difesa
            int arcieri_Enemy = player2.Arceri;          //GIcoatore in difesa
            int catapulte_Enemy = player2.Catapulte;     //GIcoatore in difesa

            tipi_Di_Unità = 0;
            tipi_Di_Unità_Att = 0;
            //Cotrollo tipi di unità
            if (guerrieri > 0)  tipi_Di_Unità++;
            if (picchieri > 0)  tipi_Di_Unità++;
            if (arcieri > 0)    tipi_Di_Unità++;
            if (catapulte > 0)  tipi_Di_Unità++;

            if (guerrieri_Enemy > 0) tipi_Di_Unità_Att++;
            if (picchieri_Enemy > 0) tipi_Di_Unità_Att++;
            if (arcieri_Enemy > 0)   tipi_Di_Unità_Att++;
            if (catapulte_Enemy > 0) tipi_Di_Unità_Att++;

            if (guerrieri + picchieri + arcieri + catapulte == 0)
                tipi_Di_Unità = 1;
            if (guerrieri_Enemy + picchieri_Enemy + arcieri_Enemy + catapulte_Enemy == 0)
                tipi_Di_Unità_Att = 1;

            // Calcolo del danno per il giocatore e il nemico
            double dannoInflittoDalNemico = CalcolareDanno_Invasore_Player(arcieri_Enemy, catapulte_Enemy, guerrieri_Enemy, picchieri_Enemy) / tipi_Di_Unità;
            double dannoInflitto = CalcolareDanno_Giocatore(arcieri, catapulte, guerrieri, picchieri) / tipi_Di_Unità_Att;

            // Applicare il danno alle unità del giocatore
            int guerrieri_Temp = RidurreNumeroSoldati(guerrieri, dannoInflittoDalNemico, Variabili.Esercito.Guerriero.Difesa * guerrieri, Variabili.Esercito.Guerriero.Salute);
            int picchieri_Temp = RidurreNumeroSoldati(picchieri, dannoInflittoDalNemico, Variabili.Esercito.Lanciere.Difesa * picchieri, Variabili.Esercito.Lanciere.Salute);
            int arcieri_Temp = RidurreNumeroSoldati(arcieri, dannoInflittoDalNemico, Variabili.Esercito.Arciere.Difesa * arcieri, Variabili.Esercito.Arciere.Salute);
            int catapulte_Temp = RidurreNumeroSoldati(catapulte, dannoInflittoDalNemico, Variabili.Esercito.Catapulta.Difesa * catapulte, Variabili.Esercito.Catapulta.Salute);

            // Applicare il danno alle unità nemiche
            int guerrieri_Enemy_Temp = RidurreNumeroSoldati(guerrieri_Enemy, dannoInflitto, Variabili.Esercito.Guerriero.Difesa * guerrieri_Enemy, Variabili.Esercito.Guerriero.Salute);
            int picchieri_Enemy_Temp = RidurreNumeroSoldati(picchieri_Enemy, dannoInflitto, Variabili.Esercito.Lanciere.Difesa * picchieri_Enemy, Variabili.Esercito.Lanciere.Salute);
            int arcieri_Enemy_Temp = RidurreNumeroSoldati(arcieri_Enemy, dannoInflitto, Variabili.Esercito.Arciere.Difesa * arcieri_Enemy, Variabili.Esercito.Arciere.Salute);
            int catapulte_Enemy_Temp = RidurreNumeroSoldati(catapulte_Enemy, dannoInflitto, Variabili.Esercito.Catapulta.Difesa * catapulte_Enemy, Variabili.Esercito.Catapulta.Salute);

            Server.Send(clientGuid, $"Log_Server|Danno inflitto dal giocatore [{player.Username}]: {(dannoInflitto * tipi_Di_Unità_Att++).ToString("0.00")}\r\n");
            Server.Send(clientGuid, $"Log_Server|Danno inflitto dal giocatore [{player2.Username}]: {(dannoInflittoDalNemico * tipi_Di_Unità++).ToString("0.00")}");

            Server.Send(clientGuid, $"Log_Server|Guerrieri: {guerrieri - guerrieri_Temp}\r\n Lancieri: {picchieri - picchieri_Temp}\r\n Arcieri: {arcieri - arcieri_Temp}\r\n Catapulte: {catapulte - catapulte_Temp}\r\n");
            Server.Send(clientGuid, $"Log_Server|Soldati persi dal giocatore [{player.Username}]:");

            Server.Send(clientGuid, $"Log_Server|Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp}\r\n Lancieri: {picchieri_Enemy - picchieri_Enemy_Temp}\r\n Arcieri: {arcieri_Enemy - arcieri_Enemy_Temp}\r\n Catapulte: {catapulte_Enemy - catapulte_Enemy_Temp}\r\n");
            Server.Send(clientGuid, $"Log_Server|Soldati persi dal giocatore [{player2.Username}]:");
            Server.Send(clientGuid, $"Log_Server|Battaglia PVP Completata\r\n");

            Server.Send(clientGuid2, $"Log_Server|Danno inflitto dal giocatore [{player.Username}]: {(dannoInflitto * tipi_Di_Unità_Att++).ToString("0.00")}\r\n");
            Server.Send(clientGuid2, $"Log_Server|Danno inflitto dal giocatore [{player2.Username}]: {(dannoInflittoDalNemico * tipi_Di_Unità++).ToString("0.00")}");

            Server.Send(clientGuid2, $"Log_Server|Guerrieri: {guerrieri - guerrieri_Temp}\r\n Lancieri: {picchieri - picchieri_Temp}\r\n Arcieri: {arcieri - arcieri_Temp}\r\n Catapulte: {catapulte - catapulte_Temp}\r\n");
            Server.Send(clientGuid2, $"Log_Server|Soldati persi dal giocatore [{player.Username}]:");

            Server.Send(clientGuid2, $"Log_Server|Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp}\r\n Lancieri: {picchieri_Enemy - picchieri_Enemy_Temp}\r\n Arcieri: {arcieri_Enemy - arcieri_Enemy_Temp}\r\n Catapulte: {catapulte_Enemy - catapulte_Enemy_Temp}\r\n");
            Server.Send(clientGuid2, $"Log_Server|Soldati persi dal giocatore [{player2.Username}]:");
            Server.Send(clientGuid2, $"Log_Server|Battaglia PVP Completata\r\n");

            player.Esperienza += (guerrieri_Enemy_Temp * Variabili.Esercito.Guerriero.Esperienza) + (picchieri_Enemy_Temp * Variabili.Esercito.Lanciere.Esperienza) + (arcieri_Enemy_Temp * Variabili.Esercito.Arciere.Esperienza) + (catapulte_Enemy_Temp * Variabili.Esercito.Arciere.Esperienza);
            player2.Esperienza += (guerrieri_Temp * Variabili.Esercito.Guerriero.Esperienza) + (picchieri_Temp * Variabili.Esercito.Lanciere.Esperienza) + (arcieri_Temp * Variabili.Esercito.Arciere.Esperienza) + (catapulte_Temp * Variabili.Esercito.Arciere.Esperienza);

            Console.WriteLine($"Danno inflitto dal giocatore [{player.Username}]: {(dannoInflitto * tipi_Di_Unità_Att++).ToString("0.00")}");
            Console.WriteLine($"Danno inflitto dal giocatore [{player2.Username}]: {(dannoInflittoDalNemico * tipi_Di_Unità++).ToString("0.00")}");

            Console.WriteLine($"Soldati persi dal giocatore [{player.Username}]:");
            Console.WriteLine($"Guerrieri: {guerrieri - guerrieri_Temp}\r\n Lancieri: {picchieri - picchieri_Temp}\r\n Arcieri: {arcieri - arcieri_Temp}\r\n Catapulte: {catapulte - catapulte_Temp}");

            Console.WriteLine($"Soldati persi dal giocatore [{player2.Username}]:");
            Console.WriteLine($"Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp}\r\n Lancieri: {picchieri_Enemy - picchieri_Enemy_Temp}\r\n Arcieri: {arcieri_Enemy - arcieri_Enemy_Temp}\r\n Catapulte: {catapulte_Enemy - catapulte_Enemy_Temp}");
            Console.WriteLine($"Battaglia PVP Completata");

            // Aggiornare le quantità delle unità
            player.Guerrieri = guerrieri_Temp;
            player.Lancieri = picchieri_Temp;
            player.Arceri = arcieri_Temp;
            player.Catapulte = catapulte_Temp;

            player2.Guerrieri = guerrieri_Enemy_Temp;
            player2.Lancieri = picchieri_Enemy_Temp;
            player2.Arceri = arcieri_Enemy_Temp;
            player2.Catapulte = catapulte_Enemy_Temp;
            return false;
        }

        public static double CalcolareDanno_Giocatore(int arcieri, int catapulte, int guerrieri, int picchieri)
        {
            // Esempio di calcolo del danno combinato, può essere esteso con logiche più complesse
            double dannoArcieri = arcieri * Variabili.Esercito.Arciere.Attacco;  // supponiamo che ogni arciere infligga 5 danni
            double dannoCatapulte = catapulte * Variabili.Esercito.Catapulta.Attacco;  // supponiamo che ogni catapulta infligga 15 danni
            double dannoGuerrieri = guerrieri * Variabili.Esercito.Guerriero.Attacco;  // supponiamo che ogni guerriero infligga 10 danni
            double dannoPicchieri = picchieri * Variabili.Esercito.Lanciere.Attacco;  // supponiamo che ogni picchiere infligga 8 danni

            return dannoArcieri + dannoCatapulte + dannoGuerrieri + dannoPicchieri;
        }
        public static double CalcolareDanno_Invasore(int arcieri, int catapulte, int guerrieri, int picchieri)
        {
            // Esempio di calcolo del danno combinato, può essere esteso con logiche più complesse
            double dannoArcieri = arcieri * Variabili.EsercitoNemico.Arciere.Attacco;  // supponiamo che ogni arciere infligga 5 danni
            double dannoCatapulte = catapulte * Variabili.EsercitoNemico.Catapulta.Attacco;  // supponiamo che ogni catapulta infligga 15 danni
            double dannoGuerrieri = guerrieri * Variabili.EsercitoNemico.Guerriero.Attacco;  // supponiamo che ogni guerriero infligga 10 danni
            double dannoPicchieri = picchieri * Variabili.EsercitoNemico.Lanciere.Attacco;  // supponiamo che ogni picchiere infligga 8 danni

            return dannoArcieri + dannoCatapulte + dannoGuerrieri + dannoPicchieri;
        }
        public static double CalcolareDanno_Invasore_Player(int arcieri, int catapulte, int guerrieri, int picchieri)
        {
            // Esempio di calcolo del danno combinato, può essere esteso con logiche più complesse
            double dannoArcieri = arcieri * Variabili.Esercito.Arciere.Attacco;  // supponiamo che ogni arciere infligga 5 danni
            double dannoCatapulte = catapulte * Variabili.Esercito.Catapulta.Attacco;  // supponiamo che ogni catapulta infligga 15 danni
            double dannoGuerrieri = guerrieri * Variabili.Esercito.Guerriero.Attacco;  // supponiamo che ogni guerriero infligga 10 danni
            double dannoPicchieri = picchieri * Variabili.Esercito.Lanciere.Attacco;  // supponiamo che ogni picchiere infligga 8 danni

            return dannoArcieri + dannoCatapulte + dannoGuerrieri + dannoPicchieri;
        }
        public static int RidurreNumeroSoldati(int numeroSoldati, double danno, double difesa, double salutePerSoldato)
        {
            // Calcolare il danno effettivo tenendo conto della difesa
            double dannoEffettivo = danno - difesa;
            dannoEffettivo = Math.Max(0, dannoEffettivo); // Assicurarsi che il danno non sia negativo

            int soldatiPersi = Convert.ToInt32(dannoEffettivo / salutePerSoldato);
            numeroSoldati -= soldatiPersi;
            return numeroSoldati < 0 ? 0 : numeroSoldati;
        }
        public static async Task<bool> Battaglia_Distanza(string struttura, Variabili.Player player, Guid clientGuid)
        {
            int guerrieri_Morti = 0, lancieri_Morti = 0, guerrieri_Morti_Att = 0, lancieri_Morti_Att = 0;
            int guerrieri_Enemy = 0, picchieri_Enemy = 0, arcieri_Enemy = 0, catapulte_Enemy = 0;

            int guerrieri = player.Guerrieri;
            int picchieri = player.Lancieri;
            int arcieri = player.Arceri;
            int catapulte = player.Catapulte;

            if (struttura == "Barbari_PVE")
            {
                guerrieri_Enemy = player.Guerrieri_Barbari_PVE;
                picchieri_Enemy = player.Lancieri_Barbari_PVE;
                arcieri_Enemy = player.Arceri_Barbari_PVE;
                catapulte_Enemy = player.Catapulte_Barbari_PVE;
            }
            else if (struttura == "Barbari_PVP")
            {
                guerrieri_Enemy = Variabili.Barbari.PVP.Guerrieri;
                picchieri_Enemy = Variabili.Barbari.PVP.Lancieri;
                arcieri_Enemy = Variabili.Barbari.PVP.Arceri;
                catapulte_Enemy = Variabili.Barbari.PVP.Catapulte;
            }
            else if (struttura == "PVP")
            {
                guerrieri_Enemy = Variabili.Barbari.PVP.Guerrieri;
                picchieri_Enemy = Variabili.Barbari.PVP.Lancieri;
                arcieri_Enemy = Variabili.Barbari.PVP.Arceri;
                catapulte_Enemy = Variabili.Barbari.PVP.Catapulte;
            }

            int arcieri_Temp = arcieri * 3 / 4;
            int catapulte_Temp = catapulte / 4;

            int arcieri_Enemy_Temp = arcieri_Enemy * 3 / 4;
            int catapulte_Enemy_Temp = catapulte_Enemy * 3 / 4;

            #region Se poche unità a distanza e d'assedio
            if (arcieri <= 10) arcieri_Temp = arcieri * 2;
            if (catapulte <= 5) catapulte_Temp = catapulte * 6;
            if (arcieri == 0) arcieri_Temp = 0;
            if (catapulte == 0) catapulte_Temp = 0;

            if (arcieri_Enemy <= 10) arcieri_Enemy_Temp = arcieri_Enemy * 2;
            if (catapulte_Enemy <= 5) catapulte_Enemy_Temp = catapulte_Enemy * 6;
            if (arcieri_Enemy == 0) arcieri_Enemy_Temp = 0;
            if (catapulte_Enemy == 0) catapulte_Enemy_Temp = 0;
            #endregion

            if (arcieri > 0 || catapulte > 0)
            {
                int attacco = (catapulte_Temp + arcieri_Temp) * 4 / 5;
                if (guerrieri_Enemy > 0 && picchieri_Enemy > 0)
                {
                    if (guerrieri_Enemy > picchieri_Enemy)
                    {
                        guerrieri_Morti_Att = attacco * 2 / 3; //Danno 2/3 contro guerrieri
                        lancieri_Morti_Att = attacco / 3; //Danno 1/3 contro lancieri
                    }
                    else
                    {
                        guerrieri_Morti_Att = attacco / 3; //Danno 2/3 contro guerrieri
                        lancieri_Morti_Att = attacco * 2 / 3; //Danno 1/3 contro lancieri
                    }
                    guerrieri_Enemy -= guerrieri_Morti_Att;
                    picchieri_Enemy -= lancieri_Morti_Att;
                }
                else if (guerrieri_Enemy > 0)
                {
                    guerrieri_Morti_Att = attacco * 4 / 5;
                    guerrieri_Enemy -= guerrieri_Morti_Att;
                }
                else if (picchieri_Enemy > 0)
                {
                    lancieri_Morti_Att = attacco * 4 / 5;
                    picchieri_Enemy -= lancieri_Morti_Att;
                }

                if (guerrieri_Enemy < 0) guerrieri_Enemy = 0;
                if (picchieri_Enemy < 0) picchieri_Enemy = 0;

                if(struttura == "PVP")
                {
                    Variabili.Barbari.PVP.Guerrieri = guerrieri_Enemy;
                    Variabili.Barbari.PVP.Lancieri = picchieri_Enemy;
                }
                if(struttura == "PVE")
                {
                    player.Guerrieri_Barbari_PVE = guerrieri_Enemy;
                    player.Lancieri_Barbari_PVE = picchieri_Enemy;
                }
            }
            Console.WriteLine($"({struttura}) Gli arceri e le catapulte del giocatore hanno causato:");
            Console.WriteLine($"({struttura}) Guerrieri morti: {guerrieri_Morti_Att} Lancieri morti:  {lancieri_Morti_Att}");
            player.Esperienza += (guerrieri_Morti_Att * Variabili.EsercitoNemico.Guerriero.Esperienza) + (lancieri_Morti_Att * Variabili.EsercitoNemico.Lanciere.Esperienza);

            Server.Send(clientGuid, $"Log_Server|Guerrieri morti: {guerrieri_Morti_Att} Lancieri morti:  {lancieri_Morti_Att}\r\n");
            Server.Send(clientGuid, $"Log_Server|Gli arceri e le catapulte del giocatore hanno causato:");
            if (arcieri_Enemy > 0 || catapulte_Enemy > 0)
            {
                int attacco = (catapulte_Enemy_Temp + arcieri_Enemy_Temp) * 4 / 5;
                if (guerrieri > 0 && picchieri > 0)
                {
                    if (guerrieri > picchieri)
                    {
                        guerrieri_Morti = attacco * 2 / 3;
                        lancieri_Morti = attacco / 3;
                    }
                    else
                    {
                        guerrieri_Morti = attacco / 3;
                        lancieri_Morti = attacco * 2 / 3;
                    }

                    guerrieri -= guerrieri_Morti;
                    picchieri -= lancieri_Morti;
                }
                else if (guerrieri > 0)
                {
                    guerrieri_Morti = attacco * 4 / 5;
                    guerrieri -= guerrieri_Morti;
                    picchieri -= lancieri_Morti;
                }
                else if (picchieri > 0)
                {
                    lancieri_Morti = attacco * 4 / 5;
                    picchieri -= lancieri_Morti;
                    guerrieri -= guerrieri_Morti;
                }
                if (guerrieri < 0) guerrieri = 0;
                if (picchieri < 0) picchieri = 0;

                player.Guerrieri = guerrieri;
                player.Lancieri = picchieri;
            }
            Server.Send(clientGuid, $"Log_Server|Guerrieri morti: {guerrieri_Morti} Lancieri morti:  {lancieri_Morti}\r\n");
            Server.Send(clientGuid, $"Log_Server|Gli arceri e le catapulte barbare hanno causato:");

            Console.WriteLine($"({struttura})Gli arceri e le catapulte barbare hanno causato:");
            Console.WriteLine($"({struttura})Guerrieri morti: {guerrieri_Morti} Lancieri morti:  {lancieri_Morti}");
            return true;
        } // Arcieri e Mezzi d'assedio attaccano prima della battaglia
        public static async Task<bool> Battaglia_Distanza(Variabili.Player player, Guid clientGuid, Variabili.Player player2, Guid clientGuid2)
        {
            int guerrieri_Morti = 0, lancieri_Morti = 0, guerrieri_Morti_Att = 0, lancieri_Morti_Att = 0;
            int guerrieri_Enemy = 0, picchieri_Enemy = 0, arcieri_Enemy = 0, catapulte_Enemy = 0;

            int guerrieri = player.Guerrieri;
            int picchieri = player.Lancieri;
            int arcieri = player.Arceri;
            int catapulte = player.Catapulte;

            guerrieri_Enemy = player2.Guerrieri;
            picchieri_Enemy = player2.Lancieri;
            arcieri_Enemy = player2.Arceri;
            catapulte_Enemy = player2.Catapulte;

            int arcieri_Temp = arcieri * 3 / 4;
            int catapulte_Temp = catapulte / 4;

            int arcieri_Enemy_Temp = arcieri_Enemy * 3 / 4;
            int catapulte_Enemy_Temp = catapulte_Enemy * 3 / 4;

            #region Se poche unità a distanza e d'assedio
            if (arcieri <= 10) arcieri_Temp = arcieri * 2;
            if (catapulte <= 5) catapulte_Temp = catapulte * 6;
            if (arcieri == 0) arcieri_Temp = 0;
            if (catapulte == 0) catapulte_Temp = 0;

            if (arcieri_Enemy <= 10) arcieri_Enemy_Temp = arcieri_Enemy * 2;
            if (catapulte_Enemy <= 5) catapulte_Enemy_Temp = catapulte_Enemy * 6;
            if (arcieri_Enemy == 0) arcieri_Enemy_Temp = 0;
            if (catapulte_Enemy == 0) catapulte_Enemy_Temp = 0;
            #endregion

            if (arcieri > 0 || catapulte > 0)
            {
                int attacco = (catapulte_Temp + arcieri_Temp) * 4 / 5;
                if (guerrieri_Enemy > 0 && picchieri_Enemy > 0)
                {
                    if (guerrieri_Enemy > picchieri_Enemy)
                    {
                        guerrieri_Morti_Att = attacco * 2 / 3; //Danno 2/3 contro guerrieri
                        lancieri_Morti_Att = attacco / 3; //Danno 1/3 contro lancieri
                    }
                    else
                    {
                        guerrieri_Morti_Att = attacco / 3; //Danno 2/3 contro guerrieri
                        lancieri_Morti_Att = attacco * 2 / 3; //Danno 1/3 contro lancieri
                    }
                    guerrieri_Enemy -= guerrieri_Morti_Att;
                    picchieri_Enemy -= lancieri_Morti_Att;
                }
                else if (guerrieri_Enemy > 0)
                {
                    guerrieri_Morti_Att = attacco * 4 / 5;
                    guerrieri_Enemy -= guerrieri_Morti_Att;
                }
                else if (picchieri_Enemy > 0)
                {
                    lancieri_Morti_Att = attacco * 4 / 5;
                    picchieri_Enemy -= lancieri_Morti_Att;
                }

                if (guerrieri_Enemy < 0) guerrieri_Enemy = 0;
                if (picchieri_Enemy < 0) picchieri_Enemy = 0;

                player2.Guerrieri = guerrieri_Enemy;
                player2.Lancieri= picchieri_Enemy;

            }
            Console.WriteLine($"Gli arceri e le catapulte del giocatore [{player.Username}] hanno causato:");
            Console.WriteLine($"Guerrieri morti: {guerrieri_Morti_Att} Lancieri morti:  {lancieri_Morti_Att}");
            player.Esperienza += (guerrieri_Morti_Att * Variabili.Esercito.Guerriero.Esperienza) + (lancieri_Morti_Att * Variabili.Esercito.Lanciere.Esperienza);

            Server.Send(clientGuid, $"Log_Server|Guerrieri morti: {guerrieri_Morti_Att} Lancieri morti:  {lancieri_Morti_Att}\r\n");
            Server.Send(clientGuid, $"Log_Server|Gli arceri e le catapulte del giocatore [{player.Username}] hanno causato:");
            Server.Send(clientGuid2, $"Log_Server|Guerrieri morti: {guerrieri_Morti_Att} Lancieri morti:  {lancieri_Morti_Att}\r\n");
            Server.Send(clientGuid2, $"Log_Server|Gli arceri e le catapulte del giocatore [{player.Username}] hanno causato:");

            if (arcieri_Enemy > 0 || catapulte_Enemy > 0)
            {
                int attacco = (catapulte_Enemy_Temp + arcieri_Enemy_Temp) * 4 / 5;
                if (guerrieri > 0 && picchieri > 0)
                {
                    if (guerrieri > picchieri)
                    {
                        guerrieri_Morti = attacco * 2 / 3;
                        lancieri_Morti = attacco / 3;
                    }
                    else
                    {
                        guerrieri_Morti = attacco / 3;
                        lancieri_Morti = attacco * 2 / 3;
                    }

                    guerrieri -= guerrieri_Morti;
                    picchieri -= lancieri_Morti;
                }
                else if (guerrieri > 0)
                {
                    guerrieri_Morti = attacco * 4 / 5;
                    guerrieri -= guerrieri_Morti;
                    picchieri -= lancieri_Morti;
                }
                else if (picchieri > 0)
                {
                    lancieri_Morti = attacco * 4 / 5;
                    picchieri -= lancieri_Morti;
                    guerrieri -= guerrieri_Morti;
                }
                if (guerrieri < 0) guerrieri = 0;
                if (picchieri < 0) picchieri = 0;

                player.Guerrieri = guerrieri;
                player.Lancieri = picchieri;
            }
            player2.Esperienza += (guerrieri_Morti * Variabili.Esercito.Guerriero.Esperienza) + (lancieri_Morti * Variabili.Esercito.Lanciere.Esperienza);
            Server.Send(clientGuid, $"Log_Server|Guerrieri morti: {guerrieri_Morti} Lancieri morti:  {lancieri_Morti}\r\n");
            Server.Send(clientGuid, $"Log_Server|Gli arceri e le catapulte del giocatore [{player2.Username}] hanno causato:");

            Server.Send(clientGuid2, $"Log_Server|Guerrieri morti: {guerrieri_Morti} Lancieri morti:  {lancieri_Morti}\r\n");
            Server.Send(clientGuid2, $"Log_Server|Gli arceri e le catapulte del giocatore [{player2.Username}] hanno causato:");

            Console.WriteLine($"Gli arceri e le catapulte del giocatore [{player.Username}] hanno causato:");
            Console.WriteLine($"Guerrieri morti: {guerrieri_Morti} Lancieri morti:  {lancieri_Morti}");
            return true;
        } // Arcieri e Mezzi d'assedio attaccano prima della battaglia
    }
}
