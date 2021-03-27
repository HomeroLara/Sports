using System;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public class Broadcast
    {
        //[JsonProperty("broadcasters")]
        //public Broadcasters Broadcasters { get; set; }

        [JsonProperty("video")]
        public Video Video { get; set; }

        [JsonProperty("audio")]
        public Audio Audio { get; set; }

        public Broadcast()
        {
        }
    }
}
