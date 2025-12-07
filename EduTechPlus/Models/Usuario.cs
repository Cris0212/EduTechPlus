public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string ContrasenaHash { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;

    public string Colegio { get; set; } = string.Empty;
    public string Turno { get; set; } = string.Empty;
    public string Grupo { get; set; } = string.Empty;

    public string? MateriasTexto { get; set; }
}