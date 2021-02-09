using Sports.Core.Services;
using Sports.Core.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sports.Core.ViewModels;

namespace Sports.Core
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
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
