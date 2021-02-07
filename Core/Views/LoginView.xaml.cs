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
    [QueryProperty("First", "first")]
    [QueryProperty("Last", "last")]
    public partial class LoginView : BaseView
    {
        private string _first;
        public string First
        {
            set
            {
                var t = this.BindingContext;
                _first = Uri.UnescapeDataString(value);
            }
        }

        private string _last;
        public string Last
        {
            set
            {
                _last = Uri.UnescapeDataString(value);
            }
        }
        public LoginView()
        {
            InitializeComponent();
            this.BindingContextChanged += LoginView_BindingContextChanged;
        }

        private void LoginView_BindingContextChanged(object sender, EventArgs e)
        {
            var t = this.BindingContext;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }


        protected override bool OnBackButtonPressed()
        {
            /*
             * Android users can press the Android back button 
             * and weasel their way out the login process
             */
            return true;
        }
    }
}