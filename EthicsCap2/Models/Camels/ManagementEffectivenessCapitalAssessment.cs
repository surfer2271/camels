using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models.Camels
{
    public class ManagementEffectivenessCapitalAssessment
    {
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int ManagementEffectivenessRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int EfficiencyRatio { get; set; }


        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int RegulatoryLeadership { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int RegulatoryResources { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int RegulatoryProcesses { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int RegulatoryCulture { get; set; }

        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int TotalMgmtEffectivenessRegulatoryScore { get; set; }
    }
}
