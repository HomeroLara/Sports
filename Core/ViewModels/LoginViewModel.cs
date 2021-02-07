
using Sports.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sports.Core.ViewModels
{
    [QueryProperty("First", "first")]
    [QueryProperty("Last", "last")]
    public class LoginViewModel : ViewModelBase
    {
        #region PRIVATE MEMBERS
        #endregion

        #region PUBLIC MEMBERS        
        private string _first;
        public string First
        {
            set
            {
                _first = Uri.UnescapeDataString(value);
            }
        }

        #endregion

        #region COMMANDS
        public Command LoginCommand { get; }
        #endregion

        #region CONSTRUCTORS
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }
        #endregion

        #region METHODS      
        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
           // await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        public override Task ScalfoldViewModel(INavigationParameters parameters = null)
        {
            return base.ScalfoldViewModel(parameters);
        }
        #endregion
    }
}
