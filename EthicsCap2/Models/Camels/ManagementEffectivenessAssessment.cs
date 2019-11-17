using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models.Camels
{
    public class ManagementEffectivenessAssessment
    {

        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int ManagementEffectivenessRating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int CRARating { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int EfficeincyRatio { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int ManagementEffectivenessQuestion1 { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int ManagementEffectivenessQuestion2 { get; set; }
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int ManagementEffectivenessQuestion3 { get; set; }

        public int CompositeAverage { get; set; }
    }
}
