using System.Security.Cryptography;
using System.Text;
using EduTechPlus.Api.Data;
using EduTechPlus.Api.Dtos;
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

        [HttpPost("register-profesor")]
        public async Task<IActionResult> RegisterProfesor([FromBody] RegisterProfesorDto dto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Correo == dto.Correo))
                return BadRequest("El correo ya está registrado.");

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                ContrasenaHash = HashPassword(dto.Contrasena),
                Rol = RolUsuario.Profesor
            };

            var detalle = new ProfesorDetalle
            {
                Usuario = usuario,
                ColegioId = dto.ColegioId,
                Turno = dto.Turno
            };

            _context.ProfesorDetalles.Add(detalle);
            await _context.SaveChangesAsync();

            // asignar materias a grupos
            var asignaciones = new List<ProfesorGrupoMateria>();
            foreach (var grupoId in dto.GruposIds)
            {
                foreach (var materiaId in dto.MateriasIds)
                {
                    asignaciones.Add(new ProfesorGrupoMateria
                    {
                        ProfesorId = usuario.Id,
                        GrupoId = grupoId,
                        MateriaId = materiaId
                    });
                }
            }
            _context.ProfesorGrupoMaterias.AddRange(asignaciones);
            await _context.SaveChangesAsync();

            return Ok(new { usuario.Id, usuario.Nombre, usuario.Correo, Rol = usuario.Rol.ToString() });
        }

        [HttpPost("register-alumno")]
        public async Task<IActionResult> RegisterAlumno([FromBody] RegisterAlumnoDto dto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Correo == dto.Correo))
                return BadRequest("El correo ya está registrado.");

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
                ContrasenaHash = HashPassword(dto.Contrasena),
                Rol = RolUsuario.Alumno
            };

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

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto dto)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.AlumnoDetalle)
                    .ThenInclude(a => a.Colegio)
                .Include(u => u.AlumnoDetalle)
                    .ThenInclude(a => a.Grupo)
                .Include(u => u.ProfesorDetalle)
                    .ThenInclude(p => p.Colegio)
                .SingleOrDefaultAsync(u => u.Correo == dto.Correo);

            if (usuario == null || usuario.ContrasenaHash != HashPassword(dto.Contrasena))
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

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
