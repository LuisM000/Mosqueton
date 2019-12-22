using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.Xna.Framework;
using Mosqueton.IoC;
using Microsoft.Extensions.DependencyInjection;


namespace Mosqueton.Droid
{
    [Activity(Label = "Mosqueton",
            MainLauncher = true,
            Icon = "@drawable/icon",
            Theme = "@style/Theme.Splash",
            AlwaysRetainTaskState = true,
            LaunchMode = LaunchMode.SingleInstance,
            ConfigurationChanges = ConfigChanges.Orientation |
            ConfigChanges.KeyboardHidden |
            ConfigChanges.Keyboard)]
    public class MainActivity : AndroidGameActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var container = new Container().Build(ConfigureServices);
            
            var game = container.GetService<Game>();
            SetContentView((View)game.Services.GetService(typeof(View)));
            game.Run();
        }


        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Game>();
        }
    }
}