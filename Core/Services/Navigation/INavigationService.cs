using System.Threading.Tasks;
using Sports.Core.ViewModels;

namespace Sports.Core.Services
{

    public interface INavigationService
    {
        ViewModelBase PreviousViewModel { get; }

        Task InitializeAsync(INavigationParameters parameters = null);

        Task NavigateToUri(string uri, INavigationParameters parameters = null);

        /// <summary>
        /// Navigate to the given page on top of the current navigation stack
        /// </summary>
        Task NavigateTo<TViewModel>(INavigationParameters parameters) where TViewModel : ViewModelBase;


        /// <summary>
        /// Navigate to the given page on top of the current navigation stack
        /// </summary>
        Task NavigateTo<TViewModel>(ViewModelBase currentViewModel, INavigationParameters parameters) where TViewModel : ViewModelBase;


        /// <summary>
        /// Navigate to the given popup page
        /// </summary>
        Task NavigateToPopup<TViewModel>(INavigationParameters parameters = null) where TViewModel : ViewModelBase;

        /// <summary>
        /// Navigate to the previous item in the navigation stack
        /// </summary>
        Task NavigateBack(INavigationParameters parameters);

        /// <summary>
        /// Navigate back to the element at the root of the navigation stack
        /// </summary>
        Task NavigateBackToRoot(INavigationParameters parameters);
    }
}
