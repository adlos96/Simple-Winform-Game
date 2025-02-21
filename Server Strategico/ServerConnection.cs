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
                    if (Convert.ToInt32(msgArgs[3]) > 0) player.QueueBuildConstruction("Fattoria", Convert.ToInt32(msgArgs[3]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[4]) > 0) player.QueueBuildConstruction("Segheria", Convert.ToInt32(msgArgs[4]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[5]) > 0) player.QueueBuildConstruction("CavaPietra", Convert.ToInt32(msgArgs[5]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[6]) > 0) player.QueueBuildConstruction("MinieraFerro", Convert.ToInt32(msgArgs[6]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[7]) > 0) player.QueueBuildConstruction("MinieraOro", Convert.ToInt32(msgArgs[7]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[8]) > 0) player.QueueBuildConstruction("Case", Convert.ToInt32(msgArgs[8]), clientGuid); // Costruisci fattorie
                    
                    if (Convert.ToInt32(msgArgs[9]) > 0) player.QueueBuildConstruction("ProduzioneSpade", Convert.ToInt32(msgArgs[9]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[10]) > 0) player.QueueBuildConstruction("ProduzioneLancie", Convert.ToInt32(msgArgs[10]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[11]) > 0) player.QueueBuildConstruction("ProduzioneArchi", Convert.ToInt32(msgArgs[11]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[12]) > 0) player.QueueBuildConstruction("ProduzioneScudi", Convert.ToInt32(msgArgs[12]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[13]) > 0) player.QueueBuildConstruction("ProduzioneArmature", Convert.ToInt32(msgArgs[13]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[14]) > 0) player.QueueBuildConstruction("ProduzioneFrecce", Convert.ToInt32(msgArgs[14]), clientGuid); // Costruisci fattorie

                    if (Convert.ToInt32(msgArgs[15]) > 0) player.QueueBuildConstruction("CasermaGuerrieri", Convert.ToInt32(msgArgs[15]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[16]) > 0) player.QueueBuildConstruction("CasermaLancieri", Convert.ToInt32(msgArgs[16]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[17]) > 0) player.QueueBuildConstruction("CasermaArcieri", Convert.ToInt32(msgArgs[17]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[18]) > 0) player.QueueBuildConstruction("CasermaCatapulte", Convert.ToInt32(msgArgs[18]), clientGuid); // Costruisci fattorie
                    break;
                case "Reclutamento":
                    if (Convert.ToInt32(msgArgs[3]) > 0) player.QueueTrainUnits("Guerriero", Convert.ToInt32(msgArgs[3]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[4]) > 0) player.QueueTrainUnits("Lanciere", Convert.ToInt32(msgArgs[4]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[5]) > 0) player.QueueTrainUnits("Arciere", Convert.ToInt32(msgArgs[5]), clientGuid, player); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[6]) > 0) player.QueueTrainUnits("Catapulta", Convert.ToInt32(msgArgs[6]), clientGuid, player); // Costruisci fattorie
                    break;
                case "Battaglia":
                    if (msgArgs[3] == "Barbari_PVE")
                    {
                        Battaglie.Battaglia_Barbari_PVE(player, clientGuid);
                    }
                    if (msgArgs[3] == "Barbari_PVP")
                    {
                        Battaglie.Battaglia_Barbari_PVP(player, clientGuid);
                    }
                    if (msgArgs[3] == "PVP")
                    {
                        var temp = msgArgs[4].Split(",");
                        var player2 = Server.servers_.GetPlayer_Data(temp[0]);
                        Battaglie.Battaglia_PVP(player, clientGuid, player2, player2.guid_Player);
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
                return true;
            }

            // Controlla se il nome utente è disponibile
            if (await Server.servers_.Check_Username_Player(username))
            {
                // Prima crea il nuovo giocatore
                await Server.servers_.AddPlayer(username, password, guid);
                
                // Poi prova a caricare i dati salvati
                if (await GameSave.LoadPlayer(username, password))
                {
                    return true;
                }
                
                // Se non ci sono dati salvati, il giocatore è già stato creato con i valori default
                return true;
            }

            return false;
        }
        public static async Task<bool> Update_Data(Guid guid, string username, string password)
        {
            var player = Server.servers_.GetPlayer(username, password);
            var buildingsQueue = player.GetQueuedBuildings();
            var unitsQueue = player.GetQueuedUnits();

            double Cibo = (player.Guerrieri * Variabili.Esercito.Guerriero.Cibo) + (player.Lancieri * Variabili.Esercito.Lanciere.Cibo) + (player.Arceri * Variabili.Esercito.Arciere.Cibo) + (player.Catapulte * Variabili.Esercito.Catapulta.Cibo);
            double Oro = (player.Guerrieri * Variabili.Esercito.Guerriero.Salario) + (player.Lancieri * Variabili.Esercito.Lanciere.Salario) + (player.Arceri * Variabili.Esercito.Arciere.Salario) + (player.Catapulte * Variabili.Esercito.Catapulta.Salario);

            Server.Send(guid, $"Update_Data|" +
                $"{player.Cibo.ToString("#,0")}|" +
                $"{player.Legno.ToString("#,0")}|" +
                $"{player.Pietra.ToString("#,0")}|" +
                $"{player.Ferro.ToString("#,0")}|" +
                $"{player.Oro.ToString("#,0")}|" +
                $"{player.Popolazione.ToString("#,0")}|" +

                $"{((player.Fattoria * Variabili.Edifici.Fattoria.Produzione) - Cibo).ToString("#,0.00")}|" +
                $"{(player.Segheria * Variabili.Edifici.Segheria.Produzione).ToString("#,0.00")}|" +
                $"{(player.CavaPietra * Variabili.Edifici.CavaPietra.Produzione).ToString("#,0.00")}|" +
                $"{(player.MinieraFerro * Variabili.Edifici.MinieraFerro.Produzione).ToString("#,0.00")}|" +
                $"{((player.MinieraOro * Variabili.Edifici.MinieraOro.Produzione) - Oro).ToString("#,0.00")}|" +
                $"{(player.Abitazioni * Variabili.Edifici.Case.Produzione).ToString("#,0.00")}|" +

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

                $"{(player.ProduzioneSpade * Variabili.Edifici.ProduzioneSpade.Produzione).ToString("#,0.00")}|" +
                $"{(player.ProduzioneLance * Variabili.Edifici.ProduzioneLance.Produzione).ToString("#,0.00")}|" +
                $"{(player.ProduzioneArchi * Variabili.Edifici.ProduzioneArchi.Produzione).ToString("#,0.00")}|" +
                $"{(player.ProduzioneScudi * Variabili.Edifici.ProduzioneScudi.Produzione).ToString("#,0.00")}|" +
                $"{(player.ProduzioneArmature * Variabili.Edifici.ProduzioneArmature.Produzione).ToString("#,0.00")}|" +
                $"{(player.ProduzioneFrecce * Variabili.Edifici.ProduzioneFrecce.Produzione).ToString("#,0.00")}|" +

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
                $"{unitsQueue.GetValueOrDefault("Catapulta", 0)}|");

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
