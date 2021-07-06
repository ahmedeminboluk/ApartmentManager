using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Core.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Dues { get; set; }
        public decimal Electric { get; set; }
        public decimal Water { get; set; }
        public decimal Gas { get; set; }
        public bool IsPaid { get; set; }
        public DateTime ExpenseDate { get; set; }

        public virtual Apartment Apartment { get; set; }
    }
}
