namespace EduTechPlus.Api.Models
{
    public class QuizPregunta
    {
        public int Id { get; set; }

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = null!;

        public int PreguntaId { get; set; }
        public Pregunta Pregunta { get; set; } = null!;

        public int Orden { get; set; }
    }
}
