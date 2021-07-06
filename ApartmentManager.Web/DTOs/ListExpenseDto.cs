using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.DTOs
{
    public class ListExpenseDto
    {
        public int Id { get; set; }
        public decimal Dues { get; set; }
        public decimal Electric { get; set; }
        public decimal Water { get; set; }
        public decimal Gas { get; set; }
        public bool IsPaid { get; set; }
        public DateTime ExpenseDate { get; set; }
        public ApartmentDto Apartment { get; set; }
    }
}
