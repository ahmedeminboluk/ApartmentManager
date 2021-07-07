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
                UserName = "Admin",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                CarPlate = "34 AA 33",
                PasswordHash = "AQAAAAEAACcQAAAAEPrUVh6ka22DMBtGoUnY6ordfeY1ag3wwg3IY1+l/waeRNZ3b/AS6a4BrAdLauipEA==",
                SecurityStamp = "9c9e5864-93f7-4c5b-8326-9d8a1f6d0302",
                ConcurrencyStamp = "ee6f5d33-2ebd-4c6f-bfa0-a3a5bc06653f",
                NormalizedUserName = "ADMIN"
                
            };

            PasswordHasher<User> ph = new PasswordHasher<User>();
            admin.PasswordHash = ph.HashPassword(admin, "Admin123+");


            builder.HasData(admin);
        }
    }
}
