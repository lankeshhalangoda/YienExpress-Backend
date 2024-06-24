using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class testing12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Couriers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Couriers");

            migrationBuilder.RenameColumn(
                name: "WeightInGrams",
                table: "Employees",
                newName: "PhoneNo");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Employees",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Condition",
                table: "Employees",
                newName: "Company");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Couriers",
                newName: "CourierName");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Couriers",
                newName: "Continent");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "Employees",
                newName: "WeightInGrams");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Employees",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Employees",
                newName: "Condition");

            migrationBuilder.RenameColumn(
                name: "CourierName",
                table: "Couriers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Continent",
                table: "Couriers",
                newName: "Gender");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Couriers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Couriers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
