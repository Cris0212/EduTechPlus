namespace EduTechPlus.Api.Models
{
    public class Leccion
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Contenido { get; set; } = null!; 

        public int TemaId { get; set; }
        public Tema Tema { get; set; } = null!;

        public bool EsOficial { get; set; }
        public int? CreadorProfesorId { get; set; }
        public Usuario? CreadorProfesor { get; set; }

        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
    }
}
