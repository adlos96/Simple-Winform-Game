
using static Server_Strategico.Esercito;
using static Server_Strategico.Ricerca;

namespace Server_Strategico
{
    internal class Ricerca
    {
        public class Tipi
        {
            public static CostoReclutamento Produzione = new CostoReclutamento
            {
                Cibo = 3000,
                Legno = 2750,
                Pietra = 2500,
                Ferro = 2250,
                Oro = 2000,
            };
            public static CostoReclutamento Costruzione = new CostoReclutamento
            {
                Cibo = 2000,
                Legno = 1750,
                Pietra = 1500,
                Ferro = 1500,
                Oro = 1250,
            };
            public static CostoReclutamento Addestramento = new CostoReclutamento
            {
                Cibo = 4000,
                Legno = 3500,
                Pietra = 3000,
                Ferro = 2750,
                Oro = 2500,
            };

            public static CostoReclutamento Incremento = new CostoReclutamento
            {
                Cibo = 0.15,
                Legno = 0.13,
                Pietra = 0.11,
                Ferro = 0.09,
                Oro = 0.07,
                Popolazione = 0.01
            };

        }
        public class Soldati
        {
            public static CostoReclutamento Salute = new CostoReclutamento
            {
                Cibo = 3000,
                Legno = 2750,
                Pietra = 2500,
                Ferro = 2250,
                Oro = 2000,
            };
            public static CostoReclutamento Difesa = new CostoReclutamento
            {
                Cibo = 2000,
                Legno = 1750,
                Pietra = 1500,
                Ferro = 1500,
                Oro = 1250,
            };
            public static CostoReclutamento Attacco = new CostoReclutamento
            {
                Cibo = 4000,
                Legno = 3500,
                Pietra = 3000,
                Ferro = 2750,
                Oro = 2500,
            };
            public static CostoReclutamento Livello = new CostoReclutamento
            {
                Cibo = 4000,
                Legno = 3500,
                Pietra = 3000,
                Ferro = 2750,
                Oro = 2500,
            };

            public static Unità Incremento = new Unità
            {
                Salute = 1,
                Difesa = 1,
                Attacco = 1
            };

        }

        public static async Task<bool> Ricerca_Produzione(Variabili.Player player, Guid clientGuid)
        {
            int livello = player.Ricerca_Produzione + 1;
            if (player.Cibo >= Tipi.Produzione.Cibo * livello &&
                player.Legno >= Tipi.Produzione.Legno * livello &&
                player.Pietra >= Tipi.Produzione.Pietra * livello &&
                player.Ferro >= Tipi.Produzione.Ferro * livello &&
                player.Oro >= Tipi.Produzione.Oro * livello)
            {
                // Sottrai le risorse necessarie
                player.Cibo -= Tipi.Produzione.Cibo * livello;
                player.Legno -= Tipi.Produzione.Legno * livello;
                player.Pietra -= Tipi.Produzione.Pietra * livello;
                player.Ferro -= Tipi.Produzione.Ferro * livello;
                player.Oro -= Tipi.Produzione.Oro * livello;

                Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di Produzione {livello}:\r\n " +
                    $"Cibo= {Tipi.Produzione.Cibo * livello}," +
                    $" Legno= {Tipi.Produzione.Legno * livello}," +
                    $" Pietra= {Tipi.Produzione.Pietra * livello}," +
                    $" Ferro= {Tipi.Produzione.Ferro * livello}," +
                    $" Oro= {Tipi.Produzione.Oro * livello}\r\n");
                Console.WriteLine($"Risorse utilizzate per la ricerca di Produzione {livello}:\r\n " +
                    $"Cibo= {Tipi.Produzione.Cibo * livello}, " +
                    $"Legno= {Tipi.Produzione.Legno * livello}, " +
                    $"Pietra= {Tipi.Produzione.Pietra * livello}, " +
                    $"Ferro= {Tipi.Produzione.Ferro * livello}, " +
                    $"Oro= {Tipi.Produzione.Oro * livello}\r\n");

                player.Ricerca_Produzione++;
                return true;
            }else
            {
                Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di Produzione {livello}:\r\n " +
                    $"Cibo= {Tipi.Produzione.Cibo * livello}," +
                    $" Legno= {Tipi.Produzione.Legno * livello}," +
                    $" Pietra= {Tipi.Produzione.Pietra * livello}," +
                    $" Ferro= {Tipi.Produzione.Ferro * livello}," +
                    $" Oro= {Tipi.Produzione.Oro * livello}\r\n");
                Console.WriteLine($"Risorse insufficienti per la ricerca di Produzione {livello}:\r\n " +
                    $"Cibo= {Tipi.Produzione.Cibo * livello}, " +
                    $"Legno= {Tipi.Produzione.Legno * livello}, " +
                    $"Pietra= {Tipi.Produzione.Pietra * livello}, " +
                    $"Ferro= {Tipi.Produzione.Ferro * livello}, " +
                    $"Oro= {Tipi.Produzione.Oro * livello}\r\n");
                    return false;
            }
        }
        public static async Task<bool> Ricerca_Costruzione(Variabili.Player player, Guid clientGuid)
        {
            int livello = player.Ricerca_Costruzione + 1;
            if (player.Cibo >= Tipi.Costruzione.Cibo        * livello &&
                player.Legno >= Tipi.Costruzione.Legno      * livello &&
                player.Pietra >= Tipi.Costruzione.Pietra    * livello &&
                player.Ferro >= Tipi.Costruzione.Ferro      * livello &&
                player.Oro >= Tipi.Costruzione.Oro          * livello)
            {
                // Sottrai le risorse necessarie
                player.Cibo -= Tipi.Costruzione.Cibo        * livello;
                player.Legno -= Tipi.Costruzione.Legno      * livello;
                player.Pietra -= Tipi.Costruzione.Pietra    * livello;
                player.Ferro -= Tipi.Costruzione.Ferro      * livello;
                player.Oro -= Tipi.Costruzione.Oro          * livello;

                Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di Costruzione {livello}:\r\n " +
                    $"Cibo= {Tipi.Costruzione.Cibo      * livello}," +
                    $" Legno= {Tipi.Costruzione.Legno * livello}," +
                    $" Pietra= {Tipi.Costruzione.Pietra * livello}," +
                    $" Ferro= {Tipi.Costruzione.Ferro * livello}," +
                    $" Oro= {Tipi.Costruzione.Oro * livello}\r\n");
                Console.WriteLine($"Risorse utilizzate per la ricerca di Costruzione {livello}:\r\n " +
                    $"Cibo= {Tipi.Costruzione.Cibo * livello}, " +
                    $"Legno= {Tipi.Costruzione.Legno * livello}, " +
                    $"Pietra= {Tipi.Costruzione.Pietra * livello}, " +
                    $"Ferro= {Tipi.Costruzione.Ferro * livello}, " +
                    $"Oro= {Tipi.Costruzione.Oro * livello}\r\n");

                player.Ricerca_Costruzione++;
                return true;
            }
            else
            {
                Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di Costruzione {livello}:\r\n " +
                    $"Cibo= {Tipi.Costruzione.Cibo * livello}," +
                    $" Legno= {Tipi.Costruzione.Legno * livello}," +
                    $" Pietra= {Tipi.Costruzione.Pietra * livello}," +
                    $" Ferro= {Tipi.Costruzione.Ferro * livello}," +
                    $" Oro= {Tipi.Costruzione.Oro * livello}\r\n");
                Console.WriteLine($"Risorse insufficienti per la ricerca di Costruzione {livello}:\r\n " +
                    $"Cibo= {Tipi.Costruzione.Cibo * livello}, " +
                    $"Legno= {Tipi.Costruzione.Legno * livello}, " +
                    $"Pietra= {Tipi.Costruzione.Pietra * livello}, " +
                    $"Ferro= {Tipi.Costruzione.Ferro * livello}, " +
                    $"Oro= {Tipi.Costruzione.Oro * livello}\r\n");
                return false;
            }
        }
        public static async Task<bool> Ricerca_Addestramento(Variabili.Player player, Guid clientGuid)
        {
            int livello = player.Ricerca_Addestramento + 1;
            int valore = player.Ricerca_Addestramento * 3;

            if (player.Livello < valore)
            {
                Server.Send(clientGuid, $"Log_Server|La ricerca Addestramento {livello}, richiede che il livello del giocatore sia almeno: {valore}\r\n");
                Console.WriteLine($"La ricerca Addestramento {livello}, richiede che il livello del giocatore sia almeno: {valore}\r\n");
                return false;
            }
            if (player.Cibo >= Tipi.Addestramento.Cibo * livello &&
                player.Legno >= Tipi.Addestramento.Legno * livello &&
                player.Pietra >= Tipi.Addestramento.Pietra * livello &&
                player.Ferro >= Tipi.Addestramento.Ferro * livello &&
                player.Oro >= Tipi.Addestramento.Oro * livello)
            {
                // Sottrai le risorse necessarie
                player.Cibo -= Tipi.Addestramento.Cibo * livello;
                player.Legno -= Tipi.Addestramento.Legno * livello;
                player.Pietra -= Tipi.Addestramento.Pietra * livello;
                player.Ferro -= Tipi.Addestramento.Ferro * livello;
                player.Oro -= Tipi.Addestramento.Oro * livello;

                Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di Addestramento {livello}:\r\n " +
                    $"Cibo= {Tipi.Addestramento.Cibo * livello}," +
                    $" Legno= {Tipi.Addestramento.Legno * livello}," +
                    $" Pietra= {Tipi.Addestramento.Pietra * livello}," +
                    $" Ferro= {Tipi.Addestramento.Ferro * livello}," +
                    $" Oro= {Tipi.Addestramento.Oro * livello}\r\n");
                Console.WriteLine($"Risorse utilizzate per la ricerca di Addestramento {livello}:\r\n " +
                    $"Cibo= {Tipi.Addestramento.Cibo * livello}, " +
                    $"Legno= {Tipi.Addestramento.Legno * livello}, " +
                    $"Pietra= {Tipi.Addestramento.Pietra * livello}, " +
                    $"Ferro= {Tipi.Addestramento.Ferro * livello}, " +
                    $"Oro= {Tipi.Addestramento.Oro * livello}\r\n");

                player.Ricerca_Addestramento++;
                return true;
            }
            else
            {
                Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di Addestramento {livello}:\r\n " +
                    $"Cibo= {Tipi.Addestramento.Cibo * livello}," +
                    $" Legno= {Tipi.Addestramento.Legno * livello}," +
                    $" Pietra= {Tipi.Addestramento.Pietra * livello}," +
                    $" Ferro= {Tipi.Addestramento.Ferro * livello}," +
                    $" Oro= {Tipi.Addestramento.Oro * livello}\r\n");
                Console.WriteLine($"Risorse insufficienti per la ricerca di Addestramento {livello}:\r\n " +
                    $"Cibo= {Tipi.Addestramento.Cibo * livello}, " +
                    $"Legno= {Tipi.Addestramento.Legno * livello}, " +
                    $"Pietra= {Tipi.Addestramento.Pietra * livello}, " +
                    $"Ferro= {Tipi.Addestramento.Ferro * livello}, " +
                    $"Oro= {Tipi.Addestramento.Oro * livello}\r\n");
                return false;
            }
        }

        public static async Task<bool> Ricerca_Truppe(Variabili.Player player, Guid clientGuid, string tipo, string unità)
        {
            int livello = 0, valore = 0;
            switch (unità)
            {
                case "Guerriero":
                    if (tipo == "Salute")
                    {
                        livello = player.Guerriero_Salute + 1;
                        valore = livello;

                        if (livello == 0) livello = 1;
                        if (valore == 0) valore = 2;

                        if (player.Guerriero_Livello < valore * 2)
                        {
                            Server.Send(clientGuid, $"Log_Server|La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            Console.WriteLine($"La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            return false;
                        }

                        if (player.Cibo >= Soldati.Salute.Cibo * livello &&
                            player.Legno >= Soldati.Salute.Legno * livello &&
                            player.Pietra >= Soldati.Salute.Pietra * livello &&
                            player.Ferro >= Soldati.Salute.Ferro * livello &&
                            player.Oro >= Soldati.Salute.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Salute.Cibo * livello;
                            player.Legno -= Soldati.Salute.Legno * livello;
                            player.Pietra -= Soldati.Salute.Pietra * livello;
                            player.Ferro -= Soldati.Salute.Ferro * livello;
                            player.Oro -= Soldati.Salute.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}," +
                                $" Legno= {Soldati.Salute.Legno * livello}," +
                                $" Pietra= {Soldati.Salute.Pietra * livello}," +
                                $" Ferro= {Soldati.Salute.Ferro * livello}," +
                                $" Oro= {Soldati.Salute.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}, " +
                                $"Legno= {Soldati.Salute.Legno * livello}, " +
                                $"Pietra= {Soldati.Salute.Pietra * livello}, " +
                                $"Ferro= {Soldati.Salute.Ferro * livello}, " +
                                $"Oro= {Soldati.Salute.Oro * livello}\r\n");

                            player.Guerriero_Salute++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}," +
                                $" Legno= {Soldati.Salute.Legno * livello}," +
                                $" Pietra= {Soldati.Salute.Pietra * livello}," +
                                $" Ferro= {Soldati.Salute.Ferro * livello}," +
                                $" Oro= {Soldati.Salute.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}, " +
                                $"Legno= {Soldati.Salute.Legno * livello}, " +
                                $"Pietra= {Soldati.Salute.Pietra * livello}, " +
                                $"Ferro= {Soldati.Salute.Ferro * livello}, " +
                                $"Oro= {Soldati.Salute.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    else if (tipo == "Difesa")
                    {
                        livello = player.Guerriero_Difesa + 1;
                        valore = livello;

                        if (livello == 0) livello = 1;
                        if (valore == 0) valore = 2;

                        if (player.Guerriero_Livello < valore * 2)
                        {
                            Server.Send(clientGuid, $"Log_Server|La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            Console.WriteLine($"La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            return false;
                        }

                        if (player.Cibo >= Soldati.Difesa.Cibo * livello &&
                            player.Legno >= Soldati.Difesa.Legno * livello &&
                            player.Pietra >= Soldati.Difesa.Pietra * livello &&
                            player.Ferro >= Soldati.Difesa.Ferro * livello &&
                            player.Oro >= Soldati.Difesa.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Difesa.Cibo * livello;
                            player.Legno -= Soldati.Difesa.Legno * livello;
                            player.Pietra -= Soldati.Difesa.Pietra * livello;
                            player.Ferro -= Soldati.Difesa.Ferro * livello;
                            player.Oro -= Soldati.Difesa.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}," +
                                $" Legno= {Soldati.Difesa.Legno * livello}," +
                                $" Pietra= {Soldati.Difesa.Pietra * livello}," +
                                $" Ferro= {Soldati.Difesa.Ferro * livello}," +
                                $" Oro= {Soldati.Difesa.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}, " +
                                $"Legno= {Soldati.Difesa.Legno * livello}, " +
                                $"Pietra= {Soldati.Difesa.Pietra * livello}, " +
                                $"Ferro= {Soldati.Difesa.Ferro * livello}, " +
                                $"Oro= {Soldati.Difesa.Oro * livello}\r\n");

                            player.Guerriero_Difesa++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}," +
                                $" Legno= {Soldati.Difesa.Legno * livello}," +
                                $" Pietra= {Soldati.Difesa.Pietra * livello}," +
                                $" Ferro= {Soldati.Difesa.Ferro * livello}," +
                                $" Oro= {Soldati.Difesa.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}, " +
                                $"Legno= {Soldati.Difesa.Legno * livello}, " +
                                $"Pietra= {Soldati.Difesa.Pietra * livello}, " +
                                $"Ferro= {Soldati.Difesa.Ferro * livello}, " +
                                $"Oro= {Soldati.Difesa.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    else if (tipo == "Attacco")
                    {
                        livello = player.Guerriero_Attacco + 1;
                        valore = livello;

                        if (livello == 0) livello = 1;
                        if (valore == 0) valore = 2;

                        if (player.Guerriero_Livello < valore * 2)
                        {
                            Server.Send(clientGuid, $"Log_Server|La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            Console.WriteLine($"La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            return false;
                        }

                        if (player.Cibo >= Soldati.Attacco.Cibo * livello &&
                            player.Legno >= Soldati.Attacco.Legno * livello &&
                            player.Pietra >= Soldati.Attacco.Pietra * livello &&
                            player.Ferro >= Soldati.Attacco.Ferro * livello &&
                            player.Oro >= Soldati.Attacco.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Attacco.Cibo * livello;
                            player.Legno -= Soldati.Attacco.Legno * livello;
                            player.Pietra -= Soldati.Attacco.Pietra * livello;
                            player.Ferro -= Soldati.Attacco.Ferro * livello;
                            player.Oro -= Soldati.Attacco.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}," +
                                $" Legno= {Soldati.Attacco.Legno * livello}," +
                                $" Pietra= {Soldati.Attacco.Pietra * livello}," +
                                $" Ferro= {Soldati.Attacco.Ferro * livello}," +
                                $" Oro= {Soldati.Attacco.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}, " +
                                $"Legno= {Soldati.Attacco.Legno * livello}, " +
                                $"Pietra= {Soldati.Attacco.Pietra * livello}, " +
                                $"Ferro= {Soldati.Attacco.Ferro * livello}, " +
                                $"Oro= {Soldati.Attacco.Oro * livello}\r\n");

                            player.Guerriero_Attacco++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}," +
                                $" Legno= {Soldati.Attacco.Legno * livello}," +
                                $" Pietra= {Soldati.Attacco.Pietra * livello}," +
                                $" Ferro= {Soldati.Attacco.Ferro * livello}," +
                                $" Oro= {Soldati.Attacco.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}, " +
                                $"Legno= {Soldati.Attacco.Legno * livello}, " +
                                $"Pietra= {Soldati.Attacco.Pietra * livello}, " +
                                $"Ferro= {Soldati.Attacco.Ferro * livello}, " +
                                $"Oro= {Soldati.Attacco.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    else if (tipo == "Livello")
                    {
                        livello = player.Guerriero_Livello + 1;

                        if (player.Cibo >= Soldati.Livello.Cibo * livello &&
                            player.Legno >= Soldati.Livello.Legno * livello &&
                            player.Pietra >= Soldati.Livello.Pietra * livello &&
                            player.Ferro >= Soldati.Livello.Ferro * livello &&
                            player.Oro >= Soldati.Livello.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Livello.Cibo * livello;
                            player.Legno -= Soldati.Livello.Legno * livello;
                            player.Pietra -= Soldati.Livello.Pietra * livello;
                            player.Ferro -= Soldati.Livello.Ferro * livello;
                            player.Oro -= Soldati.Livello.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {unità} {tipo} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}," +
                                $" Legno= {Soldati.Livello.Legno * livello}," +
                                $" Pietra= {Soldati.Livello.Pietra * livello}," +
                                $" Ferro= {Soldati.Livello.Ferro * livello}," +
                                $" Oro= {Soldati.Livello.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {unità} {tipo} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}, " +
                                $"Legno= {Soldati.Livello.Legno * livello}, " +
                                $"Pietra= {Soldati.Livello.Pietra * livello}, " +
                                $"Ferro= {Soldati.Livello.Ferro * livello}, " +
                                $"Oro= {Soldati.Livello.Oro * livello}\r\n");

                            player.Guerriero_Livello++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {unità} {tipo} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}," +
                                $" Legno= {Soldati.Livello.Legno * livello}," +
                                $" Pietra= {Soldati.Livello.Pietra * livello}," +
                                $" Ferro= {Soldati.Livello.Ferro * livello}," +
                                $" Oro= {Soldati.Livello.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {unità} {tipo} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}, " +
                                $"Legno= {Soldati.Livello.Legno * livello}, " +
                                $"Pietra= {Soldati.Livello.Pietra * livello}, " +
                                $"Ferro= {Soldati.Livello.Ferro * livello}, " +
                                $"Oro= {Soldati.Livello.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    Console.WriteLine($"Ricerca {tipo} {unità} completata!");
                    break;
                case "Lanciere":
                    if (tipo == "Salute")
                    {
                        livello = player.Lanciere_Salute + 1;
                        valore = livello;
                        if (livello == 0) livello = 1;
                        if (valore == 0) valore = 2;

                        if (player.Lanciere_Livello < valore * 2)
                        {
                            Server.Send(clientGuid, $"Log_Server|La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            Console.WriteLine($"La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            return false;
                        }
                        if (player.Cibo >= Soldati.Salute.Cibo * livello &&
                            player.Legno >= Soldati.Salute.Legno * livello &&
                            player.Pietra >= Soldati.Salute.Pietra * livello &&
                            player.Ferro >= Soldati.Salute.Ferro * livello &&
                            player.Oro >= Soldati.Salute.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Salute.Cibo * livello;
                            player.Legno -= Soldati.Salute.Legno * livello;
                            player.Pietra -= Soldati.Salute.Pietra * livello;
                            player.Ferro -= Soldati.Salute.Ferro * livello;
                            player.Oro -= Soldati.Salute.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}," +
                                $" Legno= {Soldati.Salute.Legno * livello}," +
                                $" Pietra= {Soldati.Salute.Pietra * livello}," +
                                $" Ferro= {Soldati.Salute.Ferro * livello}," +
                                $" Oro= {Soldati.Salute.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}, " +
                                $"Legno= {Soldati.Salute.Legno * livello}, " +
                                $"Pietra= {Soldati.Salute.Pietra * livello}, " +
                                $"Ferro= {Soldati.Salute.Ferro * livello}, " +
                                $"Oro= {Soldati.Salute.Oro * livello}\r\n");

                            player.Lanciere_Salute++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}," +
                                $" Legno= {Soldati.Salute.Legno * livello}," +
                                $" Pietra= {Soldati.Salute.Pietra * livello}," +
                                $" Ferro= {Soldati.Salute.Ferro * livello}," +
                                $" Oro= {Soldati.Salute.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}, " +
                                $"Legno= {Soldati.Salute.Legno * livello}, " +
                                $"Pietra= {Soldati.Salute.Pietra * livello}, " +
                                $"Ferro= {Soldati.Salute.Ferro * livello}, " +
                                $"Oro= {Soldati.Salute.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    else if (tipo == "Difesa")
                    {
                        livello = player.Lanciere_Difesa + 1;
                        valore = livello;
                        if (livello == 0) livello = 1;
                        if (valore == 0) valore = 2;

                        if (player.Lanciere_Livello < valore * 2)
                        {
                            Server.Send(clientGuid, $"Log_Server|La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            Console.WriteLine($"La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            return false;
                        }
                        if (player.Cibo >= Soldati.Difesa.Cibo * livello &&
                            player.Legno >= Soldati.Difesa.Legno * livello &&
                            player.Pietra >= Soldati.Difesa.Pietra * livello &&
                            player.Ferro >= Soldati.Difesa.Ferro * livello &&
                            player.Oro >= Soldati.Difesa.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Difesa.Cibo * livello;
                            player.Legno -= Soldati.Difesa.Legno * livello;
                            player.Pietra -= Soldati.Difesa.Pietra * livello;
                            player.Ferro -= Soldati.Difesa.Ferro * livello;
                            player.Oro -= Soldati.Difesa.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}," +
                                $" Legno= {Soldati.Difesa.Legno * livello}," +
                                $" Pietra= {Soldati.Difesa.Pietra * livello}," +
                                $" Ferro= {Soldati.Difesa.Ferro * livello}," +
                                $" Oro= {Soldati.Difesa.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}, " +
                                $"Legno= {Soldati.Difesa.Legno * livello}, " +
                                $"Pietra= {Soldati.Difesa.Pietra * livello}, " +
                                $"Ferro= {Soldati.Difesa.Ferro * livello}, " +
                                $"Oro= {Soldati.Difesa.Oro * livello}\r\n");

                            player.Lanciere_Difesa++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}," +
                                $" Legno= {Soldati.Difesa.Legno * livello}," +
                                $" Pietra= {Soldati.Difesa.Pietra * livello}," +
                                $" Ferro= {Soldati.Difesa.Ferro * livello}," +
                                $" Oro= {Soldati.Difesa.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}, " +
                                $"Legno= {Soldati.Difesa.Legno * livello}, " +
                                $"Pietra= {Soldati.Difesa.Pietra * livello}, " +
                                $"Ferro= {Soldati.Difesa.Ferro * livello}, " +
                                $"Oro= {Soldati.Difesa.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    else if (tipo == "Attacco")
                    {
                        livello = player.Lanciere_Attacco + 1;
                        valore = livello;
                        if (livello == 0) livello = 1;
                        if (valore == 0) valore = 2;

                        if (player.Lanciere_Livello < valore * 2)
                        {
                            Server.Send(clientGuid, $"Log_Server|La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            Console.WriteLine($"La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            return false;
                        }
                        if (player.Cibo >= Soldati.Attacco.Cibo * livello &&
                            player.Legno >= Soldati.Attacco.Legno * livello &&
                            player.Pietra >= Soldati.Attacco.Pietra * livello &&
                            player.Ferro >= Soldati.Attacco.Ferro * livello &&
                            player.Oro >= Soldati.Attacco.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Attacco.Cibo * livello;
                            player.Legno -= Soldati.Attacco.Legno * livello;
                            player.Pietra -= Soldati.Attacco.Pietra * livello;
                            player.Ferro -= Soldati.Attacco.Ferro * livello;
                            player.Oro -= Soldati.Attacco.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}," +
                                $" Legno= {Soldati.Attacco.Legno * livello}," +
                                $" Pietra= {Soldati.Attacco.Pietra * livello}," +
                                $" Ferro= {Soldati.Attacco.Ferro * livello}," +
                                $" Oro= {Soldati.Attacco.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}, " +
                                $"Legno= {Soldati.Attacco.Legno * livello}, " +
                                $"Pietra= {Soldati.Attacco.Pietra * livello}, " +
                                $"Ferro= {Soldati.Attacco.Ferro * livello}, " +
                                $"Oro= {Soldati.Attacco.Oro * livello}\r\n");

                            player.Lanciere_Attacco++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}," +
                                $" Legno= {Soldati.Attacco.Legno * livello}," +
                                $" Pietra= {Soldati.Attacco.Pietra * livello}," +
                                $" Ferro= {Soldati.Attacco.Ferro * livello}," +
                                $" Oro= {Soldati.Attacco.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}, " +
                                $"Legno= {Soldati.Attacco.Legno * livello}, " +
                                $"Pietra= {Soldati.Attacco.Pietra * livello}, " +
                                $"Ferro= {Soldati.Attacco.Ferro * livello}, " +
                                $"Oro= {Soldati.Attacco.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    else if (tipo == "Livello")
                    {
                        livello = player.Lanciere_Livello + 1;

                        if (player.Cibo >= Soldati.Livello.Cibo * livello &&
                            player.Legno >= Soldati.Livello.Legno * livello &&
                            player.Pietra >= Soldati.Livello.Pietra * livello &&
                            player.Ferro >= Soldati.Livello.Ferro * livello &&
                            player.Oro >= Soldati.Livello.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Livello.Cibo * livello;
                            player.Legno -= Soldati.Livello.Legno * livello;
                            player.Pietra -= Soldati.Livello.Pietra * livello;
                            player.Ferro -= Soldati.Livello.Ferro * livello;
                            player.Oro -= Soldati.Livello.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {unità} {tipo} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}," +
                                $" Legno= {Soldati.Livello.Legno * livello}," +
                                $" Pietra= {Soldati.Livello.Pietra * livello}," +
                                $" Ferro= {Soldati.Livello.Ferro * livello}," +
                                $" Oro= {Soldati.Livello.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {unità} {tipo} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}, " +
                                $"Legno= {Soldati.Livello.Legno * livello}, " +
                                $"Pietra= {Soldati.Livello.Pietra * livello}, " +
                                $"Ferro= {Soldati.Livello.Ferro * livello}, " +
                                $"Oro= {Soldati.Livello.Oro * livello}\r\n");

                            player.Lanciere_Livello++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}," +
                                $" Legno= {Soldati.Livello.Legno * livello}," +
                                $" Pietra= {Soldati.Livello.Pietra * livello}," +
                                $" Ferro= {Soldati.Livello.Ferro * livello}," +
                                $" Oro= {Soldati.Livello.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}, " +
                                $"Legno= {Soldati.Livello.Legno * livello}, " +
                                $"Pietra= {Soldati.Livello.Pietra * livello}, " +
                                $"Ferro= {Soldati.Livello.Ferro * livello}, " +
                                $"Oro= {Soldati.Livello.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    Console.WriteLine($"Ricerca {tipo} {unità} completata!");
                    break;
                case "Arciere":
                    if (tipo == "Salute")
                    {
                        livello = player.Arciere_Salute + 1;
                        valore = livello;

                        if (livello == 0) livello = 1;
                        if (valore == 0) valore = 2;

                        if (player.Arciere_Livello < valore * 2)
                        {
                            Server.Send(clientGuid, $"Log_Server|La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            Console.WriteLine($"La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            return false;
                        }

                        if (player.Cibo >= Soldati.Salute.Cibo * livello &&
                            player.Legno >= Soldati.Salute.Legno * livello &&
                            player.Pietra >= Soldati.Salute.Pietra * livello &&
                            player.Ferro >= Soldati.Salute.Ferro * livello &&
                            player.Oro >= Soldati.Salute.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Salute.Cibo * livello;
                            player.Legno -= Soldati.Salute.Legno * livello;
                            player.Pietra -= Soldati.Salute.Pietra * livello;
                            player.Ferro -= Soldati.Salute.Ferro * livello;
                            player.Oro -= Soldati.Salute.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}," +
                                $" Legno= {Soldati.Salute.Legno * livello}," +
                                $" Pietra= {Soldati.Salute.Pietra * livello}," +
                                $" Ferro= {Soldati.Salute.Ferro * livello}," +
                                $" Oro= {Soldati.Salute.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}, " +
                                $"Legno= {Soldati.Salute.Legno * livello}, " +
                                $"Pietra= {Soldati.Salute.Pietra * livello}, " +
                                $"Ferro= {Soldati.Salute.Ferro * livello}, " +
                                $"Oro= {Soldati.Salute.Oro * livello}\r\n");

                            player.Arciere_Salute++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}," +
                                $" Legno= {Soldati.Salute.Legno * livello}," +
                                $" Pietra= {Soldati.Salute.Pietra * livello}," +
                                $" Ferro= {Soldati.Salute.Ferro * livello}," +
                                $" Oro= {Soldati.Salute.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}, " +
                                $"Legno= {Soldati.Salute.Legno * livello}, " +
                                $"Pietra= {Soldati.Salute.Pietra * livello}, " +
                                $"Ferro= {Soldati.Salute.Ferro * livello}, " +
                                $"Oro= {Soldati.Salute.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    else if (tipo == "Difesa")
                    {
                        livello = player.Arciere_Difesa + 1;
                        valore = livello;

                        if (livello == 0) livello = 1;
                        if (valore == 0) valore = 2;

                        if (player.Arciere_Livello < valore * 2)
                        {
                            Server.Send(clientGuid, $"Log_Server|La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            Console.WriteLine($"La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            return false;
                        }
                        if (player.Cibo >= Soldati.Difesa.Cibo * livello &&
                            player.Legno >= Soldati.Difesa.Legno * livello &&
                            player.Pietra >= Soldati.Difesa.Pietra * livello &&
                            player.Ferro >= Soldati.Difesa.Ferro * livello &&
                            player.Oro >= Soldati.Difesa.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Difesa.Cibo * livello;
                            player.Legno -= Soldati.Difesa.Legno * livello;
                            player.Pietra -= Soldati.Difesa.Pietra * livello;
                            player.Ferro -= Soldati.Difesa.Ferro * livello;
                            player.Oro -= Soldati.Difesa.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}," +
                                $" Legno= {Soldati.Difesa.Legno * livello}," +
                                $" Pietra= {Soldati.Difesa.Pietra * livello}," +
                                $" Ferro= {Soldati.Difesa.Ferro * livello}," +
                                $" Oro= {Soldati.Difesa.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}, " +
                                $"Legno= {Soldati.Difesa.Legno * livello}, " +
                                $"Pietra= {Soldati.Difesa.Pietra * livello}, " +
                                $"Ferro= {Soldati.Difesa.Ferro * livello}, " +
                                $"Oro= {Soldati.Difesa.Oro * livello}\r\n");

                            player.Arciere_Difesa++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}," +
                                $" Legno= {Soldati.Difesa.Legno * livello}," +
                                $" Pietra= {Soldati.Difesa.Pietra * livello}," +
                                $" Ferro= {Soldati.Difesa.Ferro * livello}," +
                                $" Oro= {Soldati.Difesa.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}, " +
                                $"Legno= {Soldati.Difesa.Legno * livello}, " +
                                $"Pietra= {Soldati.Difesa.Pietra * livello}, " +
                                $"Ferro= {Soldati.Difesa.Ferro * livello}, " +
                                $"Oro= {Soldati.Difesa.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    else if (tipo == "Attacco")
                    {
                        livello = player.Arciere_Attacco + 1;
                        valore = livello;

                        if (livello == 0) livello = 1;
                        if (valore == 0) valore = 2;

                        if (player.Arciere_Livello < valore * 2)
                        {
                            Server.Send(clientGuid, $"Log_Server|La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            Console.WriteLine($"La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            return false;
                        }

                        if (player.Cibo >= Soldati.Attacco.Cibo * livello &&
                            player.Legno >= Soldati.Attacco.Legno * livello &&
                            player.Pietra >= Soldati.Attacco.Pietra * livello &&
                            player.Ferro >= Soldati.Attacco.Ferro * livello &&
                            player.Oro >= Soldati.Attacco.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Attacco.Cibo * livello;
                            player.Legno -= Soldati.Attacco.Legno * livello;
                            player.Pietra -= Soldati.Attacco.Pietra * livello;
                            player.Ferro -= Soldati.Attacco.Ferro * livello;
                            player.Oro -= Soldati.Attacco.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}," +
                                $" Legno= {Soldati.Attacco.Legno * livello}," +
                                $" Pietra= {Soldati.Attacco.Pietra * livello}," +
                                $" Ferro= {Soldati.Attacco.Ferro * livello}," +
                                $" Oro= {Soldati.Attacco.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}, " +
                                $"Legno= {Soldati.Attacco.Legno * livello}, " +
                                $"Pietra= {Soldati.Attacco.Pietra * livello}, " +
                                $"Ferro= {Soldati.Attacco.Ferro * livello}, " +
                                $"Oro= {Soldati.Attacco.Oro * livello}\r\n");

                            player.Arciere_Attacco++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}," +
                                $" Legno= {Soldati.Attacco.Legno * livello}," +
                                $" Pietra= {Soldati.Attacco.Pietra * livello}," +
                                $" Ferro= {Soldati.Attacco.Ferro * livello}," +
                                $" Oro= {Soldati.Attacco.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}, " +
                                $"Legno= {Soldati.Attacco.Legno * livello}, " +
                                $"Pietra= {Soldati.Attacco.Pietra * livello}, " +
                                $"Ferro= {Soldati.Attacco.Ferro * livello}, " +
                                $"Oro= {Soldati.Attacco.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    else if (tipo == "Livello")
                    {
                        livello = player.Arciere_Livello + 1;
                        if (player.Cibo >= Soldati.Livello.Cibo * livello &&
                            player.Legno >= Soldati.Livello.Legno * livello &&
                            player.Pietra >= Soldati.Livello.Pietra * livello &&
                            player.Ferro >= Soldati.Livello.Ferro * livello &&
                            player.Oro >= Soldati.Livello.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Livello.Cibo * livello;
                            player.Legno -= Soldati.Livello.Legno * livello;
                            player.Pietra -= Soldati.Livello.Pietra * livello;
                            player.Ferro -= Soldati.Livello.Ferro * livello;
                            player.Oro -= Soldati.Livello.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}," +
                                $" Legno= {Soldati.Livello.Legno * livello}," +
                                $" Pietra= {Soldati.Livello.Pietra * livello}," +
                                $" Ferro= {Soldati.Livello.Ferro * livello}," +
                                $" Oro= {Soldati.Livello.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}, " +
                                $"Legno= {Soldati.Livello.Legno * livello}, " +
                                $"Pietra= {Soldati.Livello.Pietra * livello}, " +
                                $"Ferro= {Soldati.Livello.Ferro * livello}, " +
                                $"Oro= {Soldati.Livello.Oro * livello}\r\n");

                            player.Arciere_Livello++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}," +
                                $" Legno= {Soldati.Livello.Legno * livello}," +
                                $" Pietra= {Soldati.Livello.Pietra * livello}," +
                                $" Ferro= {Soldati.Livello.Ferro * livello}," +
                                $" Oro= {Soldati.Livello.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}, " +
                                $"Legno= {Soldati.Livello.Legno * livello}, " +
                                $"Pietra= {Soldati.Livello.Pietra * livello}, " +
                                $"Ferro= {Soldati.Livello.Ferro * livello}, " +
                                $"Oro= {Soldati.Livello.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    Console.WriteLine($"Ricerca {tipo} {unità} completata!");
                    break;
                case "Catapulte":
                    if (tipo == "Salute")
                    {
                        livello = player.catapulta_Salute + 1;
                        valore = livello;

                        if (livello == 0) livello = 1;
                        if (valore == 0) valore = 2;

                        if (player.catapulta_Livello < valore * 2)
                        {
                            Server.Send(clientGuid, $"Log_Server|La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            Console.WriteLine($"La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            return false;
                        }

                        if (player.Cibo >= Soldati.Salute.Cibo * livello &&
                            player.Legno >= Soldati.Salute.Legno * livello &&
                            player.Pietra >= Soldati.Salute.Pietra * livello &&
                            player.Ferro >= Soldati.Salute.Ferro * livello &&
                            player.Oro >= Soldati.Salute.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Salute.Cibo * livello;
                            player.Legno -= Soldati.Salute.Legno * livello;
                            player.Pietra -= Soldati.Salute.Pietra * livello;
                            player.Ferro -= Soldati.Salute.Ferro * livello;
                            player.Oro -= Soldati.Salute.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}," +
                                $" Legno= {Soldati.Salute.Legno * livello}," +
                                $" Pietra= {Soldati.Salute.Pietra * livello}," +
                                $" Ferro= {Soldati.Salute.Ferro * livello}," +
                                $" Oro= {Soldati.Salute.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}, " +
                                $"Legno= {Soldati.Salute.Legno * livello}, " +
                                $"Pietra= {Soldati.Salute.Pietra * livello}, " +
                                $"Ferro= {Soldati.Salute.Ferro * livello}, " +
                                $"Oro= {Soldati.Salute.Oro * livello}\r\n");

                            player.catapulta_Salute++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}," +
                                $" Legno= {Soldati.Salute.Legno * livello}," +
                                $" Pietra= {Soldati.Salute.Pietra * livello}," +
                                $" Ferro= {Soldati.Salute.Ferro * livello}," +
                                $" Oro= {Soldati.Salute.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Salute.Cibo * livello}, " +
                                $"Legno= {Soldati.Salute.Legno * livello}, " +
                                $"Pietra= {Soldati.Salute.Pietra * livello}, " +
                                $"Ferro= {Soldati.Salute.Ferro * livello}, " +
                                $"Oro= {Soldati.Salute.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    else if (tipo == "Difesa")
                    {
                        livello = player.catapulta_Difesa + 1;
                        valore = livello;

                        if (livello == 0) livello = 1;
                        if (valore == 0) valore = 2;

                        if (player.catapulta_Livello < valore * 2)
                        {
                            Server.Send(clientGuid, $"Log_Server|La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            Console.WriteLine($"La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            return false;
                        }

                        if (player.Cibo >= Soldati.Difesa.Cibo * livello &&
                            player.Legno >= Soldati.Difesa.Legno * livello &&
                            player.Pietra >= Soldati.Difesa.Pietra * livello &&
                            player.Ferro >= Soldati.Difesa.Ferro * livello &&
                            player.Oro >= Soldati.Difesa.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Difesa.Cibo * livello;
                            player.Legno -= Soldati.Difesa.Legno * livello;
                            player.Pietra -= Soldati.Difesa.Pietra * livello;
                            player.Ferro -= Soldati.Difesa.Ferro * livello;
                            player.Oro -= Soldati.Difesa.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}," +
                                $" Legno= {Soldati.Difesa.Legno * livello}," +
                                $" Pietra= {Soldati.Difesa.Pietra * livello}," +
                                $" Ferro= {Soldati.Difesa.Ferro * livello}," +
                                $" Oro= {Soldati.Difesa.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}, " +
                                $"Legno= {Soldati.Difesa.Legno * livello}, " +
                                $"Pietra= {Soldati.Difesa.Pietra * livello}, " +
                                $"Ferro= {Soldati.Difesa.Ferro * livello}, " +
                                $"Oro= {Soldati.Difesa.Oro * livello}\r\n");

                            player.catapulta_Difesa++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}," +
                                $" Legno= {Soldati.Difesa.Legno * livello}," +
                                $" Pietra= {Soldati.Difesa.Pietra * livello}," +
                                $" Ferro= {Soldati.Difesa.Ferro * livello}," +
                                $" Oro= {Soldati.Difesa.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Difesa.Cibo * livello}, " +
                                $"Legno= {Soldati.Difesa.Legno * livello}, " +
                                $"Pietra= {Soldati.Difesa.Pietra * livello}, " +
                                $"Ferro= {Soldati.Difesa.Ferro * livello}, " +
                                $"Oro= {Soldati.Difesa.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    else if (tipo == "Attacco")
                    {
                        livello = player.catapulta_Attacco + 1;
                        valore = livello;

                        if (livello == 0) livello = 1;
                        if (valore == 0) valore = 2;

                        if (player.catapulta_Livello < valore * 2)
                        {
                            Server.Send(clientGuid, $"Log_Server|La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            Console.WriteLine($"La ricerca {tipo} {unità} {livello}, richiede che il {unità} sia almeno di livello: {valore * 2}\r\n");
                            return false;
                        }

                        if (player.Cibo >= Soldati.Attacco.Cibo * livello &&
                            player.Legno >= Soldati.Attacco.Legno * livello &&
                            player.Pietra >= Soldati.Attacco.Pietra * livello &&
                            player.Ferro >= Soldati.Attacco.Ferro * livello &&
                            player.Oro >= Soldati.Attacco.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Attacco.Cibo * livello;
                            player.Legno -= Soldati.Attacco.Legno * livello;
                            player.Pietra -= Soldati.Attacco.Pietra * livello;
                            player.Ferro -= Soldati.Attacco.Ferro * livello;
                            player.Oro -= Soldati.Attacco.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}," +
                                $" Legno= {Soldati.Attacco.Legno * livello}," +
                                $" Pietra= {Soldati.Attacco.Pietra * livello}," +
                                $" Ferro= {Soldati.Attacco.Ferro * livello}," +
                                $" Oro= {Soldati.Attacco.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}, " +
                                $"Legno= {Soldati.Attacco.Legno * livello}, " +
                                $"Pietra= {Soldati.Attacco.Pietra * livello}, " +
                                $"Ferro= {Soldati.Attacco.Ferro * livello}, " +
                                $"Oro= {Soldati.Attacco.Oro * livello}\r\n");

                            player.catapulta_Attacco++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}," +
                                $" Legno= {Soldati.Attacco.Legno * livello}," +
                                $" Pietra= {Soldati.Attacco.Pietra * livello}," +
                                $" Ferro= {Soldati.Attacco.Ferro * livello}," +
                                $" Oro= {Soldati.Attacco.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Attacco.Cibo * livello}, " +
                                $"Legno= {Soldati.Attacco.Legno * livello}, " +
                                $"Pietra= {Soldati.Attacco.Pietra * livello}, " +
                                $"Ferro= {Soldati.Attacco.Ferro * livello}, " +
                                $"Oro= {Soldati.Attacco.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    else if (tipo == "Livello")
                    {
                        livello = player.catapulta_Livello + 1;
                        if (player.Cibo >= Soldati.Livello.Cibo * livello &&
                            player.Legno >= Soldati.Livello.Legno * livello &&
                            player.Pietra >= Soldati.Livello.Pietra * livello &&
                            player.Ferro >= Soldati.Livello.Ferro * livello &&
                            player.Oro >= Soldati.Livello.Oro * livello)
                        {
                            // Sottrai le risorse necessarie
                            player.Cibo -= Soldati.Livello.Cibo * livello;
                            player.Legno -= Soldati.Livello.Legno * livello;
                            player.Pietra -= Soldati.Livello.Pietra * livello;
                            player.Ferro -= Soldati.Livello.Ferro * livello;
                            player.Oro -= Soldati.Livello.Oro * livello;

                            Server.Send(clientGuid, $"Log_Server|Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}," +
                                $" Legno= {Soldati.Livello.Legno * livello}," +
                                $" Pietra= {Soldati.Livello.Pietra * livello}," +
                                $" Ferro= {Soldati.Livello.Ferro * livello}," +
                                $" Oro= {Soldati.Livello.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse utilizzate per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}, " +
                                $"Legno= {Soldati.Livello.Legno * livello}, " +
                                $"Pietra= {Soldati.Livello.Pietra * livello}, " +
                                $"Ferro= {Soldati.Livello.Ferro * livello}, " +
                                $"Oro= {Soldati.Livello.Oro * livello}\r\n");

                            player.catapulta_Livello++;
                            return true;
                        }
                        else
                        {
                            Server.Send(clientGuid, $"Log_Server|Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}," +
                                $" Legno= {Soldati.Livello.Legno * livello}," +
                                $" Pietra= {Soldati.Livello.Pietra * livello}," +
                                $" Ferro= {Soldati.Livello.Ferro * livello}," +
                                $" Oro= {Soldati.Livello.Oro * livello}\r\n");
                            Console.WriteLine($"Risorse insufficienti per la ricerca di {tipo} {unità} {livello}:\r\n " +
                                $"Cibo= {Soldati.Livello.Cibo * livello}, " +
                                $"Legno= {Soldati.Livello.Legno * livello}, " +
                                $"Pietra= {Soldati.Livello.Pietra * livello}, " +
                                $"Ferro= {Soldati.Livello.Ferro * livello}, " +
                                $"Oro= {Soldati.Livello.Oro * livello}\r\n");
                            return false;
                        }
                    }
                    Console.WriteLine($"Ricerca {tipo} {unità} completata!");
                    break;
                // Aggiungi case per altri tipi di ricerche
                default:
                    Console.WriteLine($"Il tipo di ricerca {tipo} {unità} non supportata!");
                    break;
            }
            return false;
        }
    }
}
