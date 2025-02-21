using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Strategico_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                $"{txt_Frecce_Costruzione.Text}|" +
                $"{txt_Caserma_Guerrieri.Text}|" +
                $"{txt_Caserma_Lancieri.Text}|" +
                $"{txt_Caserma_Arcieri.Text}|" +
                $"{txt_Caserma_Catapulte.Text}");

            txt_Fattoria_Costruzione.Text = "0";
            txt_Segheria_Costruzione.Text = "0";
            txt_CavaPietra_Costruzione.Text = "0";
            txt_MinieraFerro_Costruzione.Text = "0";
            txt_MinieraOro_Costruzione.Text = "0";
            txt_Case_Costruzione.Text = "0";
            txt_Spade_Costruzione.Text = "0";
            txt_Lancie_Costruzione.Text = "0";
            txt_Archi_Costruzione.Text = "0";
            txt_Scudi_Costruzione.Text = "0";
            txt_Armatura_Costruzione.Text = "0";
            txt_Frecce_Costruzione.Text = "0";

            txt_Caserma_Guerrieri.Text = "0";
            txt_Caserma_Lancieri.Text = "0";
            txt_Caserma_Arcieri.Text = "0";
            txt_Caserma_Catapulte.Text = "0";
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

        private void lbl_Caserma_Guerrieri_X0_Click(object sender, EventArgs e)
        {
            txt_Caserma_Guerrieri.Text = "0";
        }

        private void lbl_Caserma_Guerrieri_X1_Click(object sender, EventArgs e)
        {
            txt_Caserma_Guerrieri.Text = (Convert.ToInt32(txt_Caserma_Guerrieri.Text) + 1).ToString();
        }

        private void lbl_Caserma_Guerrieri_X5_Click(object sender, EventArgs e)
        {
            txt_Caserma_Guerrieri.Text = (Convert.ToInt32(txt_Caserma_Guerrieri.Text) + 5).ToString();
        }

        private void lbl_Caserma_Guerrieri_X10_Click(object sender, EventArgs e)
        {
            txt_Caserma_Guerrieri.Text = (Convert.ToInt32(txt_Caserma_Guerrieri.Text) + 10).ToString();
        }

        private void lbl_Caserma_Lancieri_X0_Click(object sender, EventArgs e)
        {
            txt_Caserma_Lancieri.Text = "0";
        }

        private void lbl_Caserma_Lancieri_X1_Click(object sender, EventArgs e)
        {
            txt_Caserma_Lancieri.Text = (Convert.ToInt32(txt_Caserma_Lancieri.Text) + 1).ToString();
        }

        private void lbl_Caserma_Lancieri_X5_Click(object sender, EventArgs e)
        {
            txt_Caserma_Lancieri.Text = (Convert.ToInt32(txt_Caserma_Lancieri.Text) + 5).ToString();
        }

        private void lbl_Caserma_Lancieri_X10_Click(object sender, EventArgs e)
        {
            txt_Caserma_Lancieri.Text = (Convert.ToInt32(txt_Caserma_Lancieri.Text) + 10).ToString();
        }

        private void lbl_Caserma_Arcieri_X0_Click(object sender, EventArgs e)
        {
            txt_Caserma_Arcieri.Text = "0";
        }

        private void lbl_Caserma_Arcieri_X1_Click(object sender, EventArgs e)
        {
            txt_Caserma_Arcieri.Text = (Convert.ToInt32(txt_Caserma_Arcieri.Text) + 1).ToString();
        }

        private void lbl_Caserma_Arcieri_X5_Click(object sender, EventArgs e)
        {
            txt_Caserma_Arcieri.Text = (Convert.ToInt32(txt_Caserma_Arcieri.Text) + 5).ToString();
        }

        private void lbl_Caserma_Arcieri_X10_Click(object sender, EventArgs e)
        {
            txt_Caserma_Arcieri.Text = (Convert.ToInt32(txt_Caserma_Arcieri.Text) + 10).ToString();
        }

        private void lbl_Caserma_Catapulte_X0_Click(object sender, EventArgs e)
        {
            txt_Caserma_Catapulte.Text = "0";
        }

        private void lbl_Caserma_Catapulte_X1_Click(object sender, EventArgs e)
        {
            txt_Caserma_Catapulte.Text = (Convert.ToInt32(txt_Caserma_Catapulte.Text) + 1).ToString();
        }

        private void lbl_Caserma_Catapulte_X5_Click(object sender, EventArgs e)
        {
            txt_Caserma_Catapulte.Text = (Convert.ToInt32(txt_Caserma_Catapulte.Text) + 5).ToString();
        }

        private void lbl_Caserma_Catapulte_X10_Click(object sender, EventArgs e)
        {
            txt_Caserma_Catapulte.Text = (Convert.ToInt32(txt_Caserma_Catapulte.Text) + 10).ToString();
        }
    }
}
