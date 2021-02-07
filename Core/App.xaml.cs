using Sports.Core.Services;
using Sports.Core.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sports.Core
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IViewLocator, ViewLocator>();
            DependencyService.Register<ISettingsService, SettingsService>();
            DependencyService.Register<INavigationService, NavigationService>();

            var nav = new NavigationService(new ViewLocator(), new SettingsService());

            MainPage = new AppShell(nav);
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
