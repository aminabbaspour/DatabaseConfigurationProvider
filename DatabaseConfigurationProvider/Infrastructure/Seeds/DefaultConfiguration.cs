using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseConfigurationProvider.Infrastructure.Seeds
{
    public static class DefaultConfiguration
    {
        public static void Seed(DatabaseConfigurationDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            bool isInitialized = dbContext.Configurations.Any();

            if (!isInitialized)
            {
                IEnumerable<Model.Configuration> configurations = new List<Model.Configuration>
                {
                    new Model.Configuration {Key = "FirstName", Value="Amin"},
                    new Model.Configuration {Key = "LastName", Value="Abbaspour"},
                    new Model.Configuration {Key = "Age", Value="33"},

                };


                dbContext.Configurations.AddRange(configurations);
                dbContext.SaveChanges();
            }
        }
    }
}
