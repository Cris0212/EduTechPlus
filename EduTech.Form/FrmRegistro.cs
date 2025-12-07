using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using EduTechPlus.Api.Models;

namespace EduTechPlus
{
    public partial class FrmRegistro : Form
    {
        private readonly HttpClient cliente = new HttpClient();
        private List<Colegio> colegios = new List<Colegio>();
        private List<Grupo> grupos = new List<Grupo>();
        private List<Materia> materias = new List<Materia>();

        public FrmRegistro()
        {
            InitializeComponent();

            // Configuración HttpClient
            cliente.BaseAddress = new Uri("http://localhost:5215/api/");
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            cmbRol.Items.Add("Alumno");
            cmbRol.Items.Add("Profesor");
            cmbRol.SelectedIndex = 0;
            cmbRol.SelectedIndexChanged += RolChanged;
            cmbTurno.Items.Add("Diurno");
            cmbTurno.Items.Add("Vespertino");
            cmbTurno.SelectedIndex = 0;
            chkMateria.Visible = false;
            lblMateria.Visible = false;
            txtColegio.Leave += ColegioChanged;
            CargarColegios();
            CargarMaterias();
        }

        private void RolChanged(object? sender, EventArgs e)
        {
            bool esProfesor = cmbRol.SelectedItem.ToString() == "Profesor";
            chkMateria.Visible = esProfesor;
            lblMateria.Visible = esProfesor;

            if (!esProfesor)
                chkMateria.ClearSelected();
        }

        private async void CargarColegios()
        {
            try
            {
                var response = await cliente.GetAsync("Colegios");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    colegios = JsonConvert.DeserializeObject<List<Colegio>>(json);

                    txtColegio.AutoCompleteCustomSource.Clear();
                    foreach (var c in colegios)
                        txtColegio.AutoCompleteCustomSource.Add(c.Nombre);
                }
            }
            catch
            {
                MessageBox.Show("Error cargando colegios.");
            }
        }

        private async void CargarMaterias()
        {
            try
            {
                var response = await cliente.GetAsync("Materias");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    materias = JsonConvert.DeserializeObject<List<Materia>>(json);

                    chkMateria.Items.Clear();
                    foreach (var m in materias)
                        chkMateria.Items.Add(m.Nombre);
                }
            }
            catch
            {
                MessageBox.Show("Error cargando materias.");
            }
        }

        private void ColegioChanged(object? sender, EventArgs e)
        {
            var colegio = colegios.FirstOrDefault(c => c.Nombre == txtColegio.Text.Trim());
            if (colegio != null)
            {
                grupos = colegio.Grupos.ToList();
                cmbGrupo.Items.Clear();

                foreach (var g in grupos.Where(g => g.Nombre.Length >= 2 && "ABCDEF".Contains(g.Nombre[^1])))
                {
                    cmbGrupo.Items.Add(g.Nombre);
                }

                if (cmbGrupo.Items.Count > 0)
                    cmbGrupo.SelectedIndex = 0;
            }
        }

        private async void btnRegistar_Click(object? sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtCorreo.Text == "" || txtContrasenaRe.Text == "" || txtColegio.Text == "")
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            string rol = cmbRol.SelectedItem.ToString();
            string turno = cmbTurno.SelectedItem.ToString();
            var colegio = colegios.FirstOrDefault(c => c.Nombre == txtColegio.Text.Trim());
            int colegioId = colegio?.Id ?? 0;
            int grupoId = grupos.FirstOrDefault(g => g.Nombre == cmbGrupo.SelectedItem?.ToString())?.Id ?? 0;

            object registro;
            string endpoint;

            if (rol == "Alumno")
            {
                registro = new
                {
                    nombre = txtNombre.Text.Trim(),
                    correo = txtCorreo.Text.Trim(),
                    contrasena = txtContrasenaRe.Text.Trim(),
                    colegioId,
                    turno,
                    nombreGrupo = cmbGrupo.SelectedItem?.ToString()
                };
                endpoint = "Auth/register-alumno";
            }
            else
            {
                var materiasIds = chkMateria.CheckedItems.Cast<string>()
                    .Select(n => materias.FirstOrDefault(m => m.Nombre == n)?.Id ?? 0)
                    .Where(id => id > 0)
                    .ToArray();

                registro = new
                {
                    nombre = txtNombre.Text.Trim(),
                    correo = txtCorreo.Text.Trim(),
                    contrasena = txtContrasenaRe.Text.Trim(),
                    colegioId,
                    turno,
                    gruposIds = new int[] { grupoId },
                    materiasIds
                };
                endpoint = "Auth/register-profesor";
            }

            try
            {
                string json = JsonConvert.SerializeObject(registro);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await cliente.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"{rol} registrado correctamente.");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show($"Error al registrar {rol}");
                }
            }
            catch
            {
                MessageBox.Show("Error al conectar con la API.");
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtContrasenaRe.Clear();
            txtColegio.Clear();
            cmbGrupo.Items.Clear();
            cmbRol.SelectedIndex = 0;
            cmbTurno.SelectedIndex = 0;
            chkMateria.ClearSelected();
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
