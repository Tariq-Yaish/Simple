using Simple.Models;

namespace Simple.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Company>? DBCompanies { get; set; }
        public DbSet<Employee>? DBEmployees { get; set; }
    }
}
