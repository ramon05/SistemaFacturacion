using Microsoft.Extensions.DependencyInjection;
using SistemaFacturacionApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.Services.IoC
{
    public static class ServicesRegistry
    {
        public static void AddServiceRegistry(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
