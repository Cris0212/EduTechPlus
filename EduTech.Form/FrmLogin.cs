using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using EduTechPlus.Api.Models;

namespace EduTechPlus
{
    public partial class FrmLogin : Form
    {
        private readonly HttpClient cliente = new HttpClient();

        public FrmLogin()
        {
            InitializeComponent();

            // Configurar HttpClient
            cliente.BaseAddress = new Uri("http://localhost:5215/api/");
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            string correo = txtUsuario.Text.Trim();
            string contrasena = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Ingrese correo y contraseña.");
                return;
            }

            var loginData = new { correo, contrasena };

            try
            {
                string json = JsonSerializer.Serialize(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await cliente.PostAsync("Auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    string resultJson = await response.Content.ReadAsStringAsync();
                    var usuario = JsonSerializer.Deserialize<Usuario>(resultJson);

                    if (usuario != null)
                    {
                        MessageBox.Show($"Bienvenido {usuario.Nombre} ({usuario.Rol})");
                        this.Hide();
                        FrmMenu menu = new FrmMenu();
                        menu.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener la información del usuario.");
                    }
                }
                else
                {
                    MessageBox.Show("Correo o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la API: " + ex.Message);
            }
        }
    }
}
