using System;
using System.Collections.Generic;
using Xamarin.Forms;

using Sports.Core.Views.Templates;
using Sports.Core.Models.Sports;

namespace Sports.Core.Views.TemplateSelectors
{

    public class HomeViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NBAOverviewDataTemplate { get; set; }

        public DataTemplate NFLOverviewDataTemplate { get; set; }

        public DataTemplate SportCategoryTemplate { get; set; }

        public DataTemplate NoGamesDataTemplate { get; set; }

        public HomeViewTemplateSelector()
        {

        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is List<Sport>)
            {
                if (SportCategoryTemplate is null)
                {
                    SportCategoryTemplate = new DataTemplate(typeof(SportCategoryTemplate));
                }
                return SportCategoryTemplate;
            }
            return new DataTemplate();
        }
    }
}
