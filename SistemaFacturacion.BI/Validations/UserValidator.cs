using FluentValidation;
using SistemaFacturacionApi.BI.Dtos;

namespace SistemaFacturacionApi.BI.Validations
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("User's Name is required");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("User's LastName is required");
            RuleFor(x => x.Direction)
                .NotEmpty()
                .WithMessage("User's Direction is required");
            RuleFor(x => x.Telephone)
                .NotEmpty()
                .WithMessage("User's Telephone is required")
                .Matches(@"/^(1\s?)?(849\s?|809\s?|809|849)[\s\-]?\d{3}[\s\-]?\d{4}$/")
                .WithMessage("User's Telephone is not valid");
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("User's UserName is required");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("User's Password is required");

        }
    }
}
