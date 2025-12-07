using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            string correo = txtUsuario.Text.Trim();
            string contrasena = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Correo y contraseña son obligatorios.");
                return;
            }

            if (!EsCorreoValido(correo))
            {
                MessageBox.Show("Ingrese un correo válido.");
                return;
            }

            var loginRequest = new
            {
                correo = correo,
                contrasena = contrasena
            };

            try
            {
                string json = JsonSerializer.Serialize(loginRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await cliente.PostAsync("Auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var usuario = JsonSerializer.Deserialize<LoginResponseDto>(responseBody);

                    MessageBox.Show($"Bienvenido {usuario.Nombre} ({usuario.Rol})");
                }
                else
                {
                    MessageBox.Show($"Login fallido: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con el servidor: " + ex.Message);
            }
        }
        private bool EsCorreoValido(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patron);
        }

        private class LoginResponseDto
        {
            public int UsuarioId { get; set; }
            public string Nombre { get; set; }
            public string Correo { get; set; }
            public string Rol { get; set; }
            public int? ColegioId { get; set; }
            public string ColegioNombre { get; set; }
            public string Turno { get; set; }
            public int? GrupoId { get; set; }
            public string GrupoNombre { get; set; }
        }
    }
}
