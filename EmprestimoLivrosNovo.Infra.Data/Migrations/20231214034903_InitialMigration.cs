using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmprestimoLivrosNovo.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CliCPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CliNome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CliEndereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CliCidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CliBairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CliNumero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CliTelefoneCelular = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CliTelefoneFixo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivroNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LivroAutor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LivroEditora = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LivroAnoPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LivroEdicao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdLivro = table.Column<int>(type: "int", nullable: false),
                    DataEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Entregue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Emprestimo_Livro_IdLivro",
                        column: x => x.IdLivro,
                        principalTable: "Livro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_IdCliente",
                table: "Emprestimo",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_IdLivro",
                table: "Emprestimo",
                column: "IdLivro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
