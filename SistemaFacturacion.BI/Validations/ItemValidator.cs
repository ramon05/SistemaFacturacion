using FluentValidation;
using SistemaFacturacionApi.BI.Dtos;

namespace SistemaFacturacionApi.BI.Validations
{
    public class ItemValidator : AbstractValidator<ItemDto>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("Order's Quantity is required");
            RuleFor(x => x.OrderId)
                .NotEmpty()
                .WithMessage("Item's Order is required");
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Item's Product is required");
        }
    }
}
