using Football.Model;
using Microsoft.EntityFrameworkCore;

namespace Football.Data
{
    public class FootballContext:DbContext
    {
        public FootballContext(DbContextOptions<FootballContext> options) : base(options) { }

        public DbSet<Players> Players { get; set; } = null!;
        public DbSet<Club> Clubs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>().
                HasMany(c=>c.Players).
                WithOne(p=>p.Club).
                HasForeignKey(p=>p.ClubId).
                OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }

    }
}
