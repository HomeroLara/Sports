using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Sports.Core.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sports.Core.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateControl : ContentView
    {
        public ObservableCollection<DateModel> ItemsSource { get; set; }

        public static readonly BindableProperty ItemsSourceProperty =
           BindableProperty
           .Create(
               propertyName: "ItemsSource",
               returnType: typeof(ObservableCollection<DateModel>),
               declaringType: typeof(DateControl),
               defaultValue: null,
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: ItemsSourcePropertyChanged);

        private static bool _datesSet;
        private static int _index;
        private static DateControl _control;

        public DateControl()
        {
            InitializeComponent();
        }


        private static async void ItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var items = newValue as ObservableCollection<DateModel>;

            if (items != null)
            {
                _control = (DateControl)bindable;

                _control.collectionViewDates.ItemsSource = items;

                _index = items
                    .ToList()
                    .FindIndex(p => p.Selected);

                if (_index < items.Count)
                    _index += 2;
            }

            await Task.Delay(250);
            _control.collectionViewDates.ScrollTo(_index);
        }
    }
}
