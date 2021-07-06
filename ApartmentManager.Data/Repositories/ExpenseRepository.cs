using ApartmentManager.Core.Models;
using ApartmentManager.Core.Repositories;
using ApartmentManager.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Data.Repositories
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApartmentManagerDbContext context) : base(context)
        {
        }
    }
}
