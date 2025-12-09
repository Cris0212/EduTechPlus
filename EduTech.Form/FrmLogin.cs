using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace EduTechPlus
{
    public partial class FrmLogin : Form
    {
        private readonly HttpClient cliente = new HttpClient();

        public FrmLogin()
        {
            InitializeComponent();

            // Configurar HttpClient con la URL de tu API
            cliente.BaseAddress = new Uri("http://localhost:5215/api/");
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Crear DTO local para enviar al login
            var credenciales = new LoginRequest
            {
                Correo = txtCorreo.Text.Trim(),
                Contrasena = txtContraseña.Text.Trim()
            };

            if (string.IsNullOrEmpty(credenciales.Correo) || string.IsNullOrEmpty(credenciales.Contrasena))
            {
                MessageBox.Show("Ingrese correo y contraseña.");
                return;
            }

            try
            {
                string json = JsonConvert.SerializeObject(credenciales);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Llamada POST a la API
                var response = await cliente.PostAsync("Auth/login", content);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // DTO local para recibir respuesta de la API
                    var usuario = JsonConvert.DeserializeObject<UsuarioResponse>(jsonResponse);

                    if (usuario != null)
                    {
                        MessageBox.Show($"Bienvenido {usuario.Nombre} (Rol: {usuario.Rol})", "Login exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Correo o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la API: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // DTO local para enviar al logi
    public class LoginRequest
    {
        public string Correo { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
    }

    // DTO local para recibir respuesta de la API
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public int Rol { get; set; }
    }
}

