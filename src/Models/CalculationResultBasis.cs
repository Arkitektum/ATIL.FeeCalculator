using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ATIL.FeeCalculator.Models
{
    public class CalculationResultBasis
    {
        [JsonPropertyName("gebyrbeloep")]
        public int FeeAmount { get; set; }
        [JsonPropertyName("gebyrkategori")]
        public string FeeCategory { get; set; }
    }
}
