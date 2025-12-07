using System.Text.RegularExpressions;

namespace EduTechPlus.Api.Models
{
    public class Colegio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();
    }
}
