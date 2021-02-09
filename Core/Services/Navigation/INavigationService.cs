using System.Threading.Tasks;
using Sports.Core.ViewModels;

namespace Sports.Core.Services
{

    public interface INavigationService
    {
        ViewModelBase PreviousViewModel { get; }
        Task InitializeAsync(INavigationParameters parameters = null);
        Task NavigateTo(string route, INavigationParameters parameters = null);
        Task NavigateTo(string route, ViewModelBase currentViewModel, INavigationParameters parameters);
        Task NavigateBack(INavigationParameters parameters);
        Task NavigateBackToRoot(INavigationParameters parameters);
    }
}
