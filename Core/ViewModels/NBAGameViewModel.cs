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
    public class NBAGameViewModel: ViewModelBase
    {
        #region PRIVATE MEMBERS
        private readonly ISportsService _sportsService;
        private ObservableCollection<Game> _games;
        #endregion

        #region PUBLIC MEMBERS
        public ObservableCollection<Game> Games
        {
            get => _games;
            set
            {
                _games = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region CONSTRUCTORS
        public NBAGameViewModel(ISportsService sportsService)
        {
            _sportsService = sportsService;
        }
        #endregion

        #region OVERRIDES
        public override async Task ScalfoldViewModel(INavigationParameters parameters = null)
        {
            try
            {
                GetGamesByDatePayload payload = await _sportsService.GetNBAGamesByDate(DateTime.Today);
                Games = new ObservableCollection<Game>(payload.Games);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                //TODO: error logging / reporting
            }
        }
        #endregion
    }
}
