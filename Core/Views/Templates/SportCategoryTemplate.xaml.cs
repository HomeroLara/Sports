using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Sports.Core.Models;
using Sports.Core.Models.Sports;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sports.Core.Views.Templates
{
    public partial class SportCategoryTemplate : ContentView
    {
        #region PRIVATE MEMBERS
        private static int _index;
        private static SportCategoryTemplate _control;
        #endregion

        #region BINDABLE PROPERTIES
        public ObservableCollection<Sport> ItemsSource { get; set; }

        public static readonly BindableProperty ItemsSourceProperty =
           BindableProperty
           .Create(
               propertyName: "ItemsSource",
               returnType: typeof(ObservableCollection<Sport>),
               declaringType: typeof(SportCategoryTemplate),
               defaultValue: null,
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: ItemsSourcePropertyChanged);


        public static readonly BindableProperty IsAppearingProperty =
            BindableProperty.Create(
                "IsAppearing"
                , typeof(bool)
                , typeof(SportCategoryTemplate)
                , false
                );
        #endregion


        public bool IsAppearing
        {
            get => (bool)GetValue(IsAppearingProperty);
            set
            {
                SetValue(IsAppearingProperty, value);
            }
        }

        public SportCategoryTemplate()
        {
            InitializeComponent();
        }

        void collectionViewSports_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            collectionViewSports.SelectedItem = null;
        }

        private static async void ItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var items = newValue as ObservableCollection<Sport>;
            await Task.Delay(250);
            _control.collectionViewSports.ScrollTo(1);
        }
    }
}
