using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Server_Strategico.Variabili;


namespace Server_Strategico
{
    internal class dati
    {
        public static string Difficoltà = "1";
        public static string Versione = "0.1.12";
        public static string Server = "Italy";

        public static double forza_Esercito_Att_PVE = 0;
        public static double forza_Esercito_Att_PVP = 0;

    }

    internal class Variabili
    {
        public class Barbari
        {
            public int Guerrieri { get; set; }
            public int Lancieri { get; set; }
            public int Arceri { get; set; }
            public int Catapulte { get; set; }
            public static Barbari PVP = new Barbari
            {
                Guerrieri = 0,
                Lancieri = 0,
                Arceri = 0,
                Catapulte = 0
            };
        }
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
                Produzione = 1.62,
                TempoCostruzione = 24
            };
            public static Edifici Segheria = new Edifici
            {
                Cibo = 175,
                Legno = 175,
                Pietra = 175,
                Ferro = 175,
                Oro = 175,
                Produzione = 1.46,
                TempoCostruzione = 27
            };
            public static Edifici CavaPietra = new Edifici
            {
                Cibo = 250,
                Legno = 250,
                Pietra = 250,
                Ferro = 250,
                Oro = 250,
                Produzione = 1.22,
                TempoCostruzione = 33
            };
            public static Edifici MinieraFerro = new Edifici
            {
                Cibo = 325,
                Legno = 325,
                Pietra = 325,
                Ferro = 325,
                Oro = 325,
                Produzione = 1.04,
                TempoCostruzione = 38
            };
            public static Edifici MinieraOro = new Edifici
            {
                Cibo = 400,
                Legno = 400,
                Pietra = 400,
                Ferro = 400,
                Oro = 400,
                Produzione = 0.91,
                TempoCostruzione = 46
            };
            public static Edifici Case = new Edifici
            {
                Cibo = 500,
                Legno = 500,
                Pietra = 500,
                Ferro = 500,
                Oro = 500,
                Produzione = 0.03,
                TempoCostruzione = 54
            };
            // Edifici Militari
            public static Edifici Armature = new Edifici
            {
                Cibo = 500,
                Legno = 500,
                Pietra = 500,
                Ferro = 500,
                Oro = 500,
                Produzione = 0.09,
                TempoCostruzione = 49
            };
            public static Edifici ProduzioneSpade = new Edifici
            {
                Cibo = 500,
                Legno = 500,
                Pietra = 500,
                Ferro = 500,
                Oro = 500,
                Produzione = 0.09,
                TempoCostruzione = 49
            };
            public static Edifici ProduzioneLance = new Edifici
            {
                Cibo = 250,
                Legno = 250,
                Pietra = 250,
                Ferro = 250,
                Oro = 250,
                Produzione = 0.09,
                TempoCostruzione = 49
            };
            public static Edifici ProduzioneArchi = new Edifici
            {
                Cibo = 250,
                Legno = 250,
                Pietra = 250,
                Ferro = 250,
                Oro = 250,
                Produzione = 0.09,
                TempoCostruzione = 49
            };
            public static Edifici ProduzioneScudi = new Edifici
            {
                Cibo = 250,
                Legno = 250,
                Pietra = 250,
                Ferro = 250,
                Oro = 250,
                Produzione = 0.09,
                TempoCostruzione = 49
            };
            public static Edifici ProduzioneArmature = new Edifici
            {
                Cibo = 250,
                Legno = 250,
                Pietra = 250,
                Ferro = 250,
                Oro = 250,
                Produzione = 0.09,
                TempoCostruzione = 49
            };
            public static Edifici ProduzioneFrecce = new Edifici
            {
                Cibo = 250,
                Legno = 250,
                Pietra = 250,
                Ferro = 250,
                Oro = 250,
                Produzione = 0.09,
                TempoCostruzione = 49
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
                TempoReclutamento = 18, //55
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
                TempoReclutamento = 23,
                Popolazione = 1
            };
            public static CostoReclutamento Arciere = new CostoReclutamento
            {
                Spade = 0,
                Lance = 0,
                Archi = 1,
                Scudi = 1,
                Armature = 1,

                Cibo = 219,
                Legno = 194,
                Pietra = 123,
                Ferro = 183,
                Oro = 162,
                TempoReclutamento = 31,
                Popolazione = 1
            };
            public static CostoReclutamento Catapulta = new CostoReclutamento
            {
                Spade = 3,
                Lance = 2,
                Archi = 0,
                Scudi = 0,
                Armature = 5,

                Cibo = 311,
                Legno = 327,
                Pietra = 329,
                Ferro = 247,
                Oro = 256,
                TempoReclutamento = 60,
                Popolazione = 5
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
                TempoReclutamento = 19,
                Esperienza = 1
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
                TempoReclutamento = 24,
                Esperienza = 1
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
                TempoReclutamento = 32,
                Esperienza = 2
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
                TempoReclutamento = 61,
                Esperienza = 3
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
            public int Esperienza { get; set; }

            public static Esercito Guerriero = new Esercito
            {
                Salute = 5,
                Attacco = 3,
                Difesa = 3,
                Distanza = 1,
                Salario = 0.16,
                Cibo = 0.32,
                Quantità = 0,
                Esperienza = 1
            };
            public static Esercito Lanciere = new Esercito
            {
                Salute = 6,
                Attacco = 4,
                Difesa = 4,
                Distanza = 2,
                Salario = 0.20,
                Cibo = 0.35,
                Quantità = 0,
                Esperienza = 1
            };
            public static Esercito Arciere = new Esercito
            {
                Salute = 4,
                Attacco = 8,
                Difesa = 3,
                Distanza = 6,
                Salario = 0.25,
                Cibo = 0.41,
                Quantità = 0,
                Esperienza = 2
            };
            public static Esercito Catapulta = new Esercito
            {
                Salute = Guerriero.Salute * 0.75 * CostoReclutamento.Catapulta.Popolazione,
                Attacco = 18,
                Difesa = Guerriero.Salute * 0.75 * CostoReclutamento.Catapulta.Popolazione,
                Distanza = 18,
                Salario = CostoReclutamento.Catapulta.Popolazione * Guerriero.Salario * 0.749,
                Cibo = CostoReclutamento.Catapulta.Popolazione * Guerriero.Cibo * 0.699,
                Quantità = 0,
                Esperienza = 3
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

            public int Guerrieri_Barbari_PVE { get; set; }
            public int Lancieri_Barbari_PVE { get; set; }
            public int Arceri_Barbari_PVE { get; set; }
            public int Catapulte_Barbari_PVE { get; set; }


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
                Fattoria = 0;
                Segheria = 0;
                CavaPietra = 0;
                MinieraFerro = 0;
                MinieraOro = 0;
                Abitazioni = 0;
                //Strutture Militare
                ProduzioneSpade = 0;
                ProduzioneLance = 0;
                ProduzioneArchi = 0;
                ProduzioneScudi = 0;
                ProduzioneArmature = 0;
                ProduzioneFrecce = 0;
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

                Guerrieri_Barbari_PVE = 0;
                Lancieri_Barbari_PVE = 0;
                Arceri_Barbari_PVE = 0;
                Catapulte_Barbari_PVE = 0;

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
                Cibo += Fattoria * Variabili.Edifici.Fattoria.Produzione;
                Legno += Segheria * Variabili.Edifici.Segheria.Produzione;
                Pietra += CavaPietra * Variabili.Edifici.CavaPietra.Produzione;
                Ferro += MinieraFerro * Variabili.Edifici.MinieraFerro.Produzione;
                Oro += MinieraOro * Variabili.Edifici.MinieraOro.Produzione;
                Popolazione += Abitazioni * Variabili.Edifici.Case.Produzione;

                Spade += ProduzioneSpade * Variabili.Edifici.ProduzioneSpade.Produzione;
                Lance += ProduzioneLance * Variabili.Edifici.ProduzioneLance.Produzione;
                Archi += ProduzioneArchi * Variabili.Edifici.ProduzioneArchi.Produzione;
                Scudi += ProduzioneScudi * Variabili.Edifici.ProduzioneScudi.Produzione;
                Armature += ProduzioneArmature * Variabili.Edifici.ProduzioneArmature.Produzione;
                Frecce += ProduzioneFrecce * Variabili.Edifici.ProduzioneFrecce.Produzione;
            }
            public void QueueBuildConstruction(string buildingType, int count, Guid clientGuid)
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

                    Server.Send(clientGuid, $"Log_Server|Risorse consumate per {count} costruzione/i di {buildingType}:\r\n Cibo={buildingCost.Cibo * count}, Legno={buildingCost.Legno * count}, Pietra={buildingCost.Pietra * count}, Ferro={buildingCost.Ferro * count}, Oro={buildingCost.Oro * count}\r\n");
                    Console.WriteLine($"Risorse consumate per {count} costruzione/i di {buildingType}:\r\n Cibo={buildingCost.Cibo * count}, Legno={buildingCost.Legno * count}, Pietra={buildingCost.Pietra * count}, Ferro={buildingCost.Ferro * count}, Oro={buildingCost.Oro * count}\r\n");

                    // Verifica se la coda di costruzione esiste per questo tipo di edificio, altrimenti creala
                    if (!constructionQueues.ContainsKey(buildingType))
                        constructionQueues[buildingType] = new Queue<ConstructionTask>();

                    // Aggiungi i task di costruzione alla coda
                    int tempoCostruzioneInSecondi = Convert.ToInt32(buildingCost.TempoCostruzione);
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
            private Variabili.Edifici GetBuildingCost(string buildingType)
            {
                // Restituisci i costi dell'edificio in base al tipo
                return buildingType switch
                {
                    "Fattoria" => Variabili.Edifici.Fattoria,
                    "Segheria" => Variabili.Edifici.Segheria,
                    "CavaPietra" => Variabili.Edifici.CavaPietra,
                    "MinieraFerro" => Variabili.Edifici.MinieraFerro,
                    "MinieraOro" => Variabili.Edifici.MinieraOro,
                    "Case" => Variabili.Edifici.Case,

                    "ProduzioneSpade" => Variabili.Edifici.ProduzioneSpade,
                    "ProduzioneLancie" => Variabili.Edifici.ProduzioneLance,
                    "ProduzioneArchi" => Variabili.Edifici.ProduzioneArchi,
                    "ProduzioneScudi" => Variabili.Edifici.ProduzioneScudi,
                    "ProduzioneArmature" => Variabili.Edifici.Armature,
                    "ProduzioneFrecce" => Variabili.Edifici.ProduzioneFrecce,
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

            public async void QueueTrainUnits(string unitType, int count, Guid clientGuid)
            {
                var unitCost = GetUnitCost(unitType);

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

                    Server.Send(clientGuid, $"Log_Server|Risorse consumate per l'addestramento di {count} {unitType}:\r\n " +
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
                    Console.WriteLine($"Risorse consumate per l'addestramento di {count} {unitType}:\r\n " +
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
                    {
                        recruitQueues[unitType] = new Queue<RecruitTask>();
                    }

                    int tempoAddestramentoInSecondi = Convert.ToInt32(unitCost.TempoReclutamento);
                    for (int i = 0; i < count; i++)
                    {
                        recruitQueues[unitType].Enqueue(new RecruitTask(unitType, tempoAddestramentoInSecondi));
                    }

                    if (!currentRecruitTasks.ContainsKey(unitType))
                    {
                        currentRecruitTasks[unitType] = null;
                    }

                    if (currentRecruitTasks[unitType] == null)
                    {
                        StartNextRecruitment(unitType);
                    }
                }
                else
                {
                    Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per addestrare {count} {unitType}.");
                    Console.WriteLine($"Risorse insufficienti per addestrare {count} {unitType}.");
                }
                
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
            private CostoReclutamento GetUnitCost(string unitType)
            {
                return unitType switch
                {
                    "Guerriero" => Variabili.CostoReclutamento.Guerriero,
                    "Lanciere" => Variabili.CostoReclutamento.Lanciere,
                    "Arciere" => Variabili.CostoReclutamento.Arciere,
                    "Catapulta" => Variabili.CostoReclutamento.Catapulta,
                    _ => null,
                };
            }
        }
        public class GameServer
        {
            private Dictionary<string, Player> players = new Dictionary<string, Player>();
            public async Task<bool> AddPlayer(string username, string password, Guid guid)
            {
                if (!players.ContainsKey(username))
                {
                    players.Add(username, new Player(username, password, guid));
                    await Server.NewPlayer(username, password);
                    return true;
                }
                else
                {
                    return false;
                    throw new ArgumentException($"Player già presente con questo username {username} e password {password}.");
                }
            }
            public async Task<bool> AddFakePlayer(string username, string password)
            {
                if (!players.ContainsKey(username))
                {
                    //players.Add(username, new Player(username, password, null));
                    await Server.NewPlayer(username, password);
                    return true;
                }
                else
                {
                    return false;
                    throw new ArgumentException($"Fake Player già presente con questo username {username} e password {password}.");
                }
            }

            public Player GetPlayer(string username, string password)
            {
                if (players.TryGetValue(username, out Player player))
                {
                    if (player.ValidatePassword(password))
                        return player;
                    else
                    {
                        return null;
                        throw new UnauthorizedAccessException("Invalid password.");
                    }
                }
                else
                {
                    return null;
                    throw new KeyNotFoundException("Player not found.");
                }

            }
            public Player GetPlayer_Data(string username)
            {
                if (players.TryGetValue(username, out Player player))
                    return player;
                else
                {
                    return null;
                    throw new KeyNotFoundException("Player not found.");
                }

            }
            public void Lista_Player_manual()
            {
                Console.WriteLine($"Numero Giocatori: {players.Count()}");
                foreach (var item in players)
                {
                    Console.WriteLine($"Giocatore: {item.Value.Username} Guid: {item.Value.guid_Player}, Livello: {item.Value.Livello}, Esperienza: {item.Value.Esperienza}");
                    if(!Server.Utenti_PVP.Contains($"{item.Value.Username}, Livello: {item.Value.Livello}, Esperienza: {item.Value.Esperienza}"))
                        Server.Utenti_PVP.Add($"{item.Value.Username}, Livello: {item.Value.Livello}, Esperienza: {item.Value.Esperienza}");
                }
            }
            public void Lista_Player_Auto()
            {
                foreach (var item in players)
                    if (!Server.Utenti_PVP.Contains($"{item.Value.Username}, Livello: {item.Value.Livello}, Esperienza: {item.Value.Esperienza}"))
                        Server.Utenti_PVP.Add($"{item.Value.Username}, Livello: {item.Value.Livello}, Esperienza: {item.Value.Esperienza}");
            }
            public async Task<bool> Check_Username_Player(string username)
            {
                foreach (var item in players)
                    if (item.Value.Username.Contains(username))
                        return false;
                return true;

            }
            public void Auto_Update_Clients()
            {
                foreach (var client in Server.Client_Connessi)
                    foreach (var item in players)
                        if (item.Value.guid_Player == client)
                            ServerConnection.Update_Data(item.Value.guid_Player, item.Value.Username, item.Value.Password);
            }
            public async Task RunGameLoopAsync(CancellationToken cancellationToken)
            {
                int i = 0;
                while (!cancellationToken.IsCancellationRequested)
                {
                    foreach (var player in players.Values)
                    {
                        player.CompleteBuilds(player.guid_Player);
                        player.CompleteRecruitment(player.guid_Player);
                        player.ProduceResources();
                        if (i >= 1)
                        {
                            Server.servers_.Lista_Player_Auto();
                            i = 0;
                        }

                        player.forza_Esercito =
                        player.Guerrieri * ((Variabili.Esercito.Guerriero.Salute * 0.33) + (Variabili.Esercito.Guerriero.Attacco * 0.72)) +
                        player.Lancieri * ((Variabili.Esercito.Lanciere.Salute * 0.33) + (Variabili.Esercito.Lanciere.Attacco * 0.72)) +
                        player.Arceri * ((Variabili.Esercito.Arciere.Salute * 0.33) + (Variabili.Esercito.Arciere.Attacco * 0.72)) +
                        player.Catapulte * ((Variabili.Esercito.Catapulta.Salute * 0.33) + (Variabili.Esercito.Catapulta.Attacco * 0.72));

                        Auto_Update_Clients();
                        Esperienza.LevelUp(player);
                        if (Server_Strategico.Barbari.start == false)
                        {
                            Server_Strategico.Barbari.start = true;
                            Task.Run(() => Server_Strategico.Barbari.Barbari_PVP(players));
                        }
                        if (player.Player_Loop == false)
                        {
                            Task.Run(() => Server_Strategico.Barbari.Barbari_PVE(player));
                            player.Player_Loop = true;

                        }
                        i++;

                        // Puoi aggiungere altri metodi per gestire battaglie, commercio, ecc.
                    }
                    await Task.Delay(1000); // Ciclo ogni secondo, o regola il ritardo come necessario
                }
            }
        }
    }
}

