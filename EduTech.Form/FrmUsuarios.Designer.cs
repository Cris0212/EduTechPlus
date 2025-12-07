namespace EduTechPlus
{
    partial class FrmUsuarios
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
            lblTituloU = new Label();
            dgvUsuarios = new DataGridView();
            btnActualizar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // lblTituloU
            // 
            lblTituloU.AutoSize = true;
            lblTituloU.Font = new Font("Segoe Print", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloU.Location = new Point(422, 46);
            lblTituloU.Name = "lblTituloU";
            lblTituloU.Size = new Size(168, 61);
            lblTituloU.TabIndex = 0;
            lblTituloU.Text = "Usuarios";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(65, 129);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(874, 444);
            dgvUsuarios.TabIndex = 1;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.DarkSlateBlue;
            btnActualizar.Font = new Font("Segoe Print", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(429, 579);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(161, 69);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(1027, 702);
            Controls.Add(btnActualizar);
            Controls.Add(dgvUsuarios);
            Controls.Add(lblTituloU);
            Name = "FrmUsuarios";
            Text = "FrmUsuarios";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloU;
        private DataGridView dgvUsuarios;
        private Button btnActualizar;
    }
}