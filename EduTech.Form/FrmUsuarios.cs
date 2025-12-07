using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using EduTechPlus.Api.Dtos;
using EduTechPlus.Api.Models;

namespace EduTechPlus
{
    public partial class FrmUsuarios : Form
    {
        private readonly HttpClient cliente = new HttpClient();

        public FrmUsuarios()
        {
            InitializeComponent();

            cliente.BaseAddress = new Uri("http://localhost:5215/api/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.AutoGenerateColumns = false;

            ConfigurarColumnas();
            btnActualizar.Click += BtnActualizar_Click;

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
                Name = "Rol",
                HeaderText = "Rol",
                DataPropertyName = "Rol", // Alumno / Profesor
                ReadOnly = true
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Colegio",
                HeaderText = "Colegio",
                DataPropertyName = "Colegio",
                ReadOnly = true
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Turno",
                HeaderText = "Turno",
                DataPropertyName = "Turno",
                ReadOnly = true
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Grupo",
                HeaderText = "Grupo",
                DataPropertyName = "Grupo",
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
                    var usuariosApi = JsonConvert.DeserializeObject<List<dynamic>>(json);

                    var lista = new List<UsuarioListadoDto>();

                    foreach (var u in usuariosApi)
                    {
                        lista.Add(new UsuarioListadoDto
                        {
                            Id = u.id,
                            Nombre = u.nombre,
                            Rol = (u.rol == 1) ? "Alumno" : "Profesor",
                            Colegio = u.colegio ?? "",
                            Turno = u.turno ?? "",
                            Grupo = u.grupo ?? ""
                        });
                    }

                    dgvUsuarios.DataSource = lista;
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar los usuarios");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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