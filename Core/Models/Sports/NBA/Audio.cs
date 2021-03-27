using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public class Audio
    {

        [JsonProperty("national")]
        public HTeam National { get; set; }

        [JsonProperty("vTeam")]
        public HTeam VTeam { get; set; }

        [JsonProperty("hTeam")]
        public HTeam HTeam { get; set; }

        public Audio()
        {
        }
    }
}
