using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models.Camels
{
    public class OverallRegulatoryCaptialScores
    {
        public double CapitalAdequacyRating { get; set; }
        public double AssetQualityRating { get; set; }
        public double ManagementEffectivenessRating { get; set; }
        public double EarningsSustainableRating { get; set; }
        public double LiquidityRiskRating { get; set; }
        public double SensitivitytoMarketRiskRating { get; set; }
        

        public double AverageRegulatoryLeadership { get; set; }
        public double AverageRegulatoryResources { get; set; }
        public double AverageRegulatoryProcesses { get; set; }
        public double AverageRegulatoryCulture { get; set; }

        public double TotalRegulatoryScore { get; set; }
    }
}
