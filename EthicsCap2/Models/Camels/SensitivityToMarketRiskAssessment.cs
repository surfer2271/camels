using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models.Camels
{
    public class SensitivityToMarketRiskAssessment
    {
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int SensitivityToMarketRiskRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AdverselyStressedNIM { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int SensitivityToMarketQuestion1 { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int SensitivityToMarketQuestion2 { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int SensitivityToMarketQuestion3 { get; set; }

        public int CompositeAverage { get; set; }
    }
}
