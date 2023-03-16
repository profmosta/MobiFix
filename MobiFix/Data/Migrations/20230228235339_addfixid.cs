using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobiFix.Data.Migrations
{
    public partial class addfixid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerNavigationId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_FixStatuses_StatusNavigationId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_PaidStatuses_PaidStatusNavigationId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CustomerNavigationId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CustomerNavigationId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "PaidStatus",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "StatusNavigationId",
                table: "Sales",
                newName: "PaidStatusId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Sales",
                newName: "FixStatusId");

            migrationBuilder.RenameColumn(
                name: "PaidStatusNavigationId",
                table: "Sales",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_StatusNavigationId",
                table: "Sales",
                newName: "IX_Sales_PaidStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_PaidStatusNavigationId",
                table: "Sales",
                newName: "IX_Sales_CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_FixStatusId",
                table: "Sales",
                column: "FixStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_FixStatuses_FixStatusId",
                table: "Sales",
                column: "FixStatusId",
                principalTable: "FixStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_PaidStatuses_PaidStatusId",
                table: "Sales",
                column: "PaidStatusId",
                principalTable: "PaidStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_FixStatuses_FixStatusId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_PaidStatuses_PaidStatusId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_FixStatusId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "PaidStatusId",
                table: "Sales",
                newName: "StatusNavigationId");

            migrationBuilder.RenameColumn(
                name: "FixStatusId",
                table: "Sales",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Sales",
                newName: "PaidStatusNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_PaidStatusId",
                table: "Sales",
                newName: "IX_Sales_StatusNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                newName: "IX_Sales_PaidStatusNavigationId");

            migrationBuilder.AddColumn<int>(
                name: "Customer",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerNavigationId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaidStatus",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerNavigationId",
                table: "Sales",
                column: "CustomerNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerNavigationId",
                table: "Sales",
                column: "CustomerNavigationId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_FixStatuses_StatusNavigationId",
                table: "Sales",
                column: "StatusNavigationId",
                principalTable: "FixStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_PaidStatuses_PaidStatusNavigationId",
                table: "Sales",
                column: "PaidStatusNavigationId",
                principalTable: "PaidStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
