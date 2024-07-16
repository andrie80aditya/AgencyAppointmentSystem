using AgencyAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyAppointmentSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentSetting> AppointmentSettings { get; set; }
        public DbSet<Holiday> Holidays { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
