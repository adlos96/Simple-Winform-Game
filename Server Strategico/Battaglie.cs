
namespace Server_Strategico
{
    internal class Battaglie
    {
        public static async Task<bool> Battaglia_Barbari_PVE(Variabili.Player player, Guid clientGuid)
        {
            await Battaglia_Distanza("Barbari_PVE", player, clientGuid); //Pre battaglia, attaccano le unità a distanza ed i mezzi d'assedio

            int guerrieri   = player.Guerrieri;
            int picchieri   = player.Lancieri;
            int arcieri     = player.Arceri;
            int catapulte   = player.Catapulte;

            int guerrieri_Enemy = player.Guerrieri_Barbari_PVE;
            int picchieri_Enemy = player.Lancieri_Barbari_PVE;
            int arcieri_Enemy   = player.Arceri_Barbari_PVE;
            int catapulte_Enemy = player.Catapulte_Barbari_PVE;

            int tipi_Di_Unità = ContareTipiDiUnità(guerrieri, picchieri, arcieri, catapulte);
            int tipi_Di_Unità_Att = ContareTipiDiUnità(guerrieri_Enemy, picchieri_Enemy, arcieri_Enemy, catapulte_Enemy);

            // Calcolo del danno per il giocatore e il nemico
            double dannoInflittoDalNemico = CalcolareDanno_Invasore(arcieri_Enemy, catapulte_Enemy, guerrieri_Enemy, picchieri_Enemy) / tipi_Di_Unità;
            double dannoInflitto = CalcolareDanno_Giocatore(arcieri, catapulte, guerrieri, picchieri) / tipi_Di_Unità_Att;

            // Applicare il danno alle unità del giocatore
            int guerrieri_Temp = RidurreNumeroSoldati(guerrieri, dannoInflittoDalNemico, Esercito.Unità.Guerriero.Difesa * guerrieri, Esercito.Unità.Guerriero.Salute);
            int picchieri_Temp = RidurreNumeroSoldati(picchieri, dannoInflittoDalNemico, Esercito.Unità.Lanciere.Difesa * picchieri, Esercito.Unità.Lanciere.Salute);
            int arcieri_Temp = RidurreNumeroSoldati(arcieri, dannoInflittoDalNemico * 0.70, Esercito.Unità.Arciere.Difesa * arcieri, Esercito.Unità.Arciere.Salute);
            int catapulte_Temp = RidurreNumeroSoldati(catapulte, dannoInflittoDalNemico, Esercito.Unità.Catapulta.Difesa * catapulte, Esercito.Unità.Catapulta.Salute);

            // Applicare il danno alle unità nemiche
            int guerrieri_Enemy_Temp = RidurreNumeroSoldati(guerrieri_Enemy, dannoInflitto, Esercito.EsercitoNemico.Guerriero.Difesa * guerrieri_Enemy, Esercito.EsercitoNemico.Guerriero.Salute);
            int picchieri_Enemy_Temp = RidurreNumeroSoldati(picchieri_Enemy, dannoInflitto, Esercito.EsercitoNemico.Lanciere.Difesa * picchieri_Enemy, Esercito.EsercitoNemico.Lanciere.Salute);
            int arcieri_Enemy_Temp = RidurreNumeroSoldati(arcieri_Enemy, dannoInflitto, Esercito.EsercitoNemico.Arciere.Difesa * arcieri_Enemy, Esercito.EsercitoNemico.Arciere.Salute);
            int catapulte_Enemy_Temp = RidurreNumeroSoldati(catapulte_Enemy, dannoInflitto, Esercito.EsercitoNemico.Catapulta.Difesa * catapulte_Enemy, Esercito.EsercitoNemico.Catapulta.Salute);

            Server.Send(clientGuid, $"Log_Server|Danno inflitto dal giocatore: {(dannoInflitto * tipi_Di_Unità_Att++).ToString("0.00")}\r\n");
            Server.Send(clientGuid, $"Log_Server|Danno inflitto dal nemico: {(dannoInflittoDalNemico * tipi_Di_Unità++).ToString("0.00")}");

            Server.Send(clientGuid, $"Log_Server|Guerrieri: {guerrieri - guerrieri_Temp}/{guerrieri}\r\n Lancieri: {picchieri - picchieri_Temp}/{picchieri}\r\n Arcieri: {arcieri - arcieri_Temp}/{arcieri}\r\n Catapulte: {catapulte - catapulte_Temp}/{catapulte}\r\n");
            Server.Send(clientGuid, $"Log_Server|Soldati persi dal giocatore:");

            Server.Send(clientGuid, $"Log_Server|Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp}/{guerrieri_Enemy}\r\n Lancieri: {picchieri_Enemy - picchieri_Enemy_Temp}/{picchieri_Enemy}\r\n Arcieri: {arcieri_Enemy - arcieri_Enemy_Temp}/{arcieri_Enemy}\r\n Catapulte: {catapulte_Enemy - catapulte_Enemy_Temp}/{catapulte_Enemy}\r\n");
            Server.Send(clientGuid, $"Log_Server|Soldati persi dal nemico:");
            Server.Send(clientGuid, $"Log_Server|Battaglia PVE Completata\r\n");

            player.Esperienza += ((guerrieri_Enemy - guerrieri_Enemy_Temp) * Esercito.EsercitoNemico.Guerriero.Esperienza) + 
                                 ((picchieri_Enemy - picchieri_Enemy_Temp) * Esercito.EsercitoNemico.Lanciere.Esperienza) + 
                                 ((arcieri_Enemy - arcieri_Enemy_Temp) * Esercito.EsercitoNemico.Arciere.Esperienza) + 
                                 ((catapulte_Enemy - catapulte_Enemy_Temp) * Esercito.EsercitoNemico.Arciere.Esperienza);

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
            await Battaglia_Distanza("Barbari_PVP", player, clientGuid); //Pre battaglia, attaccano le unità a distanza ed i mezzi d'assedio

            int guerrieri = player.Guerrieri;
            int picchieri = player.Lancieri;
            int arcieri = player.Arceri;
            int catapulte = player.Catapulte;

            int guerrieri_Enemy = player.Guerrieri_Barbari_PVE;
            int picchieri_Enemy = player.Lancieri_Barbari_PVE;
            int arcieri_Enemy = player.Arceri_Barbari_PVE;
            int catapulte_Enemy = player.Catapulte_Barbari_PVE;

            int tipi_Di_Unità = ContareTipiDiUnità(guerrieri, picchieri, arcieri, catapulte);
            int tipi_Di_Unità_Att = ContareTipiDiUnità(guerrieri_Enemy, picchieri_Enemy, arcieri_Enemy, catapulte_Enemy);

            // Calcolo del danno per il giocatore e il nemico
            double dannoInflittoDalNemico = CalcolareDanno_Invasore(arcieri_Enemy, catapulte_Enemy, guerrieri_Enemy, picchieri_Enemy) / tipi_Di_Unità;
            double dannoInflitto = CalcolareDanno_Giocatore(arcieri, catapulte, guerrieri, picchieri) / tipi_Di_Unità_Att;

            // Applicare il danno alle unità del giocatore
            int guerrieri_Temp = RidurreNumeroSoldati(guerrieri, dannoInflittoDalNemico, Esercito.Unità.Guerriero.Difesa * guerrieri, Esercito.Unità.Guerriero.Salute);
            int picchieri_Temp = RidurreNumeroSoldati(picchieri, dannoInflittoDalNemico, Esercito.Unità.Lanciere.Difesa * picchieri, Esercito.Unità.Lanciere.Salute);
            int arcieri_Temp = RidurreNumeroSoldati(arcieri, dannoInflittoDalNemico * 0.70, Esercito.Unità.Arciere.Difesa * arcieri, Esercito.Unità.Arciere.Salute);
            int catapulte_Temp = RidurreNumeroSoldati(catapulte, dannoInflittoDalNemico, Esercito.Unità.Catapulta.Difesa * catapulte, Esercito.Unità.Catapulta.Salute);

            // Applicare il danno alle unità nemiche
            int guerrieri_Enemy_Temp = RidurreNumeroSoldati(guerrieri_Enemy, dannoInflitto, Esercito.EsercitoNemico.Guerriero.Difesa * guerrieri_Enemy, Esercito.EsercitoNemico.Guerriero.Salute);
            int picchieri_Enemy_Temp = RidurreNumeroSoldati(picchieri_Enemy, dannoInflitto, Esercito.EsercitoNemico.Lanciere.Difesa * picchieri_Enemy, Esercito.EsercitoNemico.Lanciere.Salute);
            int arcieri_Enemy_Temp = RidurreNumeroSoldati(arcieri_Enemy, dannoInflitto, Esercito.EsercitoNemico.Arciere.Difesa * arcieri_Enemy, Esercito.EsercitoNemico.Arciere.Salute);
            int catapulte_Enemy_Temp = RidurreNumeroSoldati(catapulte_Enemy, dannoInflitto, Esercito.EsercitoNemico.Catapulta.Difesa * catapulte_Enemy, Esercito.EsercitoNemico.Catapulta.Salute);

            Server.Send(clientGuid, $"Log_Server|Danno inflitto dal giocatore: {(dannoInflitto * tipi_Di_Unità_Att++).ToString("0.00")}\r\n");
            Server.Send(clientGuid, $"Log_Server|Danno inflitto dal nemico: {(dannoInflittoDalNemico * tipi_Di_Unità++).ToString("0.00")}");

            Server.Send(clientGuid, $"Log_Server|Guerrieri: {guerrieri - guerrieri_Temp}\r\n Lancieri: {picchieri - picchieri_Temp}\r\n Arcieri: {arcieri - arcieri_Temp}\r\n Catapulte: {catapulte - catapulte_Temp}\r\n");
            Server.Send(clientGuid, $"Log_Server|Soldati persi dal giocatore:");

            Server.Send(clientGuid, $"Log_Server|Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp}\r\n Lancieri: {picchieri_Enemy - picchieri_Enemy_Temp}\r\n Arcieri: {arcieri_Enemy - arcieri_Enemy_Temp}\r\n Catapulte: {catapulte_Enemy - catapulte_Enemy_Temp}\r\n");
            Server.Send(clientGuid, $"Log_Server|Soldati persi dal nemico:");
            Server.Send(clientGuid, $"Log_Server|Battaglia PVP Completata\r\n");

            player.Esperienza += ((guerrieri_Enemy - guerrieri_Enemy_Temp) * Esercito.EsercitoNemico.Guerriero.Esperienza) +
                                 ((picchieri_Enemy - picchieri_Enemy_Temp) * Esercito.EsercitoNemico.Lanciere.Esperienza) +
                                 ((arcieri_Enemy - arcieri_Enemy_Temp) * Esercito.EsercitoNemico.Arciere.Esperienza) +
                                 ((catapulte_Enemy - catapulte_Enemy_Temp) * Esercito.EsercitoNemico.Arciere.Esperienza);

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
            double dannoInflittoDalNemico = CalcolareDanno_Invasore_Player(arcieri_Enemy, catapulte_Enemy, guerrieri_Enemy, picchieri_Enemy) / tipi_Di_Unità;
            double dannoInflitto = CalcolareDanno_Giocatore(arcieri, catapulte, guerrieri, picchieri) / tipi_Di_Unità_Att;

            // Applicare il danno alle unità del giocatore
            int guerrieri_Temp = RidurreNumeroSoldati(guerrieri, dannoInflittoDalNemico, Esercito.Unità.Guerriero.Difesa * guerrieri, Esercito.Unità.Guerriero.Salute);
            int picchieri_Temp = RidurreNumeroSoldati(picchieri, dannoInflittoDalNemico, Esercito.Unità.Lanciere.Difesa * picchieri, Esercito.Unità.Lanciere.Salute);
            int arcieri_Temp = RidurreNumeroSoldati(arcieri, dannoInflittoDalNemico, Esercito.Unità.Arciere.Difesa * arcieri, Esercito.Unità.Arciere.Salute);
            int catapulte_Temp = RidurreNumeroSoldati(catapulte, dannoInflittoDalNemico, Esercito.Unità.Catapulta.Difesa * catapulte, Esercito.Unità.Catapulta.Salute);

            // Applicare il danno alle unità nemiche
            int guerrieri_Enemy_Temp = RidurreNumeroSoldati(guerrieri_Enemy, dannoInflitto, Esercito.Unità.Guerriero.Difesa * guerrieri_Enemy, Esercito.Unità.Guerriero.Salute);
            int picchieri_Enemy_Temp = RidurreNumeroSoldati(picchieri_Enemy, dannoInflitto, Esercito.Unità.Lanciere.Difesa * picchieri_Enemy, Esercito.Unità.Lanciere.Salute);
            int arcieri_Enemy_Temp = RidurreNumeroSoldati(arcieri_Enemy, dannoInflitto, Esercito.Unità.Arciere.Difesa * arcieri_Enemy, Esercito.Unità.Arciere.Salute);
            int catapulte_Enemy_Temp = RidurreNumeroSoldati(catapulte_Enemy, dannoInflitto, Esercito.Unità.Catapulta.Difesa * catapulte_Enemy, Esercito.Unità.Catapulta.Salute);

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

            player.Esperienza += ((guerrieri_Enemy - guerrieri_Enemy_Temp) * Esercito.Unità.Guerriero.Esperienza) + 
                                 ((picchieri_Enemy - picchieri_Enemy_Temp) * Esercito.Unità.Lanciere.Esperienza) + 
                                 ((arcieri_Enemy - arcieri_Enemy_Temp) * Esercito.Unità.Arciere.Esperienza) + 
                                 ((catapulte_Enemy - catapulte_Enemy_Temp) * Esercito.Unità.Arciere.Esperienza);
            player2.Esperienza += ((guerrieri - guerrieri_Temp) * Esercito.Unità.Guerriero.Esperienza) + 
                                  ((picchieri - picchieri_Temp) * Esercito.Unità.Lanciere.Esperienza) + 
                                  ((arcieri - arcieri_Temp) * Esercito.Unità.Arciere.Esperienza) + 
                                  ((catapulte - catapulte_Temp) * Esercito.Unità.Arciere.Esperienza);

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
            double dannoArcieri = arcieri * Esercito.Unità.Arciere.Attacco;  // supponiamo che ogni arciere infligga 5 danni
            double dannoCatapulte = catapulte * Esercito.Unità.Catapulta.Attacco;  // supponiamo che ogni catapulta infligga 15 danni
            double dannoGuerrieri = guerrieri * Esercito.Unità.Guerriero.Attacco;  // supponiamo che ogni guerriero infligga 10 danni
            double dannoPicchieri = picchieri * Esercito.Unità.Lanciere.Attacco;  // supponiamo che ogni picchiere infligga 8 danni

            return dannoArcieri + dannoCatapulte + dannoGuerrieri + dannoPicchieri;
        }
        public static double CalcolareDanno_Invasore(int arcieri, int catapulte, int guerrieri, int picchieri)
        {
            // Esempio di calcolo del danno combinato, può essere esteso con logiche più complesse
            double dannoArcieri = arcieri * Esercito.EsercitoNemico.Arciere.Attacco;  // supponiamo che ogni arciere infligga 5 danni
            double dannoCatapulte = catapulte * Esercito.EsercitoNemico.Catapulta.Attacco;  // supponiamo che ogni catapulta infligga 15 danni
            double dannoGuerrieri = guerrieri * Esercito.EsercitoNemico.Guerriero.Attacco;  // supponiamo che ogni guerriero infligga 10 danni
            double dannoPicchieri = picchieri * Esercito.EsercitoNemico.Lanciere.Attacco;  // supponiamo che ogni picchiere infligga 8 danni

            return dannoArcieri + dannoCatapulte + dannoGuerrieri + dannoPicchieri;
        }
        public static double CalcolareDanno_Invasore_Player(int arcieri, int catapulte, int guerrieri, int picchieri)
        {
            // Esempio di calcolo del danno combinato, può essere esteso con logiche più complesse
            double dannoArcieri = arcieri * Esercito.Unità.Arciere.Attacco;  // supponiamo che ogni arciere infligga 5 danni
            double dannoCatapulte = catapulte * Esercito.Unità.Catapulta.Attacco;  // supponiamo che ogni catapulta infligga 15 danni
            double dannoGuerrieri = guerrieri * Esercito.Unità.Guerriero.Attacco;  // supponiamo che ogni guerriero infligga 10 danni
            double dannoPicchieri = picchieri * Esercito.Unità.Lanciere.Attacco;  // supponiamo che ogni picchiere infligga 8 danni

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
        private static int ContareTipiDiUnità(int guerrieri, int picchieri, int arcieri, int catapulte)
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

                Console.WriteLine($"({struttura}) Gli arceri e le catapulte del giocatore hanno causato:");
                Console.WriteLine($"({struttura}) Guerrieri morti: {guerrieri_Morti_Att} Lancieri morti:  {lancieri_Morti_Att}");

                if (struttura == "Barbari_PVP")
                {
                    Server.Send(clientGuid, $"Log_Server|Guerrieri morti: {guerrieri_Morti_Att}/{Variabili.Barbari.PVP.Guerrieri} Lancieri morti:  {lancieri_Morti_Att}/{Variabili.Barbari.PVP.Lancieri}\r\n");
                    Server.Send(clientGuid, $"Log_Server|Gli arceri e le catapulte del giocatore hanno causato:");
                    Server.Send(clientGuid, $"Log_Server|Frecce utilizzate: {(arcieri * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte * Esercito.Unità.Catapulta.Componente_Lancio)}");
                    Variabili.Barbari.PVP.Guerrieri = guerrieri_Enemy;
                    Variabili.Barbari.PVP.Lancieri = picchieri_Enemy;
                }
                if (struttura == "Barbari_PVE")
                {
                    Server.Send(clientGuid, $"Log_Server|Guerrieri morti: {guerrieri_Morti_Att}/{player.Guerrieri_Barbari_PVE} Lancieri morti:  {lancieri_Morti_Att}/{player.Lancieri_Barbari_PVE}\r\n");
                    Server.Send(clientGuid, $"Log_Server|Gli arceri e le catapulte del giocatore hanno causato:");
                    Server.Send(clientGuid, $"Log_Server|Frecce utilizzate: {(arcieri * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte * Esercito.Unità.Catapulta.Componente_Lancio)}");
                    player.Guerrieri_Barbari_PVE = guerrieri_Enemy;
                    player.Lancieri_Barbari_PVE = picchieri_Enemy;
                }
                player.Esperienza += (guerrieri_Morti_Att * Esercito.EsercitoNemico.Guerriero.Esperienza) + (lancieri_Morti_Att * Esercito.EsercitoNemico.Lanciere.Esperienza);
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

                Server.Send(clientGuid2, $"Log_Server|Guerrieri morti: {guerrieri_Morti}/{player2.Guerrieri} Lancieri morti:  {lancieri_Morti}/{player2.Lancieri}\r\n");
                Server.Send(clientGuid2, $"Log_Server|Gli arceri e le catapulte del giocatore [{player2.Username}] hanno causato:");
                Server.Send(clientGuid2, $"Log_Server|Frecce utilizzate: {(arcieri_Enemy * Esercito.Unità.Arciere.Componente_Lancio) + (catapulte_Enemy * Esercito.Unità.Catapulta.Componente_Lancio)}");
                player.Esperienza += (guerrieri_Morti_Att * Esercito.Unità.Guerriero.Esperienza) + (lancieri_Morti_Att * Esercito.Unità.Lanciere.Esperienza);

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
                Server.Send(clientGuid, $"Log_Server|Guerrieri morti: {guerrieri_Morti}/{player.Guerrieri} Lancieri morti:  {lancieri_Morti}/{player.Lancieri}\r\n");
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
