using ApartmentManager.Core.Models;
using ApartmentManager.Core.Services;
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
    [Authorize(Roles = Roles.Admin )]
    public class ApartmentController : Controller
    {
        private UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IApartmentService _apartmentService;
        private readonly IMapper _mapper;

        public ApartmentController(UserManager<User> userManager, IUserService userService, IApartmentService apartmentService, IMapper mapper)
        {
            _userManager = userManager;
            _userService = userService;
            _apartmentService = apartmentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var apartments = await _apartmentService.GetAllAsync();
            var dtoApartments = _mapper.Map<List<ListApartmentDto>>(apartments);
            return View(dtoApartments);
        }

        public async Task<IActionResult> AddApartment()
        {
            var userList = await _userService.GetAllAsync();
            ViewBag.userList = userList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddApartment(ApartmentDto apartmentDto)
        {
            var findUser = await _userManager.FindByIdAsync(apartmentDto.UserId);
            var apartment = _mapper.Map<Apartment>(apartmentDto);
            apartment.User = findUser;
            var task = await _apartmentService.AddAsync(apartment);
            if (task > 0) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> EditApartment(int id)
        {
            var detailApartment = await _apartmentService.GetAsync(x => x.Id == id);
            ViewBag.userId = detailApartment.User.Id;

            var userList = await _userService.GetAllAsync();
            ViewBag.userList = userList;

            var editApartment = _mapper.Map<EditApartmentDto>(detailApartment);

            return View(editApartment);
        }

        [HttpPost]
        public async Task<IActionResult> EditApartment(EditApartmentDto apartmentDto)
        {
            var findUser = await _userManager.FindByIdAsync(apartmentDto.UserId);
            var apartment = _mapper.Map<Apartment>(apartmentDto);
            apartment.User = findUser;
            var entity = _apartmentService.Update(apartment);
            if (entity != null) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> DeleteApartment(int id)
        {
            var apartment = await _apartmentService.GetAsync(x => x.Id == id);
            _apartmentService.Delete(apartment);
            return RedirectToAction("Index");
        }
    }
}
