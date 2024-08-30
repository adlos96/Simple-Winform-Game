using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WatsonTcp;

namespace Strategico_V2
{
    internal class ClientConnection
    {
        public static string argomento_Invio = "";
        public static string argomento_Ricevuto = "";
        public static bool client_Connesso = false;

        internal class TestClient
        {
            public static string _ServerIp = "127.1"; // adly.xed.im 185.229.236.183
            //public static string _ServerIp = "185.229.236.183"; // adly.xed.im 185.229.236.183
            private static int _ServerPort = 8443;
            private static bool _Ssl = true;
            private static string _CertFile = "";
            private static string _CertPass = "Password1";
            private static bool _DebugMessages = true;
            private static bool _AcceptInvalidCerts = false;
            private static bool _MutualAuth = false;
            private static WatsonTcpClient _Client = null;
            private static string _PresharedKey = null;


            public static Task InitializeClient()
            {
                return Task.Run(async () => //Crea un task e gli assegna un blocco istruzioni da eseguire.
                {
                    bool runForever = true;
                    bool success;

                    Console.WriteLine("Client partito");
                    Console.WriteLine($"Use SSL: {_Ssl}");

                    if (_Ssl)
                    {
                        bool supplyCert = true;
                        Console.WriteLine($"Supply SSL certificate: {supplyCert}");

                        if (supplyCert)
                        {
                            _CertFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + $@"/Documents/Client.pfx";
                            _CertPass = "Password1";
                        }

                        _AcceptInvalidCerts = true;
                        _MutualAuth = true;
                        Console.WriteLine($"Accept invalid certs: {_AcceptInvalidCerts}");
                        Console.WriteLine($"Mutually authenticate: {_MutualAuth}");
                    }
                    await ConnectClient();
                });
            }
            public static Task ConnectClient()
            {
                return Task.Run(() => //Crea un task e gli assegna un blocco istruzioni da eseguire.
                {
                    if (_Client != null) _Client.Dispose();
                    if (!_Ssl) _Client = new WatsonTcpClient(_ServerIp, _ServerPort);
                    else
                    {
                        _Client = new WatsonTcpClient(_ServerIp, _ServerPort, _CertFile, _CertPass);
                        _Client.Settings.AcceptInvalidCertificates = _AcceptInvalidCerts;
                        _Client.Settings.MutuallyAuthenticate = _MutualAuth;
                    }
                    _Client.Events.AuthenticationFailure += AuthenticationFailure;
                    _Client.Events.AuthenticationSucceeded += AuthenticationSucceeded;
                    _Client.Events.ServerConnected += ServerConnected;
                    _Client.Events.ServerDisconnected += ServerDisconnected;
                    _Client.Events.MessageReceived += MessageReceived;
                    _Client.Events.ExceptionEncountered += ExceptionEncountered; //???

                    _Client.Callbacks.AuthenticationRequested = AuthenticationRequested;

                    // _Client.Settings.IdleServerTimeoutMs = 5000;
                    _Client.Settings.DebugMessages = _DebugMessages;
                    _Client.Settings.Logger = Logger;
                    _Client.Settings.NoDelay = true;

                    _Client.Keepalive.EnableTcpKeepAlives = true;
                    _Client.Keepalive.TcpKeepAliveInterval = 1;
                    _Client.Keepalive.TcpKeepAliveTime = 1;
                    _Client.Keepalive.TcpKeepAliveRetryCount = 3;

                    _Client.Connect();
                    client_Connesso = true;
                });
            }
            private static void ExceptionEncountered(object sender, ExceptionEventArgs e)
            {
                Console.WriteLine("*** Exception ***");
                Console.WriteLine(e.ToString());
            }
            private static string AuthenticationRequested()
            {
                // return "0000000000000000";
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Server requests authentication");
                Console.WriteLine("Press ENTER and THEN enter your preshared key");
                if (String.IsNullOrEmpty(_PresharedKey)) _PresharedKey = _CertPass;
                return _PresharedKey;
            }
            private static void ServerConnected(object sender, ConnectionEventArgs args)
            {
                Console.WriteLine("Server connected"); // Controlla se c'è una connessione col server
                client_Connesso = true;
            }
            private static void ServerDisconnected(object sender, DisconnectionEventArgs args)
            {
                Console.WriteLine("Server disconnected: " + args.Reason.ToString());
                client_Connesso = false;
            }
            private static void Logger(Severity sev, string msg)
            {
                Console.WriteLine("[" + sev.ToString().PadRight(9) + "] " + msg);
            }

            private static void AuthenticationSucceeded(object sender, EventArgs args)
            {
                Console.WriteLine("Authentication succeeded");
            }
            private static void AuthenticationFailure(object sender, EventArgs args)
            {
                Console.WriteLine("Authentication failed");
            }
            private static void MessageReceived(object sender, MessageReceivedEventArgs args)
            {
                Console.Write("Message from server: ");
                if (args.Data == null)
                {
                    Console.WriteLine("[null]");
                    return;
                }
                string messaggio_Ricevuto = Encoding.UTF8.GetString(args.Data); // Ottenimento Risposta dal server

                Console.WriteLine("Messaggio Ricevuto");
                Console.WriteLine("Ricevuto: " + messaggio_Ricevuto);

                var msgArgs = messaggio_Ricevuto.Split('|');

                if (msgArgs.Length < 0)
                { Console.WriteLine("[Errore|ServerConnection] >> needed 1 args"); return; }

                switch (msgArgs[0])
                {
                    case "simulazione": Console.WriteLine("Prova"); break;

                    default: Console.WriteLine($"[Errore] >> [{messaggio_Ricevuto}] Comando non riconosciuto"); break;
                }

                var comando = msgArgs[0];
                Console.WriteLine("");
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Comando:        {comando}");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("");

                switch (comando)
                {
                    //case "plotSwap": Message_Recived_PlotSwap(msgArgs); break;      // Risposta prezzo per plot
                    //case "statusPayment": Message_Recived_StatusPayment(msgArgs); break; // Risposta timer payment usdt
                }
            }
        }

    }
}
