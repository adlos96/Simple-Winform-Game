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

namespace Strategico_V2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClientConnection.TestClient.InitializeClient(); // Connessione server
        }

        private void btn_New_Game_Click(object sender, EventArgs e)
        {
            ClientConnection.TestClient.Send($"Login|{txt_Username.Text}|{txt_Password.Text}");
            btn_New_Game.Enabled = false;
            Thread.Sleep(1000);
            if (Variabili_Client.login == true)
            {
                Variabili_Client.username = txt_Username.Text;
                Variabili_Client.password = txt_Password.Text;
                Login.ActiveForm.Close();
            }
        }
        

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Load_User_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
