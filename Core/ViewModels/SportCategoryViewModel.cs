using System;
using System.Linq;
using System.Threading.Tasks;
using Sports.Core.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AsyncAwaitBestPractices.MVVM;
using Sports.Core.Models;
using Sports.Core.Models.Sports;
using Sports.Core.Models.Sports.NBA;
using Sports.Core.Helpers;

namespace Sports.Core.ViewModels
{
    public class SportCategoryViewModel: ViewModelBase
    {
        #region PRIVATE MEMBERS
        private readonly INavigationService _navigationService;
        private readonly ISportsService _sportsService;
        private ObservableCollection<Sport> _sports;
        #endregion

        #region PUBLIC MEMBERS
        public ObservableCollection<Sport> Sports
        {
            get => _sports;
            set
            {
                _sports = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region COMMANDS
        #endregion

        #region CONSTRUCTORS
        public SportCategoryViewModel(ISportsService sportsService)
        {
            _sportsService = sportsService;
        }
        #endregion

        #region OVERRIDES
        public override async Task ScalfoldViewModel(INavigationParameters parameters = null)
        {
            var sports = await _sportsService.GetSports();
            Sports = new ObservableCollection<Sport>(sports);
        }
        #endregion

        #region METHODS
        #endregion
    }
}
