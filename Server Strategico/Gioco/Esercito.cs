namespace Server_Strategico.Gioco
{
    internal class Esercito
    {
        public class CostoReclutamento
        {
            public int Spade { get; set; }
            public int Lance { get; set; }
            public int Archi { get; set; }
            public int Scudi { get; set; }
            public int Armature { get; set; }
            public double Cibo { get; set; }
            public double Legno { get; set; }
            public double Pietra { get; set; }
            public double Ferro { get; set; }
            public double Oro { get; set; }
            public double TempoReclutamento { get; set; }
            public double Popolazione { get; set; }

            // Costruttore per inizializzare i costi
            public static CostoReclutamento Guerriero = new CostoReclutamento
            {
                Spade = 1,
                Lance = 0,
                Archi = 0,
                Scudi = 0,
                Armature = 1,

                Cibo = 135,
                Legno = 87,
                Pietra = 64,
                Ferro = 118,
                Oro = 110,
                TempoReclutamento = 95, //55
                Popolazione = 1
            };
            public static CostoReclutamento Lanciere = new CostoReclutamento
            {
                Spade = 0,
                Lance = 1,
                Archi = 0,
                Scudi = 1,
                Armature = 1,

                Cibo = 186,
                Legno = 135,
                Pietra = 107,
                Ferro = 164,
                Oro = 143,
                TempoReclutamento = 109,
                Popolazione = 1
            };
            public static CostoReclutamento Arciere = new CostoReclutamento
            {
                Spade = 0,
                Lance = 0,
                Archi = 1,
                Scudi = 0,
                Armature = 1,

                Cibo = 259,
                Legno = 234,
                Pietra = 193,
                Ferro = 213,
                Oro = 202,
                TempoReclutamento = 127,
                Popolazione = 1
            };
            public static CostoReclutamento Catapulta = new CostoReclutamento
            {
                Spade = 3,
                Lance = 3,
                Archi = 0,
                Scudi = 6,
                Armature = 6,

                Cibo = 344,
                Legno = 357,
                Pietra = 389,
                Ferro = 276,
                Oro = 313,
                TempoReclutamento = 159,
                Popolazione = 6
            };
        }
        public class EsercitoNemico
        {
            public static Unità Guerriero = new Unità
            {
                Salute = 6,
                Attacco = 3,
                Difesa = 3,
                Distanza = 1,
                Quantità = 0,
                TempoReclutamento = 95,
                Esperienza = 1
            };
            public static Unità Lanciere = new Unità
            {
                Salute = 7,
                Attacco = 4,
                Difesa = 4,
                Distanza = 2,
                Quantità = 0,
                TempoReclutamento = 109,
                Esperienza = 1
            };
            public static Unità Arciere = new Unità
            {
                Salute = 5,
                Attacco = 6,
                Difesa = 2,
                Distanza = 6,
                Quantità = 0,
                TempoReclutamento = 127,
                Esperienza = 2
            };
            public static Unità Catapulta = new Unità
            {
                Salute = (int)(Guerriero.Salute * 0.58 * CostoReclutamento.Catapulta.Popolazione),
                Attacco = 12,
                Difesa = (int)(Guerriero.Difesa * 0.58 * CostoReclutamento.Catapulta.Popolazione),
                Distanza = 14,
                Quantità = 0,
                TempoReclutamento = 159,
                Esperienza = 3
            };
        }
        public class Unità
        {
            public int Salute { get; set; }
            public int Attacco { get; set; }
            public int Difesa { get; set; }
            public int Distanza { get; set; }
            public double Salario { get; set; }
            public double Cibo { get; set; }
            public int Quantità { get; set; }
            public int TempoReclutamento { get; set; }
            public int Esperienza { get; set; }
            public int Componente_Lancio { get; set; }
            public int Trasporto { get; set; }

            public static Unità Guerriero = new Unità
            {
                Salute = 5,
                Attacco = 3,
                Difesa = 3,
                Distanza = 1,
                Salario = 0.15,
                Cibo = 0.31,
                Quantità = 0,
                Esperienza = 1,
                Trasporto = 100
            };
            public static Unità Lanciere = new Unità
            {
                Salute = 6,
                Attacco = 4,
                Difesa = 4,
                Distanza = 2,
                Salario = 0.19,
                Cibo = 0.36,
                Quantità = 0,
                Esperienza = 1,
                Trasporto = 150
            };
            public static Unità Arciere = new Unità
            {
                Salute = 4,
                Attacco = 7,
                Difesa = 3,
                Distanza = 6,
                Salario = 0.24,
                Cibo = 0.43,
                Quantità = 0,
                Esperienza = 2,
                Componente_Lancio = 4,
                Trasporto = 200
            };
            public static Unità Catapulta = new Unità
            {
                Salute = (int)(Guerriero.Salute * 0.60 * CostoReclutamento.Catapulta.Popolazione),
                Attacco = 12,
                Difesa = (int)(Guerriero.Difesa * 0.60 * CostoReclutamento.Catapulta.Popolazione),
                Distanza = 14,
                Salario = CostoReclutamento.Catapulta.Popolazione * Guerriero.Salario * 0.629,
                Cibo = CostoReclutamento.Catapulta.Popolazione * Guerriero.Cibo * 0.779,
                Quantità = 0,
                Esperienza = 3,
                Componente_Lancio = 8,
                Trasporto = 300
            };
            public static Unità Saccheggiatore = new Unità
            {
                Salute = 2,
                Attacco = 0,
                Difesa = 0,
                Distanza = 0,
                Salario = 0.18,
                Cibo = 0.23,
                Quantità = 0,
                Esperienza = 1,
                Trasporto = 500
            };
            public static Unità Carretto = new Unità
            {
                Salute = 5,
                Attacco = 0,
                Difesa = 2,
                Distanza = 0,
                Salario = 0.26,
                Cibo = 0.29,
                Quantità = 0,
                Esperienza = 2,
                Trasporto = 1500
            };
        }
    }
}
