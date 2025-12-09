using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace EduTechPlus
{
    public partial class FrmUsuarios : Form
    {
        private readonly HttpClient cliente = new HttpClient();

        public FrmUsuarios()
        {
            InitializeComponent();

            // Configurar HttpClient
            cliente.BaseAddress = new Uri("https://localhost:7215/api/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // Configurar DataGridView
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.AutoGenerateColumns = false;

            ConfigurarColumnas();

            // Asociar evento botón actualizar
            btnActualizar.Click += BtnActualizar_Click;

            // Cargar usuarios al iniciar
            CargarUsuariosAsync();
        }

        private void ConfigurarColumnas()
        {
            dgvUsuarios.Columns.Clear();

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                ReadOnly = true
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                ReadOnly = true
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Correo",
                HeaderText = "Correo",
                DataPropertyName = "Correo",
                ReadOnly = true
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Rol",
                HeaderText = "Rol",
                DataPropertyName = "Rol",
                ReadOnly = true
            });
        }

        private async void CargarUsuariosAsync()
        {
            btnActualizar.Enabled = false;

            try
            {
                dgvUsuarios.DataSource = null;

                var response = await cliente.GetAsync("Usuarios");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    // Deserializamos como dynamic
                    var usuariosApi = JsonConvert.DeserializeObject<List<dynamic>>(json);

                    // Creamos lista anónima para traducir el rol
                    var lista = usuariosApi.Select(u => new
                    {
                        Id = u.id,
                        Nombre = u.nombre,
                        Correo = u.correo,
                        Rol = (u.rol == 1) ? "Alumno" : "Profesor"
                    }).ToList();

                    dgvUsuarios.DataSource = lista;
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar los usuarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnActualizar.Enabled = true;
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarUsuariosAsync();
        }
    }
}
