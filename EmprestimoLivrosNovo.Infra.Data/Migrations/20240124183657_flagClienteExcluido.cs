using Microsoft.EntityFrameworkCore.Migrations;

namespace EmprestimoLivrosNovo.Infra.Data.Migrations
{
    public partial class flagClienteExcluido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Cliente",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Cliente");
        }
    }
}
