using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Core.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string TcNo { get; set; }
        public string CarPlate { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
