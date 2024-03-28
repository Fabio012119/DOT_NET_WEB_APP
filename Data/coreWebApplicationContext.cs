using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using coreWebApplication.Models;

namespace coreWebApplication.Data
{
    public class coreWebApplicationContext : DbContext
    {
        public coreWebApplicationContext (DbContextOptions<coreWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<coreWebApplication.Models.User> User { get; set; } = default!;
    }
}
