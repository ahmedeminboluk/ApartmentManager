using ApartmentManager.Core;
using ApartmentManager.Core.Models;
using ApartmentManager.Core.Repositories;
using ApartmentManager.Core.Services;
using ApartmentManager.Data.Context;
using ApartmentManager.Data.Repositories;
using ApartmentManager.Data.UnitOfWork;
using ApartmentManager.Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Service.Dependencies
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApartmentManagerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ApartmentManagerDbContext>();

            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMessageService, MessageService>();


            services.AddScoped<IUnitofWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));

            return services;
        }
    }
}
