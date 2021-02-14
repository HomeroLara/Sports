using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Sports.Core;

namespace Sports.Core.Helpers
{
    public static class ThemeHelper
    {

        public static bool SetAppTheme()
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            mergedDictionaries.Add(new LiteTheme());
            return true;
        }
    }
}
