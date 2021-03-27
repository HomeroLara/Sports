using System;
using Newtonsoft.Json;

namespace Sports.Core.Models.Sports.NBA
{
    public class VideoStream
    {
        [JsonProperty("streamType")]
        public StreamType StreamType { get; set; }

        [JsonProperty("isOnAir")]
        public bool IsOnAir { get; set; }

        [JsonProperty("doesArchiveExist")]
        public bool DoesArchiveExist { get; set; }

        [JsonProperty("isArchiveAvailToWatch")]
        public bool IsArchiveAvailToWatch { get; set; }

        [JsonProperty("streamId")]
        public string StreamId { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        public VideoStream()
        {
        }
    }
}
