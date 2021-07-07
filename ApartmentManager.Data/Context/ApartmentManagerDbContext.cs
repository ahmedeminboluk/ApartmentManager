using ApartmentManager.Core.Models;
using ApartmentManager.Data.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Data.Context
{
    public class ApartmentManagerDbContext : IdentityDbContext<User, Role, string>
    {
        public ApartmentManagerDbContext(DbContextOptions<ApartmentManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AdminSeed());
            builder.ApplyConfiguration(new RoleSeed());
            builder.ApplyConfiguration(new AdminRoleSeed());
            base.OnModelCreating(builder);
        }
    }
}
