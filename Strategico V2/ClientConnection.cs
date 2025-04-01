using System;
using System.Linq;
using System.Text;
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
            public static string _ServerIp = "79.51.195.120"; // adly.xed.im 185.229.236.183
            //public static string _ServerIp = "79.44.11.166"; // adly.xed.im 185.229.236.183
            private static int _ServerPort = 8443;
            private static bool _Ssl = false;
            private static string _CertFile = "";
            private static string _CertPass = "Password1";
            private static bool _DebugMessages = true;
            private static bool _AcceptInvalidCerts = true;
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
                string messaggio = Encoding.UTF8.GetString(args.Data);

                Console.WriteLine("Messaggio Ricevuto");
                Console.WriteLine("Ricevuto: " + messaggio);
                string[] mess = null;
                if (messaggio.Contains('|'))
                {
                    mess = messaggio.Split('|');
                    switch (mess[0])
                    {
                        case "Login": if (mess[1] == "true") Variabili_Client.login = true; else Variabili_Client.login = false; break;
                        case "Update_Data": Update_Data(mess); break;
                        case "Log_Server": Update_Log(mess[1]); break;
                        case "Update_PVP_Player": Update_PVP_List(mess); break;
                        case "Descrizione": Update_Desc(mess[1]); break;
                        case "Raduno": Update_Lista_Raduni(mess); break;
                        case "Raduni_Player": Update_Lista_Raduni_Player(mess); break;
                        case "RadunoPartecipo":
                            Update_Raduni_Partecipazione(mess);
                            break;

                        default: Console.WriteLine($"[Errore] >> [{messaggio}] Comando non riconosciuto"); break;
                    }
                }

                var comando = mess[0];
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

                Variabili_Client.Risorse_s_Spade    = mess[31];       //Consumabili
                Variabili_Client.Risorse_s_Lance    = mess[32];       //Consumabili
                Variabili_Client.Risorse_s_Archi    = mess[33];       //Consumabili
                Variabili_Client.Risorse_s_Scudi    = mess[34];       //Consumabili
                Variabili_Client.Risorse_s_Armature = mess[35];       //Consumabili
                Variabili_Client.Risorse_s_Frecce   = mess[36];       //Consumabili

                Variabili_Client.Guerrieri = mess[37];
                Variabili_Client.Lancieri = mess[38];
                Variabili_Client.Arceri = mess[39];
                Variabili_Client.Catapulte = mess[40];

                Variabili_Client.Server = mess[41];
                Variabili_Client.Versione = mess[42];
                Variabili_Client.Difficoltà = mess[43];

                Variabili_Client.Livello = mess[44];
                Variabili_Client.Esperienza = mess[45];

                Variabili_Client.Barbari.PVE.Guerrieri = mess[46];
                Variabili_Client.Barbari.PVE.Lancieri = mess[47];
                Variabili_Client.Barbari.PVE.Arceri = mess[48];
                Variabili_Client.Barbari.PVE.Catapulte = mess[49];

                Variabili_Client.Barbari.PVP.Guerrieri = mess[50];
                Variabili_Client.Barbari.PVP.Lancieri = mess[51];
                Variabili_Client.Barbari.PVP.Arceri = mess[52];
                Variabili_Client.Barbari.PVP.Catapulte = mess[53];

                Variabili_Client.Forza_Esercito = mess[54];
                Variabili_Client.Forza_Esercito_PVE = mess[55];
                Variabili_Client.Forza_Esercito_PVP = mess[56];

                Variabili_Client.Fattoria_Coda = mess[57];
                Variabili_Client.Segheria_Coda = mess[58];
                Variabili_Client.CavaPietra_Coda = mess[59];
                Variabili_Client.MinieraFerro_Coda = mess[60];
                Variabili_Client.MinieraOro_Coda = mess[61];
                Variabili_Client.Case_Coda = mess[62];

                Variabili_Client.ProduzioneSpade_Coda = mess[63];
                Variabili_Client.ProduzioneLance_Coda = mess[64];
                Variabili_Client.ProduzioneArchi_Coda = mess[65];
                Variabili_Client.ProduzioneScudi_Coda = mess[66];
                Variabili_Client.ProduzioneArmature_Coda = mess[67];
                Variabili_Client.ProduzioneFrecce_Coda = mess[68];

                Variabili_Client.Guerrieri_Coda = mess[69];
                Variabili_Client.Lancieri_Coda = mess[70];
                Variabili_Client.Arceri_Coda = mess[71];
                Variabili_Client.Catapulte_Coda = mess[72];

                //Ricerca
                Variabili_Client.Ricerca_Salute_Guerrieri = mess[73];
                Variabili_Client.Ricerca_Difesa_Guerrieri = mess[74];
                Variabili_Client.Ricerca_Attacco_Guerrieri = mess[75];
                Variabili_Client.Ricerca_Livello_Guerrieri = mess[76];

                Variabili_Client.Ricerca_Salute_Lancieri = mess[77];
                Variabili_Client.Ricerca_Difesa_Lancieri = mess[78];
                Variabili_Client.Ricerca_Attacco_Lancieri = mess[79];
                Variabili_Client.Ricerca_Livello_Lancieri = mess[80];

                Variabili_Client.Ricerca_Salute_Arcieri = mess[81];
                Variabili_Client.Ricerca_Difesa_Arcieri = mess[82];
                Variabili_Client.Ricerca_Attacco_Arcieri = mess[83];
                Variabili_Client.Ricerca_Livello_Arcieri = mess[84];

                Variabili_Client.Ricerca_Salute_Catapulte = mess[85];
                Variabili_Client.Ricerca_Difesa_Catapulte = mess[86];
                Variabili_Client.Ricerca_Attacco_Catapulte = mess[87];
                Variabili_Client.Ricerca_Livello_Catapulte = mess[88];

                Variabili_Client.Ricerca_Produzione = mess[89];
                Variabili_Client.Ricerca_Costruzione = mess[90];
                Variabili_Client.Ricerca_Addestramento = mess[91];
            }
            static void Update_Log(string mes)
            {
                Home.Log_Update(mes);
            }
            static void Update_Desc(string mes)
            {
                Home.Desc_Update(mes);
            }
            static void Update_PVP_List(string[] mess)
            {
                if (mess[1] != "")
                    for (int i = 2; i <= mess.Count() -1; i++)
                    {
                        if (!Variabili_Client.Giocatori_PVP.Contains(mess[i]) && !Variabili_Client.username.Contains(mess[i]))
                            Variabili_Client.Giocatori_PVP.Add(mess[i]);
                    }
                
            }
            static void Update_Lista_Raduni(string[] mess)
            {
                // Ignora il primo elemento (che è "Lista_Raduni")
                // e ricostruisci la stringa originale
                var datiCompleti = string.Join("|", mess.Skip(1)).Split('-');

                if (Variabili_Client.Raduni_Creati.Count == 0)
                    foreach (string attacco in datiCompleti)
                    {
                        var dato = attacco.Split('|');
                        if (!string.IsNullOrEmpty(attacco))
                            Variabili_Client.Raduni_Creati.Add(dato[0] + " - " + dato[1] + " - " + dato[2]);
                    }
                else
                {
                    if (datiCompleti.Count() - 1 < Variabili_Client.Raduni_Creati.Count)
                        Variabili_Client.Raduni_Creati.Clear();

                    foreach (string attacco in datiCompleti)
                    {
                        var dato = attacco.Split('|');
                        if (!string.IsNullOrEmpty(attacco))
                            if (!Variabili_Client.Raduni_Creati.Contains(dato[0] + " - " + dato[1] + " - " + dato[2]))
                                Variabili_Client.Raduni_Creati.Add(dato[0] + " - " + dato[1] + " - " + dato[2]);
                    }
                }
            }

            static void Update_Lista_Raduni_Player(string[] mess)
            {
                // Ignora il primo elemento (che è "Lista_Raduni")
                // e ricostruisci la stringa originale
                var datiCompleti = string.Join("|", mess.Skip(1)).Split('-');

                if (Variabili_Client.Raduni_InCorso.Count == 0)
                    foreach (string attacco in datiCompleti)
                    {
                        var dato = attacco.Split('|');
                        if (!string.IsNullOrEmpty(attacco))
                            Variabili_Client.Raduni_InCorso.Add(dato[0] + " - " + dato[1] + " - " + dato[2] + " - " + dato[3] + " - " + dato[4] + " - " + dato[5] + " - " + dato[6]);
                    }
                else
                {
                    if (datiCompleti.Count() - 1 < Variabili_Client.Raduni_InCorso.Count)
                        Variabili_Client.Raduni_InCorso.Clear();
                
                    foreach (string attacco in datiCompleti)
                    {
                        var dato = attacco.Split('|');
                        if (!string.IsNullOrEmpty(attacco))
                            if (!Variabili_Client.Raduni_InCorso.Contains(dato[0] + " - " + dato[1] + " - " + dato[2] + " - " + dato[3] + " - " + dato[4] + " - " + dato[5] + " - " + dato[6]))
                                Variabili_Client.Raduni_InCorso.Add(dato[0] + " - " + dato[1] + " - " + dato[2] + " - " + dato[3] + " - " + dato[4] + " - " + dato[5] + " - " + dato[6]);
                    }
                }
            }

            static async void Update_Raduni_Partecipazione(string[] mess)
            {
                // Formato: CreatoreUsername|ID|NumPartecipanti|MieiGuerrieri|MieiLancieri|MieiArcieri|MieiCatapulte|TempoRimanente
                var raduno = new Variabili_Client.AttaccoPartecipazione
                {
                    Creatore = mess[1],
                    ID = mess[2],
                    NumPartecipanti = int.Parse(mess[3]),
                    MieiGuerrieri = int.Parse(mess[4]),
                    MieiLancieri = int.Parse(mess[5]),
                    MieiArcieri = int.Parse(mess[6]),
                    MieiCatapulte = int.Parse(mess[7]),
                    TempoRimanente = int.Parse(mess[8])
                };
            }
        }

    }
}
