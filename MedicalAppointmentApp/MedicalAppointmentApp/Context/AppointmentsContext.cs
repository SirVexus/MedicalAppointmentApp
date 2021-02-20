using MedicalAppointmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentApp.Context
{
    class AppointmentsContext : DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Visits> Visits { get; set; }
        public DbSet<VisitTime> VisitTime { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Appointments.db");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
