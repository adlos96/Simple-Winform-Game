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
    public partial class AttaccoCoordinato : Form
    {
        public AttaccoCoordinato()
        {
            InitializeComponent();
        }
        private async void AttaccoCoordinato_Load(object sender, EventArgs e)
        {
            await Load_Guid();
        }

        private async Task Load_Guid()
        {
            comboBox_Raduni_Creati.Items.Clear();
            comboBox_Raduni_InCorso.Items.Clear();
            if (Variabili_Client.Raduni_Creati.Count != 0)
                foreach (string attaccoStr in Variabili_Client.Raduni_Creati)
                {
                    var attacco = Variabili_Client.AttaccoInfo.FromString(attaccoStr);
                    if (attacco != null)
                    {
                        comboBox_Raduni_Creati.Items.Add($"{attacco.Creatore} - {attacco.ID} - {attacco.TempoRimanente}");
                    }
                }
            if (comboBox_Raduni_Creati.Items.Count > 0) comboBox_Raduni_Creati.Text = comboBox_Raduni_Creati.Items[0].ToString();

            if (Variabili_Client.Raduni_InCorso.Count != 0) 
                foreach (string attaccoStr in Variabili_Client.Raduni_InCorso)
                {
                    var attacco = Variabili_Client.PartecipanteAttacco.FromString(attaccoStr);
                    if (attacco != null)
                    {
                        comboBox_Raduni_InCorso.Items.Add($"{attacco.Giocatore} - {attacco.ID} - {attacco.TempoRimanente}");
                    }
                }
            if (comboBox_Raduni_InCorso.Items.Count > 0) 
                comboBox_Raduni_InCorso.Text = comboBox_Raduni_InCorso.Items[0].ToString();

            if (comboBox_Raduni_InCorso.Text == "")
            {
                txt_Guerriero_Spedizione.Text = "0";
                txt_Lanciere_Spedizione.Text = "0";
                txt_Arciere_Spedizione.Text = "0";
                txt_Catapulta_Spedizione.Text = "0";
            }

            txt_Guerriero_Esercito.Text = Variabili_Client.Guerrieri;
            txt_Lanciere_Esercito.Text = Variabili_Client.Lancieri;
            txt_Arciere_Esercito.Text = Variabili_Client.Arceri;
            txt_Catapulta_Esercito.Text = Variabili_Client.Catapulte;

            var g = Variabili_Client.Guerrieri.Split('/');
            var l = Variabili_Client.Lancieri.Split('/');
            var a = Variabili_Client.Arceri.Split('/');
            var c = Variabili_Client.Catapulte.Split('/');

            if (Convert.ToInt32(g[0]) + Convert.ToInt32(l[0]) + Convert.ToInt32(a[0]) + Convert.ToInt32(c[0]) > 0)
            {
                trackBar_Guerriero.Maximum = Convert.ToInt32(g[0]);
                trackBar_Lanciere.Maximum = Convert.ToInt32(l[0]);
                trackBar_Arciere.Maximum = Convert.ToInt32(a[0]);
                trackBar_Catapulta.Maximum = Convert.ToInt32(c[0]);
            }
            if (comboBox_Raduni_Creati.Text == "") //Disabilita i pulsanti se non ci sono raduni selezionati o presenti
            {
                btn_Inizia.Enabled = false;
                btn_Partecipa.Enabled = false;
            }else
            {
                btn_Inizia.Enabled = true;
                btn_Partecipa.Enabled = true;
            }

            if (comboBox_Raduni_InCorso.Text == "") //Disabilita i pulsanti se non ci sono raduni in corso selezionati o presenti
                btn_Abbandona.Enabled = false;
            else
                btn_Abbandona.Enabled = true;
        }

        private async void btn_Crea_Click(object sender, EventArgs e)
        {
            btn_Crea.Enabled = false;
            ClientConnection.TestClient.Send($"AttaccoCooperativo|{Variabili_Client.username}|{Variabili_Client.password}|Crea|");
            await Login.Sleep(2);
            Load_Guid();
            btn_Crea.Enabled = true;
        }

        private async void btn_Partecipa_Click(object sender, EventArgs e)
        {
            btn_Partecipa.Enabled = false;
            if (comboBox_Raduni_Creati.Text != null)
            {
                var dati = comboBox_Raduni_Creati.Text.Replace(" ", "").Split('-');
                ClientConnection.TestClient.Send($"AttaccoCooperativo|{Variabili_Client.username}|{Variabili_Client.password}|Partecipa|{dati[1]}|{lbl_Guerriero.Text}|{lbl_Lanciere.Text}|{lbl_Arciere.Text}|{lbl_Catapulta.Text}");
            }
            await Login.Sleep(2);
            Load_Guid();
            trackBar_Guerriero.Value = 0;
            trackBar_Lanciere.Value = 0;
            trackBar_Arciere.Value = 0;
            trackBar_Catapulta.Value = 0;
            lbl_Guerriero.Text = "0";
            lbl_Lanciere.Text = "0";
            lbl_Arciere.Text = "0";
            lbl_Catapulta.Text = "0";
        }

        private async void btn_Abbandona_Click(object sender, EventArgs e)
        {
            btn_Abbandona.Enabled = false;
            if (comboBox_Raduni_InCorso.Text != null)
            {
                var dati = comboBox_Raduni_InCorso.Text.Replace(" ", "").Split('-');
                ClientConnection.TestClient.Send($"AttaccoCooperativo|{Variabili_Client.username}|{Variabili_Client.password}|Abbandona|{dati[1]}");
            }
            await Login.Sleep(2);
            Load_Guid();
        }

        private async void btn_Inizia_Click(object sender, EventArgs e)
        {
            btn_Inizia.Enabled = false;
            var dati = comboBox_Raduni_Creati.Text.Replace(" ", "").Split('-');
            ClientConnection.TestClient.Send($"AttaccoCooperativo|{Variabili_Client.username}|{Variabili_Client.password}|Inizia|{dati[1]}");
            await Login.Sleep(3);
            Load_Guid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"AttaccoCooperativo|{Variabili_Client.username}|{Variabili_Client.password}|MieiAttacchi|");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Load_Guid();
        }

        private void comboBox_Raduni_InCorso_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_Raduni_InCorso.Text != "")
            {
                if (Variabili_Client.Raduni_InCorso.Count != 0)
                    foreach (string attaccoStr in Variabili_Client.Raduni_InCorso)
                    {
                        var attacco = Variabili_Client.PartecipanteAttacco.FromString(attaccoStr);
                        var testo = comboBox_Raduni_InCorso.Text.Replace(" ", "").Split('-');

                        if (attacco != null && testo[1] == attacco.ID)
                        {
                            txt_Guerriero_Spedizione.Text = attacco.Guerrieri;
                            txt_Lanciere_Spedizione.Text = attacco.Lancieri;
                            txt_Arciere_Spedizione.Text = attacco.Arcieri;
                            txt_Catapulta_Spedizione.Text = attacco.Catapulte;
                        }
                    }
            }
            else
            {
                txt_Guerriero_Spedizione.Text = "0";
                txt_Lanciere_Spedizione.Text = "0";
                txt_Arciere_Spedizione.Text = "0";
                txt_Catapulta_Spedizione.Text = "0";
            }
        }

        private void trackBar_Guerriero_Scroll(object sender, EventArgs e)
        {
            lbl_Guerriero.Text = trackBar_Guerriero.Value.ToString();
        }

        private void trackBar_Lanciere_Scroll(object sender, EventArgs e)
        {
            lbl_Lanciere.Text = trackBar_Lanciere.Value.ToString();
        }

        private void trackBar_Arciere_Scroll(object sender, EventArgs e)
        {
            lbl_Arciere.Text = trackBar_Arciere.Value.ToString();
        }

        private void trackBar_Catapulta_Scroll(object sender, EventArgs e)
        {
            lbl_Catapulta.Text = trackBar_Catapulta.Value.ToString();
        }
    }
}
