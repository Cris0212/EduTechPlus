using System.ComponentModel.DataAnnotations;

namespace EduTechPlus.Api.Models
{
    public class ProfesorDetalle
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public int ColegioId { get; set; }
        public Colegio Colegio { get; set; } = null!;

        public string Turno { get; set; } = string.Empty;

      
    }
}
