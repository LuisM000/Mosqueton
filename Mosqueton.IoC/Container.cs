using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mosqueton.Data;
using Mosqueton.Data.Interfaces;

namespace Mosqueton.IoC
{
    public class Container
    {
        public IServiceProvider Build(Action<ServiceCollection> configure)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<GameContext>(opt => opt.UseInMemoryDatabase("GameDB"));
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            configure?.Invoke(serviceCollection);

            return serviceCollection.BuildServiceProvider();
        }
    }
}
