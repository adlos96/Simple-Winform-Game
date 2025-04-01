using static Server_Strategico.Variabili;

namespace Server_Strategico
{
    internal class Dati
    {
        public static string Difficoltà = "1";
        public static string Versione = "0.1.22";
        public static string Server = "Italy";

        public static double forza_Esercito_Att_PVP = 0;
    }

    public class Variabili
    {
        public class Barbari
        {
            public int Guerrieri { get; set; }
            public int Lancieri { get; set; }
            public int Arceri { get; set; }
            public int Catapulte { get; set; }
            public int Livello { get; set; }
            public static Barbari PVP = new Barbari
            {
                Guerrieri = 0,
                Lancieri = 0,
                Arceri = 0,
                Catapulte = 0
            };
        }
        public class Player
        {
            public bool Player_Loop { get; set; }

            public string Username { get; set; }
            public string Password { get; set; }
            public Guid guid_Player { get; set; }

            public int Esperienza { get; set; }
            public int Livello { get; set; }
            public double forza_Esercito { get; set; }
            public double forza_Esercito_PVE { get; set; }

            public int Fattoria { get; private set; }
            public int Segheria { get; private set; }
            public int CavaPietra { get; private set; }
            public int MinieraFerro { get; private set; }
            public int MinieraOro { get; private set; }

            public int Abitazioni { get; private set; }
            public int ProduzioneSpade { get; private set; }
            public int ProduzioneLance { get; private set; }
            public int ProduzioneArchi { get; private set; }
            public int ProduzioneScudi { get; private set; }
            public int ProduzioneArmature { get; private set; }
            public int ProduzioneFrecce { get; private set; }

            public double Cibo { get; set; }
            public double Legno { get; set; }
            public double Pietra { get; set; }
            public double Ferro { get; set; }
            public double Oro { get; set; }
            public double Popolazione { get; set; }
                   
            public double Spade { get; set; }
            public double Lance { get; set; }
            public double Archi { get; set; }
            public double Scudi { get; set; }
            public double Armature { get; set; }
            public double Frecce { get; set; }

            public int Guerrieri { get; set; }
            public int Lancieri { get; set; }
            public int Arceri { get; set; }
            public int Catapulte { get; set; }

            public int Caserma_Guerrieri { get; set; }
            public int Caserma_Lancieri { get; set; }
            public int Caserma_Arceri { get; set; }
            public int Caserma_Catapulte { get; set; }

            public int GuerrieriMax { get; set; }
            public int LancieriMax { get; set; }
            public int ArceriMax { get; set; }
            public int CatapulteMax { get; set; }

            public int SaluteCancello { get; set; }
            public int SaluteCancelloMax { get; set; }
            public int SaluteMura { get; set; }
            public int SaluteMuraMax { get; set; }
            public int SaluteTorri { get; set; }
            public int SaluteTorriMax { get; set; }
            public int SaluteCastello { get; set; }
            public int SaluteCastelloMax { get; set; }

            public int Ricerca_Produzione { get; set; }
            public int Ricerca_Costruzione { get; set; }
            public int Ricerca_Addestramento { get; set; }
            public int Ricerca_Riparazione { get; set; }

            public int Guerriero_Livello { get; set; }
            public int Guerriero_Salute { get; set; }
            public int Guerriero_Difesa { get; set; }
            public int Guerriero_Attacco { get; set; }

            public int Lanciere_Livello { get; set; }
            public int Lanciere_Salute { get; set; }
            public int Lanciere_Difesa { get; set; }
            public int Lanciere_Attacco { get; set; }

            public int Arciere_Livello { get; set; }
            public int Arciere_Salute { get; set; }
            public int Arciere_Difesa { get; set; }
            public int Arciere_Attacco { get; set; }

            public int catapulta_Livello { get; set; }
            public int catapulta_Salute { get; set; }
            public int catapulta_Difesa { get; set; }
            public int catapulta_Attacco { get; set; }

            public int Guerrieri_Barbari_PVE { get; set; }
            public int Lancieri_Barbari_PVE { get; set; }
            public int Arceri_Barbari_PVE { get; set; }
            public int Catapulte_Barbari_PVE { get; set; }
            public int Livello_Barbari_PVE { get; set; }


            private Dictionary<string, Queue<ConstructionTask>> constructionQueues; // Dizionario per memorizzare le code di costruzione per ogni tipo di edificio
            private Dictionary<string, ConstructionTask> currentTasks; // Dizionario per memorizzare il task di costruzione attuale per ogni tipo di edificio

            private Dictionary<string, Queue<RecruitTask>> recruitQueues;  // Dizionario per memorizzare le code di reclutamento per ogni tipo di unità
            private Dictionary<string, RecruitTask> currentRecruitTasks;  // Dizionario per memorizzare il task di reclutamento attuale per ogni tipo di unità

            public Player(string username, string password, Guid guid_Client)
            {
                Player_Loop = false;

                Username = username;
                Password = password;
                guid_Player = guid_Client;

                Esperienza = 0;
                Livello = 1;
                forza_Esercito = 0;

                //Strutture Civile
                Fattoria = 0; //Produce cibo
                Segheria = 0;
                CavaPietra = 0;
                MinieraFerro = 0;
                MinieraOro = 0;
                Abitazioni = 0; //Aumenta il numero abitanti/s

                //Strutture Militare
                ProduzioneSpade = 0; //Produce Spade
                ProduzioneLance = 0;
                ProduzioneArchi = 0;
                ProduzioneScudi = 0;
                ProduzioneArmature = 0;
                ProduzioneFrecce = 0;

                Caserma_Guerrieri   = 0; //Numero Caserme
                Caserma_Lancieri    = 0;
                Caserma_Arceri      = 0;
                Caserma_Catapulte   = 0;

                //Risorse Civile
                Cibo = 0;
                Legno = 0;
                Pietra = 0;
                Ferro = 0;
                Oro = 0;
                Popolazione = 0;

                //Risorse Militare
                Spade = 0;
                Lance = 0;
                Archi = 0;
                Scudi = 0;
                Armature = 0;
                Frecce = 0;

                //Esercito
                Guerrieri = 0;
                Lancieri = 0;
                Arceri = 0;
                Catapulte = 0;

                GuerrieriMax    = 35; //Limite x caserma
                LancieriMax     = 25;
                ArceriMax       = 10;
                CatapulteMax    = 5;

                //Campo Barbaro
                Guerrieri_Barbari_PVE = 0;
                Lancieri_Barbari_PVE = 0;
                Arceri_Barbari_PVE = 0;
                Catapulte_Barbari_PVE = 0;

                //Ricerche
                Ricerca_Produzione = 0;
                Ricerca_Costruzione = 0;
                Ricerca_Riparazione = 0;
                Ricerca_Addestramento = 0;

                Guerriero_Livello = 0;
                Guerriero_Salute = 0;
                Guerriero_Difesa = 0;
                Guerriero_Attacco = 0;

                Lanciere_Livello = 0;
                Lanciere_Salute = 0;
                Lanciere_Difesa = 0;
                Lanciere_Attacco = 0;

                Arciere_Livello = 0;
                Arciere_Salute = 0;
                Arciere_Difesa = 0;
                Arciere_Attacco = 0;

                catapulta_Livello = 0;
                catapulta_Salute = 0;
                catapulta_Difesa = 0;
                catapulta_Attacco = 0;
                Livello_Barbari_PVE = 0;

                constructionQueues = new Dictionary<string, Queue<ConstructionTask>>();
                currentTasks = new Dictionary<string, ConstructionTask>();

                recruitQueues = new Dictionary<string, Queue<RecruitTask>>();
                currentRecruitTasks = new Dictionary<string, RecruitTask>();
            }

            public bool ValidatePassword(string password)
            {
                return Password == password;
            }

            public void ProduceResources() //produzione risorse
            {
                Cibo += Fattoria * (Strutture.Edifici.Fattoria.Produzione + Ricerca_Produzione * Ricerca.Tipi.Incremento.Cibo);
                Legno += Segheria * (Strutture.Edifici.Segheria.Produzione + Ricerca_Produzione * Ricerca.Tipi.Incremento.Legno);
                Pietra += CavaPietra * (Strutture.Edifici.CavaPietra.Produzione + Ricerca_Produzione * Ricerca.Tipi.Incremento.Pietra);
                Ferro += MinieraFerro * (Strutture.Edifici.MinieraFerro.Produzione + Ricerca_Produzione * Ricerca.Tipi.Incremento.Ferro);
                Oro += MinieraOro * (Strutture.Edifici.MinieraOro.Produzione + Ricerca_Produzione * Ricerca.Tipi.Incremento.Oro);
                Popolazione += Abitazioni * (Strutture.Edifici.Case.Produzione + Ricerca_Produzione * Ricerca.Tipi.Incremento.Popolazione);

                Spade += ProduzioneSpade * Strutture.Edifici.ProduzioneSpade.Produzione;
                Lance += ProduzioneLance * Strutture.Edifici.ProduzioneLance.Produzione;
                Archi += ProduzioneArchi * Strutture.Edifici.ProduzioneArchi.Produzione;
                Scudi += ProduzioneScudi * Strutture.Edifici.ProduzioneScudi.Produzione;
                Armature += ProduzioneArmature * Strutture.Edifici.ProduzioneArmature.Produzione;
                Frecce += ProduzioneFrecce * Strutture.Edifici.ProduzioneFrecce.Produzione;
            }
            public void ManutenzioneEsercito() //produzione risorse
            {
                Cibo -= (Guerrieri * Esercito.Unità.Guerriero.Cibo) + (Lancieri * Esercito.Unità.Lanciere.Cibo) + (Arceri * Esercito.Unità.Arciere.Cibo) + (Catapulte * Esercito.Unità.Catapulta.Cibo);
                Oro -= (Guerrieri * Esercito.Unità.Guerriero.Salario) + (Lancieri * Esercito.Unità.Lanciere.Salario) + (Arceri * Esercito.Unità.Arciere.Salario) + (Catapulte * Esercito.Unità.Catapulta.Salario);
                if (Cibo <= 0) Cibo = 0;
                if (Oro <= 0) Oro = 0;
            }
            public void QueueBuildConstruction(string buildingType, int count, Guid clientGuid, Player player)
            {
                // Ottieni i costi di costruzione dell'edificio
                var buildingCost = GetBuildingCost(buildingType);

                // Verifica se il giocatore ha abbastanza risorse
                if (Cibo >= buildingCost.Cibo * count &&
                    Legno >= buildingCost.Legno * count &&
                    Pietra >= buildingCost.Pietra * count &&
                    Ferro >= buildingCost.Ferro * count &&
                    Oro >= buildingCost.Oro * count)
                {
                    // Sottrai le risorse necessarie
                    Cibo -= buildingCost.Cibo * count;
                    Legno -= buildingCost.Legno * count;
                    Pietra -= buildingCost.Pietra * count;
                    Ferro -= buildingCost.Ferro * count;
                    Oro -= buildingCost.Oro * count;

                    Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per {count} costruzione/i di {buildingType}:\r\n " +
                        $"Cibo= {buildingCost.Cibo * count}, " +
                        $"Legno= {buildingCost.Legno * count}, " +
                        $"Pietra= {buildingCost.Pietra * count}, " +
                        $"Ferro= {buildingCost.Ferro * count}, " +
                        $"Oro= {buildingCost.Oro * count}\r\n");
                    Console.WriteLine($"Risorse consumate per {count} costruzione/i di {buildingType}:\r\n Cibo={buildingCost.Cibo * count}, Legno={buildingCost.Legno * count}, Pietra={buildingCost.Pietra * count}, Ferro={buildingCost.Ferro * count}, Oro={buildingCost.Oro * count}\r\n");

                    // Verifica se la coda di costruzione esiste per questo tipo di edificio, altrimenti creala
                    if (!constructionQueues.ContainsKey(buildingType))
                        constructionQueues[buildingType] = new Queue<ConstructionTask>();

                    // Aggiungi i task di costruzione alla coda
                    int tempoCostruzioneInSecondi = Convert.ToInt32(buildingCost.TempoCostruzione - player.Ricerca_Costruzione);
                    for (int i = 0; i < count; i++)
                        constructionQueues[buildingType].Enqueue(new ConstructionTask(buildingType, tempoCostruzioneInSecondi));
                    
                    // Inizializza l'entry in currentTasks se non esiste
                    if (!currentTasks.ContainsKey(buildingType))
                        currentTasks[buildingType] = null;
                    
                    // Se non c'è nessuna costruzione in corso per questo tipo, inizia la prima
                    if (currentTasks[buildingType] == null)
                        StartNextConstruction(buildingType);
                }
                else
                {
                    Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per costruire {count} {buildingType}.");
                    Console.WriteLine($"Risorse insufficienti per costruire {count} {buildingType}.");
                }
            }
            public void LoadQueueBuildConstruction(string buildingType, int count, Player player)
            {
                // Ottieni i costi di costruzione dell'edificio
                var buildingCost = GetBuildingCost(buildingType);

                if (!constructionQueues.ContainsKey(buildingType)) // Verifica se la coda di costruzione esiste per questo tipo di edificio, altrimenti creala
                    constructionQueues[buildingType] = new Queue<ConstructionTask>();

                // Aggiungi i task di costruzione alla coda
                int tempoCostruzioneInSecondi = Convert.ToInt32(buildingCost.TempoCostruzione - player.Ricerca_Costruzione);
                for (int i = 0; i < count; i++)
                    constructionQueues[buildingType].Enqueue(new ConstructionTask(buildingType, tempoCostruzioneInSecondi));

                if (!currentTasks.ContainsKey(buildingType)) // Inizializza l'entry in currentTasks se non esiste
                    currentTasks[buildingType] = null;

                if (currentTasks[buildingType] == null)  // Se non c'è nessuna costruzione in corso per questo tipo, inizia la prima
                    StartNextConstruction(buildingType);
            }
            private Strutture.Edifici GetBuildingCost(string buildingType)
            {
                // Restituisci i costi dell'edificio in base al tipo
                return buildingType switch
                {
                    "Fattoria" => Strutture.Edifici.Fattoria,
                    "Segheria" => Strutture.Edifici.Segheria,
                    "CavaPietra" => Strutture.Edifici.CavaPietra,
                    "MinieraFerro" => Strutture.Edifici.MinieraFerro,
                    "MinieraOro" => Strutture.Edifici.MinieraOro,
                    "Case" => Strutture.Edifici.Case,

                    "ProduzioneSpade" => Strutture.Edifici.ProduzioneSpade,
                    "ProduzioneLancie" => Strutture.Edifici.ProduzioneLance,
                    "ProduzioneArchi" => Strutture.Edifici.ProduzioneArchi,
                    "ProduzioneScudi" => Strutture.Edifici.ProduzioneScudi,
                    "ProduzioneArmature" => Strutture.Edifici.ProduzioneArmature,
                    "ProduzioneFrecce" => Strutture.Edifici.ProduzioneFrecce,

                    "CasermaGuerrieri" => Strutture.Edifici.CasermaGuerrieri,
                    "CasermaLancieri" => Strutture.Edifici.CasermaLancieri,
                    "CasermaArcieri" => Strutture.Edifici.CasermaArcieri,
                    "CasermaCatapulte" => Strutture.Edifici.CasermaCatapulte,
                    // Aggiungi altri edifici se necessario
                    _ => null,
                };
            }
            private void StartNextConstruction(string buildingType) // Metodo per avviare la prossima costruzione per un tipo specifico di edificio
            {
                if (constructionQueues[buildingType].Count > 0)
                {
                    currentTasks[buildingType] = constructionQueues[buildingType].Dequeue();
                    currentTasks[buildingType].Start();
                    Console.WriteLine($"Costruzione di una {buildingType} iniziata, completamento previsto in {currentTasks[buildingType].DurationInSeconds} secondi.");
                }
                else
                    currentTasks[buildingType] = null; // Nessuna costruzione in corso

            }
            public void CompleteBuilds(Guid clientGuid) // Metodo per completare le costruzioni in corso
            {
                foreach (var buildingType in currentTasks.Keys)
                {
                    var currentTask = currentTasks[buildingType];
                    if (currentTask != null && currentTask.IsComplete())
                    {
                        switch (buildingType)
                        {
                            case "Fattoria":
                                Fattoria++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "Segheria":
                                Segheria++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "CavaPietra":
                                CavaPietra++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "MinieraFerro":
                                MinieraFerro++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "MinieraOro":
                                MinieraOro++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "Case":
                                Abitazioni++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "ProduzioneSpade":
                                ProduzioneSpade++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "ProduzioneLancie":
                                ProduzioneLance++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "ProduzioneArchi":
                                ProduzioneArchi++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "ProduzioneScudi":
                                ProduzioneScudi++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "ProduzioneArmature":
                                ProduzioneArmature++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "ProduzioneFrecce":
                                ProduzioneFrecce++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "CasermaGuerrieri":
                                Caserma_Guerrieri++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "CasermaLancieri":
                                Caserma_Lancieri++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "CasermaArcieri":
                                Caserma_Arceri++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "CasermaCatapulte":
                                Caserma_Catapulte++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            // Aggiungi case per altri tipi di costruzioni
                            default:
                                Console.WriteLine($"Costruzione {buildingType} non valida!");
                                break;
                        }
                        // Avvia la prossima costruzione per questo tipo di edificio
                        Server.Send(clientGuid, $"Log_Server|Costruzione completata {buildingType} costruita!\n\r");
                        StartNextConstruction(buildingType);
                    }
                }
            }
            public bool IsBuilding() // Metodo per verificare se ci sono costruzioni in corso
            {
                foreach (var task in currentTasks.Values)
                    if (task != null) return true;
                return false;
            }

            private class ConstructionTask // Classe privata per rappresentare un task di costruzione
            {
                public string Type { get; }
                public int DurationInSeconds { get; }
                private DateTime startTime;

                public ConstructionTask(string type, int durationInSeconds)
                {
                    Type = type;
                    DurationInSeconds = durationInSeconds;
                }
                public void Start()
                {
                    startTime = DateTime.Now;
                }
                public bool IsComplete()
                {
                    return DateTime.Now >= startTime.AddSeconds(DurationInSeconds);
                }
            }
            private class RecruitTask // Classe privata per rappresentare un task di reclutamento
            {
                public string Type { get; }
                public int DurationInSeconds { get; }
                private DateTime startTime;

                public RecruitTask(string type, int durationInSeconds)
                {
                    Type = type;
                    DurationInSeconds = durationInSeconds;
                }

                public void Start()
                {
                    startTime = DateTime.Now;
                }
                public bool IsComplete()
                {
                    return DateTime.Now >= startTime.AddSeconds(DurationInSeconds);
                }
            }

            public async void QueueTrainUnits(string unitType, int count, Guid clientGuid, Variabili.Player player)
            {
                var unitCost = GetUnitCost(unitType);

                if (unitType == "Guerriero" && count + player.Guerrieri > player.GuerrieriMax * player.Caserma_Guerrieri)
                {
                    Server.Send(clientGuid, $"Log_Server|Limite raggiunto per addestrare {count} {unitType}. [Limite: {player.GuerrieriMax * player.Caserma_Guerrieri}]");
                    Console.WriteLine($"Limite raggiunto per addestrare {count} {unitType}. [Limite: {player.GuerrieriMax * player.Caserma_Guerrieri}]");
                    return;
                }
                else if (unitType == "Lanciere" && count + player.Lancieri > player.LancieriMax * player.Caserma_Lancieri)
                {
                    Server.Send(clientGuid, $"Log_Server|Limite raggiunto per addestrare {count} {unitType}. [Limite: {player.LancieriMax * player.Caserma_Lancieri}]");
                    Console.WriteLine($"Limite raggiunto per addestrare {count} {unitType}.[Limite: {player.LancieriMax * player.Caserma_Lancieri}]");
                    return;
                }
                else if (unitType == "Arciere" && count + player.Arceri > player.ArceriMax * player.Caserma_Arceri)
                {
                    Server.Send(clientGuid, $"Log_Server|Limite raggiunto per addestrare {count} {unitType}. [Limite: {player.ArceriMax * player.Caserma_Arceri}]");
                    Console.WriteLine($"Limite raggiunto per addestrare {count} {unitType}. [Limite: {player.ArceriMax * player.Caserma_Arceri}]");
                    return;
                }
                else if (unitType == "Catapulta" && count + player.Catapulte > player.CatapulteMax * player.Caserma_Catapulte)
                {
                    Server.Send(clientGuid, $"Log_Server|Limite raggiunto per addestrare {count} {unitType}. [Limite: {player.CatapulteMax * player.Caserma_Catapulte}]");
                    Console.WriteLine($"Limite raggiunto per addestrare {count} {unitType}. [Limite: {player.CatapulteMax * player.Caserma_Catapulte}]");
                    return;
                }

                if (Cibo >= unitCost.Cibo * count &&
                    Legno >= unitCost.Legno * count &&
                    Pietra >= unitCost.Pietra * count &&
                    Ferro >= unitCost.Ferro * count &&
                    Oro >= unitCost.Oro * count &&
                    Popolazione >= unitCost.Popolazione * count &&
                    Spade >= unitCost.Spade * count &&
                    Lance >= unitCost.Lance * count &&
                    Archi >= unitCost.Archi * count &&
                    Scudi >= unitCost.Scudi * count &&
                    Armature >= unitCost.Armature * count)
                {
                    Cibo -= unitCost.Cibo * count;
                    Legno -= unitCost.Legno * count;
                    Pietra -= unitCost.Pietra * count;
                    Ferro -= unitCost.Ferro * count;
                    Oro -= unitCost.Oro * count;
                    Popolazione -= unitCost.Popolazione * count;
                    Spade -= unitCost.Spade * count;
                    Lance -= unitCost.Lance * count;
                    Archi -= unitCost.Archi * count;
                    Scudi -= unitCost.Scudi * count;
                    Armature -= unitCost.Armature * count;

                    Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per l'addestramento di {count} {unitType}:\r\n " +
                        $"Cibo={unitCost.Cibo * count}, " +
                        $"Legno={unitCost.Legno * count}, " +
                        $"Pietra={unitCost.Pietra * count}, " +
                        $"Ferro={unitCost.Ferro * count}, " +
                        $"Oro={unitCost.Oro * count}, " +
                        $"Spade={unitCost.Spade * count}, " +
                        $"Lance={unitCost.Lance * count}, " +
                        $"Archi={unitCost.Archi * count}, " +
                        $"Scudi={unitCost.Scudi * count}, " +
                        $"Armature={unitCost.Armature * count}\r\n");
                    Console.WriteLine($"Risorse utilizzate per l'addestramento di {count} {unitType}:\r\n " +
                        $"Cibo={unitCost.Cibo * count}, " +
                        $"Legno={unitCost.Legno * count}, " +
                        $"Pietra={unitCost.Pietra * count}, " +
                        $"Ferro={unitCost.Ferro * count}, " +
                        $"Oro={unitCost.Oro * count}, " +
                        $"Spade={unitCost.Spade * count}, " +
                        $"Lance={unitCost.Lance * count}, " +
                        $"Archi={unitCost.Archi * count}, " +
                        $"Scudi={unitCost.Scudi * count}, " +
                        $"Armature={unitCost.Armature * count}\r\n");

                    if (!recruitQueues.ContainsKey(unitType))
                        recruitQueues[unitType] = new Queue<RecruitTask>();

                    int tempoAddestramentoInSecondi = Convert.ToInt32(unitCost.TempoReclutamento - player.Ricerca_Addestramento);
                    for (int i = 0; i < count; i++)
                        recruitQueues[unitType].Enqueue(new RecruitTask(unitType, tempoAddestramentoInSecondi));

                    if (!currentRecruitTasks.ContainsKey(unitType))
                        currentRecruitTasks[unitType] = null;
                    
                    if (currentRecruitTasks[unitType] == null)
                        StartNextRecruitment(unitType);
                }
                else
                {
                    Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per addestrare {count} {unitType}.");
                    Console.WriteLine($"Risorse insufficienti per addestrare {count} {unitType}.");
                }
            }
            public async void LoadQueueTrainUnits(string unitType, int count, Player player)
            {
                var unitCost = GetUnitCost(unitType);
                if (!recruitQueues.ContainsKey(unitType))
                    recruitQueues[unitType] = new Queue<RecruitTask>();
                
                int tempoAddestramentoInSecondi = Convert.ToInt32(unitCost.TempoReclutamento - player.Ricerca_Addestramento);
                for (int i = 0; i < count; i++)
                    recruitQueues[unitType].Enqueue(new RecruitTask(unitType, tempoAddestramentoInSecondi));
                
                if (!currentRecruitTasks.ContainsKey(unitType))
                    currentRecruitTasks[unitType] = null;

                if (currentRecruitTasks[unitType] == null)
                    StartNextRecruitment(unitType);
            }
            private void StartNextRecruitment(string unitType)
            {
                if (recruitQueues[unitType].Count > 0)
                {
                    currentRecruitTasks[unitType] = recruitQueues[unitType].Dequeue();
                    currentRecruitTasks[unitType].Start();
                    //Console.WriteLine($"Addestramento di un'unità {unitType} iniziato, completamento previsto in {currentRecruitTasks[unitType].DurationInSeconds} secondi.");
                }
                else
                    currentRecruitTasks[unitType] = null;
            }
            public void CompleteRecruitment(Guid clientGuid)
            {
                foreach (var unitType in currentRecruitTasks.Keys)
                {
                    var currentTask = currentRecruitTasks[unitType];
                    if (currentTask != null && currentTask.IsComplete())
                    {
                        switch (unitType)
                        {
                            case "Arciere":
                                Arceri++;
                                break;
                            case "Guerriero":
                                Guerrieri++;
                                break;
                            case "Lanciere":
                                Lancieri++;
                                break;
                            case "Catapulta":
                                Catapulte++;
                                break;
                            default:
                                Console.WriteLine($"{unitType} addestrato!");
                                break;
                        }
                        Server.Send(clientGuid, $"Log_Server|{unitType} addestrato!\n\r");
                        StartNextRecruitment(unitType);
                    }
                }
            }
            public bool IsRecruiting()
            {
                return currentRecruitTasks.Values.Any(task => task != null);
            }
            private Esercito.CostoReclutamento GetUnitCost(string unitType)
            {
                return unitType switch
                {
                    "Guerriero" => Esercito.CostoReclutamento.Guerriero,
                    "Lanciere" => Esercito.CostoReclutamento.Lanciere,
                    "Arciere" => Esercito.CostoReclutamento.Arciere,
                    "Catapulta" => Esercito.CostoReclutamento.Catapulta,
                    _ => null,
                };
            }
            public void SetBuildings(int fattoria, int segheria, int cavaPietra, int mineraFerro, int mineraOro, int abitazioni, int ProdSp, int ProdLan, int ProdArc, int ProdScud, int ProdArmat, int ProdFrecce, int cas_Gu, int cas_Lan, int cas_Arc, int cas_Cat)
            {
                this.Fattoria = fattoria;
                this.Segheria = segheria;
                this.CavaPietra = cavaPietra;
                this.MinieraFerro = mineraFerro;
                this.MinieraOro = mineraOro;
                this.Abitazioni = abitazioni;
                this.ProduzioneSpade = ProdSp;
                this.ProduzioneLance = ProdLan;
                this.ProduzioneArchi = ProdArc;
                this.ProduzioneScudi = ProdScud;
                this.ProduzioneArmature = ProdArmat;
                this.ProduzioneFrecce = ProdFrecce;
                this.Caserma_Guerrieri = cas_Gu;
                this.Caserma_Lancieri = cas_Lan;
                this.Caserma_Arceri = cas_Arc;
                this.Caserma_Catapulte = cas_Cat;
            }
            public Dictionary<string, int> GetQueuedBuildings()
            {
                var queuedBuildings = new Dictionary<string, int>();
                foreach (var queue in constructionQueues)
                {
                    queuedBuildings[queue.Key] = queue.Value.Count;
                }
                return queuedBuildings;
            }
            public Dictionary<string, int> GetQueuedUnits()
            {
                var queuedUnits = new Dictionary<string, int>();
                foreach (var queue in recruitQueues)
                {
                    queuedUnits[queue.Key] = queue.Value.Count;
                }
                return queuedUnits;
            }
        }
        
    }
}

