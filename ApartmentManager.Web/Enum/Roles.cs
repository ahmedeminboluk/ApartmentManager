using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.Enum
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";

    }

    public enum RoleTypes : byte
    {
        [Description(Roles.Admin)]
        Admin = 1,
        [Description(Roles.User)]
        User
    }
}
