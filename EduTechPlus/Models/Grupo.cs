namespace EduTechPlus.Api.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;  // "12 A"
        public Turno Turno { get; set; }

        public int ColegioId { get; set; }
        public Colegio Colegio { get; set; } = null!;

        public ICollection<ProfesorGrupoMateria> Profesores { get; set; } = new List<ProfesorGrupoMateria>();
        public ICollection<AlumnoDetalle> Alumnos { get; set; } = new List<AlumnoDetalle>();
    }
}
