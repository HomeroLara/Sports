using System;
using System.Collections.Generic;
using System.Text;
using Sports.Core.ViewModels;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;

namespace Sports.Core.Models.Navigation
{
    public class ViewLocatorResult
    {
        public string ViewName { get; set; }
        public ContentPage View { get; set; }
        public PopupPage PopupView { get; set; }
        public ViewModelBase ViewModel { get; set; }
    }
}
