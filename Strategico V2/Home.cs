using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            comboBox_PVP.Text = "Seleziona Giocatore";
            Task.Run(() => Gui_Update());
        }

        private void btn_Costruisci_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            return;
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
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Difficoltà       {Variabili_Client.Difficoltà}\r\n";                 
                    txt_Riepilogo_Utente.Text = txt_Riepilogo_Utente.Text + $"Forza Esercito:   {Variabili_Client.Forza_Esercito}  \r\n";


                    txt_Fattoria_Costruzione.Text = Variabili_Client.Fattoria;
                    txt_Segheria_Costruzione.Text = Variabili_Client.Segheria;
                    txt_CavaPietra_Costruzione.Text = Variabili_Client.CavaPietra;
                    txt_MinieraFerro_Costruzione.Text = Variabili_Client.MinieraFerro;
                    txt_MinieraOro_Costruzione.Text = Variabili_Client.MinieraOro;
                    txt_Case_Costruzione.Text = Variabili_Client.Case;

                    lbl_Fattoria_Coda.Text = "Coda: " + Variabili_Client.Fattoria_Coda;
                    lbl_Segheria_Coda.Text = "Coda: " + Variabili_Client.Segheria_Coda;
                    lbl_Cava_Pietra_Coda.Text = "Coda: " + Variabili_Client.CavaPietra_Coda;
                    lbl_Miniera_Ferro_Coda.Text = "Coda: " + Variabili_Client.MinieraFerro_Coda;
                    lbl_Miniera_Oro_Coda.Text = "Coda: " + Variabili_Client.MinieraOro_Coda;
                    lbl_Case_Coda.Text = "Coda: " + Variabili_Client.Case_Coda;

                    txt_Spade_Costruzione.Text = Variabili_Client.ProduzioneSpade;
                    txt_Lancie_Costruzione.Text = Variabili_Client.ProduzioneLance;
                    txt_Archi_Costruzione.Text = Variabili_Client.ProduzioneArchi;
                    txt_Scudi_Costruzione.Text = Variabili_Client.ProduzioneScudi;
                    txt_Armatura_Costruzione.Text = Variabili_Client.ProduzioneArmature;
                    txt_Frecce_Costruzione.Text = Variabili_Client.ProduzioneFrecce;

                    lbl_Spade_Coda.Text = "Coda: " + Variabili_Client.ProduzioneSpade_Coda;
                    lbl_Lancie_Coda.Text = "Coda: " + Variabili_Client.ProduzioneLance_Coda;
                    lbl_Archi_Coda.Text = "Coda: " + Variabili_Client.ProduzioneArchi_Coda;
                    lbl_Scudi_Coda.Text = "Coda: " + Variabili_Client.ProduzioneScudi_Coda;
                    lbl_Armature_Coda.Text = "Coda: " + Variabili_Client.ProduzioneArmature_Coda;
                    lbl_Freccie_Coda.Text = "Coda: " + Variabili_Client.ProduzioneFrecce_Coda;

                    txt_Guerriero_Reclutamento.Text = Variabili_Client.Guerrieri;
                    txt_Lanciere_Reclutamento.Text = Variabili_Client.Lancieri;
                    txt_Arciere_Reclutamento.Text = Variabili_Client.Arceri;
                    txt_Catapulta_Reclutamento.Text = Variabili_Client.Catapulte;

                    lbl_Guerriero_Coda.Text = "Coda: " + Variabili_Client.Guerrieri_Coda;
                    lbl_Lanciere_Coda.Text = "Coda: " + Variabili_Client.Lancieri_Coda;
                    lbl_Arciere_Coda.Text = "Coda: " + Variabili_Client.Arceri_Coda;
                    lbl_Catapulta_Coda.Text = "Coda: " + Variabili_Client.Catapulte_Coda;

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

                    txt_Produzione_Spade.Text = Variabili_Client.Risorse_s_Spade;
                    txt_Produzione_Lancie.Text = Variabili_Client.Risorse_s_Lance;
                    txt_Produzione_Archi.Text = Variabili_Client.Risorse_s_Archi;
                    txt_Produzione_Scudi.Text = Variabili_Client.Risorse_s_Scudi;
                    txt_Produzione_Armature.Text = Variabili_Client.Risorse_s_Armature;
                    txt_Produzione_Frecce.Text = Variabili_Client.Risorse_s_Frecce;

                    txt_Spade.Text      = Variabili_Client.Spade;
                    txt_Lancie.Text     = Variabili_Client.Lance;
                    txt_Archi.Text      = Variabili_Client.Archi;
                    txt_Scudi.Text      = Variabili_Client.Scudi;
                    txt_Armature.Text   = Variabili_Client.Armature;
                    txt_Frecce.Text     = Variabili_Client.Frecce;

                    txt_Guerrieri_Acc_Barbaro_PVE.Text = Variabili_Client.Barbari.PVE.Guerrieri;
                    txt_Lancieri_Acc_Barbaro_PVE.Text = Variabili_Client.Barbari.PVE.Lancieri;
                    txt_Arceri_Acc_Barbaro_PVE.Text = Variabili_Client.Barbari.PVE.Arceri;
                    txt_Catapulte_Acc_Barbaro_PVE.Text = Variabili_Client.Barbari.PVE.Catapulte;

                    txt_Guerrieri_Acc_Barbaro_PVP.Text = Variabili_Client.Barbari.PVP.Guerrieri;
                    txt_Lancieri_Acc_Barbaro_PVP.Text = Variabili_Client.Barbari.PVP.Lancieri;
                    txt_Arceri_Acc_Barbaro_PVP.Text = Variabili_Client.Barbari.PVP.Arceri;
                    txt_Catapulte_Acc_Barbaro_PVP.Text = Variabili_Client.Barbari.PVP.Catapulte;

                    txt_Livello.Text = Variabili_Client.Livello;
                    txt_Esperienza.Text = Variabili_Client.Esperienza + " XP";

                    txt_Forza_Esercito_PVE_Barbari.Text = "Forza Esercito: " + Variabili_Client.Forza_Esercito_PVE;
                    txt_Forza_Esercito_PVP_Barbari.Text = "Forza Esercito: " + Variabili_Client.Forza_Esercito_PVP;

                    btn_Giocatori.Text = "Giocatori: " + comboBox_PVP.Items.Count;

                    comboBox_PVP.Text = "Seleziona Giocatore";

                    var items = comboBox_PVP.Items;

                    if (Variabili_Client.Giocatori_PVP.Count > 0)
                        foreach (var a in Variabili_Client.Giocatori_PVP)
                            if (!items.Contains(a) && !a.Contains(Variabili_Client.username))
                                comboBox_PVP.Items.Add(a);
                }));
            }
        }

        public async Task VendiRisorsa(string risorsa, double quantita)
        {
            string messaggio = $"Mercato|Vendi|{Variabili_Client.username}|{Variabili_Client.password}|{risorsa}|{quantita}";
            ClientConnection.TestClient.Send(messaggio);
        }

        public static void Log_Update(string msg)
        {
            _ = txt_Log.Invoke((Action)(() => txt_Log.Text = $"{msg}\r\n" + txt_Log.Text));
        }

        private void btn_Accampameto_Barbaro_PVE_Attacco_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Battaglia|{Variabili_Client.username}|{Variabili_Client.password}|Barbari_PVE");
        }

        private void btn_Accampameto_Barbaro_PVP_Attacco_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Battaglia|{Variabili_Client.username}|{Variabili_Client.password}|Barbari_PVP");
        }

        private void btn_PVP_Attacco_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Battaglia|{Variabili_Client.username}|{Variabili_Client.password}|PVP|{comboBox_PVP.Text}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ = txt_Log.Invoke((Action)(() => txt_Log.Text = $""));
        }
    }
}
