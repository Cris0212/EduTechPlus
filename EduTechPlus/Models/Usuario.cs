namespace EduTechPlus.Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string ContrasenaHash { get; set; } = null!;
        public RolUsuario Rol { get; set; }

        public ProfesorDetalle? ProfesorDetalle { get; set; }
        public AlumnoDetalle? AlumnoDetalle { get; set; }
    }
}

