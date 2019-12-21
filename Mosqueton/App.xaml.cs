using System;
using Mosqueton.IoC;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mosqueton
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var container = new Container().Build();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
