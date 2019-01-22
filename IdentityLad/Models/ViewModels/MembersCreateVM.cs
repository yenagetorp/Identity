using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLad.Models.ViewModels
{
    public class MembersCreateVM
    {

        [Display(Name = "Enter Username")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Enter First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Enter Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Enter Password")]
        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}
