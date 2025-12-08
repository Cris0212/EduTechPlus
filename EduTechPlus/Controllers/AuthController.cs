using System.Threading.Tasks;
using BCrypt.Net;
using EduTechPlus.Api.Data;
using EduTechPlus.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTechPlus.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Auth/registro
        [HttpPost("registro")]
        public async Task<IActionResult> Registro([FromBody] RegistroRequest dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 1. Verificar si el correo ya existe
            bool existe = await _context.Usuarios
                .AnyAsync(u => u.Correo == dto.Correo);

            if (existe)
                return BadRequest("El correo ya está registrado.");

            // 2. Crear objeto usuario
            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                ContrasenaHash = BCrypt.Net.BCrypt.HashPassword(dto.Contrasena),
                Rol = dto.Rol   // 1 = Alumno, 2 = Profesor
            };

            // 3. Guardar en BD
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // 4. Devolver datos sin contraseña
            return Ok(new
            {
                usuario.Id,
                usuario.Nombre,
                usuario.Correo,
                usuario.Rol
            });
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == dto.Correo);

            if (usuario == null)
                return Unauthorized("Correo o contraseña incorrectos.");

            bool ok = BCrypt.Net.BCrypt.Verify(dto.Contrasena, usuario.ContrasenaHash);
            if (!ok)
                return Unauthorized("Correo o contraseña incorrectos.");

            return Ok(new
            {
                usuario.Id,
                usuario.Nombre,
                usuario.Correo,
                usuario.Rol
            });
        }
    }

    public class RegistroRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public int Rol { get; set; }  // 1 = Alumno, 2 = Profesor
    }

    public class LoginRequest
    {
        public string Correo { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
    }
}