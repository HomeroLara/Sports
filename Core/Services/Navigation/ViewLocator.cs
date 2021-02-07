using System;
using Xamarin.Forms;
using Sports.Core.ViewModels;
using Rg.Plugins.Popup.Pages;
using Sports.Core.Models.Navigation;

namespace Sports.Core.Services
{
    public class ViewLocator : IViewLocator
    {
        public ViewLocatorResult CreatePageForViewModel(Type viewModelType)
        {
            var pageType = FindPageForViewModel(viewModelType, "View");
            var page = (ContentPage)Activator.CreateInstance(pageType);
            var nameSplit = pageType.FullName.Split('.');

            return new ViewLocatorResult { 
                ViewName = nameSplit[nameSplit.Length - 1],
                View = page,
                ViewModel = page.BindingContext as ViewModelBase
            };
        }

        public ViewLocatorResult CreatePageForViewModel<TViewModel>(TViewModel viewModel)
        {
            var pageType = FindPageForViewModel(viewModel.GetType(), "View");
            var page = (ContentPage)Activator.CreateInstance(pageType);
            var nameSplit = pageType.FullName.Split('.');

            return new ViewLocatorResult
            {
                ViewName = nameSplit[nameSplit.Length - 1],
                View = page,
                ViewModel = page.BindingContext as ViewModelBase
            };
        }
        public ViewLocatorResult CreateAndBindPageFor<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase
        {
            var pageType = FindPageForViewModel(viewModel.GetType(), "View");
            var page = (ContentPage)Activator.CreateInstance(pageType);
            page.BindingContext = viewModel;
            var nameSplit = pageType.FullName.Split('.');

            return new ViewLocatorResult
            {
                ViewName = nameSplit[nameSplit.Length - 1],
                View = page,
                ViewModel = page.BindingContext as ViewModelBase
            };
        }
        public ViewLocatorResult CreatePopupPageForPopupViewModel(Type popupViewModelType)
        {
            var pageType = FindPageForViewModel(popupViewModelType, "View");
            var page = (PopupPage)Activator.CreateInstance(pageType);
            var nameSplit = pageType.FullName.Split('.');

            return new ViewLocatorResult
            {
                ViewName = nameSplit[nameSplit.Length - 1],
                PopupView = page,
                ViewModel = page.BindingContext as ViewModelBase
            };
        }
        public ViewLocatorResult CreateAndBindPopupPageFor<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase
        {
            var pageType = FindPageForViewModel(viewModel.GetType(), "View");
            var page = (PopupPage)Activator.CreateInstance(pageType);
            page.BindingContext = viewModel;
            var nameSplit = pageType.FullName.Split('.');

            return new ViewLocatorResult
            {
                ViewName = nameSplit[nameSplit.Length - 1],
                PopupView = page,
                ViewModel = page.BindingContext as ViewModelBase
            };
        }
        protected virtual Type FindPageForViewModel(Type viewModelType, string viewFilter)
        {
            var pageTypeName = viewModelType
                .AssemblyQualifiedName
                .Replace("ViewModel", viewFilter);

            var pageType = Type.GetType(pageTypeName);
            if (pageType == null)
                throw new ArgumentException(pageTypeName + " type does not exist");

            return pageType;
        }
    }
}
