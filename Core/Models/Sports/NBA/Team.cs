using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Sports.Core.Models.Sports.NBA
{
    public partial class Team
    {
        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("triCode")]
        public string TriCode { get; set; }

        [JsonProperty("win")]
        public long Win { get; set; }

        [JsonProperty("loss")]
        public long Loss { get; set; }

        [JsonProperty("seriesWin")]
        public string SeriesWin { get; set; }

        [JsonProperty("seriesLoss")]
        public string SeriesLoss { get; set; }

        [JsonProperty("score")]
        public string Score { get; set; }

        [JsonProperty("linescore")]
        public List<Linescore> Linescore { get; set; }

        public string LogoUri {
            //TODO: add default team logo incase Tricode is whitespace
            get { return $"nba_{TriCode}".ToLower(); }
        }
    }
}
