using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace rts_2D
{
    public partial class Esercito_Form : Form
    {
        public Esercito_Form()
        {
            InitializeComponent();
            if (Variabili.form_Spostamento_truppe == "Castello") lbl_Spostamento.Text = "Castello";
            if (Variabili.form_Spostamento_truppe == "Torre") lbl_Spostamento.Text = "Torre";
            if (Variabili.form_Spostamento_truppe == "Mura") lbl_Spostamento.Text = "Mura";
        }

        private void Esercito_Load(object sender, EventArgs e)
        {
            if (lbl_Spostamento.Text == "Castello")
            {
                txt_Guerrieri_Spostamento.Text  = Variabili.Città.Castello.Guerrieri.ToString();
                txt_Lancieri_Spostamento.Text   = Variabili.Città.Castello.Lancieri.ToString();
                txt_Arcieri_Spostamento.Text    = Variabili.Città.Castello.Arceri.ToString();
                txt_Catapulte_Spostamento.Text  = Variabili.Città.Castello.Catapulte.ToString();
            }
            if (lbl_Spostamento.Text == "Torre")
            {
                txt_Guerrieri_Spostamento.Text  = Variabili.Città.Torre.Guerrieri.ToString();
                txt_Lancieri_Spostamento.Text   = Variabili.Città.Torre.Lancieri.ToString();
                txt_Arcieri_Spostamento.Text    = Variabili.Città.Torre.Arceri.ToString();
                txt_Catapulte_Spostamento.Text  = Variabili.Città.Torre.Catapulte.ToString();
            }
            if (lbl_Spostamento.Text == "Mura")
            {
                txt_Guerrieri_Spostamento.Text  = Variabili.Città.Mura.Guerrieri.ToString();
                txt_Lancieri_Spostamento.Text   = Variabili.Città.Mura.Lancieri.ToString();
                txt_Arcieri_Spostamento.Text    = Variabili.Città.Mura.Arceri.ToString();
                txt_Catapulte_Spostamento.Text  = Variabili.Città.Mura.Catapulte.ToString();
            }
            txt_Guerrieri_Esercito.Text = Variabili.Esercito.Guerriero.Quantità.ToString();
            txt_Lancieri_Esercito.Text = Variabili.Esercito.Lanciere.Quantità.ToString();
            txt_Arcieri_Esercito.Text = Variabili.Esercito.Arciere.Quantità.ToString();
            txt_Catapulte_Esercito.Text = Variabili.Esercito.Catapulta.Quantità.ToString();

            trackbar_Lancieri.Maximum = Variabili.Esercito.Lanciere.Quantità;
            trackbar_Lancieri.Minimum = 0;
            txt_Min_Trackbar_Lancieri.Text = trackbar_Lancieri.Minimum.ToString();
            txt_Max_Trackbar_Lancieri.Text = trackbar_Lancieri.Maximum.ToString();

            trackbar_Guerrieri.Maximum = Variabili.Esercito.Guerriero.Quantità;
            trackbar_Guerrieri.Minimum = 0;

            txt_Min_Trackbar_Guerrieri.Text = trackbar_Guerrieri.Minimum.ToString();
            txt_Max_Trackbar_Guerrieri.Text = trackbar_Guerrieri.Maximum.ToString();

            trackbar_Arcieri.Maximum = Variabili.Esercito.Arciere.Quantità;
            trackbar_Arcieri.Minimum = 0;

            txt_Min_Trackbar_Arcieri.Text = trackbar_Arcieri.Minimum.ToString();
            txt_Max_Trackbar_Arcieri.Text = trackbar_Arcieri.Maximum.ToString();

            trackbar_Catapulte.Maximum = Variabili.Esercito.Catapulta.Quantità;
            trackbar_Catapulte.Minimum = 0;

            txt_Min_Trackbar_Catapulte.Text = trackbar_Catapulte.Minimum.ToString();
            txt_Max_Trackbar_Catapulte.Text = trackbar_Catapulte.Maximum.ToString();

        }

        private void btn_Conferma_Spostamento_Click(object sender, EventArgs e)
        {
            int guerrieri = Convert.ToInt32(txt_Value_Trackbar_Guerrieri.Text);
            int lancieri = Convert.ToInt32(txt_Value_Trackbar_Lancieri.Text);
            int arcieri = Convert.ToInt32(txt_Value_Trackbar_Arcieri.Text);
            int catapulte = Convert.ToInt32(txt_Value_Trackbar_Catapulte.Text);

            int guerrieri_Struttuta = Convert.ToInt32(txt_Guerrieri_Spostamento.Text);
            int lancieri_Struttuta = Convert.ToInt32(txt_Lancieri_Spostamento.Text);
            int arcieri_Struttuta = Convert.ToInt32(txt_Arcieri_Spostamento.Text);
            int catapulte_Struttuta = Convert.ToInt32(txt_Catapulte_Spostamento.Text);
            int totale = guerrieri_Struttuta + lancieri_Struttuta + arcieri_Struttuta + catapulte_Struttuta;
            switch (lbl_Spostamento.Text)
            {
                case "Castello":
                    if (guerrieri > 0 && totale + guerrieri <= Variabili.Città.Castello.Guarnigione)
                    {
                        Variabili.Esercito.Guerriero.Quantità -= guerrieri;
                        Variabili.Città.Castello.Guerrieri += guerrieri;
                    }
                    if (lancieri > 0 && totale + lancieri <= Variabili.Città.Castello.Guarnigione)
                    {
                        Variabili.Esercito.Lanciere.Quantità -= lancieri;
                        Variabili.Città.Castello.Lancieri += lancieri;
                    }
                    if (arcieri > 0 && totale + arcieri <= Variabili.Città.Castello.Guarnigione)
                    {
                        Variabili.Esercito.Arciere.Quantità -= arcieri;
                        Variabili.Città.Castello.Arceri += arcieri;
                    }
                    if (catapulte > 0 && totale + catapulte <= Variabili.Città.Castello.Guarnigione)
                    {
                        Variabili.Esercito.Catapulta.Quantità -= catapulte;
                        Variabili.Città.Castello.Catapulte += catapulte;
                    }
                    break;
                case "Torre":
                    if (guerrieri > 0 && totale + guerrieri <= Variabili.Città.Torre.Guarnigione)
                    {
                        Variabili.Esercito.Guerriero.Quantità -= guerrieri;
                        Variabili.Città.Torre.Guerrieri += guerrieri;
                    }
                    if (lancieri > 0 && totale + lancieri <= Variabili.Città.Torre.Guarnigione)
                    {
                        Variabili.Esercito.Lanciere.Quantità -= lancieri;
                        Variabili.Città.Torre.Lancieri += lancieri;
                    }
                    if (arcieri > 0 && totale + arcieri <= Variabili.Città.Torre.Guarnigione)
                    {
                        Variabili.Esercito.Arciere.Quantità -= arcieri;
                        Variabili.Città.Torre.Arceri += arcieri;
                    }
                    if (catapulte > 0 && totale + catapulte <= Variabili.Città.Torre.Guarnigione)
                    {
                        Variabili.Esercito.Catapulta.Quantità -= catapulte;
                        Variabili.Città.Torre.Catapulte += catapulte;
                    }
                    break;
                case "Mura":
                    if (guerrieri > 0 && totale + guerrieri <= Variabili.Città.Mura.Guarnigione)
                    {
                        Variabili.Esercito.Guerriero.Quantità -= guerrieri;
                        Variabili.Città.Mura.Guerrieri += guerrieri;
                    }
                    if (lancieri > 0 && totale + lancieri <= Variabili.Città.Mura.Guarnigione)
                    {
                        Variabili.Esercito.Lanciere.Quantità -= lancieri;
                        Variabili.Città.Mura.Lancieri += lancieri;
                    }
                    if (arcieri > 0 && totale + arcieri <= Variabili.Città.Mura.Guarnigione)
                    {
                        Variabili.Esercito.Arciere.Quantità -= arcieri;
                        Variabili.Città.Mura.Arceri += arcieri;
                    }
                    if (catapulte > 0 && totale + catapulte <= Variabili.Città.Mura.Guarnigione)
                    {
                        Variabili.Esercito.Catapulta.Quantità -= catapulte;
                        Variabili.Città.Mura.Catapulte += catapulte;
                    }
                    break;
            }
            Console.WriteLine("Totale Uomini: " + totale);
            ActiveForm.Close();
            return;
        }

        private void trackbar_Guerrieri_Scroll(object sender, EventArgs e)
        {
            txt_Value_Trackbar_Guerrieri.Text = trackbar_Guerrieri.Value.ToString();
            Esercito_Load(sender, e);
        }

        private void trackbar_Lancieri_Scroll(object sender, EventArgs e)
        {
            txt_Value_Trackbar_Lancieri.Text = trackbar_Lancieri.Value.ToString();
            Esercito_Load(sender, e);
        }

        private void trackbar_Arcieri_Scroll(object sender, EventArgs e)
        {
            txt_Value_Trackbar_Arcieri.Text = trackbar_Arcieri.Value.ToString();
            Esercito_Load(sender, e);
        }

        private void trackbar_Catapulte_Scroll(object sender, EventArgs e)
        {
            txt_Value_Trackbar_Catapulte.Text = trackbar_Catapulte.Value.ToString();
            Esercito_Load(sender, e);
        }
    }
}
