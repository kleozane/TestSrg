using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
            
        }

        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
