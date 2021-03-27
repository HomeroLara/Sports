using System;
using System.Linq;
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
        private ObservableCollection<DateModel> _dates;
        private ObservableCollection<GameTeamDTO> _gameTeamDTOs;
        private DateModel _selectedDate;
        private List<Team> _teams;
        #endregion

        #region PUBLIC MEMBERS
        public ObservableCollection<GameTeamDTO> Games
        {
            get => _gameTeamDTOs;
            set
            {
                _gameTeamDTOs = value;
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

        public DateModel SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region COMMANDS
        public IAsyncCommand<Game> GameTappedCommand => new AsyncCommand<Game>(async(_) => await GameTapped(_), (_) => !IsBusy);
        public IAsyncCommand<DateModel> DateTappedCommand => new AsyncCommand<DateModel>(async(_) => await DateTapped(_), (_) => !IsBusy);
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
                var teamPayload = await _nbaSportsService.GetTeams();
                var payload = await _nbaSportsService.GetNBAGamesByDate(DateTime.Today);
                InstanceSettings.Session.NBATeams = teamPayload?.League?.Teams;
                _teams = teamPayload.League.Teams;

                await GetGames(DateTime.Today, _teams);
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

        #region PRIVATE METHODS
        private async Task DateTapped(DateModel model)
        {
            if (model != null)
            {
                SelectedDate = model;
                Dates.ToList().ForEach((item) =>
                {
                    item.Selected = false;
                    item.BackgroundColor = "Transparent";
                    item.TextColor = "#252A37";
                    item.FrameBorderColor = "#252A37";
                });

                var index = Dates.ToList().FindIndex(p => p.Day == model.Day && p.DayWeek == model.DayWeek);
                if (index > -1)
                {
                    Dates[index].BackgroundColor = "#252A37";
                    Dates[index].TextColor = "#FFFFFF";
                    Dates[index].FrameBorderColor = "#FFFFFF";
                    Dates[index].Selected = true;
                }

                await GetGames(SelectedDate.Date, _teams);
            }
        }

        private async Task GetGames(DateTime date, List<Team> teams)
        {
            var payload = await _nbaSportsService.GetNBAGamesByDate(date);
            InstanceSettings.Session.NBAGames = payload?.Games;
            Games = new ObservableCollection<GameTeamDTO>(payload.GetGameTeamDTOs(_teams));
        }
        #endregion
    }
}
