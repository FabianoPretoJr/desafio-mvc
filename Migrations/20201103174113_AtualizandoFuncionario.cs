using Microsoft.EntityFrameworkCore.Migrations;

namespace projeto.Migrations
{
    public partial class AtualizandoFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "funcionarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
