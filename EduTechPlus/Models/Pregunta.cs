namespace EduTechPlus.Api.Models
{
    public class Pregunta
    {
        public int Id { get; set; }
        public string Enunciado { get; set; } = null!;
        public string RespuestaCorrecta { get; set; } = null!;

        public int TemaId { get; set; }
        public Tema Tema { get; set; } = null!;

        public bool EsOficial { get; set; }
        public int? CreadorProfesorId { get; set; }
        public Usuario? CreadorProfesor { get; set; }
    }
}
