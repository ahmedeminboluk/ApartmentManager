using ApartmentManager.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Data.Seeds
{
    public class RoleSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "600a7c55-6614-4607-b9ec-984f99a40bd8",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "8843758e-31d0-4fac-8cd2-555921055b30"

                },
                new IdentityRole
                {
                    Id = "9047da04-ffb9-42ff-bb56-921cbbc67b95",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "09f6efc7-db89-44b1-8e5f-d3452483b809"
                });
        }
    }
}
