
using static Server_Strategico.Variabili;

namespace Server_Strategico
{
    internal class Battaglie
    {
        public static async Task<bool> Battaglia_Barbari(Variabili.Player player, Guid clientGuid, string tipo)
        {
            await Battaglia_Distanza(tipo, player, clientGuid); //Pre battaglia, attaccano le unità a distanza ed i mezzi d'assedio

            int guerrieri   = player.Guerrieri;
            int picchieri   = player.Lancieri;
            int arcieri     = player.Arceri;
            int catapulte   = player.Catapulte;

            int guerrieri_Enemy = 0;
            int picchieri_Enemy = 0;
            int arcieri_Enemy = 0;
            int catapulte_Enemy = 0;

            if (tipo == "Barbari_PVE")
            {
                guerrieri_Enemy = player.Guerrieri_Barbari_PVE;
                picchieri_Enemy = player.Lancieri_Barbari_PVE;
                arcieri_Enemy = player.Arceri_Barbari_PVE;
                catapulte_Enemy = player.Catapulte_Barbari_PVE;
            }
            else
            {
                guerrieri_Enemy = Variabili.Barbari.PVP.Guerrieri;
                picchieri_Enemy = Variabili.Barbari.PVP.Lancieri;
                arcieri_Enemy = Variabili.Barbari.PVP.Arceri;
                catapulte_Enemy = Variabili.Barbari.PVP.Catapulte;
            }

            int tipi_Di_Unità = ContareTipiDiUnità(guerrieri, picchieri, arcieri, catapulte);
            int tipi_Di_Unità_Att = ContareTipiDiUnità(guerrieri_Enemy, picchieri_Enemy, arcieri_Enemy, catapulte_Enemy);

            // Calcolo del danno per il giocatore e il nemico
            double dannoInflittoDalNemico = CalcolareDanno_Invasore(arcieri_Enemy, catapulte_Enemy, guerrieri_Enemy, picchieri_Enemy, player) / tipi_Di_Unità;
            double dannoInflitto = CalcolareDanno_Giocatore(arcieri, catapulte, guerrieri, picchieri, player) / tipi_Di_Unità_Att;

            // Applicare il danno alle unità del giocatore
            int guerrieri_Temp  = RidurreNumeroSoldati(guerrieri, dannoInflittoDalNemico, (Esercito.Unità.Guerriero.Difesa + Ricerca.Soldati.Incremento.Difesa * player.Guerriero_Difesa) * guerrieri, Esercito.Unità.Guerriero.Salute + (Ricerca.Soldati.Incremento.Salute * player.Guerriero_Salute));
            int picchieri_Temp  = RidurreNumeroSoldati(picchieri, dannoInflittoDalNemico, (Esercito.Unità.Lanciere.Difesa + Ricerca.Soldati.Incremento.Difesa * player.Lanciere_Difesa) * picchieri, Esercito.Unità.Lanciere.Salute + (Ricerca.Soldati.Incremento.Salute * player.Lanciere_Salute));
            int arcieri_Temp    = RidurreNumeroSoldati(arcieri, dannoInflittoDalNemico * 0.70, (Esercito.Unità.Arciere.Difesa + Ricerca.Soldati.Incremento.Difesa * player.Arciere_Difesa) * arcieri, Esercito.Unità.Arciere.Salute + (Ricerca.Soldati.Incremento.Salute * player.Arciere_Salute));
            int catapulte_Temp  = RidurreNumeroSoldati(catapulte, dannoInflittoDalNemico, (Esercito.Unità.Catapulta.Difesa + Ricerca.Soldati.Incremento.Difesa * player.catapulta_Difesa) * catapulte, Esercito.Unità.Catapulta.Salute + (Ricerca.Soldati.Incremento.Salute * player.catapulta_Salute));

            // Applicare il danno alle unità nemiche
            int guerrieri_Enemy_Temp = RidurreNumeroSoldati(guerrieri_Enemy, dannoInflitto, (Esercito.EsercitoNemico.Guerriero.Difesa + player.Livello_Barbari_PVE) * guerrieri_Enemy, Esercito.EsercitoNemico.Guerriero.Salute + player.Livello_Barbari_PVE);
            int picchieri_Enemy_Temp = RidurreNumeroSoldati(picchieri_Enemy, dannoInflitto, (Esercito.EsercitoNemico.Lanciere.Difesa + player.Livello_Barbari_PVE) * picchieri_Enemy, Esercito.EsercitoNemico.Lanciere.Salute + player.Livello_Barbari_PVE);
            int arcieri_Enemy_Temp   = RidurreNumeroSoldati(arcieri_Enemy, dannoInflitto, (Esercito.EsercitoNemico.Arciere.Difesa + player.Livello_Barbari_PVE) * arcieri_Enemy, Esercito.EsercitoNemico.Arciere.Salute + player.Livello_Barbari_PVE);
            int catapulte_Enemy_Temp = RidurreNumeroSoldati(catapulte_Enemy, dannoInflitto, (Esercito.EsercitoNemico.Catapulta.Difesa + player.Livello_Barbari_PVE) * catapulte_Enemy, Esercito.EsercitoNemico.Catapulta.Salute + player.Livello_Barbari_PVE);

            int esperienza = ((guerrieri_Enemy - guerrieri_Enemy_Temp) * Esercito.EsercitoNemico.Guerriero.Esperienza) +
                                 ((picchieri_Enemy - picchieri_Enemy_Temp) * Esercito.EsercitoNemico.Lanciere.Esperienza) +
                                 ((arcieri_Enemy - arcieri_Enemy_Temp) * Esercito.EsercitoNemico.Arciere.Esperienza) +
                                 ((catapulte_Enemy - catapulte_Enemy_Temp) * Esercito.EsercitoNemico.Arciere.Esperienza);

            Server.Send(clientGuid, $"Log_Server|Danno inflitto dal giocatore: {(dannoInflitto * tipi_Di_Unità_Att++).ToString("0.00")}\r\n");
            Server.Send(clientGuid, $"Log_Server|Danno inflitto dal nemico: {(dannoInflittoDalNemico * tipi_Di_Unità++).ToString("0.00")}");
            Server.Send(clientGuid, $"Log_Server|Guerrieri: {guerrieri - guerrieri_Temp}/{guerrieri}\r\n Lancieri: {picchieri - picchieri_Temp}/{picchieri}\r\n Arcieri: {arcieri - arcieri_Temp}/{arcieri}\r\n Catapulte: {catapulte - catapulte_Temp}/{catapulte}\r\n");
            Server.Send(clientGuid, $"Log_Server|Soldati persi dal giocatore [{player.Username}]:");

            Server.Send(clientGuid, $"Log_Server|Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp}/{guerrieri_Enemy}\r\n Lancieri: {picchieri_Enemy - picchieri_Enemy_Temp}/{picchieri_Enemy}\r\n Arcieri: {arcieri_Enemy - arcieri_Enemy_Temp}/{arcieri_Enemy}\r\n Catapulte: {catapulte_Enemy - catapulte_Enemy_Temp}/{catapulte_Enemy}\r\n");
            Server.Send(clientGuid, $"Log_Server|Soldati persi dal nemico:");
            Server.Send(clientGuid, $"Log_Server|Battaglia PVE Completata\r\n");

            player.Esperienza += esperienza;

            Console.WriteLine($"Danno inflitto dal nemico: {(dannoInflittoDalNemico * tipi_Di_Unità++).ToString("0.00")}");
            Console.WriteLine($"Danno inflitto dal giocatore: {(dannoInflitto * tipi_Di_Unità_Att++).ToString("0.00")}");

            Console.WriteLine($"Guerrieri: {guerrieri - guerrieri_Temp}\r\n Lancieri: {picchieri - picchieri_Temp}\r\n Arcieri: {arcieri - arcieri_Temp}\r\n Catapulte: {catapulte - catapulte_Temp}");
            Console.WriteLine($"Soldati persi dal giocatore:");
            
            Console.WriteLine($"Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp} \r\n Lancieri:  {picchieri_Enemy - picchieri_Enemy_Temp} \r\n Arcieri:  {arcieri_Enemy - arcieri_Enemy_Temp} \r\n Catapulte:  {catapulte_Enemy - catapulte_Enemy_Temp}\r\n");
            Console.WriteLine($"Soldati persi dal nemico:");
            Console.WriteLine($"Battaglia PVE Completata");

            // Aggiornare le quantità delle unità
            player.Guerrieri = guerrieri_Temp;
            player.Lancieri = picchieri_Temp;
            player.Arceri = arcieri_Temp;
            player.Catapulte= catapulte_Temp;


            if (tipo == "Barbari_PVE")
            {
                player.Guerrieri_Barbari_PVE = guerrieri_Enemy_Temp;
                player.Lancieri_Barbari_PVE = picchieri_Enemy_Temp;
                player.Arceri_Barbari_PVE = arcieri_Enemy_Temp;
                player.Catapulte_Barbari_PVE = catapulte_Enemy_Temp;
            }
            else
            {
                Variabili.Barbari.PVP.Guerrieri = guerrieri_Enemy_Temp;
                Variabili.Barbari.PVP.Lancieri = picchieri_Enemy_Temp;
                Variabili.Barbari.PVP.Arceri = arcieri_Enemy_Temp;
                Variabili.Barbari.PVP.Catapulte = catapulte_Enemy_Temp;
            }
            return false;
        }
        public static async Task<bool> Battaglia_PVP(Variabili.Player player, Guid clientGuid, Variabili.Player player2, Guid clientGuid2)
        {
            await Battaglia_Distanza(player, clientGuid, player2, clientGuid2); //Pre battaglia, attaccano le unità a distanza ed i mezzi d'assedio

            int guerrieri = player.Guerrieri;                   //Giocatore attaccante
            int picchieri = player.Lancieri;                    //Giocatore attaccante
            int arcieri = player.Arceri;                        //Giocatore attaccante
            int catapulte = player.Catapulte;                   //Giocatore attaccante

            int guerrieri_Enemy = player2.Guerrieri;     //GIcoatore in difesa
            int picchieri_Enemy = player2.Lancieri;      //GIcoatore in difesa
            int arcieri_Enemy = player2.Arceri;          //GIcoatore in difesa
            int catapulte_Enemy = player2.Catapulte;     //GIcoatore in difesa

            int tipi_Di_Unità = ContareTipiDiUnità(guerrieri, picchieri, arcieri, catapulte);
            int tipi_Di_Unità_Att = ContareTipiDiUnità(guerrieri_Enemy, picchieri_Enemy, arcieri_Enemy, catapulte_Enemy);

            // Calcolo del danno per il giocatore e il nemico
            double dannoInflittoDalNemico = CalcolareDanno_Giocatore(arcieri_Enemy, catapulte_Enemy, guerrieri_Enemy, picchieri_Enemy, player) / tipi_Di_Unità; //Invasore
            double dannoInflitto = CalcolareDanno_Giocatore(arcieri, catapulte, guerrieri, picchieri, player) / tipi_Di_Unità_Att;

            // Applicare il danno alle unità del giocatore
            int guerrieri_Temp = RidurreNumeroSoldati(guerrieri, dannoInflittoDalNemico, Esercito.Unità.Guerriero.Difesa + (Ricerca.Soldati.Incremento.Difesa * player.Guerriero_Difesa) * guerrieri, Esercito.Unità.Guerriero.Salute + (Ricerca.Soldati.Incremento.Salute * player.Guerriero_Salute));
            int picchieri_Temp = RidurreNumeroSoldati(picchieri, dannoInflittoDalNemico, Esercito.Unità.Lanciere.Difesa + (Ricerca.Soldati.Incremento.Difesa * player.Lanciere_Difesa) * picchieri, Esercito.Unità.Lanciere.Salute + (Ricerca.Soldati.Incremento.Salute * player.Lanciere_Salute));
            int arcieri_Temp = RidurreNumeroSoldati(arcieri, dannoInflittoDalNemico * 0.70, Esercito.Unità.Arciere.Difesa + (Ricerca.Soldati.Incremento.Difesa * player.Arciere_Difesa) * arcieri, Esercito.Unità.Arciere.Salute + (Ricerca.Soldati.Incremento.Salute * player.Arciere_Salute));
            int catapulte_Temp = RidurreNumeroSoldati(catapulte, dannoInflittoDalNemico, Esercito.Unità.Catapulta.Difesa + (Ricerca.Soldati.Incremento.Difesa * player.catapulta_Difesa) * catapulte, Esercito.Unità.Catapulta.Salute + (Ricerca.Soldati.Incremento.Salute * player.catapulta_Salute));

            // Applicare il danno alle unità nemiche
            int guerrieri_Enemy_Temp = RidurreNumeroSoldati(guerrieri_Enemy, dannoInflitto, Esercito.Unità.Guerriero.Difesa + (Ricerca.Soldati.Incremento.Difesa * player2.Guerriero_Difesa) * guerrieri_Enemy, Esercito.Unità.Guerriero.Salute + (Ricerca.Soldati.Incremento.Salute * player2.Guerriero_Salute));
            int picchieri_Enemy_Temp = RidurreNumeroSoldati(picchieri_Enemy, dannoInflitto, Esercito.Unità.Lanciere.Difesa + (Ricerca.Soldati.Incremento.Difesa * player2.Lanciere_Difesa) * picchieri_Enemy, Esercito.Unità.Lanciere.Salute + (Ricerca.Soldati.Incremento.Salute * player2.Lanciere_Salute));
            int arcieri_Enemy_Temp = RidurreNumeroSoldati(arcieri_Enemy, dannoInflitto * 0.70, Esercito.Unità.Arciere.Difesa + (Ricerca.Soldati.Incremento.Difesa * player2.Arciere_Difesa) * arcieri_Enemy, Esercito.Unità.Arciere.Salute + (Ricerca.Soldati.Incremento.Salute * player2.Arciere_Salute));
            int catapulte_Enemy_Temp = RidurreNumeroSoldati(catapulte_Enemy, dannoInflitto, Esercito.Unità.Catapulta.Difesa + (Ricerca.Soldati.Incremento.Difesa * player2.catapulta_Difesa) * catapulte_Enemy, Esercito.Unità.Catapulta.Salute + (Ricerca.Soldati.Incremento.Salute * player2.catapulta_Salute));

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

            player.Esperienza += ((guerrieri_Enemy- guerrieri_Enemy_Temp) * Esercito.Unità.Guerriero.Esperienza) + 
                                 ((picchieri_Enemy - picchieri_Enemy_Temp) * Esercito.Unità.Lanciere.Esperienza) + 
                                 ((arcieri_Enemy   - arcieri_Enemy_Temp) * Esercito.Unità.Arciere.Esperienza) + 
                                 ((catapulte_Enemy - catapulte_Enemy_Temp) * Esercito.Unità.Catapulta.Esperienza);
            player2.Esperienza += ((guerrieri - guerrieri_Temp) * Esercito.Unità.Guerriero.Esperienza) + 
                                  ((picchieri - picchieri_Temp) * Esercito.Unità.Lanciere.Esperienza) + 
                                  ((arcieri - arcieri_Temp) * Esercito.Unità.Arciere.Esperienza) + 
                                  ((catapulte - catapulte_Temp) * Esercito.Unità.Catapulta.Esperienza);

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

        public static double CalcolareDanno_Giocatore(int arcieri, int catapulte, int guerrieri, int picchieri, Variabili.Player player)
        {
            double dannoArcieri = 0;  // supponiamo che ogni arciere infligga 5 danni
            double dannoCatapulte = 0;  // supponiamo che ogni catapulta infligga 15 danni
            if (player.Frecce < (arcieri * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte * Esercito.Unità.Catapulta.Componente_Lancio))
            {
                Server.Send(player.guid_Player, $"Log_Server|Gli arceri e le catapulte del giocatore subiscono una riduzione del danno per mancanza di frecce [{(arcieri * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte * Esercito.Unità.Catapulta.Componente_Lancio)}/{player.Frecce}]:");
                dannoArcieri = 0.33 * arcieri * (Esercito.Unità.Arciere.Attacco + (Ricerca.Soldati.Incremento.Attacco * player.Arciere_Attacco));  // supponiamo che ogni arciere infligga 5 danni
                dannoCatapulte = 0.33 * catapulte * (Esercito.Unità.Catapulta.Attacco + (Ricerca.Soldati.Incremento.Attacco * player.catapulta_Attacco));  // supponiamo che ogni catapulta infligga 15 danni
                player.Frecce = 0;
            }
            else
            {
                player.Frecce -= (arcieri * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte * Esercito.Unità.Catapulta.Componente_Lancio);
                dannoArcieri = arcieri * (Esercito.Unità.Arciere.Attacco + (Ricerca.Soldati.Incremento.Attacco * player.Arciere_Attacco));  // supponiamo che ogni arciere infligga 5 danni
                dannoCatapulte = catapulte * (Esercito.Unità.Catapulta.Attacco + (Ricerca.Soldati.Incremento.Attacco * player.catapulta_Attacco));  // supponiamo che ogni catapulta infligga 15 danni
            }

            // Esempio di calcolo del danno combinato, può essere esteso con logiche più complesse
            double dannoGuerrieri = guerrieri * (Esercito.Unità.Guerriero.Attacco + (Ricerca.Soldati.Incremento.Attacco * player.Guerriero_Attacco));  // supponiamo che ogni guerriero infligga 10 danni
            double dannoPicchieri = picchieri * (Esercito.Unità.Lanciere.Attacco + (Ricerca.Soldati.Incremento.Attacco * player.Lanciere_Attacco));  // supponiamo che ogni picchiere infligga 8 danni

            return dannoArcieri + dannoCatapulte + dannoGuerrieri + dannoPicchieri;
        }
        public static double CalcolareDanno_Invasore(int arcieri, int catapulte, int guerrieri, int picchieri, Variabili.Player player)
        {
            // Esempio di calcolo del danno combinato, può essere esteso con logiche più complesse
            double dannoArcieri = arcieri * (Esercito.EsercitoNemico.Arciere.Attacco + player.Livello_Barbari_PVE);  // supponiamo che ogni arciere infligga 5 danni
            double dannoCatapulte = catapulte * (Esercito.EsercitoNemico.Catapulta.Attacco + player.Livello_Barbari_PVE);  // supponiamo che ogni catapulta infligga 15 danni
            double dannoGuerrieri = guerrieri * (Esercito.EsercitoNemico.Guerriero.Attacco + player.Livello_Barbari_PVE);  // supponiamo che ogni guerriero infligga 10 danni
            double dannoPicchieri = picchieri * (Esercito.EsercitoNemico.Lanciere.Attacco + player.Livello_Barbari_PVE);  // supponiamo che ogni picchiere infligga 8 danni

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
        public static int RidurreNumeroSoldati_OLD(int numeroSoldati, double danno, double difesa, double salutePerSoldato)
        {
            // Calcolare il danno effettivo tenendo conto della difesa
            double dannoEffettivo = Math.Max(0, danno - difesa);
            dannoEffettivo = Math.Max(0, dannoEffettivo); // Assicurarsi che il danno non sia negativo

            // Aggiungere una variazione casuale per simulare l'imprevedibilità della battaglia
            Random random = new Random();
            double variationFactor = 1 + (random.NextDouble() * 0.2 - 0.1); // ±10% di variazione
            dannoEffettivo *= variationFactor;

            int soldatiPersi = (int)Math.Ceiling(dannoEffettivo / salutePerSoldato); // Calcolare i soldati persi con una logica più sofisticata
            soldatiPersi = Math.Min(soldatiPersi, numeroSoldati); // Assicurarsi che il numero di soldati persi non superi il numero totale di soldati

            return soldatiPersi;
        }
        static int Panico(int soldatiPersi, int numeroSoldati, Guid clientGuid)
        {
            // Implementare un meccanismo di riduzione progressiva
            if ((double)soldatiPersi / numeroSoldati > 0.8) // Se più dell'80% delle unità sono perse
                soldatiPersi += (int)((numeroSoldati - soldatiPersi) * 0.18); // Applica un fattore di panico/demoralizzazione
            return soldatiPersi;
        }
        public static int ContareTipiDiUnità(int guerrieri, int picchieri, int arcieri, int catapulte)
        {
            int tipiDiUnità = 0;

            if (guerrieri > 0) tipiDiUnità++;
            if (picchieri > 0) tipiDiUnità++;
            if (arcieri > 0) tipiDiUnità++;
            if (catapulte > 0) tipiDiUnità++;

            // Se non ci sono unità, forza a 1 per evitare divisioni per zero
            return tipiDiUnità == 0 ? 1 : tipiDiUnità;
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

            int arcieri_Temp = arcieri * 2 / 3;
            int catapulte_Temp = catapulte * 2 / 3;

            int arcieri_Enemy_Temp = arcieri_Enemy * 2 / 3;
            int catapulte_Enemy_Temp = catapulte_Enemy * 2 / 3;

            if (player.Frecce < (arcieri * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte * Esercito.Unità.Catapulta.Componente_Lancio))
            {
                Server.Send(clientGuid, $"Log_Server|Gli arceri e le catapulte del giocatore subiscono una riduzione del danno per mancanza di frecce [{(arcieri * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte * Esercito.Unità.Catapulta.Componente_Lancio)}/{player.Frecce}]:");
                arcieri_Temp = arcieri_Temp / 3;
                catapulte_Temp = catapulte_Temp / 3;
                player.Frecce = 0;
            }else
                player.Frecce -= (arcieri * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte * Esercito.Unità.Catapulta.Componente_Lancio);
            

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
                }   
                else if (guerrieri_Enemy > 0)
                    guerrieri_Morti_Att = attacco * 4 / 5;
                
                else if (picchieri_Enemy > 0)
                    lancieri_Morti_Att = attacco * 4 / 5;

                if (guerrieri_Morti_Att > guerrieri_Enemy)
                {
                    guerrieri_Morti_Att = guerrieri_Enemy;
                    guerrieri_Enemy = 0;
                }
                else
                    guerrieri_Enemy -= guerrieri_Morti_Att;

                if (lancieri_Morti_Att > picchieri_Enemy)
                {
                    lancieri_Morti_Att = picchieri_Enemy;
                    picchieri_Enemy = 0;
                }
                else
                    picchieri_Enemy -= lancieri_Morti_Att;

                int esperienza = (guerrieri_Morti_Att * Esercito.EsercitoNemico.Guerriero.Esperienza) + (lancieri_Morti_Att * Esercito.EsercitoNemico.Lanciere.Esperienza);

                Console.WriteLine($"({struttura}) Gli arceri e le catapulte del giocatore hanno causato:");
                Console.WriteLine($"({struttura}) Guerrieri morti: {guerrieri_Morti_Att} Lancieri morti: {lancieri_Morti_Att}\r\n");

                if (struttura == "Barbari_PVP")
                {
                    Server.Send(clientGuid, $"Log_Server|Guerrieri morti: {guerrieri_Morti_Att}/{Variabili.Barbari.PVP.Guerrieri} Lancieri morti:  {lancieri_Morti_Att}/{Variabili.Barbari.PVP.Lancieri}\r\n Esperienza: +{esperienza}\r\n");
                    Server.Send(clientGuid, $"Log_Server|Gli arceri e le catapulte del giocatore hanno causato:");
                    Server.Send(clientGuid, $"Log_Server|Frecce utilizzate: {(arcieri * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte * Esercito.Unità.Catapulta.Componente_Lancio)}/{player.Frecce}");
                    Variabili.Barbari.PVP.Guerrieri = guerrieri_Enemy;
                    Variabili.Barbari.PVP.Lancieri = picchieri_Enemy;
                }
                if (struttura == "Barbari_PVE")
                {
                    Server.Send(clientGuid, $"Log_Server|Guerrieri morti: {guerrieri_Morti_Att}/{player.Guerrieri_Barbari_PVE} Lancieri morti:  {lancieri_Morti_Att}/{player.Lancieri_Barbari_PVE}\r\n Esperienza: +{esperienza}\r\n");
                    Server.Send(clientGuid, $"Log_Server|Gli arceri e le catapulte del giocatore hanno causato:");
                    Server.Send(clientGuid, $"Log_Server|Frecce utilizzate: {(arcieri * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte * Esercito.Unità.Catapulta.Componente_Lancio)}/{player.Frecce}");
                    player.Guerrieri_Barbari_PVE = guerrieri_Enemy;
                    player.Lancieri_Barbari_PVE = picchieri_Enemy;
                }
                player.Esperienza += esperienza;
            }

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
                }
                else if (guerrieri > 0) guerrieri_Morti = attacco * 4 / 5;
                else if (picchieri > 0) lancieri_Morti = attacco * 4 / 5;

                if (guerrieri_Morti > guerrieri)
                {
                    guerrieri_Morti = guerrieri;
                    guerrieri = 0;
                }
                else guerrieri -= guerrieri_Morti;

                if (lancieri_Morti > picchieri)
                {
                    lancieri_Morti = picchieri;
                    picchieri = 0;
                }
                else picchieri -= lancieri_Morti;

                Server.Send(clientGuid, $"Log_Server|Guerrieri morti: {guerrieri_Morti}/{player.Guerrieri} Lancieri morti:  {lancieri_Morti}/{player.Lancieri}\r\n");
                Server.Send(clientGuid, $"Log_Server|Gli arceri e le catapulte barbare hanno causato:");

                Console.WriteLine($"({struttura})Gli arceri e le catapulte barbare hanno causato:");
                Console.WriteLine($"({struttura})Guerrieri morti: {guerrieri_Morti}/{player.Guerrieri} Lancieri morti:  {lancieri_Morti}/{player.Lancieri}");

                player.Guerrieri = guerrieri;
                player.Lancieri = picchieri;
            }
            return true;
        } // Arcieri e Mezzi d'assedio attaccano prima della battaglia (giocatore-barbari)
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

            int arcieri_Temp = arcieri * 2 / 3;
            int catapulte_Temp = catapulte * 2 / 3;

            int arcieri_Enemy_Temp = arcieri_Enemy * 2 / 3;
            int catapulte_Enemy_Temp = catapulte_Enemy * 2 / 3;

            if (player.Frecce < (arcieri * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte * Esercito.Unità.Catapulta.Componente_Lancio))
            {
                Server.Send(clientGuid, $"Log_Server|Gli arceri e le catapulte del giocatore [{player.Username}] subiscono una riduzione del danno per mancanza di frecce [{(arcieri * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte * Esercito.Unità.Catapulta.Componente_Lancio)}/{player.Frecce}]:");
                arcieri_Temp = arcieri_Temp / 3;
                catapulte_Temp = catapulte_Temp / 3;
                player.Frecce = 0;
            }
            else
                player.Frecce -= (arcieri * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte * Esercito.Unità.Catapulta.Componente_Lancio);

            if (player2.Frecce < (arcieri_Enemy * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte_Enemy * Esercito.Unità.Catapulta.Componente_Lancio))
            {
                Server.Send(clientGuid, $"Log_Server|Gli arceri e le catapulte del giocatore [{player2.Username}] subiscono una riduzione del danno per mancanza di frecce [{(arcieri_Enemy * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte_Enemy * Esercito.Unità.Catapulta.Componente_Lancio)}/{player.Frecce}]:");
                arcieri_Enemy_Temp = arcieri_Enemy_Temp / 3;
                catapulte_Enemy_Temp = catapulte_Enemy_Temp / 3;
                player2.Frecce = 0;
            }
            else
                player2.Frecce -= (arcieri_Enemy * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte_Enemy * Esercito.Unità.Catapulta.Componente_Lancio);

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
                }
                else if (guerrieri_Enemy > 0) guerrieri_Morti_Att = attacco * 4 / 5;
                else if (picchieri_Enemy > 0) lancieri_Morti_Att = attacco * 4 / 5;

                if (guerrieri_Morti_Att > guerrieri_Enemy)
                {
                    guerrieri_Morti_Att = guerrieri_Enemy;
                    guerrieri_Enemy = 0;
                }
                else
                    guerrieri_Enemy -= guerrieri_Morti_Att;

                if (lancieri_Morti_Att > picchieri_Enemy)
                {
                    lancieri_Morti_Att = picchieri_Enemy;
                    picchieri_Enemy = 0;
                }
                else
                    picchieri_Enemy -= lancieri_Morti_Att;

                player.Esperienza += (guerrieri_Morti_Att * Esercito.Unità.Guerriero.Esperienza) + (lancieri_Morti_Att * Esercito.Unità.Lanciere.Esperienza);
                int esperienza2 = (guerrieri_Morti_Att * Esercito.Unità.Guerriero.Esperienza) + (lancieri_Morti_Att * Esercito.Unità.Lanciere.Esperienza);

                Server.Send(clientGuid2, $"Log_Server|Guerrieri morti: {guerrieri_Morti}/{player2.Guerrieri} Lancieri morti:  {lancieri_Morti}/{player2.Lancieri}\r\n Esperienza:  {esperienza2}\r\n");
                Server.Send(clientGuid2, $"Log_Server|Gli arceri e le catapulte del giocatore [{player2.Username}] hanno causato:");
                Server.Send(clientGuid2, $"Log_Server|Frecce utilizzate: {(arcieri_Enemy * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte_Enemy * Esercito.Unità.Catapulta.Componente_Lancio)}");

                player2.Guerrieri = guerrieri_Enemy;
                player2.Lancieri = picchieri_Enemy;

            }
            Console.WriteLine($"Gli arceri e le catapulte del giocatore [{player.Username}] hanno causato:");
            Console.WriteLine($"Guerrieri morti: {guerrieri_Morti_Att} Lancieri morti:  {lancieri_Morti_Att}");

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
                }
                else if (guerrieri > 0) guerrieri_Morti = attacco * 4 / 5;
                else if (picchieri > 0) lancieri_Morti = attacco * 4 / 5;

                if (guerrieri_Morti > guerrieri)
                {
                    guerrieri_Morti = guerrieri;
                    guerrieri = 0;
                }
                else guerrieri -= guerrieri_Morti;

                if (lancieri_Morti > picchieri)
                {
                    lancieri_Morti = picchieri;
                    picchieri = 0;
                }
                else picchieri -= lancieri_Morti;

                player2.Esperienza += (guerrieri_Morti * Esercito.Unità.Guerriero.Esperienza) + (lancieri_Morti * Esercito.Unità.Lanciere.Esperienza);
                int esperienza1 = (guerrieri_Morti * Esercito.Unità.Guerriero.Esperienza) + (lancieri_Morti * Esercito.Unità.Lanciere.Esperienza);

                Server.Send(clientGuid, $"Log_Server|Guerrieri morti: {guerrieri_Morti}/{player.Guerrieri} Lancieri morti:  {lancieri_Morti}/{player.Lancieri}\r\n Esperienza:  {esperienza1}\r\n");
                Server.Send(clientGuid, $"Log_Server|Gli arceri e le catapulte del giocatore [{player2.Username}] hanno causato:");
                Server.Send(clientGuid, $"Log_Server|Frecce utilizzate: {(arcieri * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte * Esercito.Unità.Catapulta.Componente_Lancio)}");

                player.Guerrieri = guerrieri;
                player.Lancieri = picchieri;
            }

            Console.WriteLine($"Gli arceri e le catapulte del giocatore [{player.Username}] hanno causato:");
            Console.WriteLine($"Guerrieri morti: {guerrieri_Morti} Lancieri morti:  {lancieri_Morti}");
            return true;
        } // Arcieri e Mezzi d'assedio attaccano prima della battaglia (giocatore-giocatore)
    }
}
