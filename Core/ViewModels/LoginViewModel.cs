using System;
using Sports.Core.Services;
using System.Threading.Tasks;
using AsyncAwaitBestPractices.MVVM;
using System.Collections.Generic;

namespace Sports.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region PRIVATE MEMBERS
        private readonly INavigationService _navigationService;
        private string _userName;
        private string _password;
        #endregion

        #region PUBLIC MEMBERS
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region COMMANDS
        public AsyncCommand LoginCommand => new AsyncCommand(async() => await Login(), (_) => !IsBusy);
        public AsyncCommand RegisterCommand => new AsyncCommand(async() => await Register(), (_) => !IsBusy);
        #endregion

        #region CONSTRUCTORS
        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            this.Title = "Login";
        }
        #endregion

        #region METHODS      
        private async Task Login()
        {
            try
            {
                IsBusy = true;
                await _navigationService.NavigateTo("//home");
            }
            catch(Exception ex)
            {
                //TODO: error logging
            }
            finally
            {
                IsBusy = false;
            }
        }

        public override void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query.Count > 0)
            {
            }
        }

        public override Task ScalfoldViewModel(INavigationParameters parameters = null)
        {
            return base.ScalfoldViewModel(parameters);
        }

        public async Task Register()
        {
            //todo: implement registration
        }
        #endregion
    }
}
