using System;
using System.Collections.Generic;
using Xamarin.Forms;

using Sports.Core.Views.Templates;
using Sports.Core.Models.Sports;
using Sports.Core.ViewModels;

namespace Sports.Core.Views.TemplateSelectors
{

    public class HomeViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NBAScheduleDataTemplate { get; set; }

        public DataTemplate NFLOverviewDataTemplate { get; set; }

        public DataTemplate NoGamesDataTemplate { get; set; }

        public HomeViewTemplateSelector()
        {

        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if(item is NBAScheduleViewModel)
            {
                if(NBAScheduleDataTemplate is null)
                {
                    NBAScheduleDataTemplate = new DataTemplate(typeof(NBAScheduleTemplate));
                }
                return NBAScheduleDataTemplate;
            }
            return new DataTemplate();
        }
    }
}
