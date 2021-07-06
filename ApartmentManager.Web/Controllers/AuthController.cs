using ApartmentManager.Core.Models;
using ApartmentManager.Web.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.Controllers
{
    public class AuthController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return View(loginDto);

            var user = await _userManager.FindByEmailAsync(loginDto.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "Hesabınız yoktur!..");
                return View(loginDto);
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            ModelState.AddModelError("", "Kullanıcı adı veya parolanızı kontrol ediniz..");
            return View(loginDto);
        }
    }
}
