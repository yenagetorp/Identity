using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityLad.Models;
using IdentityLad.Models.ViewModels;

namespace IdentityLad.Models
{
    public class MembersService
    {
        UserManager<MyidentityUser> userManager;
        SignInManager<MyidentityUser> signInManager;
        RoleManager<IdentityRole> roleManager;

        public MembersService(
            UserManager<MyidentityUser> userManager,
            SignInManager<MyidentityUser> signInManager, 
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        internal async Task<IdentityResult> CreateUserAsync(MembersCreateVM newMember)
        {
            return await userManager.CreateAsync(
                new MyidentityUser
                {
                    UserName = newMember.UserName,
                    FirstName =newMember.FirstName,
                    LastName =newMember.LastName
                },
                newMember.PassWord);
    }

        internal async Task<SignInResult> LoginUserAsync(MembersLoginVM member)
        {
            return await signInManager.PasswordSignInAsync(member.UserName, member.PassWord, false, false);
        }

        internal async Task LogOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
