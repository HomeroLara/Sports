using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

using Sports.Core.ViewModels;
using Sports.Core.Services;
using Sports.Core;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Sports.Core.Helpers;
using Sports.Core.Views;

namespace Sports.Core.Services
{
    public class NavigationService : INavigationService
    {
        #region PRIVATE MEMBERS
        private readonly IViewLocator _viewLocator;
        private readonly ISettingsService _settingsService;
        private INavigation Navigator => Application.Current.MainPage.Navigation;
        #endregion

        #region PUBLIC MEMBERS
        public ViewModelBase PreviousViewModel => throw new NotImplementedException();
        #endregion

        #region CONSTRUCTORS
        public NavigationService(IViewLocator viewLocator, ISettingsService settingsService)
        {
            _viewLocator = viewLocator;
            _settingsService = settingsService;
        }
        #endregion

        #region IMPLEMENTATION
        public Task InitializeAsync(INavigationParameters parameters = null)
        {
            if (string.IsNullOrEmpty(_settingsService.AuthAccessToken))
                return NavigateTo<LoginViewModel>(parameters);
            else
                return NavigateTo<HomeViewModel>();
        }

        public async Task NavigateBack(INavigationParameters parameters = null)
        {
            var dismissing = Navigator
                .NavigationStack
                .Last()
                .BindingContext as ViewModelBase;

            await Shell.Current.Navigation.PopAsync();
            await dismissing?.DissmissViewModel(parameters);
        }

        public async Task NavigateBackToRoot(INavigationParameters parameters = null)
        {
            var toDismiss = Navigator
               .NavigationStack
               .Skip(1)
               .Select(vw => vw.BindingContext)
               .OfType<ViewModelBase>()
               .ToArray();

            await Shell.Current.Navigation.PopToRootAsync();

            foreach (var viewModel in toDismiss)
            {
                //FireAndForget since we're in a loop
                viewModel.DissmissViewModel(parameters).FireAndForget();
            }
        }

        public async Task NavigateToUri(string uri, INavigationParameters parameters = null)
        {
            var queryParameters = parameters?.ToQueryStringParameters();
            await Shell.Current.GoToAsync($"{uri}{queryParameters}");
        }

        public async Task NavigateTo<TViewModel>(INavigationParameters parameters = null) where TViewModel : ViewModelBase
        {
            //var viewLocatorResult = _viewLocator.CreatePageForViewModel(typeof(TViewModel));
            //var viewModel = (viewLocatorResult?.View?.BindingContext as ViewModelBase);

            //if (viewModel != null)
            //{
            //    await viewModel?.ScalfoldViewModel(parameters);
            //}
            var queryParameters = parameters?.ToQueryStringParameters();
            await Shell.Current.GoToAsync($"LoginView{queryParameters}", true);
            //await Shell.Current.GoToAsync($"{viewLocatorResult.ViewName}", true);
        }

        public async Task NavigateTo<TViewModel>(ViewModelBase currentViewModel, INavigationParameters parameters = null) where TViewModel : ViewModelBase
        {
            await NavigateTo<TViewModel>(parameters);
            await currentViewModel?.DissmissViewModel(null);
        }

        public async Task NavigateToPopup<TViewModel>(INavigationParameters parameters = null) where TViewModel : ViewModelBase
        {
            var viewLocatorResult = _viewLocator.CreatePopupPageForPopupViewModel(typeof(TViewModel));
            var viewModel = viewLocatorResult.PopupView?.BindingContext as ViewModelBase;
            await viewModel?.ScalfoldViewModel(parameters);
            await PopupNavigation.Instance.PushAsync(viewLocatorResult.PopupView, true);
        }
        #endregion

        #region PRIVATE METHODS
        private IEnumerable<ViewModelBase> FindViewModelsToDismiss(Page dismissingPage)
        {
            var viewmodels = new List<ViewModelBase>();

            if (dismissingPage is NavigationPage)
            {
                viewmodels.AddRange(
                    Navigator
                        .NavigationStack
                        .Select(p => p.BindingContext)
                        .OfType<ViewModelBase>()
                );
            }
            else
            {
                var viewmodel = dismissingPage?.BindingContext as ViewModelBase;
                if (viewmodel != null) viewmodels.Add(viewmodel);
            }

            return viewmodels;
        }

        private async void NavPagePopRequested(object sender, NavigationRequestedEventArgs e)
        {
            if (Navigator.NavigationStack.LastOrDefault()?.BindingContext is ViewModelBase poppingPage)
            {
                await poppingPage.DissmissViewModel();
            }
        }
        #endregion
    }
}
