using Foundation;
using Microsoft.Extensions.DependencyInjection;
using Mosqueton.Data;
using Mosqueton.IoC;
using UIKit;

namespace Mosqueton.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {       
        public override void FinishedLaunching(UIApplication application)
        {
            var container = new Container().Build(ConfigureServices);
            container.GetRequiredService<GameContext>().Seed();

            var game = container.GetRequiredService<Game>();           
            game.Run();
        }


        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Game>();
        }
    }
}
