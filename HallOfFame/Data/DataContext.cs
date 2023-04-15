using HallOfFame.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace HallOfFame.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        {

        }


        public DbSet<Person> Persons => Set<Person>();
    }
}
