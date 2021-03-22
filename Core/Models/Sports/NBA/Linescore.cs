using System;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public partial class Linescore
    {
        [JsonProperty("score")]
        public long Score { get; set; }
    }
}
