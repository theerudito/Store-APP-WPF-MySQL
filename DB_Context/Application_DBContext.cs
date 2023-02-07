using Microsoft.EntityFrameworkCore;
using Store.Models;
using System.Reflection;

namespace Store.DB_Context
{
    public class Application_DBContext : DbContext
    {

        protected static string _connectionString = "server=localhost;port=3306;user=root;password=erudito;database=WPFStore;";
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }
        public DbSet<MProduct> Products { get; set; }
        public DbSet<MClient> Clients { get; set; }
        public DbSet<MCart> Cart { get; set; }
        public DbSet<MDetailsCart> DetailsCart { get; set; }
        public DbSet<MCompany> Company { get; set; }
    }
}
