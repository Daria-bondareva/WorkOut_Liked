using Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class SavedWorkoutConfiguration : IEntityTypeConfiguration<SavedWorkout>
    {
        public void Configure(EntityTypeBuilder<SavedWorkout> builder)
        {
            builder.HasKey(sw => sw.Id);

            builder.Property(sw => sw.SavedDate)
                .IsRequired();

            builder.Property(sw => sw.Notes)
                .HasMaxLength(500);


            builder.HasOne(sw => sw.User)
                .WithMany(u => u.SavedWorkouts)
                .HasForeignKey(sw => sw.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sw => sw.Workout)
                .WithMany(w => w.SavedWorkouts)
                .HasForeignKey(sw => sw.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
