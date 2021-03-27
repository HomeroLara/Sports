using System;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public class Watch
    {

        [JsonProperty("broadcast")]
        public Broadcast Broadcast { get; set; }

        public Watch()
        {
        }
    }
}
