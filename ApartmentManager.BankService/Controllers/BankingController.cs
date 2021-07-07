using ApartmentManager.BankService.Service;
using ApartmentManager.BankService.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.BankService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;

        public BankingController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost("WithdrawMoney")]
        public async Task<IActionResult> WithdrawMoney(CreditCardViewModel model)
        {
            var result = await _creditCardService.WithdrawMoney(new Model.Mongo.CreditCard
            {
                CardNumber = model.CardNumber,
                Cvv = model.Cvv,
                Owner = model.Owner,
                ValidMonth = model.ValidMonth,
                ValidYear = model.ValidYear
            }, model.Money);
            return Ok(result);
        }
    }
}
