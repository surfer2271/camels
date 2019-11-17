using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthicsCap2.Models
{
 

        public class Company
        {

            [Required]
            public Guid? CompanyId { get; set; }
            [Required]
            [Display(Name = "Company Name")]
            [StringLength(255, ErrorMessage = "Description Max Length is 255")]
            public string CompanyName { get; set; }
            [Required]
            [Display(Name = "Address")]
            [StringLength(255, ErrorMessage = "Description Max Length is 255")]
            public string Address { get; set; }
            [Required]
            [Display(Name = "Group Admin Token")]
            [StringLength(255, ErrorMessage = "Description Max Length is 255")]
            public string GroupAdminToken { get; set; }
            [Required]
            [Display(Name = "Assessment Token")]
            [StringLength(255, ErrorMessage = "Description Max Length is 255")]
            public string AssessmentToken { get; set; }

            /// <summary>
            /// for edits
            /// </summary
            ///    [Required]
            [Display(Name = "New Company Name")]
            [StringLength(255, ErrorMessage = "Description Max Length is 255")]
            public string newCompanyName { get; set; }
            [Display(Name = "New Address")]
            [StringLength(255, ErrorMessage = "Description Max Length is 255")]
            public string newAddress { get; set; }
            [Display(Name = "New Group Admin Token")]
            [StringLength(255, ErrorMessage = "Description Max Length is 255")]
            public string newGroupAdminToken { get; set; }
            [Display(Name = "New Assessment Token")]
            [StringLength(255, ErrorMessage = "Description Max Length is 255")]
            public string newAssessmentToken { get; set; }

            public Company() { }
        }


}
