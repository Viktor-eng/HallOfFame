using HallOfFame.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HallOfFame.Data.Configurations
{
    public class PersonConfigurations : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(n => n.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(n => n.DisplayName)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasMany(p => p.Skills)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
