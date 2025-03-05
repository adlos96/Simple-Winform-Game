using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Strategico_V2.Interfacce
{
    public partial class Ricerca_Guid : Form
    {
        public Ricerca_Guid()
        {
            InitializeComponent();
        }

        private async void Ricerca_Guid_Load(object sender, EventArgs e)
        {
            await Login.Sleep(1);
            btn_Produzione.Text = "Produzione " + Variabili_Client.Ricerca_Produzione;
            btn_Costruzione.Text = "Costruzione " + Variabili_Client.Ricerca_Costruzione;
            btn_Addestramento.Text = "Addestramento " + Variabili_Client.Ricerca_Addestramento;

            btn_Salute_Guerrieri.Text = "Salute " + Variabili_Client.Ricerca_Salute_Guerrieri;
            btn_Difesa_Guerrieri.Text = "Difesa " + Variabili_Client.Ricerca_Difesa_Guerrieri;
            btn_Attacco_Guerrieri.Text = "Attacco " + Variabili_Client.Ricerca_Attacco_Guerrieri;
            btn_Livello_Guerrieri.Text = "Livello " + Variabili_Client.Ricerca_Livello_Guerrieri;

            btn_Salute_Lancieri.Text = "Salute " + Variabili_Client.Ricerca_Salute_Lancieri;
            btn_Difesa_Lancieri.Text = "Difesa " + Variabili_Client.Ricerca_Difesa_Lancieri;
            btn_Attacco_Lancieri.Text = "Attacco " + Variabili_Client.Ricerca_Attacco_Lancieri;
            btn_Livello_Lancieri.Text = "Livello " + Variabili_Client.Ricerca_Livello_Lancieri;

            btn_Salute_Arcieri.Text = "Salute " + Variabili_Client.Ricerca_Salute_Arcieri;
            btn_Difesa_Arcieri.Text = "Difesa " + Variabili_Client.Ricerca_Difesa_Arcieri;
            btn_Attacco_Arcieri.Text = "Attacco " + Variabili_Client.Ricerca_Attacco_Arcieri;
            btn_Livello_Arcieri.Text = "Livello " + Variabili_Client.Ricerca_Livello_Arcieri;

            btn_Salute_Catapulte.Text = "Salute " + Variabili_Client.Ricerca_Salute_Catapulte;
            btn_Difesa_Catapulte.Text = "Difesa " + Variabili_Client.Ricerca_Difesa_Catapulte;
            btn_Attacco_Catapulte.Text = "Attacco " + Variabili_Client.Ricerca_Attacco_Catapulte;
            btn_Livello_Catapulte.Text = "Livello " + Variabili_Client.Ricerca_Livello_Catapulte;
        }

        private void btn_Produzione_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Produzione");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Costruzione_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Costruzione");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Addestramento_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Addestramento");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Salute_Guerrieri_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Salute|Guerriero");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Difesa_Guerrieri_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Difesa|Guerriero");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Attacco_Guerrieri_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Attacco|Guerriero");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Livello_Guerrieri_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Livello|Guerriero");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Salute_Lancieri_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Salute|Lanciere");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Difesa_Lancieri_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Difesa|Lanciere");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Attacco_Lancieri_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Attacco|Lanciere");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Livello_Lancieri_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Livello|Lanciere");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Salute_Arcieri_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Salute|Arciere");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Difesa_Arcieri_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Difesa|Arciere");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Attacco_Arcieri_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Attacco|Arciere");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Livello_Arcieri_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Livello|Arciere");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Salute_Catapulte_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Salute|Catapulte");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Difesa_Catapulte_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Difesa|Catapulte");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Attacco_Catapulte_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Attacco|Catapulte");
            Ricerca_Guid_Load(sender, e);
        }

        private void btn_Livello_Catapulte_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Ricerca|{Variabili_Client.username}|{Variabili_Client.password}|Truppe|Livello|Catapulte");
            Ricerca_Guid_Load(sender, e);
        }
    }
}
