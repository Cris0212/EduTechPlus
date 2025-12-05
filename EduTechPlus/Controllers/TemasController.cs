using EduTechPlus.Api.Data;
using EduTechPlus.Api.Dtos;
using EduTechPlus.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTechPlus.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TemasController(AppDbContext context)
        {
            _context = context;
        }

        // GET /api/temas?materiaId=1&grado=12&pais=Panamá
        [HttpGet]
        public async Task<IActionResult> GetTemas([FromQuery] int? materiaId, [FromQuery] string? grado, [FromQuery] string? pais)
        {
            var query = _context.Temas
                .Include(t => t.Materia)
                .AsQueryable();

            if (materiaId.HasValue)
                query = query.Where(t => t.MateriaId == materiaId.Value);

            if (!string.IsNullOrWhiteSpace(grado))
                query = query.Where(t => t.Grado == grado);

            if (!string.IsNullOrWhiteSpace(pais))
                query = query.Where(t => t.Pais == pais);

            var temas = await query.ToListAsync();

            var result = temas.Select(t => new
            {
                t.Id,
                t.Titulo,
                t.Descripcion,
                t.Grado,
                t.Pais,
                t.EsOficial,
                Materia = t.Materia.Nombre
            });

            return Ok(result);
        }

        // POST /api/admin/temas (Tema oficial) 
        [HttpPost("admin")]
        public async Task<IActionResult> CrearTemaOficial([FromBody] CrearTemaDto dto)
        {
            var tema = new Tema
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                MateriaId = dto.MateriaId,
                Grado = dto.Grado,
                Pais = dto.Pais,
                EsOficial = true
            };

            _context.Temas.Add(tema);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTemas), new { id = tema.Id }, tema);
        }

        // POST /api/profesores/temas – tema creado por profesor
        [HttpPost("profesores/{profesorId:int}")]
        public async Task<IActionResult> CrearTemaProfesor(int profesorId, [FromBody] CrearTemaDto dto)
        {
            var profesor = await _context.Usuarios.FindAsync(profesorId);
            if (profesor == null || profesor.Rol != RolUsuario.Profesor)
                return BadRequest("Profesor inválido.");

            var tema = new Tema
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                MateriaId = dto.MateriaId,
                Grado = dto.Grado,
                Pais = dto.Pais,
                EsOficial = false,
                CreadorProfesorId = profesorId
            };

            _context.Temas.Add(tema);
            await _context.SaveChangesAsync();

            return Ok(tema);
        }
    }
}
