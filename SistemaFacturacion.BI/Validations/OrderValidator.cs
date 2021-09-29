using FluentValidation;
using SistemaFacturacionApi.BI.Dtos;

namespace SistemaFacturacionApi.BI.Validations
{
    public class OrderValidator : AbstractValidator<OrderDto>
    {
        public OrderValidator()
        {
            RuleFor(x => x.NumberOrder)
                .NotEmpty()
                .WithMessage("Number Order is required");
            RuleFor(x => x.DateOrder)
                .NotEmpty()
                .WithMessage("order date is required");
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("User is required");
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Customer is required");
        }
    }
}
