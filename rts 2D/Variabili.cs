using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rts_2D
{
    internal class Variabili
    {
        public static double Cibo        = 0;
        public static double Legno       = 0;
        public static double Pietra      = 0;
        public static double Ferro       = 0;
        public static double Oro         = 0;
        public static double Popolazione = 0;
        public static double Popolazione_Up = 0.11;

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

        public static int guerrieri = 0;
        public static int picchieri = 0;
        public static int arcieri = 0;
        public static int catapulte = 0;

        public static int guerrieri_Att = 0;
        public static int picchieri_Att = 0;
        public static int arcieri_Att = 0;
        public static int catapulte_Att = 0;
        public static double forza_Esercito_Att = 0;
        public static int timer_Invasione = 60 * 15;

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
                Produzione = 4.54,
                TempoCostruzione = 25
            };
            public static CostoCostruzione Segheria = new CostoCostruzione
            {
                Cibo    = 200,
                Legno   = 200,
                Pietra  = 200,
                Ferro   = 200,
                Oro     = 200,
                Produzione = 3.25,
                TempoCostruzione = 29
            };
            public static CostoCostruzione CavaPietra = new CostoCostruzione
            {
                Cibo    = 300,
                Legno   = 300,
                Pietra  = 300,
                Ferro   = 300,
                Oro     = 300,
                Produzione = 2.33,
                TempoCostruzione = 35
            };
            public static CostoCostruzione MinieraFerro = new CostoCostruzione
            {
                Cibo    = 400,
                Legno   = 400,
                Pietra  = 400,
                Ferro   = 400,
                Oro     = 400,
                Produzione = 1.87,
                TempoCostruzione = 39
            };
            public static CostoCostruzione MinieraOro = new CostoCostruzione
            {
                Cibo    = 500,
                Legno   = 500,
                Pietra  = 500,
                Ferro   = 500,
                Oro     = 500,
                Produzione = 1.28,
                TempoCostruzione = 51
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
                Spade       = 100,
                Lance       = 100,
                Archi       = 100,
                Scudi       = 100,
                Armature    = 100,
                Cibo        = 100,
                Legno       = 100,
                Pietra      = 100,
                Ferro       = 100,
                Oro         = 100,
                TempoReclutamento = 55, //55
                Popolazione = 1
            };
            public static CostoReclutamento Lanciere = new CostoReclutamento
            {
                Spade       = 200,
                Lance       = 200,
                Archi       = 200,
                Scudi       = 200,
                Armature    = 200,
                Cibo        = 200,
                Legno       = 200,
                Pietra      = 200,
                Ferro       = 200,
                Oro         = 200,
                TempoReclutamento = 71,
                Popolazione = 1
            };
            public static CostoReclutamento Arciere = new CostoReclutamento
            {
                Spade       = 300,
                Lance       = 300,
                Archi       = 300,
                Scudi       = 300,
                Armature    = 300,
                Cibo        = 300,
                Legno       = 300,
                Pietra      = 300,
                Ferro       = 300,
                Oro         = 300,
                TempoReclutamento = 119,
                Popolazione = 1
            };
            public static CostoReclutamento Catapulta = new CostoReclutamento
            {
                Spade       = 400,
                Lance       = 400,
                Archi       = 400,
                Scudi       = 400,
                Armature    = 400,
                Cibo        = 400,
                Legno       = 400,
                Pietra      = 400,
                Ferro       = 400,
                Oro         = 400,
                TempoReclutamento = 200,
                Popolazione = 5
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

            public static Esercito Guerriero = new Esercito
            {
                Salute = 4,
                Attacco = 3,
                Difesa = 1,
                Distanza = 0,
                Salario = 1,
                Cibo = 1
            };
            public static Esercito Lanciere = new Esercito
            {
                Salute = 4,
                Attacco = 4,
                Difesa = 3,
                Distanza = 6,
                Salario = 1,
                Cibo = 1
            };
            public static Esercito Arciere = new Esercito
            {
                Salute = 3,
                Attacco = 5,
                Difesa = 1,
                Distanza = 6,
                Salario = 1,
                Cibo = 1
            };
            public static Esercito Catapulta = new Esercito
            {
                Salute = Guerriero.Salute / 1.88 * CostoReclutamento.Guerriero.Popolazione,
                Attacco = 1,
                Difesa = Guerriero.Salute / 1.68 * CostoReclutamento.Guerriero.Popolazione,
                Distanza = 14,
                Salario = CostoReclutamento.Guerriero.Popolazione * 1.725,
                Cibo = 1 * CostoReclutamento.Guerriero.Popolazione
            };
        }
    }
}
