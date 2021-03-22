using System;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public partial class Game
    {
        [JsonProperty("seasonStageId")]
        public long SeasonStageId { get; set; }

        [JsonProperty("seasonYear")]
        public long SeasonYear { get; set; }

        [JsonProperty("leagueName")]
        public LeagueName LeagueName { get; set; }

        [JsonProperty("gameId")]
        public string GameId { get; set; }

        [JsonProperty("arena")]
        public Arena Arena { get; set; }

        [JsonProperty("isGameActivated")]
        public bool IsGameActivated { get; set; }

        [JsonProperty("statusNum")]
        public long StatusNum { get; set; }

        [JsonProperty("extendedStatusNum")]
        public long ExtendedStatusNum { get; set; }

        [JsonProperty("startTimeEastern")]
        public string StartTimeEastern { get; set; }

        [JsonProperty("startTimeUTC")]
        public DateTimeOffset StartTimeUtc { get; set; }

        [JsonProperty("endTimeUTC", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? EndTimeUtc { get; set; }

        [JsonProperty("startDateEastern")]
        public long StartDateEastern { get; set; }

        [JsonProperty("homeStartDate")]
        public long HomeStartDate { get; set; }

        [JsonProperty("homeStartTime")]
        public long HomeStartTime { get; set; }

        [JsonProperty("visitorStartDate")]
        public long VisitorStartDate { get; set; }

        [JsonProperty("visitorStartTime")]
        public long VisitorStartTime { get; set; }

        [JsonProperty("gameUrlCode")]
        public string GameUrlCode { get; set; }

        [JsonProperty("isBuzzerBeater")]
        public bool IsBuzzerBeater { get; set; }

        [JsonProperty("isPreviewArticleAvail")]
        public bool IsPreviewArticleAvail { get; set; }

        [JsonProperty("isRecapArticleAvail")]
        public bool IsRecapArticleAvail { get; set; }

        [JsonProperty("attendance")]
        public string Attendance { get; set; }

        [JsonProperty("hasGameBookPdf")]
        public bool HasGameBookPdf { get; set; }

        [JsonProperty("isStartTimeTBD")]
        public bool IsStartTimeTbd { get; set; }

        [JsonProperty("isNeutralVenue")]
        public bool IsNeutralVenue { get; set; }

        [JsonProperty("gameDuration")]
        public GameDuration GameDuration { get; set; }

        [JsonProperty("period")]
        public Period Period { get; set; }

        [JsonProperty("vTeam")]
        public Team VTeam { get; set; }

        [JsonProperty("hTeam")]
        public Team HTeam { get; set; }
    }
}
