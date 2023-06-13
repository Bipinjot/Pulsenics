using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pulsenics.Models;

namespace Pulsenics.Data
{
    public class PulsenicsContext : DbContext
    {
        public PulsenicsContext (DbContextOptions<PulsenicsContext> options)
            : base(options)
        {
        }

        public DbSet<Pulsenics.Models.Movie> Movie { get; set; } = default!;
    }
}
