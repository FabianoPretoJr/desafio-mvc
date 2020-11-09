using Microsoft.EntityFrameworkCore.Migrations;

namespace projeto.Migrations
{
    public partial class AlterandoPopular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContDados",
                table: "popular");

            migrationBuilder.DropColumn(
                name: "ContLogin",
                table: "popular");

            migrationBuilder.AddColumn<string>(
                name: "ClaimCont",
                table: "popular",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ValueCont",
                table: "popular",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimCont",
                table: "popular");

            migrationBuilder.DropColumn(
                name: "ValueCont",
                table: "popular");

            migrationBuilder.AddColumn<bool>(
                name: "ContDados",
                table: "popular",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ContLogin",
                table: "popular",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
