using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models.Camels
{
    public class RegulatoryKnowledgeAssessment
    {
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int CapitalAdequacyRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AssestQualityRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int ManagementEffectivenessRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int CRAandTargetExamRatings { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int EarningsSustainabilityRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int LiquidityRiskRating { get; set; }
        [Range(1, 5, ErrorMessage = "Must be between 0 to 5")]
        public int SensitivitytoMarketRiskRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int Tier1CapitalRatio { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int TotalCapitalRatio { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AdverselyClassifiedItemsRatio { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int EfficiencyRatio { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int ROAA { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AdverselyStressedLiquidity { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AdverselyStressedNIM { get; set; }

    }
}
