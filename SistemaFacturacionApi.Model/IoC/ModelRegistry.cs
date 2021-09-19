using Microsoft.Extensions.DependencyInjection;
using SistemaFacturacionApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.Model.IoC
{
    public static class ModelRegistry
    {
        public static void AddModelRegistry(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
