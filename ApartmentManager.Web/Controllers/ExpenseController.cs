using ApartmentManager.Core.Models;
using ApartmentManager.Core.Services;
using ApartmentManager.Web.DTOs;
using ApartmentManager.Web.Enum;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class ExpenseController : Controller
    {
        private readonly IApartmentService _apartmentService;
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper;

        public ExpenseController(IApartmentService apartmentService, IExpenseService expenseService, IMapper mapper)
        {
            _apartmentService = apartmentService;
            _expenseService = expenseService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
           var listExpense = await _expenseService.GetAllAsync();
           
           var listExpenseDto = _mapper.Map<List<ListExpenseDto>>(listExpense);
            return View(listExpenseDto);
        }

        public async Task<IActionResult> AddExpense(int id)
        {
            var apartment = await _apartmentService.GetAsync(x => x.Id == id);
            ViewBag.apartmentId = apartment.Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpenseDto expenseDto)
        {
            var expense = _mapper.Map<Expense>(expenseDto);
            var apartment = await _apartmentService.GetAsync(x => x.Id == expenseDto.ApartmentId);
            expense.Apartment = apartment;
            var id = await _expenseService.AddAsync(expense);
            if (id > 0) return RedirectToAction("Index");
            return View();
        }

        public IActionResult AddAllExpense()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAllExpense(ExpenseDto expenseDto)
        {
            var apartments = await _apartmentService.GetAllAsync();
            var listExpenseDto = new List<Expense>();
            foreach (var item in apartments)
            {
                var expense = new Expense
                {
                    Dues = expenseDto.Dues,
                    Electric = expenseDto.Electric,
                    Water = expenseDto.Water,
                    Gas = expenseDto.Gas,
                    IsPaid = expenseDto.IsPaid,
                    ExpenseDate = expenseDto.ExpenseDate,
                    Apartment = item
                };
                listExpenseDto.Add(expense);
            }
            var id = await _expenseService.AddAllAsync(listExpenseDto);
            if (id > 0) return RedirectToAction("Index");
            
            return View();
        }

        public async Task<IActionResult> EditExpense(int id)
        {
            var apartmentList =  await _apartmentService.GetAllAsync();
            
            ViewBag.apartmentList = _mapper.Map<List<DropdownApartmentDto>>(apartmentList);
            var expense = await _expenseService.GetAsync(x => x.Id == id);
            ViewBag.apartmentId = expense.Apartment.Id;
            
            return View(_mapper.Map<EditExpenseDto>(expense));
        }

        [HttpPost]
        public async Task<IActionResult> EditExpense(EditExpenseDto expenseDto)
        {
            var apartment = await _apartmentService.GetAsync(x => x.Id == expenseDto.ApartmentId);
            var expense = _mapper.Map<Expense>(expenseDto);
            expense.Apartment = apartment;
            var updateExpense = _expenseService.Update(expense);
            if (updateExpense != null) return RedirectToAction("Index");
            return View(expenseDto);
        }

        public async Task<IActionResult> DeleteExpense(int id)
        {
            var expense = await _expenseService.GetAsync(x => x.Id == id);
            _expenseService.Delete(expense);
            return RedirectToAction("Index");
        }
    }
}
