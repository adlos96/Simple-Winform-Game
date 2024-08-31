using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            public static WatsonTcpClient _Client = null;
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
                    Send("Connesso");
                });
            }
            public static void Send(string messaggio)
            {
                _Client.SendAsync(messaggio);
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
                    case "Login": if (msgArgs[1] == "true") Variabili_Client.login = true; else Variabili_Client.login = false; break;
                    case "Update_Data": Update_Data(msgArgs); break;
                    case "Log_Server": Update_Log(msgArgs[1]); break;


                    default: Console.WriteLine($"[Errore] >> [{messaggio_Ricevuto}] Comando non riconosciuto"); break;
                }

                var comando = msgArgs[0];
                Console.WriteLine("");
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Comando:        {comando}");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("");
            }

            static void Update_Data(string[] mess)
            {
                Variabili_Client.Cibo = mess[1];          //Risorse
                Variabili_Client.Legno = mess[2];         //Risorse
                Variabili_Client.Pietra = mess[3];        //Risorse
                Variabili_Client.Ferro = mess[4];         //Risorse
                Variabili_Client.Oro = mess[5];           //Risorse
                Variabili_Client.Popolazione = mess[6];   //Risorse

                Variabili_Client.Risorse_s_Cibo = mess[7];           //Risorse al S
                Variabili_Client.Risorse_s_Legno = mess[8];          //Risorse al S
                Variabili_Client.Risorse_s_Pietra = mess[9];         //Risorse al S
                Variabili_Client.Risorse_s_Ferro = mess[10];         //Risorse al S
                Variabili_Client.Risorse_s_Oro = mess[11];           //Risorse al S
                Variabili_Client.Risorse_s_Popolazione = mess[12];   //Risorse al S

                Variabili_Client.Fattoria = mess[13];                //Edifici
                Variabili_Client.Segheria = mess[14];                //Edifici
                Variabili_Client.CavaPietra = mess[15];              //Edifici
                Variabili_Client.MinieraFerro = mess[16];            //Edifici
                Variabili_Client.MinieraOro = mess[17];              //Edifici
                Variabili_Client.Case = mess[18];                    //Edifici

                Variabili_Client.ProduzioneSpade = mess[19];
                Variabili_Client.ProduzioneLance = mess[20];
                Variabili_Client.ProduzioneArchi = mess[21];
                Variabili_Client.ProduzioneScudi = mess[22];
                Variabili_Client.ProduzioneArmature = mess[23];
                Variabili_Client.ProduzioneFrecce = mess[24];

                Variabili_Client.Spade = mess[25];                   //Edifici
                Variabili_Client.Lance = mess[26];                   //Edifici
                Variabili_Client.Archi = mess[27];                   //Edifici
                Variabili_Client.Scudi = mess[28];                   //Edifici
                Variabili_Client.Armature = mess[29];                //Edifici
                Variabili_Client.Frecce = mess[30];                  //Edifici

                Variabili_Client.Risorse_s_Spade = mess[31];       //Consumabili
                Variabili_Client.Risorse_s_Lance = mess[32];       //Consumabili
                Variabili_Client.Risorse_s_Archi = mess[33];       //Consumabili
                Variabili_Client.Risorse_s_Scudi = mess[34];      //Consumabili
                Variabili_Client.Risorse_s_Armature = mess[35];   //Consumabili
                Variabili_Client.Risorse_s_Frecce = mess[36];     //Consumabili

                Variabili_Client.Guerrieri = mess[37];
                Variabili_Client.Lancieri = mess[38];
                Variabili_Client.Arceri = mess[39];
                Variabili_Client.Catapulte = mess[40];

                Variabili_Client.Server = mess[41];
                Variabili_Client.Versione = mess[42];
                Variabili_Client.Difficoltà = mess[43];
            }
            static void Update_Log(string mes)
            {
                Home.Log_Update(mes);
            }
        }

    }
}
