
using Sports.Core.Services;
using System.Threading.Tasks;
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
        public AsyncCommand LoginCommand => new AsyncCommand(async() => await Login(), (_) => !IsBusy);
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
            await _navigationService.NavigateTo("//home");
        }

        public override Task ScalfoldViewModel(INavigationParameters parameters = null)
        {
            return base.ScalfoldViewModel(parameters);
        }
        #endregion
    }
}
