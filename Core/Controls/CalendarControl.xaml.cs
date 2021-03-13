using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Sports.Core.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sports.Core.Controls
{
    public partial class CalendarControl : ContentView
    {
        public ObservableCollection<WeekModel> ItemsSource { get; set; }

        public static readonly BindableProperty ItemsSourceProperty =
           BindableProperty
           .Create(
               propertyName: "ItemsSource",
               returnType: typeof(ObservableCollection<WeekModel>),
               declaringType: typeof(CalendarControl),
               defaultValue: null,
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: ItemsSourcePropertyChanged);

        private static int _index;
        private static CalendarControl _control;

        public CalendarControl()
        {
            InitializeComponent();
        }

        private static async void ItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }

        protected void CollectionViewMonths_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            collectionViewMonth.SelectedItem = null;
        }
    }
}
