using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carometro.Infra.Data.Migrations
{
    public partial class Marcodeverasbonito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Turma = table.Column<string>(type: "varchar(15)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RG = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NumMatricula = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Senha = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
