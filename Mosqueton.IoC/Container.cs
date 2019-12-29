using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mosqueton.Data;
using Mosqueton.Data.Interfaces;
using Mosqueton.IServices;
using Mosqueton.Services;
using Mosqueton.GameServices;
using Mosqueton.MonoGame.Infrastructure;

namespace Mosqueton.IoC
{
	public class Container
	{
		public IServiceProvider Build(Action<ServiceCollection> configure)
		{
			var serviceCollection = new ServiceCollection();

			serviceCollection.AddDbContext<GameContext>(opt => opt.UseInMemoryDatabase("GameDB").EnableSensitiveDataLogging());
			serviceCollection.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
			serviceCollection.AddScoped<IGameManager, GameManager>();
			serviceCollection.AddScoped<ILevelManager, LevelManager>();
            serviceCollection.AddScoped<ITextureStore, TextureStore>();

			configure?.Invoke(serviceCollection);

			return serviceCollection.BuildServiceProvider();
		}
	}
}