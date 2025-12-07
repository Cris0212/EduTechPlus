using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using EduTechPlus.Api.Models;
using Newtonsoft.Json;

namespace EduTechPlus
{
    public partial class FrmUsuarios : Form
    {
        private readonly HttpClient cliente = new HttpClient();

        public FrmUsuarios()
        {
            InitializeComponent();

            // Configurar HttpClient
            cliente.BaseAddress = new Uri("http://localhost:5215/api/");
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.AutoGenerateColumns = true;
            dgvUsuarios.CellDoubleClick += DgvUsuarios_CellDoubleClick;
            btnActualizar.Click += BtnActualizar_Click;
            CargarUsuariosAsync();
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
                    var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);

                    if (usuarios != null && usuarios.Count > 0)
                    {
                        dgvUsuarios.DataSource = usuarios;
                    }
                    else
                    {
                        dgvUsuarios.DataSource = null;
                        MessageBox.Show("No hay usuarios para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show($"No se pudieron cargar los usuarios. Código: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvUsuarios.Rows[e.RowIndex].DataBoundItem as Usuario;
                if (fila != null)
                {
                    string tipoDetalle = fila.ProfesorDetalle != null ? "Profesor" :
                                         fila.AlumnoDetalle != null ? "Alumno" : "Desconocido";

                    string info = $"ID: {fila.Id}\nNombre: {fila.Nombre}\nCorreo: {fila.Correo}\nRol: {fila.Rol}\nTipo: {tipoDetalle}";
                    MessageBox.Show(info, "Detalles del Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
