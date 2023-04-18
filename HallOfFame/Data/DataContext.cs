using HallOfFame.Data.Configurations;
using HallOfFame.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace HallOfFame.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfigurations());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    
        public DbSet<Person> Persons { get; set; }

        public DbSet<Skill> Skills { get; set; }
    }
}
