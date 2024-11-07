using Domain.Entites;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class LikedContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WorkOut> WorkOuts { get; set; }
        public DbSet<SavedWorkout> SavedWorkouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WorkOutConfiguration());
            modelBuilder.ApplyConfiguration(new SavedWorkoutConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public LikedContext(DbContextOptions<LikedContext> options) : base(options)
        {
        }
    }
}
