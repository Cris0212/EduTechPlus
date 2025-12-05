using EduTechPlus.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTechPlus.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfesoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET /api/profesores/{profesorId}/grupos
        [HttpGet("{profesorId:int}/grupos")]
        public async Task<IActionResult> GetGrupos(int profesorId)
        {
            var grupos = await _context.ProfesorGrupoMaterias
                .Include(pgm => pgm.Grupo)
                    .ThenInclude(g => g.Colegio)
                .Where(pgm => pgm.ProfesorId == profesorId)
                .Select(pgm => pgm.Grupo)
                .Distinct()
                .ToListAsync();

            var result = grupos.Select(g => new
            {
                g.Id,
                g.Nombre,
                Turno = g.Turno.ToString(),
                Colegio = g.Colegio.Nombre
            });

            return Ok(result);
        }

        // GET /api/profesores/{profesorId}/grupos/{grupoId}/progreso
        [HttpGet("{profesorId:int}/grupos/{grupoId:int}/progreso")]
        public async Task<IActionResult> GetProgresoGrupo(int profesorId, int grupoId)
        {
            // validar que el grupo es del profesor
            bool pertenece = await _context.ProfesorGrupoMaterias
                .AnyAsync(pgm => pgm.ProfesorId == profesorId && pgm.GrupoId == grupoId);

            if (!pertenece)
                return BadRequest("El grupo no pertenece a este profesor.");

            var alumnos = await _context.AlumnoDetalles
                .Include(a => a.Usuario)
                .Include(a => a.ResultadosQuiz)
                .Where(a => a.GrupoId == grupoId)
                .ToListAsync();

            var data = alumnos.Select(a => new
            {
                AlumnoId = a.UsuarioId,
                Nombre = a.Usuario.Nombre,
                Correo = a.Usuario.Correo,
                Intentos = a.ResultadosQuiz.Count,
                Promedio = a.ResultadosQuiz.Any()
                    ? a.ResultadosQuiz.Average(r =>
                        (double)r.Puntaje / (r.TotalPreguntas == 0 ? 1 : r.TotalPreguntas) * 100.0)
                    : 0.0,
                UltimoIntento = a.ResultadosQuiz.OrderByDescending(r => r.Fecha).FirstOrDefault()?.Fecha
            });

            return Ok(data);
        }
    }
}
