using System.Collections.Generic;

namespace EduTechPlus.Api.Dtos
{
    public class CrearPreguntaDto
    {
        public int TemaId { get; set; }
        public string Enunciado { get; set; } = null!;
        public string RespuestaCorrecta { get; set; } = null!;
    }

    public class CrearQuizDto
    {
        public string Titulo { get; set; } = null!;
        public int TemaId { get; set; }
        public List<int> PreguntasIds { get; set; } = new();
    }

    public class ResolverQuizDto
    {
        public int QuizId { get; set; }
        public int AlumnoId { get; set; }
        public Dictionary<int, string> Respuestas { get; set; } = new();
        // key = PreguntaId, value = respuesta del alumno
    }
}
