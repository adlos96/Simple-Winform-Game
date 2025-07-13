using Server_Strategico.Gioco;
using System.Text;
using WatsonTcp;

namespace Server_Strategico.Server
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
                case "New Player":
                    Console.WriteLine($"[Server] Richiesta nuovo utente ID: {clientGuid}");
                    if (await New_Player(msgArgs[1], msgArgs[2], clientGuid))
                        Server.Send(clientGuid, "Login|true");
                    else
                        Server.Send(clientGuid, $"Login|false|Questo nome utente è già presente: [{msgArgs[1]}]");
                    break;
                case "Login":
                    bool login = await Login(msgArgs[1], msgArgs[2], clientGuid);
                    if (login == true) Server.Send(clientGuid, "Login|true");
                    else
                        Server.Send(clientGuid, $"Login|false|Username o password non corrispondono. User: [{msgArgs[1]}] psw: [{msgArgs[2]}]");
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
                    if (msgArgs[3] == "Barbari_PVE") Battaglie.Battaglia_Barbari(player, clientGuid, "Barbari_PVE");
                    if (msgArgs[3] == "Barbari_PVP") Battaglie.Battaglia_Barbari(player, clientGuid, "Barbari_PVP");
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
                            Server.Send(clientGuid, $"Descrizione|La fattoria è la struttura principale per la produzione di Cibo, fondamentale anche per la costruzione di strutture, " +
                                $"l'addestramento delle unità militari ed il loro mantenimento. Indispensabile anche per la ricerca tecnologica e la produzione di componenti militari\r\n \r\n" +
                                $"Costo Costruzione:\r\n" +
                                $"Cibo: {Strutture.Edifici.Fattoria.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.Fattoria.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.Fattoria.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.Fattoria.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.Fattoria.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.Fattoria.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.Fattoria.Produzione.ToString()}");
                            break;
                        case "Segheria":
                            Server.Send(clientGuid, $"Descrizione|La Segheria è la struttura principale per la produzione di Legna, fondamentale per la costruzione di strutture e " +
                                $"l'addestramento delle unità militari. Indispensabile anche per la ricerca tecnologica e la produzione di componenti militari\r\n \r\n" +
                                $"Costo Costruzione:\r\n" +
                                $"Cibo: {Strutture.Edifici.Segheria.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.Segheria.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.Segheria.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.Segheria.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.Segheria.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.Segheria.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.Segheria.Produzione.ToString()}");
                            break;
                        case "Cava Pietra":
                            Server.Send(clientGuid, $"Descrizione|La cava di pietra è la struttura principale per la produzione di Pietra, fondamentale per la costruzione di strutture e " +
                                $"l'addestramento delle unità militari. Indispensabile anche per la ricerca tecnologica e la produzione di componenti militari\r\n \r\n" +
                                $"Costo Costruzione:\r\n" +
                                $"Cibo: {Strutture.Edifici.CavaPietra.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.CavaPietra.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.CavaPietra.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.CavaPietra.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.CavaPietra.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.CavaPietra.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.CavaPietra.Produzione.ToString()}");
                            break;
                        case "Miniera Ferro":
                            Server.Send(clientGuid, $"Descrizione|La Miniera di ferro è la struttura principale per la produzione di Ferro, fondamentale per la costruzione di strutture e " +
                                $"l'addestramento delle unità militari. Indispensabile anche per la ricerca tecnologica e la produzione di componenti militari\r\n \r\n" +
                                $"Costo Costruzione:\r\n" +
                                $"Cibo: {Strutture.Edifici.MinieraFerro.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.MinieraFerro.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.MinieraFerro.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.MinieraFerro.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.MinieraFerro.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.MinieraFerro.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.MinieraFerro.Produzione.ToString()}");
                            break;
                        case "Miniera Oro":
                            Server.Send(clientGuid, $"Descrizione|La miniera d'oro è la struttura principale per la produzione dell'Oro, fondamentale per la costruzione di strutture e " +
                                $"l'addestramento delle unità militari. Indispensabile anche per la ricerca tecnologica e la produzione di componenti militari\r\n \r\n" +
                                $"Costo Costruzione:\r\n" +
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
                                $"Costo Costruzione:\r\n" +
                                $"Cibo: {Strutture.Edifici.Case.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.Case.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.Case.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.Case.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.Case.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.Case.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.Case.Produzione.ToString()}");
                            break;

                        case "Produzione Spade":
                            Server.Send(clientGuid, $"Descrizione|Questa struttura è attrezzata in modo da produrre equipaggiamento militare specifico, " +
                                $"essenziali per l'addestramento di unità militari, questa struttura produce Spade.\r\n \r\n" +
                                $"Costo Costruzione:\r\n" +
                                $"Cibo: {Strutture.Edifici.ProduzioneSpade.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.ProduzioneSpade.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.ProduzioneSpade.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.ProduzioneSpade.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.ProduzioneSpade.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.ProduzioneSpade.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.ProduzioneSpade.Produzione.ToString()}");
                            break;
                        case "Produzione Lance":
                            Server.Send(clientGuid, $"Descrizione|Questa struttura è attrezzata in modo da produrre equipaggiamento militare specifico, " +
                                $"essenziali per l'addestramento di unità militari, questa struttura produce Lance.\r\n \r\n" +
                                $"Costo Costruzione:\r\n" +
                                $"Cibo: {Strutture.Edifici.ProduzioneLance.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.ProduzioneLance.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.ProduzioneLance.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.ProduzioneLance.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.ProduzioneLance.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.ProduzioneLance.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.ProduzioneLance.Produzione.ToString()}");
                            break;
                        case "Produzione Archi":
                            Server.Send(clientGuid, $"Descrizione|Questa struttura è attrezzata in modo da produrre equipaggiamento militare specifico, " +
                                $"essenziali per l'addestramento di unità militari, questa struttura produce Archi.\r\n \r\n" +
                                $"Costo Costruzione:\r\n" +
                                $"Cibo: {Strutture.Edifici.ProduzioneArchi.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.ProduzioneArchi.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.ProduzioneArchi.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.ProduzioneArchi.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.ProduzioneArchi.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.ProduzioneArchi.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.ProduzioneArchi.Produzione.ToString()}");
                            break;
                        case "Produzione Scudi":
                            Server.Send(clientGuid, $"Descrizione|Questa struttura è attrezzata in modo da produrre equipaggiamento militare specifico, " +
                                $"essenziali per l'addestramento di unità militari, questa struttura produce Scudi.\r\n \r\n" +
                                $"Costo Costruzione:\r\n" +
                                $"Cibo: {Strutture.Edifici.ProduzioneScudi.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.ProduzioneScudi.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.ProduzioneScudi.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.ProduzioneScudi.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.ProduzioneScudi.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.ProduzioneScudi.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.ProduzioneScudi.Produzione.ToString()}");
                            break;
                        case "Produzione Armature":
                            Server.Send(clientGuid, $"Descrizione|Questa struttura è attrezzata in modo da produrre equipaggiamento militare specifico, " +
                                $"essenziali per l'addestramento di unità militari, questa struttura produce Armature.\r\n \r\n" +
                                $"Costo Costruzione:\r\n" +
                                $"Cibo: {Strutture.Edifici.ProduzioneArmature.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.ProduzioneArmature.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.ProduzioneArmature.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.ProduzioneArmature.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.ProduzioneArmature.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.ProduzioneArmature.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.ProduzioneArmature.Produzione.ToString()}");
                            break;
                        case "Produzione Frecce":
                            Server.Send(clientGuid, $"Descrizione|Questa struttura è attrezzata in modo da produrre equipaggiamento militare specifico, " +
                                $"essenziali per l'addestramento di unità militari, questa struttura produce Frecce.\r\n \r\n" +
                                $"Costo Costruzione:\r\n" +
                                $"Cibo: {Strutture.Edifici.ProduzioneFrecce.Cibo.ToString("#,0")}\r\n" +
                                $"Legno: {Strutture.Edifici.ProduzioneFrecce.Legno.ToString("#,0")}\r\n" +
                                $"Pietra: {Strutture.Edifici.ProduzioneFrecce.Pietra.ToString("#,0")}\r\n" +
                                $"Ferro: {Strutture.Edifici.ProduzioneFrecce.Ferro.ToString("#,0")}\r\n" +
                                $"Oro: {Strutture.Edifici.ProduzioneFrecce.Oro.ToString("#,0")}\r\n" +
                                $"Tempo di costruzione: {Strutture.Edifici.ProduzioneFrecce.TempoCostruzione.ToString()} s\r\n" +
                                $"Produzione risorse: {Strutture.Edifici.ProduzioneFrecce.Produzione.ToString()}");
                            break;

                        case "Guerriero":
                            Server.Send(clientGuid, $"Descrizione|I guerrieri sono la spina dorsale dell'esercito, anche se sprovvisti di scudo sono sa prina dorsale di ogni esercito,  " +
                                $"sono facili da reclutare e non chiedono molta manutenzione in cibo ed oro.\r\n \r\n" +
                                $"Costo Addestramento:\r\n" +
                                $"Cibo: {Esercito.CostoReclutamento.Guerriero.Cibo.ToString("#,0")}                  Spade: {Esercito.CostoReclutamento.Guerriero.Spade.ToString("#,0")}\r\n" +
                                $"Legno: {Esercito.CostoReclutamento.Guerriero.Legno.ToString("#,0")}               Lancie: {Esercito.CostoReclutamento.Guerriero.Lance.ToString("#,0")}\r\n" +
                                $"Pietra: {Esercito.CostoReclutamento.Guerriero.Pietra.ToString("#,0")}                Archi: {Esercito.CostoReclutamento.Guerriero.Archi.ToString("#,0")}\r\n" +
                                $"Ferro: {Esercito.CostoReclutamento.Guerriero.Ferro.ToString("#,0")}                 Scudi: {Esercito.CostoReclutamento.Guerriero.Scudi.ToString("#,0")}\r\n" +
                                $"Oro: {Esercito.CostoReclutamento.Guerriero.Oro.ToString("#,0")}                    Armature: {Esercito.CostoReclutamento.Guerriero.Armature.ToString("#,0")}\r\n \r\n" +
                                $"Popolazione: {Esercito.CostoReclutamento.Guerriero.Popolazione}\r\n" +
                                $"Tempo di Addestramento: {Esercito.CostoReclutamento.Guerriero.TempoReclutamento.ToString()} s\r\n" +
                                $"Mantenimento Cibo: {Esercito.Unità.Guerriero.Cibo.ToString()} s\r\n" +
                                $"Mantenimento Oro: {Esercito.Unità.Guerriero.Salario.ToString()} s\r\n \r\n" +
                                $"Statistiche:\r\n" +
                                $"Livello: {player.Guerriero_Livello.ToString("#,0")}\r\n" +
                                $"Salute:  {(Esercito.Unità.Guerriero.Salute + player.Guerriero_Livello).ToString("#,0")}\r\n" +
                                $"Difesa:  {(Esercito.Unità.Guerriero.Difesa + player.Guerriero_Livello).ToString("#,0")}\r\n" +
                                $"Attacco: {(Esercito.Unità.Guerriero.Attacco + player.Guerriero_Livello).ToString("#,0")}\r\n \r\n");
                            break;
                        case "Lanciere":
                            Server.Send(clientGuid, $"Descrizione|I Lancieri sono la spina dorsale di ogni esercito ben organizzato. Armati di lance, " +
                                $"questi soldati costituiscono un baluardo formidabile contro gli assalti nemici.\r\n \r\n" +
                                $"Costo Addestramento:\r\n" +
                                $"Cibo: {Esercito.CostoReclutamento.Lanciere.Cibo.ToString("#,0")}                  Spade: {Esercito.CostoReclutamento.Lanciere.Spade.ToString("#,0")}\r\n" +
                                $"Legno: {Esercito.CostoReclutamento.Lanciere.Legno.ToString("#,0")}               Lancie: {Esercito.CostoReclutamento.Lanciere.Lance.ToString("#,0")}\r\n" +
                                $"Pietra: {Esercito.CostoReclutamento.Lanciere.Pietra.ToString("#,0")}                Archi: {Esercito.CostoReclutamento.Lanciere.Archi.ToString("#,0")}\r\n" +
                                $"Ferro: {Esercito.CostoReclutamento.Lanciere.Ferro.ToString("#,0")}                 Scudi: {Esercito.CostoReclutamento.Lanciere.Scudi.ToString("#,0")}\r\n" +
                                $"Oro: {Esercito.CostoReclutamento.Lanciere.Oro.ToString("#,0")}                    Armature: {Esercito.CostoReclutamento.Lanciere.Armature.ToString("#,0")}\r\n \r\n" +
                                $"Popolazione: {Esercito.CostoReclutamento.Lanciere.Popolazione}\r\n" +
                                $"Tempo di Addestramento: {Esercito.CostoReclutamento.Lanciere.TempoReclutamento.ToString()} s\r\n" +
                                $"Mantenimento Cibo: {Esercito.Unità.Lanciere.Cibo.ToString()} s\r\n" +
                                $"Mantenimento Oro: {Esercito.Unità.Lanciere.Salario.ToString()} s\r\n \r\n" +
                                $"Statistiche:\r\n" +
                                $"Livello: {player.Lanciere_Livello.ToString("#,0")}\r\n" +
                                $"Salute:  {(Esercito.Unità.Lanciere.Salute + player.Lanciere_Livello).ToString("#,0")}\r\n" +
                                $"Difesa:  {(Esercito.Unità.Lanciere.Difesa + player.Lanciere_Livello).ToString("#,0")}\r\n" +
                                $"Attacco: {(Esercito.Unità.Lanciere.Attacco + player.Lanciere_Livello).ToString("#,0")}\r\n \r\n");
                            break;
                        case "Arciere":
                            Server.Send(clientGuid, $"Descrizione|Gli Arcieri armati di arco e faretra, sono soldati specializzati, dominano il campo di battaglia dalla distanza, " +
                                $"lanciando frecce mortali sulle linee nemiche, prima che possano avvicinarsi.\r\n \r\n" +
                                $"Costo Addestramento:\r\n" +
                                $"Cibo: {Esercito.CostoReclutamento.Arciere.Cibo.ToString("#,0")}                  Spade: {Esercito.CostoReclutamento.Arciere.Spade.ToString("#,0")}\r\n" +
                                $"Legno: {Esercito.CostoReclutamento.Arciere.Legno.ToString("#,0")}               Lancie: {Esercito.CostoReclutamento.Arciere.Lance.ToString("#,0")}\r\n" +
                                $"Pietra: {Esercito.CostoReclutamento.Arciere.Pietra.ToString("#,0")}                Archi: {Esercito.CostoReclutamento.Arciere.Archi.ToString("#,0")}\r\n" +
                                $"Ferro: {Esercito.CostoReclutamento.Arciere.Ferro.ToString("#,0")}                 Scudi: {Esercito.CostoReclutamento.Arciere.Scudi.ToString("#,0")}\r\n" +
                                $"Oro: {Esercito.CostoReclutamento.Arciere.Oro.ToString("#,0")}                    Armature: {Esercito.CostoReclutamento.Arciere.Armature.ToString("#,0")}\r\n \r\n" +
                                $"Popolazione: {Esercito.CostoReclutamento.Arciere.Popolazione}\r\n" +
                                $"Tempo di Addestramento: {Esercito.CostoReclutamento.Arciere.TempoReclutamento.ToString()} s\r\n" +
                                $"Mantenimento Cibo: {Esercito.Unità.Arciere.Cibo.ToString()} s\r\n" +
                                $"Mantenimento Oro: {Esercito.Unità.Arciere.Salario.ToString()} s\r\n \r\n" +
                                $"Statistiche:\r\n" +
                                $"Livello: {player.Arciere_Livello.ToString("#,0")}\r\n" +
                                $"Salute:  {(Esercito.Unità.Arciere.Salute + player.Arciere_Livello).ToString("#,0")}\r\n" +
                                $"Difesa:  {(Esercito.Unità.Arciere.Difesa + player.Arciere_Livello).ToString("#,0")}\r\n" +
                                $"Attacco: {(Esercito.Unità.Arciere.Attacco + player.Arciere_Livello).ToString("#,0")}\r\n \r\n");
                            break;
                        case "Catapulta":
                            Server.Send(clientGuid, $"Descrizione|Le Catapulte sono potenti macchine d'assedio che cambiano le sorti delle battaglie, " +
                                $"scagliano enormi proiettili distruggendo mura e seminando il terrore tra le fila nemiche\r\n \r\n" +
                                $"Costo Addestramento:\r\n" +
                                $"Cibo: {Esercito.CostoReclutamento.Catapulta.Cibo.ToString("#,0")}                  Spade: {Esercito.CostoReclutamento.Catapulta.Spade.ToString("#,0")}\r\n" +
                                $"Legno: {Esercito.CostoReclutamento.Catapulta.Legno.ToString("#,0")}               Lancie: {Esercito.CostoReclutamento.Catapulta.Lance.ToString("#,0")}\r\n" +
                                $"Pietra: {Esercito.CostoReclutamento.Catapulta.Pietra.ToString("#,0")}                Archi: {Esercito.CostoReclutamento.Catapulta.Archi.ToString("#,0")}\r\n" +
                                $"Ferro: {Esercito.CostoReclutamento.Catapulta.Ferro.ToString("#,0")}                 Scudi: {Esercito.CostoReclutamento.Catapulta.Scudi.ToString("#,0")}\r\n" +
                                $"Oro: {Esercito.CostoReclutamento.Catapulta.Oro.ToString("#,0")}                    Armature: {Esercito.CostoReclutamento.Catapulta.Armature.ToString("#,0")}\r\n \r\n" +
                                $"Popolazione: {Esercito.CostoReclutamento.Catapulta.Popolazione}\r\n" +
                                $"Tempo di Addestramento: {Esercito.CostoReclutamento.Catapulta.TempoReclutamento.ToString()} s\r\n" +
                                $"Mantenimento Cibo: {Esercito.Unità.Catapulta.Cibo.ToString("0.00")} s\r\n" +
                                $"Mantenimento Oro: {Esercito.Unità.Catapulta.Salario.ToString("0.00")} s\r\n \r\n" +
                                $"Statistiche:\r\n" +
                                $"Livello: {player.catapulta_Livello.ToString("#,0")}\r\n" +
                                $"Salute:  {(Esercito.Unità.Catapulta.Salute + player.catapulta_Livello).ToString("#,0")}\r\n" +
                                $"Difesa:  {(Esercito.Unità.Catapulta.Difesa + player.catapulta_Livello).ToString("#,0")}\r\n" +
                                $"Attacco: {(Esercito.Unità.Catapulta.Attacco + player.catapulta_Livello).ToString("#,0")}\r\n \r\n");
                            break;

                        case "Guerriero_PVE":
                            Server.Send(clientGuid, $"Descrizione|I guerrieri sono la spina dorsale dell'esercito, anche se sprovvisti di scudo sono sa prina dorsale di ogni esercito,  " +
                                $"sono facili da reclutare e non chiedono molta manutenzione in cibo ed oro.\r\n \r\n" +
                                $"Statistiche:\r\n" +
                                $"Livello: {player.Livello_Barbari_PVE.ToString("#,0")}\r\n" +
                                $"Salute:  {(Esercito.EsercitoNemico.Guerriero.Salute + player.Livello_Barbari_PVE).ToString("#,0")}\r\n" +
                                $"Difesa:  {(Esercito.EsercitoNemico.Guerriero.Difesa + player.Livello_Barbari_PVE).ToString("#,0")}\r\n" +
                                $"Attacco: {(Esercito.EsercitoNemico.Guerriero.Attacco + player.Livello_Barbari_PVE).ToString("#,0")}\r\n" +
                                $"Esperienza: {Esercito.EsercitoNemico.Guerriero.Esperienza.ToString("#,0")}\r\n");
                            break;
                        case "Lanciere_PVE":
                            Server.Send(clientGuid, $"Descrizione|I Lancieri sono la spina dorsale di ogni esercito ben organizzato. Armati di lance, " +
                                $"questi soldati costituiscono un baluardo formidabile contro gli assalti nemici.\r\n \r\n" +
                                $"Statistiche:\r\n" +
                                $"Livello: {player.Livello_Barbari_PVE.ToString("#,0")}\r\n" +
                                $"Salute:  {(Esercito.EsercitoNemico.Lanciere.Salute + player.Livello_Barbari_PVE).ToString("#,0")}\r\n" +
                                $"Difesa:  {(Esercito.EsercitoNemico.Lanciere.Difesa + player.Livello_Barbari_PVE).ToString("#,0")}\r\n" +
                                $"Attacco: {(Esercito.EsercitoNemico.Lanciere.Attacco + player.Livello_Barbari_PVE).ToString("#,0")}\r\n" +
                                $"Esperienza: {Esercito.EsercitoNemico.Lanciere.Esperienza.ToString("#,0")}\r\n");
                            break;
                        case "Arciere_PVE":
                            Server.Send(clientGuid, $"Descrizione|Gli Arcieri armati di arco e faretra, sono soldati specializzati, dominano il campo di battaglia dalla distanza, " +
                                $"lanciando frecce mortali sulle linee nemiche, prima che possano avvicinarsi.\r\n \r\n" +
                                $"Statistiche:\r\n" +
                                $"Livello: {player.Livello_Barbari_PVE.ToString("#,0")}\r\n" +
                                $"Salute:  {(Esercito.EsercitoNemico.Arciere.Salute + player.Livello_Barbari_PVE).ToString("#,0")}\r\n" +
                                $"Difesa:  {(Esercito.EsercitoNemico.Arciere.Difesa + player.Livello_Barbari_PVE).ToString("#,0")}\r\n" +
                                $"Attacco: {(Esercito.EsercitoNemico.Arciere.Attacco + player.Livello_Barbari_PVE).ToString("#,0")}\r\n" +
                                $"Esperienza: {Esercito.EsercitoNemico.Arciere.Esperienza.ToString("#,0")}\r\n");
                            break;
                        case "Catapulta_PVE":
                            Server.Send(clientGuid, $"Descrizione|Le Catapulte sono potenti macchine d'assedio che cambiano le sorti delle battaglie, " +
                                $"scagliano enormi proiettili distruggendo mura e seminando il terrore tra le fila nemiche\r\n \r\n" +
                                $"Statistiche:\r\n" +
                                $"Livello: {player.Livello_Barbari_PVE.ToString("#,0")}\r\n" +
                                $"Salute:  {(Esercito.EsercitoNemico.Catapulta.Salute + player.Livello_Barbari_PVE).ToString("#,0")}\r\n" +
                                $"Difesa:  {(Esercito.EsercitoNemico.Catapulta.Difesa + player.Livello_Barbari_PVE).ToString("#,0")}\r\n" +
                                $"Attacco: {(Esercito.EsercitoNemico.Catapulta.Attacco + player.Livello_Barbari_PVE).ToString("#,0")}\r\n" +
                                $"Esperienza: {Esercito.EsercitoNemico.Catapulta.Esperienza.ToString("#,0")}\r\n");
                            break;

                        case "Raduno":
                            Server.Send(clientGuid, $"Descrizione|Il Raduno ti permette di creare e gestire attacchi coordinati con altri giocatori, " +
                                $"verso il barbaro PVP disponibile. Essendo che il barbaro riesce a reclutare molte unità nel suo campo, può essere saggio " +
                                $"chiedere aiuto ad altri giocatori nell'impresa.\r\n \r\n" +
                                $"- Solo colui che crea il raduno potrà iniziare l'attacco.\r\n" +
                                $"- Gli attacchi aperti sono pubblici e chiunque potra partecipare\r\n" +
                                $"- Nel caso in cui il tempo disponibile termina, il raduno verrà annullato e le unità dei giocatori partecipanti torneranno indietro\r\n" +
                                $"- Il livello delle unità non verrà mantenuto, perciò sia i giocatori che il barbaro avranno unità LV 0");
                            break;
                        case "Costruzione":
                            Server.Send(clientGuid, $"Descrizione|Permette la costruzione di Strutture Militari, Civili, Caserme ed unità Militari");
                            break;
                        case "Ricerca":
                            Server.Send(clientGuid, $"Descrizione|La Ricerca è fondamentale per ogni città... Per il miglioramento delle strutture, la loro produzione, fino " +
                                $"al reclutamento delle unità, le stesse possono subire un miglioramento delle loro caratteristiche e del loro livello.");
                            break;
                    }
                    break;
                case "AttaccoCooperativo":
                    await AttacchiCooperativi.GestisciComando(msgArgs, clientGuid, player);
                    break;
                default: Console.WriteLine($"Messaggio: [{msgArgs}]"); break;
            }
           
        }
        static async Task<bool> New_Player(string username, string password, Guid guid)
        {
            var existingPlayer = Server.servers_.GetPlayer(username, password);
            if (existingPlayer != null) // Controlla se il giocatore esiste già
            {
                existingPlayer.guid_Player = guid; //Assegna il guid aggiornato
                Console.WriteLine("New Player: Il giocatore già esiste");
                return false;
            }
            if (await Server.servers_.Check_Username_Player(username)) // Controlla se il nome utente è disponibile
            {
                await Server.servers_.AddPlayer(username, password, guid);
                await GameSave.LoadPlayer(username, password);
                    return true;
            }
            return false;
        }
        static async Task<bool> Login(string username, string password, Guid guid)
        {
            var existingPlayer = Server.servers_.GetPlayer(username, password);
            if (existingPlayer != null) // Controlla se il giocatore esiste già
            {
                existingPlayer.guid_Player = guid; //Assegna il guid aggiornato
                Console.WriteLine("Login: Il giocatore già esiste");
                return true;
            }
            if (await Server.servers_.Check_Username_Player(username)) // Controlla se il nome utente è disponibile
            {
                if (await GameSave.LoadPlayer(username, password)) // Poi prova a caricare i dati salvati
                    return false;
            }
            return false;
        }

        public static async Task<bool> Load_User_Auto(string username, string password)
        {
            var existingPlayer = Server.servers_.GetPlayer_Data(username);
            if (existingPlayer != null) // Controlla se il giocatore esiste già
            {
                Console.WriteLine("Login: Il giocatore già esiste");
                return true;
            }

            // Controlla se il nome utente è disponibile
            if (await Server.servers_.Check_Username_Player(username))
            {
                await Server.servers_.AddPlayer(username, password, Guid.Empty); // Prima crea il nuovo giocatore
                if (await GameSave.LoadPlayer(username, password)) // Poi prova a caricare i dati salvati
                    return true;
            }
            return true;
        }


        public static async Task<bool> Update_Data(Guid guid, string username, string password)
        {
            var player = Server.servers_.GetPlayer(username, password);
            var buildingsQueue = player.GetQueuedBuildings();
            var unitsQueue = player.GetQueuedUnits();

            double Cibo = player.Guerrieri * Esercito.Unità.Guerriero.Cibo + player.Lancieri * Esercito.Unità.Lanciere.Cibo + player.Arceri * Esercito.Unità.Arciere.Cibo + player.Catapulte * Esercito.Unità.Catapulta.Cibo;
            double Oro = player.Guerrieri * Esercito.Unità.Guerriero.Salario + player.Lancieri * Esercito.Unità.Lanciere.Salario + player.Arceri * Esercito.Unità.Arciere.Salario + player.Catapulte * Esercito.Unità.Catapulta.Salario;

            Server.Send(guid, $"Update_Data|" +
                $"{player.Cibo.ToString("#,0")}|" +
                $"{player.Legno.ToString("#,0")}|" +
                $"{player.Pietra.ToString("#,0")}|" +
                $"{player.Ferro.ToString("#,0")}|" +
                $"{player.Oro.ToString("#,0")}|" +
                $"{player.Popolazione.ToString("#,0")}|" +

                $"{(player.Fattoria * (Strutture.Edifici.Fattoria.Produzione + player.Ricerca_Produzione * Ricerca.Tipi.Incremento.Cibo) - Cibo).ToString("#,0.00")}|" +
                $"{(player.Segheria * (Strutture.Edifici.Segheria.Produzione + player.Ricerca_Produzione * Ricerca.Tipi.Incremento.Legno)).ToString("#,0.00")}|" +
                $"{(player.CavaPietra * (Strutture.Edifici.CavaPietra.Produzione + player.Ricerca_Produzione * Ricerca.Tipi.Incremento.Pietra)).ToString("#,0.00")}|" +
                $"{(player.MinieraFerro * (Strutture.Edifici.MinieraFerro.Produzione + player.Ricerca_Produzione * Ricerca.Tipi.Incremento.Ferro)).ToString("#,0.00")}|" +
                $"{(player.MinieraOro * (Strutture.Edifici.MinieraOro.Produzione + player.Ricerca_Produzione * Ricerca.Tipi.Incremento.Oro) - Oro).ToString("#,0.00")}|" +
                $"{(player.Abitazioni * (Strutture.Edifici.Case.Produzione + player.Ricerca_Produzione * Ricerca.Tipi.Incremento.Popolazione)).ToString("#,0.000")}|" +

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
                $"{player.Frecce.ToString("#,0")}|" +

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

                $"{Dati.Server}|" +
                $"{Dati.Versione}|" +
                $"{Dati.Difficoltà}|" +

                $"{player.Livello}|" +
                $"{player.Esperienza.ToString("#,0")}|" +

                $"{player.Guerrieri_Barbari_PVE.ToString("#,0")}|" +
                $"{player.Lancieri_Barbari_PVE.ToString("#,0")}|" +
                $"{player.Arceri_Barbari_PVE.ToString("#,0")}|" +
                $"{player.Catapulte_Barbari_PVE.ToString("#,0")}|" +

                $"{Giocatori.Barbari.PVP.Guerrieri.ToString("#,0")}|" +
                $"{Giocatori.Barbari.PVP.Lancieri.ToString("#,0")}|" +
                $"{Giocatori.Barbari.PVP.Arceri.ToString("#,0")}|" +
                $"{Giocatori.Barbari.PVP.Catapulte.ToString("#,0")}|" +

                $"{player.forza_Esercito.ToString("#,0.00")}|" +
                $"{player.forza_Esercito_PVE.ToString("#,0.00")}|" +
                $"{Dati.forza_Esercito_Att_PVP.ToString("#,0.00")}|" +
                
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

            string testo = $"Raduno|";
            string testo2 = $"Raduni_Player|";
            if (AttacchiCooperativi.AttacchiInCorso.Keys.Count() > 0)
                foreach (string idAttacco in AttacchiCooperativi.AttacchiInCorso.Keys)
                {
                    var attacco = AttacchiCooperativi.AttacchiInCorso[idAttacco];
                    testo += $"{attacco.CreatoreUsername}|{idAttacco}|{attacco.TempoRimanente / 60}-";
                }

            if (AttacchiCooperativi.AttacchiInPlayer.Keys.Count() > 0)
                foreach (string idAttacco in AttacchiCooperativi.AttacchiInPlayer.Keys)
                {
                    var attacco = AttacchiCooperativi.AttacchiInPlayer[idAttacco];
                    var user = attacco.GiocatoriPartecipanti.Keys;
                    var users = attacco.GiocatoriPartecipanti.Values;

                    foreach (var item in attacco.GiocatoriPartecipanti.Keys)
                    {
                        if (player.Username == item)
                            foreach (var items in attacco.GiocatoriPartecipanti.Values)
                                if (items.Player == player.Username)
                                    testo2 += $"{item}|{idAttacco}|{attacco.TempoRimanente / 60}|{items.Guerrieri}|{items.Lancieri}|{items.Arcieri}|{items.Catapulte}-";
                    }
                }
            Server.Send(guid, testo); //Invia i raduni aperti
            Server.Send(guid, testo2); //Invia i raduni aperti


            stringa_Base = "";
            stringa_Base = $"{Server.Utenti_PVP.Count}";
            string stringa = "";
            foreach (var item in Server.Utenti_PVP)
                stringa = await costruisci_stringa(item);
            if (stringa != "")
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
