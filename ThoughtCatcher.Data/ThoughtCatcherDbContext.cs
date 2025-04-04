using Microsoft.EntityFrameworkCore;
using ThoughtCatcher.Core.Models;

namespace ThoughtCatcher.Data
{
    public class ThoughtCatcherDbContext : DbContext
    {
        public ThoughtCatcherDbContext(DbContextOptions<ThoughtCatcherDbContext> options)
            : base(options) { }

        public DbSet<Thought> ThoughtCatcher { get; set; }
    }
}
