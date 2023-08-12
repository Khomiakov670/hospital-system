using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Treatments_TreatmentId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Apparatuses_ApparatusId",
                table: "Tenants");

            migrationBuilder.DropTable(
                name: "Apparatuses");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_ApparatusId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Records_TreatmentId",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Wards",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "floor",
                table: "Wards",
                newName: "Floor");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "Wards",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "DayOfBirth",
                table: "User",
                newName: "DateOfBirth");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tenants",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Apparatus_Functiional",
                table: "Tenants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Apparatus_Id",
                table: "Tenants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Apparatus_SerialNumber",
                table: "Tenants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Treatment_Id",
                table: "Records",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Treatment_Medicines",
                table: "Records",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Treatment_Procedures",
                table: "Records",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Treatment_Recommendations",
                table: "Records",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apparatus_Functiional",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Apparatus_Id",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Apparatus_SerialNumber",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Treatment_Id",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Treatment_Medicines",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Treatment_Procedures",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Treatment_Recommendations",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Wards",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Floor",
                table: "Wards",
                newName: "floor");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Wards",
                newName: "capacity");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "User",
                newName: "DayOfBirth");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tenants",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "Apparatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Functiional = table.Column<int>(type: "INTEGER", nullable: false),
                    SerialNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apparatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Medicines = table.Column<string>(type: "TEXT", nullable: true),
                    Procedures = table.Column<string>(type: "TEXT", nullable: true),
                    Recommendations = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ApparatusId",
                table: "Tenants",
                column: "ApparatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_TreatmentId",
                table: "Records",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Treatments_TreatmentId",
                table: "Records",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Apparatuses_ApparatusId",
                table: "Tenants",
                column: "ApparatusId",
                principalTable: "Apparatuses",
                principalColumn: "Id");
        }
    }
}
