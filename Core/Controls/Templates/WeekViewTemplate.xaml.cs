using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Sports.Core.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sports.Core.Controls.Templates
{
    public partial class WeekViewTemplate : ContentView
    {
        public ObservableCollection<DateModel> ItemsSource { get; set; }

        public static readonly BindableProperty ItemsSourceProperty =
           BindableProperty
           .Create(
               propertyName: "ItemsSource",
               returnType: typeof(ObservableCollection<DateModel>),
               declaringType: typeof(CalendarControl),
               defaultValue: null,
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: ItemsSourcePropertyChanged);

        private static int _index;
        private static CalendarControl _control;

        public WeekViewTemplate()
        {
            InitializeComponent();
        }

        private static async void ItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }
    }
}
