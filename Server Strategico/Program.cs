namespace Server_Strategico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameSave.Initialize(); // Inizializza il sistema di salvataggio
            Server.GetInstance(); // Starta il server
        }
    }
}
