using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EduTechPlus.Api.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colegios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colegios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    ContrasenaHash = table.Column<string>(type: "text", nullable: false),
                    Rol = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Turno = table.Column<string>(type: "text", nullable: false),
                    ColegioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupos_Colegios_ColegioId",
                        column: x => x.ColegioId,
                        principalTable: "Colegios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfesorDetalles",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    ColegioId = table.Column<int>(type: "integer", nullable: false),
                    Turno = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesorDetalles", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_ProfesorDetalles_Colegios_ColegioId",
                        column: x => x.ColegioId,
                        principalTable: "Colegios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfesorDetalles_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    MateriaId = table.Column<int>(type: "integer", nullable: false),
                    Grado = table.Column<string>(type: "text", nullable: false),
                    Pais = table.Column<string>(type: "text", nullable: false),
                    EsOficial = table.Column<bool>(type: "boolean", nullable: false),
                    CreadorProfesorId = table.Column<int>(type: "integer", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temas_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Temas_Usuarios_CreadorProfesorId",
                        column: x => x.CreadorProfesorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlumnoDetalles",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    ColegioId = table.Column<int>(type: "integer", nullable: false),
                    GrupoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoDetalles", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_AlumnoDetalles_Colegios_ColegioId",
                        column: x => x.ColegioId,
                        principalTable: "Colegios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoDetalles_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoDetalles_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfesorGrupoMaterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfesorId = table.Column<int>(type: "integer", nullable: false),
                    GrupoId = table.Column<int>(type: "integer", nullable: false),
                    MateriaId = table.Column<int>(type: "integer", nullable: false),
                    ProfesorDetalleUsuarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesorGrupoMaterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfesorGrupoMaterias_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfesorGrupoMaterias_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfesorGrupoMaterias_ProfesorDetalles_ProfesorDetalleUsuar~",
                        column: x => x.ProfesorDetalleUsuarioId,
                        principalTable: "ProfesorDetalles",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_ProfesorGrupoMaterias_Usuarios_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lecciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Contenido = table.Column<string>(type: "text", nullable: false),
                    TemaId = table.Column<int>(type: "integer", nullable: false),
                    EsOficial = table.Column<bool>(type: "boolean", nullable: false),
                    CreadorProfesorId = table.Column<int>(type: "integer", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecciones_Temas_TemaId",
                        column: x => x.TemaId,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lecciones_Usuarios_CreadorProfesorId",
                        column: x => x.CreadorProfesorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Enunciado = table.Column<string>(type: "text", nullable: false),
                    RespuestaCorrecta = table.Column<string>(type: "text", nullable: false),
                    TemaId = table.Column<int>(type: "integer", nullable: false),
                    EsOficial = table.Column<bool>(type: "boolean", nullable: false),
                    CreadorProfesorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preguntas_Temas_TemaId",
                        column: x => x.TemaId,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preguntas_Usuarios_CreadorProfesorId",
                        column: x => x.CreadorProfesorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    TemaId = table.Column<int>(type: "integer", nullable: false),
                    EsOficial = table.Column<bool>(type: "boolean", nullable: false),
                    CreadorProfesorId = table.Column<int>(type: "integer", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Temas_TemaId",
                        column: x => x.TemaId,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quizzes_Usuarios_CreadorProfesorId",
                        column: x => x.CreadorProfesorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuizPreguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuizId = table.Column<int>(type: "integer", nullable: false),
                    PreguntaId = table.Column<int>(type: "integer", nullable: false),
                    Orden = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizPreguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizPreguntas_Preguntas_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Preguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizPreguntas_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResultadosQuiz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuizId = table.Column<int>(type: "integer", nullable: false),
                    AlumnoId = table.Column<int>(type: "integer", nullable: false),
                    Puntaje = table.Column<int>(type: "integer", nullable: false),
                    TotalPreguntas = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadosQuiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultadosQuiz_AlumnoDetalles_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "AlumnoDetalles",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultadosQuiz_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoDetalles_ColegioId",
                table: "AlumnoDetalles",
                column: "ColegioId");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoDetalles_GrupoId",
                table: "AlumnoDetalles",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_ColegioId",
                table: "Grupos",
                column: "ColegioId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_Nombre_Turno_ColegioId",
                table: "Grupos",
                columns: new[] { "Nombre", "Turno", "ColegioId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lecciones_CreadorProfesorId",
                table: "Lecciones",
                column: "CreadorProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecciones_TemaId",
                table: "Lecciones",
                column: "TemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_CreadorProfesorId",
                table: "Preguntas",
                column: "CreadorProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_TemaId",
                table: "Preguntas",
                column: "TemaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorDetalles_ColegioId",
                table: "ProfesorDetalles",
                column: "ColegioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorGrupoMaterias_GrupoId",
                table: "ProfesorGrupoMaterias",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorGrupoMaterias_MateriaId",
                table: "ProfesorGrupoMaterias",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorGrupoMaterias_ProfesorDetalleUsuarioId",
                table: "ProfesorGrupoMaterias",
                column: "ProfesorDetalleUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorGrupoMaterias_ProfesorId",
                table: "ProfesorGrupoMaterias",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizPreguntas_PreguntaId",
                table: "QuizPreguntas",
                column: "PreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizPreguntas_QuizId",
                table: "QuizPreguntas",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_CreadorProfesorId",
                table: "Quizzes",
                column: "CreadorProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_TemaId",
                table: "Quizzes",
                column: "TemaId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosQuiz_AlumnoId",
                table: "ResultadosQuiz",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosQuiz_QuizId",
                table: "ResultadosQuiz",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Temas_CreadorProfesorId",
                table: "Temas",
                column: "CreadorProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Temas_MateriaId",
                table: "Temas",
                column: "MateriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lecciones");

            migrationBuilder.DropTable(
                name: "ProfesorGrupoMaterias");

            migrationBuilder.DropTable(
                name: "QuizPreguntas");

            migrationBuilder.DropTable(
                name: "ResultadosQuiz");

            migrationBuilder.DropTable(
                name: "ProfesorDetalles");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.DropTable(
                name: "AlumnoDetalles");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Temas");

            migrationBuilder.DropTable(
                name: "Colegios");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
