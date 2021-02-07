using System;
using Xamarin.Forms;
using Sports.Core.ViewModels;
using Rg.Plugins.Popup.Pages;
using Sports.Core.Models.Navigation;

namespace Sports.Core.Services
{
    public interface IViewLocator
    {
        ViewLocatorResult CreatePageForViewModel(Type viewModelType);
        ViewLocatorResult CreatePageForViewModel<TViewModel>(TViewModel viewModel);
        ViewLocatorResult CreateAndBindPageFor<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase;
        ViewLocatorResult CreatePopupPageForPopupViewModel(Type viewModelType);
        ViewLocatorResult CreateAndBindPopupPageFor<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase;
    }
}
