namespace EduTechPlus.Api.Models
{
    public class ProfesorGrupoMateria
    {
        public int Id { get; set; }

        public int ProfesorId { get; set; }
        public Usuario Profesor { get; set; } = null!; // Rol = Profesor

        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; } = null!;

        public int MateriaId { get; set; }
        public Materia Materia { get; set; } = null!;
    }
}
