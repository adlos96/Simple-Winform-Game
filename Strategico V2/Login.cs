using System;
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
        }

        private async void btn_New_Game_Click(object sender, EventArgs e)
        {
            btn_New_Game.Enabled = false;
            if(txt_IP.Text != "AUTO")
                ClientConnection.TestClient._ServerIp = txt_IP.Text;

            ClientConnection.TestClient.InitializeClient(); // Connessione server
            Thread.Sleep(1500);
            ClientConnection.TestClient.Send($"Login|{txt_Username.Text}|{txt_Password.Text}");
            await Sleep(4);
            if (Variabili_Client.login == true)
            {
                Variabili_Client.username = txt_Username.Text;
                Variabili_Client.password = txt_Password.Text;
                Login.ActiveForm.Close();
            }else btn_New_Game.Enabled = true;
        }
        public async Task<bool> Sleep(int secondi)
        {
            await Task.Delay(1000 * secondi);
            return true;
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
