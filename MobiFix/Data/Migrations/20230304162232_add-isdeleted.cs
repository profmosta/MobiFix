using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobiFix.Data.Migrations
{
    public partial class addisdeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "Sales",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "PaidStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "FixStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isdeleted",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "isdeleted",
                table: "PaidStatuses");

            migrationBuilder.DropColumn(
                name: "isdeleted",
                table: "FixStatuses");

            migrationBuilder.DropColumn(
                name: "isdeleted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "isdeleted",
                table: "Brands");
        }
    }
}
