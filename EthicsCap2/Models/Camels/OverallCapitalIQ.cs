using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models.Camels
{
    public class OverallCapitalIQ
    {
        [Range(0, 5, ErrorMessage = "Must be between 0 to 5")]
        public int EnterValue { get; set; }

    }
}
