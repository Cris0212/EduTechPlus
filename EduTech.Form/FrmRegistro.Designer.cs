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
            lblTurno = new Label();
            lblColegio = new Label();
            cmbTurno = new ComboBox();
            txtColegio = new TextBox();
            lblGrupo = new Label();
            cmbGrupo = new ComboBox();
            lblMateria = new Label();
            chkMateria = new CheckedListBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.Font = new Font("Segoe Print", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.DarkSlateBlue;
            btnCancelar.Location = new Point(457, 726);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(159, 68);
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
            btnRegistar.Location = new Point(235, 726);
            btnRegistar.Name = "btnRegistar";
            btnRegistar.Size = new Size(173, 68);
            btnRegistar.TabIndex = 24;
            btnRegistar.Text = "Registrar";
            btnRegistar.UseVisualStyleBackColor = false;
            btnRegistar.UseWaitCursor = true;
            btnRegistar.Click += btnRegistar_Click;
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreo.Location = new Point(78, 285);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(350, 38);
            txtCorreo.TabIndex = 23;
            txtCorreo.UseWaitCursor = true;
            // 
            // txtContrasenaRe
            // 
            txtContrasenaRe.BackColor = Color.White;
            txtContrasenaRe.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasenaRe.Location = new Point(78, 403);
            txtContrasenaRe.Name = "txtContrasenaRe";
            txtContrasenaRe.Size = new Size(350, 38);
            txtContrasenaRe.TabIndex = 22;
            txtContrasenaRe.UseWaitCursor = true;
            // 
            // lblTituloRe
            // 
            lblTituloRe.AutoSize = true;
            lblTituloRe.Font = new Font("Segoe Print", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloRe.Location = new Point(392, 33);
            lblTituloRe.Name = "lblTituloRe";
            lblTituloRe.Size = new Size(165, 61);
            lblTituloRe.TabIndex = 21;
            lblTituloRe.Text = "Registro";
            lblTituloRe.UseWaitCursor = true;
            // 
            // cmbRol
            // 
            cmbRol.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(77, 533);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(351, 39);
            cmbRol.TabIndex = 30;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCorreo.Location = new Point(78, 243);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(95, 40);
            lblCorreo.TabIndex = 31;
            lblCorreo.Text = "Correo";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContrasena.Location = new Point(78, 360);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(149, 40);
            lblContrasena.TabIndex = 32;
            lblContrasena.Text = "Contraseña";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRol.Location = new Point(78, 477);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(194, 40);
            lblRol.TabIndex = 33;
            lblRol.Text = "Seleccionar Rol";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(80, 123);
            label1.Name = "label1";
            label1.Size = new Size(110, 40);
            label1.TabIndex = 34;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(78, 165);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(351, 38);
            txtNombre.TabIndex = 35;
            txtNombre.UseWaitCursor = true;
            // 
            // lblTurno
            // 
            lblTurno.AutoSize = true;
            lblTurno.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTurno.Location = new Point(521, 243);
            lblTurno.Name = "lblTurno";
            lblTurno.Size = new Size(86, 40);
            lblTurno.TabIndex = 55;
            lblTurno.Text = "Turno";
            // 
            // lblColegio
            // 
            lblColegio.AutoSize = true;
            lblColegio.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblColegio.Location = new Point(517, 123);
            lblColegio.Name = "lblColegio";
            lblColegio.Size = new Size(98, 40);
            lblColegio.TabIndex = 54;
            lblColegio.Text = "Colegio";
            // 
            // cmbTurno
            // 
            cmbTurno.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTurno.FormattingEnabled = true;
            cmbTurno.Location = new Point(518, 286);
            cmbTurno.Name = "cmbTurno";
            cmbTurno.Size = new Size(351, 39);
            cmbTurno.TabIndex = 53;
            // 
            // txtColegio
            // 
            txtColegio.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtColegio.Location = new Point(517, 165);
            txtColegio.Name = "txtColegio";
            txtColegio.Size = new Size(350, 38);
            txtColegio.TabIndex = 56;
            txtColegio.UseWaitCursor = true;
            // 
            // lblGrupo
            // 
            lblGrupo.AutoSize = true;
            lblGrupo.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGrupo.Location = new Point(518, 359);
            lblGrupo.Name = "lblGrupo";
            lblGrupo.Size = new Size(89, 40);
            lblGrupo.TabIndex = 57;
            lblGrupo.Text = "Grupo";
            // 
            // cmbGrupo
            // 
            cmbGrupo.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbGrupo.FormattingEnabled = true;
            cmbGrupo.Location = new Point(517, 402);
            cmbGrupo.Name = "cmbGrupo";
            cmbGrupo.Size = new Size(351, 39);
            cmbGrupo.TabIndex = 58;
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMateria.Location = new Point(517, 477);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new Size(109, 40);
            lblMateria.TabIndex = 59;
            lblMateria.Text = "Materia";
            // 
            // chkMateria
            // 
            chkMateria.AccessibleName = "";
            chkMateria.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkMateria.FormattingEnabled = true;
            chkMateria.Items.AddRange(new object[] { "Matemáticas", "Química", "Física", "Biología", "Inglés", "Programación" });
            chkMateria.Location = new Point(523, 520);
            chkMateria.Name = "chkMateria";
            chkMateria.Size = new Size(346, 154);
            chkMateria.TabIndex = 60;
            // 
            // FrmRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(954, 854);
            Controls.Add(chkMateria);
            Controls.Add(lblMateria);
            Controls.Add(cmbGrupo);
            Controls.Add(lblGrupo);
            Controls.Add(txtColegio);
            Controls.Add(cmbTurno);
            Controls.Add(txtNombre);
            Controls.Add(cmbRol);
            Controls.Add(btnCancelar);
            Controls.Add(btnRegistar);
            Controls.Add(txtCorreo);
            Controls.Add(txtContrasenaRe);
            Controls.Add(lblTituloRe);
            Controls.Add(lblColegio);
            Controls.Add(lblTurno);
            Controls.Add(lblRol);
            Controls.Add(label1);
            Controls.Add(lblCorreo);
            Controls.Add(lblContrasena);
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
        private Label lblTurno;
        private Label lblColegio;
        private ComboBox cmbTurno;
        private TextBox txtColegio;
        private Label lblGrupo;
        private ComboBox cmbGrupo;
        private Label lblMateria;
        private CheckedListBox chkMateria;
    }
}