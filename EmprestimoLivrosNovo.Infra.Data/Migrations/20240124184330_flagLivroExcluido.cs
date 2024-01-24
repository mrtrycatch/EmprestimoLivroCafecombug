using Microsoft.EntityFrameworkCore.Migrations;

namespace EmprestimoLivrosNovo.Infra.Data.Migrations
{
    public partial class flagLivroExcluido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Livro",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Livro");
        }
    }
}
