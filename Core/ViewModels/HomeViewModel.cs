using System;
using System.Threading.Tasks;
using Sports.Core.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AsyncAwaitBestPractices.MVVM;

namespace Sports.Core.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        #region PRIVATE MEMBERS
        private readonly INavigationService _navigationService;
        #endregion

        #region PUBLIC MEMBERS
        #endregion

        #region COMMANDS
        #endregion

        #region CONSTRUCTORS
        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

        #region METHODS
        #endregion
    }
}
