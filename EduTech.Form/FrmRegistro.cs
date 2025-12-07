using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace EduTechPlus
{
    public partial class FrmRegistro : Form
    {
        // HttpClient para consumir la API
        private readonly HttpClient cliente = new HttpClient();

        public FrmRegistro()
        {
            InitializeComponent();

            cmbRol.Items.Clear();
            cmbRol.Items.Add("Alumno");
            cmbRol.Items.Add("Profesor");
            cmbRol.SelectedIndex = 0; 

            // Configurar HttpClient
            cliente.BaseAddress = new Uri("https://localhost:7060/api/");
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        // Evento del botón Registrar
        private async void btnRegistar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasenaRe.Text.Trim();
            string rol = cmbRol.SelectedItem?.ToString() ?? "Alumno";

            // Validación de campos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            object registro;
            string endpoint;

            if (rol == "Alumno")
            {
                registro = new
                {
                    nombre = nombre,
                    correo = correo,
                    contrasena = contrasena,
                    colegioId = 1,
                    turno = "Diurno",
                    nombreGrupo = "Grupo A"
                };
                endpoint = "Auth/register-alumno";
            }
            else 
            {
                registro = new
                {
                    nombre = nombre,
                    correo = correo,
                    contrasena = contrasena,
                    colegioId = 1,
                    turno = "Diurno",
                    materiasIds = new int[] { 1 },
                    gruposIds = new int[] { 1 }
                };
                endpoint = "Auth/register-profesor";
            }

            try
            {
                var json = JsonSerializer.Serialize(registro);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await cliente.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"{rol} registrado correctamente.");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show($"Error al registrar {rol}: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la API: " + ex.Message);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtContrasenaRe.Clear();
            cmbRol.SelectedIndex = 0;
        }
    }
}
