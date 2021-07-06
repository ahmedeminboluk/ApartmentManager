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
    public class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ApartmentManagerDbContext context) : base(context)
        {
        }
    }
}
