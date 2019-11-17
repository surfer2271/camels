using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models.Camels
{
    public class RegulatoryAlignment
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

        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int CMeasurableAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int CLinkedAlignment  { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int CCommunicatedAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int CAccountableAlignment   { get; set; }


        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AMeasurableAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int ALinkedAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int ACommunicatedAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AAccountableAlignment { get; set; }

        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int MMeasurableAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int MLinkedAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int MCommunicatedAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int MAccountableAlignment { get; set; }

        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int EMeasurableAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int ELinkedAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int ECommunicatedAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int EAccountableAlignment { get; set; }

        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int LMeasurableAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int LLinkedAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int LCommunicatedAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int LAccountableAlignment { get; set; }

        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int SMeasurableAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int SLinkedAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int SCommunicatedAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int SAccountableAlignment { get; set; }

        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int TotalMeasurableAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int TotalLinkedAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int TotalCommunicatedAlignment { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int TotalAccountableAlignment { get; set; }

    }
}
