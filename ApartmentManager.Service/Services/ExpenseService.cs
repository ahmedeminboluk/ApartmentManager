using ApartmentManager.Core;
using ApartmentManager.Core.Models;
using ApartmentManager.Core.Repositories;
using ApartmentManager.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Service.Services
{
    public class ExpenseService : Service<Expense>, IExpenseService
    {
        public ExpenseService(IUnitofWork unitOfWork, IRepository<Expense> repository) : base(unitOfWork, repository)
        {
        }
    }
}
