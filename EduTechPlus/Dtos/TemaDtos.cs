namespace EduTechPlus.Api.Dtos
{
    public class CrearTemaDto
    {
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int MateriaId { get; set; }
        public string Grado { get; set; } = null!;
        public string Pais { get; set; } = "Panamá";
    }
}
