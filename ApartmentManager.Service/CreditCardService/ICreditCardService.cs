using ApartmentManager.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Service.CreditCardService
{
    public interface ICreditCardService
    {
        Task<bool> WithdrawMoney(CreditCardDto creditCardDto);
    }
}
