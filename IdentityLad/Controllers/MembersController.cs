using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityLad.Models;
using IdentityLad.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityLad.Controllers
{
    public class MembersController : Controller
    {
        MembersService service;
        public MembersController(MembersService service)
        {
            this.service = service;
        }
        [Authorize]
        public IActionResult Index()
        {
            MembersIndexVM member = new MembersIndexVM
            {
                UserName = User.Identity.Name
            };
            return View(member);
        }

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(MembersLoginVM member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);
            }
            else
            {
               var result =  await service.LoginUserAsync(member);
                if (result.Succeeded)
                {
                 return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(member);
                } 
            }
        }

        [HttpGet]

        public async Task<IActionResult> LogOut()
        {
            await service.LogOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(MembersCreateVM newMember)
        {
            if (!ModelState.IsValid)
            {
                return View(newMember);
            }
            else
            {
                var result = await service.CreateUserAsync(newMember);
                if (result.Succeeded)
                {
                    ModelState.AddModelError(nameof(MembersCreateVM.UserName), "Invalid login credentials");
                    return RedirectToAction(nameof(Login));
                }
                else return View();
            }
        }
    }
}