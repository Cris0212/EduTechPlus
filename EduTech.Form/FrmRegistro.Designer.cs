namespace EduTechPlus
{
    partial class FrmRegistro
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
            btnCancelar = new Button();
            txtUsuario = new TextBox();
            btnRegistar = new Button();
            txtCorreo = new TextBox();
            txtContrasenaRe = new TextBox();
            lblTituloRe = new Label();
            lblUsuario = new Label();
            cmbRol = new ComboBox();
            lblCorreo = new Label();
            lblContrasena = new Label();
            lblRol = new Label();
            label1 = new Label();
            txtNombre = new TextBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.Font = new Font("Segoe Print", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.DarkSlateBlue;
            btnCancelar.Location = new Point(440, 390);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(139, 51);
            btnCancelar.TabIndex = 26;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.UseWaitCursor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.White;
            txtUsuario.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(487, 114);
            txtUsuario.Margin = new Padding(3, 2, 3, 2);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(246, 32);
            txtUsuario.TabIndex = 25;
            txtUsuario.UseWaitCursor = true;
            // 
            // btnRegistar
            // 
            btnRegistar.BackColor = Color.DarkSlateBlue;
            btnRegistar.Font = new Font("Segoe Print", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistar.ForeColor = Color.White;
            btnRegistar.Location = new Point(244, 390);
            btnRegistar.Margin = new Padding(3, 2, 3, 2);
            btnRegistar.Name = "btnRegistar";
            btnRegistar.Size = new Size(151, 51);
            btnRegistar.TabIndex = 24;
            btnRegistar.Text = "Registrar";
            btnRegistar.UseVisualStyleBackColor = false;
            btnRegistar.UseWaitCursor = true;
            btnRegistar.Click += btnRegistar_Click;
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreo.Location = new Point(89, 214);
            txtCorreo.Margin = new Padding(3, 2, 3, 2);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(307, 32);
            txtCorreo.TabIndex = 23;
            txtCorreo.UseWaitCursor = true;
            // 
            // txtContrasenaRe
            // 
            txtContrasenaRe.BackColor = Color.White;
            txtContrasenaRe.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasenaRe.Location = new Point(89, 302);
            txtContrasenaRe.Margin = new Padding(3, 2, 3, 2);
            txtContrasenaRe.Name = "txtContrasenaRe";
            txtContrasenaRe.Size = new Size(307, 32);
            txtContrasenaRe.TabIndex = 22;
            txtContrasenaRe.UseWaitCursor = true;
            // 
            // lblTituloRe
            // 
            lblTituloRe.AutoSize = true;
            lblTituloRe.Font = new Font("Segoe Print", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloRe.Location = new Point(309, 26);
            lblTituloRe.Name = "lblTituloRe";
            lblTituloRe.Size = new Size(130, 47);
            lblTituloRe.TabIndex = 21;
            lblTituloRe.Text = "Registro";
            lblTituloRe.UseWaitCursor = true;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(487, 82);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(88, 33);
            lblUsuario.TabIndex = 27;
            lblUsuario.Text = "Usuario";
            // 
            // cmbRol
            // 
            cmbRol.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(487, 214);
            cmbRol.Margin = new Padding(3, 2, 3, 2);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(246, 33);
            cmbRol.TabIndex = 30;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCorreo.Location = new Point(89, 182);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(80, 33);
            lblCorreo.TabIndex = 31;
            lblCorreo.Text = "Correo";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContrasena.Location = new Point(89, 270);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(124, 33);
            lblContrasena.TabIndex = 32;
            lblContrasena.Text = "Contraseña";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRol.Location = new Point(487, 171);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(161, 33);
            lblRol.TabIndex = 33;
            lblRol.Text = "Seleccionar Rol";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(91, 92);
            label1.Name = "label1";
            label1.Size = new Size(92, 33);
            label1.TabIndex = 34;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(89, 124);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(308, 32);
            txtNombre.TabIndex = 35;
            txtNombre.UseWaitCursor = true;
            // 
            // FrmRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(827, 473);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Controls.Add(lblRol);
            Controls.Add(lblContrasena);
            Controls.Add(lblCorreo);
            Controls.Add(cmbRol);
            Controls.Add(lblUsuario);
            Controls.Add(btnCancelar);
            Controls.Add(txtUsuario);
            Controls.Add(btnRegistar);
            Controls.Add(txtCorreo);
            Controls.Add(txtContrasenaRe);
            Controls.Add(lblTituloRe);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmRegistro";
            Text = "FrmRegistro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private TextBox txtUsuario;
        private Button btnRegistar;
        private TextBox txtCorreo;
        private TextBox txtContrasenaRe;
        private Label lblTituloRe;
        private Label lblUsuario;
        private ComboBox cmbRol;
        private Label lblCorreo;
        private Label lblContrasena;
        private Label lblRol;
        private Label label1;
        private TextBox txtNombre;
    }
}