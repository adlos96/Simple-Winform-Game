using rts_2D.Properties;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rts_2D
{
    public partial class Form1 : Form
    {
        int tokenCostruzione = 0;
        int tokenReclutamento = 0;
        public static int Invasione_Ondata = 0;

        private static TextBox log;
        private static TextBox log_Battaglia;
        private static int tempo_Trascorso = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log = this.txt_Cose;
            log_Battaglia = this.Txt_Log_Battaglie;
        }
        private void label17_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text = $"Reclutamento Guerriero\r\n" +
                $"Cibo:         {Variabili.CostoReclutamento.Guerriero.Cibo}\r\n" +
                $"Legno:        {Variabili.CostoReclutamento.Guerriero.Legno}\r\n" +
                $"Pietra:       {Variabili.CostoReclutamento.Guerriero.Pietra}\r\n" +
                $"Ferro:        {Variabili.CostoReclutamento.Guerriero.Ferro}\r\n" +
                $"Oro:          {Variabili.CostoReclutamento.Guerriero.Oro}\r\n" +
                $"Tempo:        {Variabili.CostoReclutamento.Guerriero.TempoReclutamento}s\r\n" +
                $"Popolazione:  {Variabili.CostoReclutamento.Guerriero.Popolazione}\r\n" +
                $"Salario:      {Variabili.Esercito.Guerriero.Salario}\r\n" +
                $"Mantenimento: {Variabili.Esercito.Guerriero.Cibo}\r\n";

        }
        private void label23_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text = $"Reclutamento Lanciere\r\n" +
                $"Cibo:         {Variabili.CostoReclutamento.Lanciere.Cibo}\r\n" +
                $"Legno:        {Variabili.CostoReclutamento.Lanciere.Legno}\r\n" +
                $"Pietra:       {Variabili.CostoReclutamento.Lanciere.Pietra}\r\n" +
                $"Ferro:        {Variabili.CostoReclutamento.Lanciere.Ferro}\r\n" +
                $"Oro:          {Variabili.CostoReclutamento.Lanciere.Oro}\r\n" +
                $"Tempo:        {Variabili.CostoReclutamento.Lanciere.TempoReclutamento}s\r\n" +
                $"Popolazione:  {Variabili.CostoReclutamento.Lanciere.Popolazione}\r\n" +
                $"Salario:      {Variabili.Esercito.Lanciere.Salario}\r\n" +
                $"Mantenimento: {Variabili.Esercito.Lanciere.Cibo}\r\n";
        }
        private void label15_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text = $"Reclutamento Arciere\r\n" +
                $"Cibo:         {Variabili.CostoReclutamento.Arciere.Cibo}\r\n" +
                $"Legno:        {Variabili.CostoReclutamento.Arciere.Legno}\r\n" +
                $"Pietra:       {Variabili.CostoReclutamento.Arciere.Pietra}\r\n" +
                $"Ferro:        {Variabili.CostoReclutamento.Arciere.Ferro}\r\n" +
                $"Oro:          {Variabili.CostoReclutamento.Arciere.Oro}\r\n" +
                $"Tempo:        {Variabili.CostoReclutamento.Arciere.TempoReclutamento}s\r\n" +
                $"Popolazione:  {Variabili.CostoReclutamento.Arciere.Popolazione}\r\n" +
                $"Salario:      {Variabili.Esercito.Arciere.Salario}\r\n" +
                $"Mantenimento: {Variabili.Esercito.Arciere.Cibo}\r\n";
        }
        private void label14_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text = $"Reclutamento Catapulta\r\n" +
                $"Cibo:         {Variabili.CostoReclutamento.Catapulta.Cibo}\r\n" +
                $"Legno:        {Variabili.CostoReclutamento.Catapulta.Legno}\r\n" +
                $"Pietra:       {Variabili.CostoReclutamento.Catapulta.Pietra}\r\n" +
                $"Ferro:        {Variabili.CostoReclutamento.Catapulta.Ferro}\r\n" +
                $"Oro:          {Variabili.CostoReclutamento.Catapulta.Oro}\r\n" +
                $"Tempo:        {Variabili.CostoReclutamento.Catapulta.TempoReclutamento}s\r\n" +
                $"Popolazione:  {Variabili.CostoReclutamento.Catapulta.Popolazione}\r\n" +
                $"Salario:      {Variabili.Esercito.Catapulta.Salario}\r\n" +
                $"Mantenimento: {Variabili.Esercito.Catapulta.Cibo}\r\n";
        }

        private async void btn_Costruisci_Strutture_Click(object sender, EventArgs e)
        {
            double fattorie = 0;
            double segherie = 0;
            double cava = 0;
            double miniera_Ferro = 0;
            double miniera_Oro = 0;

            double.TryParse(txt_Fattoria.Text, out fattorie);
            double.TryParse(txt_Segheria.Text, out segherie);
            double.TryParse(txt_Cava.Text, out cava);
            double.TryParse(txt_Miniera_Ferro.Text, out miniera_Ferro);
            double.TryParse(txt_Miniera_Oro.Text, out miniera_Oro);
            if (fattorie > 0 || segherie > 0 || cava > 0 || miniera_Ferro > 0 || miniera_Oro > 0)
            {
                if (fattorie > 0 &&
                    Variabili.Cibo >= Variabili.CostoCostruzione.Fattoria.Cibo * fattorie &&
                    Variabili.Legno >= Variabili.CostoCostruzione.Fattoria.Legno * fattorie &&
                    Variabili.Pietra >= Variabili.CostoCostruzione.Fattoria.Pietra * fattorie &&
                    Variabili.Ferro >= Variabili.CostoCostruzione.Fattoria.Ferro * fattorie &&
                    Variabili.Oro >= Variabili.CostoCostruzione.Fattoria.Oro * fattorie)
                {
                    Variabili.Cibo -= Variabili.CostoCostruzione.Fattoria.Cibo * fattorie;
                    Variabili.Legno -= Variabili.CostoCostruzione.Fattoria.Legno * fattorie;
                    Variabili.Pietra -= Variabili.CostoCostruzione.Fattoria.Pietra * fattorie;
                    Variabili.Ferro -= Variabili.CostoCostruzione.Fattoria.Ferro * fattorie;
                    Variabili.Oro -= Variabili.CostoCostruzione.Fattoria.Oro * fattorie;
                    Variabili.Coda.Fattoria.quantità += (int)fattorie;
                }
                else
                    if (fattorie != 0)
                    {
                        fattorie = 0;
                        txt_Cose.Text = "Costruzione Fattoria fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    }
                
                if (segherie > 0 &&
                    Variabili.Cibo >= Variabili.CostoCostruzione.Segheria.Cibo * segherie &&
                    Variabili.Legno >= Variabili.CostoCostruzione.Segheria.Legno * segherie &&
                    Variabili.Pietra >= Variabili.CostoCostruzione.Segheria.Pietra * segherie &&
                    Variabili.Ferro >= Variabili.CostoCostruzione.Segheria.Ferro * segherie &&
                    Variabili.Oro >= Variabili.CostoCostruzione.Segheria.Oro * segherie)
                {
                    Variabili.Cibo -= Variabili.CostoCostruzione.Segheria.Cibo * segherie;
                    Variabili.Legno -= Variabili.CostoCostruzione.Segheria.Legno * segherie;
                    Variabili.Pietra -= Variabili.CostoCostruzione.Segheria.Pietra * segherie;
                    Variabili.Ferro -= Variabili.CostoCostruzione.Segheria.Ferro * segherie;
                    Variabili.Oro -= Variabili.CostoCostruzione.Segheria.Oro * segherie;
                    Variabili.Coda.Segheria.quantità += (int)segherie;
                }
                else
                    if (segherie != 0)
                    {
                    segherie = 0;
                        txt_Cose.Text = "Costruzione Segheria fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    }

                if (cava > 0 &&
                    Variabili.Cibo >= Variabili.CostoCostruzione.CavaPietra.Cibo * cava &&
                    Variabili.Legno >= Variabili.CostoCostruzione.CavaPietra.Legno * cava &&
                    Variabili.Pietra >= Variabili.CostoCostruzione.CavaPietra.Pietra * cava &&
                    Variabili.Ferro >= Variabili.CostoCostruzione.CavaPietra.Ferro * cava &&
                    Variabili.Oro >= Variabili.CostoCostruzione.CavaPietra.Oro * cava)
                {
                    Variabili.Cibo -= Variabili.CostoCostruzione.CavaPietra.Cibo * cava;
                    Variabili.Legno -= Variabili.CostoCostruzione.CavaPietra.Legno * cava;
                    Variabili.Pietra -= Variabili.CostoCostruzione.CavaPietra.Pietra * cava;
                    Variabili.Ferro -= Variabili.CostoCostruzione.CavaPietra.Ferro * cava;
                    Variabili.Oro -= Variabili.CostoCostruzione.CavaPietra.Oro * cava;
                    Variabili.Coda.CavaPietra.quantità += (int)cava;
                }
                else
                    if (cava != 0)
                    {
                        txt_Cose.Text = "Costruzione Cava di Pietra fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                        cava = 0;
                    }

                if (miniera_Ferro > 0 &&
                    Variabili.Cibo >= Variabili.CostoCostruzione.Segheria.Cibo * miniera_Ferro &&
                    Variabili.Legno >= Variabili.CostoCostruzione.Segheria.Legno * miniera_Ferro &&
                    Variabili.Pietra >= Variabili.CostoCostruzione.Segheria.Pietra * miniera_Ferro &&
                    Variabili.Ferro >= Variabili.CostoCostruzione.Segheria.Ferro * miniera_Ferro &&
                    Variabili.Oro >= Variabili.CostoCostruzione.Segheria.Oro * miniera_Ferro)
                {
                    Variabili.Cibo -= Variabili.CostoCostruzione.MinieraFerro.Cibo * miniera_Ferro;
                    Variabili.Legno -= Variabili.CostoCostruzione.MinieraFerro.Legno * miniera_Ferro;
                    Variabili.Pietra -= Variabili.CostoCostruzione.MinieraFerro.Pietra * miniera_Ferro;
                    Variabili.Ferro -= Variabili.CostoCostruzione.MinieraFerro.Ferro * miniera_Ferro;
                    Variabili.Oro -= Variabili.CostoCostruzione.MinieraFerro.Oro * miniera_Ferro;
                    Variabili.Coda.MinieraFerro.quantità += (int)miniera_Ferro;
                }
                else
                    if (miniera_Ferro != 0)
                {
                    txt_Cose.Text = "Costruzione Miniera di Ferro fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    miniera_Ferro = 0;
                }

                if (miniera_Oro > 0 &&
                    Variabili.Cibo >= Variabili.CostoCostruzione.MinieraOro.Cibo * miniera_Oro &&
                    Variabili.Legno >= Variabili.CostoCostruzione.MinieraOro.Legno * miniera_Oro &&
                    Variabili.Pietra >= Variabili.CostoCostruzione.MinieraOro.Pietra * miniera_Oro &&
                    Variabili.Ferro >= Variabili.CostoCostruzione.MinieraOro.Ferro * miniera_Oro &&
                    Variabili.Oro >= Variabili.CostoCostruzione.MinieraOro.Oro * miniera_Oro)
                {
                    Variabili.Cibo -= Variabili.CostoCostruzione.MinieraOro.Cibo * miniera_Oro;
                    Variabili.Legno -= Variabili.CostoCostruzione.MinieraOro.Legno * miniera_Oro;
                    Variabili.Pietra -= Variabili.CostoCostruzione.MinieraOro.Pietra * miniera_Oro;
                    Variabili.Ferro -= Variabili.CostoCostruzione.MinieraOro.Ferro * miniera_Oro;
                    Variabili.Oro -= Variabili.CostoCostruzione.MinieraOro.Oro * miniera_Oro;
                    Variabili.Coda.MinieraOro.quantità += (int)miniera_Oro;
                }
                else 
                    if (miniera_Oro != 0)
                    {
                        txt_Cose.Text = "Costruzione Miniera d'Oro fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                        miniera_Oro = 0;
                    }

                if (tokenCostruzione == 0)
                {
                    _ = Task.Run(() => Costruzione());
                    tokenCostruzione++;
                }
                Tempo_Costruzione(fattorie, segherie, cava, miniera_Ferro, miniera_Oro);
                txt_Fattoria.Text = "0";
                txt_Segheria.Text = "0";
                txt_Cava.Text = "0";
                txt_Miniera_Ferro.Text = "0";
                txt_Miniera_Oro.Text = "0";
            }
        }
        private void btn_Recluta_Truppe_Click(object sender, EventArgs e)
        {
            double Guerriero = 0;
            double Lanciere = 0;
            double Arciere = 0;
            double Catapulta = 0;

            double.TryParse(txt_Guerriero.Text, out Guerriero);
            double.TryParse(txt_Lancieri.Text, out Lanciere);
            double.TryParse(txt_Arciere.Text, out Arciere);
            double.TryParse(txt_Catapulta.Text, out Catapulta);

             if (Guerriero > 0 &&
                 Variabili.Cibo >= Variabili.CostoReclutamento.Guerriero.Cibo * Guerriero &&
                 Variabili.Legno >= Variabili.CostoReclutamento.Guerriero.Legno * Guerriero &&
                 Variabili.Pietra >= Variabili.CostoReclutamento.Guerriero.Pietra * Guerriero &&
                 Variabili.Ferro >= Variabili.CostoReclutamento.Guerriero.Ferro * Guerriero &&
                 Variabili.Oro >= Variabili.CostoReclutamento.Guerriero.Oro * Guerriero &&
                 Variabili.Popolazione >= Variabili.CostoReclutamento.Guerriero.Popolazione * Guerriero)
             {
                 Variabili.Cibo -= Variabili.CostoReclutamento.Guerriero.Cibo * Guerriero;
                 Variabili.Legno -= Variabili.CostoReclutamento.Guerriero.Legno * Guerriero;
                 Variabili.Pietra -= Variabili.CostoReclutamento.Guerriero.Pietra * Guerriero;
                 Variabili.Ferro -= Variabili.CostoReclutamento.Guerriero.Ferro * Guerriero;
                 Variabili.Oro -= Variabili.CostoReclutamento.Guerriero.Oro * Guerriero;
                 Variabili.Popolazione -= Variabili.CostoReclutamento.Guerriero.Popolazione * Guerriero;
                 Variabili.Coda.Guerriero.quantità += (int)Guerriero;
             }else if(Guerriero > 0) {
                 Guerriero = 0;
                 txt_Cose.Text = txt_Cose.Text + "Reclutamento Guerriero fallita, risorse insufficienti\r\n";
             }
             
             if (Lanciere > 0 &&
                 Variabili.Cibo >= Variabili.CostoReclutamento.Lanciere.Cibo * Lanciere &&
                 Variabili.Legno >= Variabili.CostoReclutamento.Lanciere.Legno * Lanciere &&
                 Variabili.Pietra >= Variabili.CostoReclutamento.Lanciere.Pietra * Lanciere &&
                 Variabili.Ferro >= Variabili.CostoReclutamento.Lanciere.Ferro * Lanciere &&
                 Variabili.Oro >= Variabili.CostoReclutamento.Lanciere.Oro * Lanciere &&
                 Variabili.Popolazione >= Variabili.CostoReclutamento.Lanciere.Popolazione * Lanciere)
             {
                 Variabili.Cibo -= Variabili.CostoReclutamento.Lanciere.Cibo * Lanciere;
                 Variabili.Legno -= Variabili.CostoReclutamento.Lanciere.Legno * Lanciere;
                 Variabili.Pietra -= Variabili.CostoReclutamento.Lanciere.Pietra * Lanciere;
                 Variabili.Ferro -= Variabili.CostoReclutamento.Lanciere.Ferro * Lanciere;
                 Variabili.Oro -= Variabili.CostoReclutamento.Lanciere.Oro * Lanciere;
                 Variabili.Popolazione -= Variabili.CostoReclutamento.Guerriero.Popolazione * Lanciere;
                 Variabili.Coda.Lanciere.quantità += (int)Lanciere;
             } else if (Lanciere > 0) {
                 Lanciere = 0;
                 txt_Cose.Text = txt_Cose.Text + "Reclutamento Lanciere fallita, risorse insufficienti\r\n";
             }
             
             if (Arciere > 0 &&
                 Variabili.Cibo >= Variabili.CostoReclutamento.Arciere.Cibo * Arciere &&
                 Variabili.Legno >= Variabili.CostoReclutamento.Arciere.Legno * Arciere &&
                 Variabili.Pietra >= Variabili.CostoReclutamento.Arciere.Pietra * Arciere &&
                 Variabili.Ferro >= Variabili.CostoReclutamento.Arciere.Ferro * Arciere &&
                 Variabili.Oro >= Variabili.CostoReclutamento.Arciere.Oro * Arciere &&
                 Variabili.Popolazione >= Variabili.CostoReclutamento.Arciere.Popolazione * Arciere)
             {
                 Variabili.Cibo -= Variabili.CostoReclutamento.Arciere.Cibo * Arciere;
                 Variabili.Legno -= Variabili.CostoReclutamento.Arciere.Legno * Arciere;
                 Variabili.Pietra -= Variabili.CostoReclutamento.Arciere.Pietra * Arciere;
                 Variabili.Ferro -= Variabili.CostoReclutamento.Arciere.Ferro * Arciere;
                 Variabili.Oro -= Variabili.CostoReclutamento.Arciere.Oro * Arciere;
                 Variabili.Popolazione -= Variabili.CostoReclutamento.Guerriero.Popolazione * Arciere;
                 Variabili.Coda.Arciere.quantità += (int)Arciere;
             } else if(Arciere > 0) {
                 txt_Cose.Text = txt_Cose.Text + "Reclutamento Arciere fallita, risorse insufficienti\r\n";
                 Arciere = 0;
             }
             
             if (Catapulta > 0 &&
                 Variabili.Cibo >= Variabili.CostoReclutamento.Catapulta.Cibo * Catapulta &&
                 Variabili.Legno >= Variabili.CostoReclutamento.Catapulta.Legno * Catapulta &&
                 Variabili.Pietra >= Variabili.CostoReclutamento.Catapulta.Pietra * Catapulta &&
                 Variabili.Ferro >= Variabili.CostoReclutamento.Catapulta.Ferro * Catapulta &&
                 Variabili.Oro >= Variabili.CostoReclutamento.Catapulta.Oro * Catapulta &&
                 Variabili.Popolazione >= Variabili.CostoReclutamento.Catapulta.Popolazione * Catapulta)
             {
                 Variabili.Cibo -= Variabili.CostoReclutamento.Catapulta.Cibo * Catapulta;
                 Variabili.Legno -= Variabili.CostoReclutamento.Catapulta.Legno * Catapulta;
                 Variabili.Pietra -= Variabili.CostoReclutamento.Catapulta.Pietra * Catapulta;
                 Variabili.Ferro -= Variabili.CostoReclutamento.Catapulta.Ferro * Catapulta;
                 Variabili.Oro -= Variabili.CostoReclutamento.Catapulta.Oro * Catapulta;
                 Variabili.Popolazione -= Variabili.CostoReclutamento.Guerriero.Popolazione * Catapulta;
                 Variabili.Coda.Catapulta.quantità += (int)Catapulta;
             } else if(Catapulta > 0) {
                 txt_Cose.Text = "Reclutamento Catapulta fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                 Catapulta = 0;
             }
             
             if (tokenReclutamento == 0) {
                 tokenReclutamento++;
                Task.Run(() => Reclutamento());
             }
             Tempo_Reclutamento(Guerriero, Lanciere, Arciere, Catapulta);
             txt_Guerriero.Text = "0";
             txt_Lancieri.Text = "0";
             txt_Arciere.Text = "0";
             txt_Catapulta.Text = "0";
        }
        private void Tempo_Costruzione(double fattorie, double segherie, double cava, double miniera_Ferro, double miniera_Oro)
        {
            Variabili.tempo_Costruzione = Variabili.tempo_Costruzione +
                    (int)((fattorie * Variabili.CostoCostruzione.Fattoria.TempoCostruzione) +
                    (segherie * Variabili.CostoCostruzione.Segheria.TempoCostruzione) +
                    (cava * Variabili.CostoCostruzione.CavaPietra.TempoCostruzione) +
                    (miniera_Ferro * Variabili.CostoCostruzione.MinieraFerro.TempoCostruzione) +
                    (miniera_Oro * Variabili.CostoCostruzione.MinieraOro.TempoCostruzione));

            txt_Fattoria.Text = "0";
            txt_Segheria.Text = "0";
            txt_Cava.Text = "0";
            txt_Miniera_Ferro.Text = "0";
            txt_Miniera_Oro.Text = "0";
        }
        private void Tempo_Reclutamento(double Guerriero, double Lanciere, double Arciere, double Catapulta)
        {
            Variabili.tempo_Reclutamento = Variabili.tempo_Reclutamento +
                    (int)((Guerriero * Variabili.CostoReclutamento.Guerriero.TempoReclutamento) +
                    (Lanciere * Variabili.CostoReclutamento.Lanciere.TempoReclutamento) +
                    (Arciere * Variabili.CostoReclutamento.Arciere.TempoReclutamento) +
                    (Catapulta * Variabili.CostoReclutamento.Catapulta.TempoReclutamento));

            txt_Guerriero.Text = "0";
            txt_Lancieri.Text = "0";
            txt_Arciere.Text = "0";
            txt_Catapulta.Text = "0";
        }

        private async void btn_Start_Click(object sender, EventArgs e)
        {
            _ = Task.Run(() => Loop());
            btn_Invasioni.Visible = true;
            Blocco_Costruzione.Visible = true;
            Blocco_Invasioni.Visible = true;
            Blocco_Produzione.Visible = true;
            Blocco_Reclutamento.Visible = true;
            lbl_Tempo.Visible = true;
            btn_Ricerca.Visible = true;
            btn_Start.Visible = false;
        }
        private async Task<double> Cibo()
        {
            double cibo = 0;

            cibo += Variabili.Esercito.Guerriero.Quantità * Variabili.Esercito.Guerriero.Cibo;
            cibo += Variabili.Esercito.Lanciere.Quantità * Variabili.Esercito.Lanciere.Cibo;
            cibo += Variabili.Esercito.Arciere.Quantità * Variabili.Esercito.Arciere.Cibo;
            cibo += Variabili.Esercito.Catapulta.Quantità * Variabili.Esercito.Catapulta.Cibo;

            return cibo;
        }
        async Task Loop()
        {
            Variabili.Cibo = 110000;
            Variabili.Legno = 120000;
            Variabili.Pietra = 130000;
            Variabili.Ferro = 140000;
            Variabili.Oro = 210000;
            Variabili.Popolazione = 10;
            while (true)
            {
                //Agiunta risorse
                Variabili.Cibo = Variabili.Cibo + ((Variabili.CostoCostruzione.Fattoria.Produzione * Variabili.fattoria) - await Cibo());
                Variabili.Legno = Variabili.Legno + (Variabili.CostoCostruzione.Segheria.Produzione * Variabili.segheria);
                Variabili.Pietra = Variabili.Pietra + (Variabili.CostoCostruzione.CavaPietra.Produzione * Variabili.cava_Pietra);
                Variabili.Ferro = Variabili.Ferro + (Variabili.CostoCostruzione.MinieraFerro.Produzione * Variabili.miniera_Ferro);
                Variabili.Oro = Variabili.Oro + ((Variabili.CostoCostruzione.MinieraOro.Produzione * Variabili.miniera_Oro) - await Oro());
                Variabili.Popolazione = Variabili.Popolazione + Variabili.Popolazione_Up;

                Variabili.forza_Esercito =
                    Variabili.Esercito.Guerriero.Quantità * ((Variabili.Esercito.Guerriero.Salute * 0.33) + (Variabili.Esercito.Guerriero.Attacco * 0.72)) +
                    Variabili.Esercito.Lanciere.Quantità * ((Variabili.Esercito.Lanciere.Salute * 0.33) + (Variabili.Esercito.Lanciere.Attacco * 0.72)) +
                    Variabili.Esercito.Arciere.Quantità * ((Variabili.Esercito.Arciere.Salute * 0.33) + (Variabili.Esercito.Arciere.Attacco * 0.72)) +
                    Variabili.Esercito.Catapulta.Quantità * ((Variabili.Esercito.Catapulta.Salute * 0.33) + (Variabili.Esercito.Catapulta.Attacco * 0.72));

                tempo_Trascorso++;
                Load_Gui_Info();
                Thread.Sleep(1000);
            }
        }
        Task Costruzione()
        {
            int Fattoria = 0;
            int Segheria = 0;
            int CavaPietra = 0;
            int MinieraFerro = 0;
            int MinieraOro = 0;

            while (true)
            {
                if (Variabili.tempo_Costruzione > 0)
                {
                    if (Variabili.Coda.Fattoria.quantità > 0)
                    {
                        Fattoria++;
                        Variabili.tempo_Costruzione--;
                    }
                    if (Variabili.Coda.Segheria.quantità > 0)
                    { 
                        Segheria++;
                        Variabili.tempo_Costruzione--;
                    }
                    if (Variabili.Coda.CavaPietra.quantità > 0) 
                    {
                        CavaPietra++;
                        Variabili.tempo_Costruzione--;
                    }
                    if (Variabili.Coda.MinieraFerro.quantità > 0) 
                    {
                        MinieraFerro++;
                        Variabili.tempo_Costruzione--;
                    }
                    if (Variabili.Coda.MinieraOro.quantità > 0) 
                    {
                        MinieraOro++;
                        Variabili.tempo_Costruzione--;
                    }

                    if (Variabili.Coda.Fattoria.quantità > 0 && Fattoria == Variabili.CostoCostruzione.Fattoria.TempoCostruzione)
                    {
                        Variabili.fattoria++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Costruzione Fattoria completata!\r\n" + txt_Cose.Text));
                        Variabili.Coda.Fattoria.quantità--;
                        Fattoria = 0;
                    }
                    if (Variabili.Coda.Segheria.quantità > 0 && Segheria == Variabili.CostoCostruzione.Segheria.TempoCostruzione)
                    {
                        Variabili.segheria++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Costruzione Segheria completata!\r\n" + txt_Cose.Text));
                        Variabili.Coda.Segheria.quantità--;
                        Segheria = 0;
                    }
                    if (Variabili.Coda.CavaPietra.quantità > 0 && CavaPietra == Variabili.CostoCostruzione.CavaPietra.TempoCostruzione)
                    {
                        Variabili.cava_Pietra++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Costruzione Cava di Pietra completata!\r\n" + txt_Cose.Text));
                        Variabili.Coda.CavaPietra.quantità--;
                        CavaPietra = 0;
                    }
                    if (Variabili.Coda.MinieraFerro.quantità > 0 && MinieraFerro == Variabili.CostoCostruzione.MinieraFerro.TempoCostruzione)
                    {
                        Variabili.miniera_Ferro++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Costruzione Miniera di Ferro completata!\r\n" + txt_Cose.Text));
                        Variabili.Coda.MinieraFerro.quantità--;
                        MinieraFerro = 0;
                    }
                    if (Variabili.Coda.MinieraOro.quantità > 0 && MinieraOro == Variabili.CostoCostruzione.MinieraOro.TempoCostruzione)
                    {
                        Variabili.miniera_Oro++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Costruzione Miniera d'Oro completata!\r\n" + txt_Cose.Text));
                        Variabili.Coda.MinieraOro.quantità--;
                        MinieraOro = 0;
                    }
                    if (Variabili.Coda.Fattoria.quantità + Variabili.Coda.Segheria.quantità + Variabili.Coda.CavaPietra.quantità + Variabili.Coda.MinieraFerro.quantità + Variabili.Coda.MinieraOro.quantità == 0)
                        Variabili.tempo_Costruzione = 0;
                }
                Thread.Sleep(1000);
            }
        }
        Task Reclutamento()
        {
            int Guerriero = 0;
            int Lanciere = 0;
            int Arciere = 0;
            int Catapulta = 0;
            while (true)
            {
                if (Variabili.tempo_Reclutamento > 0)
                {
                    if (Variabili.Coda.Guerriero.quantità > 0)
                    {
                        Guerriero++;
                        Variabili.tempo_Reclutamento--;
                    }
                    if (Variabili.Coda.Lanciere.quantità > 0)
                    { 
                        Lanciere++;
                        Variabili.tempo_Reclutamento--;
                    }
                    if (Variabili.Coda.Arciere.quantità > 0)
                    {
                        Arciere++;
                        Variabili.tempo_Reclutamento--;
                    }
                    if (Variabili.Coda.Catapulta.quantità > 0)
                    {
                        Catapulta++;
                        Variabili.tempo_Reclutamento--;
                    }

                    if (Variabili.Coda.Guerriero.quantità > 0 && Guerriero == Variabili.CostoReclutamento.Guerriero.TempoReclutamento)
                    {
                        Variabili.Esercito.Guerriero.Quantità++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Reclutamento Guerrirero\r\n" + txt_Cose.Text));
                        Variabili.Coda.Guerriero.quantità--;
                        Guerriero = 0;
                    }
                    if (Variabili.Coda.Lanciere.quantità > 0 && Lanciere == Variabili.CostoReclutamento.Lanciere.TempoReclutamento)
                    {
                        Variabili.Esercito.Lanciere.Quantità++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Reclutamento Lanciere\r\n" + txt_Cose.Text));
                        Variabili.Coda.Lanciere.quantità--;
                        Lanciere = 0;
                    }
                    if (Variabili.Coda.Arciere.quantità > 0 && Arciere == Variabili.CostoReclutamento.Arciere.TempoReclutamento)
                    {
                        Variabili.Esercito.Arciere.Quantità++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Reclutamento Arciere\r\n" + txt_Cose.Text));
                        Variabili.Coda.Arciere.quantità--;
                        Arciere = 0;
                    }
                    if (Variabili.Coda.Catapulta.quantità > 0 && Catapulta == Variabili.CostoReclutamento.Catapulta.TempoReclutamento)
                    {
                        Variabili.Esercito.Catapulta.Quantità++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Reclutamento Catapulta\r\n" + txt_Cose.Text));
                        Variabili.Coda.Catapulta.quantità--;
                        Catapulta = 0;
                    }
                    if (Variabili.Coda.Guerriero.quantità + Variabili.Coda.Lanciere.quantità + Variabili.Coda.Arciere.quantità + Variabili.Coda.Catapulta.quantità == 0)
                        Variabili.tempo_Costruzione = 0;
                }
                Thread.Sleep(1000);
            }
        }
        public void Load_Gui_Info()
        {
            if (txt_Cibo.InvokeRequired)
            {
                // Usa Invoke per eseguire le operazioni sul thread dell'UI
                txt_Cibo.Invoke((Action)(async () =>
                {
                txt_Cibo.Text = Variabili.Cibo.ToString("0.00");
                txt_Legno.Text = Variabili.Legno.ToString("0.00");
                txt_Pietra.Text = Variabili.Pietra.ToString("0.00");
                txt_Ferro.Text = Variabili.Ferro.ToString("0.00");
                txt_Oro.Text = Variabili.Oro.ToString("0.00");
                txt_Popolazione.Text = Variabili.Popolazione.ToString("0.00");

                txt_Spade.Text = Variabili.spade.ToString();
                txt_Lance.Text = Variabili.lance.ToString();
                txt_Archi.Text = Variabili.archi.ToString();
                txt_Scudi.Text = Variabili.scudi.ToString();
                txt_Armature.Text = Variabili.armature.ToString();

                txt_Produzione_Cibo.Text = ((Variabili.CostoCostruzione.Fattoria.Produzione * Variabili.fattoria) - await Cibo()).ToString("0.00");
                txt_Produzione_Legno.Text = (Variabili.CostoCostruzione.Segheria.Produzione * Variabili.segheria).ToString("0.00");
                txt_Produzione_Pietra.Text = (Variabili.CostoCostruzione.CavaPietra.Produzione * Variabili.cava_Pietra).ToString("0.00");
                txt_Produzione_Ferro.Text = (Variabili.CostoCostruzione.MinieraFerro.Produzione * Variabili.miniera_Ferro).ToString("0.00");
                txt_Produzione_Oro.Text = ((Variabili.CostoCostruzione.MinieraOro.Produzione * Variabili.miniera_Oro) - await Oro()).ToString("0.00");
                txt_Produzione_Popolazione.Text = Variabili.Popolazione_Up.ToString("0.00");

                txt_Tempo_Costruzione.Text = Variabili.tempo_Costruzione.ToString();
                txt_Tempo_Reclutamento.Text = Variabili.tempo_Reclutamento.ToString();
                txt_Strutture.Text = $"" +
                $"Fattorie:              {Variabili.fattoria}\r\n" +
                $"Segherie:            {Variabili.segheria}\r\n" +
                $"Cave di Pietra:    {Variabili.cava_Pietra}\r\n" +
                $"Miniera di Ferro: {Variabili.miniera_Ferro}\r\n" +
                $"Miniera d'Oro:     {Variabili.miniera_Oro}\r\n";
                txt_Esercito.Text = $"" +
                $"Guerriero:      {Variabili.Esercito.Guerriero.Quantità}\r\n" +
                $"Lanciere:       {Variabili.Esercito.Lanciere.Quantità}\r\n" +
                $"Arceri:           {Variabili.Esercito.Arciere.Quantità}\r\n" +
                $"Catapulte:      {Variabili.Esercito.Catapulta.Quantità}\r\n" +
                $"Forza Esercito: {Variabili.forza_Esercito.ToString("0.00")}";
                    //Coda Costruzione
                    txt_Fattoria_Coda.Text = Variabili.Coda.Fattoria.quantità.ToString();
                    txt_Segheria_Coda.Text = Variabili.Coda.Segheria.quantità.ToString();
                    txt_Cava_Coda.Text = Variabili.Coda.CavaPietra.quantità.ToString();
                    txt_Miniera_Ferro_Coda.Text = Variabili.Coda.MinieraFerro.quantità.ToString();
                    txt_Miniera_Oro_Coda.Text = Variabili.Coda.MinieraOro.quantità.ToString();
                    txt_Totale_Coda_Costruzioni.Text = (Variabili.Coda.Fattoria.quantità + Variabili.Coda.Segheria.quantità + Variabili.Coda.CavaPietra.quantità + Variabili.Coda.MinieraFerro.quantità + Variabili.Coda.MinieraOro.quantità).ToString();
                    //Coda Reclutamento
                    txt_Guerriero_Coda.Text = Variabili.Coda.Guerriero.quantità.ToString();
                    txt_Lancieri_Coda.Text = Variabili.Coda.Lanciere.quantità.ToString();
                    txt_Arciere_Coda.Text = Variabili.Coda.Arciere.quantità.ToString();
                    txt_Catapulta_Coda.Text = Variabili.Coda.Catapulta.quantità.ToString();
                    txt_Totale_Coda_Addestramento.Text = (Variabili.Coda.Guerriero.quantità + Variabili.Coda.Lanciere.quantità + Variabili.Coda.Arciere.quantità + Variabili.Coda.Catapulta.quantità).ToString();

                    //Città - Castello
                    lbl_Salute_Castello.Text = Variabili.Città.Castello.Salute.ToString() + "HP";
                    lbl_Difesa_Castello.Text = Variabili.Città.Castello.Difesa.ToString() + "DIF";
                    lbl_Guarnigione_Castello.Text = (Variabili.Città.Castello.Guerrieri + Variabili.Città.Castello.Lancieri + Variabili.Città.Castello.Arceri + Variabili.Città.Castello.Catapulte).ToString();
                    //Città - Torre
                    lbl_Salute_Torre.Text = Variabili.Città.Torre.Salute.ToString() + "HP";
                    lbl_Difesa_Torre.Text = Variabili.Città.Torre.Difesa.ToString() + "DIF";
                    lbl_Guarnigione_Torre.Text = (Variabili.Città.Torre.Guerrieri + Variabili.Città.Torre.Lancieri + Variabili.Città.Torre.Arceri + Variabili.Città.Torre.Catapulte).ToString();
                    //Città - Mura
                    lbl_Salute_Mura.Text = Variabili.Città.Mura.Salute.ToString() + "HP";
                    lbl_Difesa_Mura.Text = Variabili.Città.Mura.Difesa.ToString() + "DIF";
                    lbl_Guarnigione_Mura.Text = (Variabili.Città.Mura.Guerrieri + Variabili.Città.Mura.Lancieri + Variabili.Città.Mura.Arceri + Variabili.Città.Mura.Catapulte).ToString();

                    //Città - Salute
                    progressBar_Salute_Castello.Maximum = Variabili.Città.Castello.SaluteMax;
                    progressBar_Salute_Torre.Maximum = Variabili.Città.Torre.SaluteMax;
                    progressBar_Salute_Mura.Maximum = Variabili.Città.Mura.SaluteMax;
                    //Città - Difesa
                    progressBar_Difesa_Castello.Maximum = Variabili.Città.Castello.DifesaMax;
                    progressBar_Difesa_Torre.Maximum = Variabili.Città.Torre.DifesaMax;
                    progressBar_Difesa_Mura.Maximum = Variabili.Città.Mura.DifesaMax;
                    //Città - Progress Bar
                    progressBar_Salute_Castello.Value = Variabili.Città.Castello.Salute;
                    progressBar_Difesa_Castello.Value = Variabili.Città.Castello.Difesa;
                    progressBar_Guarnigione_Castello.Value = Variabili.Città.Castello.Guerrieri + Variabili.Città.Castello.Lancieri + Variabili.Città.Castello.Arceri + Variabili.Città.Castello.Catapulte;

                    progressBar_Salute_Torre.Value = Variabili.Città.Torre.Salute;
                    progressBar_Difesa_Torre.Value = Variabili.Città.Torre.Difesa;
                    progressBar_Guarnigione_Torre.Value = Variabili.Città.Torre.Guerrieri + Variabili.Città.Torre.Lancieri + Variabili.Città.Torre.Arceri + Variabili.Città.Torre.Catapulte;

                    progressBar_Salute_Mura.Value = Variabili.Città.Mura.Salute;
                    progressBar_Difesa_Mura.Value = Variabili.Città.Mura.Difesa;
                    progressBar_Guarnigione_Mura.Value = Variabili.Città.Mura.Guerrieri + Variabili.Città.Mura.Lancieri + Variabili.Città.Mura.Arceri + Variabili.Città.Mura.Catapulte;

                    //Gestione colori progress bar
                    if (progressBar_Salute_Castello.Value <= Variabili.Città.Castello.SaluteMax * Variabili.ProgressColorMax && progressBar_Salute_Castello.Value >= Variabili.Città.Castello.SaluteMax * Variabili.ProgressColorMin)
                        progressBar_Salute_Castello.SetState(3); //Giallo
                    else if (progressBar_Salute_Castello.Value < Variabili.Città.Castello.SaluteMax * Variabili.ProgressColorMin)
                        progressBar_Salute_Castello.SetState(2); //Rosso

                    if (progressBar_Difesa_Castello.Value <= Variabili.Città.Castello.DifesaMax * Variabili.ProgressColorMax && progressBar_Difesa_Castello.Value >= Variabili.Città.Castello.DifesaMax * Variabili.ProgressColorMin)
                        progressBar_Difesa_Castello.SetState(3); //Giallo
                    else if (progressBar_Difesa_Castello.Value < Variabili.Città.Castello.DifesaMax * Variabili.ProgressColorMin)
                        progressBar_Difesa_Castello.SetState(2); //Rosso

                    if (progressBar_Salute_Torre.Value <= Variabili.Città.Torre.SaluteMax * Variabili.ProgressColorMax && progressBar_Salute_Torre.Value >= Variabili.Città.Torre.SaluteMax * Variabili.ProgressColorMin)
                        progressBar_Salute_Torre.SetState(3); //Giallo
                    else if (progressBar_Salute_Torre.Value < Variabili.Città.Torre.SaluteMax * Variabili.ProgressColorMin)
                        progressBar_Salute_Torre.SetState(2); //Rosso

                    if (progressBar_Difesa_Torre.Value <= Variabili.Città.Torre.DifesaMax * Variabili.ProgressColorMax && progressBar_Difesa_Torre.Value >= Variabili.Città.Torre.DifesaMax * Variabili.ProgressColorMin)
                        progressBar_Difesa_Torre.SetState(3); //Giallo
                    else if (progressBar_Difesa_Torre.Value < Variabili.Città.Torre.DifesaMax * Variabili.ProgressColorMin)
                        progressBar_Difesa_Torre.SetState(2); //Rosso

                    if (progressBar_Salute_Mura.Value <= Variabili.Città.Mura.SaluteMax * Variabili.ProgressColorMax && progressBar_Salute_Mura.Value >= Variabili.Città.Mura.SaluteMax * Variabili.ProgressColorMin)
                        progressBar_Salute_Mura.SetState(3); //Giallo
                    else if (progressBar_Salute_Mura.Value < Variabili.Città.Mura.SaluteMax * Variabili.ProgressColorMin)
                        progressBar_Salute_Mura.SetState(2); //Rosso

                    if (progressBar_Difesa_Mura.Value <= Variabili.Città.Mura.DifesaMax * Variabili.ProgressColorMax && progressBar_Difesa_Mura.Value >= Variabili.Città.Mura.DifesaMax * Variabili.ProgressColorMin)
                        progressBar_Difesa_Mura.SetState(3); //Giallo
                    else if (progressBar_Difesa_Mura.Value < Variabili.Città.Mura.DifesaMax * Variabili.ProgressColorMin)
                        progressBar_Difesa_Mura.SetState(2); //Rosso

                    lbl_Tempo.Text = "Tempo Trascorso: " + ConvertSeconds(tempo_Trascorso);
                }));
            }
        }
        private void Invasione()
        {
            txt_Esercito_Invasore.Text = $"" +
                    $"Guerriero:      {Variabili.EsercitoNemico.Guerriero.Quantità}\r\n" +
                    $"Lanciere:       {Variabili.EsercitoNemico.Lanciere.Quantità}\r\n" +
                    $"Arceri:           {Variabili.EsercitoNemico.Arciere.Quantità}\r\n" +
                    $"Catapulte:      {Variabili.EsercitoNemico.Catapulta.Quantità}\r\n" +
                    $"Forza Esercito: {Variabili.forza_Esercito_Att.ToString("0.00")}";
            txt_Timer_Invasione.Text = Variabili.timer_Invasione.ToString();
            txt_Numero_Ondata.Text = Invasione_Ondata.ToString();
        }
        private async Task<double> Oro()
        {
            double oro = 0;

            oro += Variabili.Esercito.Guerriero.Quantità * Variabili.Esercito.Guerriero.Salario;
            oro += Variabili.Esercito.Lanciere.Quantità * Variabili.Esercito.Lanciere.Salario;
            oro += Variabili.Esercito.Arciere.Quantità * Variabili.Esercito.Arciere.Salario;
            oro += Variabili.Esercito.Catapulta.Quantità * Variabili.Esercito.Catapulta.Salario;

            return oro;
        }

        private void lbl_Fattoria_MouseHover(object sender, EventArgs e)
        {
            //txt_Log.Text = $"Costruzione Fattoria\r\nCibo: 1200\r\nLegno: 500\r\nPietra: 0\r\nFerro: 250\r\nOro: 0";
            txt_Log.Text = $"Costruzione Fattoria\r\n" +
                $"Cibo:       {Variabili.CostoCostruzione.Fattoria.Cibo}\r\n" +
                $"Legno:      {Variabili.CostoCostruzione.Fattoria.Legno}\r\n" +
                $"Pietra:     {Variabili.CostoCostruzione.Fattoria.Pietra}\r\n" +
                $"Ferro:      {Variabili.CostoCostruzione.Fattoria.Ferro}\r\n" +
                $"Oro:        {Variabili.CostoCostruzione.Fattoria.Oro}\r\n" +
                $"Tempo:      {Variabili.CostoCostruzione.Fattoria.TempoCostruzione}s\r\n" +
                $"Produzione: {Variabili.CostoCostruzione.Fattoria.Produzione}\r\n";
        }
        private void lbl_Segheria_MouseHover(object sender, EventArgs e)
        {
            //txt_Log.Text = "Costruzione Segheria\r\nCibo: 650\r\nLegno: 1000\r\nPietra: 0\r\nFerro: 300\r\nOro: 0";
            txt_Log.Text = $"Costruzione Segheria\r\n" +
                $"Cibo:           {Variabili.CostoCostruzione.Segheria.Cibo}\r\n" +
                $"Legno:        {Variabili.CostoCostruzione.Segheria.Legno}\r\n" +
                $"Pietra:         {Variabili.CostoCostruzione.Segheria.Pietra}\r\n" +
                $"Ferro:          {Variabili.CostoCostruzione.Segheria.Ferro}\r\n" +
                $"Oro:            {Variabili.CostoCostruzione.Segheria.Oro}\r\n" +
                $"Tempo:       {Variabili.CostoCostruzione.Segheria.TempoCostruzione}s\r\n" +
                $"Produzione: {Variabili.CostoCostruzione.Segheria.Produzione}\r\n";
        }
        private void lbl_CavaPietra_MouseHover(object sender, EventArgs e)
        {
            //txt_Log.Text = "Costruzione Cava Pietra\r\nCibo: 500\r\nLegno: 850\r\nPietra: 0\r\nFerro: 575\r\nOro: 0";
            txt_Log.Text = $"Costruzione Cava di Pietra\r\n" +
                $"Cibo:       {Variabili.CostoCostruzione.CavaPietra.Cibo}\r\n" +
                $"Legno:      {Variabili.CostoCostruzione.CavaPietra.Legno}\r\n" +
                $"Pietra:     {Variabili.CostoCostruzione.CavaPietra.Pietra}\r\n" +
                $"Ferro:      {Variabili.CostoCostruzione.CavaPietra.Ferro}\r\n" +
                $"Oro:        {Variabili.CostoCostruzione.CavaPietra.Oro}\r\n" +
                $"Tempo:      {Variabili.CostoCostruzione.CavaPietra.TempoCostruzione}s\r\n" +
                $"Produzione: {Variabili.CostoCostruzione.CavaPietra.Produzione}\r\n";
        }
        private void lbl_MinieraFerro_MouseHover(object sender, EventArgs e)
        {
            //txt_Log.Text = "Costruzione Miniera Ferro\r\nCibo: 500\r\nLegno: 875\r\nPietra: 0\r\nFerro: 420\r\nOro: 0";
            txt_Log.Text = $"Costruzione Miniera di Ferro\r\n" +
                $"Cibo:       {Variabili.CostoCostruzione.MinieraFerro.Cibo}\r\n" +
                $"Legno:      {Variabili.CostoCostruzione.MinieraFerro.Legno}\r\n" +
                $"Pietra:     {Variabili.CostoCostruzione.MinieraFerro.Pietra}\r\n" +
                $"Ferro:      {Variabili.CostoCostruzione.MinieraFerro.Ferro}\r\n" +
                $"Oro:        {Variabili.CostoCostruzione.MinieraFerro.Oro}\r\n" +
                $"Tempo:      {Variabili.CostoCostruzione.MinieraFerro.TempoCostruzione}s\r\n" +
                $"Produzione: {Variabili.CostoCostruzione.MinieraFerro.Produzione}\r\n";
        }
        private void lbl_MinieraOro_MouseHover(object sender, EventArgs e)
        {
            //txt_Log.Text = "Costruzione Miniera Oro\r\nCibo: 750\r\nLegno: 975\r\nPietra: 0\r\nFerro: 525\r\nOro: 0";
            txt_Log.Text = $"Costruzione Miniera d'Oro\r\n" +
                $"Cibo:       {Variabili.CostoCostruzione.MinieraOro.Cibo}\r\n" +
                $"Legno:      {Variabili.CostoCostruzione.MinieraOro.Legno}\r\n" +
                $"Pietra:     {Variabili.CostoCostruzione.MinieraOro.Pietra}\r\n" +
                $"Ferro:      {Variabili.CostoCostruzione.MinieraOro.Ferro}\r\n" +
                $"Oro:        {Variabili.CostoCostruzione.MinieraOro.Oro}\r\n" +
                $"Tempo:      {Variabili.CostoCostruzione.MinieraOro.TempoCostruzione}s\r\n" +
                $"Produzione: {Variabili.CostoCostruzione.MinieraOro.Produzione}\r\n";
        }

        private void btn_Invasioni_Click(object sender, EventArgs e)
        {
            btn_Invasioni.Enabled = false;
            btn_Invasioni.Visible = false;
            txt_Esercito_Invasore.Visible = true;
            Blocco_Città.Visible = true;

            Variabili.timer_Invasione = Variabili.timer_Invasione_Set;
            _ = Task.Run(() => Loop_Invasione());
        }
        void Loop_Invasione()
        {
            int Guerriero = 50;
            int i = 0;

            Variabili.EsercitoNemico.Guerriero.Quantità = 14;
            Variabili.EsercitoNemico.Lanciere.Quantità = 8;
            Variabili.EsercitoNemico.Arciere.Quantità = 6;
            Variabili.EsercitoNemico.Catapulta.Quantità = 1;

            if (Invasione_Ondata > 1)
            {
                Variabili.EsercitoNemico.Guerriero.Quantità  = Convert.ToInt32(4 + Convert.ToDouble(Variabili.EsercitoNemico.Guerriero.Quantità) * 1.19);
                Variabili.EsercitoNemico.Lanciere.Quantità   = Convert.ToInt32(3 + Convert.ToDouble(Variabili.EsercitoNemico.Lanciere.Quantità)  * 1.14);
                Variabili.EsercitoNemico.Arciere.Quantità    = Convert.ToInt32(2 + Convert.ToDouble(Variabili.EsercitoNemico.Arciere.Quantità)   * 1.11);
                Variabili.EsercitoNemico.Catapulta.Quantità  = Convert.ToInt32(1 + Convert.ToDouble(Variabili.EsercitoNemico.Catapulta.Quantità) * 1.08);
            }

            while (true)
            {
                if(i == 7 && Invasione_Ondata > 6) Variabili.EsercitoNemico.Guerriero.Quantità += 3;
                if (i == 9 && Invasione_Ondata > 10) Variabili.EsercitoNemico.Lanciere.Quantità += 2;
                if (i == 12 && Invasione_Ondata > 14) Variabili.EsercitoNemico.Arciere.Quantità += 2;

                if (i == Variabili.CostoReclutamento.Guerriero.TempoReclutamento - 4)
                {
                    Variabili.EsercitoNemico.Guerriero.Quantità++;
                    i = 0;
                }
                if (i == Variabili.CostoReclutamento.Lanciere.TempoReclutamento - 7 && Invasione_Ondata > 7)
                {
                    Variabili.EsercitoNemico.Lanciere.Quantità++;
                    i = 0;
                }
                if (i == Variabili.CostoReclutamento.Arciere.TempoReclutamento - 9 && Invasione_Ondata > 15)
                {
                    Variabili.EsercitoNemico.Arciere.Quantità++;
                    i = 0;
                }
                if (i == Variabili.CostoReclutamento.Catapulta.TempoReclutamento - 11 && Invasione_Ondata > 22)
                {
                    Variabili.EsercitoNemico.Catapulta.Quantità++;
                    i = 0;
                }
                i++;
                txt_Cibo.Invoke((Action)(async () => { Invasione(); }));
                Variabili.timer_Invasione--;

                Variabili.forza_Esercito_Att =
                    Variabili.EsercitoNemico.Guerriero.Quantità * ((Variabili.Esercito.Guerriero.Salute * 0.33) + (Variabili.Esercito.Guerriero.Attacco * 0.72)) +
                    Variabili.EsercitoNemico.Lanciere.Quantità * ((Variabili.Esercito.Lanciere.Salute * 0.33) + (Variabili.Esercito.Lanciere.Attacco * 0.72)) +
                    Variabili.EsercitoNemico.Arciere.Quantità * ((Variabili.Esercito.Arciere.Salute * 0.33) + (Variabili.Esercito.Arciere.Attacco * 0.72)) +
                    Variabili.EsercitoNemico.Catapulta.Quantità * ((Variabili.Esercito.Catapulta.Salute * 0.33) + (Variabili.Esercito.Catapulta.Attacco * 0.72));
                if (Variabili.timer_Invasione == 0)
                {
                    Battle.Battaglia();
                    Invasione_Ondata++;
                    Variabili.timer_Invasione = Variabili.timer_Invasione_Set + (50 * Invasione_Ondata);
                }
                if (Variabili.timer_Invasione == 0) Variabili.timer_Invasione--; ;
                Thread.Sleep(1000);
            }
        }
        static string ConvertSeconds(int totalSeconds)
        {
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;

            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }
        private void btn_Ricerca_Click(object sender, EventArgs e)
        {
            if (Variabili.Cibo      >= Variabili.Ricerca.Sblocco_Ricerca.Cibo && 
                Variabili.Legno     >= Variabili.Ricerca.Sblocco_Ricerca.Legno && 
                Variabili.Pietra    >= Variabili.Ricerca.Sblocco_Ricerca.Pietra &&
                Variabili.Ferro     >= Variabili.Ricerca.Sblocco_Ricerca.Ferro && 
                Variabili.Oro       >= Variabili.Ricerca.Sblocco_Ricerca.Oro)
            {
                Variabili.Cibo      -= Variabili.Ricerca.Sblocco_Ricerca.Cibo;
                Variabili.Legno     -= Variabili.Ricerca.Sblocco_Ricerca.Legno;
                Variabili.Pietra    -= Variabili.Ricerca.Sblocco_Ricerca.Pietra;
                Variabili.Ferro     -= Variabili.Ricerca.Sblocco_Ricerca.Ferro;
                Variabili.Oro       -= Variabili.Ricerca.Sblocco_Ricerca.Oro;
                Blocco_Ricerca.Visible = true;
                btn_Ricerca.Visible = false;
            }
            else txt_Cose.Text = "Sblocco ricerca fallita, risorse insufficienti\r\n" + txt_Cose.Text;

        }
        private void btn_Risorse_Produzione_Click(object sender, EventArgs e)
        {
            switch (btn_Risorse_Produzione.Text)
            {
                case "Produzione I":
                    if (Variabili.Cibo >= Variabili.Ricerca.Produzione_I.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Produzione_I.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Produzione_I.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Produzione_I.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Produzione_I.Oro)
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Produzione_I.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Produzione_I.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Produzione_I.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Produzione_I.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Produzione_I.Oro;

                        btn_Risorse_Produzione.Text = "Produzione II";
                        Variabili.CostoCostruzione.Fattoria.Produzione += 0.19;
                        Variabili.CostoCostruzione.Segheria.Produzione += 0.17;
                        Variabili.CostoCostruzione.CavaPietra.Produzione += 0.15;
                        Variabili.CostoCostruzione.MinieraFerro.Produzione += 0.13;
                        Variabili.CostoCostruzione.MinieraOro.Produzione += 0.11;
                    }
                    else txt_Cose.Text = "Ricerca Produzione I fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Produzione II":
                    if (Variabili.Cibo >= Variabili.Ricerca.Produzione_II.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Produzione_II.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Produzione_II.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Produzione_II.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Produzione_II.Oro &&
                        btn_Risorse_Produzione.Text == "Produzione II")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Produzione_II.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Produzione_II.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Produzione_II.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Produzione_II.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Produzione_II.Oro;

                        btn_Risorse_Produzione.Text = "Produzione III";
                        Variabili.CostoCostruzione.Fattoria.Produzione += 0.20;
                        Variabili.CostoCostruzione.Segheria.Produzione += 0.18;
                        Variabili.CostoCostruzione.CavaPietra.Produzione += 0.16;
                        Variabili.CostoCostruzione.MinieraFerro.Produzione += 0.14;
                        Variabili.CostoCostruzione.MinieraOro.Produzione += 0.12;
                    }
                    else txt_Cose.Text = "Ricerca Produzione II fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Produzione III":
                    if (Variabili.Cibo >= Variabili.Ricerca.Produzione_III.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Produzione_III.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Produzione_III.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Produzione_III.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Produzione_III.Oro &&
                        btn_Risorse_Produzione.Text == "Produzione III")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Produzione_III.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Produzione_III.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Produzione_III.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Produzione_III.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Produzione_III.Oro;

                        btn_Risorse_Produzione.Text = "Produzione IV";
                        btn_Risorse_Produzione.Enabled = false;
                        Variabili.CostoCostruzione.Fattoria.Produzione += 0.22;
                        Variabili.CostoCostruzione.Segheria.Produzione += 0.20;
                        Variabili.CostoCostruzione.CavaPietra.Produzione += 0.18;
                        Variabili.CostoCostruzione.MinieraFerro.Produzione += 0.16;
                        Variabili.CostoCostruzione.MinieraOro.Produzione += 0.13;
                    }
                    else txt_Cose.Text = "Ricerca Produzione III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
            }
        }
        private void btn_Risorse_Costruzione_Click(object sender, EventArgs e)
        {
            switch (btn_Risorse_Costruzione.Text)
            {
                case "Costruzione I":
                    if (Variabili.Cibo >= Variabili.Ricerca.Costruzione_I.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Costruzione_I.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Costruzione_I.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Costruzione_I.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Costruzione_I.Oro)
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Costruzione_I.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Costruzione_I.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Costruzione_I.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Costruzione_I.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Costruzione_I.Oro;

                        btn_Risorse_Costruzione.Text = "Costruzione II";
                        Variabili.CostoCostruzione.Fattoria.TempoCostruzione -= 1;
                        Variabili.CostoCostruzione.Segheria.TempoCostruzione -= 1;
                        Variabili.CostoCostruzione.CavaPietra.TempoCostruzione -= 1;
                        Variabili.CostoCostruzione.MinieraFerro.TempoCostruzione -= 1;
                        Variabili.CostoCostruzione.MinieraOro.TempoCostruzione -= 2;
                    }
                    else txt_Cose.Text = "Ricerca Costruzione I fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Costruzione II":
                    if (Variabili.Cibo >= Variabili.Ricerca.Costruzione_II.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Costruzione_II.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Costruzione_II.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Costruzione_II.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Costruzione_II.Oro &&
                        btn_Risorse_Costruzione.Text == "Costruzione II")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Costruzione_II.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Costruzione_II.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Costruzione_II.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Costruzione_II.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Costruzione_II.Oro;

                        btn_Risorse_Costruzione.Text = "Costruzione III";
                        Variabili.CostoCostruzione.Fattoria.TempoCostruzione -= 2;
                        Variabili.CostoCostruzione.Segheria.TempoCostruzione -= 2;
                        Variabili.CostoCostruzione.CavaPietra.TempoCostruzione -= 2;
                        Variabili.CostoCostruzione.MinieraFerro.TempoCostruzione -= 2;
                        Variabili.CostoCostruzione.MinieraOro.TempoCostruzione -= 3;
                    }
                    else txt_Cose.Text = "Ricerca Costruzione III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Costruzione III":
                    if (Variabili.Cibo >= Variabili.Ricerca.Costruzione_III.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Costruzione_III.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Costruzione_III.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Costruzione_III.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Costruzione_III.Oro &&
                        btn_Risorse_Costruzione.Text == "Costruzione III")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Costruzione_III.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Costruzione_III.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Costruzione_III.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Costruzione_III.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Costruzione_III.Oro;

                        btn_Risorse_Costruzione.Text = "Costruzione IV";
                        btn_Risorse_Costruzione.Enabled = false;
                        Variabili.CostoCostruzione.Fattoria.TempoCostruzione -= 3;
                        Variabili.CostoCostruzione.Segheria.TempoCostruzione -= 3;
                        Variabili.CostoCostruzione.CavaPietra.TempoCostruzione -= 3;
                        Variabili.CostoCostruzione.MinieraFerro.TempoCostruzione -= 3;
                        Variabili.CostoCostruzione.MinieraOro.TempoCostruzione -= 4;
                    }
                    else txt_Cose.Text = "Ricerca Costruzione III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
            }
        }
        private void btn_Risorse_Popolazione_Click(object sender, EventArgs e)
        {
            switch (btn_Risorse_Popolazione.Text)
            {
                case "Popolazione I":
                    if (Variabili.Cibo >= Variabili.Ricerca.Popolazione_I.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Popolazione_I.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Popolazione_I.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Popolazione_I.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Popolazione_I.Oro)
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Popolazione_I.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Popolazione_I.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Popolazione_I.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Popolazione_I.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Popolazione_I.Oro;

                        btn_Risorse_Popolazione.Text = "Popolazione II";
                        Variabili.Popolazione_Up += 0.07;
                    }
                    else txt_Cose.Text = "Ricerca Popolazione I fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Popolazione II":
                    if (Variabili.Cibo >= Variabili.Ricerca.Popolazione_II.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Popolazione_II.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Popolazione_II.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Popolazione_II.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Popolazione_II.Oro
                        && btn_Risorse_Popolazione.Text == "Popolazione II")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Popolazione_II.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Popolazione_II.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Popolazione_II.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Popolazione_II.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Popolazione_II.Oro;

                        btn_Risorse_Popolazione.Text = "Popolazione III";
                        Variabili.Popolazione_Up += 0.11;
                    }
                    else txt_Cose.Text = "Ricerca Popolazione II fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Popolazione III":
                    if (Variabili.Cibo >= Variabili.Ricerca.Popolazione_III.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Popolazione_III.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Popolazione_III.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Popolazione_III.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Popolazione_III.Oro &&
                        btn_Risorse_Popolazione.Text == "Popolazione III")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Popolazione_III.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Popolazione_III.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Popolazione_III.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Popolazione_III.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Popolazione_III.Oro;

                        btn_Risorse_Popolazione.Text = "Popolazione IV";
                        btn_Risorse_Popolazione.Enabled = false;
                        Variabili.Popolazione_Up += 0.14;
                    }
                    else txt_Cose.Text = "Ricerca Popolazione III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
            }
        }
        private void btn_Esercito_Reclutamento_Click(object sender, EventArgs e)
        {
            switch (btn_Esercito_Reclutamento.Text)
            {
                case "Reclutamento I":
                    if (Variabili.Cibo >= Variabili.Ricerca.Reclutamento_I.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Reclutamento_I.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Reclutamento_I.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Reclutamento_I.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Reclutamento_I.Oro)
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Reclutamento_I.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Reclutamento_I.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Reclutamento_I.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Reclutamento_I.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Reclutamento_I.Oro;

                        btn_Esercito_Reclutamento.Text = "Reclutamento II";
                        Variabili.CostoReclutamento.Guerriero.TempoReclutamento -= 1;
                        Variabili.CostoReclutamento.Lanciere.TempoReclutamento -= 1;
                        Variabili.CostoReclutamento.Arciere.TempoReclutamento -= 1;
                        Variabili.CostoReclutamento.Catapulta.TempoReclutamento -= 2;
                    }
                    else txt_Cose.Text = "Ricerca Reclutamento I fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Reclutamento II":
                    if (Variabili.Cibo >= Variabili.Ricerca.Reclutamento_II.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Reclutamento_II.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Reclutamento_II.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Reclutamento_II.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Reclutamento_II.Oro &&
                        btn_Esercito_Reclutamento.Text == "Reclutamento II")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Reclutamento_II.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Reclutamento_II.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Reclutamento_II.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Reclutamento_II.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Reclutamento_II.Oro;

                        btn_Esercito_Reclutamento.Text = "Reclutamento III";
                        Variabili.CostoReclutamento.Guerriero.TempoReclutamento -= 2;
                        Variabili.CostoReclutamento.Lanciere.TempoReclutamento -= 2;
                        Variabili.CostoReclutamento.Arciere.TempoReclutamento -= 2;
                        Variabili.CostoReclutamento.Catapulta.TempoReclutamento -= 3;
                    }
                    else txt_Cose.Text = "Ricerca Reclutamento III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Reclutamento III":
                    if (Variabili.Cibo >= Variabili.Ricerca.Reclutamento_III.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Reclutamento_III.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Reclutamento_III.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Reclutamento_III.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Reclutamento_III.Oro &&
                        btn_Esercito_Reclutamento.Text == "Reclutamento III")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Reclutamento_III.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Reclutamento_III.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Reclutamento_III.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Reclutamento_III.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Reclutamento_III.Oro;

                        btn_Esercito_Reclutamento.Text = "Reclutamento IV";
                        btn_Esercito_Reclutamento.Enabled = false;
                        Variabili.CostoReclutamento.Guerriero.TempoReclutamento -= 3;
                        Variabili.CostoReclutamento.Lanciere.TempoReclutamento -= 3;
                        Variabili.CostoReclutamento.Arciere.TempoReclutamento -= 3;
                        Variabili.CostoReclutamento.Catapulta.TempoReclutamento -= 4;
                    }
                    else txt_Cose.Text = "Ricerca Reclutamento III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
            }
        }
        private void btn_Esercito_Salute_Click(object sender, EventArgs e)
        {
            switch (btn_Esercito_Salute.Text)
            {
                case "Salute I":
                    if (Variabili.Cibo >= Variabili.Ricerca.Salute_I.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Salute_I.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Salute_I.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Salute_I.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Salute_I.Oro)
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Salute_I.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Salute_I.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Salute_I.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Salute_I.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Salute_I.Oro;

                        btn_Esercito_Salute.Text = "Salute II";
                        Variabili.Esercito.Guerriero.Difesa += 1;
                        Variabili.Esercito.Lanciere.Difesa += 1;
                        Variabili.Esercito.Arciere.Difesa += 1;
                        Variabili.Esercito.Catapulta.Difesa += 2;
                    }
                    else txt_Cose.Text = "Ricerca Salute I fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Salute II":
                    if (Variabili.Cibo >= Variabili.Ricerca.Salute_II.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Salute_II.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Salute_II.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Salute_II.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Salute_II.Oro &&
                        btn_Esercito_Salute.Text == "Salute II")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Salute_II.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Salute_II.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Salute_II.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Salute_II.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Salute_II.Oro;

                        btn_Esercito_Salute.Text = "Salute III";
                        Variabili.Esercito.Guerriero.Salute += 2;
                        Variabili.Esercito.Lanciere.Salute += 2;
                        Variabili.Esercito.Arciere.Salute += 2;
                        Variabili.Esercito.Catapulta.Salute += 3;
                    }
                    else txt_Cose.Text = "Ricerca Salute III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Salute III":
                    if (Variabili.Cibo >= Variabili.Ricerca.Salute_III.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Salute_III.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Salute_III.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Salute_III.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Salute_III.Oro &&
                        btn_Esercito_Salute.Text == "Salute III")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Salute_III.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Salute_III.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Salute_III.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Salute_III.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Salute_III.Oro;

                        btn_Esercito_Salute.Text = "Salute IV";
                        btn_Esercito_Salute.Enabled = false;
                        Variabili.Esercito.Guerriero.Salute += 3;
                        Variabili.Esercito.Lanciere.Salute += 3;
                        Variabili.Esercito.Arciere.Salute += 3;
                        Variabili.Esercito.Catapulta.Salute += 4;
                    }
                    else txt_Cose.Text = "Ricerca Salute III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
            }
        }
        private void btn_Esercito_Attacco_Click(object sender, EventArgs e)
        {
            switch (btn_Esercito_Attacco.Text)
            {
                case "Attacco I":
                    if (Variabili.Cibo >= Variabili.Ricerca.Attacco_I.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Attacco_I.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Attacco_I.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Attacco_I.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Attacco_I.Oro)
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Attacco_I.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Attacco_I.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Attacco_I.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Attacco_I.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Attacco_I.Oro;

                        btn_Esercito_Attacco.Text = "Attacco II";
                        Variabili.Esercito.Guerriero.Attacco += 1;
                        Variabili.Esercito.Lanciere.Attacco += 1;
                        Variabili.Esercito.Arciere.Attacco += 1;
                        Variabili.Esercito.Catapulta.Attacco += 2;
                    }
                    else txt_Cose.Text = "Ricerca Attacco Esercito I fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Attacco II":
                    if (Variabili.Cibo >= Variabili.Ricerca.Attacco_II.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Attacco_II.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Attacco_II.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Attacco_II.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Attacco_II.Oro &&
                        btn_Esercito_Attacco.Text == "Attacco II")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Attacco_II.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Attacco_II.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Attacco_II.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Attacco_II.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Attacco_II.Oro;

                        btn_Esercito_Attacco.Text = "Attacco III";
                        Variabili.Esercito.Guerriero.Attacco += 2;
                        Variabili.Esercito.Lanciere.Attacco += 2;
                        Variabili.Esercito.Arciere.Attacco += 2;
                        Variabili.Esercito.Catapulta.Attacco += 3;
                    }
                    else txt_Cose.Text = "Ricerca Attacco Esercito III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Attacco III":
                    if (Variabili.Cibo >= Variabili.Ricerca.Attacco_III.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Attacco_III.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Attacco_III.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Attacco_III.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Attacco_III.Oro &&
                        btn_Esercito_Attacco.Text == "Attacco III")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Attacco_III.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Attacco_III.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Attacco_III.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Attacco_III.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Attacco_III.Oro;

                        btn_Esercito_Attacco.Text = "Attacco IV";
                        btn_Esercito_Attacco.Enabled = false;
                        Variabili.Esercito.Guerriero.Attacco += 3;
                        Variabili.Esercito.Lanciere.Attacco += 3;
                        Variabili.Esercito.Arciere.Attacco += 3;
                        Variabili.Esercito.Catapulta.Attacco += 4;
                    }
                    else txt_Cose.Text = "Ricerca Attacco Esercito III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
            }
        }
        private void btn_Esercito_Difesa_Click(object sender, EventArgs e)
        {
            switch (btn_Esercito_Difesa.Text)
            {
                case "Difesa I":
                    if (Variabili.Cibo >= Variabili.Ricerca.Difesa_I.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Difesa_I.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Difesa_I.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Difesa_I.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Difesa_I.Oro)
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Difesa_I.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Difesa_I.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Difesa_I.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Difesa_I.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Difesa_I.Oro;

                        btn_Esercito_Difesa.Text = "Difesa II";
                        Variabili.Esercito.Guerriero.Difesa += 1;
                        Variabili.Esercito.Lanciere.Difesa += 1;
                        Variabili.Esercito.Arciere.Difesa += 1;
                        Variabili.Esercito.Catapulta.Difesa += 2;
                    }
                    else txt_Cose.Text = "Ricerca Difesa I fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Difesa II":
                    if (Variabili.Cibo >= Variabili.Ricerca.Difesa_II.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Difesa_II.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Difesa_II.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Difesa_II.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Difesa_II.Oro &&
                        btn_Esercito_Difesa.Text == "Difesa II")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Difesa_II.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Difesa_II.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Difesa_II.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Difesa_II.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Difesa_II.Oro;

                        btn_Esercito_Difesa.Text = "Difesa III";
                        Variabili.Esercito.Guerriero.Difesa += 2;
                        Variabili.Esercito.Lanciere.Difesa += 2;
                        Variabili.Esercito.Arciere.Difesa += 2;
                        Variabili.Esercito.Catapulta.Difesa += 3;
                    }
                    else txt_Cose.Text = "Ricerca Difesa III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Difesa III":
                    if (Variabili.Cibo >= Variabili.Ricerca.Difesa_III.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Difesa_III.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Difesa_III.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Difesa_III.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Difesa_III.Oro &&
                        btn_Esercito_Difesa.Text == "Difesa III")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Difesa_III.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Difesa_III.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Difesa_III.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Difesa_III.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Difesa_III.Oro;

                        btn_Esercito_Difesa.Text = "Difesa IV";
                        btn_Esercito_Difesa.Enabled = false;
                        Variabili.Esercito.Guerriero.Difesa += 3;
                        Variabili.Esercito.Lanciere.Difesa += 3;
                        Variabili.Esercito.Arciere.Difesa += 3;
                        Variabili.Esercito.Catapulta.Difesa += 4;
                    }
                    else txt_Cose.Text = "Ricerca Difesa III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
            }
        }

        private void btn_Citta_Guarnigione_Click(object sender, EventArgs e)
        {

        }
        private void btn_Citta_Difesa_Click(object sender, EventArgs e)
        {

        }
        private void btn_Citta_Salute_Click(object sender, EventArgs e)
        {

        }

        private void btn_Ricerca_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text = $"Sblocco Ricerca:\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Sblocco_Ricerca.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Sblocco_Ricerca.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Sblocco_Ricerca.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Sblocco_Ricerca.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Sblocco_Ricerca.Oro}\r\n";
        }
        private void btn_Risorse_Costruzione_MouseHover(object sender, EventArgs e)
        {
            if (btn_Risorse_Costruzione.Text == "Costruzione I")
                txt_Log.Text = $"Costruzione I\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Costruzione_I.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Costruzione_I.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Costruzione_I.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Costruzione_I.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Costruzione_I.Oro}\r\n";

            if (btn_Risorse_Costruzione.Text == "Costruzione II")
                txt_Log.Text = $"Costruzione II\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Costruzione_II.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Costruzione_II.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Costruzione_II.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Costruzione_II.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Costruzione_II.Oro}\r\n";

            if (btn_Risorse_Costruzione.Text == "Costruzione III")
                txt_Log.Text = $"Costruzione III\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Costruzione_III.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Costruzione_III.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Costruzione_III.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Costruzione_III.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Costruzione_III.Oro}\r\n";
        }
        private void btn_Risorse_Produzione_MouseHover(object sender, EventArgs e)
        {
            if (btn_Risorse_Produzione.Text == "Produzione I")
                txt_Log.Text = $"Produzione I\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Produzione_I.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Produzione_I.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Produzione_I.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Produzione_I.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Produzione_I.Oro}\r\n";

            if (btn_Risorse_Produzione.Text == "Produzione II")
                txt_Log.Text = $"Produzione II\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Produzione_II.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Produzione_II.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Produzione_II.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Produzione_II.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Produzione_II.Oro}\r\n";

            if (btn_Risorse_Produzione.Text == "Produzione III")
                txt_Log.Text = $"Produzione III\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Produzione_III.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Produzione_III.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Produzione_III.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Produzione_III.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Produzione_III.Oro}\r\n";
        }
        private void btn_Risorse_Popolazione_MouseHover(object sender, EventArgs e)
        {
            if (btn_Risorse_Popolazione.Text == "Popolazione I")
                txt_Log.Text = $"Popolazione I\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Popolazione_I.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Popolazione_I.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Popolazione_I.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Popolazione_I.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Popolazione_I.Oro}\r\n";

            if (btn_Risorse_Popolazione.Text == "Popolazione II")
                txt_Log.Text = $"Popolazione II\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Popolazione_II.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Popolazione_II.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Popolazione_II.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Popolazione_II.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Popolazione_II.Oro}\r\n";

            if (btn_Risorse_Popolazione.Text == "Popolazione III")
                txt_Log.Text = $"Popolazione III\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Popolazione_III.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Popolazione_III.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Popolazione_III.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Popolazione_III.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Popolazione_III.Oro}\r\n";
        }
        private void btn_Esercito_Reclutamento_MouseHover(object sender, EventArgs e)
        {
            if (btn_Esercito_Reclutamento.Text == "Reclutamento I")
                txt_Log.Text = $"Reclutamento I\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Reclutamento_I.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Reclutamento_I.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Reclutamento_I.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Reclutamento_I.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Reclutamento_I.Oro}\r\n";

            if (btn_Esercito_Reclutamento.Text == "Reclutamento II")
                txt_Log.Text = $"Reclutamento II\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Reclutamento_II.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Reclutamento_II.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Reclutamento_II.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Reclutamento_II.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Reclutamento_II.Oro}\r\n";

            if (btn_Esercito_Reclutamento.Text == "Reclutamento III")
                txt_Log.Text = $"Reclutamento III\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Reclutamento_III.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Reclutamento_III.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Reclutamento_III.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Reclutamento_III.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Reclutamento_III.Oro}\r\n";
        }
        private void btn_Esercito_Salute_MouseHover(object sender, EventArgs e)
        {
            if (btn_Esercito_Salute.Text == "Salute I")
                txt_Log.Text = $"Salute I\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Salute_I.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Salute_I.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Salute_I.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Salute_I.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Salute_I.Oro}\r\n";

            if (btn_Esercito_Salute.Text == "Salute II")
                txt_Log.Text = $"Salute II\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Salute_II.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Salute_II.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Salute_II.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Salute_II.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Salute_II.Oro}\r\n";

            if (btn_Esercito_Salute.Text == "Salute III")
                txt_Log.Text = $"Salute III\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Salute_III.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Salute_III.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Salute_III.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Salute_III.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Salute_III.Oro}\r\n";
        }
        private void btn_Esercito_Attacco_MouseHover(object sender, EventArgs e)
        {
            if (btn_Esercito_Attacco.Text == "Attacco I")
                txt_Log.Text = $"Attacco I\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Attacco_I.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Attacco_I.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Attacco_I.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Attacco_I.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Attacco_I.Oro}\r\n";

            if (btn_Esercito_Attacco.Text == "Attacco II")
                txt_Log.Text = $"Attacco II\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Attacco_II.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Attacco_II.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Attacco_II.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Attacco_II.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Attacco_II.Oro}\r\n";

            if (btn_Esercito_Attacco.Text == "Attacco III")
                txt_Log.Text = $"Attacco III\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Attacco_III.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Attacco_III.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Attacco_III.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Attacco_III.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Attacco_III.Oro}\r\n";
        }
        private void btn_Esercito_Difesa_MouseHover(object sender, EventArgs e)
        {
            if (btn_Esercito_Difesa.Text == "Difesa I")
                txt_Log.Text = $"Difesa I\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Difesa_I.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Difesa_I.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Difesa_I.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Difesa_I.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Difesa_I.Oro}\r\n";

            if (btn_Esercito_Difesa.Text == "Difesa II")
                txt_Log.Text = $"Difesa II\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Difesa_II.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Difesa_II.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Difesa_II.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Difesa_II.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Difesa_II.Oro}\r\n";

            if (btn_Esercito_Difesa.Text == "Difesa III")
                txt_Log.Text = $"Difesa III\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Difesa_III.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Difesa_III.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Difesa_III.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Difesa_III.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Difesa_III.Oro}\r\n";
        }

        private void btn_Citta_Difesa_MouseHover(object sender, EventArgs e)
        {

        }
        private void btn_Citta_Guarnigione_MouseHover(object sender, EventArgs e)
        {

        }
        private void btn_Citta_Salute_MouseHover(object sender, EventArgs e)
        {

        }
        public static void Log_Battaglia(string messaggio)
        {
            _ = log_Battaglia.Invoke((Action)(() => log_Battaglia.Text = $"{messaggio}\r\n" + log_Battaglia.Text));
        }
        public static void Log(string messaggio)
        {
            _ = log.Invoke((Action)(() => log.Text = $"{messaggio}\r\n" + log.Text));
        }

        private void progressBar_Salute_Castello_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text =
                $"Salute Castello: {Variabili.Città.Castello.Salute}/{Variabili.Città.Castello.SaluteMax}\r\n" +
                $"\r\nCosto Riparazioni:\r\n" +
                $"Cibo:   {1 * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute)}\r\n" +
                $"Legno:  {2 * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute)}\r\n" +
                $"Pietra: {3 * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute)}\r\n" +
                $"Ferro:  {4 * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute)}\r\n" +
                $"Oro:    {5 * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute)}\r\n" +
                $"Per riparare il castello, premere sulla barra della salute\r\n";
        }
        private void progressBar_Salute_Torre_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text =
                $"Salute Torre: {Variabili.Città.Torre.Salute}/|{Variabili.Città.Torre.SaluteMax}\r\n" +
                $"\r\nCosto Riparazioni:\r\n" +
                $"Cibo:   {1 * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute)}\r\n" +
                $"Legno:  {2 * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute)}\r\n" +
                $"Pietra: {3 * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute)}\r\n" +
                $"Ferro:  {4 * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute)}\r\n" +
                $"Oro:    {5 * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute)}\r\n" +
                $"Per riparare la torre, premere sulla barra della salute\r\n";
        }
        private void progressBar_Salute_Mura_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text =
                $"Salute Mura: {Variabili.Città.Mura.Salute}/{Variabili.Città.Mura.SaluteMax}\r\n" +
                $"\r\nCosto Riparazioni:\r\n" +
                $"Cibo:   {1 * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute)}\r\n" +
                $"Legno:  {2 * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute)}\r\n" +
                $"Pietra: {3 * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute)}\r\n" +
                $"Ferro:  {4 * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute)}\r\n" +
                $"Oro:    {5 * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute)}\r\n" +
                $"Per riparare le mura, premere sulla barra della salute\r\n";
        }
        private void progressBar_Difesa_Castello_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text =
                $"Difesa Castello: {Variabili.Città.Castello.Difesa}/{Variabili.Città.Castello.DifesaMax}\r\n" +
                $"\r\nCosto Riparazioni\r\n:" +
                $"Cibo:   {1 * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa)}\r\n" +
                $"Legno:  {2 * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa)}\r\n" +
                $"Pietra: {3 * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa)}\r\n" +
                $"Ferro:  {4 * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa)}\r\n" +
                $"Oro:    {5 * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa)}\r\n" +
                $"Per ripristinare le difese del castello, premere sulla barra della difesa\r\n";
        }
        private void progressBar_Difesa_Torre_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text =
                $"Difesa Torre: {Variabili.Città.Torre.Difesa}/{Variabili.Città.Torre.DifesaMax}\r\n" +
                $"\r\nCosto Riparazioni:\r\n" +
                $"Cibo:   {1 * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa)}\r\n" +
                $"Legno:  {2 * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa)}\r\n" +
                $"Pietra: {3 * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa)}\r\n" +
                $"Ferro:  {4 * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa)}\r\n" +
                $"Oro:    {5 * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa)}\r\n" +
                $"Per ripristinare le difese della torre, premere sulla barra della difesa\r\n";
        }
        private void progressBar_Difesa_Mura_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text =
                $"Difesa Mura: {Variabili.Città.Mura.Difesa}/{Variabili.Città.Mura.DifesaMax}\r\n" +
                $"\r\nCosto Riparazioni:\r\n" +
                $"Cibo:   {1 * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa)}\r\n" +
                $"Legno:  {2 * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa)}\r\n" +
                $"Pietra: {3 * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa)}\r\n" +
                $"Ferro:  {4 * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa)}\r\n" +
                $"Oro:    {5 * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa)}\r\n" +
                $"Per ripristinare le difese delle mura, premere sulla barra della difesa\r\n";
        }

        private void progressBar_Guarnigione_Castello_MouseHover(object sender, EventArgs e)
        {
            int totale_Guerrireri = Variabili.Città.Castello.Guerrieri + Variabili.Città.Castello.Lancieri + Variabili.Città.Castello.Arceri + Variabili.Città.Castello.Catapulte;
            txt_Log.Text =
                $"Guarnigione Castello: {Variabili.Città.Castello.Guarnigione}/{Variabili.Città.Castello.Guarnigione}\r\n" +
                $"Guerrieri:    {Variabili.Città.Castello.Guerrieri}\r\n" +
                $"Lancieri:     {Variabili.Città.Castello.Lancieri}\r\n" +
                $"Arcieri:      {Variabili.Città.Castello.Arceri}\r\n" +
                $"Catapulte:    {Variabili.Città.Castello.Catapulte}\r\n";
        }
        private void progressBar_Guarnigione_Torre_MouseMove(object sender, MouseEventArgs e)
        {
            int totale_Guerrireri = Variabili.Città.Torre.Guerrieri + Variabili.Città.Torre.Lancieri + Variabili.Città.Torre.Arceri + Variabili.Città.Torre.Catapulte;
            txt_Log.Text =
                $"Guarnigione Torre: {totale_Guerrireri}/{Variabili.Città.Torre.DifesaMax}\r\n" +
                $"Guerrieri:    {Variabili.Città.Torre.Guerrieri}\r\n" +
                $"Lancieri:     {Variabili.Città.Torre.Lancieri}\r\n" +
                $"Arcieri:      {Variabili.Città.Torre.Arceri}\r\n" +
                $"Catapulte:    {Variabili.Città.Torre.Catapulte}\r\n";
        }
        private void progressBar_Guarnigione_Mura_MouseHover(object sender, EventArgs e)
        {
            int totale_Guerrireri = Variabili.Città.Mura.Guerrieri + Variabili.Città.Mura.Lancieri + Variabili.Città.Mura.Arceri + Variabili.Città.Mura.Catapulte;
            txt_Log.Text =
                $"Guarnigione Mura: {totale_Guerrireri}/{Variabili.Città.Mura.DifesaMax}\r\n" +
                $"Guerrieri:    {Variabili.Città.Mura.Guerrieri}\r\n" +
                $"Lancieri:     {Variabili.Città.Mura.Lancieri}\r\n" +
                $"Arcieri:      {Variabili.Città.Mura.Arceri}\r\n" +
                $"Catapulte:    {Variabili.Città.Mura.Catapulte}\r\n";
        }

        private void btn_Castello_Click(object sender, EventArgs e)
        {
            Variabili.form_Spostamento_truppe = "Castello";
            Esercito_Form esercito = new Esercito_Form();
            esercito.ShowDialog();
        }
        private void btn_Torre_Click(object sender, EventArgs e)
        {
            Variabili.form_Spostamento_truppe = "Torre";
            Esercito_Form esercito = new Esercito_Form();
            esercito.ShowDialog();
        }
        private void btn_Mura_Click(object sender, EventArgs e)
        {
            Variabili.form_Spostamento_truppe = "Mura";
            Esercito_Form esercito = new Esercito_Form();
            esercito.ShowDialog();
        }
    }
}
