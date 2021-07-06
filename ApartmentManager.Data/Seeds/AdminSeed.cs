using ApartmentManager.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Data
{
    public class AdminSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var admin = new User()
            {
                Id = "95587827-f1ae-4bb1-b0b4-6777cf57ca07",
                Email = "admin@admin.com",
                EmailConfirmed = false,
                TcNo = "12345678911",
                FullName = "Admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN"
            };

            PasswordHasher<User> ph = new PasswordHasher<User>();
            admin.PasswordHash = ph.HashPassword(admin, "Admin123+");


            builder.HasData(admin);
        }
    }
}
