using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.DTOs
{
    public class LoginDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
