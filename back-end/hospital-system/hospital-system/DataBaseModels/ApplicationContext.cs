using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospital_system.DataBaseModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace hospital_system.DataBaseModels
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=hospitalSystemApp.db");
        }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
            .HasOne<PatientMedicalRecord>(p => p.Grade)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.CurrentGradeId);
        }*/

        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Ward> Wards => Set<Ward>();
        public DbSet<PatientMedicalRecord> PatientMedicalRecords => Set<PatientMedicalRecord>();
        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<Treatment> Treatments => Set<Treatment>();

        
    }
}
