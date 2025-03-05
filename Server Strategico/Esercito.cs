namespace Server_Strategico
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

                Cibo = 89,
                Legno = 43,
                Pietra = 12,
                Ferro = 82,
                Oro = 32,
                TempoReclutamento = 38, //55
                Popolazione = 1
            };
            public static CostoReclutamento Lanciere = new CostoReclutamento
            {
                Spade = 0,
                Lance = 1,
                Archi = 0,
                Scudi = 1,
                Armature = 1,

                Cibo = 164,
                Legno = 92,
                Pietra = 28,
                Ferro = 132,
                Oro = 81,
                TempoReclutamento = 46,
                Popolazione = 1
            };
            public static CostoReclutamento Arciere = new CostoReclutamento
            {
                Spade = 0,
                Lance = 0,
                Archi = 1,
                Scudi = 0,
                Armature = 1,

                Cibo = 219,
                Legno = 194,
                Pietra = 123,
                Ferro = 183,
                Oro = 162,
                TempoReclutamento = 54,
                Popolazione = 1
            };
            public static CostoReclutamento Catapulta = new CostoReclutamento
            {
                Spade = 3,
                Lance = 2,
                Archi = 0,
                Scudi = 5,
                Armature = 5,

                Cibo = 311,
                Legno = 327,
                Pietra = 329,
                Ferro = 247,
                Oro = 256,
                TempoReclutamento = 84,
                Popolazione = 5
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
                Salario = 1,
                Cibo = 1,
                Quantità = 0,
                TempoReclutamento = 19,
                Esperienza = 1
            };
            public static Unità Lanciere = new Unità
            {
                Salute = 7,
                Attacco = 4,
                Difesa = 4,
                Distanza = 2,
                Salario = 1,
                Cibo = 1,
                Quantità = 0,
                TempoReclutamento = 24,
                Esperienza = 1
            };
            public static Unità Arciere = new Unità
            {
                Salute = 5,
                Attacco = 6,
                Difesa = 2,
                Distanza = 6,
                Salario = 1,
                Cibo = 1,
                Quantità = 0,
                TempoReclutamento = 32,
                Esperienza = 2
            };
            public static Unità Catapulta = new Unità
            {
                Salute = (int)(Guerriero.Salute * 0.65 * CostoReclutamento.Guerriero.Popolazione),
                Attacco = 14,
                Difesa = (int)(Guerriero.Salute * 0.65 * CostoReclutamento.Guerriero.Popolazione),
                Distanza = 14,
                Salario = CostoReclutamento.Guerriero.Popolazione * 1.525,
                Cibo = 1 * CostoReclutamento.Guerriero.Popolazione,
                Quantità = 0,
                TempoReclutamento = 61,
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

            public static Unità Guerriero = new Unità
            {
                Salute = 5,
                Attacco = 3,
                Difesa = 3,
                Distanza = 1,
                Salario = 0.14,
                Cibo = 0.29,
                Quantità = 0,
                Esperienza = 1
            };
            public static Unità Lanciere = new Unità
            {
                Salute = 6,
                Attacco = 4,
                Difesa = 4,
                Distanza = 2,
                Salario = 0.18,
                Cibo = 0.32,
                Quantità = 0,
                Esperienza = 1
            };
            public static Unità Arciere = new Unità
            {
                Salute = 4,
                Attacco = 7,
                Difesa = 3,
                Distanza = 6,
                Salario = 0.23,
                Cibo = 0.38,
                Quantità = 0,
                Esperienza = 2,
                Componente_Lancio = 3
            };
            public static Unità Catapulta = new Unità
            {
                Salute = (int)(Guerriero.Salute * 0.65 * CostoReclutamento.Catapulta.Popolazione),
                Attacco = 14,
                Difesa = (int)(Guerriero.Salute * 0.65 * CostoReclutamento.Catapulta.Popolazione),
                Distanza = 14,
                Salario = CostoReclutamento.Catapulta.Popolazione * Guerriero.Salario * 0.619,
                Cibo = CostoReclutamento.Catapulta.Popolazione * Guerriero.Cibo * 0.769,
                Quantità = 0,
                Esperienza = 3,
                Componente_Lancio = 5
            };
        }
    }
}
