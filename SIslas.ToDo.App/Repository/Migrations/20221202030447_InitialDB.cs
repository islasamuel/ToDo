using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIslas.ToDo.App.Repository.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatEstatusTareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(80)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatEstatusTareas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalTareas = table.Column<int>(type: "int", nullable: false),
                    PorcentajeCompletada = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdMeta = table.Column<int>(type: "int", nullable: false),
                    IdEstatusTarea = table.Column<int>(type: "int", nullable: false),
                    Importante = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tareas_CatEstatusTareas_IdEstatusTarea",
                        column: x => x.IdEstatusTarea,
                        principalTable: "CatEstatusTareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tareas_Metas_IdMeta",
                        column: x => x.IdMeta,
                        principalTable: "Metas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CatEstatusTareas",
                columns: new[] { "Id", "Activo", "Descripcion" },
                values: new object[] { 1, true, "Abierta" });

            migrationBuilder.InsertData(
                table: "CatEstatusTareas",
                columns: new[] { "Id", "Activo", "Descripcion" },
                values: new object[] { 2, true, "Completada" });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_IdEstatusTarea",
                table: "Tareas",
                column: "IdEstatusTarea");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_IdMeta",
                table: "Tareas",
                column: "IdMeta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "CatEstatusTareas");

            migrationBuilder.DropTable(
                name: "Metas");
        }
    }
}
