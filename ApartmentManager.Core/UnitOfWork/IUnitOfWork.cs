using ApartmentManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Core
{
    public interface IUnitofWork
    {
        IApartmentRepository Apartments { get; }
        IExpenseRepository Expenses { get; }
        Task<int> CommitAsync();
        int Commit();
    }
}
