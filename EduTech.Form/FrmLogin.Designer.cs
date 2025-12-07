namespace EduTechPlus
{
    partial class FrmLogin
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
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            btnIniciar = new Button();
            lblContraseña = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe Print", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(377, 75);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(118, 61);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Login";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(245, 161);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(105, 40);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.White;
            txtUsuario.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(245, 199);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(372, 38);
            txtUsuario.TabIndex = 4;
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraseña.Location = new Point(245, 318);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(372, 38);
            txtContraseña.TabIndex = 5;
            // 
            // btnIniciar
            // 
            btnIniciar.BackColor = Color.DarkSlateBlue;
            btnIniciar.Font = new Font("Segoe Print", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciar.ForeColor = Color.White;
            btnIniciar.Location = new Point(377, 389);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(142, 64);
            btnIniciar.TabIndex = 7;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContraseña.Location = new Point(245, 275);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(149, 40);
            lblContraseña.TabIndex = 9;
            lblContraseña.Text = "Contraseña";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Lavender;
            ClientSize = new Size(864, 531);
            Controls.Add(lblContraseña);
            Controls.Add(btnIniciar);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblTitulo);
            Name = "FrmLogin";
            Text = "FrmLogin";
            TransparencyKey = Color.Transparent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Button btnIniciar;
        private Label lblContraseña;
    }
}