using System;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public class HTeamStream
    {
        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("isOnAir")]
        public bool IsOnAir { get; set; }

        [JsonProperty("streamId")]
        public string StreamId { get; set; }

        public HTeamStream()
        {
        }
    }
}
