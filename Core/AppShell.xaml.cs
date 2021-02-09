using Sports.Core.ViewModels;
using Sports.Core.Views;
using System;
using Xamarin.Forms;
using Sports.Core.Services;

namespace Sports.Core
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        #region PRIVATE MEMBERS
        private readonly INavigationService _navigationService;
        #endregion
        public AppShell(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeComponent();

            Routing.RegisterRoute("main/login", typeof(LoginView));
            Routing.RegisterRoute(nameof(RegistrationView), typeof(RegistrationView));
            BindingContext = this;
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await _navigationService.NavigateTo("//login", null);
        }
    }
}
