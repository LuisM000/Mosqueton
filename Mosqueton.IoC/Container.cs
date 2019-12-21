using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mosqueton.Data;

namespace Mosqueton.IoC
{
    public class Container
    {
        public IServiceProvider Build()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<GameContext>(opt => opt.UseInMemoryDatabase("GameDB"));

            return serviceCollection.BuildServiceProvider();
        }
    }
}
