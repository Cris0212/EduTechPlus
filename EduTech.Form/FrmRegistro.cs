using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace EduTechPlus
{
    public partial class FrmRegistro : Form
    {
        private readonly HttpClient cliente = new HttpClient();

        public FrmRegistro()
        {
            InitializeComponent();

            // Configurar HttpClient
            cliente.BaseAddress = new Uri("http://localhost:5215/api/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // Configuración del Combo Rol
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Alumno");
            cmbRol.Items.Add("Profesor");
            cmbRol.SelectedIndex = 0;
        }

        private async void btnRegistar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtContrasenaRe.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Determinar el valor del rol según la selección
            int rolValor = (cmbRol.SelectedItem?.ToString() == "Alumno") ? 1 : 2;

            // Crear objeto para enviar al API
            var registro = new
            {
                nombre = txtNombre.Text.Trim(),
                correo = txtCorreo.Text.Trim(),
                contrasena = txtContrasenaRe.Text.Trim(),
                rol = rolValor
            };

            try
            {
                string json = JsonConvert.SerializeObject(registro);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await cliente.PostAsync("Auth/registro", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"{cmbRol.SelectedItem} registrado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCampos();
                }
                else
                {
                    string errorBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(
                        $"Error al registrar {cmbRol.SelectedItem}.\nCódigo: {response.StatusCode}\nAPI: {errorBody}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la API.\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtContrasenaRe.Clear();
            cmbRol.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
