using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

using Sports.Core.Services;

namespace Sports.Core.ViewModels
{
    public class ViewModelBase: Observable
    {
        #region PRIVATE MEMBERS
        private bool _isBusy = false;
        private bool _isRefreshing = false;
        private bool _navigatedSuccessfully = false;
        private string title = string.Empty;
        #endregion

        #region PUBLIC MEMBERS
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public bool NavigatedSuccessfully
        {
            get => _navigatedSuccessfully;
            set
            {
                _navigatedSuccessfully = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region CONSTRUCTORS
        public ViewModelBase()
        {
        }
        #endregion


        /// <summary>
        /// Called exactly once, before the viewmodel enters the navigation stack
        /// </summary>
        public virtual Task ScalfoldViewModel(INavigationParameters parameters = null)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called exactly once, when the viewmodel leaves the navigation stack
        /// </summary>
        public virtual Task DissmissViewModel(INavigationParameters parameters = null)
        {
            return Task.CompletedTask;
        }

        // You may also wish to implement any of the following...
        //Task BeforeAppearing(); // Called before a viewmodel appears, when navigating either forwards or backwards
        //Task AfterAppearing(); // Called after a viewmodel appears, when navigating either forwards or backwards
        //Task BeforeNavigateAway(); // Called before a viewmodel disappears, when navigating either forwards or backwards
        //Task AfterNavigateAway(); // Called after a viewmodel disappears, when navigating either forwards or backwards+

    }
}
