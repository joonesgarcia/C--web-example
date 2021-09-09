using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<WebExample.Models.Product> Product { get; set; }
    }
}
