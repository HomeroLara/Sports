using System;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using Sports.Core.ViewModels;
using Sports.Core.Helpers;

namespace Sports.Core.Services
{
    public class NavigationService : INavigationService
    {
        #region PRIVATE MEMBERS
        private readonly ISettingsService _settingsService;
        private INavigation Navigator => Shell.Current.Navigation;
        #endregion

        #region PUBLIC MEMBERS
        public ViewModelBase PreviousViewModel { get; set; }
        public ViewModelBase CurrentViewModel { get; set; }
        #endregion

        #region CONSTRUCTORS
        public NavigationService(ISettingsService settingsService)
        { 
            _settingsService = settingsService;
        }
        #endregion

        #region IMPLEMENTATION
        public Task InitializeAsync(INavigationParameters parameters = null)
        {
            if (string.IsNullOrEmpty(_settingsService.AuthAccessToken))
            {
                return NavigateTo("///login", parameters);
            }
            else
            {
                return NavigateTo("///home", parameters);
            }
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

        public async Task NavigateTo(string route, INavigationParameters parameters = null)
        {
            if (parameters != null)
            {
                await Shell.Current.GoToAsync($"{route}{parameters.ToQueryStringParameters()}");
            }
            else
            {
                await Shell.Current.GoToAsync($"{route}", true);
            }
        }

        public async Task NavigateTo(string uri, ViewModelBase currentViewModel, INavigationParameters parameters = null)
        {
            await NavigateTo(uri, parameters);
            await currentViewModel?.DissmissViewModel(null);
        }
        #endregion
    }
}
