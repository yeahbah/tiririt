using System;
using System.IO;
using System.Linq;
using Tiririt.App;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BatchSeedData
{
    class Program
    {
        private static IServiceProvider _serviceProvider;        

        static void Main(string[] args)
        {
            // arg 1 - stock quotes folder
            // yyyy / csv files
            if (args.Length < 1) 
            {
                Console.WriteLine("Tell me where the CSV files are located.");
                return;
            }
            RegisterServices();

            ProcessFiles(args[0]).GetAwaiter().GetResult();
        }

        private static async Task ProcessFiles(string src)
        {
            var sourceFolder = src;
            var dirs = Directory.GetDirectories(sourceFolder);
            var scope = _serviceProvider.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<StockQuoteDataSeed>();
            foreach (var dir in dirs)
            {
                var files = Directory.GetFiles(dir, "*.csv");
                foreach (var file in files)
                {
                    await seeder.ProcessFile(file);
                }
            }
        }

        private static void RegisterServices()
        {
           var services = new ServiceCollection()
            .AddAppServiceCollection()
            .AddTransient<StockQuoteDataSeed>();

          _serviceProvider = services.BuildServiceProvider(true);
        }

    }
}
