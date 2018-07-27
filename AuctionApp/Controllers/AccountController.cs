using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using AuctionApp.Core.DAL.Enum;
using AuctionApp.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    Address = model.Address,
                    Country = model.Country,
                    PhoneNumber = model.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(true);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Role.customer);
                    await _signInManager.SignInAsync(user, false).ConfigureAwait(true);

                    return RedirectToAction("Index", "Manage", new { area = "customer" });
                }
                ModelState.AddModelError("", "Rejestracja nie powiodła się.");
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false).ConfigureAwait(true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Manage", new { area = "customer" });
                }
                if (result.IsLockedOut)
                {
                    return RedirectToAction("Lockout");
                }
                ModelState.AddModelError("", "Niudana próba logowania.");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync().ConfigureAwait(true);
            return RedirectToAction("Index", "Home");
        }
    }
}