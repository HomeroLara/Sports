using System;
using System.Threading.Tasks;
using Sports.Core.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AsyncAwaitBestPractices.MVVM;

namespace Sports.Core.ViewModels
{
    public class LoadingViewModel: ViewModelBase
    {
        #region PRIVATE MEMBERS
        private readonly INavigationService _navigationService;
        #endregion

        #region PUBLIC MEMBERS
        #endregion

        #region CONSTRUCTORS
        public LoadingViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

        #region METHODS
        #endregion

        #region OVERRIDES
        public override async Task ScalfoldViewModel(INavigationParameters parameters = null)
        {
            await Task.Delay(2000);
            await _navigationService.InitializeAsync(parameters);
        }
        #endregion
    }
}
