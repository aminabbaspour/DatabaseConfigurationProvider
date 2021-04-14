using Microsoft.EntityFrameworkCore;
using DatabaseConfigurationProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseConfigurationProvider.Infrastructure
{
    public class DatabaseConfigurationDbContext : DbContext
    {
        public DatabaseConfigurationDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Model.Configuration> Configurations { get; set; }

    }
}
