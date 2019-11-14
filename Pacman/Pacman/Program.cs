using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pacman.Controllers;
using Pacman.Models;
using Pacman.Models.Builder.ConcreteBuilder;
using Pacman.Models.Singleton;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman
{
    public class Program
    {
        static HttpClient client = new HttpClient();
        static string requestUri = "/api/players/";
        static string uri = "http://localhost:50924";

        public static async Task Main(string[] args)
        {
            IWebHost webHost = CreateWebHostBuilder(args).Build();
            using(var scope = webHost.Services.CreateScope())
            {
                //var myDbContext = scope.ServiceProvider.GetRequiredService<PacmanContext>();
                //await myDbContext.Database.MigrateAsync();
            }

            Logger logger = LoggerInit();
            await webHost.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:50924");

        public static Logger LoggerInit()
        {
            Logger logger = Logger.GetLogger();
            logger.Log("Logger created.");
            logger.Log("Test.");
            return logger;
        }

        static async Task<ICollection<Player>> GetAllPlayerAsync()
        {
            ICollection<Player> players = null;
            HttpResponseMessage response = await client.GetAsync(uri + requestUri);
            if (response.IsSuccessStatusCode)
            {
                players = await response.Content.ReadAsAsync<ICollection<Player>>();
            }
            return players;
        }
    }
}
