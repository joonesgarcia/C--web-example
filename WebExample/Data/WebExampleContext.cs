using Microsoft.EntityFrameworkCore;
using WebExample.Models;

namespace WebExample.Data
{
    public class WebExampleContext : DbContext
    {
        public WebExampleContext (DbContextOptions<WebExampleContext> options)
            : base(options)
        {
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<SpendsRecord> SpendsRecord { get; set; }
        public DbSet<Segment> Segment { get; set; }
    }
}
