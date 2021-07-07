using ApartmentManager.Core.Services;
using ApartmentManager.Service.CreditCardService;
using ApartmentManager.Service.Dto;
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
    [Authorize(Roles = Roles.User)]
    public class PaymentController : Controller
    {
        private readonly ICreditCardService _creditCardService;
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper;

        public PaymentController(ICreditCardService creditCardService, IExpenseService expenseService, IMapper mapper)
        {
            _creditCardService = creditCardService;
            _expenseService = expenseService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Payment(int id)
        {
            var expense =  await _expenseService.GetAsync(x => x.Id == id);
            ViewBag.id = expense.Id;
            ViewBag.total = (float)(expense.Dues + expense.Electric + expense.Water + expense.Gas);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Payment(CreditCardExpenseDto creditCardExpenseDto)
        {
            
            var creditCard = _mapper.Map<CreditCardDto>(creditCardExpenseDto);
            bool result = await _creditCardService.WithdrawMoney(creditCard);

            if (result == true)
            {
                var expense = await _expenseService.GetAsync(x => x.Id == creditCardExpenseDto.ExpenseId);
                expense.IsPaid = true;
                _expenseService.Update(expense);
                return RedirectToAction("Index", "UserExpense");
            }
            return View();
        }
    }
}
