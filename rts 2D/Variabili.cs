using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rts_2D
{
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
    internal class Variabili
    {
        public static double Cibo        = 0;
        public static double Legno       = 0;
        public static double Pietra      = 0;
        public static double Ferro       = 0;
        public static double Oro         = 0;
        public static double Popolazione = 0;
        public static double Popolazione_Up = 0.21;

        public static int fattoria = 0;
        public static int segheria = 0;
        public static int cava_Pietra = 0;
        public static int miniera_Ferro = 0;
        public static int miniera_Oro = 0;

        public static int spade = 0;
        public static int lance = 0;
        public static int archi = 0;
        public static int scudi = 0;
        public static int armature = 0;

        public static int tempo_Costruzione = 0;
        public static int tempo_Reclutamento = 0;
        public static double forza_Esercito = 0;
        public static double forza_Esercito_Att = 0;

        public static int tipi_Di_Unità = 0;
        public static int tipi_Di_Unità_Att = 0;

        public static int timer_Invasione = timer_Invasione_Set;
        public static int timer_Invasione_Set = 50 * 1;

        public static double ProgressColorMax = 0.66;
        public static double ProgressColorMin = 0.33;

        public static int token = 0;

        public static string form_Spostamento_truppe = "Nothing";

        // Costo costruzioni

        public class Coda
        {
            public int quantità { get; set; }

            public static Coda Fattoria = new Coda
            {
                quantità = 0
            };
            public static Coda Segheria = new Coda
            {
                quantità = 0
            };
            public static Coda CavaPietra = new Coda
            {
                quantità = 0
            };
            public static Coda MinieraFerro = new Coda
            {
                quantità = 0
            };
            public static Coda MinieraOro = new Coda
            {
                quantità = 0
            };

            public static Coda Guerriero = new Coda
            {
                quantità = 0
            };

            public static Coda Lanciere = new Coda
            {
                quantità = 0
            };

            public static Coda Arciere = new Coda
            {
                quantità = 0
            };
            public static Coda Catapulta = new Coda
            {
                quantità = 0
            };
        }
        public class CostoCostruzione
        {
            public int Cibo { get; set; }
            public int Legno { get; set; }
            public int Pietra { get; set; }
            public int Ferro { get; set; }
            public int Oro { get; set; }
            public double Produzione { get; set; }
            public double TempoCostruzione { get; set; }

            // Costruttore per inizializzare i costi
            public static CostoCostruzione Fattoria = new CostoCostruzione
            {
                Cibo    = 100,
                Legno   = 100,
                Pietra  = 100,
                Ferro   = 100,
                Oro     = 100,
                Produzione = 1.62,
                TempoCostruzione = 24
            };
            public static CostoCostruzione Segheria = new CostoCostruzione
            {
                Cibo    = 175,
                Legno   = 175,
                Pietra  = 175,
                Ferro   = 175,
                Oro     = 175,
                Produzione = 1.46,
                TempoCostruzione = 27
            };
            public static CostoCostruzione CavaPietra = new CostoCostruzione
            {
                Cibo    = 250,
                Legno   = 250,
                Pietra  = 250,
                Ferro   = 250,
                Oro     = 250,
                Produzione = 1.22,
                TempoCostruzione = 33
            };
            public static CostoCostruzione MinieraFerro = new CostoCostruzione
            {
                Cibo    = 325,
                Legno   = 325,
                Pietra  = 325,
                Ferro   = 325,
                Oro     = 325,
                Produzione = 1.04,
                TempoCostruzione = 38
            };
            public static CostoCostruzione MinieraOro = new CostoCostruzione
            {
                Cibo    = 400,
                Legno   = 400,
                Pietra  = 400,
                Ferro   = 400,
                Oro     = 400,
                Produzione = 0.91,
                TempoCostruzione = 46
            };
        }
        public class CostoReclutamento
        {
            public int Spade { get; set; }
            public int Lance { get; set; }
            public int Archi { get; set; }
            public int Scudi { get; set; }
            public int Armature { get; set; }
            public int Cibo { get; set; }
            public int Legno { get; set; }
            public int Pietra { get; set; }
            public int Ferro { get; set; }
            public int Oro { get; set; }
            public double TempoReclutamento { get; set; }
            public int Popolazione { get; set; }

            // Costruttore per inizializzare i costi
            public static CostoReclutamento Guerriero = new CostoReclutamento
            {
                Spade       = 1,
                Scudi       = 0,
                Armature    = 1,

                Cibo        = 89,
                Legno       = 43,
                Pietra      = 12,
                Ferro       = 82,
                Oro         = 32,
                TempoReclutamento = 18, //55
                Popolazione = 1
            };
            public static CostoReclutamento Lanciere = new CostoReclutamento
            {
                Spade       = 0,
                Lance       = 1,
                Archi       = 0,
                Scudi       = 1,
                Armature    = 1,

                Cibo        = 164,
                Legno       = 92,
                Pietra      = 28,
                Ferro       = 132,
                Oro         = 81,
                TempoReclutamento = 23,
                Popolazione = 1
            };
            public static CostoReclutamento Arciere = new CostoReclutamento
            {
                Spade       = 0,
                Lance       = 0,
                Archi       = 1,
                Scudi       = 1,
                Armature    = 1,

                Cibo        = 219,
                Legno       = 194,
                Pietra      = 123,
                Ferro       = 183,
                Oro         = 162,
                TempoReclutamento = 31,
                Popolazione = 1
            };
            public static CostoReclutamento Catapulta = new CostoReclutamento
            {
                Spade       = 3,
                Lance       = 2,
                Archi       = 0,
                Scudi       = 0,
                Armature    = 5,

                Cibo        = 311,
                Legno       = 327,
                Pietra      = 329,
                Ferro       = 247,
                Oro         = 256,
                TempoReclutamento = 60,
                Popolazione = 5
            };
        }
        public class Ricerca
        {
            public int Cibo { get; set; }
            public int Legno { get; set; }
            public int Pietra { get; set; }
            public int Ferro { get; set; }
            public int Oro { get; set; }

            public static Ricerca Sblocco_Ricerca = new Ricerca
            {
                Cibo = 9000,
                Legno = 8000,
                Pietra = 7000,
                Ferro = 6000,
                Oro = 5000
            };
            public static Ricerca Sblocco_Invasioni = new Ricerca
            {
                Cibo = 7000,
                Legno = 6000,
                Pietra = 5000,
                Ferro = 4000,
                Oro = 3500
            };

            public static Ricerca Produzione_I = new Ricerca
            {
                Cibo = 4000,
                Legno = 3500,
                Pietra = 3000,
                Ferro = 2500,
                Oro = 2000
            };
            public static Ricerca Produzione_II = new Ricerca
            {
                Cibo = 5500,
                Legno = 5000,
                Pietra = 4500,
                Ferro = 4000,
                Oro = 3500
            };
            public static Ricerca Produzione_III = new Ricerca
            {
                Cibo = 8000,
                Legno = 7500,
                Pietra = 7000,
                Ferro = 6500,
                Oro = 6000
            };
            public static Ricerca Produzione_IV = new Ricerca
            {
                Cibo = 12500,
                Legno = 11000,
                Pietra = 10500,
                Ferro = 9500,
                Oro = 8000
            };
            public static Ricerca Produzione_V = new Ricerca
            {
                Cibo = 16000,
                Legno = 15500,
                Pietra = 14000,
                Ferro = 13500,
                Oro = 13000
            };
            public static Ricerca Costruzione_I = new Ricerca
            {
                Cibo = 4000,
                Legno = 3500,
                Pietra = 3000,
                Ferro = 2500,
                Oro = 2000
            };
            public static Ricerca Costruzione_II = new Ricerca
            {
                Cibo = 5500,
                Legno = 5000,
                Pietra = 4500,
                Ferro = 4000,
                Oro = 3500
            };
            public static Ricerca Costruzione_III = new Ricerca
            {
                Cibo = 8000,
                Legno = 7500,
                Pietra = 7000,
                Ferro = 6500,
                Oro = 6000
            };
            public static Ricerca Costruzione_IV = new Ricerca
            {
                Cibo = 12500,
                Legno = 11000,
                Pietra = 10500,
                Ferro = 9500,
                Oro = 8000
            };
            public static Ricerca Costruzione_V = new Ricerca
            {
                Cibo = 16000,
                Legno = 15500,
                Pietra = 14000,
                Ferro = 13500,
                Oro = 13000
            };
            public static Ricerca Popolazione_I = new Ricerca
            {
                Cibo = 4000,
                Legno = 3500,
                Pietra = 3000,
                Ferro = 2500,
                Oro = 2000
            };
            public static Ricerca Popolazione_II = new Ricerca
            {
                Cibo = 5500,
                Legno = 5000,
                Pietra = 4500,
                Ferro = 4000,
                Oro = 3500
            };
            public static Ricerca Popolazione_III = new Ricerca
            {
                Cibo = 8000,
                Legno = 7500,
                Pietra = 7000,
                Ferro = 6500,
                Oro = 6000
            };
            public static Ricerca Reclutamento_I = new Ricerca
            {
                Cibo = 4000,
                Legno = 3500,
                Pietra = 3000,
                Ferro = 2500,
                Oro = 2000
            };
            public static Ricerca Reclutamento_II = new Ricerca
            {
                Cibo = 5500,
                Legno = 5000,
                Pietra = 4500,
                Ferro = 4000,
                Oro = 3500
            };
            public static Ricerca Reclutamento_III = new Ricerca
            {
                Cibo = 8000,
                Legno = 7500,
                Pietra = 7000,
                Ferro = 6500,
                Oro = 6000
            };
            public static Ricerca Reclutamento_IV = new Ricerca
            {
                Cibo = 12500,
                Legno = 11000,
                Pietra = 10500,
                Ferro = 9500,
                Oro = 8000
            };
            public static Ricerca Reclutamento_V = new Ricerca
            {
                Cibo = 16000,
                Legno = 15500,
                Pietra = 14000,
                Ferro = 13500,
                Oro = 13000
            };
            public static Ricerca Attacco_I = new Ricerca
            {
                Cibo = 5000,
                Legno = 4500,
                Pietra = 4000,
                Ferro = 3500,
                Oro = 3000
            };
            public static Ricerca Attacco_II = new Ricerca
            {
                Cibo = 6500,
                Legno = 6000,
                Pietra = 5500,
                Ferro = 5000,
                Oro = 4500
            };
            public static Ricerca Attacco_III = new Ricerca
            {
                Cibo = 9000,
                Legno = 8500,
                Pietra = 8000,
                Ferro = 7500,
                Oro = 7000
            };
            public static Ricerca Difesa_I = new Ricerca
            {
                Cibo = 5000,
                Legno = 4500,
                Pietra = 4000,
                Ferro = 3500,
                Oro = 3000
            };
            public static Ricerca Difesa_II = new Ricerca
            {
                Cibo = 6500,
                Legno = 6000,
                Pietra = 5500,
                Ferro = 5000,
                Oro = 4500
            };
            public static Ricerca Difesa_III = new Ricerca
            {
                Cibo = 9000,
                Legno = 8500,
                Pietra = 8000,
                Ferro = 7500,
                Oro = 7000
            };
            public static Ricerca Salute_I = new Ricerca
            {
                Cibo = 5000,
                Legno = 4500,
                Pietra = 4000,
                Ferro = 3500,
                Oro = 3000
            };
            public static Ricerca Salute_II = new Ricerca
            {
                Cibo = 6500,
                Legno = 6000,
                Pietra = 5500,
                Ferro = 5000,
                Oro = 4500
            };
            public static Ricerca Salute_III = new Ricerca
            {
                Cibo = 9000,
                Legno = 8500,
                Pietra = 8000,
                Ferro = 7500,
                Oro = 7000
            };
            public static Ricerca Città_Salute_I = new Ricerca
            {
                Cibo = 5000,
                Legno = 4500,
                Pietra = 4000,
                Ferro = 3500,
                Oro = 3000
            };
            public static Ricerca Città_Salute_II = new Ricerca
            {
                Cibo = 6500,
                Legno = 6000,
                Pietra = 5500,
                Ferro = 5000,
                Oro = 4500
            };
            public static Ricerca Città_Salute_III = new Ricerca
            {
                Cibo = 9000,
                Legno = 8500,
                Pietra = 8000,
                Ferro = 7500,
                Oro = 7000
            };
            public static Ricerca Città_Difesa_I = new Ricerca
            {
                Cibo = 5000,
                Legno = 4500,
                Pietra = 4000,
                Ferro = 3500,
                Oro = 3000
            };
            public static Ricerca Città_Difesa_II = new Ricerca
            {
                Cibo = 6500,
                Legno = 6000,
                Pietra = 5500,
                Ferro = 5000,
                Oro = 4500
            };
            public static Ricerca Città_Difesa_III = new Ricerca
            {
                Cibo = 9000,
                Legno = 8500,
                Pietra = 8000,
                Ferro = 7500,
                Oro = 7000
            };
            public static Ricerca Città_Guarnigione_I = new Ricerca
            {
                Cibo = 5000,
                Legno = 4500,
                Pietra = 4000,
                Ferro = 3500,
                Oro = 3000
            };
            public static Ricerca Città_Guarnigione_II = new Ricerca
            {
                Cibo = 6500,
                Legno = 6000,
                Pietra = 5500,
                Ferro = 5000,
                Oro = 4500
            };
            public static Ricerca Città_Guarnigione_III = new Ricerca
            {
                Cibo = 9000,
                Legno = 8500,
                Pietra = 8000,
                Ferro = 7500,
                Oro = 7000
            };
            public static Ricerca Città_Riparazione_I = new Ricerca
            {
                Cibo = 6000,
                Legno = 5500,
                Pietra = 5000,
                Ferro = 4500,
                Oro = 4000
            };
            public static Ricerca Città_Riparazione_II = new Ricerca
            {
                Cibo = 7500,
                Legno = 7000,
                Pietra = 6500,
                Ferro = 6000,
                Oro = 5500
            };
            public static Ricerca Città_Riparazione_III = new Ricerca
            {
                Cibo = 10500,
                Legno = 9500,
                Pietra = 9000,
                Ferro = 8500,
                Oro = 8000
            };
        }

        public class EsercitoNemico
        {
            public static Esercito Guerriero = new Esercito
            {
                Salute = 6,
                Attacco = 3,
                Difesa = 3,
                Distanza = 1,
                Salario = 1,
                Cibo = 1,
                Quantità = 0,
                TempoReclutamento = 19
            };
            public static Esercito Lanciere = new Esercito
            {
                Salute = 7,
                Attacco = 4,
                Difesa = 4,
                Distanza = 2,
                Salario = 1,
                Cibo = 1,
                Quantità = 0,
                TempoReclutamento = 24
            };
            public static Esercito Arciere = new Esercito
            {
                Salute = 5,
                Attacco = 6,
                Difesa = 2,
                Distanza = 6,
                Salario = 1,
                Cibo = 1,
                Quantità = 0,
                TempoReclutamento = 32
            };
            public static Esercito Catapulta = new Esercito
            {
                Salute = Guerriero.Salute * 0.71 * CostoReclutamento.Guerriero.Popolazione,
                Attacco = 18,
                Difesa = Guerriero.Salute * 0.71 * CostoReclutamento.Guerriero.Popolazione,
                Distanza = 18,
                Salario = CostoReclutamento.Guerriero.Popolazione * 1.525,
                Cibo = 1 * CostoReclutamento.Guerriero.Popolazione,
                Quantità = 0,
                TempoReclutamento = 61
            };
        }
        public class Esercito
        {
            public double Salute { get; set; }
            public double Attacco { get; set; }
            public double Difesa { get; set; }
            public double Distanza { get; set; }
            public double Salario { get; set; }
            public double Cibo { get; set; }
            public int Quantità { get; set; }
            public int TempoReclutamento { get; set; }

            public static Esercito Guerriero = new Esercito
            {
                Salute = 5,
                Attacco = 3,
                Difesa = 3,
                Distanza = 1,
                Salario = 0.16,
                Cibo = 0.32,
                Quantità = 0
            };
            public static Esercito Lanciere = new Esercito
            {
                Salute = 6,
                Attacco = 4,
                Difesa = 4,
                Distanza = 2,
                Salario = 0.20,
                Cibo = 0.35,
                Quantità = 0
            };
            public static Esercito Arciere = new Esercito
            {
                Salute = 4,
                Attacco = 8,
                Difesa = 3,
                Distanza = 6,
                Salario = 0.25,
                Cibo = 0.41,
                Quantità = 0
            };
            public static Esercito Catapulta = new Esercito
            {
                Salute = Guerriero.Salute * 0.75 * CostoReclutamento.Catapulta.Popolazione,
                Attacco = 18,
                Difesa = Guerriero.Salute * 0.75 * CostoReclutamento.Catapulta.Popolazione,
                Distanza = 18,
                Salario = CostoReclutamento.Catapulta.Popolazione * Guerriero.Salario * 0.749,
                Cibo = CostoReclutamento.Catapulta.Popolazione * Guerriero.Cibo * 0.699,
                Quantità = 0
            };
        }
        public class Città : Esercito
        {
            public new int Salute { get; set; }
            public new int Difesa { get; set; }
            public new int SaluteMax { get; set; }
            public new int DifesaMax { get; set; }
            public int Guarnigione { get; set; }
            public int Arceri { get; set; }
            public int Guerrieri { get; set; }
            public int Lancieri { get; set; }
            public int Catapulte { get; set; }

            public static Città Castello = new Città
            {
                Salute = 1500,
                Difesa = 450,
                Guarnigione = 440,
                Guerrieri = 0,
                Lancieri = 0,
                Arceri = 0,
                Catapulte = 0,

                SaluteMax = 1500,
                DifesaMax = 450
            };
            public static Città Torre = new Città
            {
                Salute = 900,
                Difesa = 325,
                Guarnigione = 360,

                Guerrieri = 0,
                Lancieri = 0,
                Arceri = 0,
                Catapulte = 0,

                SaluteMax = 900,
                DifesaMax = 325
            };
            public static Città Mura = new Città
            {
                Salute = 500,
                Difesa = 250,
                Guarnigione = 320,

                Guerrieri = 0,
                Lancieri = 0,
                Arceri = 0,
                Catapulte = 0,

                SaluteMax = 500,
                DifesaMax = 250
            };
        }
        public class Riparazioni
        {
            public double Mura_Salute { get; set; }
            public double Mura_Difesa { get; set; }
            public double Torre_Salute { get; set; }
            public double Torre_Difesa { get; set; }
            public double Castello_Salute { get; set; }
            public double Castello_Difesa { get; set; }
            public int Riparazione { get; set; }

            public static Riparazioni Stato = new Riparazioni
            {
                Mura_Salute = 0,
                Mura_Difesa = 0,
                Torre_Salute = 0,
                Torre_Difesa = 0,
                Castello_Salute = 0,
                Castello_Difesa = 0
            };
            public static CostoCostruzione Costo_Riparazioni = new CostoCostruzione
            {
                Cibo = 9,
                Legno = 6,
                Pietra = 10,
                Ferro = 8,
                Oro = 14
            };
            public static Riparazioni Valore = new Riparazioni
            {
                Riparazione = 1
            };

        }
        public class Abilità
        {
            public int Costo_Token { get; set; }
            public string Descrizione { get; set; }

            public static Abilità Rinforzo_Esercito = new Abilità
            {
                Costo_Token = 1,
            };
            public static Abilità Rinforzo_Città = new Abilità
            {
                Costo_Token = 2,
            };
            public static Abilità Guerrieri = new Abilità
            {
                Costo_Token = 1,
            };
            public static Abilità Lancieri = new Abilità
            {
                Costo_Token = 1,
            };
            public static Abilità Arcieri = new Abilità
            {
                Costo_Token = 1,
            };
            public static Abilità Popolani = new Abilità
            {
                Costo_Token = 1,
            };

        }
    }
}
