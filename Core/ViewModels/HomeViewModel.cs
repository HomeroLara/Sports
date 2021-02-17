using System;
using System.Linq;
using System.Threading.Tasks;
using Sports.Core.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AsyncAwaitBestPractices.MVVM;
using Sports.Core.Models;
using Sports.Core.Helpers;

namespace Sports.Core.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        #region PRIVATE MEMBERS
        private readonly INavigationService _navigationService;
        private ObservableCollection<DateModel> _dates;
        private DateModel _selectedDate;
        #endregion

        #region PUBLIC MEMBERS
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
        public IAsyncCommand<DateModel> SelectDateCommand => new AsyncCommand<DateModel>(async (_) => await SelectDate(_), (_) => !IsBusy);
        #endregion

        #region CONSTRUCTORS
        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            LoadDates();
        }
        #endregion

        #region PUBLIC METHODS
        public override async Task ScalfoldViewModel(INavigationParameters parameters = null)
        {
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
        #endregion
    }
}
