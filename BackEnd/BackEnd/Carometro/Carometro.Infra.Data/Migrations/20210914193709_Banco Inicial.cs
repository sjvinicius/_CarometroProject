using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carometro.Infra.Data.Migrations
{
    public partial class BancoInicial : Migration
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
                    Senha = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FotoPath = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    IdAluno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotos_Alunos_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_IdAluno",
                table: "Fotos",
                column: "IdAluno",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
