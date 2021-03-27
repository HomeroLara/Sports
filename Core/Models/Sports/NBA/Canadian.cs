using System;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public class Canadian
    {
        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("longName")]
        public string LongName { get; set; }

        public Canadian()
        {
        }
    }
}
