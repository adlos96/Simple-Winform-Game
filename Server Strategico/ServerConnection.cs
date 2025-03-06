using System;
using System.Text;
using WatsonTcp;

namespace Server_Strategico
{
    internal class ServerConnection
    {
        public static string stringa_Base = "";
        public static async void HandleClientRequest(MessageReceivedEventArgs requestData)
        {
            var client = requestData.Client.ToString();
            var clientGuid = requestData.Client.Guid;
            var messaggioRicevuto = Encoding.UTF8.GetString(requestData.Data);

            //Variabili.server_Log.Add()
           Console.WriteLine("             ** Comunicazione Client **  ");
           Console.WriteLine("-----------------------------", "standard");
           Console.WriteLine($"[ServerConnection|ClientRequest] > Client:      {client}");
           Console.WriteLine($"[ServerConnection|ClientRequest] > Guid:        [{clientGuid}]");
           Console.WriteLine($"[ServerConnection|ClientRequest] > Messaggio:   [{messaggioRicevuto}]");

            if (!messaggioRicevuto.Contains("|"))
            {
                Console.WriteLine($"[Errore|ServerConnection] >> Messaggio ricevuto: {messaggioRicevuto}");
                return;
            }
            var msgArgs = messaggioRicevuto.Split('|'); // Composto da 3 part1 0|1|2 -> 0 = percorso file
            if (msgArgs.Length == 0)
            {
                Console.WriteLine("[Errore|ServerConnection] >> needed 1 args");
                return;
            }
            var player = Server.servers_.GetPlayer(msgArgs[1], msgArgs[2]);
            switch (msgArgs[0])
            {
                case "Update_Data": Update_Data(clientGuid, msgArgs[1], msgArgs[2]); break;
                case "Login":
                    bool login = await Login(msgArgs[1], msgArgs[2], clientGuid);
                    if (login == true) Server.Send(clientGuid, "Login|true");
                    else
                        Server.Send(clientGuid, "Login|false");
                    Update_Data(clientGuid, msgArgs[1], msgArgs[2]);
                    break;
                case "Costruzione":
                    if (Convert.ToInt32(msgArgs[3]) > 0) player.QueueBuildConstruction("Fattoria", Convert.ToInt32(msgArgs[3]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[4]) > 0) player.QueueBuildConstruction("Segheria", Convert.ToInt32(msgArgs[4]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[5]) > 0) player.QueueBuildConstruction("CavaPietra", Convert.ToInt32(msgArgs[5]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[6]) > 0) player.QueueBuildConstruction("MinieraFerro", Convert.ToInt32(msgArgs[6]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[7]) > 0) player.QueueBuildConstruction("MinieraOro", Convert.ToInt32(msgArgs[7]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[8]) > 0) player.QueueBuildConstruction("Case", Convert.ToInt32(msgArgs[8]), clientGuid, player); // Costruisci fattorie
                    
                    if (Convert.ToInt32(msgArgs[9]) > 0) player.QueueBuildConstruction("ProduzioneSpade", Convert.ToInt32(msgArgs[9]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[10]) > 0) player.QueueBuildConstruction("ProduzioneLancie", Convert.ToInt32(msgArgs[10]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[11]) > 0) player.QueueBuildConstruction("ProduzioneArchi", Convert.ToInt32(msgArgs[11]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[12]) > 0) player.QueueBuildConstruction("ProduzioneScudi", Convert.ToInt32(msgArgs[12]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[13]) > 0) player.QueueBuildConstruction("ProduzioneArmature", Convert.ToInt32(msgArgs[13]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[14]) > 0) player.QueueBuildConstruction("ProduzioneFrecce", Convert.ToInt32(msgArgs[14]), clientGuid, player); // Costruisci fattorie

                    if (Convert.ToInt32(msgArgs[15]) > 0) player.QueueBuildConstruction("CasermaGuerrieri", Convert.ToInt32(msgArgs[15]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[16]) > 0) player.QueueBuildConstruction("CasermaLancieri", Convert.ToInt32(msgArgs[16]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[17]) > 0) player.QueueBuildConstruction("CasermaArcieri", Convert.ToInt32(msgArgs[17]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[18]) > 0) player.QueueBuildConstruction("CasermaCatapulte", Convert.ToInt32(msgArgs[18]), clientGuid, player); // Costruisci fattorie
                    break;
                case "Reclutamento":
                    if (Convert.ToInt32(msgArgs[3]) > 0) player.QueueTrainUnits("Guerriero", Convert.ToInt32(msgArgs[3]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[4]) > 0) player.QueueTrainUnits("Lanciere", Convert.ToInt32(msgArgs[4]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[5]) > 0) player.QueueTrainUnits("Arciere", Convert.ToInt32(msgArgs[5]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[6]) > 0) player.QueueTrainUnits("Catapulta", Convert.ToInt32(msgArgs[6]), clientGuid, player); // Costruisci fattorie
                    break;
                case "Battaglia":
                    if (msgArgs[3] == "Barbari_PVE") Battaglie.Battaglia_Barbari_PVE(player, clientGuid);
                    if (msgArgs[3] == "Barbari_PVP") Battaglie.Battaglia_Barbari_PVP(player, clientGuid);
                    if (msgArgs[3] == "PVP")
                    {
                        var temp = msgArgs[4].Split(",");
                        var player2 = Server.servers_.GetPlayer_Data(temp[0]);
                        Battaglie.Battaglia_PVP(player, clientGuid, player2, player2.guid_Player);
                    }
                    break;
                case "Ricerca":
                    if (msgArgs[3] == "Produzione") Ricerca.Ricerca_Produzione(player, clientGuid);
                    if (msgArgs[3] == "Costruzione") Ricerca.Ricerca_Costruzione(player, clientGuid);
                    if (msgArgs[3] == "Addestramento") Ricerca.Ricerca_Addestramento(player, clientGuid);
                    if (msgArgs[3] == "Truppe") Ricerca.Ricerca_Truppe(player, clientGuid, msgArgs[4], msgArgs[5]);
                    break;
                case "Descrizione":
                    switch (msgArgs[3])
                    {
                        case "Fattoria":
                            Server.Send(clientGuid, $"Descrizione|La fattoria è indispensabile per la produzione di Cibo, fondamentale anche per la costruzione di strutture, " +
                                $"l'addestramento delle unità militari ed il loro mantenimento. Indispensabile anche per la ricerca tecnologica e la produzione di componenti militari\r\n \r\n" +
                                $"Cibo: {Strutture.Edifici.Fattoria.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.Fattoria.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.Fattoria.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.Fattoria.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.Fattoria.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.Fattoria.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.Fattoria.Produzione.ToString()}");
                            break;
                        case "Segheria":
                            Server.Send(clientGuid, $"Descrizione|La Segheria è indispensabile per la produzione di Legna, fondamentale per la costruzione di strutture e " +
                                $"l'addestramento delle unità militari. Indispensabile anche per la ricerca tecnologica e la produzione di componenti militari\r\n \r\n" +
                                $"Cibo: {Strutture.Edifici.Segheria.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.Segheria.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.Segheria.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.Segheria.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.Segheria.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.Segheria.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.Segheria.Produzione.ToString()}");
                            break;
                        case "Cava Pietra":
                            Server.Send(clientGuid, $"Descrizione|La cava di pietra è indispensabile per la produzione di Pietra, fondamentale per la costruzione di strutture e " +
                                $"l'addestramento delle unità militari. Indispensabile anche per la ricerca tecnologica e la produzione di componenti militari\r\n \r\n" +
                                $"Cibo: {Strutture.Edifici.CavaPietra.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.CavaPietra.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.CavaPietra.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.CavaPietra.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.CavaPietra.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.CavaPietra.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.CavaPietra.Produzione.ToString()}");
                            break;
                        case "Miniera Ferro":
                            Server.Send(clientGuid, $"Descrizione|La Miniera di ferro è indispensabile per la produzione di Ferro, fondamentale per la costruzione di strutture e " +
                                $"l'addestramento delle unità militari. Indispensabile anche per la ricerca tecnologica e la produzione di componenti militari\r\n \r\n" +
                                $"Cibo: {Strutture.Edifici.MinieraFerro.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.MinieraFerro.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.MinieraFerro.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.MinieraFerro.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.MinieraFerro.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.MinieraFerro.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.MinieraFerro.Produzione.ToString()}");
                            break;
                        case "Miniera Oro":
                            Server.Send(clientGuid, $"Descrizione|La miniera d'oro è indispensabile per la produzione dell'Oro, fondamentale per la costruzione di strutture e " +
                                $"l'addestramento delle unità militari. Indispensabile anche per la ricerca tecnologica e la produzione di componenti militari\r\n \r\n" +
                                $"Cibo: {Strutture.Edifici.MinieraOro.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.MinieraOro.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.MinieraOro.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.MinieraOro.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.MinieraOro.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.MinieraOro.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.MinieraOro.Produzione.ToString()}");
                            break;
                        case "Case":
                            Server.Send(clientGuid, $"Descrizione|Le Case sono necessarie per invogliare sempre più cittadini presso il vostro villaggio, " +
                                $"sono fondamentali per addestrare le unità militari.\r\n \r\n" +
                                $"Cibo: {Strutture.Edifici.Case.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.Case.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.Case.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.Case.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.Case.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.Case.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.Case.Produzione.ToString()}");
                            break;
                    }
                    break;
                default: Console.WriteLine($"Messaggio: [{msgArgs}]"); break;
            }
           
        }
        static async Task<bool> Login(string username, string password, Guid guid)
        {
            // Controlla se il giocatore esiste già
            var existingPlayer = Server.servers_.GetPlayer(username, password);
            if (existingPlayer != null)
            {
                Console.WriteLine("Login: Il giocatore già esiste");
                return true;
            }

            // Controlla se il nome utente è disponibile
            if (await Server.servers_.Check_Username_Player(username))
            {
                
                // Poi prova a caricare i dati salvati
                if (await GameSave.LoadPlayer(username, password))
                {
                    return true;
                }
            }

            return true;
        }

        public static async Task<bool> Load_User_Auto(string username, string password)
        {
            // Controlla se il giocatore esiste già
            var existingPlayer = Server.servers_.GetPlayer_Data(username);
            if (existingPlayer != null)
            {
                Console.WriteLine("Login: Il giocatore già esiste");
                return true;
            }

            // Controlla se il nome utente è disponibile
            if (await Server.servers_.Check_Username_Player(username))
            {
                // Prima crea il nuovo giocatore
                await Server.servers_.AddPlayer(username, password, Guid.Empty);

                // Poi prova a caricare i dati salvati
                if (await GameSave.LoadPlayer(username, password))
                {
                    return true;
                }
            }

            return true;
        }


        public static async Task<bool> Update_Data(Guid guid, string username, string password)
        {
            var player = Server.servers_.GetPlayer(username, password);
            var buildingsQueue = player.GetQueuedBuildings();
            var unitsQueue = player.GetQueuedUnits();

            double Cibo = (player.Guerrieri * Esercito.Unità.Guerriero.Cibo) + (player.Lancieri * Esercito.Unità.Lanciere.Cibo) + (player.Arceri * Esercito.Unità.Arciere.Cibo) + (player.Catapulte * Esercito.Unità.Catapulta.Cibo);
            double Oro = (player.Guerrieri * Esercito.Unità.Guerriero.Salario) + (player.Lancieri * Esercito.Unità.Lanciere.Salario) + (player.Arceri * Esercito.Unità.Arciere.Salario) + (player.Catapulte * Esercito.Unità.Catapulta.Salario);

            Server.Send(guid, $"Update_Data|" +
                $"{player.Cibo.ToString("#,0")}|" +
                $"{player.Legno.ToString("#,0")}|" +
                $"{player.Pietra.ToString("#,0")}|" +
                $"{player.Ferro.ToString("#,0")}|" +
                $"{player.Oro.ToString("#,0")}|" +
                $"{player.Popolazione.ToString("#,0")}|" +

                $"{((player.Fattoria * (Strutture.Edifici.Fattoria.Produzione + player.Ricerca_Produzione * Ricerca.Tipi.Incremento.Cibo)) - Cibo).ToString("#,0.00")}|" +
                $"{(player.Segheria * (Strutture.Edifici.Segheria.Produzione + player.Ricerca_Produzione * Ricerca.Tipi.Incremento.Legno)).ToString("#,0.00")}|" +
                $"{(player.CavaPietra * (Strutture.Edifici.CavaPietra.Produzione + player.Ricerca_Produzione * Ricerca.Tipi.Incremento.Pietra)).ToString("#,0.00")}|" +
                $"{(player.MinieraFerro * (Strutture.Edifici.MinieraFerro.Produzione + player.Ricerca_Produzione * Ricerca.Tipi.Incremento.Ferro)).ToString("#,0.00")}|" +
                $"{((player.MinieraOro * (Strutture.Edifici.MinieraOro.Produzione + player.Ricerca_Produzione * Ricerca.Tipi.Incremento.Oro)) - Oro).ToString("#,0.00")}|" +
                $"{(player.Abitazioni * (Strutture.Edifici.Case.Produzione + player.Ricerca_Produzione * Ricerca.Tipi.Incremento.Popolazione)).ToString("#,0.00")}|" +

                $"{player.Fattoria.ToString("#,0")}|" +
                $"{player.Segheria.ToString("#,0")}|" +
                $"{player.CavaPietra.ToString("#,0")}|" +
                $"{player.MinieraFerro.ToString("#,0")}|" +
                $"{player.MinieraOro.ToString("#,0")}|" +
                $"{player.Abitazioni.ToString("#,0")}|" +

                $"{player.ProduzioneSpade.ToString("#,0")}|" +
                $"{player.ProduzioneLance.ToString("#,0")}|" +
                $"{player.ProduzioneArchi.ToString("#,0")}|" +
                $"{player.ProduzioneScudi.ToString("#,0")}|" +
                $"{player.ProduzioneArmature.ToString("#,0")}|" +
                $"{player.ProduzioneFrecce.ToString("#,0")}|" +

                $"{player.Spade.ToString("#,0.00")}|" +
                $"{player.Lance.ToString("#,0.00")}|" +
                $"{player.Archi.ToString("#,0.00")}|" +
                $"{player.Scudi.ToString("#,0.00")}|" +
                $"{player.Armature.ToString("#,0.00")}|" +
                $"{player.Frecce.ToString("#,0.00")}|" +

                $"{(player.ProduzioneSpade * Strutture.Edifici.ProduzioneSpade.Produzione).ToString("#,0.00")}|" +
                $"{(player.ProduzioneLance * Strutture.Edifici.ProduzioneLance.Produzione).ToString("#,0.00")}|" +
                $"{(player.ProduzioneArchi * Strutture.Edifici.ProduzioneArchi.Produzione).ToString("#,0.00")}|" +
                $"{(player.ProduzioneScudi * Strutture.Edifici.ProduzioneScudi.Produzione).ToString("#,0.00")}|" +
                $"{(player.ProduzioneArmature * Strutture.Edifici.ProduzioneArmature.Produzione).ToString("#,0.00")}|" +
                $"{(player.ProduzioneFrecce * Strutture.Edifici.ProduzioneFrecce.Produzione).ToString("#,0.00")}|" +

                $"{player.Guerrieri.ToString("#,0")}/{player.Caserma_Guerrieri * player.GuerrieriMax}|" +
                $"{player.Lancieri.ToString("#,0")}/{player.Caserma_Lancieri * player.LancieriMax}|" +
                $"{player.Arceri.ToString("#,0")}/{player.Caserma_Arceri * player.ArceriMax}|" +
                $"{player.Catapulte.ToString("#,0")}/{player.Caserma_Catapulte * player.CatapulteMax}|" +

                $"{Server_Strategico.dati.Server}|" +
                $"{Server_Strategico.dati.Versione}|" +
                $"{Server_Strategico.dati.Difficoltà}|" +

                $"{player.Livello}|" +
                $"{player.Esperienza.ToString("#,0")}|" +

                $"{player.Guerrieri_Barbari_PVE.ToString("#,0")}|" +
                $"{player.Lancieri_Barbari_PVE.ToString("#,0")}|" +
                $"{player.Arceri_Barbari_PVE.ToString("#,0")}|" +
                $"{player.Catapulte_Barbari_PVE.ToString("#,0")}|" +

                $"{Variabili.Barbari.PVP.Guerrieri.ToString("#,0")}|" +
                $"{Variabili.Barbari.PVP.Lancieri.ToString("#,0")}|" +
                $"{Variabili.Barbari.PVP.Arceri.ToString("#,0")}|" +
                $"{Variabili.Barbari.PVP.Catapulte.ToString("#,0")}|" +

                $"{player.forza_Esercito.ToString("#,0.00")}|" +
                $"{player.forza_Esercito_PVE.ToString("#,0.00")}|" +
                $"{dati.forza_Esercito_Att_PVP.ToString("#,0.00")}|" +
                
                // Code edifici
                $"{buildingsQueue.GetValueOrDefault("Fattoria", 0)}|" +
                $"{buildingsQueue.GetValueOrDefault("Segheria", 0)}|" +
                $"{buildingsQueue.GetValueOrDefault("CavaPietra", 0)}|" +
                $"{buildingsQueue.GetValueOrDefault("MinieraFerro", 0)}|" +
                $"{buildingsQueue.GetValueOrDefault("MinieraOro", 0)}|" +
                $"{buildingsQueue.GetValueOrDefault("Case", 0)}|" +
                $"{buildingsQueue.GetValueOrDefault("ProduzioneSpade", 0)}|" +
                $"{buildingsQueue.GetValueOrDefault("ProduzioneLance", 0)}|" +
                $"{buildingsQueue.GetValueOrDefault("ProduzioneArchi", 0)}|" +
                $"{buildingsQueue.GetValueOrDefault("ProduzioneScudi", 0)}|" +
                $"{buildingsQueue.GetValueOrDefault("ProduzioneArmature", 0)}|" +
                $"{buildingsQueue.GetValueOrDefault("ProduzioneFrecce", 0)}|" +

                // Code unità
                $"{unitsQueue.GetValueOrDefault("Guerriero", 0)}|" +
                $"{unitsQueue.GetValueOrDefault("Lanciere", 0)}|" +
                $"{unitsQueue.GetValueOrDefault("Arciere", 0)}|" +
                $"{unitsQueue.GetValueOrDefault("Catapulta", 0)}|" +

                $"{player.Guerriero_Salute.ToString("#,0")}|" +
                $"{player.Guerriero_Difesa.ToString("#,0")}|" +
                $"{player.Guerriero_Attacco.ToString("#,0")}|" +
                $"{player.Guerriero_Livello.ToString("#,0")}|" +

                $"{player.Lanciere_Salute.ToString("#,0")}|" +
                $"{player.Lanciere_Difesa.ToString("#,0")}|" +
                $"{player.Lanciere_Attacco.ToString("#,0")}|" +
                $"{player.Lanciere_Livello.ToString("#,0")}|" +

                $"{player.Arciere_Salute.ToString("#,0")}|" +
                $"{player.Arciere_Difesa.ToString("#,0")}|" +
                $"{player.Arciere_Attacco.ToString("#,0")}|" +
                $"{player.Arciere_Livello.ToString("#,0")}|" +

                $"{player.catapulta_Salute.ToString("#,0")}|" +
                $"{player.catapulta_Difesa.ToString("#,0")}|" +
                $"{player.catapulta_Attacco.ToString("#,0")}|" +
                $"{player.catapulta_Livello.ToString("#,0")}|" +

                $"{player.Ricerca_Produzione.ToString("#,0")}|" +
                $"{player.Ricerca_Costruzione.ToString("#,0")}|" +
                $"{player.Ricerca_Addestramento.ToString("#,0")}|");

            stringa_Base = "";
            stringa_Base = $"{Server.Utenti_PVP.Count}";
            string stringa = "";
            foreach (var item in Server.Utenti_PVP)
                stringa = await costruisci_stringa(item);
            
            Server.Send(guid, $"Update_PVP_Player|" +
                $"{stringa}|");
            return true;
        }
        static async Task<string> costruisci_stringa (string dato)
        {
            stringa_Base = stringa_Base + "|" + dato;
            return stringa_Base;
        }
    }
}
