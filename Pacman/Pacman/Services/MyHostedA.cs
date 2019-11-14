using Microsoft.Extensions.Hosting;
using Pacman.Models.Builder.ConcreteBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman.Services
{
    public class MyHostedA : IHostedService
    {
        private Task task;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            task = BuildingAsync();

            if (task.IsCompleted)
            {
                return task;
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public static async Task BuildingAsync()
        {

            //ICollection<Player> players = await GetAllPlayerAsync();

            MapObjectsBuilder builder = new MapObjectsBuilder();
            //builder.AddPlayers((List<Player>)players);
            builder.CreateRandomItem();
        }
    }
}
