using Sports.Core.Services;
using Sports.Core.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sports.Core.ViewModels;
using Sports.Core;
using Sports.Core.Helpers;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Sports.Core
{
    public partial class App : Xamarin.Forms.Application
    {

        public App()
        {
            InitializeComponent();
            On<iOS>().SetHandleControlUpdatesOnMainThread(true);
            var nav = new NavigationService(new SettingsService());

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
