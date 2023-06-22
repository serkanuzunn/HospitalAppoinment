using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalAppoinment.Migrations
{
    public partial class UpdateAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Appointments_AppointmentId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_AppointmentId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Medicines");

            migrationBuilder.AddColumn<bool>(
                name: "IsFamilyDoctorAppointment",
                table: "Appointments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AppointmentMedicine",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(nullable: false),
                    MedicineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentMedicine", x => new { x.AppointmentId, x.MedicineId });
                    table.ForeignKey(
                        name: "FK_AppointmentMedicine_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentMedicine_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentMedicine_MedicineId",
                table: "AppointmentMedicine",
                column: "MedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentMedicine");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsFamilyDoctorAppointment",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Medicines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_AppointmentId",
                table: "Medicines",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Appointments_AppointmentId",
                table: "Medicines",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
