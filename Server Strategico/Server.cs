using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatsonTcp;
using static Server_Strategico.Variabili;

namespace Server_Strategico
{
    internal class Server
    {
        private string? serverIp = null; // "null" will open the tcp server on addr 0.0.0.0 on windows (127.0.0.1 on linux)
        private const int serverPort = 8443;
        private static Guid lastGuid = Guid.Empty;
        public static WatsonTcpServer server = null;

        private static string _CertFile = "";
        private static string _CertPass = "";

        private static bool _Ssl = true;
        private static bool _AcceptInvalidCerts = false;
        private static bool _MutualAuth = false;

        private CancellationTokenSource cts;
        private Task gameLoopTask;
        private GameServer servers_ = new GameServer();

        private Server()
        {
            string subjectName = Environment.MachineName; //Ottine il nome della macchina (hostname)
            if (subjectName == "DESKTOP-DOBLVTI") serverIp = "0.0.0.0";

            if (!_Ssl) server = new WatsonTcpServer(serverIp, serverPort);
            else
            {
                string OS = "Windosw";
                if (OS == "Linux")
                    _CertFile = Password.path;
                else
                    _CertFile = Password.path;
                _CertPass = Password.pasword;
                _AcceptInvalidCerts = true;
                _MutualAuth = true;

                server = new WatsonTcpServer(serverIp, serverPort, _CertFile, _CertPass);
                server.Settings.AcceptInvalidCertificates = _AcceptInvalidCerts;
                server.Settings.MutuallyAuthenticate = _MutualAuth;
            }

            server.Events.ClientConnected += ClientConnected;
            server.Events.MessageReceived += MessageReceived;
            server.Events.ClientDisconnected += ClientDisconnected;
            server.Events.ExceptionEncountered += ExceptionEncountered;

            server.Settings.Logger = Logger;
            server.Settings.NoDelay = true;
            server.Keepalive.EnableTcpKeepAlives = true;
            server.Keepalive.TcpKeepAliveInterval = 1;
            server.Keepalive.TcpKeepAliveTime = 1;
            server.Keepalive.TcpKeepAliveRetryCount = 3;
            server.Start();

            Console.WriteLine("[SERVER|LOG] (Info) > [WatsonTcpServer] Server Inizializzato");
            Console.WriteLine("");
            StartGame();

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Info Comandi: \"?\"");
                var userInput = Console.ReadLine() ?? string.Empty;

                switch (userInput)
                {
                    case "?":
                        Console.WriteLine("");
                        Console.WriteLine("                         *** Command ***");
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine("Comando vuoto:                 []");                      // 

                        Console.WriteLine("----------------------------------------------------------------------");
                        break;

                    default: Console.WriteLine("[Server] >> Comando sconosciuto"); break;
                }
            }
        }
        private async Task StartGame()
        {
            servers_.AddPlayer("Player1");
            servers_.AddPlayer("Player2");
            await NewPlayer("Player1");
            await NewPlayer("Player2");
            var player1 = servers_.GetPlayer("Player1");
            var player2 = servers_.GetPlayer("Player2");

            player1.QueueBuildConstruction("Fattoria", 1); // Costruisci 10 fattorie
            player1.QueueTrainUnits("Arciere", 1); // Avvia l'addestramento di 5 arcieri

            player2.QueueBuildConstruction("Fattoria", 1); // Costruisci 10 fattorie,
            player2.QueueTrainUnits("Arciere", 1); // Avvia l'addestramento di 5 arcieri

            // Simula il passare del tempo sul server
            cts = new CancellationTokenSource();
            gameLoopTask = servers_.RunGameLoopAsync(cts.Token);
        }
        private async Task StopGame()
        {
            if (cts != null)
            {
                cts.Cancel(); // Ferma il loop di gioco
                await gameLoopTask; // Attende che il loop si fermi completamente
                Console.WriteLine("Il gioco è terminato.");
            }
            else
                Console.WriteLine("Il gioco non è attualmente in esecuzione.");
            
        }

        private async Task NewPlayer(string player)
        {
            var player1 = servers_.GetPlayer(player);
            player1.Cibo = 4000;
            player1.Legno = 4000;
            player1.Pietra = 4000;
            player1.Ferro = 4000;
            player1.Oro = 4000;
            player1.Popolazione = 20;
        }
        // ----------------------- Client Connessione --------------------------
        static void ClientConnected(object? sender, ConnectionEventArgs args)
        {
            lastGuid = args.Client.Guid;
            string lasIpPort = args.Client.IpPort;
            Console.WriteLine("[SERVER|LOG] > Client connesso: " + args.Client.ToString());

            var ciao = lasIpPort.Split(":");
        }
        static void ClientDisconnected(object? sender, DisconnectionEventArgs args)
        {
            Console.WriteLine("[SERVER|LOG] > Client disconnesso: " + args.Client.ToString() + ": " + args.Reason.ToString());
        }
        private static void ExceptionEncountered(object sender, ExceptionEventArgs e)
        {
            Console.WriteLine(server.SerializationHelper.SerializeJson(e.Exception, true));
        }
        
        // ----------------------- Server --------------------------
        public static WatsonTcpServer GetInstance()
        {
            if (server == null) new Server();
            return server;
        }
        static void MessageReceived(object? sender, MessageReceivedEventArgs args)
        {
            Console.Write("[SERVER|LOG] > " + args.Data.Length + " byte message from " + args.Client + ": " + "\r");
            if (args.Data != null || args.Data.Length != 0) ServerConnection.HandleClientRequest(args);
            else Console.WriteLine("[SERVER|LOG] > [null]");
        }
        static void Logger(Severity sev, string msg)
        {
            Console.WriteLine("[SERVER|LOG] (" + sev.ToString() + ") > " + msg);
        }
    }
}
