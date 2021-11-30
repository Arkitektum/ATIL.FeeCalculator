using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ATIL.FeeCalculator.Models
{
    public class CalculationResult
    {
        [JsonPropertyName("beskrivelse")]
        public string Description { get; set; }
        [JsonPropertyName("tiltakstype")]
        public string Tiltakstype { get; set; }
        [JsonPropertyName("bygningstype")]
        public string Bygningstype { get; set; }
        [JsonPropertyName("areal")]
        public string Area { get; set; }
        [JsonPropertyName("gebyr")]
        public Fee Fee { get; set; }

    }
}
