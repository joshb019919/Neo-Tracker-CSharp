using Microsoft.EntityFrameworkCore;
using Neo_Tracker_C_.Models;

namespace Neo_Tracker_C_.Data
{
    public class NeoTrackerDbContext : DbContext
    {
        public NeoTrackerDbContext(DbContextOptions<NeoTrackerDbContext> options)
            : base(options)
        {
        }

        public DbSet<NearEarthObject> NearEarthObjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NearEarthObject>()
                .HasKey(neo => neo.Id);
            // Add further configuration as needed
        }
    }
}
