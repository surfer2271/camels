using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models.Camels
{
    public class SensitivityToMarketRegulatoryAssessment
    {
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int SensitivitytoMarketRiskRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AdverselyStressedNIM { get; set; }


        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int RegulatoryLeadership { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int RegulatoryResources { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int RegulatoryProcesses { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int RegulatoryCulture { get; set; }

        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int TotalSensitivityToMarketRegulatoryScore { get; set; }
    }
}
