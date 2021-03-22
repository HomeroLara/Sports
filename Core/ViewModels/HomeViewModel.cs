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
        private readonly ISportsService _sportsService;
        private ObservableCollection<DateModel> _dates;
        private ObservableCollection<WeekModel> _weeks;
        private DateModel _selectedDate;
        private List<Sport> _sports;
        private ObservableCollection<object> _templateModels;
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

        public ObservableCollection<WeekModel> Weeks
        {
            get => _weeks;
            set
            {
                _weeks = value;
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

        public List<Sport> Sports
        {
            get => _sports;
            set
            {
                _sports = value;
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
        public IAsyncCommand<DateModel> SelectDateCommand => new AsyncCommand<DateModel>(async (_) => await SelectDate(_), (_) => !IsBusy);
        #endregion

        #region CONSTRUCTORS
        public HomeViewModel(INavigationService navigationService, ISportsService sportsService)
        {
            _navigationService = navigationService;
            _sportsService = sportsService;
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
                LoadDates();
                Sports = await _sportsService.GetSports();
                _templateModels.Add(Sports);

                var nbaViewModel = new NBAGameViewModel(_sportsService);
                await nbaViewModel.ScalfoldViewModel();
                _templateModels.Add(nbaViewModel);
            }
            catch(Exception ex)
            {
                var error = ex.Message;
                //TODO: error logging / reporting
            }
        }
        #endregion

        #region PRIVATE METHODS
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
        #endregion

        #region PRIVATE METHODS
        private async Task SelectDate(DateModel model)
        {
            if (model != null)
            {
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
            }
        }

        private int GetWeekNumberOfMonth(DateTime date)
        {
            date = date.Date;
            DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            if (firstMonthMonday > date)
            {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            }
            return (date - firstMonthMonday).Days / 7 + 1;
        }
        #endregion
    }
}
