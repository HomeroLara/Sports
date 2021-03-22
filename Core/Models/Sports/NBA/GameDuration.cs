using System;
using Newtonsoft.Json;
namespace Sports.Core.Models.Sports.NBA
{
    public partial class GameDuration
    {
        [JsonProperty("hours")]
        public string Hours { get; set; }

        [JsonProperty("minutes")]
        public string Minutes { get; set; }
    }
}
