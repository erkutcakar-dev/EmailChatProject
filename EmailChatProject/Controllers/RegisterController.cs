﻿using Azure.Identity;
using EmailChatProject.Entities;
using EmailChatProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmailChatProject.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult NewUser()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> NewUser(RegisterViewModel model)
        {
            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Email = model.Email,
                Surname = model.Surname,
                UserName = model.UserName,

            };

            var result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("UserLogin", "Login");

            }
            else
            {
                foreach (var item in result.Errors)
                {

                    ModelState.AddModelError("", item.Description);
                }

                return View();
            }

        }


    }

}