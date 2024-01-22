using Microsoft.EntityFrameworkCore.Migrations;

namespace EmprestimoLivrosNovo.Infra.Data.Migrations
{
    public partial class permiteMultiplosLivrosEmprestados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Livro_IdLivro",
                table: "Emprestimo");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_IdLivro",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "IdLivro",
                table: "Emprestimo");

            migrationBuilder.AddColumn<int>(
                name: "LivroId",
                table: "Emprestimo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LivroEmprestado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmprestimo = table.Column<int>(type: "int", nullable: false),
                    IdLivro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroEmprestado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivroEmprestado_Emprestimo_IdEmprestimo",
                        column: x => x.IdEmprestimo,
                        principalTable: "Emprestimo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LivroEmprestado_Livro_IdLivro",
                        column: x => x.IdLivro,
                        principalTable: "Livro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_LivroId",
                table: "Emprestimo",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroEmprestado_IdEmprestimo",
                table: "LivroEmprestado",
                column: "IdEmprestimo");

            migrationBuilder.CreateIndex(
                name: "IX_LivroEmprestado_IdLivro",
                table: "LivroEmprestado",
                column: "IdLivro");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Livro_LivroId",
                table: "Emprestimo",
                column: "LivroId",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Livro_LivroId",
                table: "Emprestimo");

            migrationBuilder.DropTable(
                name: "LivroEmprestado");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_LivroId",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "Emprestimo");

            migrationBuilder.AddColumn<int>(
                name: "IdLivro",
                table: "Emprestimo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_IdLivro",
                table: "Emprestimo",
                column: "IdLivro");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Livro_IdLivro",
                table: "Emprestimo",
                column: "IdLivro",
                principalTable: "Livro",
                principalColumn: "Id");
        }
    }
}
