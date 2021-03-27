using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sports.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : BaseView
    {
        public HomeView()
        {
            InitializeComponent();
        }

        void collectionHomeMain_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            collectionHomeMain.SelectedItem = null;
        }
    }
}