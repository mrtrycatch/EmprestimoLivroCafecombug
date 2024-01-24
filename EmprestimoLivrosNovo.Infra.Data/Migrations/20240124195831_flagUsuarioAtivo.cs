using Microsoft.EntityFrameworkCore.Migrations;

namespace EmprestimoLivrosNovo.Infra.Data.Migrations
{
    public partial class flagUsuarioAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Usuario");
        }
    }
}
