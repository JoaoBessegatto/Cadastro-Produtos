using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cadastro_Produtos.Migrations
{
    public partial class Inicialcriacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadastro");
        }
    }
}
