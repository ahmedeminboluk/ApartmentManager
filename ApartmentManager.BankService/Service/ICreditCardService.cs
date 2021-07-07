using ApartmentManager.BankService.Model.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.BankService.Service
{
    public interface ICreditCardService
    {
        Task<bool> WithdrawMoney(CreditCard creditCard, int money);
    }
}
