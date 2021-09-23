using FluentValidation;
using SistemaFacturacionApi.BI.Dtos;

namespace SistemaFacturacionApi.BI.Validations
{
    public class AuthenticateRequestValidator : AbstractValidator<AuthenticateRequestDto>
    {
        public AuthenticateRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("User's Name is required");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("User's Password is required")
                .MaximumLength(8)
                .WithMessage("Password's length must be at least 8 characters");
        }
    }
}
