using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Server_Strategico.Variabili;

namespace Server_Strategico
{
    internal class Variabili
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

        public class Player
        {
            public string Username { get; set; }
            public int Fattoria { get; private set; }
            public int Segheria { get; private set; }
            public int CavaPietra { get; private set; }
            public int MinieraFerro { get; private set; }
            public int MinieraOro { get; private set; }

            public int Case { get; private set; }
            public int ProduzioneSpade { get; private set; }
            public int ProduzioneLance { get; private set; }
            public int ProduzioneArchi { get; private set; }
            public int ProduzioneScudi { get; private set; }
            public int ProduzioneArmature { get; private set; }

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

            public int Arceri { get; set; }
            public int Guerrieri { get; set; }
            public int Lancieri { get; set; }
            public int Catapulte { get; set; }


            private Dictionary<string, Queue<ConstructionTask>> constructionQueues; // Dizionario per memorizzare le code di costruzione per ogni tipo di edificio
            private Dictionary<string, ConstructionTask> currentTasks; // Dizionario per memorizzare il task di costruzione attuale per ogni tipo di edificio

            private Dictionary<string, Queue<RecruitTask>> recruitQueues;  // Dizionario per memorizzare le code di reclutamento per ogni tipo di unità
            private Dictionary<string, RecruitTask> currentRecruitTasks;  // Dizionario per memorizzare il task di reclutamento attuale per ogni tipo di unità

            public Player(string username)
            {
                Username = username;
                //Strutture Civile
                Fattoria = 0;
                Segheria = 0;
                CavaPietra = 0;
                MinieraFerro = 0;
                MinieraOro = 0;
                //Strutture Militare
                Case = 0;
                ProduzioneSpade = 0;
                ProduzioneLance = 0;
                ProduzioneArchi = 0;
                ProduzioneScudi = 0;
                ProduzioneArmature = 0;
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
                Arceri = 0;
                Guerrieri = 0;
                Lancieri = 0;
                Catapulte = 0;

                constructionQueues = new Dictionary<string, Queue<ConstructionTask>>();
                currentTasks = new Dictionary<string, ConstructionTask>();

                recruitQueues = new Dictionary<string, Queue<RecruitTask>>();
                currentRecruitTasks = new Dictionary<string, RecruitTask>();
            }

            public void ProduceResources() //produzione risorse
            {
                Cibo += Fattoria * Variabili.Edifici.Fattoria.Produzione;
                Legno += Segheria * Variabili.Edifici.Segheria.Produzione;
                Pietra += CavaPietra * Variabili.Edifici.CavaPietra.Produzione;
                Ferro += MinieraFerro * Variabili.Edifici.MinieraFerro.Produzione;
                Oro += MinieraOro * Variabili.Edifici.MinieraOro.Produzione;
                Popolazione += Case * Variabili.Edifici.Case.Produzione;

                Console.WriteLine($"{Username} ha prodotto: Cibo={Cibo.ToString("0.00")}, Legno={Legno.ToString("0.00")}, Pietra={Pietra.ToString("0.00")}, Ferro={Ferro.ToString("0.00")}, Oro={Oro.ToString("0.00")}, Popolazione={Popolazione.ToString("0.00")}");
            }

            public void QueueBuildConstruction(string buildingType, int count)
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

                    Console.WriteLine($"Risorse consumate per {count} costruzione/i di {buildingType}: Cibo={buildingCost.Cibo * count}, Legno={buildingCost.Legno * count}, Pietra={buildingCost.Pietra * count}, Ferro={buildingCost.Ferro * count}, Oro={buildingCost.Oro * count}");

                    // Verifica se la coda di costruzione esiste per questo tipo di edificio, altrimenti creala
                    if (!constructionQueues.ContainsKey(buildingType))
                    {
                        constructionQueues[buildingType] = new Queue<ConstructionTask>();
                    }

                    // Aggiungi i task di costruzione alla coda
                    int tempoCostruzioneInSecondi = Convert.ToInt32(buildingCost.TempoCostruzione);
                    for (int i = 0; i < count; i++)
                    {
                        constructionQueues[buildingType].Enqueue(new ConstructionTask(buildingType, tempoCostruzioneInSecondi));
                    }

                    // Inizializza l'entry in currentTasks se non esiste
                    if (!currentTasks.ContainsKey(buildingType))
                    {
                        currentTasks[buildingType] = null;
                    }

                    // Se non c'è nessuna costruzione in corso per questo tipo, inizia la prima
                    if (currentTasks[buildingType] == null)
                    {
                        StartNextConstruction(buildingType);
                    }
                }
                else
                {
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

            public void CompleteBuilds() // Metodo per completare le costruzioni in corso
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
                            case "Cava di pietra":
                                CavaPietra++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "Miniera di ferro":
                                MinieraFerro++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            case "Miniera D'oro":
                                MinieraOro++;
                                Console.WriteLine($"Costruzione completata {buildingType} costruita!");
                                break;
                            // Aggiungi case per altri tipi di costruzioni
                            default:
                                Console.WriteLine($"Costruzione {buildingType} Annullata!!");
                                break;
                        }

                        // Avvia la prossima costruzione per questo tipo di edificio
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

            public void QueueTrainUnits(string unitType, int count)
            {
                var unitCost = GetUnitCost(unitType);

                if (Cibo >= unitCost.Cibo * count &&
                    Legno >= unitCost.Legno * count &&
                    Pietra >= unitCost.Pietra * count &&
                    Ferro >= unitCost.Ferro * count &&
                    Oro >= unitCost.Oro * count &&
                    Popolazione >= unitCost.Popolazione * count)
                {
                    Cibo -= unitCost.Cibo * count;
                    Legno -= unitCost.Legno * count;
                    Pietra -= unitCost.Pietra * count;
                    Ferro -= unitCost.Ferro * count;
                    Oro -= unitCost.Oro * count;
                    Popolazione -= unitCost.Popolazione * count;

                    Console.WriteLine($"Risorse consumate per l'addestramento di {count} {unitType}: Cibo={unitCost.Cibo * count}, Legno={unitCost.Legno * count}, Pietra={unitCost.Pietra * count}, Ferro={unitCost.Ferro * count}, Oro={unitCost.Oro * count}");

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
                    Console.WriteLine($"Risorse insufficienti per addestrare {count} {unitType}.");
                }
            }

            private void StartNextRecruitment(string unitType)
            {
                if (recruitQueues[unitType].Count > 0)
                {
                    currentRecruitTasks[unitType] = recruitQueues[unitType].Dequeue();
                    currentRecruitTasks[unitType].Start();
                    Console.WriteLine($"Addestramento di un'unità {unitType} iniziato, completamento previsto in {currentRecruitTasks[unitType].DurationInSeconds} secondi.");
                }
                else
                    currentRecruitTasks[unitType] = null;
            }

            public void CompleteRecruitment()
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

            public void AddPlayer(string username)
            {
                if (!players.ContainsKey(username))
                {
                    players.Add(username, new Player(username));
                }
            }

            public Player GetPlayer(string username)
            {
                players.TryGetValue(username, out Player player);
                return player;
            }

            public async Task RunGameLoopAsync(CancellationToken cancellationToken)
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    foreach (var player in players.Values)
                    {
                        player.CompleteBuilds();
                        player.CompleteRecruitment();
                        player.ProduceResources();

                        // Puoi aggiungere altri metodi per gestire battaglie, commercio, ecc.
                    }
                    Console.WriteLine("");
                    await Task.Delay(1000); // Ciclo ogni secondo, o regola il ritardo come necessario
                }
            }
        }
    }
}

