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
using static rts_2D.Variabili;

namespace rts_2D
{
    public partial class Esercito_Form : Form
    {
        public Esercito_Form()
        {
            InitializeComponent();
            if (form_Spostamento_truppe == "Castello") lbl_Spostamento.Text = "Castello";
            if (form_Spostamento_truppe == "Torre") lbl_Spostamento.Text = "Torre";
            if (form_Spostamento_truppe == "Mura") lbl_Spostamento.Text = "Mura";
        }

        private void Esercito_Load(object sender, EventArgs e)
        {
            if (lbl_Spostamento.Text == "Castello")
            {
                txt_Guerrieri_Spostamento.Text  = Città.Castello.Guerrieri.ToString();
                txt_Lancieri_Spostamento.Text   = Città.Castello.Lancieri.ToString();
                txt_Arcieri_Spostamento.Text    = Città.Castello.Arceri.ToString();
                txt_Catapulte_Spostamento.Text  = Città.Castello.Catapulte.ToString();
            }
            if (lbl_Spostamento.Text == "Torre")
            {
                txt_Guerrieri_Spostamento.Text  = Città.Torre.Guerrieri.ToString();
                txt_Lancieri_Spostamento.Text   = Città.Torre.Lancieri.ToString();
                txt_Arcieri_Spostamento.Text    = Città.Torre.Arceri.ToString();
                txt_Catapulte_Spostamento.Text  = Città.Torre.Catapulte.ToString();
            }
            if (lbl_Spostamento.Text == "Mura")
            {
                txt_Guerrieri_Spostamento.Text  = Città.Mura.Guerrieri.ToString();
                txt_Lancieri_Spostamento.Text   = Città.Mura.Lancieri.ToString();
                txt_Arcieri_Spostamento.Text    = Città.Mura.Arceri.ToString();
                txt_Catapulte_Spostamento.Text  = Città.Mura.Catapulte.ToString();
            }
            txt_Guerrieri_Esercito.Text = Esercito.Guerriero.Quantità.ToString();
            txt_Lancieri_Esercito.Text = Esercito.Lanciere.Quantità.ToString();
            txt_Arcieri_Esercito.Text = Esercito.Arciere.Quantità.ToString();
            txt_Catapulte_Esercito.Text = Esercito.Catapulta.Quantità.ToString();

            trackbar_Lancieri.Maximum = Esercito.Lanciere.Quantità;
            trackbar_Lancieri.Minimum = 0;
            txt_Min_Trackbar_Lancieri.Text = trackbar_Lancieri.Minimum.ToString();
            txt_Max_Trackbar_Lancieri.Text = trackbar_Lancieri.Maximum.ToString();

            trackbar_Guerrieri.Maximum = Esercito.Guerriero.Quantità;
            trackbar_Guerrieri.Minimum = 0;

            txt_Min_Trackbar_Guerrieri.Text = trackbar_Guerrieri.Minimum.ToString();
            txt_Max_Trackbar_Guerrieri.Text = trackbar_Guerrieri.Maximum.ToString();

            trackbar_Arcieri.Maximum = Esercito.Arciere.Quantità;
            trackbar_Arcieri.Minimum = 0;

            txt_Min_Trackbar_Arcieri.Text = trackbar_Arcieri.Minimum.ToString();
            txt_Max_Trackbar_Arcieri.Text = trackbar_Arcieri.Maximum.ToString();

            trackbar_Catapulte.Maximum = Esercito.Catapulta.Quantità;
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
            switch (lbl_Spostamento.Text)
            {
                case "Castello":
                    if (guerrieri > 0)
                    {
                        Esercito.Guerriero.Quantità -= guerrieri;
                        Città.Castello.Guerrieri += guerrieri;
                    }
                    if (lancieri > 0)
                    {
                        Esercito.Lanciere.Quantità -= lancieri;
                        Città.Castello.Lancieri += lancieri;
                    }
                    if (arcieri > 0)
                    {
                        Esercito.Arciere.Quantità -= arcieri;
                        Città.Castello.Arceri += arcieri;
                    }
                    if (catapulte > 0)
                    {
                        Esercito.Catapulta.Quantità -= catapulte;
                        Città.Castello.Catapulte += catapulte;
                    }
                    break;
                case "Torre":
                    if (guerrieri > 0)
                    {
                        Esercito.Guerriero.Quantità -= guerrieri;
                        Città.Torre.Guerrieri += guerrieri;
                    }
                    if (lancieri > 0)
                    {
                        Esercito.Lanciere.Quantità -= lancieri;
                        Città.Torre.Lancieri += lancieri;
                    }
                    if (arcieri > 0)
                    {
                        Esercito.Arciere.Quantità -= arcieri;
                        Città.Torre.Arceri += arcieri;
                    }
                    if (catapulte > 0)
                    {
                        Esercito.Catapulta.Quantità -= catapulte;
                        Città.Torre.Catapulte += catapulte;
                    }
                    break;
                case "Mura":
                    if (guerrieri > 0)
                    {
                        Esercito.Guerriero.Quantità -= guerrieri;
                        Città.Mura.Guerrieri += guerrieri;
                    }
                    if (lancieri > 0)
                    {
                        Esercito.Lanciere.Quantità -= lancieri;
                        Città.Mura.Lancieri += lancieri;
                    }
                    if (arcieri > 0)
                    {
                        Esercito.Arciere.Quantità -= arcieri;
                        Città.Mura.Arceri += arcieri;
                    }
                    if (catapulte > 0)
                    {
                        Esercito.Catapulta.Quantità -= catapulte;
                        Città.Mura.Catapulte += catapulte;
                    }
                    break;

            }
            ActiveForm.Close();
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
