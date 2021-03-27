using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public class HTeam
    {

        [JsonProperty("streams")]
        public List<HTeamStream> Streams { get; set; }

        [JsonProperty("broadcasters")]
        public List<Canadian> Broadcasters { get; set; }

        public HTeam()
        {
        }
    }
}
