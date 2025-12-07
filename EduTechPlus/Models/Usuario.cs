using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduTechPlus.Api.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Correo { get; set; } = string.Empty;

        //Contraseña encriptada con PasswordHasher
        [Required]
        public string ContrasenaHash { get; set; } = string.Empty;

        // Rol del usuario: Admin / Profesor / Alumno
        [Required]
        public RolUsuario Rol { get; set; }

        // Relación 1:1 a ProfesorDetalle
        public ProfesorDetalle? ProfesorDetalle { get; set; }

        // Relación 1:1 a AlumnoDetalle
        public AlumnoDetalle? AlumnoDetalle { get; set; }
    }

    public enum RolUsuario
    {
        Admin = 1,
        Profesor = 2,
        Alumno = 3
    }
}
