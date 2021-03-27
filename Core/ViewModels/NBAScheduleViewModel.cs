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
    public class NBAScheduleViewModel : ViewModelBase
    {
        #region PRIVATE MEMBERS
        private readonly INBASportService _nbaSportsService;
        private ObservableCollection<Game> _games;
        private List<Team> _teams;
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
        public NBAScheduleViewModel(INBASportService nbaSportsService)
        {
            _nbaSportsService = nbaSportsService;
        }
        #endregion

        #region OVERRIDES
        public override async Task ScalfoldViewModel(INavigationParameters parameters = null)
        {
            try
            {
                var payload = await _nbaSportsService.GetNBAGamesByDate(DateTime.Today);
                Games = new ObservableCollection<Game>(payload.Games);

                var teamPayload = await _nbaSportsService.GetTeams();
                _teams = teamPayload.League.Teams;
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
