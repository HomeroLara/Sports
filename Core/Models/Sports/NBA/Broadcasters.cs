using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public class Broadcasters
    {
        [JsonProperty("national")]
        public List<Canadian> National { get; set; }

        [JsonProperty("canadian")]
        public List<Canadian> Canadian { get; set; }

        [JsonProperty("vTeam")]
        public List<Canadian> VTeam { get; set; }

        [JsonProperty("hTeam")]
        public List<Canadian> HTeam { get; set; }

        [JsonProperty("spanish_hTeam")]
        public List<object> SpanishHTeam { get; set; }

        [JsonProperty("spanish_vTeam")]
        public List<object> SpanishVTeam { get; set; }

        [JsonProperty("spanish_national")]
        public List<object> SpanishNational { get; set; }

        public Broadcasters()
        {
        }
    }
}
