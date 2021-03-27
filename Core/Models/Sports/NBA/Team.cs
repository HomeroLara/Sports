using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public class Team
    {
        [JsonProperty("isNBAFranchise")]
        public bool IsNbaFranchise { get; set; }

        [JsonProperty("isAllStar")]
        public bool IsAllStar { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("altCityName")]
        public string AltCityName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("triCode")]
        public string TriCode { get; set; }

        [JsonProperty("teamId")]
        public long TeamId { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("urlName")]
        public string UrlName { get; set; }

        [JsonProperty("teamShortName")]
        public string TeamShortName { get; set; }

        [JsonProperty("confName")]
        public ConfName ConfName { get; set; }

        [JsonProperty("divName")]
        public string DivName { get; set; }

        [JsonProperty("loss")]
        public long Loss { get; set; }

        [JsonProperty("seriesWin")]
        public string SeriesWin { get; set; }

        [JsonProperty("seriesLoss")]
        public string SeriesLoss { get; set; }

        [JsonProperty("win")]
        public long Win { get; set; }

        [JsonProperty("score")]
        public string Score { get; set; }

        [JsonProperty("linescore")]
        public List<Linescore> Linescore { get; set; }

        public string Display
        {
            get {
                return $"{FullName} ( {Win} - {Loss} )";
            }
        }

        public string LogoUri
        {
            //TODO: add default team logo incase Tricode is whitespace
            get { return $"nba_{TriCode}".ToLower(); }
        }

        public Team()
        {
        }
    }
}
