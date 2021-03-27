using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows.Input;

using Sports.Core.Models.Sports.NBA;

namespace Sports.Core.Views.Templates
{
    public partial class GameTemplate : ContentView
    {

        #region BINDABLE PROPERTIES
        public static readonly BindableProperty GetGameDetailsCommandProperty =
            BindableProperty.Create(
                "GetGameDetailsCommand"
                , typeof(ICommand)
                , typeof(GameTemplate)
                , null );

        public static readonly BindableProperty GameParameterProperty =
            BindableProperty.Create(
                "GameParameter"
                , typeof(Game)
                , typeof(GameTemplate)
                , null);

        #endregion

        #region PUBLIC MEMBERS
        public ICommand GetGameDetailsCommand
        {
            get => (ICommand)GetValue(GetGameDetailsCommandProperty);
            set
            {
                SetValue(GetGameDetailsCommandProperty, value);
            }
        }

        public Game GameParameter
        {
            get => (Game)GetValue(GameParameterProperty);
            set
            {
                SetValue(GameParameterProperty, value);
            }
        }
        #endregion
        public GameTemplate()
        {
            InitializeComponent();
        }
    }
}
