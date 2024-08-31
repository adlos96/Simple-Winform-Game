using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Strategico_V2
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            Task.Run(() => Gui_Update());
        }

        private void btn_Costruisci_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Costruzione|{Variabili_Client.username}|{Variabili_Client.password}|" +
                $"{txt_Fattoria_Costruzione.Text}|" +
                $"{txt_Segheria_Costruzione.Text}|" +
                $"{txt_CavaPietra_Costruzione.Text}|" +
                $"{txt_MinieraFerro_Costruzione.Text}|" +
                $"{txt_MinieraOro_Costruzione.Text}|" +
                $"{txt_Case_Costruzione.Text}|" +
                $"{txt_Spade_Costruzione.Text}|" +
                $"{txt_Lancie_Costruzione.Text}|" +
                $"{txt_Archi_Costruzione.Text}|" +
                $"{txt_Scudi_Costruzione.Text}|" +
                $"{txt_Armatura_Costruzione.Text}|" +
                $"{txt_Frecce_Costruzione.Text}");

            txt_Fattoria_Costruzione.Text       = "0";
            txt_Segheria_Costruzione.Text       = "0";
            txt_CavaPietra_Costruzione.Text     = "0";
            txt_MinieraFerro_Costruzione.Text   = "0";
            txt_MinieraOro_Costruzione.Text     = "0";
            txt_Case_Costruzione.Text           = "0";
            txt_Spade_Costruzione.Text          = "0";
            txt_Lancie_Costruzione.Text         = "0";
            txt_Archi_Costruzione.Text          = "0";
            txt_Scudi_Costruzione.Text          = "0";
            txt_Armatura_Costruzione.Text       = "0";
            txt_Frecce_Costruzione.Text         = "0";
        }
        private void btn_Reclutamento_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Reclutamento|{Variabili_Client.username}|{Variabili_Client.password}|" +
                $"{txt_Guerriero_Reclutamento.Text}|" +
                $"{txt_Lanciere_Reclutamento.Text}|" +
                $"{txt_Arciere_Reclutamento.Text}|" +
                $"{txt_Catapulta_Reclutamento.Text}|" +
                $"{txt_Frecce_Costruzione.Text}");

            txt_Guerriero_Reclutamento.Text = "0";
            txt_Lanciere_Reclutamento.Text = "0";
            txt_Arciere_Reclutamento.Text = "0";
            txt_Catapulta_Reclutamento.Text = "0";
            txt_Frecce_Costruzione.Text = "0";
        }
        async void Gui_Update()
        {
            while (true)
            {
                Thread.Sleep(1000);
                txt_Cibo.Invoke((Action)(async () =>
                {
                    txt_Riepilogo_Utente.Text = $"Server         {Variabili_Client.Server}\r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Versione         {Variabili_Client.Versione}\r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Difficoltà         {Variabili_Client.Difficoltà}\r\n";

                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"\r\nFattorie         {Variabili_Client.Fattoria}\r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Segherie         {Variabili_Client.Segheria}\r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Cave di pietra   {Variabili_Client.CavaPietra}\r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Miniere di ferro {Variabili_Client.MinieraFerro}\r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Miniere D'oro    {Variabili_Client.MinieraOro}\r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Case             {Variabili_Client.Case}\r\n";
                                                 
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"\r\nProduzione Spade    {Variabili_Client.ProduzioneSpade}\r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Produzione Lance    {Variabili_Client.ProduzioneLance}\r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Produzione Archi    {Variabili_Client.ProduzioneArchi}\r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Produzione Scudi    {Variabili_Client.ProduzioneScudi} \r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Produzione Armature {Variabili_Client.ProduzioneArmature} \r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Produzione Frecce   {Variabili_Client.ProduzioneFrecce} \r\n";
                                                
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"\r\nSpade    {Variabili_Client.Spade} \r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Lance    {Variabili_Client.Lance} \r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Archi    {Variabili_Client.Archi} \r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Scudi    {Variabili_Client.Scudi} \r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Armature {Variabili_Client.Armature} \r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Frecce   {Variabili_Client.Frecce} \r\n";
                                               
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"\r\nGuerrieri   {Variabili_Client.Guerrieri} \r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Lancieri    {Variabili_Client.Lancieri} \r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Arcieri     {Variabili_Client.Arceri}  \r\n";
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Catapulte   {Variabili_Client.Catapulte}  \r\n";

                    txt_Cibo.Text = Variabili_Client.Cibo;
                    txt_Legno.Text = Variabili_Client.Legno;
                    txt_Pietra.Text = Variabili_Client.Pietra;
                    txt_Ferro.Text = Variabili_Client.Ferro;
                    txt_Oro.Text = Variabili_Client.Oro;
                    txt_Popolazione.Text = Variabili_Client.Popolazione;

                    txt_Produzione_Cibo.Text = Variabili_Client.Risorse_s_Cibo;
                    txt_Produzione_Legno.Text = Variabili_Client.Risorse_s_Legno;
                    txt_Produzione_Pietra.Text = Variabili_Client.Risorse_s_Pietra;
                    txt_Produzione_Ferro.Text = Variabili_Client.Risorse_s_Ferro;
                    txt_Produzione_Oro.Text = Variabili_Client.Risorse_s_Oro;
                    txt_Produzione_Popolazione.Text = Variabili_Client.Risorse_s_Popolazione;
                }));
            }
        }
        public static void Log_Update(string msg)
        {
            _ = txt_Log.Invoke((Action)(() => txt_Log.Text = $"{msg}\r\n" + txt_Log.Text));
        }
        private void lbl_Fattoria_X0_Click(object sender, EventArgs e)
        {
            txt_Fattoria_Costruzione.Text = "0";
        }
        private void lbl_Fattoria_X1_Click(object sender, EventArgs e)
        {
            txt_Fattoria_Costruzione.Text = (Convert.ToInt32(txt_Fattoria_Costruzione.Text) + 1).ToString();
        }
        private void lbl_Fattoria_X5_Click(object sender, EventArgs e)
        {
            txt_Fattoria_Costruzione.Text = (Convert.ToInt32(txt_Fattoria_Costruzione.Text) + 5).ToString();
        }
        private void lbl_Fattoria_X10_Click(object sender, EventArgs e)
        {
            txt_Fattoria_Costruzione.Text = (Convert.ToInt32(txt_Fattoria_Costruzione.Text) + 10).ToString();
        }

        private void lbl_Seghera_X0_Click(object sender, EventArgs e)
        {
            txt_Segheria_Costruzione.Text = "0";
        }
        private void lbl_Seghera_X1_Click(object sender, EventArgs e)
        {
            txt_Segheria_Costruzione.Text = (Convert.ToInt32(txt_Segheria_Costruzione.Text) + 1).ToString();
        }
        private void lbl_Seghera_X5_Click(object sender, EventArgs e)
        {
            txt_Segheria_Costruzione.Text = (Convert.ToInt32(txt_Segheria_Costruzione.Text) + 5).ToString();
        }
        private void lbl_Seghera_X10_Click(object sender, EventArgs e)
        {
            txt_Segheria_Costruzione.Text = (Convert.ToInt32(txt_Segheria_Costruzione.Text) + 10).ToString();
        }

        private void lbl_CavaPietra_X0_Click(object sender, EventArgs e)
        {
            txt_CavaPietra_Costruzione.Text = "0";
        }
        private void lbl_CavaPietra_X1_Click(object sender, EventArgs e)
        {
            txt_CavaPietra_Costruzione.Text = (Convert.ToInt32(txt_CavaPietra_Costruzione.Text) + 1).ToString();
        }
        private void lbl_CavaPietra_X5_Click(object sender, EventArgs e)
        {
            txt_CavaPietra_Costruzione.Text = (Convert.ToInt32(txt_CavaPietra_Costruzione.Text) + 5).ToString();
        }
        private void lbl_CavaPietra_X10_Click(object sender, EventArgs e)
        {
            txt_CavaPietra_Costruzione.Text = (Convert.ToInt32(txt_CavaPietra_Costruzione.Text) + 10).ToString();
        }

        private void lbl_Miniera_Ferro_X0_Click(object sender, EventArgs e)
        {
            txt_MinieraFerro_Costruzione.Text = "0";
        }
        private void lbl_Miniera_Ferro_X1_Click(object sender, EventArgs e)
        {
            txt_MinieraFerro_Costruzione.Text = (Convert.ToInt32(txt_MinieraFerro_Costruzione.Text) + 1).ToString();
        }
        private void lbl_Miniera_Ferro_X5_Click(object sender, EventArgs e)
        {
            txt_MinieraFerro_Costruzione.Text = (Convert.ToInt32(txt_MinieraFerro_Costruzione.Text) + 5).ToString();
        }
        private void lbl_Miniera_Ferro_X10_Click(object sender, EventArgs e)
        {
            txt_MinieraFerro_Costruzione.Text = (Convert.ToInt32(txt_MinieraFerro_Costruzione.Text) + 10).ToString();
        }

        private void lbl_Miniera_Oro_X0_Click(object sender, EventArgs e)
        {
            txt_MinieraOro_Costruzione.Text = "0";
        }
        private void lbl_Miniera_Oro_X1_Click(object sender, EventArgs e)
        {
            txt_MinieraOro_Costruzione.Text = (Convert.ToInt32(txt_MinieraOro_Costruzione.Text) + 1).ToString();
        }
        private void lbl_Miniera_Oro_X5_Click(object sender, EventArgs e)
        {
            txt_MinieraOro_Costruzione.Text = (Convert.ToInt32(txt_MinieraOro_Costruzione.Text) + 5).ToString();
        }
        private void lbl_Miniera_Oro_X10_Click(object sender, EventArgs e)
        {
            txt_MinieraOro_Costruzione.Text = (Convert.ToInt32(txt_MinieraOro_Costruzione.Text) + 10).ToString();
        }

        private void lbl_Case_X0_Click(object sender, EventArgs e)
        {
            txt_Case_Costruzione.Text = "0";
        }
        private void lbl_Case_X1_Click(object sender, EventArgs e)
        {
            txt_Case_Costruzione.Text = (Convert.ToInt32(txt_Case_Costruzione.Text) + 1).ToString();
        }
        private void lbl_Case_X5_Click(object sender, EventArgs e)
        {
            txt_Case_Costruzione.Text = (Convert.ToInt32(txt_Case_Costruzione.Text) + 5).ToString();
        }
        private void lbl_Case_X10_Click(object sender, EventArgs e)
        {
            txt_Case_Costruzione.Text = (Convert.ToInt32(txt_Case_Costruzione.Text) + 10).ToString();
        }

        private void lbl_Produzione_Spade_X0_Click(object sender, EventArgs e)
        {
            txt_Spade_Costruzione.Text = "0";
        }
        private void lbl_Produzione_Spade_X1_Click(object sender, EventArgs e)
        {
            txt_Spade_Costruzione.Text = (Convert.ToInt32(txt_Spade_Costruzione.Text) + 1).ToString();
        }
        private void lbl_Produzione_Spade_X5_Click(object sender, EventArgs e)
        {
            txt_Spade_Costruzione.Text = (Convert.ToInt32(txt_Spade_Costruzione.Text) + 5).ToString();
        }
        private void lbl_Produzione_Spade_X10_Click(object sender, EventArgs e)
        {
            txt_Spade_Costruzione.Text = (Convert.ToInt32(txt_Spade_Costruzione.Text) + 10).ToString();
        }

        private void lbl_Produzione_Lancie_X0_Click(object sender, EventArgs e)
        {
            txt_Lancie_Costruzione.Text = "0";
        }
        private void lbl_Produzione_Lancie_X1_Click(object sender, EventArgs e)
        {
            txt_Lancie_Costruzione.Text = (Convert.ToInt32(txt_Lancie_Costruzione.Text) + 1).ToString();
        }
        private void lbl_Produzione_Lancie_X5_Click(object sender, EventArgs e)
        {
            txt_Lancie_Costruzione.Text = (Convert.ToInt32(txt_Lancie_Costruzione.Text) + 5).ToString();
        }
        private void lbl_Produzione_Lancie_X10_Click(object sender, EventArgs e)
        {
            txt_Lancie_Costruzione.Text = (Convert.ToInt32(txt_Lancie_Costruzione.Text) + 10).ToString();
        }

        private void lbl_Produzione_Archi_X0_Click(object sender, EventArgs e)
        {
            txt_Archi_Costruzione.Text = "0";
        }
        private void lbl_Produzione_Archi_X1_Click(object sender, EventArgs e)
        {
            txt_Archi_Costruzione.Text = (Convert.ToInt32(txt_Archi_Costruzione.Text) + 1).ToString();
        }
        private void lbl_Produzione_Archi_X5_Click(object sender, EventArgs e)
        {
            txt_Archi_Costruzione.Text = (Convert.ToInt32(txt_Archi_Costruzione.Text) + 5).ToString();
        }
        private void lbl_Produzione_Archi_X10_Click(object sender, EventArgs e)
        {
            txt_Archi_Costruzione.Text = (Convert.ToInt32(txt_Archi_Costruzione.Text) + 10).ToString();
        }

        private void lbl_Produzione_Scudi_X0_Click(object sender, EventArgs e)
        {
            txt_Scudi_Costruzione.Text = "0";
        }
        private void lbl_Produzione_Scudi_X1_Click(object sender, EventArgs e)
        {
            txt_Scudi_Costruzione.Text = (Convert.ToInt32(txt_Scudi_Costruzione.Text) + 1).ToString();
        }
        private void lbl_Produzione_Scudi_X5_Click(object sender, EventArgs e)
        {
            txt_Scudi_Costruzione.Text = (Convert.ToInt32(txt_Scudi_Costruzione.Text) + 5).ToString();
        }
        private void lbl_Produzione_Scudi_X10_Click(object sender, EventArgs e)
        {
            txt_Scudi_Costruzione.Text = (Convert.ToInt32(txt_Scudi_Costruzione.Text) + 10).ToString();
        }

        private void lbl_Produzione_Armature_X0_Click(object sender, EventArgs e)
        {
            txt_Armatura_Costruzione.Text = "0";
        }
        private void lbl_Produzione_Armature_X1_Click(object sender, EventArgs e)
        {
            txt_Armatura_Costruzione.Text = (Convert.ToInt32(txt_Armatura_Costruzione.Text) + 1).ToString();
        }
        private void lbl_Produzione_Armature_X5_Click(object sender, EventArgs e)
        {
            txt_Armatura_Costruzione.Text = (Convert.ToInt32(txt_Armatura_Costruzione.Text) + 5).ToString();
        }
        private void lbl_Produzione_Armature_X10_Click(object sender, EventArgs e)
        {
            txt_Armatura_Costruzione.Text = (Convert.ToInt32(txt_Armatura_Costruzione.Text) + 10).ToString();
        }
        private void lbl_Produzione_Frecce_X0_Click(object sender, EventArgs e)
        {
            txt_Frecce_Costruzione.Text = "0";
        }
        private void lbl_Produzione_Frecce_X1_Click(object sender, EventArgs e)
        {
            txt_Frecce_Costruzione.Text = (Convert.ToInt32(txt_Frecce_Costruzione.Text) + 1).ToString();
        }
        private void lbl_Produzione_Frecce_X5_Click(object sender, EventArgs e)
        {
            txt_Frecce_Costruzione.Text = (Convert.ToInt32(txt_Frecce_Costruzione.Text) + 5).ToString();
        }
        private void lbl_Produzione_Frecce_X10_Click(object sender, EventArgs e)
        {
            txt_Frecce_Costruzione.Text = (Convert.ToInt32(txt_Frecce_Costruzione.Text) + 10).ToString();
        }

        private void lbl_Reclutamento_Guerriero_X0_Click(object sender, EventArgs e)
        {
            txt_Guerriero_Reclutamento.Text = "0";
        }
        private void lbl_Reclutamento_Guerriero_X1_Click(object sender, EventArgs e)
        {
            txt_Guerriero_Reclutamento.Text = (Convert.ToInt32(txt_Guerriero_Reclutamento.Text) + 1).ToString();
        }
        private void lbl_Reclutamento_Guerriero_X5_Click(object sender, EventArgs e)
        {
            txt_Guerriero_Reclutamento.Text = (Convert.ToInt32(txt_Guerriero_Reclutamento.Text) + 5).ToString();
        }
        private void lbl_Reclutamento_Guerriero_X10_Click(object sender, EventArgs e)
        {
            txt_Guerriero_Reclutamento.Text = (Convert.ToInt32(txt_Guerriero_Reclutamento.Text) + 10).ToString();
        }

        private void lbl_Reclutamento_Lanciere_X0_Click(object sender, EventArgs e)
        {
            txt_Lanciere_Reclutamento.Text = "0";
        }
        private void lbl_Reclutamento_Lanciere_X1_Click(object sender, EventArgs e)
        {
            txt_Lanciere_Reclutamento.Text = (Convert.ToInt32(txt_Lanciere_Reclutamento.Text) + 1).ToString();
        }
        private void lbl_Reclutamento_Lanciere_X5_Click(object sender, EventArgs e)
        {
            txt_Lanciere_Reclutamento.Text = (Convert.ToInt32(txt_Lanciere_Reclutamento.Text) + 5).ToString();
        }
        private void lbl_Reclutamento_Lanciere_X10_Click(object sender, EventArgs e)
        {
            txt_Lanciere_Reclutamento.Text = (Convert.ToInt32(txt_Lanciere_Reclutamento.Text) + 10).ToString();
        }

        private void lbl_Reclutamento_Arciere_X0_Click(object sender, EventArgs e)
        {
            txt_Arciere_Reclutamento.Text = "0";
        }
        private void lbl_Reclutamento_Arciere_X1_Click(object sender, EventArgs e)
        {
            txt_Arciere_Reclutamento.Text = (Convert.ToInt32(txt_Arciere_Reclutamento.Text) + 1).ToString();
        }
        private void lbl_Reclutamento_Arciere_X5_Click(object sender, EventArgs e)
        {
            txt_Arciere_Reclutamento.Text = (Convert.ToInt32(txt_Arciere_Reclutamento.Text) + 5).ToString();
        }
        private void lbl_Reclutamento_Arciere_X10_Click(object sender, EventArgs e)
        {
            txt_Arciere_Reclutamento.Text = (Convert.ToInt32(txt_Arciere_Reclutamento.Text) + 10).ToString();
        }

        private void lbl_Reclutamento_Catapulta_X0_Click(object sender, EventArgs e)
        {
            txt_Catapulta_Reclutamento.Text = "0";
        }
        private void lbl_Reclutamento_Catapulta_X1_Click(object sender, EventArgs e)
        {
            txt_Catapulta_Reclutamento.Text = (Convert.ToInt32(txt_Catapulta_Reclutamento.Text) + 1).ToString();
        }
        private void lbl_Reclutamento_Catapulta_X5_Click(object sender, EventArgs e)
        {
            txt_Catapulta_Reclutamento.Text = (Convert.ToInt32(txt_Catapulta_Reclutamento.Text) + 5).ToString();
        }
        private void lbl_Reclutamento_Catapulta_X10_Click(object sender, EventArgs e)
        {
            txt_Catapulta_Reclutamento.Text = (Convert.ToInt32(txt_Catapulta_Reclutamento.Text) + 10).ToString();
        }
    }
}
