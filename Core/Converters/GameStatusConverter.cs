using System;
using System.Globalization;
using Xamarin.Forms;

using Sports.Core.Models.Sports.NBA;

namespace Sports.Core.Converters
{
    public class GameStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var defaultColor = "#000000";
            if(value is GameTeamDTO game)
            {
                if(game.Game.IsGameActivated)
                {
                    return "#00CC00";
                }
            }

            return defaultColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
