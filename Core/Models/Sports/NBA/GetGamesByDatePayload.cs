using System;
using System.Collections.Generic;
using Sports.Core.Models.Sports.NBA;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public class GetGamesByDatePayload
    {
        [JsonProperty("numGames")]
        public int GameCount { get; set; }

        [JsonProperty("games")]
        public List<Game> Games { get; set; }
        
        public GetGamesByDatePayload()
        {
        }
    }
}
