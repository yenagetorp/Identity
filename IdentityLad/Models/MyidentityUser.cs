using IdentityLad.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLad.Models
{
    public class MyidentityUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }

  
}
