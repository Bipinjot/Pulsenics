using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pulsenics.Models;

namespace Pulsenics.Data
{
    public class FilesContext : DbContext
    {
        public FilesContext (DbContextOptions<FilesContext> options)
            : base(options)
        {
        }

        public DbSet<Pulsenics.Models.FileSystem> FileSystem { get; set; } = default!;
    }
}
