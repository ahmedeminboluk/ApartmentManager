using ApartmentManager.Core.Models;
using ApartmentManager.Core.Services;
using ApartmentManager.Web.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.Controllers
{
    public class UserExpense : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserExpense(IExpenseService expenseService, IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = HttpContext.User.Identity.Name;
            var result = await _userService.GetAsync(x => x.UserName == user);
            var apartment = result.Apartments;
            var apartmentWithExpense = _mapper.Map<List<ListApartmentWithExpenseDto>>(apartment);
            return View(apartmentWithExpense);
        }
    }
}
