using Microsoft.EntityFrameworkCore.Migrations;

namespace projeto.Migrations
{
    public partial class AdicionandoDelecaoBooleana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "vagas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "tecnologias",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "gfts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "funcionarios",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "vagas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tecnologias");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "gfts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "funcionarios");
        }
    }
}
