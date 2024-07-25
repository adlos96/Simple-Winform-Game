using rts_2D.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace rts_2D
{
    public partial class Form1 : Form
    {
        int tokenCostruzione = 0;
        int tokenReclutamento = 0;
        int Invasione_Ondata = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label17_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text = "Reclutamento Guerriero\r\nCibo: 750\r\nLegno: 975\r\nPietra: 0\r\nFerro: 525\r\nOro: 200";
        }

        private void label23_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text = "Reclutamento Lanciere\r\nCibo: 750\r\nLegno: 975\r\nPietra: 0\r\nFerro: 525\r\nOro: 200";
        }

        private void label15_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text = "Reclutamento Arciere\r\nCibo: 750\r\nLegno: 975\r\nPietra: 0\r\nFerro: 525\r\nOro: 200";
        }

        private void label14_MouseHover(object sender, EventArgs e)
        {
            txt_Log.Text = "Reclutamento Catapulta\r\nCibo: 750\r\nLegno: 975\r\nPietra: 500\r\nFerro: 525\r\nOro: 400";
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
                if (fattorie >= 0 &&
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
                        txt_Cose.Text = txt_Cose.Text + "Costruzione Fattoria fallita, risorse insufficienti\r\n";
                    }
                
                if (segherie >= 0 &&
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
                        txt_Cose.Text = txt_Cose.Text + "Costruzione Segheria fallita, risorse insufficienti\r\n";
                    }

                if (cava >= 0 &&
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
                        txt_Cose.Text = txt_Cose.Text + "Costruzione Cava di Pietra fallita, risorse insufficienti\r\n";
                        cava = 0;
                    }

                if (miniera_Ferro >= 0 &&
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
                    txt_Cose.Text = txt_Cose.Text + "Costruzione Miniera di Ferro fallita, risorse insufficienti\r\n";
                    miniera_Ferro = 0;
                }

                if (miniera_Oro >= 0 &&
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
                        txt_Cose.Text = txt_Cose.Text + "Costruzione Miniera d'Oro fallita, risorse insufficienti\r\n";
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

            if (Guerriero > 0 || Lanciere > 0 || Arciere > 0 || Catapulta > 0)
            {
                if (Guerriero >= 0 &&
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
                else
                    if (Guerriero != 0)
                {
                    Guerriero = 0;
                    txt_Cose.Text = txt_Cose.Text + "Reclutamento Guerriero fallita, risorse insufficienti\r\n";
                }

                if (Lanciere >= 0 &&
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
                }
                else
                    if (Lanciere != 0)
                {
                    Lanciere = 0;
                    txt_Cose.Text = txt_Cose.Text + "Reclutamento Lanciere fallita, risorse insufficienti\r\n";
                }

                if (Arciere >= 0 &&
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
                }
                else
                    if (Arciere != 0)
                {
                    txt_Cose.Text = txt_Cose.Text + "Reclutamento Arciere fallita, risorse insufficienti\r\n";
                    Arciere = 0;
                }

                if (Catapulta >= 0 &&
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
                }
                else
                    if (Catapulta != 0)
                {
                    txt_Cose.Text = txt_Cose.Text + "Reclutamento Catapulta fallita, risorse insufficienti\r\n";
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
        }
        private async void btn_Start_Click(object sender, EventArgs e)
        {
            _ = Task.Run(() => Loop());
            btn_Invasioni.Visible = true;
        }
        async Task Loop()
        {
            Variabili.Cibo = 1000;
            Variabili.Legno = 1000;
            Variabili.Pietra = 1000;
            Variabili.Ferro = 1000;
            Variabili.Oro = 1500;
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
                    Variabili.guerrieri * ((Variabili.Esercito.Guerriero.Salute * 0.33) + (Variabili.Esercito.Guerriero.Attacco * 0.72)) +
                    Variabili.picchieri * ((Variabili.Esercito.Lanciere.Salute * 0.33) + (Variabili.Esercito.Lanciere.Attacco * 0.72)) +
                    Variabili.arcieri   * ((Variabili.Esercito.Arciere.Salute * 0.33) + (Variabili.Esercito.Arciere.Attacco * 0.72)) +
                    Variabili.catapulte * ((Variabili.Esercito.Catapulta.Salute * 0.33) + (Variabili.Esercito.Catapulta.Attacco * 0.72));

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
                    Variabili.tempo_Costruzione--;
                    if (Variabili.Coda.Fattoria.quantità > 0) Fattoria++;
                    if (Variabili.Coda.Segheria.quantità > 0) Segheria++;
                    if (Variabili.Coda.CavaPietra.quantità > 0) CavaPietra++;
                    if (Variabili.Coda.MinieraFerro.quantità > 0) MinieraFerro++;
                    if (Variabili.Coda.MinieraOro.quantità > 0) MinieraOro++;

                    if (Variabili.Coda.Fattoria.quantità > 0 && Fattoria == Variabili.CostoCostruzione.Fattoria.TempoCostruzione)
                    {
                        Variabili.fattoria++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = txt_Cose.Text + "Costruzione Fattoria completata!\r\n"));
                        Variabili.Coda.Fattoria.quantità--;
                        Fattoria = 0;
                    }
                    if (Variabili.Coda.Segheria.quantità > 0 && Segheria == Variabili.CostoCostruzione.Segheria.TempoCostruzione)
                    {
                        Variabili.segheria++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = txt_Cose.Text + "Costruzione Segheria completata!\r\n"));
                        Variabili.Coda.Segheria.quantità--;
                        Segheria = 0;
                    }
                    if (Variabili.Coda.CavaPietra.quantità > 0 && CavaPietra == Variabili.CostoCostruzione.CavaPietra.TempoCostruzione)
                    {
                        Variabili.cava_Pietra++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = txt_Cose.Text + "Costruzione Cava di Pietra completata!\r\n"));
                        Variabili.Coda.CavaPietra.quantità--;
                        CavaPietra = 0;
                    }
                    if (Variabili.Coda.MinieraFerro.quantità > 0 && MinieraFerro == Variabili.CostoCostruzione.MinieraFerro.TempoCostruzione)
                    {
                        Variabili.miniera_Ferro++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = txt_Cose.Text + "Costruzione Miniera di Ferro completata!\r\n"));
                        Variabili.Coda.MinieraFerro.quantità--;
                        MinieraFerro = 0;
                    }
                    if (Variabili.Coda.MinieraOro.quantità > 0 && MinieraOro == Variabili.CostoCostruzione.MinieraOro.TempoCostruzione)
                    {
                        Variabili.miniera_Oro++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = txt_Cose.Text + "Costruzione Miniera d'Oro completata!\r\n"));
                        Variabili.Coda.MinieraOro.quantità--;
                        MinieraOro = 0;
                    }
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
                    Variabili.tempo_Reclutamento--;
                    if (Variabili.Coda.Guerriero.quantità > 0) Guerriero++;
                    if (Variabili.Coda.Lanciere.quantità > 0) Lanciere++;
                    if (Variabili.Coda.Arciere.quantità > 0) Arciere++;
                    if (Variabili.Coda.Catapulta.quantità > 0) Catapulta++;

                    if (Variabili.Coda.Guerriero.quantità > 0 && Guerriero == Variabili.CostoReclutamento.Guerriero.TempoReclutamento)
                    {
                        Variabili.guerrieri++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = txt_Cose.Text + "Reclutamento Guerrirero\r\n"));
                        Variabili.Coda.Guerriero.quantità--;
                        Guerriero = 0;
                    }
                    if (Variabili.Coda.Lanciere.quantità > 0 && Lanciere == Variabili.CostoReclutamento.Lanciere.TempoReclutamento)
                    {
                        Variabili.picchieri++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = txt_Cose.Text + "Reclutamento Lanciere\r\n"));
                        Variabili.Coda.Lanciere.quantità--;
                        Lanciere = 0;
                    }
                    if (Variabili.Coda.Arciere.quantità > 0 && Arciere == Variabili.CostoReclutamento.Arciere.TempoReclutamento)
                    {
                        Variabili.arcieri++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = txt_Cose.Text + "Reclutamento Arciere\r\n"));
                        Variabili.Coda.Arciere.quantità--;
                        Arciere = 0;
                    }
                    if (Variabili.Coda.Catapulta.quantità > 0 && Catapulta == Variabili.CostoReclutamento.Catapulta.TempoReclutamento)
                    {
                        Variabili.catapulte++;
                        txt_Cibo.Invoke((Action)(() => txt_Cose.Text = txt_Cose.Text + "Reclutamento Catapulta\r\n"));
                        Variabili.Coda.Catapulta.quantità--;
                        Catapulta = 0;
                    }
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
                    $"Fattorie:             {Variabili.fattoria}\r\n" +
                    $"Segherie:           {Variabili.segheria}\r\n" +
                    $"Cave di Pietra:   {Variabili.cava_Pietra}\r\n" +
                    $"Miniera di Ferro: {Variabili.miniera_Ferro}\r\n" +
                    $"Miniera d'Oro:    {Variabili.miniera_Oro}\r\n";
                    txt_Esercito.Text = $"" +
                    $"Guerriero:    {Variabili.guerrieri}\r\n" +
                    $"Lanciere:     {Variabili.picchieri}\r\n" +
                    $"Arceri:         {Variabili.arcieri}\r\n" +
                    $"Catapulte:    {Variabili.catapulte}\r\n" +
                    $"Forza Esercito Difensore: {Variabili.forza_Esercito.ToString("0.00")}";
                }));
            }
        }
        private void Invasione()
        {
            txt_Esercito_Invasore.Text = $"" +
                    $"Guerriero:    {Variabili.guerrieri_Att}\r\n" +
                    $"Lanciere:     {Variabili.picchieri_Att}\r\n" +
                    $"Arceri:         {Variabili.arcieri_Att}\r\n" +
                    $"Catapulte:    {Variabili.catapulte_Att}\r\n" +
                    $"Forza Esercito Invasore: {Variabili.forza_Esercito_Att.ToString("0.00")}";
            txt_Timer_Invasione.Text = Variabili.timer_Invasione.ToString();
        }
        private async Task<double> Cibo()
        {
            double cibo = 0;

            cibo += Variabili.guerrieri * Variabili.Esercito.Guerriero.Cibo;
            cibo += Variabili.picchieri * Variabili.Esercito.Lanciere.Cibo;
            cibo += Variabili.arcieri * Variabili.Esercito.Arciere.Cibo;
            cibo += Variabili.catapulte * Variabili.Esercito.Catapulta.Cibo;

            return cibo;
        }
        private async Task<double> Oro()
        {
            double oro = 0;

            oro += Variabili.guerrieri * Variabili.Esercito.Guerriero.Salario;
            oro += Variabili.picchieri * Variabili.Esercito.Lanciere.Salario;
            oro += Variabili.arcieri * Variabili.Esercito.Arciere.Salario;
            oro += Variabili.catapulte * Variabili.Esercito.Catapulta.Salario;

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

            _ = Task.Run(() => Loop_Invasione());
        }
        void Loop_Invasione()
        {
            int Guerriero = 50;
            int i = 0;

            Variabili.guerrieri_Att = 50;
            Variabili.picchieri_Att = 20;
            Variabili.arcieri_Att = 5;
            Variabili.catapulte_Att = 1;
            while (true)
            {
                if (i == 4)
                {
                    Variabili.guerrieri_Att++;
                    //Variabili.picchieri_Att = Variabili.picchieri_Att++;
                    //Variabili.arcieri_Att = Variabili.arcieri_Att++;
                    //Variabili.catapulte_Att = Variabili.catapulte_Att++;
                    i = 0;
                    txt_Cibo.Invoke((Action)(async () =>
                    {
                        Invasione();
                    }));
                }
                i++;
                txt_Cibo.Invoke((Action)(async () =>
                {
                    Invasione();
                }));
                Variabili.timer_Invasione--;

                Variabili.forza_Esercito_Att =
                    Variabili.guerrieri_Att * ((Variabili.Esercito.Guerriero.Salute * 0.33) + (Variabili.Esercito.Guerriero.Attacco * 0.72)) +
                    Variabili.picchieri_Att * ((Variabili.Esercito.Lanciere.Salute * 0.33) + (Variabili.Esercito.Lanciere.Attacco * 0.72)) +
                    Variabili.arcieri_Att * ((Variabili.Esercito.Arciere.Salute * 0.33) + (Variabili.Esercito.Arciere.Attacco * 0.72)) +
                    Variabili.catapulte_Att * ((Variabili.Esercito.Catapulta.Salute * 0.33) + (Variabili.Esercito.Catapulta.Attacco * 0.72));
                Thread.Sleep(1000);
            }
        }
    }
}
