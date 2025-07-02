using Microsoft.EntityFrameworkCore;
using HospitalPatientRecords.Models;

namespace HospitalPatientRecords.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<Medication> Medications { get; set; } = null!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public static DatabaseContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlite("Data Source=HospitalRecords.db");
            return new DatabaseContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Medications)
                .WithOne(m => m.Patient)
                .HasForeignKey(m => m.PatientId);
        }
    }
} 