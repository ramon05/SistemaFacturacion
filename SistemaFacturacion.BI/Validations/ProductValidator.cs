using FluentValidation;
using SistemaFacturacionApi.BI.Dtos;

namespace SistemaFacturacionApi.BI.Validations
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Product's Name is required");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Product's Description is required");
            RuleFor(x => x.Stock)
                .NotEmpty()
                .WithMessage("Product's Stock is required");
        }
    }
}
