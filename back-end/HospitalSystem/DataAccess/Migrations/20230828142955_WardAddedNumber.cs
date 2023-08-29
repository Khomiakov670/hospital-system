using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class WardAddedNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apparatus_Functiional",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Treatment_Id",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "Apparatus_Id",
                table: "Tenants",
                newName: "Apparatus_Functional");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Wards",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Wards");

            migrationBuilder.RenameColumn(
                name: "Apparatus_Functional",
                table: "Tenants",
                newName: "Apparatus_Id");

            migrationBuilder.AddColumn<int>(
                name: "Apparatus_Functiional",
                table: "Tenants",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Treatment_Id",
                table: "Records",
                type: "integer",
                nullable: true);
        }
    }
}
