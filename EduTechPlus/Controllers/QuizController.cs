using EduTechPlus.Api.Data;
using EduTechPlus.Api.Dtos;
using EduTechPlus.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTechPlus.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuizController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("preguntas")]
        public async Task<IActionResult> CrearPregunta([FromBody] CrearPreguntaDto dto)
        {
            var pregunta = new Pregunta
            {
                TemaId = dto.TemaId,
                Enunciado = dto.Enunciado,
                RespuestaCorrecta = dto.RespuestaCorrecta,
                EsOficial = false
            };

            _context.Preguntas.Add(pregunta);
            await _context.SaveChangesAsync();

            return Ok(pregunta);
        }

        [HttpPost]
        public async Task<IActionResult> CrearQuiz([FromBody] CrearQuizDto dto)
        {
            var quiz = new Quiz
            {
                Titulo = dto.Titulo,
                TemaId = dto.TemaId,
                EsOficial = false
            };

            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();

            var orden = 1;
            foreach (var preguntaId in dto.PreguntasIds)
            {
                var qp = new QuizPregunta
                {
                    QuizId = quiz.Id,
                    PreguntaId = preguntaId,
                    Orden = orden++
                };
                _context.QuizPreguntas.Add(qp);
            }

            await _context.SaveChangesAsync();

            return Ok(quiz);
        }

        [HttpPost("resolver")]
        public async Task<IActionResult> ResolverQuiz([FromBody] ResolverQuizDto dto)
        {
            var quiz = await _context.Quizzes
                .Include(q => q.QuizPreguntas)
                    .ThenInclude(qp => qp.Pregunta)
                .SingleOrDefaultAsync(q => q.Id == dto.QuizId);

            if (quiz == null)
                return NotFound("Quiz no encontrado.");

            var alumno = await _context.AlumnoDetalles
                .Include(a => a.Usuario)
                .SingleOrDefaultAsync(a => a.UsuarioId == dto.AlumnoId);

            if (alumno == null)
                return BadRequest("Alumno inválido.");

            int total = quiz.QuizPreguntas.Count;
            int correctas = 0;

            foreach (var qp in quiz.QuizPreguntas)
            {
                if (dto.Respuestas.TryGetValue(qp.PreguntaId, out var respuesta))
                {
                    if (string.Equals(respuesta?.Trim(), qp.Pregunta.RespuestaCorrecta.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        correctas++;
                    }
                }
            }

            var resultado = new ResultadoQuiz
            {
                QuizId = quiz.Id,
                AlumnoId = alumno.UsuarioId,
                Alumno = alumno,
                Puntaje = correctas,
                TotalPreguntas = total
            };

            _context.ResultadosQuiz.Add(resultado);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                resultado.Id,
                resultado.Puntaje,
                resultado.TotalPreguntas,
                Porcentaje = total > 0 ? (double)correctas / total * 100.0 : 0
            });
        }
    }
}
