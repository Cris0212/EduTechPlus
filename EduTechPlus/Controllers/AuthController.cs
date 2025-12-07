using EduTechPlus.Api.Data;
using EduTechPlus.Api.Dtos;
using EduTechPlus.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTechPlus.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<Usuario> _passwordHasher;

        public AuthController(AppDbContext context, IPasswordHasher<Usuario> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        // POST: api/auth/register-profesor
        [HttpPost("register-profesor")]
        public async Task<IActionResult> RegisterProfesor([FromBody] RegisterProfesorDto dto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Correo == dto.Correo))
                return BadRequest("El correo ya está registrado.");

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Rol = RolUsuario.Profesor
            };

            // Hash de la contraseña
            usuario.ContrasenaHash = _passwordHasher.HashPassword(usuario, dto.Contrasena);

            var detalle = new ProfesorDetalle
            {
                Usuario = usuario,
                ColegioId = dto.ColegioId,
                Turno = dto.Turno
            };

            _context.ProfesorDetalles.Add(detalle);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                usuario.Id,
                usuario.Nombre,
                usuario.Correo,
                Rol = usuario.Rol.ToString()
            });
        }

        // POST: api/auth/register-alumno
        [HttpPost("register-alumno")]
        public async Task<IActionResult> RegisterAlumno([FromBody] RegisterAlumnoDto dto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Correo == dto.Correo))
                return BadRequest("El correo ya está registrado.");

            // Buscar el grupo por nombre, turno y colegio
            var grupo = await _context.Grupos
                .Include(g => g.Colegio)
                .SingleOrDefaultAsync(g =>
                    g.Nombre == dto.NombreGrupo &&
                    g.Turno == dto.Turno &&
                    g.ColegioId == dto.ColegioId);

            if (grupo == null)
                return BadRequest("No existe ese grupo para el colegio y turno seleccionados.");

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Rol = RolUsuario.Alumno
            };

            // Hash de la contraseña
            usuario.ContrasenaHash = _passwordHasher.HashPassword(usuario, dto.Contrasena);

            var detalle = new AlumnoDetalle
            {
                Usuario = usuario,
                ColegioId = dto.ColegioId,
                GrupoId = grupo.Id
            };

            _context.AlumnoDetalles.Add(detalle);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                usuario.Id,
                usuario.Nombre,
                usuario.Correo,
                Rol = usuario.Rol.ToString(),
                Grupo = new
                {
                    grupo.Id,
                    grupo.Nombre,
                    Turno = grupo.Turno.ToString(),
                    Colegio = grupo.Colegio.Nombre
                }
            });
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto dto)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.AlumnoDetalle)
                    .ThenInclude(a => a.Colegio)
                .Include(u => u.AlumnoDetalle)
                    .ThenInclude(a => a.Grupo)
                .Include(u => u.ProfesorDetalle)
                    .ThenInclude(p => p.Colegio)
                .SingleOrDefaultAsync(u => u.Correo == dto.Correo);

            if (usuario == null)
                return Unauthorized("Correo o contraseña incorrectos.");

            // 🔐 Verificación del hash
            var result = _passwordHasher.VerifyHashedPassword(
                usuario,
                usuario.ContrasenaHash,
                dto.Contrasena
            );

            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Correo o contraseña incorrectos.");

            var response = new LoginResponseDto
            {
                UsuarioId = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Rol = usuario.Rol.ToString()
            };

            if (usuario.Rol == RolUsuario.Alumno && usuario.AlumnoDetalle != null)
            {
                response.ColegioId = usuario.AlumnoDetalle.ColegioId;
                response.ColegioNombre = usuario.AlumnoDetalle.Colegio.Nombre;
                response.GrupoId = usuario.AlumnoDetalle.GrupoId;
                response.GrupoNombre = usuario.AlumnoDetalle.Grupo.Nombre;
                response.Turno = usuario.AlumnoDetalle.Grupo.Turno.ToString();
            }
            else if (usuario.Rol == RolUsuario.Profesor && usuario.ProfesorDetalle != null)
            {
                response.ColegioId = usuario.ProfesorDetalle.ColegioId;
                response.ColegioNombre = usuario.ProfesorDetalle.Colegio.Nombre;
                response.Turno = usuario.ProfesorDetalle.Turno.ToString();
            }

            return Ok(response);
        }
    }
}
