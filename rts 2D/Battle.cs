using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static rts_2D.Variabili;

namespace rts_2D
{
    internal class Battle
    {
        static int assalto_Unità_Att = 0;
        static double danno_Strutture = 0;
        public static async Task<bool> Battaglia()
        {
            await Battaglia_Distanza("Campale"); //Pre battaglia, attaccano le unità a distanza ed i mezzi d'assedio

            int totale_Uomini_Temp = 0, totale_Uomini = 0;

            int guerrieri = Variabili.Esercito.Guerriero.Quantità;
            int picchieri = Variabili.Esercito.Lanciere.Quantità;
            int arcieri = Variabili.Esercito.Arciere.Quantità;
            int catapulte = Variabili.Esercito.Catapulta.Quantità;

            int guerrieri_Enemy = Variabili.EsercitoNemico.Guerriero.Quantità;
            int picchieri_Enemy = Variabili.EsercitoNemico.Lanciere.Quantità;
            int arcieri_Enemy = Variabili.EsercitoNemico.Arciere.Quantità;
            int catapulte_Enemy = Variabili.EsercitoNemico.Catapulta.Quantità;

            Variabili.tipi_Di_Unità = 0;
            Variabili.tipi_Di_Unità_Att = 0;
            //Cotrollo tipi di unità
            if (guerrieri > 0) Variabili.tipi_Di_Unità++;
            if (picchieri > 0) Variabili.tipi_Di_Unità++;
            if (arcieri > 0) Variabili.tipi_Di_Unità++;
            if (catapulte > 0) Variabili.tipi_Di_Unità++;

            if (guerrieri_Enemy > 0) Variabili.tipi_Di_Unità_Att++;
            if (picchieri_Enemy > 0) Variabili.tipi_Di_Unità_Att++;
            if (arcieri_Enemy > 0) Variabili.tipi_Di_Unità_Att++;
            if (catapulte_Enemy > 0) Variabili.tipi_Di_Unità_Att++;

            if (guerrieri + picchieri + arcieri + catapulte == 0)
                Variabili.tipi_Di_Unità = 1;
            if (guerrieri_Enemy + picchieri_Enemy + arcieri_Enemy + catapulte_Enemy == 0)
                Variabili.tipi_Di_Unità_Att = 1;

            // Calcolo del danno per il giocatore e il nemico
            double dannoInflittoDalNemico = CalcolareDanno_Invasore(arcieri_Enemy, catapulte_Enemy, guerrieri_Enemy, picchieri_Enemy) / Variabili.tipi_Di_Unità;
            double dannoInflitto = CalcolareDanno_Giocatore(arcieri, catapulte, guerrieri, picchieri) / Variabili.tipi_Di_Unità_Att;

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

            Form1.Log_Battaglia($"Danno inflitto dal nemico: {(dannoInflittoDalNemico * Variabili.tipi_Di_Unità).ToString("0.00")}");
            Form1.Log_Battaglia($"Danno inflitto dal giocatore: {(dannoInflitto * Variabili.tipi_Di_Unità_Att).ToString("0.00")}");

            Form1.Log_Battaglia($"Guerrieri: {guerrieri - guerrieri_Temp}\r\n Lancieri: {picchieri - picchieri_Temp}\r\n Arcieri: {arcieri - arcieri_Temp}\r\n Catapulte: {catapulte - catapulte_Temp}");
            Form1.Log_Battaglia($"Soldati persi dal giocatore:");

            Form1.Log_Battaglia($"Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp}\r\n Lancieri: {picchieri_Enemy - picchieri_Enemy_Temp}\r\n Arcieri: {arcieri_Enemy - arcieri_Enemy_Temp}\r\n Catapulte: {catapulte_Enemy - catapulte_Enemy_Temp}");
            Form1.Log_Battaglia($"Soldati persi dal nemico:");
            Form1.Log_Battaglia($"\r\nInvasione {Form1.Invasione_Ondata + 1} Completata");

            // Aggiornare le quantità delle unità
            Variabili.Esercito.Guerriero.Quantità = guerrieri_Temp;
            Variabili.Esercito.Lanciere.Quantità = picchieri_Temp;
            Variabili.Esercito.Arciere.Quantità = arcieri_Temp;
            Variabili.Esercito.Catapulta.Quantità = catapulte_Temp;

            Variabili.EsercitoNemico.Guerriero.Quantità = guerrieri_Enemy_Temp;
            Variabili.EsercitoNemico.Lanciere.Quantità = picchieri_Enemy_Temp;
            Variabili.EsercitoNemico.Arciere.Quantità = arcieri_Enemy_Temp;
            Variabili.EsercitoNemico.Catapulta.Quantità = catapulte_Enemy_Temp;

            totale_Uomini_Temp = guerrieri_Temp + picchieri_Temp + arcieri_Temp + catapulte_Temp;
            totale_Uomini = guerrieri + picchieri + arcieri + catapulte;

            if ((totale_Uomini_Temp < 48 || totale_Uomini < 48) && Form1.Invasione_Ondata > 5)
            {
                await Assedio_Mura();

                if (Variabili.Città.Mura.Salute == 0) await Assedio_Torre();
                if (Variabili.Città.Torre.Salute == 0) await Assedio_Castello();
            }
            return false;
        }
        public static async Task<bool> Assedio_Mura()
        {
            await Battaglia_Distanza("Mura");

            int guerrieri = Variabili.Città.Mura.Guerrieri;
            int picchieri = Variabili.Città.Mura.Lancieri;
            int arcieri = Variabili.Città.Mura.Arceri;
            int catapulte = Variabili.Città.Mura.Catapulte;

            int guerrieri_Enemy = Variabili.EsercitoNemico.Guerriero.Quantità;
            int picchieri_Enemy = Variabili.EsercitoNemico.Lanciere.Quantità;
            int arcieri_Enemy = Variabili.EsercitoNemico.Arciere.Quantità;
            int catapulte_Enemy = Variabili.EsercitoNemico.Catapulta.Quantità;

            Variabili.tipi_Di_Unità = 0;
            Variabili.tipi_Di_Unità_Att = 0;

            //Cotrollo tipi di unità
            if (guerrieri > 0) Variabili.tipi_Di_Unità++;
            if (picchieri > 0) Variabili.tipi_Di_Unità++;
            if (arcieri > 0) Variabili.tipi_Di_Unità++;
            if (catapulte > 0) Variabili.tipi_Di_Unità++;

            if (guerrieri_Enemy > 0) Variabili.tipi_Di_Unità_Att++;
            if (picchieri_Enemy > 0) Variabili.tipi_Di_Unità_Att++;
            if (arcieri_Enemy > 0) Variabili.tipi_Di_Unità_Att++;
            if (catapulte_Enemy > 0) Variabili.tipi_Di_Unità_Att++;

            if (guerrieri + picchieri + arcieri + catapulte == 0)
                Variabili.tipi_Di_Unità = 1;
            if (guerrieri_Enemy + picchieri_Enemy + arcieri_Enemy + catapulte_Enemy == 0)
                Variabili.tipi_Di_Unità_Att = 1;

            // Calcolo del danno per il giocatore e il nemico
            double dannoInflittoDalNemico = CalcolareDanno_Invasore(arcieri_Enemy, catapulte_Enemy, guerrieri_Enemy, picchieri_Enemy) / Variabili.tipi_Di_Unità;
            double dannoInflitto = CalcolareDanno_Giocatore(arcieri, catapulte, guerrieri, picchieri) / Variabili.tipi_Di_Unità_Att;

            // Applicare il danno alle unità del giocatore
            int guerrieri_Temp = RidurreNumeroSoldati_2(guerrieri, dannoInflittoDalNemico, Variabili.Esercito.Guerriero.Difesa * guerrieri, Variabili.Esercito.Guerriero.Salute, "Mura");
            int picchieri_Temp = RidurreNumeroSoldati_2(picchieri, dannoInflittoDalNemico, Variabili.Esercito.Lanciere.Difesa * picchieri, Variabili.Esercito.Lanciere.Salute, "Mura");
            int arcieri_Temp = RidurreNumeroSoldati_2(arcieri, dannoInflittoDalNemico * 0.70, Variabili.Esercito.Arciere.Difesa * arcieri, Variabili.Esercito.Arciere.Salute, "Mura");
            int catapulte_Temp = RidurreNumeroSoldati_2(catapulte, dannoInflittoDalNemico, Variabili.Esercito.Catapulta.Difesa * catapulte, Variabili.Esercito.Catapulta.Salute, "Mura");

            // Applicare il danno alle unità nemiche
            int guerrieri_Enemy_Temp = RidurreNumeroSoldati(guerrieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Guerriero.Difesa * guerrieri_Enemy, Variabili.EsercitoNemico.Guerriero.Salute);
            int picchieri_Enemy_Temp = RidurreNumeroSoldati(picchieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Lanciere.Difesa * picchieri_Enemy, Variabili.EsercitoNemico.Lanciere.Salute);
            int arcieri_Enemy_Temp = RidurreNumeroSoldati(arcieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Arciere.Difesa * arcieri_Enemy, Variabili.EsercitoNemico.Arciere.Salute);
            int catapulte_Enemy_Temp = RidurreNumeroSoldati(catapulte_Enemy, dannoInflitto, Variabili.EsercitoNemico.Catapulta.Difesa * catapulte_Enemy, Variabili.EsercitoNemico.Catapulta.Salute);

            Form1.Log_Battaglia($"Danno inflitto dal nemico: {(dannoInflittoDalNemico * Variabili.tipi_Di_Unità).ToString("0.00")}");
            Form1.Log_Battaglia($"Danno inflitto dal giocatore: {(dannoInflitto * Variabili.tipi_Di_Unità_Att).ToString("0.00")}");

            Form1.Log_Battaglia($"Guerrieri: {guerrieri - guerrieri_Temp}\r\n Lancieri: {picchieri - picchieri_Temp}\r\n Arcieri: {arcieri - arcieri_Temp}\r\n Catapulte: {catapulte - catapulte_Temp}");
            Form1.Log_Battaglia($"Soldati persi dal giocatore:");

            Form1.Log_Battaglia($"Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp}\r\n Lancieri: {picchieri_Enemy - picchieri_Enemy_Temp}\r\n Arcieri: {arcieri_Enemy - arcieri_Enemy_Temp}\r\n Catapulte: {catapulte_Enemy - catapulte_Enemy_Temp}");
            Form1.Log_Battaglia($"Soldati persi dal nemico:");
            Form1.Log_Battaglia($"\r\nAssalto alle mura terminato");

            // Aggiornare le quantità delle unità
            Variabili.Città.Mura.Guerrieri = guerrieri_Temp;
            Variabili.Città.Mura.Lancieri = picchieri_Temp;
            Variabili.Città.Mura.Arceri = arcieri_Temp;
            Variabili.Città.Mura.Catapulte = catapulte_Temp;

            Variabili.EsercitoNemico.Guerriero.Quantità = guerrieri_Enemy_Temp;
            Variabili.EsercitoNemico.Lanciere.Quantità = picchieri_Enemy_Temp;
            Variabili.EsercitoNemico.Arciere.Quantità = arcieri_Enemy_Temp;
            Variabili.EsercitoNemico.Catapulta.Quantità = catapulte_Enemy_Temp;
            return true;
        }
        public static async Task<bool> Assedio_Torre()
        {
            await Battaglia_Distanza("Torre");

            int guerrieri = Variabili.Città.Torre.Guerrieri;
            int picchieri = Variabili.Città.Torre.Lancieri;
            int arcieri = Variabili.Città.Torre.Arceri;
            int catapulte = Variabili.Città.Torre.Catapulte;

            int guerrieri_Enemy = Variabili.EsercitoNemico.Guerriero.Quantità;
            int picchieri_Enemy = Variabili.EsercitoNemico.Lanciere.Quantità;
            int arcieri_Enemy = Variabili.EsercitoNemico.Arciere.Quantità;
            int catapulte_Enemy = Variabili.EsercitoNemico.Catapulta.Quantità;

            Variabili.tipi_Di_Unità = 0;
            Variabili.tipi_Di_Unità_Att = 0;

            //Cotrollo tipi di unità
            if (guerrieri > 0) Variabili.tipi_Di_Unità++;
            if (picchieri > 0) Variabili.tipi_Di_Unità++;
            if (arcieri > 0) Variabili.tipi_Di_Unità++;
            if (catapulte > 0) Variabili.tipi_Di_Unità++;

            if (guerrieri_Enemy > 0) Variabili.tipi_Di_Unità_Att++;
            if (picchieri_Enemy > 0) Variabili.tipi_Di_Unità_Att++;
            if (arcieri_Enemy > 0) Variabili.tipi_Di_Unità_Att++;
            if (catapulte_Enemy > 0) Variabili.tipi_Di_Unità_Att++;

            if (guerrieri + picchieri + arcieri + catapulte == 0)
                Variabili.tipi_Di_Unità = 1;
            if (guerrieri_Enemy + picchieri_Enemy + arcieri_Enemy + catapulte_Enemy == 0)
                Variabili.tipi_Di_Unità_Att = 1;

            // Calcolo del danno per il giocatore e il nemico
            double dannoInflittoDalNemico = CalcolareDanno_Invasore(arcieri_Enemy, catapulte_Enemy, guerrieri_Enemy, picchieri_Enemy) / Variabili.tipi_Di_Unità;
            double dannoInflitto = CalcolareDanno_Giocatore(arcieri, catapulte, guerrieri, picchieri) / Variabili.tipi_Di_Unità_Att;

            // Applicare il danno alle unità del giocatore
            int guerrieri_Temp = RidurreNumeroSoldati_2(guerrieri, dannoInflittoDalNemico, Variabili.Esercito.Guerriero.Difesa * guerrieri, Variabili.Esercito.Guerriero.Salute, "Torre");
            int picchieri_Temp = RidurreNumeroSoldati_2(picchieri, dannoInflittoDalNemico, Variabili.Esercito.Lanciere.Difesa * picchieri, Variabili.Esercito.Lanciere.Salute, "Torre");
            int arcieri_Temp = RidurreNumeroSoldati_2(arcieri, dannoInflittoDalNemico * 0.70, Variabili.Esercito.Arciere.Difesa * arcieri, Variabili.Esercito.Arciere.Salute, "Torre");
            int catapulte_Temp = RidurreNumeroSoldati_2(catapulte, dannoInflittoDalNemico, Variabili.Esercito.Catapulta.Difesa * catapulte, Variabili.Esercito.Catapulta.Salute, "Torre");

            // Applicare il danno alle unità nemiche
            int guerrieri_Enemy_Temp = RidurreNumeroSoldati(guerrieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Guerriero.Difesa * guerrieri_Enemy, Variabili.EsercitoNemico.Guerriero.Salute);
            int picchieri_Enemy_Temp = RidurreNumeroSoldati(picchieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Lanciere.Difesa * picchieri_Enemy, Variabili.EsercitoNemico.Lanciere.Salute);
            int arcieri_Enemy_Temp = RidurreNumeroSoldati(arcieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Arciere.Difesa * arcieri_Enemy, Variabili.EsercitoNemico.Arciere.Salute);
            int catapulte_Enemy_Temp = RidurreNumeroSoldati(catapulte_Enemy, dannoInflitto, Variabili.EsercitoNemico.Catapulta.Difesa * catapulte_Enemy, Variabili.EsercitoNemico.Catapulta.Salute);

            Form1.Log_Battaglia($"Danno inflitto dal nemico: {(dannoInflittoDalNemico * Variabili.tipi_Di_Unità).ToString("0.00")}");
            Form1.Log_Battaglia($"Danno inflitto dal giocatore: {(dannoInflitto * Variabili.tipi_Di_Unità_Att).ToString("0.00")}");

            Form1.Log_Battaglia($"Guerrieri: {guerrieri - guerrieri_Temp}\r\n Lancieri: {picchieri - picchieri_Temp} \r\n Arcieri: {arcieri - arcieri_Temp} \r\n Catapulte: {catapulte - catapulte_Temp}");
            Form1.Log_Battaglia($"Soldati persi dal giocatore:");

            Form1.Log_Battaglia($"Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp}\r\n Lancieri: {picchieri_Enemy - picchieri_Enemy_Temp} \r\n Arcieri: {arcieri_Enemy - arcieri_Enemy_Temp} \r\n Catapulte: {catapulte_Enemy - catapulte_Enemy_Temp}");
            Form1.Log_Battaglia($"Soldati persi dal nemico:");
            Form1.Log_Battaglia($"\r\nAssalto alla torre terminato");

            // Aggiornare le quantità delle unità
            Variabili.Città.Torre.Guerrieri = guerrieri_Temp;
            Variabili.Città.Torre.Lancieri = picchieri_Temp;
            Variabili.Città.Torre.Arceri = arcieri_Temp;
            Variabili.Città.Torre.Catapulte = catapulte_Temp;

            Variabili.EsercitoNemico.Guerriero.Quantità = guerrieri_Enemy_Temp;
            Variabili.EsercitoNemico.Lanciere.Quantità = picchieri_Enemy_Temp;
            Variabili.EsercitoNemico.Arciere.Quantità = arcieri_Enemy_Temp;
            Variabili.EsercitoNemico.Catapulta.Quantità = catapulte_Enemy_Temp;
            return true;
        }
        public static async Task<bool> Assedio_Castello()
        {
            await Battaglia_Distanza("Castello");

            int guerrieri = Variabili.Città.Castello.Guerrieri;
            int picchieri = Variabili.Città.Castello.Lancieri;
            int arcieri = Variabili.Città.Castello.Arceri;
            int catapulte = Variabili.Città.Castello.Catapulte;

            int guerrieri_Enemy = Variabili.EsercitoNemico.Guerriero.Quantità;
            int picchieri_Enemy = Variabili.EsercitoNemico.Lanciere.Quantità;
            int arcieri_Enemy = Variabili.EsercitoNemico.Arciere.Quantità;
            int catapulte_Enemy = Variabili.EsercitoNemico.Catapulta.Quantità;

            Variabili.tipi_Di_Unità = 0;
            Variabili.tipi_Di_Unità_Att = 0;

            //Cotrollo tipi di unità
            if (guerrieri > 0) Variabili.tipi_Di_Unità++;
            if (picchieri > 0) Variabili.tipi_Di_Unità++;
            if (arcieri > 0) Variabili.tipi_Di_Unità++;
            if (catapulte > 0) Variabili.tipi_Di_Unità++;

            if (guerrieri_Enemy > 0) Variabili.tipi_Di_Unità_Att++;
            if (picchieri_Enemy > 0) Variabili.tipi_Di_Unità_Att++;
            if (arcieri_Enemy > 0) Variabili.tipi_Di_Unità_Att++;
            if (catapulte_Enemy > 0) Variabili.tipi_Di_Unità_Att++;

            if (guerrieri + picchieri + arcieri + catapulte == 0)
                Variabili.tipi_Di_Unità = 1;
            if (guerrieri_Enemy + picchieri_Enemy + arcieri_Enemy + catapulte_Enemy == 0)
                Variabili.tipi_Di_Unità_Att = 1;

            // Calcolo del danno per il giocatore e il nemico
            double dannoInflittoDalNemico = CalcolareDanno_Invasore(arcieri_Enemy, catapulte_Enemy, guerrieri_Enemy, picchieri_Enemy) / Variabili.tipi_Di_Unità;
            double dannoInflitto = CalcolareDanno_Giocatore(arcieri, catapulte, guerrieri, picchieri) / Variabili.tipi_Di_Unità_Att;

            // Applicare il danno alle unità del giocatore
            int guerrieri_Temp = RidurreNumeroSoldati_2(guerrieri, dannoInflittoDalNemico, Variabili.Esercito.Guerriero.Difesa * guerrieri, Variabili.Esercito.Guerriero.Salute, "Castello");
            int picchieri_Temp = RidurreNumeroSoldati_2(picchieri, dannoInflittoDalNemico, Variabili.Esercito.Lanciere.Difesa * picchieri, Variabili.Esercito.Lanciere.Salute, "Castello");
            int arcieri_Temp = RidurreNumeroSoldati_2(arcieri, dannoInflittoDalNemico * 0.70, Variabili.Esercito.Arciere.Difesa * arcieri, Variabili.Esercito.Arciere.Salute, "Castello");
            int catapulte_Temp = RidurreNumeroSoldati_2(catapulte, dannoInflittoDalNemico, Variabili.Esercito.Catapulta.Difesa * catapulte, Variabili.Esercito.Catapulta.Salute, "Castello");

            // Applicare il danno alle unità nemiche
            int guerrieri_Enemy_Temp = RidurreNumeroSoldati(guerrieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Guerriero.Difesa * guerrieri_Enemy, Variabili.EsercitoNemico.Guerriero.Salute);
            int picchieri_Enemy_Temp = RidurreNumeroSoldati(picchieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Lanciere.Difesa * picchieri_Enemy, Variabili.EsercitoNemico.Lanciere.Salute);
            int arcieri_Enemy_Temp = RidurreNumeroSoldati(arcieri_Enemy, dannoInflitto, Variabili.EsercitoNemico.Arciere.Difesa * arcieri_Enemy, Variabili.EsercitoNemico.Arciere.Salute);
            int catapulte_Enemy_Temp = RidurreNumeroSoldati(catapulte_Enemy, dannoInflitto, Variabili.EsercitoNemico.Catapulta.Difesa * catapulte_Enemy, Variabili.EsercitoNemico.Catapulta.Salute);

            Form1.Log_Battaglia($"Danno inflitto dal nemico: {(dannoInflittoDalNemico * Variabili.tipi_Di_Unità).ToString("0.00")}");
            Form1.Log_Battaglia($"Danno inflitto dal giocatore: {(dannoInflitto * Variabili.tipi_Di_Unità_Att).ToString("0.00")}");

            Form1.Log_Battaglia($"Guerrieri: {guerrieri - guerrieri_Temp}\r\n Lancieri: {picchieri - picchieri_Temp} \r\n Arcieri: {arcieri - arcieri_Temp} \r\n Catapulte: {catapulte - catapulte_Temp}");
            Form1.Log_Battaglia($"Soldati persi dal giocatore:");

            Form1.Log_Battaglia($"Guerrieri: {guerrieri_Enemy - guerrieri_Enemy_Temp}\r\n Lancieri: {picchieri_Enemy - picchieri_Enemy_Temp} \r\n Arcieri: {arcieri_Enemy - arcieri_Enemy_Temp} \r\n Catapulte: {catapulte_Enemy - catapulte_Enemy_Temp}");
            Form1.Log_Battaglia($"Soldati persi dal nemico:");
            Form1.Log_Battaglia($"\r\nAssalto alla torre terminato");

            // Aggiornare le quantità delle unità
            Variabili.Città.Castello.Guerrieri = guerrieri_Temp;
            Variabili.Città.Castello.Lancieri = picchieri_Temp;
            Variabili.Città.Castello.Arceri = arcieri_Temp;
            Variabili.Città.Castello.Catapulte = catapulte_Temp;

            Variabili.EsercitoNemico.Guerriero.Quantità = guerrieri_Enemy_Temp;
            Variabili.EsercitoNemico.Lanciere.Quantità = picchieri_Enemy_Temp;
            Variabili.EsercitoNemico.Arciere.Quantità = arcieri_Enemy_Temp;
            Variabili.EsercitoNemico.Catapulta.Quantità = catapulte_Enemy_Temp;
            return true;
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
        public static int RidurreNumeroSoldati(int numeroSoldati, double danno, double difesa, double salutePerSoldato)
        {
            // Calcolare il danno effettivo tenendo conto della difesa
            double dannoEffettivo = danno - difesa;
            dannoEffettivo = Math.Max(0, dannoEffettivo); // Assicurarsi che il danno non sia negativo

            int soldatiPersi = Convert.ToInt32(dannoEffettivo / salutePerSoldato);
            numeroSoldati -= soldatiPersi;
            return numeroSoldati < 0 ? 0 : numeroSoldati;
        }
        public static int RidurreNumeroSoldati_2(int numeroSoldati, double danno, double difesa, double salutePerSoldato, string struttura)
        {
            // Calcolare il danno effettivo tenendo conto della difesa
            double dannoEffettivo = danno - difesa;
            double Difesa_Rimasta = 0, Salute_Rimasta = 0;
            dannoEffettivo = Math.Max(0, dannoEffettivo); // Assicurarsi che il danno non sia negativo

            danno_Strutture =+ dannoEffettivo;
            if (struttura == "Mura")
            {
                Difesa_Rimasta = Variabili.Città.Mura.Difesa - (dannoEffettivo * 0.40);
                Salute_Rimasta = Variabili.Città.Mura.Salute - (dannoEffettivo * 0.20);

                if (Difesa_Rimasta > 0) Variabili.Città.Mura.Difesa = Convert.ToInt32(Difesa_Rimasta);
                else Variabili.Città.Mura.Difesa = 0;

                if (Salute_Rimasta > 0) Variabili.Città.Mura.Salute = Convert.ToInt32(Salute_Rimasta);
                else Variabili.Città.Mura.Salute = 0;

                if (assalto_Unità_Att >= Variabili.tipi_Di_Unità)
                {
                    Form1.Log_Battaglia($"Le difese delle mura è diminuita di: {(danno_Strutture * 0.40).ToString("0")}");
                    Form1.Log_Battaglia($"La salute delle mura è dimiuita di: {(danno_Strutture * 0.20).ToString("0")}");
                    danno_Strutture = 0;
                    assalto_Unità_Att = 0;
                }
                assalto_Unità_Att++;
            }
            if (struttura == "Torre")
            {
                Difesa_Rimasta = Variabili.Città.Torre.Difesa - (dannoEffettivo * 0.430);
                Salute_Rimasta = Variabili.Città.Torre.Salute - (dannoEffettivo * 0.220);

                if (Difesa_Rimasta > 0) Variabili.Città.Torre.Difesa = Convert.ToInt32(Difesa_Rimasta);
                else Variabili.Città.Torre.Difesa = 0;

                if (Salute_Rimasta > 0) Variabili.Città.Torre.Salute = Convert.ToInt32(Salute_Rimasta);
                else Variabili.Città.Torre.Salute = 0;

                if (assalto_Unità_Att == Variabili.tipi_Di_Unità - 1)
                {
                    Form1.Log_Battaglia($"Le difese delle torre è stata ridotta di: {(danno_Strutture * 0.430).ToString("0.00")}");
                    Form1.Log_Battaglia($"La salute delle torre è stata ridotta di: {(danno_Strutture * 0.220).ToString("0.00")}");
                    danno_Strutture = 0;
                    assalto_Unità_Att = 0;
                }
                assalto_Unità_Att++;
            }
            if (struttura == "Castello")
            {
                Difesa_Rimasta = Variabili.Città.Castello.Difesa - (dannoEffettivo * 0.45);
                Salute_Rimasta = Variabili.Città.Castello.Salute - (dannoEffettivo * 0.25);

                if (Difesa_Rimasta > 0) Variabili.Città.Castello.Difesa = Convert.ToInt32(Difesa_Rimasta);
                else Variabili.Città.Castello.Difesa = 0;

                if (Salute_Rimasta > 0) Variabili.Città.Castello.Salute = Convert.ToInt32(Salute_Rimasta);
                else Variabili.Città.Castello.Salute = 0;

                if (assalto_Unità_Att == Variabili.tipi_Di_Unità - 1)
                {
                    Form1.Log_Battaglia($"Le difese delle castello è stata ridotta di: {(danno_Strutture * 0.455).ToString("0.00")}");
                    Form1.Log_Battaglia($"La salute delle castello è stata ridotta di: {(danno_Strutture * 0.245).ToString("0.00")}");
                    danno_Strutture = 0;
                    assalto_Unità_Att = 0;
                }
                assalto_Unità_Att++;
            }

            int soldatiPersi = Convert.ToInt32(dannoEffettivo * 0.40 / salutePerSoldato);
            numeroSoldati -= soldatiPersi;
            return numeroSoldati < 0 ? 0 : numeroSoldati;
        }

        public static async Task<bool> Battaglia_Distanza(string struttura)
        {
            int guerrieri_Morti = 0, lancieri_Morti = 0, guerrieri_Morti_Att = 0, lancieri_Morti_Att = 0;
            int guerrieri   = 0, picchieri   = 0,  arcieri     = 0, catapulte   = 0;
            #region Caricamento Uomini a seconda della battaglia
            if (struttura == "Campale")
            {
                guerrieri = Variabili.Esercito.Guerriero.Quantità;
                picchieri = Variabili.Esercito.Lanciere.Quantità;
                arcieri   = Variabili.Esercito.Arciere.Quantità;
                catapulte = Variabili.Esercito.Catapulta.Quantità;
            }
            if (struttura == "Mura")
            {
                guerrieri = Variabili.Città.Mura.Guerrieri;
                picchieri = Variabili.Città.Mura.Lancieri;
                arcieri   = Variabili.Città.Mura.Arceri;
                catapulte = Variabili.Città.Mura.Catapulte;
            }
            if (struttura == "Torre")
            {
                guerrieri = Variabili.Città.Torre.Guerrieri;
                picchieri = Variabili.Città.Torre.Lancieri;
                arcieri   = Variabili.Città.Torre.Arceri;
                catapulte = Variabili.Città.Torre.Catapulte;
            }
            if (struttura == "Castello")
            {
                guerrieri = Variabili.Città.Castello.Guerrieri;
                picchieri = Variabili.Città.Castello.Lancieri;
                arcieri   = Variabili.Città.Castello.Arceri;
                catapulte = Variabili.Città.Castello.Catapulte;
            }
            #endregion
            int guerrieri_Enemy = Variabili.EsercitoNemico.Guerriero.Quantità;
            int picchieri_Enemy = Variabili.EsercitoNemico.Lanciere.Quantità;
            int arcieri_Enemy   = Variabili.EsercitoNemico.Arciere.Quantità;
            int catapulte_Enemy = Variabili.EsercitoNemico.Catapulta.Quantità;

            int arcieri_Temp = arcieri * 3 / 4;
            int catapulte_Temp = catapulte * 3 / 4;

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
                        lancieri_Morti_Att = attacco  / 3; //Danno 1/3 contro lancieri
                    }else
                    {
                        guerrieri_Morti_Att = attacco  / 3; //Danno 2/3 contro guerrieri
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
                
                Variabili.EsercitoNemico.Guerriero.Quantità = guerrieri_Enemy;
                Variabili.EsercitoNemico.Lanciere.Quantità = picchieri_Enemy;
            }
            Form1.Log_Battaglia($"Guerrieri morti: {guerrieri_Morti_Att} Lancieri morti:  {lancieri_Morti_Att}");
            Form1.Log_Battaglia($"Gli arceri e le catapulte in difesa hanno causato:");

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

                if (struttura == "Campale")
                {
                    Esercito.Guerriero.Quantità = guerrieri;
                    Esercito.Lanciere.Quantità = picchieri;
                }
                if (struttura == "Mura")
                {
                    Città.Mura.Guerrieri = guerrieri;
                    Città.Mura.Lancieri = picchieri;
                }
                if (struttura == "Torre")
                {
                    Città.Torre.Guerrieri = guerrieri;
                    Città.Torre.Lancieri = picchieri;
                }
                if (struttura == "Castello")
                {
                    Città.Castello.Guerrieri = guerrieri;
                    Città.Castello.Lancieri = picchieri;
                }
            }

            Form1.Log_Battaglia($"Guerrieri morti: {guerrieri_Morti} Lancieri morti:  {lancieri_Morti}");
            Form1.Log_Battaglia($"Gli arceri e le catapulte attaccanti hanno causato:");
            return true;
        } // Arcieri e Mezzi d'assedio attaccano prima della battaglia

    }
}
