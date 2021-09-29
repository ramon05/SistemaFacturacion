using FluentValidation;
using SistemaFacturacionApi.BI.Dtos;

namespace SistemaFacturacionApi.BI.Validations
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Customer's Name is required");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Customer's LastName is required");
            RuleFor(x => x.Direction)
                .NotEmpty()
                .WithMessage("Customer's Direction is required");
            RuleFor(x => x.Telephone)
                .NotEmpty()
                .WithMessage("Customer's Telephone is required")
                .Matches(@"/^(1\s?)?(849\s?|809\s?|809|849)[\s\-]?\d{3}[\s\-]?\d{4}$/")
                .WithMessage("Customer's Telephone is not valid");
        }
    }
}
