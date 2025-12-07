using System;
using System.Windows.Forms;

namespace EduTechPlus
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar login primero
            FrmLogin frmLogin = new FrmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                // Si login OK, abrir menú principal
                Application.Run(new FrmMenu());
            }
        }
    }
}
