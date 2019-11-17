using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models.Camels
{
    public class CapitalAdequacyAssessment
    {
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int CapitalAdequacyRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int Tier1CapitalRatio { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int TotalCapitalRatio { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int CapitalAdequacyQuestion1 { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int CapitalAdequacyQuestion2 { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int CapitalAdequacyQuestion3 { get; set; }

        public int CompositeAverage { get; set; }
}
}
