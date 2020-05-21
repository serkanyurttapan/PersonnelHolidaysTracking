using Microsoft.EntityFrameworkCore;
using PersonnelHolidaysTracking.Core.Models;

namespace PersonnelHolidaysTracking.Data
{
    public class AsistPersonnelTrackingContext : DbContext
    {
        public AsistPersonnelTrackingContext(DbContextOptions<AsistPersonnelTrackingContext> options)
    : base(options)
        {
        }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<PersonnelHoliday> PersonnelHolidays { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
