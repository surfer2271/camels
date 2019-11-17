using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models
{
    public class Registration
    {
        [Required]
        public Guid? CompanyId { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Login: ")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 6)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Email Address: ")]
        public string Email { get; set; }

        //public string PasswordSalt { get; set; }

        [Required]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }
        [ScaffoldColumn(false)]
        public string UserType { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime CreatedDate { get; set; }
        [ScaffoldColumn(false)]
        public bool IsActive { get; set; }
        [ScaffoldColumn(false)]
        public string IPAddress { get; set; }

    }
}
