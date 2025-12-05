using static System.Collections.Specialized.BitVector32;

namespace EduTechPlus.Api.Models
{
    public class Tema
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }

        public int MateriaId { get; set; }
        public Materia Materia { get; set; } = null!;

        public string Grado { get; set; } = null!; 
        public string Pais { get; set; } = "Panamá";

        public bool EsOficial { get; set; }
        public int? CreadorProfesorId { get; set; }
        public Usuario? CreadorProfesor { get; set; }

        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;

        public ICollection<Leccion> Lecciones { get; set; } = new List<Leccion>();
        public ICollection<Pregunta> Preguntas { get; set; } = new List<Pregunta>();
        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
    }
}
