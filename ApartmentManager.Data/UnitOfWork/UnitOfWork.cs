using ApartmentManager.Core;
using ApartmentManager.Core.Repositories;
using ApartmentManager.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Data.UnitOfWork
{
    public class UnitOfWork : IUnitofWork
    {
        public IApartmentRepository Apartments { get; }
        public IExpenseRepository Expenses { get; }
        public IMessageRepository Messages { get; }
        private readonly ApartmentManagerDbContext _context;

        public UnitOfWork(ApartmentManagerDbContext context, IApartmentRepository apartmentRepository, IExpenseRepository expenseRepository, IMessageRepository messageRepository)
        {
            _context = context;
            Apartments = apartmentRepository;
            Expenses = expenseRepository;
            Messages = messageRepository;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
