using Xamarin.Forms;

namespace Sports.Core.Views.Templates
{
    public partial class SportCategoryTemplate : ContentView
    {
        #region BINDABLE PROPERTIES
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
    }
}
