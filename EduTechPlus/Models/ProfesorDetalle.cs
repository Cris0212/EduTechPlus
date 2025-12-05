namespace EduTechPlus.Api.Models
{
    public class ProfesorDetalle
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public int ColegioId { get; set; }
        public Colegio Colegio { get; set; } = null!;

        public Turno Turno { get; set; }

        public ICollection<ProfesorGrupoMateria> ProfesoresGruposMaterias { get; set; } = new List<ProfesorGrupoMateria>();
    }
}
