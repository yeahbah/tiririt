using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Tiririt.Data.Internal;

namespace BatchSeedData
{
    public abstract class DataSeederBase
    {
        protected static TiriritDbContext CreateDbContext()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets("8c724486-0e01-4d42-bfff-aeda2705bfc7")
                .Build();

            var builder = new DbContextOptionsBuilder<TiriritDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseNpgsql(connectionString);

            return new TiriritDbContext(builder.Options, Options.Create(new OperationalStoreOptions()));
        }


    }
}
