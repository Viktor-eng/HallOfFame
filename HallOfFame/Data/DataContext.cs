using HallOfFame.Models;
using Microsoft.EntityFrameworkCore;

namespace HallOfFame.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Skills)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Skill>().
                HasKey(p => p.Id);
        }
    
    public DbSet<Person> Persons => Set<Person>();

    }
}
