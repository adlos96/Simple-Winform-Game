using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static rts_2D.Variabili;

namespace rts_2D
{
    public partial class Form1 : Form
    {
        int tokenCostruzione = 0;
        int tokenReclutamento = 0;
        int tokenRiparazione = 0;
        public static int Invasione_Ondata = 0;
        static bool pausa = false;
        static bool avvio = false;

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
                $"Cibo:         {Variabili.CostoReclutamento.Guerriero.Cibo}       Salute:  {Variabili.Esercito.Guerriero.Salute}\r\n" +
                $"Legno:        {Variabili.CostoReclutamento.Guerriero.Legno}      Attacco: {Variabili.Esercito.Guerriero.Attacco}\r\n" +
                $"Pietra:       {Variabili.CostoReclutamento.Guerriero.Pietra}     Difesa:  {Variabili.Esercito.Guerriero.Difesa}\r\n" +
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
                $"Cibo:         {Variabili.CostoReclutamento.Lanciere.Cibo}         Salute:  {Variabili.Esercito.Lanciere.Salute}\r\n" +
                $"Legno:        {Variabili.CostoReclutamento.Lanciere.Legno}        Attacco: {Variabili.Esercito.Lanciere.Attacco}\r\n" +
                $"Pietra:       {Variabili.CostoReclutamento.Lanciere.Pietra}       Difesa:  {Variabili.Esercito.Lanciere.Difesa}\r\n" +
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
                $"Cibo:         {Variabili.CostoReclutamento.Arciere.Cibo}          Salute:  {Variabili.Esercito.Arciere.Salute}\r\n" +
                $"Legno:        {Variabili.CostoReclutamento.Arciere.Legno}         Attacco: {Variabili.Esercito.Arciere.Attacco}\r\n" +
                $"Pietra:       {Variabili.CostoReclutamento.Arciere.Pietra}        Difesa:  {Variabili.Esercito.Arciere.Difesa}\r\n" +
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
                $"Cibo:         {Variabili.CostoReclutamento.Catapulta.Cibo}            Salute:  {Variabili.Esercito.Catapulta.Salute}\r\n" +
                $"Legno:        {Variabili.CostoReclutamento.Catapulta.Legno}           Attacco: {Variabili.Esercito.Catapulta.Attacco}\r\n" +
                $"Pietra:       {Variabili.CostoReclutamento.Catapulta.Pietra}          Difesa:  {Variabili.Esercito.Catapulta.Difesa}\r\n" +
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
            }
            else if (Guerriero > 0)
            {
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
                Variabili.Popolazione -= Variabili.CostoReclutamento.Lanciere.Popolazione * Lanciere;
                Variabili.Coda.Lanciere.quantità += (int)Lanciere;
            }
            else if (Lanciere > 0)
            {
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
                Variabili.Popolazione -= Variabili.CostoReclutamento.Arciere.Popolazione * Arciere;
                Variabili.Coda.Arciere.quantità += (int)Arciere;
            }
            else if (Arciere > 0)
            {
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
                Variabili.Popolazione -= Variabili.CostoReclutamento.Catapulta.Popolazione * Catapulta;
                Variabili.Coda.Catapulta.quantità += (int)Catapulta;
            }
            else if (Catapulta > 0)
            {
                txt_Cose.Text = "Reclutamento Catapulta fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                Catapulta = 0;
            }

            if (tokenReclutamento == 0)
            {
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
            comboBox_Effetto_Abilità.Text = "Seleziona abilità";
            comboBox_Effetto_Abilità.Items.Add("Rinforzo Esercito");
            comboBox_Effetto_Abilità.Items.Add("Rinforzo Città");
            comboBox_Effetto_Abilità.Items.Add("Guerrieri");
            comboBox_Effetto_Abilità.Items.Add("Lancieri");
            comboBox_Effetto_Abilità.Items.Add("Arcieri");
            comboBox_Effetto_Abilità.Items.Add("Popolani");

            Blocco_Costruzione.Visible = true;
            Blocco_Produzione.Visible = true;
            Blocco_Reclutamento.Visible = true;
            Blocco_Strutture_Esercito.Visible = true;
            Blocco_Abilità.Visible = true;
            Blocco_Risorse.Visible = true;
            Blocco_Invasioni.Visible = true;

            btn_Invasioni.Visible = true;
            btn_Ricerca.Visible = true;
            btn_Start.Visible = false;
            lbl_Tempo.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            Txt_Log_Battaglie.Visible = true;
            txt_Cose.Visible = true;
            btn_Pausa.Visible = true;
            avvio = true;
        }
        
        async Task Loop()
        {
            int i = 4;
            if (avvio == false)
            {
                Variabili.Cibo = 4800;
                Variabili.Legno = 4600;
                Variabili.Pietra = 4500;
                Variabili.Ferro = 4500;
                Variabili.Oro = 5400;
                Variabili.Popolazione = 15;

                //Città - Salute
                progressBar_Salute_Castello.Minimum = 0;
                progressBar_Salute_Torre.Minimum = 0;
                progressBar_Salute_Mura.Minimum = 0;
                progressBar_Salute_Castello.Maximum = Variabili.Città.Castello.SaluteMax;
                progressBar_Salute_Torre.Maximum = Variabili.Città.Torre.SaluteMax;
                progressBar_Salute_Mura.Maximum = Variabili.Città.Mura.SaluteMax;

                //Città - Difesa
                progressBar_Difesa_Castello.Minimum = 0;
                progressBar_Difesa_Torre.Minimum = 0;
                progressBar_Difesa_Mura.Minimum = 0;
                progressBar_Difesa_Castello.Maximum = Variabili.Città.Castello.DifesaMax;
                progressBar_Difesa_Torre.Maximum = Variabili.Città.Torre.DifesaMax;
                progressBar_Difesa_Mura.Maximum = Variabili.Città.Mura.DifesaMax;

                //Città - Guarnigione
                progressBar_Guarnigione_Castello.Minimum = 0;
                progressBar_Guarnigione_Torre.Minimum = 0;
                progressBar_Guarnigione_Mura.Minimum = 0;
                progressBar_Guarnigione_Castello.Maximum = Variabili.Città.Castello.Guarnigione;
                progressBar_Guarnigione_Torre.Maximum = Variabili.Città.Torre.Guarnigione;
                progressBar_Guarnigione_Mura.Maximum = Variabili.Città.Mura.Guarnigione;
            }

            while (true)
            {
                if (i == 4)
                {
                    Console.WriteLine("Update Loop");
                    if (await Pausa() == true) return;
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
                    i = 0;
                    await Load_Gui_Info();
                    await Load_Gui_Città();
                }
                i++;

                Thread.Sleep(250);
            }
        }
        async Task Costruzione()
        {
            int Fattoria = 0;
            int Segheria = 0;
            int CavaPietra = 0;
            int MinieraFerro = 0;
            int MinieraOro = 0;
            int tempo = 0;

            while (true)
            {
                if (await Pausa() == true) return;
                tempo = Fattoria + Segheria + CavaPietra + MinieraFerro + MinieraOro;
                if (Variabili.tempo_Costruzione > 0)
                {
                    if (Variabili.Coda.Fattoria.quantità > 0)
                    {
                        Fattoria++;
                        Variabili.tempo_Costruzione--;

                        if (Fattoria >= Variabili.CostoCostruzione.Fattoria.TempoCostruzione)
                        {
                            Variabili.fattoria++;
                            txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Costruzione Fattoria completata!\r\n" + txt_Cose.Text));
                            Variabili.Coda.Fattoria.quantità--;
                            Fattoria = 0;
                        }
                    }
                    if (Variabili.Coda.Segheria.quantità > 0)
                    {
                        Segheria++;
                        Variabili.tempo_Costruzione--;

                        if (Segheria >= Variabili.CostoCostruzione.Segheria.TempoCostruzione)
                        {
                            Variabili.segheria++;
                            txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Costruzione Segheria completata!\r\n" + txt_Cose.Text));
                            Variabili.Coda.Segheria.quantità--;
                            Segheria = 0;
                        }
                    }
                    if (Variabili.Coda.CavaPietra.quantità > 0)
                    {
                        CavaPietra++;
                        Variabili.tempo_Costruzione--;

                        if (CavaPietra >= Variabili.CostoCostruzione.CavaPietra.TempoCostruzione)
                        {
                            Variabili.cava_Pietra++;
                            txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Costruzione Cava di Pietra completata!\r\n" + txt_Cose.Text));
                            Variabili.Coda.CavaPietra.quantità--;
                            CavaPietra = 0;
                        }
                    }
                    if (Variabili.Coda.MinieraFerro.quantità > 0)
                    {
                        MinieraFerro++;
                        Variabili.tempo_Costruzione--;

                        if (MinieraFerro >= Variabili.CostoCostruzione.MinieraFerro.TempoCostruzione)
                        {
                            Variabili.miniera_Ferro++;
                            txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Costruzione Miniera di Ferro completata!\r\n" + txt_Cose.Text));
                            Variabili.Coda.MinieraFerro.quantità--;
                            MinieraFerro = 0;
                        }
                    }
                    if (Variabili.Coda.MinieraOro.quantità > 0)
                    {
                        MinieraOro++;
                        Variabili.tempo_Costruzione--;

                        if (MinieraOro >= Variabili.CostoCostruzione.MinieraOro.TempoCostruzione)
                        {
                            Variabili.miniera_Oro++;
                            txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Costruzione Miniera d'Oro completata!\r\n" + txt_Cose.Text));
                            Variabili.Coda.MinieraOro.quantità--;
                            MinieraOro = 0;
                        }
                    }

                    if (Variabili.Coda.Fattoria.quantità + Variabili.Coda.Segheria.quantità + Variabili.Coda.CavaPietra.quantità + Variabili.Coda.MinieraFerro.quantità + Variabili.Coda.MinieraOro.quantità == 0)
                        Variabili.tempo_Costruzione = 0;
                }
                Thread.Sleep(1000);

                Variabili.tempo_Costruzione =
                    (int)((Variabili.Coda.Fattoria.quantità * Variabili.CostoCostruzione.Fattoria.TempoCostruzione) +
                    (Variabili.Coda.Segheria.quantità * Variabili.CostoCostruzione.Segheria.TempoCostruzione) +
                    (Variabili.Coda.CavaPietra.quantità * Variabili.CostoCostruzione.CavaPietra.TempoCostruzione) +
                    (Variabili.Coda.MinieraFerro.quantità * Variabili.CostoCostruzione.MinieraFerro.TempoCostruzione) +
                    (Variabili.Coda.MinieraOro.quantità * Variabili.CostoCostruzione.MinieraOro.TempoCostruzione) - tempo);
            }
        }
        async Task Reclutamento()
        {
            int Guerriero = 0;
            int Lanciere = 0;
            int Arciere = 0;
            int Catapulta = 0;
            int tempo = 0;
            while (true)
            {
                if (await Pausa() == true) return;
                tempo = Guerriero + Lanciere + Arciere + Catapulta;
                if (Variabili.tempo_Reclutamento > 0)
                {
                    if (Variabili.Coda.Guerriero.quantità > 0)
                    {
                        Guerriero++;
                        Variabili.tempo_Reclutamento--;

                        if (Guerriero >= Variabili.CostoReclutamento.Guerriero.TempoReclutamento)
                        {
                            Variabili.Esercito.Guerriero.Quantità++;
                            txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Reclutamento Guerrirero\r\n" + txt_Cose.Text));
                            Variabili.Coda.Guerriero.quantità--;
                            Guerriero = 0;
                        }
                    }
                    if (Variabili.Coda.Lanciere.quantità > 0)
                    {
                        Lanciere++;
                        Variabili.tempo_Reclutamento--;

                        if (Lanciere >= Variabili.CostoReclutamento.Lanciere.TempoReclutamento)
                        {
                            Variabili.Esercito.Lanciere.Quantità++;
                            txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Reclutamento Lanciere\r\n" + txt_Cose.Text));
                            Variabili.Coda.Lanciere.quantità--;
                            Lanciere = 0;
                        }
                    }
                    if (Variabili.Coda.Arciere.quantità > 0)
                    {
                        Arciere++;
                        Variabili.tempo_Reclutamento--;

                        if (Arciere >= Variabili.CostoReclutamento.Arciere.TempoReclutamento)
                        {
                            Variabili.Esercito.Arciere.Quantità++;
                            txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Reclutamento Arciere\r\n" + txt_Cose.Text));
                            Variabili.Coda.Arciere.quantità--;
                            Arciere = 0;
                        }
                    }
                    if (Variabili.Coda.Catapulta.quantità > 0)
                    {
                        Catapulta++;
                        Variabili.tempo_Reclutamento--;

                        if (Catapulta >= Variabili.CostoReclutamento.Catapulta.TempoReclutamento)
                        {
                            Variabili.Esercito.Catapulta.Quantità++;
                            txt_Cibo.Invoke((Action)(() => txt_Cose.Text = "Reclutamento Catapulta\r\n" + txt_Cose.Text));
                            Variabili.Coda.Catapulta.quantità--;
                            Catapulta = 0;
                        }
                    }
                    if (Variabili.Coda.Guerriero.quantità + Variabili.Coda.Lanciere.quantità + Variabili.Coda.Arciere.quantità + Variabili.Coda.Catapulta.quantità == 0)
                        Variabili.tempo_Costruzione = 0;
                }
                Thread.Sleep(1000);

                Variabili.tempo_Reclutamento =
                    (int)((Variabili.Coda.Guerriero.quantità * Variabili.CostoReclutamento.Guerriero.TempoReclutamento) +
                    (Variabili.Coda.Lanciere.quantità * Variabili.CostoReclutamento.Lanciere.TempoReclutamento) +
                    (Variabili.Coda.Arciere.quantità * Variabili.CostoReclutamento.Arciere.TempoReclutamento) +
                    (Variabili.Coda.Catapulta.quantità * Variabili.CostoReclutamento.Catapulta.TempoReclutamento) - tempo);
            }
        }
        async void Loop_Invasione()
        {
            int guerriero = 0, lanciere = 0, arciere = 0, catapulta = 0, i = 0, a = 0;
            int respawn = 0;

            Variabili.EsercitoNemico.Guerriero.Quantità += 14;
            Variabili.EsercitoNemico.Lanciere.Quantità += 8;
            Variabili.EsercitoNemico.Arciere.Quantità += 6;
            Variabili.EsercitoNemico.Catapulta.Quantità += 1;

            while (true)
            {
                if (await Pausa() == true) return;

                if (Invasione_Ondata > 7 && guerriero >= Variabili.EsercitoNemico.Guerriero.TempoReclutamento - 3) Variabili.EsercitoNemico.Guerriero.Quantità += 1;
                if (Invasione_Ondata > 10 && lanciere >= Variabili.EsercitoNemico.Lanciere.TempoReclutamento - 3) Variabili.EsercitoNemico.Lanciere.Quantità += 1;
                if (Invasione_Ondata > 18 && arciere >= Variabili.EsercitoNemico.Arciere.TempoReclutamento - 3) Variabili.EsercitoNemico.Arciere.Quantità += 1;
                if (Invasione_Ondata > 25 && catapulta >= Variabili.EsercitoNemico.Catapulta.TempoReclutamento - 3) Variabili.EsercitoNemico.Catapulta.Quantità += 1;

                if (guerriero >= Variabili.EsercitoNemico.Guerriero.TempoReclutamento)
                {
                    Variabili.EsercitoNemico.Guerriero.Quantità++;
                    guerriero = 0;
                }
                if (lanciere >= Variabili.EsercitoNemico.Lanciere.TempoReclutamento && Invasione_Ondata >= 8)
                {
                    Variabili.EsercitoNemico.Lanciere.Quantità++;
                    lanciere = 0;
                }
                if (arciere >= Variabili.EsercitoNemico.Arciere.TempoReclutamento && Invasione_Ondata >= 16)
                {
                    Variabili.EsercitoNemico.Arciere.Quantità++;
                    arciere = 0;
                }
                if (catapulta >= Variabili.EsercitoNemico.Catapulta.TempoReclutamento && Invasione_Ondata >= 23)
                {
                    Variabili.EsercitoNemico.Catapulta.Quantità++;
                    catapulta = 0;
                }

                Variabili.forza_Esercito_Att =
                    Variabili.EsercitoNemico.Guerriero.Quantità * ((Variabili.EsercitoNemico.Guerriero.Salute * 0.33) + (Variabili.EsercitoNemico.Guerriero.Attacco * 0.72)) +
                    Variabili.EsercitoNemico.Lanciere.Quantità * ((Variabili.EsercitoNemico.Lanciere.Salute * 0.33) + (Variabili.EsercitoNemico.Lanciere.Attacco * 0.72)) +
                    Variabili.EsercitoNemico.Arciere.Quantità * ((Variabili.EsercitoNemico.Arciere.Salute * 0.33) + (Variabili.EsercitoNemico.Arciere.Attacco * 0.72)) +
                    Variabili.EsercitoNemico.Catapulta.Quantità * ((Variabili.EsercitoNemico.Catapulta.Salute * 0.33) + (Variabili.EsercitoNemico.Catapulta.Attacco * 0.72));

                if (Variabili.timer_Invasione == 0)
                {
                    await Battle.Battaglia();
                    Invasione_Ondata++;
                    Variabili.timer_Invasione = Variabili.timer_Invasione_Set + (17 * Invasione_Ondata);
                    respawn = 0;
                }
                if (Invasione_Ondata > 5 && respawn == 19)
                {
                    Variabili.EsercitoNemico.Guerriero.Quantità += 1;
                    Variabili.EsercitoNemico.Lanciere.Quantità += 1;
                }

                if (a >= 300)
                {
                    Variabili.token++;
                    a = 0;
                }

                txt_Cibo.Invoke((Action)(async () => { Invasione(); }));
                Variabili.timer_Invasione--;

                Thread.Sleep(1000);
                guerriero++;
                lanciere++;
                arciere++;
                catapulta++;
                respawn++;
                a++;
                Console.WriteLine("Token timer: " + a);
                Console.WriteLine("Token " + Variabili.token);
            }
        }
        async Task Loop_Riparazione()
        {
            while (true)
            {
                if (await Pausa() == true) return;
                if (Variabili.Città.Mura.Salute < Variabili.Città.Mura.SaluteMax && Variabili.Riparazioni.Stato.Mura_Salute > 0)
                {
                    Variabili.Città.Mura.Salute += Variabili.Riparazioni.Valore.Riparazione;
                    if (Variabili.Città.Mura.Salute > Variabili.Città.Mura.SaluteMax)
                    {

                        Variabili.Città.Mura.Salute = Variabili.Città.Mura.SaluteMax;
                        Variabili.Riparazioni.Stato.Mura_Salute = 0;
                    }
                }
                if (Variabili.Città.Mura.Salute < Variabili.Città.Mura.SaluteMax && Variabili.Riparazioni.Stato.Mura_Difesa > 0)
                {
                    Variabili.Città.Mura.Difesa += Variabili.Riparazioni.Valore.Riparazione;
                    if (Variabili.Città.Mura.Difesa > Variabili.Città.Mura.DifesaMax)
                    {
                        Variabili.Città.Mura.Difesa = Variabili.Città.Mura.DifesaMax;
                        Variabili.Riparazioni.Stato.Mura_Difesa = 0;
                    }
                }
                if (Variabili.Città.Torre.Salute < Variabili.Città.Torre.SaluteMax && Variabili.Riparazioni.Stato.Torre_Salute > 0)
                {
                    Variabili.Città.Torre.Salute += Variabili.Riparazioni.Valore.Riparazione;
                    if (Variabili.Città.Torre.Salute > Variabili.Città.Torre.SaluteMax)
                    {

                        Variabili.Città.Torre.Salute = Variabili.Città.Torre.SaluteMax;
                        Variabili.Riparazioni.Stato.Torre_Salute = 0;
                    }
                }
                if (Variabili.Città.Torre.Salute < Variabili.Città.Torre.SaluteMax && Variabili.Riparazioni.Stato.Torre_Difesa > 0)
                {
                    Variabili.Città.Torre.Difesa += Variabili.Riparazioni.Valore.Riparazione;
                    if (Variabili.Città.Torre.Difesa > Variabili.Città.Torre.DifesaMax)
                    {
                        Variabili.Città.Torre.Difesa = Variabili.Città.Torre.DifesaMax;
                        Variabili.Riparazioni.Stato.Torre_Difesa = 0;
                    }
                }

                if (Variabili.Città.Castello.Salute < Variabili.Città.Castello.SaluteMax && Variabili.Riparazioni.Stato.Castello_Salute > 0)
                {
                    Variabili.Città.Castello.Salute += Variabili.Riparazioni.Valore.Riparazione;
                    if (Variabili.Città.Castello.Salute > Variabili.Città.Castello.SaluteMax)
                    {

                        Variabili.Città.Castello.Salute = Variabili.Città.Castello.SaluteMax;
                        Variabili.Riparazioni.Stato.Castello_Salute = 0;
                    }
                }
                if (Variabili.Città.Castello.Salute < Variabili.Città.Castello.SaluteMax && Variabili.Riparazioni.Stato.Castello_Difesa > 0)
                {
                    Variabili.Città.Castello.Difesa += Variabili.Riparazioni.Valore.Riparazione;
                    if (Variabili.Città.Castello.Difesa > Variabili.Città.Castello.DifesaMax)
                    {
                        Variabili.Città.Castello.Difesa = Variabili.Città.Castello.DifesaMax;
                        Variabili.Riparazioni.Stato.Castello_Difesa = 0;
                    }
                }
                Thread.Sleep(1000);
            }

        }

        static async Task<bool> Pausa()
        {
            if (pausa == true) return true;
            return false;
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
        private async Task<double> Oro()
        {
            double oro = 0;

            oro += Variabili.Esercito.Guerriero.Quantità * Variabili.Esercito.Guerriero.Salario;
            oro += Variabili.Esercito.Lanciere.Quantità * Variabili.Esercito.Lanciere.Salario;
            oro += Variabili.Esercito.Arciere.Quantità * Variabili.Esercito.Arciere.Salario;
            oro += Variabili.Esercito.Catapulta.Quantità * Variabili.Esercito.Catapulta.Salario;

            return oro;
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
        static string ConvertSeconds(int totalSeconds)
        {
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;

            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }
        public async Task<bool> Load_Gui_Città()
        {
            txt_Cibo.Invoke((Action)(async () =>
            {

                if (Variabili.Città.Mura.Salute == 0 || Variabili.Città.Mura.Salute == Variabili.Città.Mura.SaluteMax)
                {
                    progressBar_Salute_Mura.SetState(1);
                    progressBar_Salute_Mura.Value = Variabili.Città.Mura.Salute;
                }
                if (Variabili.Città.Mura.Difesa == 0 || Variabili.Città.Mura.Difesa ==  Variabili.Città.Mura.DifesaMax)
                {
                    progressBar_Difesa_Mura.SetState(1);
                    progressBar_Difesa_Mura.Value = Variabili.Città.Mura.Difesa;
                }
                if (Variabili.Città.Torre.Salute == 0 || Variabili.Città.Torre.Salute == Variabili.Città.Torre.SaluteMax)
                {
                    progressBar_Salute_Torre.SetState(1);
                    progressBar_Salute_Torre.Value = Variabili.Città.Torre.Salute;
                }
                if (Variabili.Città.Torre.Difesa == 0 || Variabili.Città.Torre.Difesa == Variabili.Città.Torre.DifesaMax)
                {
                    progressBar_Difesa_Torre.SetState(1);
                    progressBar_Difesa_Torre.Value = Variabili.Città.Torre.Difesa;
                }
                if (Variabili.Città.Castello.Salute == 0 || Variabili.Città.Castello.Salute == Variabili.Città.Castello.SaluteMax)
                {
                    progressBar_Salute_Castello.SetState(1);
                    progressBar_Salute_Castello.Value = Variabili.Città.Castello.Salute;
                }
                if (Variabili.Città.Castello.Difesa == 0 || Variabili.Città.Castello.Difesa == Variabili.Città.Castello.DifesaMax)
                {
                    progressBar_Difesa_Castello.SetState(1);
                    progressBar_Difesa_Castello.Value = Variabili.Città.Castello.Difesa;
                }

                //Città - Salute
                progressBar_Salute_Castello.Maximum = Variabili.Città.Castello.SaluteMax;
                progressBar_Salute_Torre.Maximum = Variabili.Città.Torre.SaluteMax;
                progressBar_Salute_Mura.Maximum = Variabili.Città.Mura.SaluteMax;

                //Città - Difesa
                progressBar_Difesa_Castello.Maximum = Variabili.Città.Castello.DifesaMax;
                progressBar_Difesa_Torre.Maximum = Variabili.Città.Torre.DifesaMax;
                progressBar_Difesa_Mura.Maximum = Variabili.Città.Mura.DifesaMax;

                //Città - Guarnigione
                progressBar_Guarnigione_Castello.Maximum = Variabili.Città.Castello.Guarnigione;
                progressBar_Guarnigione_Torre.Maximum = Variabili.Città.Torre.Guarnigione;
                progressBar_Guarnigione_Mura.Maximum = Variabili.Città.Mura.Guarnigione;

                progressBar_Guarnigione_Castello.Maximum = Variabili.Città.Castello.Guarnigione;
                progressBar_Guarnigione_Torre.Maximum = Variabili.Città.Torre.Guarnigione;
                progressBar_Guarnigione_Mura.Maximum = Variabili.Città.Mura.Guarnigione;

                //Città - Castello
                lbl_Salute_Castello.Text = Variabili.Città.Castello.Salute.ToString() + " HP";
                lbl_Difesa_Castello.Text = Variabili.Città.Castello.Difesa.ToString() + " DIF";
                lbl_Guarnigione_Castello.Text = (Variabili.Città.Castello.Guerrieri + Variabili.Città.Castello.Lancieri + Variabili.Città.Castello.Arceri + Variabili.Città.Castello.Catapulte).ToString() + "/" + Variabili.Città.Castello.Guarnigione;

                //Città - Torre
                lbl_Salute_Torre.Text = Variabili.Città.Torre.Salute.ToString() + " HP";
                lbl_Difesa_Torre.Text = Variabili.Città.Torre.Difesa.ToString() + " DIF";
                lbl_Guarnigione_Torre.Text = (Variabili.Città.Torre.Guerrieri + Variabili.Città.Torre.Lancieri + Variabili.Città.Torre.Arceri + Variabili.Città.Torre.Catapulte).ToString() + "/" + Variabili.Città.Torre.Guarnigione;

                //Città - Mura
                lbl_Salute_Mura.Text = Variabili.Città.Mura.Salute.ToString() + " HP";
                lbl_Difesa_Mura.Text = Variabili.Città.Mura.Difesa.ToString() + " DIF";
                lbl_Guarnigione_Mura.Text = (Variabili.Città.Mura.Guerrieri + Variabili.Città.Mura.Lancieri + Variabili.Città.Mura.Arceri + Variabili.Città.Mura.Catapulte).ToString() + "/" + Variabili.Città.Mura.Guarnigione;

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

            }));

            return true;
        }
        public async Task<bool> Load_Gui_Info()
        {
            if (txt_Cibo.InvokeRequired)
            {
                // Usa Invoke per eseguire le operazioni sul thread dell'UI
                txt_Cibo.Invoke((Action)(async () =>
                {
                    txt_Totale_Token_Abilità.Text = Variabili.token.ToString();
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

                    if (Variabili.Città.Castello.Salute == 0)
                    {
                        btn_Castello.Enabled = false;
                        Variabili.Riparazioni.Stato.Castello_Salute = 0;
                        Variabili.Riparazioni.Stato.Castello_Difesa = 0;
                        Variabili.Città.Castello.Salute = 0;
                        Variabili.Città.Castello.Difesa = 0;

                        Variabili.Città.Castello.Guerrieri = 0;
                        Variabili.Città.Castello.Lancieri = 0;
                        Variabili.Città.Castello.Arceri = 0;
                        Variabili.Città.Castello.Catapulte = 0;
                    }
                    if (Variabili.Città.Torre.Salute == 0)
                    {
                        Variabili.Riparazioni.Stato.Torre_Salute = 0;
                        Variabili.Riparazioni.Stato.Torre_Difesa = 0;
                        Variabili.Città.Torre.Salute = 0;
                        Variabili.Città.Torre.Difesa = 0;

                        btn_Torre.Enabled = false;
                        Variabili.Città.Torre.Guerrieri = 0;
                        Variabili.Città.Torre.Lancieri = 0;
                        Variabili.Città.Torre.Arceri = 0;
                        Variabili.Città.Torre.Catapulte = 0;
                    }
                    if (Variabili.Città.Mura.Salute == 0)
                    {
                        Variabili.Riparazioni.Stato.Mura_Salute = 0;
                        Variabili.Riparazioni.Stato.Mura_Difesa = 0;
                        Variabili.Città.Mura.Salute = 0;
                        Variabili.Città.Mura.Difesa = 0;

                        btn_Mura.Enabled = false;
                        Variabili.Città.Mura.Guerrieri = 0;
                        Variabili.Città.Mura.Lancieri = 0;
                        Variabili.Città.Mura.Arceri = 0;
                        Variabili.Città.Mura.Catapulte = 0;
                    }

                    lbl_Tempo.Text = "Tempo Trascorso: " + ConvertSeconds(tempo_Trascorso);
                }));
            }
            return true;
        }

        // btn Ricerche
        private void btn_Invasioni_Click(object sender, EventArgs e)
        {
            if (Variabili.Cibo >= Variabili.Ricerca.Sblocco_Invasioni.Cibo &&
                Variabili.Legno >= Variabili.Ricerca.Sblocco_Invasioni.Legno &&
                Variabili.Pietra >= Variabili.Ricerca.Sblocco_Invasioni.Pietra &&
                Variabili.Ferro >= Variabili.Ricerca.Sblocco_Invasioni.Ferro &&
                Variabili.Oro >= Variabili.Ricerca.Sblocco_Invasioni.Oro)
            {
                Variabili.Cibo -= Variabili.Ricerca.Sblocco_Invasioni.Cibo;
                Variabili.Legno -= Variabili.Ricerca.Sblocco_Invasioni.Legno;
                Variabili.Pietra -= Variabili.Ricerca.Sblocco_Invasioni.Pietra;
                Variabili.Ferro -= Variabili.Ricerca.Sblocco_Invasioni.Ferro;
                Variabili.Oro -= Variabili.Ricerca.Sblocco_Invasioni.Oro;

                btn_Invasioni.Enabled = false;
                btn_Invasioni.Visible = false;
                Blocco_Città.Visible = true;
                label26.Visible = true;
                txt_Timer_Invasione.Visible = true;
                txt_Numero_Ondata.Visible = true;

                Variabili.timer_Invasione = Variabili.timer_Invasione_Set;
                if (txt_Esercito_Invasore.Visible == false)
                    Task.Run(() => Loop_Invasione());
                txt_Esercito_Invasore.Visible = true;

            }
            else txt_Cose.Text = "Sblocco invasioni fallita, risorse insufficienti\r\n" + txt_Cose.Text;
        }
        private void btn_Ricerca_Click(object sender, EventArgs e)
        {
            if (Variabili.Cibo >= Variabili.Ricerca.Sblocco_Ricerca.Cibo &&
                Variabili.Legno >= Variabili.Ricerca.Sblocco_Ricerca.Legno &&
                Variabili.Pietra >= Variabili.Ricerca.Sblocco_Ricerca.Pietra &&
                Variabili.Ferro >= Variabili.Ricerca.Sblocco_Ricerca.Ferro &&
                Variabili.Oro >= Variabili.Ricerca.Sblocco_Ricerca.Oro)
            {
                Variabili.Cibo -= Variabili.Ricerca.Sblocco_Ricerca.Cibo;
                Variabili.Legno -= Variabili.Ricerca.Sblocco_Ricerca.Legno;
                Variabili.Pietra -= Variabili.Ricerca.Sblocco_Ricerca.Pietra;
                Variabili.Ferro -= Variabili.Ricerca.Sblocco_Ricerca.Ferro;
                Variabili.Oro -= Variabili.Ricerca.Sblocco_Ricerca.Oro;
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
                        Variabili.CostoCostruzione.Fattoria.Produzione += 0.23;
                        Variabili.CostoCostruzione.Segheria.Produzione += 0.21;
                        Variabili.CostoCostruzione.CavaPietra.Produzione += 0.19;
                        Variabili.CostoCostruzione.MinieraFerro.Produzione += 0.17;
                        Variabili.CostoCostruzione.MinieraOro.Produzione += 0.14;
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
                        Variabili.CostoCostruzione.Fattoria.Produzione += 0.24;
                        Variabili.CostoCostruzione.Segheria.Produzione += 0.22;
                        Variabili.CostoCostruzione.CavaPietra.Produzione += 0.20;
                        Variabili.CostoCostruzione.MinieraFerro.Produzione += 0.18;
                        Variabili.CostoCostruzione.MinieraOro.Produzione += 0.16;
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
                        Variabili.CostoCostruzione.Fattoria.Produzione += 0.26;
                        Variabili.CostoCostruzione.Segheria.Produzione += 0.24;
                        Variabili.CostoCostruzione.CavaPietra.Produzione += 0.21;
                        Variabili.CostoCostruzione.MinieraFerro.Produzione += 0.20;
                        Variabili.CostoCostruzione.MinieraOro.Produzione += 0.17;
                    }
                    else txt_Cose.Text = "Ricerca Produzione III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Produzione IV":
                    if (Variabili.Cibo >= Variabili.Ricerca.Produzione_IV.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Produzione_IV.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Produzione_IV.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Produzione_IV.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Produzione_IV.Oro &&
                        btn_Risorse_Produzione.Text == "Produzione IV")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Produzione_IV.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Produzione_IV.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Produzione_IV.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Produzione_IV.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Produzione_IV.Oro;

                        btn_Risorse_Produzione.Text = "Produzione V";
                        Variabili.CostoCostruzione.Fattoria.Produzione += 0.29;
                        Variabili.CostoCostruzione.Segheria.Produzione += 0.27;
                        Variabili.CostoCostruzione.CavaPietra.Produzione += 0.24;
                        Variabili.CostoCostruzione.MinieraFerro.Produzione += 0.23;
                        Variabili.CostoCostruzione.MinieraOro.Produzione += 0.20;
                    }
                    else txt_Cose.Text = "Ricerca Produzione IV fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Produzione V":
                    if (Variabili.Cibo >= Variabili.Ricerca.Produzione_V.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Produzione_V.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Produzione_V.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Produzione_V.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Produzione_V.Oro &&
                        btn_Risorse_Produzione.Text == "Produzione V")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Produzione_V.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Produzione_V.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Produzione_V.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Produzione_V.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Produzione_V.Oro;

                        btn_Risorse_Produzione.Text = "Produzione VI";
                        btn_Risorse_Produzione.Enabled = false;
                        Variabili.CostoCostruzione.Fattoria.Produzione += 0.33;
                        Variabili.CostoCostruzione.Segheria.Produzione += 0.31;
                        Variabili.CostoCostruzione.CavaPietra.Produzione += 0.28;
                        Variabili.CostoCostruzione.MinieraFerro.Produzione += 0.27;
                        Variabili.CostoCostruzione.MinieraOro.Produzione += 0.24;
                    }
                    else txt_Cose.Text = "Ricerca Produzione V fallita, risorse insufficienti\r\n" + txt_Cose.Text;
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
                        Variabili.CostoCostruzione.Fattoria.TempoCostruzione -= 3;
                        Variabili.CostoCostruzione.Segheria.TempoCostruzione -= 3;
                        Variabili.CostoCostruzione.CavaPietra.TempoCostruzione -= 3;
                        Variabili.CostoCostruzione.MinieraFerro.TempoCostruzione -= 3;
                        Variabili.CostoCostruzione.MinieraOro.TempoCostruzione -= 4;
                    }
                    else txt_Cose.Text = "Ricerca Costruzione III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;

                case "Costruzione IV":
                    if (Variabili.Cibo >= Variabili.Ricerca.Costruzione_IV.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Costruzione_IV.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Costruzione_IV.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Costruzione_IV.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Costruzione_IV.Oro &&
                        btn_Risorse_Costruzione.Text == "Costruzione IV")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Costruzione_IV.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Costruzione_IV.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Costruzione_IV.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Costruzione_IV.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Costruzione_IV.Oro;

                        btn_Risorse_Costruzione.Text = "Costruzione V";
                        Variabili.CostoCostruzione.Fattoria.TempoCostruzione -= 2;
                        Variabili.CostoCostruzione.Segheria.TempoCostruzione -= 2;
                        Variabili.CostoCostruzione.CavaPietra.TempoCostruzione -= 2;
                        Variabili.CostoCostruzione.MinieraFerro.TempoCostruzione -= 3;
                        Variabili.CostoCostruzione.MinieraOro.TempoCostruzione -= 4;
                    }
                    else txt_Cose.Text = "Ricerca Costruzione IV fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;

                case "Costruzione V":
                    if (Variabili.Cibo >= Variabili.Ricerca.Costruzione_V.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Costruzione_V.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Costruzione_V.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Costruzione_V.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Costruzione_V.Oro &&
                        btn_Risorse_Costruzione.Text == "Costruzione V")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Costruzione_V.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Costruzione_V.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Costruzione_V.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Costruzione_V.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Costruzione_V.Oro;

                        btn_Risorse_Costruzione.Text = "Costruzione VI";
                        btn_Risorse_Costruzione.Enabled = false;
                        Variabili.CostoCostruzione.Fattoria.TempoCostruzione -= 3;
                        Variabili.CostoCostruzione.Segheria.TempoCostruzione -= 3;
                        Variabili.CostoCostruzione.CavaPietra.TempoCostruzione -= 3;
                        Variabili.CostoCostruzione.MinieraFerro.TempoCostruzione -= 4;
                        Variabili.CostoCostruzione.MinieraOro.TempoCostruzione -= 6;
                    }
                    else txt_Cose.Text = "Ricerca Costruzione V fallita, risorse insufficienti\r\n" + txt_Cose.Text;
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
                        Variabili.Popolazione_Up += 0.11;
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
                        Variabili.Popolazione_Up += 0.16;
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
                        Variabili.Popolazione_Up += 0.21;
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
                        Variabili.CostoReclutamento.Guerriero.TempoReclutamento -= 3;
                        Variabili.CostoReclutamento.Lanciere.TempoReclutamento -= 3;
                        Variabili.CostoReclutamento.Arciere.TempoReclutamento -= 3;
                        Variabili.CostoReclutamento.Catapulta.TempoReclutamento -= 4;
                    }
                    else txt_Cose.Text = "Ricerca Reclutamento III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Reclutamento IV":
                    if (Variabili.Cibo >= Variabili.Ricerca.Reclutamento_IV.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Reclutamento_IV.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Reclutamento_IV.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Reclutamento_IV.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Reclutamento_IV.Oro &&
                        btn_Esercito_Reclutamento.Text == "Reclutamento IV")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Reclutamento_IV.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Reclutamento_IV.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Reclutamento_IV.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Reclutamento_IV.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Reclutamento_IV.Oro;

                        btn_Esercito_Reclutamento.Text = "Reclutamento V";
                        Variabili.CostoReclutamento.Guerriero.TempoReclutamento -= 4;
                        Variabili.CostoReclutamento.Lanciere.TempoReclutamento -= 4;
                        Variabili.CostoReclutamento.Arciere.TempoReclutamento -= 5;
                        Variabili.CostoReclutamento.Catapulta.TempoReclutamento -= 5;
                    }
                    else txt_Cose.Text = "Ricerca Reclutamento IV fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Reclutamento V":
                    if (Variabili.Cibo >= Variabili.Ricerca.Reclutamento_V.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Reclutamento_V.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Reclutamento_V.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Reclutamento_V.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Reclutamento_V.Oro &&
                        btn_Esercito_Reclutamento.Text == "Reclutamento V")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Reclutamento_V.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Reclutamento_V.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Reclutamento_V.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Reclutamento_V.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Reclutamento_V.Oro;

                        btn_Esercito_Reclutamento.Text = "Reclutamento VI";
                        btn_Esercito_Reclutamento.Enabled = false;
                        Variabili.CostoReclutamento.Guerriero.TempoReclutamento -= 4;
                        Variabili.CostoReclutamento.Lanciere.TempoReclutamento -= 5;
                        Variabili.CostoReclutamento.Arciere.TempoReclutamento -= 5;
                        Variabili.CostoReclutamento.Catapulta.TempoReclutamento -= 6;
                    }
                    else txt_Cose.Text = "Ricerca Reclutamento V fallita, risorse insufficienti\r\n" + txt_Cose.Text;
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
            switch (btn_Citta_Guarnigione.Text)
            {
                case "Guarnigione I":
                    if (Variabili.Cibo >= Variabili.Ricerca.Città_Guarnigione_I.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Città_Guarnigione_I.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Città_Guarnigione_I.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Città_Guarnigione_I.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Città_Guarnigione_I.Oro)
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Città_Guarnigione_I.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Città_Guarnigione_I.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Città_Guarnigione_I.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Città_Guarnigione_I.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Città_Guarnigione_I.Oro;

                        btn_Citta_Guarnigione.Text = "Guarnigione II";
                        Variabili.Città.Mura.Guarnigione = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Mura.Guarnigione) * 1.25);
                        Variabili.Città.Torre.Guarnigione = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Torre.Guarnigione) * 1.25);
                        Variabili.Città.Castello.Guarnigione = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Castello.Guarnigione) * 1.25);
                    }
                    else txt_Cose.Text = "Ricerca Guarnigione I (Città) fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Guarnigione II":
                    if (Variabili.Cibo >= Variabili.Ricerca.Città_Guarnigione_II.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Città_Guarnigione_II.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Città_Guarnigione_II.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Città_Guarnigione_II.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Città_Guarnigione_II.Oro &&
                        btn_Citta_Guarnigione.Text == "Guarnigione II")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Città_Guarnigione_II.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Città_Guarnigione_II.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Città_Guarnigione_II.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Città_Guarnigione_II.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Città_Guarnigione_II.Oro;

                        btn_Citta_Guarnigione.Text = "Guarnigione III";
                        Variabili.Città.Mura.Guarnigione = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Mura.Guarnigione) * 1.5);
                        Variabili.Città.Torre.Guarnigione = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Torre.Guarnigione) * 1.5);
                        Variabili.Città.Castello.Guarnigione = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Castello.Guarnigione) * 1.5);
                    }
                    else txt_Cose.Text = "Ricerca Guarnigione III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Guarnigione III":
                    if (Variabili.Cibo >= Variabili.Ricerca.Città_Guarnigione_III.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Città_Guarnigione_III.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Città_Guarnigione_III.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Città_Guarnigione_III.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Città_Guarnigione_III.Oro &&
                        btn_Citta_Guarnigione.Text == "Guarnigione III")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Città_Guarnigione_III.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Città_Guarnigione_III.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Città_Guarnigione_III.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Città_Guarnigione_III.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Città_Guarnigione_III.Oro;

                        btn_Citta_Guarnigione.Text = "Guarnigione IV";
                        btn_Citta_Guarnigione.Enabled = false;
                        Variabili.Città.Mura.Guarnigione = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Mura.Guarnigione) * 1.5);
                        Variabili.Città.Torre.Guarnigione = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Torre.Guarnigione) * 1.5);
                        Variabili.Città.Castello.Guarnigione = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Castello.Guarnigione) * 1.5);
                    }
                    else txt_Cose.Text = "Ricerca Guarnigione III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
            }
        }
        private void btn_Citta_Difesa_Click(object sender, EventArgs e)
        {
            switch (btn_Citta_Difesa.Text)
            {
                case "Difesa I":
                    if (Variabili.Cibo >= Variabili.Ricerca.Città_Difesa_I.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Città_Difesa_I.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Città_Difesa_I.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Città_Difesa_I.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Città_Difesa_I.Oro)
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Città_Difesa_I.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Città_Difesa_I.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Città_Difesa_I.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Città_Difesa_I.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Città_Difesa_I.Oro;

                        btn_Citta_Difesa.Text = "Difesa II";
                        Variabili.Città.Mura.DifesaMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Mura.DifesaMax) * 1.5);
                        Variabili.Città.Torre.DifesaMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Torre.DifesaMax) * 1.5);
                        Variabili.Città.Castello.DifesaMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Castello.DifesaMax) * 1.5);

                    }
                    else txt_Cose.Text = "Ricerca Difesa I (Città) fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Difesa II":
                    if (Variabili.Cibo >= Variabili.Ricerca.Città_Difesa_II.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Città_Difesa_II.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Città_Difesa_II.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Città_Difesa_II.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Città_Difesa_II.Oro &&
                        btn_Citta_Difesa.Text == "Difesa II")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Città_Difesa_II.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Città_Difesa_II.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Città_Difesa_II.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Città_Difesa_II.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Città_Difesa_II.Oro;

                        btn_Citta_Difesa.Text = "Difesa III";
                        Variabili.Città.Mura.DifesaMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Mura.DifesaMax) * 1.75);
                        Variabili.Città.Torre.DifesaMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Torre.DifesaMax) * 1.75);
                        Variabili.Città.Castello.DifesaMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Castello.DifesaMax) * 1.75);

                    }
                    else txt_Cose.Text = "Ricerca Difesa II fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Difesa III":
                    if (Variabili.Cibo >= Variabili.Ricerca.Città_Difesa_III.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Città_Difesa_III.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Città_Difesa_III.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Città_Difesa_III.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Città_Difesa_III.Oro &&
                        btn_Citta_Difesa.Text == "Difesa III")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Città_Difesa_III.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Città_Difesa_III.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Città_Difesa_III.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Città_Difesa_III.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Città_Difesa_III.Oro;

                        btn_Citta_Difesa.Text = "Difesa IV";
                        btn_Citta_Difesa.Enabled = false;
                        Variabili.Città.Mura.DifesaMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Mura.DifesaMax) * 1.75);
                        Variabili.Città.Torre.DifesaMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Torre.DifesaMax) * 1.75);
                        Variabili.Città.Castello.DifesaMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Castello.DifesaMax) * 1.75);
                    }
                    else txt_Cose.Text = "Ricerca Difesa III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
            }
        }
        private void btn_Citta_Salute_Click(object sender, EventArgs e)
        {
            switch (btn_Citta_Salute.Text)
            {
                case "Salute I":
                    if (Variabili.Cibo >= Variabili.Ricerca.Città_Salute_I.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Città_Salute_I.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Città_Salute_I.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Città_Salute_I.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Città_Salute_I.Oro)
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Città_Salute_I.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Città_Salute_I.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Città_Salute_I.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Città_Salute_I.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Città_Salute_I.Oro;

                        btn_Citta_Salute.Text = "Salute II";
                        Variabili.Città.Mura.SaluteMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Mura.SaluteMax) * 1.5);
                        Variabili.Città.Torre.SaluteMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Torre.SaluteMax) * 1.5);
                        Variabili.Città.Castello.SaluteMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Castello.SaluteMax) * 1.5);
                    }
                    else txt_Cose.Text = "Ricerca Salute I fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Salute II":
                    if (Variabili.Cibo >= Variabili.Ricerca.Città_Salute_II.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Città_Salute_II.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Città_Salute_II.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Città_Salute_II.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Città_Salute_II.Oro &&
                        btn_Citta_Salute.Text == "Salute II")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Città_Salute_II.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Città_Salute_II.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Città_Salute_II.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Città_Salute_II.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Città_Salute_II.Oro;

                        btn_Citta_Salute.Text = "Salute III";
                        Variabili.Città.Mura.SaluteMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Mura.SaluteMax) * 1.75);
                        Variabili.Città.Torre.SaluteMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Torre.SaluteMax) * 1.75);
                        Variabili.Città.Castello.SaluteMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Castello.SaluteMax) * 1.75);
                    }
                    else txt_Cose.Text = "Ricerca Salute III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Salute III":
                    if (Variabili.Cibo >= Variabili.Ricerca.Città_Salute_III.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Città_Salute_III.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Città_Salute_III.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Città_Salute_III.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Città_Salute_III.Oro &&
                        btn_Citta_Salute.Text == "Salute III")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Città_Salute_III.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Città_Salute_III.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Città_Salute_III.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Città_Salute_III.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Città_Salute_III.Oro;

                        btn_Citta_Salute.Text = "Salute IV";
                        btn_Citta_Salute.Enabled = false;

                        Variabili.Città.Mura.SaluteMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Mura.SaluteMax) * 1.75);
                        Variabili.Città.Torre.SaluteMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Torre.SaluteMax) * 1.75);
                        Variabili.Città.Castello.SaluteMax = Convert.ToInt32(Convert.ToDouble(Variabili.Città.Castello.SaluteMax) * 1.75);
                    }
                    else txt_Cose.Text = "Ricerca Salute III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
            }
        }
        private void btn_Citta_Riparazioni_Click(object sender, EventArgs e)
        {
            switch (btn_Citta_Riparazioni.Text)
            {
                case "Riparazione I":
                    if (Variabili.Cibo >= Variabili.Ricerca.Città_Riparazione_I.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Città_Riparazione_I.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Città_Riparazione_I.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Città_Riparazione_I.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Città_Riparazione_I.Oro)
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Città_Riparazione_I.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Città_Riparazione_I.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Città_Riparazione_I.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Città_Riparazione_I.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Città_Riparazione_I.Oro;

                        btn_Citta_Riparazioni.Text = "Riparazione II";
                        Variabili.Riparazioni.Valore.Riparazione += 1;
                    }
                    else txt_Cose.Text = "Ricerca Riparazione I fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Riparazione II":
                    if (Variabili.Cibo >= Variabili.Ricerca.Città_Riparazione_II.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Città_Riparazione_II.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Città_Riparazione_II.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Città_Riparazione_II.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Città_Riparazione_II.Oro &&
                        btn_Citta_Riparazioni.Text == "Riparazione II")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Città_Riparazione_II.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Città_Riparazione_II.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Città_Riparazione_II.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Città_Riparazione_II.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Città_Riparazione_II.Oro;

                        btn_Citta_Riparazioni.Text = "Riparazione III";
                        Variabili.Riparazioni.Valore.Riparazione += 1;
                    }
                    else txt_Cose.Text = "Ricerca Riparazione III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
                case "Riparazione III":
                    if (Variabili.Cibo >= Variabili.Ricerca.Città_Riparazione_III.Cibo &&
                        Variabili.Legno >= Variabili.Ricerca.Città_Riparazione_III.Legno &&
                        Variabili.Pietra >= Variabili.Ricerca.Città_Riparazione_III.Pietra &&
                        Variabili.Ferro >= Variabili.Ricerca.Città_Riparazione_III.Ferro &&
                        Variabili.Oro >= Variabili.Ricerca.Città_Riparazione_III.Oro &&
                        btn_Citta_Riparazioni.Text == "Riparazione III")
                    {
                        Variabili.Cibo -= Variabili.Ricerca.Città_Riparazione_III.Cibo;
                        Variabili.Legno -= Variabili.Ricerca.Città_Riparazione_III.Legno;
                        Variabili.Pietra -= Variabili.Ricerca.Città_Riparazione_III.Pietra;
                        Variabili.Ferro -= Variabili.Ricerca.Città_Riparazione_III.Ferro;
                        Variabili.Oro -= Variabili.Ricerca.Città_Riparazione_III.Oro;

                        btn_Citta_Riparazioni.Text = "Riparazione IV";
                        btn_Citta_Riparazioni.Enabled = false;
                        Variabili.Riparazioni.Valore.Riparazione += 1;
                    }
                    else txt_Cose.Text = "Ricerca Riparazione III fallita, risorse insufficienti\r\n" + txt_Cose.Text;
                    break;
            }
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

            if (btn_Risorse_Costruzione.Text == "Costruzione IV")
                txt_Log.Text = $"Costruzione IV\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Costruzione_IV.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Costruzione_IV.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Costruzione_IV.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Costruzione_IV.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Costruzione_IV.Oro}\r\n";

            if (btn_Risorse_Costruzione.Text == "Costruzione V")
                txt_Log.Text = $"Costruzione V\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Costruzione_V.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Costruzione_V.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Costruzione_V.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Costruzione_V.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Costruzione_V.Oro}\r\n";
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

            if (btn_Risorse_Produzione.Text == "Produzione IV")
                txt_Log.Text = $"Produzione IV\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Produzione_IV.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Produzione_IV.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Produzione_IV.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Produzione_IV.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Produzione_IV.Oro}\r\n";

            if (btn_Risorse_Produzione.Text == "Produzione V")
                txt_Log.Text = $"Produzione V\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Produzione_V.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Produzione_V.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Produzione_V.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Produzione_V.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Produzione_V.Oro}\r\n";
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
            if (btn_Esercito_Reclutamento.Text == "Reclutamento IV")
                txt_Log.Text = $"Reclutamento IV\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Reclutamento_IV.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Reclutamento_IV.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Reclutamento_IV.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Reclutamento_IV.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Reclutamento_IV.Oro}\r\n";
            if (btn_Esercito_Reclutamento.Text == "Reclutamento V")
                txt_Log.Text = $"Reclutamento V\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Reclutamento_V.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Reclutamento_V.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Reclutamento_V.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Reclutamento_V.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Reclutamento_V.Oro}\r\n";
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
            if (btn_Citta_Difesa.Text == "Difesa I")
                txt_Log.Text = $"Difesa I\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Città_Difesa_I.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Città_Difesa_I.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Città_Difesa_I.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Città_Difesa_I.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Città_Difesa_I.Oro}\r\n";

            if (btn_Citta_Difesa.Text == "Difesa II")
                txt_Log.Text = $"Difesa II\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Città_Difesa_II.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Città_Difesa_II.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Città_Difesa_II.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Città_Difesa_II.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Città_Difesa_II.Oro}\r\n";

            if (btn_Citta_Difesa.Text == "Difesa III")
                txt_Log.Text = $"Difesa III\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Città_Difesa_III.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Città_Difesa_III.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Città_Difesa_III.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Città_Difesa_III.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Città_Difesa_III.Oro}\r\n";
        }
        private void btn_Citta_Guarnigione_MouseHover(object sender, EventArgs e)
        {
            if (btn_Citta_Guarnigione.Text == "Difesa I")
                txt_Log.Text = $"Difesa I\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Città_Guarnigione_I.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Città_Guarnigione_I.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Città_Guarnigione_I.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Città_Guarnigione_I.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Città_Guarnigione_I.Oro}\r\n";

            if (btn_Citta_Guarnigione.Text == "Difesa II")
                txt_Log.Text = $"Difesa II\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Città_Guarnigione_II.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Città_Guarnigione_II.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Città_Guarnigione_II.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Città_Guarnigione_II.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Città_Guarnigione_II.Oro}\r\n";

            if (btn_Citta_Guarnigione.Text == "Difesa III")
                txt_Log.Text = $"Difesa III\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Città_Guarnigione_III.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Città_Guarnigione_III.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Città_Guarnigione_III.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Città_Guarnigione_III.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Città_Guarnigione_III.Oro}\r\n";
        }
        private void btn_Citta_Salute_MouseHover(object sender, EventArgs e)
        {
            if (btn_Citta_Salute.Text == "Difesa I")
                txt_Log.Text = $"Difesa I\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Città_Salute_I.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Città_Salute_I.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Città_Salute_I.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Città_Salute_I.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Città_Salute_I.Oro}\r\n";

            if (btn_Citta_Salute.Text == "Difesa II")
                txt_Log.Text = $"Difesa II\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Città_Salute_II.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Città_Salute_II.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Città_Salute_II.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Città_Salute_II.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Città_Salute_II.Oro}\r\n";

            if (btn_Citta_Salute.Text == "Difesa III")
                txt_Log.Text = $"Difesa III\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Città_Salute_III.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Città_Salute_III.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Città_Salute_III.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Città_Salute_III.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Città_Salute_III.Oro}\r\n";
        }
        private void btn_Citta_Riparazioni_MouseHover(object sender, EventArgs e)
        {
            if (btn_Citta_Riparazioni.Text == "Riparazione I")
                txt_Log.Text = $"Riparazione I\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Città_Riparazione_I.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Città_Riparazione_I.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Città_Riparazione_I.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Città_Riparazione_I.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Città_Riparazione_I.Oro}\r\n";

            if (btn_Citta_Riparazioni.Text == "Riparazione II")
                txt_Log.Text = $"Riparazione II\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Città_Riparazione_II.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Città_Riparazione_II.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Città_Riparazione_II.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Città_Riparazione_II.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Città_Riparazione_II.Oro}\r\n";

            if (btn_Citta_Riparazioni.Text == "Riparazione III")
                txt_Log.Text = $"Riparazione III\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Città_Riparazione_III.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Città_Riparazione_III.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Città_Riparazione_III.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Città_Riparazione_III.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Città_Riparazione_III.Oro}\r\n";
        }


        public static void Log_Battaglia(string messaggio)
        {
            _ = log_Battaglia.Invoke((Action)(() => log_Battaglia.Text = $"{messaggio}\r\n" + log_Battaglia.Text));
        }
        public static void Log(string messaggio)
        {
            _ = log.Invoke((Action)(() => log.Text = $"{messaggio}\r\n" + log.Text));
        }

        // Stato e costro riparazione strutture città
        private void progressBar_Salute_Castello_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text =
                $"Salute Castello: {Variabili.Città.Castello.Salute}/{Variabili.Città.Castello.SaluteMax}\r\n" +
                $"\r\nCosto Riparazioni:\r\n" +
                $"Cibo:   {Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute)}\r\n" +
                $"Legno:  {Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute)}\r\n" +
                $"Pietra: {Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute)}\r\n" +
                $"Ferro:  {Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute)}\r\n" +
                $"Oro:    {Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute)}\r\n" +
                $"Per riparare il castello, premere sulla barra della salute\r\n";
        }
        private void progressBar_Salute_Torre_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text =
                $"Salute Torre: {Variabili.Città.Torre.Salute}/|{Variabili.Città.Torre.SaluteMax}\r\n" +
                $"\r\nCosto Riparazioni:\r\n" +
                $"Cibo:   {Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute)}\r\n" +
                $"Legno:  {Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute)}\r\n" +
                $"Pietra: {Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute)}\r\n" +
                $"Ferro:  {Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute)}\r\n" +
                $"Oro:    {Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute)}\r\n" +
                $"Per riparare la torre, premere sulla barra della salute\r\n";
        }
        private void progressBar_Salute_Mura_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text =
                $"Salute Mura: {Variabili.Città.Mura.Salute}/{Variabili.Città.Mura.SaluteMax}\r\n" +
                $"\r\nCosto Riparazioni:\r\n" +
                $"Cibo:   {Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute)}\r\n" +
                $"Legno:  {Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute)}\r\n" +
                $"Pietra: {Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute)}\r\n" +
                $"Ferro:  {Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute)}\r\n" +
                $"Oro:    {Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute)}\r\n" +
                $"Per riparare le mura, premere sulla barra della salute\r\n";
        }
        private void progressBar_Difesa_Castello_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text =
                $"Difesa Castello: {Variabili.Città.Castello.Difesa}/{Variabili.Città.Castello.DifesaMax}\r\n" +
                $"\r\nCosto Riparazioni\r\n:" +
                $"Cibo:   {Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa)}\r\n" +
                $"Legno:  {Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa)}\r\n" +
                $"Pietra: {Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa)}\r\n" +
                $"Ferro:  {Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa)}\r\n" +
                $"Oro:    {Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa)}\r\n" +
                $"Per ripristinare le difese del castello, premere sulla barra della difesa\r\n";
        }
        private void progressBar_Difesa_Torre_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text =
                $"Difesa Torre: {Variabili.Città.Torre.Difesa}/{Variabili.Città.Torre.DifesaMax}\r\n" +
                $"\r\nCosto Riparazioni:\r\n" +
                $"Cibo:   {Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa)}\r\n" +
                $"Legno:  {Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa)}\r\n" +
                $"Pietra: {Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa)}\r\n" +
                $"Ferro:  {Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa)}\r\n" +
                $"Oro:    {Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa)}\r\n" +
                $"Per ripristinare le difese della torre, premere sulla barra della difesa\r\n";
        }
        private void progressBar_Difesa_Mura_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text =
                $"Difesa Mura: {Variabili.Città.Mura.Difesa}/{Variabili.Città.Mura.DifesaMax}\r\n" +
                $"\r\nCosto Riparazioni:\r\n" +
                $"Cibo:   {Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa)}\r\n" +
                $"Legno:  {Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa)}\r\n" +
                $"Pietra: {Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa)}\r\n" +
                $"Ferro:  {Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa)}\r\n" +
                $"Oro:    {Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa)}\r\n" +
                $"Per ripristinare le difese delle mura, premere sulla barra della difesa\r\n";
        }
        private void progressBar_Guarnigione_Castello_MouseHover(object sender, EventArgs e)
        {
            int totale_Guerrireri = Variabili.Città.Castello.Guerrieri + Variabili.Città.Castello.Lancieri + Variabili.Città.Castello.Arceri + Variabili.Città.Castello.Catapulte;
            txt_Log.Text =
                $"Guarnigione Castello: {totale_Guerrireri}/{Variabili.Città.Castello.Guarnigione}\r\n" +
                $"Guerrieri:    {Variabili.Città.Castello.Guerrieri}\r\n" +
                $"Lancieri:     {Variabili.Città.Castello.Lancieri}\r\n" +
                $"Arcieri:      {Variabili.Città.Castello.Arceri}\r\n" +
                $"Catapulte:    {Variabili.Città.Castello.Catapulte}\r\n";
        }
        private void progressBar_Guarnigione_Torre_MouseMove(object sender, MouseEventArgs e)
        {
            int totale_Guerrireri = Variabili.Città.Torre.Guerrieri + Variabili.Città.Torre.Lancieri + Variabili.Città.Torre.Arceri + Variabili.Città.Torre.Catapulte;
            txt_Log.Text =
                $"Guarnigione Torre: {totale_Guerrireri}/{Variabili.Città.Torre.Guarnigione}\r\n" +
                $"Guerrieri:    {Variabili.Città.Torre.Guerrieri}\r\n" +
                $"Lancieri:     {Variabili.Città.Torre.Lancieri}\r\n" +
                $"Arcieri:      {Variabili.Città.Torre.Arceri}\r\n" +
                $"Catapulte:    {Variabili.Città.Torre.Catapulte}\r\n";
        }
        private void progressBar_Guarnigione_Mura_MouseHover(object sender, EventArgs e)
        {
            int totale_Guerrireri = Variabili.Città.Mura.Guerrieri + Variabili.Città.Mura.Lancieri + Variabili.Città.Mura.Arceri + Variabili.Città.Mura.Catapulte;
            txt_Log.Text =
                $"Guarnigione Mura: {totale_Guerrireri}/{Variabili.Città.Mura.Guarnigione}\r\n" +
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
        #region lbl click X1 X5 X0
        private void lbl_Fattoria_X1_Click(object sender, EventArgs e)
        {
            txt_Fattoria.Text = (Convert.ToInt32(txt_Fattoria.Text) + 1).ToString();
        }
        private void lbl_Fattoria_X5_Click(object sender, EventArgs e)
        {
            txt_Fattoria.Text = (Convert.ToInt32(txt_Fattoria.Text) + 5).ToString();
        }
        private void lbl_Fattoria_X0_Click(object sender, EventArgs e)
        {
            txt_Fattoria.Text = "0";
        }
        private void lbl_Segheria_X1_Click(object sender, EventArgs e)
        {
            txt_Segheria.Text = (Convert.ToInt32(txt_Segheria.Text) + 1).ToString();
        }
        private void lbl_Segheria_X5_Click(object sender, EventArgs e)
        {
            txt_Segheria.Text = (Convert.ToInt32(txt_Segheria.Text) + 5).ToString();
        }
        private void lbl_Segheria_X0_Click(object sender, EventArgs e)
        {
            txt_Segheria.Text = "0";
        }
        private void lbl_Cava_X1_Click(object sender, EventArgs e)
        {
            txt_Cava.Text = (Convert.ToInt32(txt_Cava.Text) + 1).ToString();
        }
        private void lbl_Cava_X5_Click(object sender, EventArgs e)
        {
            txt_Cava.Text = (Convert.ToInt32(txt_Cava.Text) + 5).ToString();
        }
        private void lbl_Cava_X0_Click(object sender, EventArgs e)
        {
            txt_Cava.Text = "0";
        }
        private void lbl_Miniera_Ferro_X1_Click(object sender, EventArgs e)
        {
            txt_Miniera_Ferro.Text = (Convert.ToInt32(txt_Miniera_Ferro.Text) + 1).ToString();
        }
        private void lbl_Miniera_Ferro_X5_Click(object sender, EventArgs e)
        {
            txt_Miniera_Ferro.Text = (Convert.ToInt32(txt_Miniera_Ferro.Text) + 5).ToString();
        }
        private void lbl_Miniera_Ferro_X0_Click(object sender, EventArgs e)
        {
            txt_Miniera_Ferro.Text = "0";
        }
        private void lbl_Miniera_Oro_X1_Click(object sender, EventArgs e)
        {
            txt_Miniera_Oro.Text = (Convert.ToInt32(txt_Miniera_Oro.Text) + 1).ToString();
        }
        private void lbl_Miniera_Oro_X5_Click(object sender, EventArgs e)
        {
            txt_Miniera_Oro.Text = (Convert.ToInt32(txt_Miniera_Oro.Text) + 5).ToString();
        }
        private void lbl_Miniera_Oro_X0_Click(object sender, EventArgs e)
        {
            txt_Miniera_Oro.Text = "0";
        }
        private void lbl_Guerriero_X1_Click(object sender, EventArgs e)
        {
            txt_Guerriero.Text = (Convert.ToInt32(txt_Guerriero.Text) + 1).ToString();
        }
        private void lbl_Guerriero_X5_Click(object sender, EventArgs e)
        {
            txt_Guerriero.Text = (Convert.ToInt32(txt_Guerriero.Text) + 5).ToString();
        }
        private void lbl_Guerriero_X0_Click(object sender, EventArgs e)
        {
            txt_Guerriero.Text = "0";
        }
        private void lbl_Lanciere_X1_Click(object sender, EventArgs e)
        {
            txt_Lancieri.Text = (Convert.ToInt32(txt_Lancieri.Text) + 1).ToString();
        }
        private void lbl_Lanciere_X5_Click(object sender, EventArgs e)
        {
            txt_Lancieri.Text = (Convert.ToInt32(txt_Lancieri.Text) + 5).ToString();
        }
        private void lbl_Lanciere_X0_Click(object sender, EventArgs e)
        {
            txt_Lancieri.Text = "0";
        }
        private void lbl_Arciere_X1_Click(object sender, EventArgs e)
        {
            txt_Arciere.Text = (Convert.ToInt32(txt_Arciere.Text) + 1).ToString();
        }
        private void lbl_Arciere_X5_Click(object sender, EventArgs e)
        {
            txt_Arciere.Text = (Convert.ToInt32(txt_Arciere.Text) + 5).ToString();
        }
        private void lbl_Arciere_X0_Click(object sender, EventArgs e)
        {
            txt_Arciere.Text = "0";
        }
        private void lbl_Catapulta_X1_Click(object sender, EventArgs e)
        {
            txt_Catapulta.Text = (Convert.ToInt32(txt_Catapulta.Text) + 1).ToString();
        }
        private void lbl_Catapulta_X5_Click(object sender, EventArgs e)
        {
            txt_Catapulta.Text = (Convert.ToInt32(txt_Catapulta.Text) + 5).ToString();
        }
        private void lbl_Catapulta_X0_Click(object sender, EventArgs e)
        {
            txt_Catapulta.Text = "0";
        }
        #endregion

        // Riparazione strutture città
        private void progressBar_Salute_Mura_Click(object sender, EventArgs e)
        {
            if (Variabili.Cibo >= Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute) &&
                Variabili.Legno >= Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute) &&
                Variabili.Pietra >= Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute) &&
                Variabili.Ferro >= Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute) &&
                Variabili.Oro >= Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute))
            {
                if (Variabili.Riparazioni.Stato.Mura_Salute > 0)
                    txt_Cose.Text = "Riparazione mura fallita, ripristino salute in corso...\r\n" + txt_Cose.Text;
                else
                {
                    Variabili.Cibo -= Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute);
                    Variabili.Legno -= Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute);
                    Variabili.Pietra -= Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute);
                    Variabili.Ferro -= Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute);
                    Variabili.Oro -= Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Mura.SaluteMax - Variabili.Città.Mura.Salute);

                    btn_Mura.Enabled = true;
                    Variabili.Riparazioni.Stato.Mura_Salute++;
                    if (tokenRiparazione == 0)
                    {
                        tokenRiparazione++;
                        _ = Task.Run(() => Loop_Riparazione());
                    }
                }
            }
            else txt_Cose.Text = "Riparazione salute mura fallito, risorse insufficienti\r\n" + txt_Cose.Text;
        }
        private void progressBar_Difesa_Mura_Click(object sender, EventArgs e)
        {
            if (Variabili.Cibo >= Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa) &&
                Variabili.Legno >= Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa) &&
                Variabili.Pietra >= Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa) &&
                Variabili.Ferro >= Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa) &&
                Variabili.Oro >= Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa))
            {
                if (Variabili.Riparazioni.Stato.Mura_Difesa > 0)
                    txt_Cose.Text = "Riparazione mura fallita, ripristino difesa in corso...\r\n" + txt_Cose.Text;
                else
                {
                    Variabili.Cibo -= Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa);
                    Variabili.Legno -= Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa);
                    Variabili.Pietra -= Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa);
                    Variabili.Ferro -= Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa);
                    Variabili.Oro -= Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Mura.DifesaMax - Variabili.Città.Mura.Difesa);

                    Variabili.Riparazioni.Stato.Mura_Difesa++;
                    if (tokenRiparazione == 0)
                    {
                        tokenRiparazione++;
                        _ = Task.Run(() => Loop_Riparazione());
                    }
                }
            }
            else txt_Cose.Text = "Riparazione difesa mura fallito, risorse insufficienti\r\n" + txt_Cose.Text;
        }
        private void progressBar_Salute_Torre_Click(object sender, EventArgs e)
        {
            if (Variabili.Cibo >= Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute) &&
                Variabili.Legno >= Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute) &&
                Variabili.Pietra >= Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute) &&
                Variabili.Ferro >= Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute) &&
                Variabili.Oro >= Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute))
            {
                if (Variabili.Riparazioni.Stato.Torre_Salute > 0)
                    txt_Cose.Text = "Riparazione torre fallita, ripristino salute in corso...\r\n" + txt_Cose.Text;
                else
                {
                    Variabili.Cibo -= Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute);
                    Variabili.Legno -= Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute);
                    Variabili.Pietra -= Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute);
                    Variabili.Ferro -= Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute);
                    Variabili.Oro -= Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Torre.SaluteMax - Variabili.Città.Torre.Salute);

                    btn_Torre.Enabled = true;
                    Variabili.Riparazioni.Stato.Torre_Salute++;
                    if (tokenRiparazione == 0)
                    {
                        tokenRiparazione++;
                        _ = Task.Run(() => Loop_Riparazione());
                    }
                }
            }
            else txt_Cose.Text = "Riparazione salute torre fallito, risorse insufficienti\r\n" + txt_Cose.Text;
        }
        private void progressBar_Difesa_Torre_Click(object sender, EventArgs e)
        {
            if (Variabili.Cibo >= Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa) &&
                Variabili.Legno >= Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa) &&
                Variabili.Pietra >= Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa) &&
                Variabili.Ferro >= Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa) &&
                Variabili.Oro >= Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa))
            {
                if (Variabili.Riparazioni.Stato.Torre_Difesa > 0)
                    txt_Cose.Text = "Riparazione torre fallita, ripristino difesa in corso...\r\n" + txt_Cose.Text;
                else
                {
                    Variabili.Cibo -= Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa);
                    Variabili.Legno -= Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa);
                    Variabili.Pietra -= Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa);
                    Variabili.Ferro -= Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa);
                    Variabili.Oro -= Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Torre.DifesaMax - Variabili.Città.Torre.Difesa);

                    Variabili.Riparazioni.Stato.Torre_Difesa++;
                    if (tokenRiparazione == 0)
                    {
                        tokenRiparazione++;
                        _ = Task.Run(() => Loop_Riparazione());
                    }
                }
            }
            else txt_Cose.Text = "Riparazione difesa torre fallito, risorse insufficienti\r\n" + txt_Cose.Text;
        }
        private void progressBar_Salute_Castello_Click(object sender, EventArgs e)
        {
            if (Variabili.Cibo >= Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute) &&
                Variabili.Legno >= Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute) &&
                Variabili.Pietra >= Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute) &&
                Variabili.Ferro >= Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute) &&
                Variabili.Oro >= Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute))
            {
                if (Variabili.Riparazioni.Stato.Castello_Salute > 0)
                    txt_Cose.Text = "Riparazione castello fallita, ripristino salute in corso...\r\n" + txt_Cose.Text;
                else
                {
                    Variabili.Cibo -= Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute);
                    Variabili.Legno -= Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute);
                    Variabili.Pietra -= Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute);
                    Variabili.Ferro -= Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute);
                    Variabili.Oro -= Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Castello.SaluteMax - Variabili.Città.Castello.Salute);

                    btn_Castello.Enabled = true;
                    Variabili.Riparazioni.Stato.Castello_Salute++;
                    if (tokenRiparazione == 0)
                    {
                        tokenRiparazione++;
                        _ = Task.Run(() => Loop_Riparazione());
                    }
                }
            }
            else txt_Cose.Text = "Riparazione salute castello fallito, risorse insufficienti\r\n" + txt_Cose.Text;
        }
        private void progressBar_Difesa_Castello_Click(object sender, EventArgs e)
        {
            if (Variabili.Cibo >= Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Torre.Difesa) &&
                Variabili.Legno >= Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Torre.Difesa) &&
                Variabili.Pietra >= Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Torre.Difesa) &&
                Variabili.Ferro >= Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Torre.Difesa) &&
                Variabili.Oro >= Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Torre.Difesa))
            {
                if (Variabili.Riparazioni.Stato.Castello_Difesa > 0)
                    txt_Cose.Text = "Riparazione castello fallita, ripristino difesa in corso...\r\n" + txt_Cose.Text;
                else
                {
                    Variabili.Cibo -= Variabili.Riparazioni.Costo_Riparazioni.Cibo * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa);
                    Variabili.Legno -= Variabili.Riparazioni.Costo_Riparazioni.Legno * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa);
                    Variabili.Pietra -= Variabili.Riparazioni.Costo_Riparazioni.Pietra * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa);
                    Variabili.Ferro -= Variabili.Riparazioni.Costo_Riparazioni.Ferro * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa);
                    Variabili.Oro -= Variabili.Riparazioni.Costo_Riparazioni.Oro * (Variabili.Città.Castello.DifesaMax - Variabili.Città.Castello.Difesa);

                    Variabili.Riparazioni.Stato.Castello_Difesa++;
                    if (tokenRiparazione == 0)
                    {
                        tokenRiparazione++;
                        _ = Task.Run(() => Loop_Riparazione());
                    }
                }
            }
            else txt_Cose.Text = "Riparazione difesa castello fallito, risorse insufficienti\r\n" + txt_Cose.Text;
        }

        private void btn_Invasioni_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text = $"Sblocco Invasioni:\r\n" +
                    $"Cibo:   {Variabili.Ricerca.Sblocco_Invasioni.Cibo}\r\n" +
                    $"Legno:  {Variabili.Ricerca.Sblocco_Invasioni.Legno}\r\n" +
                    $"Pietra: {Variabili.Ricerca.Sblocco_Invasioni.Pietra}\r\n" +
                    $"Ferro:  {Variabili.Ricerca.Sblocco_Invasioni.Ferro}\r\n" +
                    $"Oro:    {Variabili.Ricerca.Sblocco_Invasioni.Oro}\r\n";
        }

        private void comboBox_Effetto_Abilità_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_Effetto_Abilità.SelectedItem)
            {
                case "Rinforzo Esercito":
                    txt_Descrizione_Abilità.Text = $"Un manipolo di soldati sul campo 110 Guerrieri 110 Lancieri 80 Arcieri 30 Catapulte | Costo: {Abilità.Rinforzo_Esercito.Costo_Token} Token";
                    break;                           
                case "Rinforzo Città":
                    txt_Descrizione_Abilità.Text = $"Aggiunge a tutte le strutture della città 80 Guerrieri 80 Lancieri 40 Arcieri 20 Catapulte | Costo: {Abilità.Rinforzo_Città.Costo_Token} Token";
                    break;
                case "Guerrieri":
                    txt_Descrizione_Abilità.Text = $"Aggiunge all'esercito sul campo 200 Guerrieri | Costo: {Abilità.Guerrieri.Costo_Token} Token";
                    break;
                case "Lancieri":
                    txt_Descrizione_Abilità.Text = $"Aggiunge all'esercito sul campo 170 Lancieri | Costo: {Abilità.Lancieri.Costo_Token} Token";
                    break;
                case "Arcieri":
                    txt_Descrizione_Abilità.Text = $"Aggiunge all'esercito sul campo 130 Arcieri | Costo: {Abilità.Arcieri.Costo_Token} Token";
                    break;
                case "Popolani":
                    txt_Descrizione_Abilità.Text = $"Richiama da terre lontane 400 popolani al tuo servizio | Costo: {Abilità.Popolani.Costo_Token} Token";
                    break;
            }
        }

        private void btn_Applica_Effetto_Abilità_Click(object sender, EventArgs e)
        {
            switch (comboBox_Effetto_Abilità.SelectedItem)
            {
                case "Rinforzo Esercito":
                    if (Variabili.token >= Variabili.Abilità.Rinforzo_Esercito.Costo_Token)
                    {
                        Variabili.token -= Variabili.Abilità.Rinforzo_Esercito.Costo_Token;
                        Variabili.Esercito.Guerriero.Quantità += 110;
                        Variabili.Esercito.Lanciere.Quantità += 110;
                        Variabili.Esercito.Arciere.Quantità += 80;
                        Variabili.Esercito.Catapulta.Quantità += 30;
                    }
                    break;
                case "Rinforzo Città":
                    if (Variabili.token >= Variabili.Abilità.Rinforzo_Città.Costo_Token)
                    {
                        Variabili.token -= Variabili.Abilità.Rinforzo_Città.Costo_Token;

                        Variabili.Città.Mura.Guerrieri += 90;
                        Variabili.Città.Mura.Lancieri += 65;
                        Variabili.Città.Mura.Arceri += 30;
                        Variabili.Città.Mura.Catapulte += 15;

                        Variabili.Città.Torre.Guerrieri += 90;
                        Variabili.Città.Torre.Lancieri += 65;
                        Variabili.Città.Torre.Arceri += 30;
                        Variabili.Città.Torre.Catapulte += 15;

                        Variabili.Città.Castello.Guerrieri += 90;
                        Variabili.Città.Castello.Lancieri += 65;
                        Variabili.Città.Castello.Arceri += 30;
                        Variabili.Città.Castello.Catapulte += 15;
                    }

                    break;
                case "Guerrieri":
                    if (Variabili.token >= Variabili.Abilità.Guerrieri.Costo_Token)
                    {
                        Variabili.token -= Variabili.Abilità.Guerrieri.Costo_Token;
                        Variabili.Esercito.Guerriero.Quantità += 200;
                    }
                    break;
                case "Lancieri":
                    if (Variabili.token >= Variabili.Abilità.Lancieri.Costo_Token)
                    {
                        Variabili.token -= Variabili.Abilità.Lancieri.Costo_Token;
                        Variabili.Esercito.Lanciere.Quantità += 170;
                    }
                    break;
                case "Arcieri":
                    if (Variabili.token >= Variabili.Abilità.Arcieri.Costo_Token)
                    {
                        Variabili.token -= Variabili.Abilità.Arcieri.Costo_Token;
                        Variabili.Esercito.Arciere.Quantità += 130;
                    }
                    break;
            }
        }

        private void btn_Pausa_Click(object sender, EventArgs e)
        {
            if (pausa == false)
                pausa = true;
            else if (pausa == true)
            {
                pausa = false;
                _ = Task.Run(() => Loop());
                _ = Task.Run(() => Reclutamento());
                _ = Task.Run(() => Costruzione());
                if (txt_Esercito_Invasore.Visible == true)
                {
                    _ = Task.Run(() => Loop_Invasione());
                    _ = Task.Run(() => Loop_Riparazione());
                }
            }
            Console.WriteLine($"Pausa: {pausa}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Creare un nuovo documento XML
            XDocument xmlDoc = new XDocument(
                new XElement("Gioco",
                    new XElement("Risorse",
                        new XElement("Risorsa",
                            new XAttribute("tipo", "Cibo"),
                            new XAttribute("quantita", Variabili.Cibo)),
                        new XElement("Risorsa",
                            new XAttribute("tipo", "Legna"),
                            new XAttribute("quantita", Variabili.Legno)),
                        new XElement("Risorsa",
                            new XAttribute("tipo", "Pietra"),
                            new XAttribute("quantita", Variabili.Pietra)),
                        new XElement("Risorsa",
                            new XAttribute("tipo", "Ferro"),
                            new XAttribute("quantita", Variabili.Ferro)),
                        new XElement("Risorsa",
                            new XAttribute("tipo", "Oro"),
                            new XAttribute("quantita", Variabili.Oro)),
                        new XElement("Risorsa",
                            new XAttribute("tipo", "Popolazione"),
                            new XAttribute("quantita", Variabili.Popolazione)),
                        new XElement("Risorsa",
                            new XAttribute("tipo", "Token"),
                            new XAttribute("quantita", Variabili.token)
                            ) 
                    ),

                    new XElement("Esercito",
                        new XElement("Unita",
                            new XAttribute("tipo", "Guerrieri"),
                            new XAttribute("quantita", Variabili.Esercito.Guerriero.Quantità)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Lancieri"),
                            new XAttribute("quantita", Variabili.Esercito.Lanciere.Quantità)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Arcieri"),
                            new XAttribute("quantita", Variabili.Esercito.Arciere.Quantità)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Catapulte"),
                            new XAttribute("quantita", Variabili.Esercito.Catapulta.Quantità) 
                            )
                    ),

                    new XElement("Strutture",
                        new XElement("Struttura",
                            new XAttribute("tipo", "Fattoria"),
                            new XAttribute("quantita", Variabili.fattoria)),
                        new XElement("Struttura",
                            new XAttribute("tipo", "Segheria"),
                            new XAttribute("quantita", Variabili.segheria)),
                        new XElement("Struttura",
                            new XAttribute("tipo", "Cava_Pietra"),
                            new XAttribute("quantita", Variabili.cava_Pietra)),
                        new XElement("Struttura",
                            new XAttribute("tipo", "Miniera_Ferro"),
                            new XAttribute("quantita", Variabili.miniera_Ferro)),
                        new XElement("Struttura",
                            new XAttribute("tipo", "Miniera_Oro"),
                            new XAttribute("quantita", Variabili.miniera_Oro)
                            )
                    ),

                    new XElement("Esercito_Reclutamento",
                        new XElement("Unita",
                            new XAttribute("tipo", "Guerrieri"),
                            new XAttribute("quantita", Variabili.Coda.Guerriero.quantità)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Lancieri"),
                            new XAttribute("quantita", Variabili.Coda.Lanciere.quantità)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Arcieri"),
                            new XAttribute("quantita", Variabili.Coda.Arciere.quantità)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Catapulte"),
                            new XAttribute("quantita", Variabili.Coda.Catapulta.quantità)
                            )
                    ),

                    new XElement("Strutture_Costruzione",
                        new XElement("Struttura",
                            new XAttribute("tipo", "Fattoria"),
                            new XAttribute("quantita", Variabili.Coda.Fattoria.quantità)),
                        new XElement("Struttura",
                            new XAttribute("tipo", "Segheria"),
                            new XAttribute("quantita", Variabili.Coda.Segheria.quantità)),
                        new XElement("Struttura",
                            new XAttribute("tipo", "Cava_Pietra"),
                            new XAttribute("quantita", Variabili.Coda.CavaPietra.quantità)),
                        new XElement("Struttura",
                            new XAttribute("tipo", "Miniera_Ferro"),
                            new XAttribute("quantita", Variabili.Coda.MinieraFerro.quantità)),
                        new XElement("Struttura",
                            new XAttribute("tipo", "Miniera_Oro"),
                            new XAttribute("quantita", Variabili.Coda.MinieraOro.quantità)
                            )
                    ),

                    new XElement("Esercito_Mura",
                        new XElement("Unita",
                            new XAttribute("tipo", "Guerrieri"),
                            new XAttribute("quantita", Variabili.Città.Mura.Guerrieri)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Lancieri"),
                            new XAttribute("quantita", Variabili.Città.Mura.Lancieri)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Arcieri"),
                            new XAttribute("quantita", Variabili.Città.Mura.Arceri)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Catapulte"),
                            new XAttribute("quantita", Variabili.Città.Mura.Catapulte)
                            )
                    ),

                    new XElement("Esercito_Torre",
                        new XElement("Unita",
                            new XAttribute("tipo", "Guerrieri"),
                            new XAttribute("quantita", Variabili.Città.Torre.Guerrieri)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Lancieri"),
                            new XAttribute("quantita", Variabili.Città.Torre.Lancieri)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Arcieri"),
                            new XAttribute("quantita", Variabili.Città.Torre.Arceri)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Catapulte"),
                            new XAttribute("quantita", Variabili.Città.Torre.Catapulte)
                            )
                    ),

                    new XElement("Esercito_Castello",
                        new XElement("Unita",
                            new XAttribute("tipo", "Guerrieri"),
                            new XAttribute("quantita", Variabili.Città.Castello.Guerrieri)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Lancieri"),
                            new XAttribute("quantita", Variabili.Città.Castello.Lancieri)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Arcieri"),
                            new XAttribute("quantita", Variabili.Città.Castello.Arceri)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Catapulte"),
                            new XAttribute("quantita", Variabili.Città.Castello.Catapulte)
                            )
                    ),

                    new XElement("Esercito_Invasore",
                        new XElement("Unita",
                            new XAttribute("tipo", "Guerrieri"),
                            new XAttribute("quantita", Variabili.EsercitoNemico.Guerriero.Quantità)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Lancieri"),
                            new XAttribute("quantita", Variabili.EsercitoNemico.Lanciere.Quantità)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Arcieri"),
                            new XAttribute("quantita", Variabili.EsercitoNemico.Arciere.Quantità)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Catapulte"),
                            new XAttribute("quantita", Variabili.EsercitoNemico.Catapulta.Quantità)),
                        new XElement("Unita",
                            new XAttribute("tipo", "Ondata Invasione"),
                            new XAttribute("quantita", Invasione_Ondata)
                            )
                    ),

                    new XElement("Ricerca",
                        new XElement("Strutture",
                            new XAttribute("tipo", "Produzione"),
                            new XAttribute("quantita", btn_Risorse_Produzione.Text)),
                        new XElement("Strutture",
                            new XAttribute("tipo", "Costruzione"),
                            new XAttribute("quantita", btn_Risorse_Costruzione.Text)),
                        new XElement("Strutture",
                            new XAttribute("tipo", "Popolazione"),
                            new XAttribute("quantita", btn_Risorse_Popolazione.Text)),

                        new XElement("Esercito",
                            new XAttribute("tipo", "Attacco"),
                            new XAttribute("quantita", btn_Esercito_Attacco.Text)),
                        new XElement("Esercito",
                            new XAttribute("tipo", "Difesa"),
                            new XAttribute("quantita", btn_Esercito_Difesa.Text)),
                        new XElement("Esercito",
                            new XAttribute("tipo", "Salute"),
                            new XAttribute("quantita", btn_Esercito_Salute.Text)),
                        new XElement("Esercito",
                            new XAttribute("tipo", "Reclutamento")),
                            new XAttribute("quantita", btn_Esercito_Reclutamento.Text)),

                        new XElement("Città",
                            new XAttribute("tipo", "Riparazione"),
                            new XAttribute("quantita", btn_Citta_Riparazioni.Text)),
                        new XElement("Città",
                            new XAttribute("tipo", "Difesa"),
                            new XAttribute("quantita", btn_Citta_Difesa.Text)),
                        new XElement("Città",
                            new XAttribute("tipo", "Salute"),
                            new XAttribute("quantita", btn_Citta_Salute.Text)),
                        new XElement("Città",
                            new XAttribute("tipo", "Guarnigione"),
                            new XAttribute("quantita", btn_Citta_Guarnigione.Text)
                    )
                    
                )
            );

            // Salvare il file XML
            xmlDoc.Save("gioco.xml");

            Console.WriteLine("File XML creato e salvato con successo.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Carica il documento XML
            XDocument xmlDoc = XDocument.Load("gioco.xml");

            // Estrai e assegna le risorse a variabili specifiche
            Variabili.Cibo = double.Parse(xmlDoc.Descendants("Risorsa")
                                      .First(r => r.Attribute("tipo").Value == "Cibo")
                                      .Attribute("quantita").Value.Replace(".", ","));

            Variabili.Legno = double.Parse(xmlDoc.Descendants("Risorsa")
                                       .First(r => r.Attribute("tipo").Value == "Legna")
                                       .Attribute("quantita").Value.Replace(".", ","));

            Variabili.Pietra = double.Parse(xmlDoc.Descendants("Risorsa")
                                       .First(r => r.Attribute("tipo").Value == "Ferro")
                                       .Attribute("quantita").Value.Replace(".", ","));

            Variabili.Ferro = double.Parse(xmlDoc.Descendants("Risorsa")
                                        .First(r => r.Attribute("tipo").Value == "Pietra")
                                        .Attribute("quantita").Value.Replace(".", ","));

            Variabili.Oro = double.Parse(xmlDoc.Descendants("Risorsa")
                                     .First(r => r.Attribute("tipo").Value == "Oro")
                                     .Attribute("quantita").Value.Replace(".", ","));

            Variabili.Popolazione = double.Parse(xmlDoc.Descendants("Risorsa")
                                     .First(r => r.Attribute("tipo").Value == "Popolazione")
                                     .Attribute("quantita").Value.Replace(".", ","));

            Variabili.token = int.Parse(xmlDoc.Descendants("Risorsa")
                                     .First(r => r.Attribute("tipo").Value == "Token")
                                     .Attribute("quantita").Value);

            int GetUnitCount2(string parentName, string unitType)
            {
                return int.Parse(xmlDoc.Descendants("Struttura")
                                       .First(u => u.Parent.Name == parentName && u.Attribute("tipo").Value == unitType)
                                       .Attribute("quantita").Value);
            }

            // Estrazione dei dati per "Esercito_Reclutamento"
            Variabili.Coda.Fattoria.quantità = GetUnitCount2("Strutture_Costruzione", "Fattoria");
            Variabili.Coda.Segheria.quantità = GetUnitCount2("Strutture_Costruzione", "Segheria");
            Variabili.Coda.CavaPietra.quantità = GetUnitCount2("Strutture_Costruzione", "Cava_Pietra");
            Variabili.Coda.MinieraFerro.quantità = GetUnitCount2("Strutture_Costruzione", "Miniera_Ferro");
            Variabili.Coda.MinieraOro.quantità = GetUnitCount2("Strutture_Costruzione", "Miniera_Oro");

            Variabili.fattoria = GetUnitCount2("Strutture", "Fattoria");
            Variabili.segheria = GetUnitCount2("Strutture", "Segheria");
            Variabili.cava_Pietra = GetUnitCount2("Strutture", "Cava_Pietra");
            Variabili.miniera_Ferro = GetUnitCount2("Strutture", "Miniera_Ferro");
            Variabili.miniera_Oro = GetUnitCount2("Strutture", "Miniera_Oro");

            int GetUnitCount(string parentName, string unitType)
            {
                return int.Parse(xmlDoc.Descendants("Unita")
                                       .First(u => u.Parent.Name == parentName && u.Attribute("tipo").Value == unitType)
                                       .Attribute("quantita").Value);
            }


            // Estrazione dei dati per "Esercito"
            Variabili.Esercito.Guerriero.Quantità = GetUnitCount("Esercito", "Guerrieri");
            Variabili.Esercito.Lanciere.Quantità = GetUnitCount("Esercito", "Lancieri");
            Variabili.Esercito.Arciere.Quantità = GetUnitCount("Esercito", "Arcieri");
            Variabili.Esercito.Catapulta.Quantità = GetUnitCount("Esercito", "Catapulte");

            // Estrazione dei dati per "Esercito_Reclutamento"
            Variabili.Coda.Guerriero.quantità = GetUnitCount("Esercito_Reclutamento", "Guerrieri");
            Variabili.Coda.Lanciere.quantità = GetUnitCount("Esercito_Reclutamento", "Lancieri");
            Variabili.Coda.Arciere.quantità = GetUnitCount("Esercito_Reclutamento", "Arcieri");
            Variabili.Coda.Catapulta.quantità = GetUnitCount("Esercito_Reclutamento", "Catapulte");

            // Estrazione dei dati per "Esercito_Mura"
            Variabili.Città.Mura.Guerrieri  = GetUnitCount("Esercito_Mura", "Guerrieri");
            Variabili.Città.Mura.Lancieri   = GetUnitCount("Esercito_Mura", "Lancieri");
            Variabili.Città.Mura.Arceri     = GetUnitCount("Esercito_Mura", "Arcieri");
            Variabili.Città.Mura.Catapulte  = GetUnitCount("Esercito_Mura", "Catapulte");

            // Estrazione dei dati per "Esercito_Torre"
            Variabili.Città.Torre.Guerrieri  = GetUnitCount("Esercito_Torre", "Guerrieri");
            Variabili.Città.Torre.Lancieri   = GetUnitCount("Esercito_Torre", "Lancieri");
            Variabili.Città.Torre.Arceri     = GetUnitCount("Esercito_Torre", "Arcieri");
            Variabili.Città.Torre.Catapulte  = GetUnitCount("Esercito_Torre", "Catapulte");

            // Estrazione dei dati per "Esercito_Castello"
            Variabili.Città.Castello.Guerrieri  = GetUnitCount("Esercito_Castello", "Guerrieri");
            Variabili.Città.Castello.Lancieri   = GetUnitCount("Esercito_Castello", "Lancieri");
            Variabili.Città.Castello.Arceri     = GetUnitCount("Esercito_Castello", "Arcieri");
            Variabili.Città.Castello.Catapulte  = GetUnitCount("Esercito_Castello", "Catapulte");

            // Estrazione dei dati per "Esercito_Invasore"
            Variabili.EsercitoNemico.Guerriero.Quantità  = GetUnitCount("Esercito_Invasore", "Guerrieri");
            Variabili.EsercitoNemico.Lanciere.Quantità = GetUnitCount("Esercito_Invasore", "Lancieri");
            Variabili.EsercitoNemico.Arciere.Quantità = GetUnitCount("Esercito_Invasore", "Arcieri");
            Variabili.EsercitoNemico.Catapulta.Quantità = GetUnitCount("Esercito_Invasore", "Catapulte");
            Invasione_Ondata = GetUnitCount("Esercito_Invasore", "Ondata Invasione");
        }
    }
}
