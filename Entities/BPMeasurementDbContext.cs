using Microsoft.EntityFrameworkCore;

namespace BPMeasurementApp.Entities
{
    public class BPMeasurementDbContext : DbContext
    {
        public BPMeasurementDbContext(DbContextOptions<BPMeasurementDbContext> options)
            : base(options)
        {
        }

        public DbSet<BPMeasurement> BPMeasurements { get; set; }

        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the foreign key relationship explicitly
           

            // Seed data for Positions
            modelBuilder.Entity<Position>().HasData(
                new Position() { PositionId = "1", Name = "Standing" },
                new Position() { PositionId = "2", Name = "Sitting" },
                new Position() { PositionId = "3", Name = "Lying down" }
            );

            // Seed data for BPMeasurements
            modelBuilder.Entity<BPMeasurement>().HasData(
                new BPMeasurement() { BPMeasurementId = 1, Systolic = 120, Diastolic = 80, MeasurementDate = DateTime.Now.AddDays(-5), PositionId = "2" },
                new BPMeasurement() { BPMeasurementId = 2, Systolic = 130, Diastolic = 85, MeasurementDate = DateTime.Now.AddDays(-4), PositionId = "1" },
                new BPMeasurement() { BPMeasurementId = 3, Systolic = 140, Diastolic = 90, MeasurementDate = DateTime.Now.AddDays(-3), PositionId = "3" },
                new BPMeasurement() { BPMeasurementId = 4, Systolic = 110, Diastolic = 75, MeasurementDate = DateTime.Now.AddDays(-2), PositionId = "2" },
                new BPMeasurement() { BPMeasurementId = 5, Systolic = 125, Diastolic = 80, MeasurementDate = DateTime.Now.AddDays(-1), PositionId = "1" }
            );
        }
    }
}
