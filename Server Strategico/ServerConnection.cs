using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatsonTcp;
using static Server_Strategico.Variabili;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Server_Strategico
{
    internal class ServerConnection
    {
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
            switch (msgArgs[0])
            {
                case "Update_Data": Update_Data(clientGuid, msgArgs[1], msgArgs[2]); break;
                case "Login":
                    bool login = await Login(msgArgs[1], msgArgs[2], clientGuid);
                    if (login == true) Server.Send(clientGuid, "Login|true");
                    Update_Data(clientGuid, msgArgs[1], msgArgs[2]);
                    break;
                case "Costruzione":
                    var player1 = Server.servers_.GetPlayer(msgArgs[1], msgArgs[2]);
                    if (Convert.ToInt32(msgArgs[3]) > 0) player1.QueueBuildConstruction("Fattoria", Convert.ToInt32(msgArgs[3]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[4]) > 0) player1.QueueBuildConstruction("Segheria", Convert.ToInt32(msgArgs[4]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[5]) > 0) player1.QueueBuildConstruction("CavaPietra", Convert.ToInt32(msgArgs[5]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[6]) > 0) player1.QueueBuildConstruction("MinieraFerro", Convert.ToInt32(msgArgs[6]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[7]) > 0) player1.QueueBuildConstruction("MinieraOro", Convert.ToInt32(msgArgs[7]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[8]) > 0) player1.QueueBuildConstruction("Case", Convert.ToInt32(msgArgs[8]), clientGuid); // Costruisci fattorie
                    
                    if (Convert.ToInt32(msgArgs[9]) > 0) player1.QueueBuildConstruction("ProduzioneSpade", Convert.ToInt32(msgArgs[9]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[10]) > 0) player1.QueueBuildConstruction("ProduzioneLancie", Convert.ToInt32(msgArgs[10]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[11]) > 0) player1.QueueBuildConstruction("ProduzioneArchi", Convert.ToInt32(msgArgs[11]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[12]) > 0) player1.QueueBuildConstruction("ProduzioneScudi", Convert.ToInt32(msgArgs[12]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[13]) > 0) player1.QueueBuildConstruction("ProduzioneArmature", Convert.ToInt32(msgArgs[13]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[14]) > 0) player1.QueueBuildConstruction("ProduzioneFrecce", Convert.ToInt32(msgArgs[14]), clientGuid); // Costruisci fattorie
                    break;
                case "Reclutamento":
                    var player2 = Server.servers_.GetPlayer(msgArgs[1], msgArgs[2]);
                    if (Convert.ToInt32(msgArgs[3]) > 0) player2.QueueTrainUnits("Guerriero", Convert.ToInt32(msgArgs[3]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[4]) > 0) player2.QueueTrainUnits("Lanciere", Convert.ToInt32(msgArgs[4]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[5]) > 0) player2.QueueTrainUnits("Arciere", Convert.ToInt32(msgArgs[5]), clientGuid); // Costruisci fattorie
                    if (Convert.ToInt32(msgArgs[6]) > 0) player2.QueueTrainUnits("Catapulta", Convert.ToInt32(msgArgs[6]), clientGuid); // Costruisci fattorie
                    break;
                default: Console.WriteLine($"Messaggio: [{msgArgs}]"); break;
            }
           
        }
        static async Task<bool> Login (string username, string password, Guid guid)
        {
            if (Server.servers_.GetPlayer(username, password) == null)
            {
                bool add_Player = await Server.servers_.AddPlayer(username, password, guid);
            }
            return true;
        }
        public static bool Update_Data(Guid guid, string username, string password)
        {
            var player = Server.servers_.GetPlayer(username, password);
            Server.Send(guid, $"Update_Data|" +
                $"{player.Cibo.ToString("0.00")}|" +
                $"{player.Legno.ToString("0.00")}|" +
                $"{player.Pietra.ToString("0.00")}|" +
                $"{player.Ferro.ToString("0.00")}|" +
                $"{player.Oro.ToString("0.00")}|" +
                $"{player.Popolazione.ToString("0.00")}|" +

                $"{(player.Fattoria * Variabili.Edifici.Fattoria.Produzione).ToString("0.00")}|" +
                $"{(player.Segheria * Variabili.Edifici.Segheria.Produzione).ToString("0.00")}|" +
                $"{(player.CavaPietra * Variabili.Edifici.CavaPietra.Produzione).ToString("0.00")}|" +
                $"{(player.MinieraFerro * Variabili.Edifici.MinieraFerro.Produzione).ToString("0.00")}|" +
                $"{(player.MinieraOro * Variabili.Edifici.MinieraOro.Produzione).ToString("0.00")}|" +
                $"{(player.Abitazioni * Variabili.Edifici.Case.Produzione).ToString("0.00")}|" +

                $"{player.Fattoria.ToString("0")}|" +
                $"{player.Segheria.ToString("0")}|" +
                $"{player.CavaPietra.ToString("0")}|" +
                $"{player.MinieraFerro.ToString("0")}|" +
                $"{player.MinieraOro.ToString("0")}|" +
                $"{player.Abitazioni.ToString("0")}|" +

                $"{player.ProduzioneSpade.ToString("0")}|" +
                $"{player.ProduzioneLance.ToString("0")}|" +
                $"{player.ProduzioneArchi.ToString("0")}|" +
                $"{player.ProduzioneScudi.ToString("0")}|" +
                $"{player.ProduzioneArmature.ToString("0")}|" +
                $"{player.ProduzioneFrecce.ToString("0")}|" +

                $"{player.Spade.ToString("0.00")}|" +
                $"{player.Lance.ToString("0.00")}|" +
                $"{player.Archi.ToString("0.00")}|" +
                $"{player.Scudi.ToString("0.00")}|" +
                $"{player.Armature.ToString("0.00")}|" +
                $"{player.Frecce.ToString("0.00")}|" +

                $"{(player.ProduzioneSpade * Variabili.Edifici.ProduzioneSpade.Produzione).ToString("0.00")}|" +
                $"{(player.ProduzioneLance * Variabili.Edifici.ProduzioneLance.Produzione).ToString("0.00")}|" +
                $"{(player.ProduzioneArchi * Variabili.Edifici.ProduzioneArchi.Produzione).ToString("0.00")}|" +
                $"{(player.ProduzioneScudi * Variabili.Edifici.ProduzioneScudi.Produzione).ToString("0.00")}|" +
                $"{(player.ProduzioneArmature * Variabili.Edifici.ProduzioneArmature.Produzione).ToString("0.00")}|" +
                $"{(player.ProduzioneFrecce * Variabili.Edifici.ProduzioneFrecce.Produzione).ToString("0.00")}|" +

                $"{player.Guerrieri.ToString("0")}|" +
                $"{player.Lancieri.ToString("0")}|" +
                $"{player.Arceri.ToString("0")}|" +
                $"{player.Catapulte.ToString("0")}|" +

                $"{Server_Strategico.dati.Server}|" +
                $"{Server_Strategico.dati.Versione}|" +
                $"{Server_Strategico.dati.Difficoltà}|" +
                $"");
            return true;
        }
    }
}
