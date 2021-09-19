
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaFacturacionApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.BI.Config
{
    public static class FluentValidationConfig
    {
        public static IMvcBuilder configFluentValidation(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(x =>
            {
                x.AutomaticValidationEnabled = false;
                x.RegisterValidatorsFromAssemblyContaining<Customer>();
            });

            return builder;
        }
    }
}
