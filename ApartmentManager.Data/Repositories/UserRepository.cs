using ApartmentManager.Core.Models;
using ApartmentManager.Core.Repositories;
using ApartmentManager.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApartmentManagerDbContext context) : base(context)
        {
        }
    }
}
