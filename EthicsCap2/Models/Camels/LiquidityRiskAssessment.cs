using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models.Camels
{
    public class LiquidityRiskAssessment
    {
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int LiquidityRiskRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AdverselyStressedLiquidityRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int LiquidityRiskQuestion1 { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int LiquidityRiskQuestion2 { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int LiquidityRiskQuestion3 { get; set; }

        public int CompositeAverage { get; set; }
    }
}
