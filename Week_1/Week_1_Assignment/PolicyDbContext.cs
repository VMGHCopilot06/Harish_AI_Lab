using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Week_1_Assignment.Data
{
    public class PolicyDbContext : DbContext
    {
        public PolicyDbContext(DbContextOptions<PolicyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Policy> Policies { get; set; }
    }
}

