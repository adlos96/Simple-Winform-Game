using System.Collections.Generic;

namespace Strategico_V2
{
    internal class Variabili_Client
    {
        public static bool login = false;

        public static string Server = "0";
        public static string Versione = "0";
        public static string Difficoltà = "0";

        public static List<string> Giocatori_PVP = new List<string>();
        public static List<string> Raduni_Creati = new List<string>(); //Raduni pubblici
        public static List<string> Raduni_InCorso = new List<string>(); //Raduni a cui si partecipa inviando truppe

        public static string Forza_Esercito = "0";
        public static string Forza_Esercito_PVE = "0";
        public static string Forza_Esercito_PVP = "0";

        public static string username = "";
        public static string password = "";
        public static string Livello = "";
        public static string Esperienza = "";

        public static string Cibo               = "0";
        public static string Legno              = "0";
        public static string Pietra             = "0";
        public static string Ferro              = "0";
        public static string Oro                = "0";
        public static string Popolazione        = "0";

        public static string Risorse_s_Cibo     = "0";
        public static string Risorse_s_Legno    = "0";
        public static string Risorse_s_Pietra   = "0";
        public static string Risorse_s_Ferro    = "0";
        public static string Risorse_s_Oro      = "0";
        public static string Risorse_s_Popolazione = "0";

        public static string Fattoria           = "0";  //Edifici
        public static string Segheria           = "0";  //Edifici
        public static string CavaPietra         = "0";  //Edifici
        public static string MinieraFerro       = "0";  //Edifici
        public static string MinieraOro         = "0";  //Edifici
        public static string Case               = "0";  //Edifici

        public static string ProduzioneSpade    = "0";   //Edifici
        public static string ProduzioneLance    = "0";   //Edifici
        public static string ProduzioneArchi    = "0";   //Edifici
        public static string ProduzioneScudi    = "0";   //Edifici
        public static string ProduzioneArmature = "0";   //Edifici
        public static string ProduzioneFrecce   = "0";   //Edifici

        public static string Fattoria_Coda      = "0";  //Edifici
        public static string Segheria_Coda      = "0";  //Edifici
        public static string CavaPietra_Coda    = "0";  //Edifici
        public static string MinieraFerro_Coda  = "0";  //Edifici
        public static string MinieraOro_Coda    = "0";  //Edifici
        public static string Case_Coda          = "0";  //Edifici

        public static string ProduzioneSpade_Coda = "0";   //Edifici
        public static string ProduzioneLance_Coda = "0";   //Edifici
        public static string ProduzioneArchi_Coda = "0";   //Edifici
        public static string ProduzioneScudi_Coda = "0";   //Edifici
        public static string ProduzioneArmature_Coda = "0";   //Edifici
        public static string ProduzioneFrecce_Coda = "0";   //Edifici

        public static string Risorse_s_Spade              = "0";  //Consumabili
        public static string Risorse_s_Lance              = "0";  //Consumabili
        public static string Risorse_s_Archi              = "0";  //Consumabili
        public static string Risorse_s_Scudi              = "0";  //Consumabili
        public static string Risorse_s_Armature           = "0";  //Consumabili
        public static string Risorse_s_Frecce             = "0";  //Consumabili

        public static string Spade              = "0";  //Consumabili
        public static string Lance              = "0";  //Consumabili
        public static string Archi              = "0";  //Consumabili
        public static string Scudi              = "0";  //Consumabili
        public static string Armature           = "0";  //Consumabili
        public static string Frecce             = "0";  //Consumabili

        //Albero Ricerca
        public static string Ricerca_Produzione = "1";  //Consumabili
        public static string Ricerca_Costruzione = "1";  //Consumabili
        public static string Ricerca_Addestramento = "1";  //Consumabili

        public static string Ricerca_Salute_Guerrieri = "1";  //Consumabili
        public static string Ricerca_Difesa_Guerrieri = "1";  //Consumabili
        public static string Ricerca_Attacco_Guerrieri = "1";  //Consumabili
        public static string Ricerca_Livello_Guerrieri = "1";  //Consumabili

        public static string Ricerca_Salute_Lancieri = "1";  //Consumabili
        public static string Ricerca_Difesa_Lancieri = "1";  //Consumabili
        public static string Ricerca_Attacco_Lancieri = "1";  //Consumabili
        public static string Ricerca_Livello_Lancieri = "1";  //Consumabili

        public static string Ricerca_Salute_Arcieri = "1";  //Consumabili
        public static string Ricerca_Difesa_Arcieri = "1";  //Consumabili
        public static string Ricerca_Attacco_Arcieri = "1";  //Consumabili
        public static string Ricerca_Livello_Arcieri = "1";  //Consumabili

        public static string Ricerca_Salute_Catapulte = "1";  //Consumabili
        public static string Ricerca_Difesa_Catapulte = "1";  //Consumabili
        public static string Ricerca_Attacco_Catapulte = "1";  //Consumabili
        public static string Ricerca_Livello_Catapulte = "1";  //Consumabili

        public static string Arceri             = "0";
        public static string Guerrieri          = "0";
        public static string Lancieri           = "0";
        public static string Catapulte          = "0";

        public static string Arceri_Coda = "0";
        public static string Guerrieri_Coda = "0";
        public static string Lancieri_Coda = "0";
        public static string Catapulte_Coda = "0";

        public class Barbari
        {
            public string Guerrieri { get; set; }
            public string Lancieri { get; set; }
            public string Arceri { get; set; }
            public string Catapulte { get; set; }
            public static Barbari PVE = new Barbari
            {
                Guerrieri = "0",
                Lancieri = "0",
                Arceri = "0",
                Catapulte = "0"
            };
            public static Barbari PVP = new Barbari
            {
                Guerrieri = "0",
                Lancieri = "0",
                Arceri = "0",
                Catapulte = "0"
            };
        }

        public class AttaccoInfo
        {
            public string Creatore { get; set; }
            public string ID { get; set; }
            public int TempoRimanente { get; set; }
            
            public override string ToString()
            {
                return $"ID: {ID} - Creato da: {Creatore}  - {TempoRimanente} min";
            }
            
            public static AttaccoInfo FromString(string data)
            {
                string[] parts = data.Replace(" ", "").Split('-');
                if (parts.Length >= 3)
                {
                    return new AttaccoInfo
                    {
                        Creatore = parts[0],
                        ID = parts[1],
                        TempoRimanente = int.Parse(parts[2])
                    };
                }
                return null;
            }
        }
        public class PartecipanteAttacco
        {
            public string Giocatore { get; set; }
            public string ID { get; set; }
            public string Guerrieri { get; set; }
            public string Lancieri { get; set; }
            public string Arcieri { get; set; }
            public string Catapulte { get; set; }
            public int TempoRimanente { get; set; }

            public override string ToString()
            {
                return $"ID: {ID} - Creato da: {Giocatore}  - {TempoRimanente} min";
            }

            public static PartecipanteAttacco FromString(string data)
            {
                string[] parts = data.Replace(" ", "").Split('-');
                if (parts.Length >= 3)
                {
                    return new PartecipanteAttacco
                    {
                        //"adlos - 30e2fb60 - 29 - 1 - 1 - 1 - 1"
                        Giocatore = parts[0],
                        ID = parts[1],
                        TempoRimanente = int.Parse(parts[2]),
                        Guerrieri = parts[3],
                        Lancieri = parts[4],
                        Arcieri = parts[5],
                        Catapulte = parts[6]
                    };
                }
                return null;
            }
        }

        public class AttaccoPartecipazione
        {
            public string Creatore { get; set; }
            public string ID { get; set; }
            public int NumPartecipanti { get; set; }
            public int MieiGuerrieri { get; set; }
            public int MieiLancieri { get; set; }
            public int MieiArcieri { get; set; }
            public int MieiCatapulte { get; set; }
            public int TempoRimanente { get; set; }
            
            public override string ToString()
            {
                return $"ID: {ID} - Creato da: {Creatore} - Le mie truppe: G:{MieiGuerrieri} L:{MieiLancieri} A:{MieiArcieri} C:{MieiCatapulte} - {TempoRimanente} min";
            }
            
            public static AttaccoPartecipazione FromString(string data)
            {
                string[] parts = data.Split('|');
                if (parts.Length >= 8)
                {
                    return new AttaccoPartecipazione
                    {
                        Creatore = parts[0],
                        ID = parts[1],
                        NumPartecipanti = int.Parse(parts[2]),
                        MieiGuerrieri = int.Parse(parts[3]),
                        MieiLancieri = int.Parse(parts[4]),
                        MieiArcieri = int.Parse(parts[5]),
                        MieiCatapulte = int.Parse(parts[6]),
                        TempoRimanente = int.Parse(parts[7])
                    };
                }
                return null;
            }
        }

    }
}
