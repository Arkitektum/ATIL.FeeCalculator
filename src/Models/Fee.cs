using System.Text.Json.Serialization;

namespace ATIL.FeeCalculator.Models
{
    public class Fee
    {
        [JsonPropertyName("gebyrbeloep")]
        public int FeeAmount { get; set; }
        [JsonPropertyName("gebyrkategori")]
        public string FeeCategory { get; set; }
        [JsonPropertyName("gebyrkategoribeskrivelse")]
        public string FeeCategoryDescription { get; set; }
    }
}
