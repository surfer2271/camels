using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models.Camels
{
    public class AssetQualityAssessment
    {
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int CapitalAdequacyRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AdverselyClassifiedItemsRatio { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AssetQualityQuestion1 { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AssetQualityQuestion2 { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int AssetQualityQuestion3 { get; set; }

        public int CompositeAverage { get; set; }
    }
}
