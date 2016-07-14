using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
