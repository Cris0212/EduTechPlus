using System.Linq;
using System.Threading.Tasks;
using EduTechPlus.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTechPlus.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var lista = await _context.Usuarios
                .AsNoTracking()
                .Select(u => new
                {
                    u.Id,
                    u.Nombre,
                    u.Correo,
                    u.Rol
                })
                .ToListAsync();

            return Ok(lista);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var u = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (u == null)
                return NotFound();

            return Ok(new
            {
                u.Id,
                u.Nombre,
                u.Correo,
                u.Rol
            });
        }
    }
}