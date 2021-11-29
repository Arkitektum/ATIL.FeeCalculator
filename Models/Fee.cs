using System.Text.Json.Serialization;

namespace ATIL.FeeCalculator.Models
{
    public class Fee
    {
        [JsonPropertyName("Gebyrbeloep")]
        public int FeeAmount { get; set; }
        [JsonPropertyName("Gebyrkategori")]
        public string FeeCategory { get; set; }
    }
}
