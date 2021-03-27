using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;

using Sports.Core.ViewModels;
using Sports.Core.Helpers;
using Sports.Core.Services;
using Xamarin.Forms;
using TinyIoC;

namespace Sports.Core.ViewModels
{
    public static class ViewModelLocator
    {
        private static TinyIoCContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty
            .CreateAttached("AutoWireViewModel",
                typeof(bool),
                typeof(ViewModelLocator),
                default(bool),
                propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static readonly BindableProperty AutoWireAndInitializeViewModelProperty =
            BindableProperty
            .CreateAttached("AutoWireAndInitializeViewModel",
                typeof(bool),
                typeof(ViewModelLocator),
                default(bool),
                propertyChanged: OnAutoWireAndAutoInitialize);

        public static bool GetAutoWireAndInitializeViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireAndInitializeViewModelProperty);
        }

        public static void SetAutoWireAndInitializeViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireAndInitializeViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        static ViewModelLocator()
        {
            _container = new TinyIoCContainer();

            //// View models - by default, TinyIoC will register concrete classes as multi-instance.
            _container.Register<HomeViewModel>();
            _container.Register<LoginViewModel>();
            _container.Register<LoadingViewModel>();

            //// Services - by default, TinyIoC will register interface registrations as singletons.
            _container.Register<INavigationParameters, NavigationParameters>();
            _container.Register<INavigationService, NavigationService>();
            _container.Register<ISettingsService, SettingsService>();
            _container.Register<INBASportService, NBASportService>();
        }

        public static void UpdateDependencies(bool useMockServices)
        {
            // Change injected dependencies
            if (useMockServices)
            {
                UseMockService = true;
            }
            else
            {
                UseMockService = false;
            }
        }

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>().AsSingleton();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewModel = GetViewModel(viewType);
            view.BindingContext = viewModel;
        }

        private static void OnAutoWireAndAutoInitialize(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewModel = GetViewModel(viewType);
            view.BindingContext = viewModel;
            viewModel?.ScalfoldViewModel().FireAndForget();
        }

        private static async void OnAutoWireAndAutoInitializeAsync(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewModel = GetViewModel(viewType);
            await viewModel?.ScalfoldViewModel();
        }

        private static ViewModelBase GetViewModel(Type viewType)
        {
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return null;
            }

            var viewModel = _container.Resolve(viewModelType) as ViewModelBase;
            return viewModel;
        }
    }
}
