using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Core.Models
{
    public class Role : IdentityRole
    {
    }

    public enum RoleTypes : byte
    {
        Admin = 1,
        User
    }
}
