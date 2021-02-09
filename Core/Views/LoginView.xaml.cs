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
    public partial class LoginView : BaseView
    {
        public LoginView()
        {
            InitializeComponent();
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