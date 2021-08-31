using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeliculasAPI.Migrations
{
    public partial class Peliculas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    resumen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trailer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enCines = table.Column<bool>(type: "bit", nullable: false),
                    fechaLanzamiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    poster = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PeliculasActores",
                columns: table => new
                {
                    peliculaId = table.Column<int>(type: "int", nullable: false),
                    actorId = table.Column<int>(type: "int", nullable: false),
                    personaje = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasActores", x => new { x.actorId, x.peliculaId });
                    table.ForeignKey(
                        name: "FK_PeliculasActores_Actores_actorId",
                        column: x => x.actorId,
                        principalTable: "Actores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculasActores_Peliculas_peliculaId",
                        column: x => x.peliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculasCines",
                columns: table => new
                {
                    peliculaId = table.Column<int>(type: "int", nullable: false),
                    cineId = table.Column<int>(type: "int", nullable: false),
                    generoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasCines", x => new { x.peliculaId, x.cineId });
                    table.ForeignKey(
                        name: "FK_PeliculasCines_Cines_cineId",
                        column: x => x.cineId,
                        principalTable: "Cines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculasCines_Generos_generoid",
                        column: x => x.generoid,
                        principalTable: "Generos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeliculasCines_Peliculas_peliculaId",
                        column: x => x.peliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculasGeneros",
                columns: table => new
                {
                    peliculaId = table.Column<int>(type: "int", nullable: false),
                    generoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasGeneros", x => new { x.peliculaId, x.generoId });
                    table.ForeignKey(
                        name: "FK_PeliculasGeneros_Generos_generoId",
                        column: x => x.generoId,
                        principalTable: "Generos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculasGeneros_Peliculas_peliculaId",
                        column: x => x.peliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasActores_peliculaId",
                table: "PeliculasActores",
                column: "peliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasCines_cineId",
                table: "PeliculasCines",
                column: "cineId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasCines_generoid",
                table: "PeliculasCines",
                column: "generoid");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasGeneros_generoId",
                table: "PeliculasGeneros",
                column: "generoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculasActores");

            migrationBuilder.DropTable(
                name: "PeliculasCines");

            migrationBuilder.DropTable(
                name: "PeliculasGeneros");

            migrationBuilder.DropTable(
                name: "Peliculas");
        }
    }
}
