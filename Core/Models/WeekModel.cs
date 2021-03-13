using System;
using System.Collections.Generic;

namespace Sports.Core.Models
{
    public class WeekModel
    {
        public int WeekNumber { get; set; }
        public IList<DateModel> Dates { get; set; }

        public WeekModel()
        {
            Dates = new List<DateModel>();
        }
    }
}
