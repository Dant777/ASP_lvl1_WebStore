using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew.Entities;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User {UserName = model.UserName, Email = model.Email};
            var createResut = await _userManager.CreateAsync(user, model.Password);

            if (!createResut.Succeeded)
            {
                foreach (var identityError in createResut.Errors)
                {
                    ModelState.AddModelError("",identityError.Description);
                    return View(model);
                }
            }

            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }
    }
}