using System;
using System.Threading.Tasks;
using Sports.Core.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AsyncAwaitBestPractices.MVVM;
using Sports.Core.Models.Sports.NBA;
using Sports.Core.Helpers;

namespace Sports.Core.ViewModels
{
    public class NBAScheduleViewModel : ViewModelBase
    {
        #region PRIVATE MEMBERS
        private readonly INBASportService _nbaSportsService;
        private ObservableCollection<Game> _games;
        private ObservableCollection<DateModel> _dates;
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

        public ObservableCollection<DateModel> Dates
        {
            get => _dates;
            set
            {
                _dates = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region COMMANDS
        public IAsyncCommand<Game> GameTappedCommand => new AsyncCommand<Game>(async(_) => await GameTapped(_), (_) => !IsBusy);
        #endregion

        #region CONSTRUCTORS
        public NBAScheduleViewModel(INBASportService nbaSportsService)
        {
            _nbaSportsService = nbaSportsService;
            LoadDates();
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

        #region METHODS
        private void LoadDates()
        {
            var dates = new List<DateModel>();
            var dateInit = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var dateEnd = new DateTime(dateInit.Year, dateInit.Month, DateTime.DaysInMonth(dateInit.Year, dateInit.Month));

            for (int i = 1; i <= dateEnd.Day; i++)
            {
                dates.Add(new DateModel()
                {
                    Day = string.Format("{0:00}", i),
                    Month = dateInit.ToString("MMM").FirstLetterUpperCase(),
                    DayWeek = new DateTime(dateInit.Year, dateInit.Month, i).DayOfWeek.ToString().Substring(0, 3),
                    Date = new DateTime(dateInit.Year, dateInit.Month, i),
                    Selected = i == DateTime.Today.Day,
                    BackgroundColor = i == DateTime.Today.Day ? "#252A37" : "Transparent",
                    FrameBorderColor = i == DateTime.Today.Day ? "#FFFFFF" : "#252A37",
                    TextColor = i == DateTime.Today.Day ? "#FFFFFF" : "#252A37",
                });
            }

            Dates = new ObservableCollection<DateModel>(dates);
        }

        private async Task GameTapped(Game game)
        {
            var g = game;
        }
        #endregion
    }
}
