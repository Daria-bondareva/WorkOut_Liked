using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites;

namespace Infrastructure.Configurations
{
    public class WorkOutConfiguration : IEntityTypeConfiguration<WorkOut>
    {
        public void Configure(EntityTypeBuilder<WorkOut> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(w => w.Description)
                .IsRequired();

            builder.Property(w => w.TrainingDuration)
                .IsRequired()
                .HasMaxLength(50);


            builder.OwnsOne(w => w.Price, p =>
            {
                p.Property(pp => pp.Amount)
                    .HasColumnName("PriceAmount")
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
                p.Property(pp => pp.Currency)
                    .HasColumnName("PriceCurrency")
                    .HasConversion<string>() 
                    .IsRequired();
            });
        }
    }
}
