using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows.Input;

using Sports.Core.Models.Sports.NBA;
using Sharpnado.Shades;

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
                , typeof(GameTeamDTO)
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

        public GameTeamDTO GameParameter
        {
            get => (GameTeamDTO)GetValue(GameParameterProperty);
            set
            {
                SetValue(GameParameterProperty, value);
            }
        }
        #endregion
        public GameTemplate()
        {
            InitializeComponent();
            this.BindingContextChanged += GameTemplate_BindingContextChanged;
        }

        private void GameTemplate_BindingContextChanged(object sender, EventArgs e)
        {
            //this kinda sucks. issue: sharpnado shadows are immutable
            //TODO: look to refactor. possibly use Xamarin Toolkit's Shades
            if (GameParameter != null)
            {
                var shade = new Shade();
                shade.BlurRadius = 10.0;
                shade.Opacity = 0.5;
                shade.Offset = new Point(10, 10);
                shade.Color = GameParameter.Game.IsGameActivated ? Color.FromHex("#00CC00") : Color.FromHex("#000000");
                shadows.Shades = new List<Shade>() { shade };
            }
        }
    }
}
