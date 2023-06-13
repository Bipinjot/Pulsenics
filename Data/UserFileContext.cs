using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pulsenics.Models;

namespace Pulsenics.Data
{
    public class UserFileContext : DbContext
    {
        public UserFileContext (DbContextOptions<UserFileContext> options)
            : base(options)
        {
        }

        public DbSet<Pulsenics.Models.User> User { get; set; } = default!;
    }
}
