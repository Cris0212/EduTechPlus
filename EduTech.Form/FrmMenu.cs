using System;
using System.Windows.Forms;

namespace EduTechPlus
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        private void FrmRegistro_Click(object sender, EventArgs e)
        {
            FrmRegistro frmRegistro = new FrmRegistro();
            frmRegistro.MdiParent = this;
            frmRegistro.WindowState = FormWindowState.Maximized;
            frmRegistro.Show();
        }
        private void FrmLogin_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.MdiParent = this;
            frmLogin.WindowState = FormWindowState.Maximized;
            frmLogin.Show();
        }

        private void FrmUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frmUsuarios = new FrmUsuarios();
            frmUsuarios.MdiParent = this;
            frmUsuarios.WindowState = FormWindowState.Maximized;
            frmUsuarios.Show();

        }
    }
}
