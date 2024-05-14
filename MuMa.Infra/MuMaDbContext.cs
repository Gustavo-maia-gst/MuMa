using Microsoft.EntityFrameworkCore;
using MuMa.Domain.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuMa.EntityFramework
{
    public class MuMaDbContext : DbContext
    {
        public DbSet<Listener> Listeners { get; set; }

        public MuMaDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
