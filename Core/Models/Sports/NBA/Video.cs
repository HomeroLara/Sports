using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public class Video
    {
        [JsonProperty("regionalBlackoutCodes")]
        public string RegionalBlackoutCodes { get; set; }

        [JsonProperty("canPurchase")]
        public bool CanPurchase { get; set; }

        [JsonProperty("isLeaguePass")]
        public bool IsLeaguePass { get; set; }

        [JsonProperty("isNationalBlackout")]
        public bool IsNationalBlackout { get; set; }

        [JsonProperty("isTNTOT")]
        public bool IsTntot { get; set; }

        [JsonProperty("isVR")]
        public bool IsVr { get; set; }

        [JsonProperty("tntotIsOnAir")]
        public bool TntotIsOnAir { get; set; }

        [JsonProperty("isNextVR")]
        public bool IsNextVr { get; set; }

        [JsonProperty("isNBAOnTNTVR")]
        public bool IsNbaOnTntvr { get; set; }

        [JsonProperty("isMagicLeap")]
        public bool IsMagicLeap { get; set; }

        [JsonProperty("isOculusVenues")]
        public bool IsOculusVenues { get; set; }

        [JsonProperty("streams")]
        public List<VideoStream> Streams { get; set; }

        [JsonProperty("deepLink")]
        public List<DeepLink> DeepLink { get; set; }

        public Video()
        {
        }
    }
}
