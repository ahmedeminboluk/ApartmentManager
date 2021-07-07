using ApartmentManager.Core.Models;
using ApartmentManager.Core.Services;
using ApartmentManager.Data.Context;
using ApartmentManager.Web.DTOs;
using ApartmentManager.Web.Enum;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IMapper mapper, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var userList = await _userService.GetAllAsync();
            var detailUser = _mapper.Map<List<UserDto>>(userList);
            return View(detailUser);
        }

        /*
         * [AllowAnonymous]
        public async Task<IActionResult> CreateRole()
        {
            await _roleManager.CreateAsync(new Role() { Name = Roles.Admin });
            await _roleManager.CreateAsync(new Role() { Name = Roles.User });

            return View();
        }
        
        [AllowAnonymous]
        public async Task<IActionResult> AddAdmin()
        {
            await _userManager.CreateAsync(new Core.Models.User { FullName = "Admin", Email = "admin@admin.com", UserName = "Admin", TcNo="12345678911", CarPlate = "34 AA 321"}, "Admin123+");

            var admin = await _userManager.FindByEmailAsync("admin@admin.com");
            await _userManager.AddToRoleAsync(admin, Roles.Admin);
            return View();
        }
        */

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }
            var result = await _userManager.CreateAsync(_mapper.Map<User>(userDto), "1234Aa+");
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(userDto.Email);
                await _userManager.AddToRoleAsync(user, Roles.User);
                return RedirectToAction("AddUser");
            }
            return View();
        }

        public async Task<IActionResult> EditUser(string email)
        {
            var user = await _userService.GetAsync(x => x.Email == email);
            var userEditDto = _mapper.Map<EditUserDto>(user);
            return View(userEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserDto userDto)
        {
            if (!ModelState.IsValid)
                return View(userDto);


            var updateUser = _mapper.Map<User>(userDto);
            var newUser = await _userManager.FindByEmailAsync(updateUser.Email);
            newUser.FullName = updateUser.FullName;
            newUser.TcNo = updateUser.TcNo;
            newUser.UserName = updateUser.UserName;
            newUser.Email = updateUser.Email;
            newUser.PhoneNumber = updateUser.PhoneNumber;
            newUser.CarPlate = updateUser.CarPlate;

            await _userManager.UpdateAsync(newUser);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
    }
}
