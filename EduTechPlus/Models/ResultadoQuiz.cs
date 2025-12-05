namespace EduTechPlus.Api.Models
{
    public class ResultadoQuiz
    {
        public int Id { get; set; }

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = null!;

        public int AlumnoId { get; set; }          // UsuarioId (Alumno)
        public AlumnoDetalle Alumno { get; set; } = null!;

        public int Puntaje { get; set; }
        public int TotalPreguntas { get; set; }

        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
