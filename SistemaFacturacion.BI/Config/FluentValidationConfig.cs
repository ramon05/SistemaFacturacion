
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaFacturacionApi.BI.Validations;

namespace SistemaFacturacionApi.BI.Config
{
    public static class FluentValidationConfig
    {
        public static IMvcBuilder configFluentValidation(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(x =>
            {
                x.AutomaticValidationEnabled = false;
                x.RegisterValidatorsFromAssemblyContaining<CustomerValidator>();
            });

            return builder;
        }
    }
}
