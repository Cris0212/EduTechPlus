using EduTechPlus.Api.Models;
using System.Collections.Generic;

namespace EduTechPlus.Api.Dtos
{
    public class LoginRequestDto
    {
        public string Correo { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
    }

    public class LoginResponseDto
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Rol { get; set; } = null!;  // "Admin", "Profesor", "Alumno"

        public int? ColegioId { get; set; }
        public string? ColegioNombre { get; set; }
        public string? Turno { get; set; }
        public int? GrupoId { get; set; }
        public string? GrupoNombre { get; set; }
    }

    public class RegisterProfesorDto
    {
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contrasena { get; set; } = null!;

        public int ColegioId { get; set; }
        public Turno Turno { get; set; }

        public List<int> MateriasIds { get; set; } = new();
        public List<int> GruposIds { get; set; } = new();
    }

    public class RegisterAlumnoDto
    {
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contrasena { get; set; } = null!;

        public int ColegioId { get; set; }
        public Turno Turno { get; set; }
        public string NombreGrupo { get; set; } = null!; // "12 A"
    }
}
