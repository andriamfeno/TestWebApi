using System.Text.Json.Serialization;

namespace LatelierWebApi.Models
{
    public partial class Data
    {
        [JsonPropertyName("rank")]
        public long Rank { get; set; }

        [JsonPropertyName("points")]
        public long Points { get; set; }

        [JsonPropertyName("weight")]
        public long Weight { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }

        [JsonPropertyName("age")]
        public long Age { get; set; }

        [JsonPropertyName("last")]
        public long[] Last { get; set; }
    }
}
