using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduTechPlus.Api.Data;
using EduTechPlus.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTechPlus.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MateriasController(AppDbContext context)
        {
            _context = context;
        }

        // =======================================
        // GET: api/Materias
        // Devuelve lista de materias
        // =======================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MateriaDto>>> GetMaterias()
        {
            var materias = await _context.Materias.ToListAsync();

            var resultado = materias.Select(m => new MateriaDto
            {
                Id = m.Id,
                Nombre = m.Nombre
            });

            return Ok(resultado);
        }

        // =======================================
        // GET: api/Materias/5
        // =======================================
        [HttpGet("{id}")]
        public async Task<ActionResult<MateriaDto>> GetMateria(int id)
        {
            var materia = await _context.Materias.FindAsync(id);

            if (materia == null)
                return NotFound();

            var dto = new MateriaDto
            {
                Id = materia.Id,
                Nombre = materia.Nombre
            };

            return Ok(dto);
        }

        // =======================================
        // POST: api/Materias
        // Crear materia simple
        // =======================================
        [HttpPost]
        public async Task<ActionResult<MateriaDto>> CrearMateria([FromBody] CrearMateriaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var materia = new Materia
            {
                Nombre = dto.Nombre
            };

            _context.Materias.Add(materia);
            await _context.SaveChangesAsync();

            var result = new MateriaDto
            {
                Id = materia.Id,
                Nombre = materia.Nombre
            };

            return CreatedAtAction(nameof(GetMateria), new { id = materia.Id }, result);
        }
    }

    // ==========================
    //      D T O S
    // ==========================

    public class MateriaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    public class CrearMateriaDto
    {
        public string Nombre { get; set; } = string.Empty;
    }
}