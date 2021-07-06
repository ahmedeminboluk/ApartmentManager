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
    public class ApartmentService : Service<Apartment>, IApartmentService
    {
        public ApartmentService(IUnitofWork unitOfWork, IRepository<Apartment> repository) : base(unitOfWork, repository)
        {
        }
    }
}
