using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstSon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Apparatus_ApparatusId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_ApparatusId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ApparatusId",
                table: "Tenants");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Apparatus",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Apparatus_TenantId",
                table: "Apparatus",
                column: "TenantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apparatus_Tenants_TenantId",
                table: "Apparatus",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apparatus_Tenants_TenantId",
                table: "Apparatus");

            migrationBuilder.DropIndex(
                name: "IX_Apparatus_TenantId",
                table: "Apparatus");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Apparatus");

            migrationBuilder.AddColumn<int>(
                name: "ApparatusId",
                table: "Tenants",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ApparatusId",
                table: "Tenants",
                column: "ApparatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Apparatus_ApparatusId",
                table: "Tenants",
                column: "ApparatusId",
                principalTable: "Apparatus",
                principalColumn: "Id");
        }
    }
}
