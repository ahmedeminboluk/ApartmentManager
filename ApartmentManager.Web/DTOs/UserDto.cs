﻿using ApartmentManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.DTOs
{
    public class UserDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string TcNo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CarPlate { get; set; }
    }
}
