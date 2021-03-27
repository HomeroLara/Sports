using System;
using System.Collections.Generic;
using Sports.Core.Models.Sports.NBA;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public class GetAllTeamsPayload
    {
        [JsonProperty("_internal")]
        public Internal Internal { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        public GetAllTeamsPayload()
        {
        }
    }

    public class League
    {
        [JsonProperty("standard")]
        public List<Team> Teams { get; set; }
        public List<object> africa { get; set; }
        public List<object> sacramento { get; set; }
        public List<object> vegas { get; set; }
        public List<object> utah { get; set; }
    }

    public partial class Standard
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
    }

    public partial class Internal
    {
        [JsonProperty("pubDateTime")]
        public string PubDateTime { get; set; }

        [JsonProperty("igorPath")]
        public string IgorPath { get; set; }

        [JsonProperty("xslt")]
        public string Xslt { get; set; }

        [JsonProperty("xsltForceRecompile")]
        public bool XsltForceRecompile { get; set; }

        [JsonProperty("xsltInCache")]
        public bool XsltInCache { get; set; }

        [JsonProperty("xsltCompileTimeMillis")]
        public long XsltCompileTimeMillis { get; set; }

        [JsonProperty("xsltTransformTimeMillis")]
        public long XsltTransformTimeMillis { get; set; }

        [JsonProperty("consolidatedDomKey")]
        public string ConsolidatedDomKey { get; set; }

        [JsonProperty("endToEndTimeMillis")]
        public long EndToEndTimeMillis { get; set; }
    }
}
