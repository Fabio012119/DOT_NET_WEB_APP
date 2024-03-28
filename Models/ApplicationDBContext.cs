using Microsoft.EntityFrameworkCore;

namespace coreWebApplication.Models
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DEV2-GAMEOVER;Database=CodeFirstDB;Integrated Security=true;TrustServerCertificate=true;");
        }

    }
}
