namespace EduTechPlus.Api.Models
{
    public class Grupo
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Turno { get; set; } = string.Empty;

        public int ColegioId { get; set; }
        public Colegio Colegio { get; set; }

        // Relación con alumnos (si la tienes)
        public ICollection<AlumnoDetalle> Alumnos { get; set; } = new List<AlumnoDetalle>();

        
    }
}