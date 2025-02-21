using System.Text;
using System;
using System.Text.Json;
using static Server_Strategico.Variabili;

namespace Server_Strategico
{
    internal class GameSave
    {
        private static readonly string SavePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
            "Server Strategico",
            "Saves"
        );

        public static void Initialize()
        {
            if (!Directory.Exists(SavePath)) // Crea la directory se non esiste
                Directory.CreateDirectory(SavePath);
        }

        public static async Task SavePlayer(Player player)
        {
            try
            {
                var playerData = new PlayerSaveData
                {
                    Username = player.Username,
                    Password = player.Password,
                    Livello = player.Livello,
                    Esperienza = player.Esperienza,
                    
                    // Risorse
                    Cibo = player.Cibo,
                    Legno = player.Legno,
                    Pietra = player.Pietra,
                    Ferro = player.Ferro,
                    Oro = player.Oro,
                    Popolazione = player.Popolazione,

                    Spade = player.Spade,
                    Lance = player.Lance,
                    Archi = player.Archi,
                    Scudi = player.Scudi,
                    Armature = player.Armature,
                    Frecce = player.Frecce,

                    // Edifici
                    Fattoria = player.Fattoria,
                    Segheria = player.Segheria,
                    CavaPietra = player.CavaPietra,
                    MinieraFerro = player.MinieraFerro,
                    MinieraOro = player.MinieraOro,
                    Abitazioni = player.Abitazioni,

                    ProduzioneSpade = player.ProduzioneSpade,
                    ProduzioneLance = player.ProduzioneLance,
                    ProduzioneArchi = player.ProduzioneArchi,
                    ProduzioneScudi = player.ProduzioneScudi,
                    ProduzioneArmature = player.ProduzioneArmature,
                    ProduzioneFrecce = player.ProduzioneFrecce,

                    CasermaGuerrieri = player.Caserma_Guerrieri,
                    CasermaLancieri = player.Caserma_Lancieri,
                    CasermaArceri = player.Caserma_Arceri,
                    CasermaCatapulte = player.Caserma_Catapulte,

                    // Esercito
                    Guerrieri = player.Guerrieri,
                    Lancieri = player.Lancieri,
                    Arceri = player.Arceri,
                    Catapulte = player.Catapulte,

                    // Nuovi dati da salvare
                    GuerrieriMax = player.GuerrieriMax,
                    LancieriMax = player.LancieriMax,
                    ArceriMax = player.ArceriMax,
                    CatapulteMax = player.CatapulteMax,

                    SaluteCancello = player.SaluteCancello,
                    SaluteCancelloMax = player.SaluteCancelloMax,
                    SaluteMura = player.SaluteMura,
                    SaluteMuraMax = player.SaluteMuraMax,
                    SaluteTorri = player.SaluteTorri,
                    SaluteTorriMax = player.SaluteTorriMax,
                    SaluteCastello = player.SaluteCastello,
                    SaluteCastelloMax = player.SaluteCastelloMax,

                    // Aggiungi queste proprietà per le code
                    BuildingQueues = player.GetQueuedBuildings(),
                    RecruitmentQueues = player.GetQueuedUnits(),

                    // Dati dei barbari PVE
                    Guerrieri_Barbari_PVE = player.Guerrieri_Barbari_PVE,
                    Lancieri_Barbari_PVE = player.Lancieri_Barbari_PVE,
                    Arceri_Barbari_PVE = player.Arceri_Barbari_PVE,
                    Catapulte_Barbari_PVE = player.Catapulte_Barbari_PVE
                };

                string fileName = Path.Combine(SavePath, $"{player.Username}.json");
                string jsonString = JsonSerializer.Serialize(playerData, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(fileName, jsonString);

                Console.WriteLine($"[GameSave] Salvati i dati del giocatore {player.Username}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GameSave] Errore durante il salvataggio: {ex.Message}");
            }
        }

        public static async Task<bool> LoadPlayer(string username, string password)
        {
            try
            {
                string fileName = Path.Combine(SavePath, $"{username}.json");
                if (!File.Exists(fileName))
                {
                    Console.WriteLine($"[GameSave] Nessun salvataggio trovato per {username}");
                    return false;
                }

                string jsonString = await File.ReadAllTextAsync(fileName);
                var playerData = JsonSerializer.Deserialize<PlayerSaveData>(jsonString);

                if (playerData.Password != password)
                {
                    Console.WriteLine($"[GameSave] Password non valida per {username}");
                    return false;
                }

                // Aggiorna il giocatore esistente con i dati salvati
                var player = Server.servers_.GetPlayer(username, password);
                if (player != null)
                {
                    player.Livello = playerData.Livello;
                    player.Esperienza = playerData.Esperienza;
                    
                    // Risorse
                    player.Cibo = playerData.Cibo;
                    player.Legno = playerData.Legno;
                    player.Pietra = playerData.Pietra;
                    player.Ferro = playerData.Ferro;
                    player.Oro = playerData.Oro;
                    player.Popolazione = playerData.Popolazione;

                    player.Spade = playerData.Spade;
                    player.Lance = playerData.Lance;
                    player.Archi = playerData.Archi;
                    player.Scudi = playerData.Scudi;
                    player.Armature = playerData.Armature;
                    player.Frecce = playerData.Frecce;

                    // Edifici
                    player.SetBuildings(
                        playerData.Fattoria,
                        playerData.Segheria, 
                        playerData.CavaPietra,
                        playerData.MinieraFerro,
                        playerData.MinieraOro,
                        playerData.Abitazioni,
                        playerData.ProduzioneSpade,
                        playerData.ProduzioneLance,
                        playerData.ProduzioneArchi,
                        playerData.ProduzioneScudi,
                        playerData.ProduzioneArmature,
                        playerData.ProduzioneFrecce,
                        playerData.CasermaGuerrieri,
                        playerData.CasermaLancieri,
                        playerData.CasermaArceri,
                        playerData.CasermaCatapulte
                    );

                    // Esercito
                    player.Guerrieri = playerData.Guerrieri;
                    player.Lancieri = playerData.Lancieri;
                    player.Arceri = playerData.Arceri;
                    player.Catapulte = playerData.Catapulte;

                    // Ripristina i nuovi dati
                    player.GuerrieriMax = playerData.GuerrieriMax;
                    player.LancieriMax = playerData.LancieriMax;
                    player.ArceriMax = playerData.ArceriMax;
                    player.CatapulteMax = playerData.CatapulteMax;

                    player.SaluteCancello = playerData.SaluteCancello;
                    player.SaluteCancelloMax = playerData.SaluteCancelloMax;
                    player.SaluteMura = playerData.SaluteMura;
                    player.SaluteMuraMax = playerData.SaluteMuraMax;
                    player.SaluteTorri = playerData.SaluteTorri;
                    player.SaluteTorriMax = playerData.SaluteTorriMax;
                    player.SaluteCastello = playerData.SaluteCastello;
                    player.SaluteCastelloMax = playerData.SaluteCastelloMax;

                    //Ricerca

                    // Ripristina le code
                    foreach (var building in playerData.BuildingQueues)
                    {
                        if (building.Value > 0)
                            player.LoadQueueBuildConstruction(building.Key, building.Value, player.guid_Player);
                    }
                    if (playerData.BuildingQueues.Count() != 0)
                    {
                        Server.Send(player.guid_Player, $"Log_Server|Strutture in Coda ripristinate\r\n");
                        Console.WriteLine($"Log_Server|Strutture in Coda ripristinate\r\n");
                    }

                    foreach (var unit in playerData.RecruitmentQueues)
                    {
                        if (unit.Value > 0)
                            player.LoadQueueTrainUnits(unit.Key, unit.Value, player.guid_Player);
                    }
                    if (playerData.RecruitmentQueues.Count() != 0)
                    {
                        Server.Send(player.guid_Player, $"Log_Server|Unità in coda ripristinate\r\n");
                        Console.WriteLine($"Log_Server|Unità in coda ripristinate\r\n");
                    }

                    // Dati dei barbari PVE
                    player.Guerrieri_Barbari_PVE = playerData.Guerrieri_Barbari_PVE;
                    player.Lancieri_Barbari_PVE = playerData.Lancieri_Barbari_PVE;
                    player.Arceri_Barbari_PVE = playerData.Arceri_Barbari_PVE;
                    player.Catapulte_Barbari_PVE = playerData.Catapulte_Barbari_PVE;

                    Console.WriteLine($"[GameSave] Caricati i dati del giocatore {username}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GameSave] Errore durante il caricamento: {ex.Message}");
            }
            return false;
        }

        public static async Task SaveBarbariPVP()
        {
            var barbariData = new
            {
                Guerrieri = Variabili.Barbari.PVP.Guerrieri,
                Lancieri = Variabili.Barbari.PVP.Lancieri,
                Arceri = Variabili.Barbari.PVP.Arceri,
                Catapulte = Variabili.Barbari.PVP.Catapulte
            };

            string fileName = Path.Combine(SavePath, "BarbariPVP.json");
            string jsonString = JsonSerializer.Serialize(barbariData, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(fileName, jsonString);

            Console.WriteLine("[GameSave] Dati dei barbari PVP salvati.");
        }

        private class PlayerSaveData
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public int Livello { get; set; }
            public int Esperienza { get; set; }
            
            // Risorse
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

            // Edifici
            public int Fattoria { get; set; }
            public int Segheria { get; set; }
            public int CavaPietra { get; set; }
            public int MinieraFerro { get; set; }
            public int MinieraOro { get; set; }
            public int Abitazioni { get; set; }

            public int ProduzioneSpade { get; set; }
            public int ProduzioneLance { get; set; }
            public int ProduzioneArchi { get; set; }
            public int ProduzioneScudi { get; set; }
            public int ProduzioneArmature { get; set; }
            public int ProduzioneFrecce { get; set; }

            public int CasermaGuerrieri { get; set; }
            public int CasermaLancieri { get; set; }
            public int CasermaArceri { get; set; }
            public int CasermaCatapulte { get; set; }

            // Esercito
            public int Guerrieri { get; set; }
            public int Lancieri { get; set; }
            public int Arceri { get; set; }
            public int Catapulte { get; set; }


            // Nuovi dati da salvare
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

            // Aggiungi queste proprietà per le code
            public Dictionary<string, int> BuildingQueues { get; set; }
            public Dictionary<string, int> RecruitmentQueues { get; set; }

            // Dati dei barbari PVE
            public int Guerrieri_Barbari_PVE { get; set; }
            public int Lancieri_Barbari_PVE { get; set; }
            public int Arceri_Barbari_PVE { get; set; }
            public int Catapulte_Barbari_PVE { get; set; }
        }
    }
} 