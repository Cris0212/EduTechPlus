namespace EduTechPlus.Api.Models
{
    public class AlumnoDetalle
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public int ColegioId { get; set; }
        public Colegio Colegio { get; set; } = null!;

        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; } = null!;

        public ICollection<ResultadoQuiz> ResultadosQuiz { get; set; } = new List<ResultadoQuiz>();
    }
}
