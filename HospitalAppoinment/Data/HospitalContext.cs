using HospitalAppoinment.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppoinment.Data
{
    public class HospitalContext:DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {


        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<FamilyDoctor> FamilyDoctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentMedicine>()
                .HasKey(am => new { am.AppointmentId, am.MedicineId });

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
