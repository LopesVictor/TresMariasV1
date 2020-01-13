using Microsoft.EntityFrameworkCore.Migrations;

namespace TresMariasApi.Migrations
{
    public partial class migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "IsAuthenticated",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "facebookId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "googleId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "profileImage",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DestinationLatitude",
                table: "Route",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DestinationLongitude",
                table: "Route",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginLatitude",
                table: "Route",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginLongitude",
                table: "Route",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAuthenticated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "facebookId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "googleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "profileImage",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DestinationLatitude",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "DestinationLongitude",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "OriginLatitude",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "OriginLongitude",
                table: "Route");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
