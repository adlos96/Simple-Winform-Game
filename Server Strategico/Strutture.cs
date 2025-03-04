namespace Server_Strategico
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
                Produzione = 1.40,
                TempoCostruzione = 27
            };
            public static Edifici Segheria = new Edifici
            {
                Cibo = 175,
                Legno = 175,
                Pietra = 175,
                Ferro = 175,
                Oro = 175,
                Produzione = 1.24,
                TempoCostruzione = 30
            };
            public static Edifici CavaPietra = new Edifici
            {
                Cibo = 250,
                Legno = 250,
                Pietra = 250,
                Ferro = 250,
                Oro = 250,
                Produzione = 1.03,
                TempoCostruzione = 35
            };
            public static Edifici MinieraFerro = new Edifici
            {
                Cibo = 325,
                Legno = 325,
                Pietra = 325,
                Ferro = 325,
                Oro = 325,
                Produzione = 0.86,
                TempoCostruzione = 39
            };
            public static Edifici MinieraOro = new Edifici
            {
                Cibo = 400,
                Legno = 400,
                Pietra = 400,
                Ferro = 400,
                Oro = 400,
                Produzione = 0.73,
                TempoCostruzione = 46
            };
            public static Edifici Case = new Edifici
            {
                Cibo = 2500,
                Legno = 2500,
                Pietra = 2500,
                Ferro = 2500,
                Oro = 2500,
                Produzione = 0.01,
                TempoCostruzione = 54
            };
            // Edifici Militari
            public static Edifici Armature = new Edifici
            {
                Cibo = 1500,
                Legno = 1500,
                Pietra = 1500,
                Ferro = 5100,
                Oro = 1500,
                Produzione = 0.02,
                TempoCostruzione = 69
            };
            public static Edifici ProduzioneSpade = new Edifici
            {
                Cibo = 1750,
                Legno = 1750,
                Pietra = 1750,
                Ferro = 1750,
                Oro = 1750,
                Produzione = 0.02,
                TempoCostruzione = 69
            };
            public static Edifici ProduzioneLance = new Edifici
            {
                Cibo = 2000,
                Legno = 2000,
                Pietra = 2000,
                Ferro = 2000,
                Oro = 2000,
                Produzione = 0.02,
                TempoCostruzione = 69
            };
            public static Edifici ProduzioneArchi = new Edifici
            {
                Cibo = 2250,
                Legno = 2250,
                Pietra = 2250,
                Ferro = 2250,
                Oro = 2250,
                Produzione = 0.02,
                TempoCostruzione = 69
            };
            public static Edifici ProduzioneScudi = new Edifici
            {
                Cibo = 2500,
                Legno = 2500,
                Pietra = 2500,
                Ferro = 2500,
                Oro = 2500,
                Produzione = 0.02,
                TempoCostruzione = 69
            };
            public static Edifici ProduzioneArmature = new Edifici
            {
                Cibo = 2750,
                Legno = 2750,
                Pietra = 2750,
                Ferro = 2750,
                Oro = 2750,
                Produzione = 0.02,
                TempoCostruzione = 69
            };
            public static Edifici ProduzioneFrecce = new Edifici
            {
                Cibo = 3250,
                Legno = 3250,
                Pietra = 3250,
                Ferro = 3250,
                Oro = 3250,
                Produzione = 0.09,
                TempoCostruzione = 79
            };

            public static Edifici CasermaGuerrieri = new Edifici
            {
                Cibo = 1250,
                Legno = 1250,
                Pietra = 1250,
                Ferro = 1250,
                Oro = 1250,
                TempoCostruzione = 98
            };
            public static Edifici CasermaLancieri = new Edifici
            {
                Cibo = 1450,
                Legno = 1450,
                Pietra = 1450,
                Ferro = 1450,
                Oro = 1450,
                TempoCostruzione = 98
            };
            public static Edifici CasermaArcieri = new Edifici
            {
                Cibo = 1650,
                Legno = 1650,
                Pietra = 1650,
                Ferro = 1650,
                Oro = 1650,
                TempoCostruzione = 98
            };
            public static Edifici CasermaCatapulte = new Edifici
            {
                Cibo = 1850,
                Legno = 1850,
                Pietra = 1850,
                Ferro = 1850,
                Oro = 1850,
                TempoCostruzione = 98
            };
        }
    }
}
