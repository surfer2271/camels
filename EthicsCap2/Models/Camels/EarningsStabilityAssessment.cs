using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models.Camels
{
    public class EarningsStabilityAssessment
    {

        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int EarningsStabilityRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int ROAA { get; set; }
         [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int EarningsStabilityQuestion1 { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int EarningsStabilityQuestion2 { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int EarningsStabilityQuestion3 { get; set; }

        public int CompositeAverage { get; set; }
    }
}
