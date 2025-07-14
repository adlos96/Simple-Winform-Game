namespace Server_Strategico.Gioco
{
    internal class Strutture
    {
        public class Edifici
        {
            public int Cibo { get; set; }
            public int Legno { get; set; }
            public int Pietra { get; set; }
            public int Ferro { get; set; }
            public int Oro { get; set; }
            public double Produzione { get; set; }
            public double TempoCostruzione { get; set; }

            // Edifici Civili
            public static Edifici Fattoria = new Edifici
            {
                Cibo = 100,
                Legno = 100,
                Pietra = 100,
                Ferro = 100,
                Oro = 100,
                Produzione = 1.12,
                TempoCostruzione = 101
            };
            public static Edifici Segheria = new Edifici
            {
                Cibo = 175,
                Legno = 175,
                Pietra = 175,
                Ferro = 175,
                Oro = 175,
                Produzione = 0.96,
                TempoCostruzione = 117
            };
            public static Edifici CavaPietra = new Edifici
            {
                Cibo = 250,
                Legno = 250,
                Pietra = 250,
                Ferro = 250,
                Oro = 250,
                Produzione = 0.83,
                TempoCostruzione = 136
            };
            public static Edifici MinieraFerro = new Edifici
            {
                Cibo = 325,
                Legno = 325,
                Pietra = 325,
                Ferro = 325,
                Oro = 325,
                Produzione = 0.70,
                TempoCostruzione = 148
            };
            public static Edifici MinieraOro = new Edifici
            {
                Cibo = 400,
                Legno = 400,
                Pietra = 400,
                Ferro = 400,
                Oro = 400,
                Produzione = 0.57,
                TempoCostruzione = 172
            };
            public static Edifici Case = new Edifici
            {
                Cibo = 2500,
                Legno = 2500,
                Pietra = 2500,
                Ferro = 2500,
                Oro = 2500,
                Produzione = 0.001,
                TempoCostruzione = 221
            };
            // Produzione Militari
            public static Edifici ProduzioneSpade = new Edifici
            {
                Cibo = 1750,
                Legno = 1750,
                Pietra = 1750,
                Ferro = 1750,
                Oro = 1750,
                Produzione = 0.008,
                TempoCostruzione = 152
            };
            public static Edifici ProduzioneLance = new Edifici
            {
                Cibo = 2000,
                Legno = 2000,
                Pietra = 2000,
                Ferro = 2000,
                Oro = 2000,
                Produzione = 0.007,
                TempoCostruzione = 181
            };
            public static Edifici ProduzioneArchi = new Edifici
            {
                Cibo = 2250,
                Legno = 2250,
                Pietra = 2250,
                Ferro = 2250,
                Oro = 2250,
                Produzione = 0.0075,
                TempoCostruzione = 214
            };
            public static Edifici ProduzioneScudi = new Edifici
            {
                Cibo = 2500,
                Legno = 2500,
                Pietra = 2500,
                Ferro = 2500,
                Oro = 2500,
                Produzione = 0.008,
                TempoCostruzione = 229
            };
            public static Edifici ProduzioneArmature = new Edifici
            {
                Cibo = 2750,
                Legno = 2750,
                Pietra = 2750,
                Ferro = 2750,
                Oro = 2750,
                Produzione = 0.0065,
                TempoCostruzione = 253
            };
            public static Edifici ProduzioneFrecce = new Edifici
            {
                Cibo = 3750,
                Legno = 3750,
                Pietra = 3750,
                Ferro = 3750,
                Oro = 3750,
                Produzione = 0.005,
                TempoCostruzione = 294
            };

            public static Edifici CasermaGuerrieri = new Edifici
            {
                Cibo = 2450,
                Legno = 2450,
                Pietra = 2450,
                Ferro = 2450,
                Oro = 2450,
                TempoCostruzione = 274
            };
            public static Edifici CasermaLancieri = new Edifici
            {
                Cibo = 2650,
                Legno = 2650,
                Pietra = 2650,
                Ferro = 2650,
                Oro = 2650,
                TempoCostruzione = 295
            };
            public static Edifici CasermaArcieri = new Edifici
            {
                Cibo = 3850,
                Legno = 3850,
                Pietra = 3850,
                Ferro = 3850,
                Oro = 3850,
                TempoCostruzione = 316
            };
            public static Edifici CasermaCatapulte = new Edifici
            {
                Cibo = 4550,
                Legno = 4550,
                Pietra = 4550,
                Ferro = 4550,
                Oro = 4550,
                TempoCostruzione = 337
            };
        }
    }
}
