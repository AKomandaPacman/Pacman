using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pacman.Models.Singleton;
using System.Threading.Tasks;

namespace Pacman
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IWebHost webHost = CreateWebHostBuilder(args).Build();

            using(var scope = webHost.Services.CreateScope())
            {
                //var myDbContext = scope.ServiceProvider.GetRequiredService<PacmanContext>();
                //await myDbContext.Database.MigrateAsync();
            }

            

            LoggerInit().GetAwaiter().GetResult();

            await webHost.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static async Task LoggerInit()
        {
            Logger logger = Logger.GetLogger();
            logger.Log("Logger created.");
            logger.Log("Test.");
        }
    }
}
