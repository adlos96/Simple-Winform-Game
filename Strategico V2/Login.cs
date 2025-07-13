using System;
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
        public static string login_data = "";
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private async void btn_Login_User_Click(object sender, EventArgs e)
        {
            btn_Login_User.Enabled = false;
            txt_Log.Text = "Connessione...";

            if (txt_IP.Text != "AUTO")
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
                this.Close();
            }
            else btn_Login_User.Enabled = true;
            if (login_data != "") txt_Log.Text = login_data;
        }

        private async void btn_New_Game_Click(object sender, EventArgs e)
        {
            btn_New_Game.Enabled = false;
            txt_Log.Text = "Connessione..."; 

            if(txt_IP.Text != "AUTO")
                ClientConnection.TestClient._ServerIp = txt_IP.Text;
            ClientConnection.TestClient.InitializeClient(); // Connessione server
            await Sleep(2);
            txt_Log.Text = "Cotattando il server...";
            await Sleep(2);
            ClientConnection.TestClient.Send($"New Player|{txt_Username.Text}|{txt_Password.Text}");
            await Sleep(2);
            if (Variabili_Client.login == true)
            {
                Variabili_Client.username = txt_Username.Text;
                Variabili_Client.password = txt_Password.Text;
                this.Close();
            }else btn_New_Game.Enabled = true;
            if (login_data != "") txt_Log.Text = login_data;
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
    }
}
