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
            txt_Log.Text = "Connessione..."; 

            if(txt_IP.Text != "AUTO")
                ClientConnection.TestClient._ServerIp = txt_IP.Text;
            ClientConnection.TestClient.InitializeClient(); // Connessione server
            await Sleep(2);
            txt_Log.Text = "Login...";
            await Sleep(2);
            ClientConnection.TestClient.Send($"Login|{txt_Username.Text}|{txt_Password.Text}");
            await Loop_Login(5);
            await Sleep(2);
            if (Variabili_Client.login == true)
            {
                Variabili_Client.username = txt_Username.Text;
                Variabili_Client.password = txt_Password.Text;
                Login.ActiveForm.Close();
            }else btn_New_Game.Enabled = true;
        }
        public static async Task<bool> Sleep(int secondi)
        {
            await Task.Delay(1000 * secondi);
            return true;
        }
        public async Task<bool> Loop_Login(int tentativi_Max)
        {
            int tentativi = 1;
            while (Variabili_Client.login == false || tentativi >= tentativi_Max)
            {
                txt_Log.Text = $"Tentativo Login... [{tentativi}/{tentativi_Max}]";
                await Task.Delay(2000);
                tentativi++;
            }
            if (Variabili_Client.login == true)
                txt_Log.Text = $"Login completato con successo, buon game!";
            else txt_Log.Text = $"Login fallito!";
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
