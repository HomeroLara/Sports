using System;
using Newtonsoft.Json;
namespace Sports.Core.Models.Sports.NBA
{
    public partial class Period
    {
        [JsonProperty("current")]
        public long Current { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("maxRegular")]
        public long MaxRegular { get; set; }

        [JsonProperty("isHalftime")]
        public bool IsHalftime { get; set; }

        [JsonProperty("isEndOfPeriod")]
        public bool IsEndOfPeriod { get; set; }
    }
}
