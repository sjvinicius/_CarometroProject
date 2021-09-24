using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carometro.Infra.Data.Migrations
{
    public partial class ProjetoInicialFotoRemovido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.AlterColumn<int>(
                name: "TipoUsuario",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(200)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Alunos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(200)");

            migrationBuilder.AlterColumn<int>(
                name: "NumMatricula",
                table: "Alunos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(200)");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Alunos",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Alunos");

            migrationBuilder.AlterColumn<int>(
                name: "TipoUsuario",
                table: "Usuarios",
                type: "int(200)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Alunos",
                type: "int(200)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NumMatricula",
                table: "Alunos",
                type: "int(200)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FotoPath = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    IdAluno = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
    }
}
