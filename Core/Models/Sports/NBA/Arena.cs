using System;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public partial class Arena
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isDomestic")]
        public bool IsDomestic { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("stateAbbr")]
        public string StateAbbr { get; set; }
    }
}
