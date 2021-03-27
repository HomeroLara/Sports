using System;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public class Tickets
    {
        [JsonProperty("mobileApp")]
        public Uri MobileApp { get; set; }

        [JsonProperty("desktopWeb")]
        public Uri DesktopWeb { get; set; }

        [JsonProperty("mobileWeb")]
        public Uri MobileWeb { get; set; }

        [JsonProperty("leagGameInfo")]
        public Uri LeagGameInfo { get; set; }

        [JsonProperty("leagTix")]
        public Uri LeagTix { get; set; }

        public Tickets()
        {
        }
    }
}
