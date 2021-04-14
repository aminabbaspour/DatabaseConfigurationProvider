using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DatabaseConfigurationProvider.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseConfigurationProvider.Infrastructure.Seeds;

namespace DatabaseConfigurationProvider.Configuration
{
    public class DatabaseConfigurationProvider : ConfigurationProvider
    {
        private readonly Action<DbContextOptionsBuilder> _action;

        public DatabaseConfigurationProvider(Action<DbContextOptionsBuilder> action)
        {
            _action = action;
        }

        public override void Load()
        {
            var build = new DbContextOptionsBuilder<DatabaseConfigurationDbContext>();

            _action(build);

            using(var context = new DatabaseConfigurationDbContext(build.Options))
            {
                DefaultConfiguration.Seed(context);

                Data = context.Configurations.ToDictionary(c => c.Key, c => c.Value);
            }
        }

    }
}
