using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInRecordsForgeinIdFromIntToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Doctors_DoctorId1",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Patients_PatientId1",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_DoctorId1",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_PatientId1",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "ApparatusId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "Records");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tenants",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Records",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Records",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Records_DoctorId",
                table: "Records",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_PatientId",
                table: "Records",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Doctors_DoctorId",
                table: "Records",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Patients_PatientId",
                table: "Records",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Doctors_DoctorId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Patients_PatientId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_DoctorId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_PatientId",
                table: "Records");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tenants",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ApparatusId",
                table: "Tenants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Records",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Records",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "DoctorId1",
                table: "Records",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientId1",
                table: "Records",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "Records",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Records_DoctorId1",
                table: "Records",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Records_PatientId1",
                table: "Records",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Doctors_DoctorId1",
                table: "Records",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Patients_PatientId1",
                table: "Records",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
