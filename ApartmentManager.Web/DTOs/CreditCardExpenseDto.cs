using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.DTOs
{
    public class CreditCardExpenseDto
    {
        public string Owner { get; set; }
        public string CardNumber { get; set; }
        public string ValidMonth { get; set; }
        public string ValidYear { get; set; }
        public string Cvv { get; set; }

        public int Money { get; set; }

        public int ExpenseId { get; set; }
    }
}
