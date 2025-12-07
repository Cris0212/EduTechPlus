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
    public class ColegiosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ColegiosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Colegios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colegio>>> GetColegios()
        {
            var lista = await _context.Colegios
                .Include(c => c.Grupos) // trae sus grupos
                .ToListAsync();

            return Ok(lista);
        }
    }
}