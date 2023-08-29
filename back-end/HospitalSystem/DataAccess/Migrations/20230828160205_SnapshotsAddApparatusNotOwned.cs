using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SnapshotsAddApparatusNotOwned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apparatus_Functional",
                table: "Tenants");

            migrationBuilder.RenameColumn(
                name: "Apparatus_SerialNumber",
                table: "Tenants",
                newName: "ApparatusId");

            migrationBuilder.CreateTable(
                name: "Apparatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SerialNumber = table.Column<int>(type: "integer", nullable: false),
                    Functional = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apparatus", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Apparatus_ApparatusId",
                table: "Tenants");

            migrationBuilder.DropTable(
                name: "Apparatus");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_ApparatusId",
                table: "Tenants");

            migrationBuilder.RenameColumn(
                name: "ApparatusId",
                table: "Tenants",
                newName: "Apparatus_SerialNumber");

            migrationBuilder.AddColumn<int>(
                name: "Apparatus_Functional",
                table: "Tenants",
                type: "integer",
                nullable: true);
        }
    }
}
