using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.DTOs
{
    public class EditApartmentDto
    {
        public int Id { get; set; }
        public string ApartmentBlock { get; set; }
        public bool Status { get; set; } // dolu-boş
        public string Type { get; set; } // 2+1 
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        public bool IsOwner { get; set; } // 1:sahibi, 0:kiracı
        public string UserId { get; set; }
    }
}
