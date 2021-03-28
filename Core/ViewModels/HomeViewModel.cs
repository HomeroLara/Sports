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
    public class HomeViewModel: ViewModelBase
    {
        #region PRIVATE MEMBERS
        private readonly INavigationService _navigationService;
        private readonly INBASportService _nbaSportsService;
        private ObservableCollection<object> _templateModels;
        private ObservableCollection<Sport> _sports;
        #endregion

        #region PUBLIC MEMBERS
        public ObservableCollection<object> TemplateModels
        {
            get => _templateModels;
            set
            {
                _templateModels = value;
                OnPropertyChanged();
            }
        }

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

        #region CONSTRUCTORS
        public HomeViewModel(INavigationService navigationService, INBASportService nbaSportsService)
        {
            _navigationService = navigationService;
            _nbaSportsService = nbaSportsService;
            _templateModels = new ObservableCollection<object>();
        }
        #endregion

        #region PUBLIC METHODS

        public override void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query.Count > 0)
            {
                //TODO: setup models
            }
        }

        public override async Task ScalfoldViewModel(INavigationParameters parameters = null)
        {
            try
            {

                var sports = await _nbaSportsService.GetSports();
                Sports = new ObservableCollection<Sport>(sports);

                var nbaViewModel = new NBAScheduleViewModel(_nbaSportsService);
                await nbaViewModel.ScalfoldViewModel();
                _templateModels.Add(nbaViewModel);
            }
            catch(Exception ex)
            {
                //TODO: error logging / reporting
                var error = ex.Message;
            }
        }
        #endregion
    }
}
