using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatsonTcp;

namespace Server_Strategico
{
    internal class ServerConnection
    {
        public static void HandleClientRequest(MessageReceivedEventArgs requestData)
        {
            var client = requestData.Client.ToString();
            var clientGuid = requestData.Client.Guid;
            var messaggioRicevuto = Encoding.UTF8.GetString(requestData.Data);

            //Variabili.server_Log.Add()
           Console.WriteLine("", "standard", "server", "no");
           Console.WriteLine("             ** Comunicazione Client **  ", "verde", "server", "si");
           Console.WriteLine("-----------------------------", "standard", "server", "si");
           Console.WriteLine($"[ServerConnection|ClientRequest] > Client:      {client}", "standard", "server", "si");
           Console.WriteLine($"[ServerConnection|ClientRequest] > Guid:        [{clientGuid}]", "standard", "server", "si");
           Console.WriteLine($"[ServerConnection|ClientRequest] > Messaggio:   [{messaggioRicevuto}]", "standard", "server", "si");

            if (!messaggioRicevuto.Contains("|"))
            {
                Console.WriteLine($"[Errore|ServerConnection] >> Messaggio ricevuto: {messaggioRicevuto}", "rosso", "server", "si");
                return;
            }
            var msgArgs = messaggioRicevuto.Split('|'); // Composto da 3 part1 0|1|2 -> 0 = percorso file
            if (msgArgs.Length == 0)
            {
                Console.WriteLine("[Errore|ServerConnection] >> needed 1 args", "rosso", "server", "si");
                return;
            }
            switch (msgArgs[0])
            {
                case "login": Console.WriteLine("Comando: [{msgArgs}]"); break;
                default: Console.WriteLine($"Messaggio: [{msgArgs}]"); break;
            }
           
        }
    }
}
