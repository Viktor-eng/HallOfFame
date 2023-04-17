using HallOfFame.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HallOfFame.Data.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(n => n.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.Level)
                .IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("[Level]", "[Level] > 0 AND [Level] <= 10").HasName("CK_Skill_Level"));
        }
    }
}
