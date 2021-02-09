
using Sports.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AsyncAwaitBestPractices;
using AsyncAwaitBestPractices.MVVM;

namespace Sports.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region PRIVATE MEMBERS
        private readonly INavigationService _navigationService;
        #endregion

        #region PUBLIC MEMBERS
        #endregion

        #region COMMANDS
        public AsyncCommand LoginCommand => new AsyncCommand(async() => await Login());
        #endregion

        #region CONSTRUCTORS
        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

        #region METHODS      
        private async Task Login()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await _navigationService.NavigateTo("//home");
        }

        public override Task ScalfoldViewModel(INavigationParameters parameters = null)
        {
            return base.ScalfoldViewModel(parameters);
        }
        #endregion
    }
}
