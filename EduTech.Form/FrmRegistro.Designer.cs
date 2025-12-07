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
            btnRegistar = new Button();
            txtCorreo = new TextBox();
            txtContrasenaRe = new TextBox();
            lblTituloRe = new Label();
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
            btnCancelar.Location = new Point(415, 295);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(139, 51);
            btnCancelar.TabIndex = 26;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.UseWaitCursor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnRegistar
            // 
            btnRegistar.BackColor = Color.DarkSlateBlue;
            btnRegistar.Font = new Font("Segoe Print", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistar.ForeColor = Color.White;
            btnRegistar.Location = new Point(223, 295);
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
            txtCorreo.Location = new Point(411, 124);
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
            txtContrasenaRe.Location = new Point(67, 217);
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
            lblTituloRe.Location = new Point(343, 25);
            lblTituloRe.Name = "lblTituloRe";
            lblTituloRe.Size = new Size(130, 47);
            lblTituloRe.TabIndex = 21;
            lblTituloRe.Text = "Registro";
            lblTituloRe.UseWaitCursor = true;
            // 
            // cmbRol
            // 
            cmbRol.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(410, 216);
            cmbRol.Margin = new Padding(3, 2, 3, 2);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(308, 33);
            cmbRol.TabIndex = 30;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCorreo.Location = new Point(68, 182);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(80, 33);
            lblCorreo.TabIndex = 31;
            lblCorreo.Text = "Correo";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContrasena.Location = new Point(415, 89);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(124, 33);
            lblContrasena.TabIndex = 32;
            lblContrasena.Text = "Contraseña";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRol.Location = new Point(415, 182);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(161, 33);
            lblRol.TabIndex = 33;
            lblRol.Text = "Seleccionar Rol";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(70, 92);
            label1.Name = "label1";
            label1.Size = new Size(92, 33);
            label1.TabIndex = 34;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(68, 124);
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
            ClientSize = new Size(835, 562);
            Controls.Add(txtNombre);
            Controls.Add(cmbRol);
            Controls.Add(btnCancelar);
            Controls.Add(btnRegistar);
            Controls.Add(txtCorreo);
            Controls.Add(txtContrasenaRe);
            Controls.Add(lblTituloRe);
            Controls.Add(lblRol);
            Controls.Add(label1);
            Controls.Add(lblCorreo);
            Controls.Add(lblContrasena);
            Margin = new Padding(3, 2, 3, 2);
            MinimizeBox = false;
            Name = "FrmRegistro";
            Text = "FrmRegistro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnRegistar;
        private TextBox txtCorreo;
        private TextBox txtContrasenaRe;
        private Label lblTituloRe;
        private ComboBox cmbRol;
        private Label lblCorreo;
        private Label lblContrasena;
        private Label lblRol;
        private Label label1;
        private TextBox txtNombre;
    }
}