namespace EduTechPlus.Api.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;

        public int TemaId { get; set; }
        public Tema Tema { get; set; } = null!;

        public bool EsOficial { get; set; }
        public int? CreadorProfesorId { get; set; }
        public Usuario? CreadorProfesor { get; set; }

        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;

        public ICollection<QuizPregunta> QuizPreguntas { get; set; } = new List<QuizPregunta>();
        public ICollection<ResultadoQuiz> Resultados { get; set; } = new List<ResultadoQuiz>();
    }
}
