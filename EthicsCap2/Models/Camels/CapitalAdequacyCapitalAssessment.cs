using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models.Camels
{
    public class CapitalAdequacyCapitalAssessment
    {
        
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AssetQualityRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AdverselyClassifiedItemsRatio  { get; set; }


        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int RegulatoryLeadership { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int RegulatoryResources   { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int RegulatoryProcesses   { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int RegulatoryCulture { get; set; }

        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int TotalCapitalRegulatoryScore { get; set; }
    }
}
