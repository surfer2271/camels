using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models
{
    public class Login
    {
        public Guid? CompanyId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        // Company company { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("New UserName")]
        public string newUserName { get; set; }
        [DisplayName("New Password")]
        [ScaffoldColumn(false)]
        public string newPassword { get; set; }
    }
}
