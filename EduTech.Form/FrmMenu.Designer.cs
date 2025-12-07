namespace EduTechPlus
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            m = new MenuStrip();
            LoginToolStripMenuItem = new ToolStripMenuItem();
            RegistroToolStripMenuItem = new ToolStripMenuItem();
            FrmUsuarios = new ToolStripMenuItem();
            m.SuspendLayout();
            SuspendLayout();
            // 
            // m
            // 
            m.ImageScalingSize = new Size(20, 20);
            m.Items.AddRange(new ToolStripItem[] { LoginToolStripMenuItem, RegistroToolStripMenuItem, FrmUsuarios });
            m.Location = new Point(0, 0);
            m.Name = "m";
            m.Size = new Size(1036, 62);
            m.TabIndex = 0;
            m.Text = "menuStrip1";
            // 
            // LoginToolStripMenuItem
            // 
            LoginToolStripMenuItem.Font = new Font("Segoe Print", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginToolStripMenuItem.Name = "LoginToolStripMenuItem";
            LoginToolStripMenuItem.Size = new Size(119, 58);
            LoginToolStripMenuItem.Text = "Login";
            LoginToolStripMenuItem.Click += FrmLogin_Click;
            // 
            // RegistroToolStripMenuItem
            // 
            RegistroToolStripMenuItem.Font = new Font("Segoe Print", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RegistroToolStripMenuItem.ForeColor = SystemColors.ControlText;
            RegistroToolStripMenuItem.Name = "RegistroToolStripMenuItem";
            RegistroToolStripMenuItem.Size = new Size(160, 58);
            RegistroToolStripMenuItem.Text = "Registro";
            RegistroToolStripMenuItem.Click += FrmRegistro_Click;
            // 
            // FrmUsuarios
            // 
            FrmUsuarios.Font = new Font("Segoe Print", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FrmUsuarios.Name = "FrmUsuarios";
            FrmUsuarios.Size = new Size(163, 58);
            FrmUsuarios.Text = "Usuarios";
            FrmUsuarios.Click += FrmUsuarios_Click;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 957);
            Controls.Add(m);
            IsMdiContainer = true;
            MainMenuStrip = m;
            Name = "FrmMenu";
            Text = "FrmLogin";
            m.ResumeLayout(false);
            m.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip m;
        private ToolStripMenuItem LoginToolStripMenuItem;
        private ToolStripMenuItem RegistroToolStripMenuItem;
        private ToolStripMenuItem FrmUsuarios;
    }
}